using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using HCQ2_IDAL;
using HCQ2_Model;
using HCQ2_Common.SQL;
using HCQ2_Common;

namespace HCQ2_DAL_MSSQL
{
    /// <summary>
    ///  单位表 业务层实现
    /// 创建人：Joychen
    /// 创建时间：2016-12-15
    /// </summary>
    public partial class B01DAL : IB01DAL
    {
        /// <summary>
        ///  参数
        /// </summary>
        private Dictionary<string, object> _param = new Dictionary<string, object>();
        /// <summary>
        ///  sql语句
        /// </summary>
        private StringBuilder sb = new StringBuilder();
        /// <summary>
        ///  根据单位代码获取子单位信息
        ///  单位代为为空，查询所有单位
        /// </summary>
        /// <param name="unitID"></param>
        /// <returns></returns>
        public List<B01> GetB01Info(int user_id,string unitID=null)
        {
            List<B01> list = null;
            if (string.IsNullOrEmpty(unitID))
            {
                if (user_id <= 0)
                    //查询所有单位
                    list = Select<int>(o => !string.IsNullOrEmpty(o.UnitID), o => o.DispOrder);
                else
                {
                    T_PermissionsDAL pDal = new T_PermissionsDAL();
                    List<int> rolelist = pDal.GetRolesListById(user_id);
                    if (null == rolelist || rolelist.Count <= 0)
                    {
                        rolelist = new List<int>();
                        rolelist.Add(0);
                    }
                    StringBuilder sb = new StringBuilder();
                    /***
                    *根据当前人员权限获取单位信息：注意包含两部分
                    *1：用户管理 代管配置
                    *2：权限管理允许新增单位管理权限，并对其配置
                    *3：区域权限分配
                    **/
                    sb.Append(string.Format(@"SELECT e1.* FROM
                        (SELECT * FROM 
                        (SELECT DISTINCT c1.UnitID FROM
                        (SELECT per_id FROM dbo.T_RolePermissRelation WHERE role_id IN({0})) a1 INNER JOIN
                        (SELECT per_id FROM dbo.T_Permissions WHERE per_type = 'unitManager') b1 ON a1.per_id = b1.per_id INNER JOIN
                        (SELECT per_id,UnitID FROM dbo.T_B01PermissRelation) c1 ON a1.per_id = c1.per_id) d1 
                        UNION
                        SELECT * FROM 
                        (SELECT DISTINCT bb.UnitID FROM
                        (SELECT per_id FROM dbo.T_RolePermissRelation WHERE role_id IN({0})) aa1 INNER JOIN
                        (SELECT per_id FROM dbo.T_Permissions WHERE per_type = 'areaManager') pp1 ON aa1.per_id = pp1.per_id INNER JOIN
                        (SELECT per_id,area_code FROM dbo.T_AreaPermissRelation) area ON aa1.per_id = area.per_id INNER JOIN
                        (SELECT * FROM dbo.B01) bb ON bb.SSWG=area.area_code) dd1
                        UNION
                        (SELECT DISTINCT unit_id FROM dbo.T_UserUnitRelation WHERE user_id={1})) f1 INNER JOIN
                        (SELECT * FROM dbo.B01) e1 ON f1.UnitID = e1.UnitID ", string.Join(",", rolelist.ToArray()),
                        user_id));
                    DataTable dt = HCQ2_Common.SQL.SqlHelper.ExecuteDataTable(sb.ToString(), CommandType.Text);
                    list = HCQ2_Common.Data.DataTableHelper.DataTableToIList<B01>(dt);
                }
            }
            else
                //子单位UnitID.StartsWith(unitID)：like '1001%'
                list = Select<int>(s => s.KeyParent== unitID, s => s.DispOrder);            
            return list;
        }
        /// <summary>
        ///  获取项目月增长
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public List<HCQ2_Model.APPModel.ResultApiModel.ChartProject> GetProjectMonthGrow(HCQ2_Model.APPModel.ParamModel.DebtAllGrantModel model)
        {
            sb?.Clear();
            sb.Append(string.Format(@"SELECT CAST(SUBSTRING(T.createDate,6,2) AS INT) AS month,COUNT(T.UnitID) AS projectCount FROM 
                (SELECT CONVERT(varchar(7),B0183,120) AS createDate,UnitID FROM dbo.B01 WHERE ISNULL(B0183,'')<>'' AND CONVERT(varchar(7),B0183,120) BETWEEN @startDate AND @endDate )T GROUP BY T.createDate;"));
            _param?.Clear();
            _param.Add("@startDate", model.startDate);
            _param.Add("@endDate", model.endDate); 
            DataTable dt = SqlHelper.ExecuteDataTable(sb.ToString(), CommandType.Text, SqlHelper.GetParameters(_param));
            return HCQ2_Common.Data.DataTableHelper.DataTableToIList<HCQ2_Model.APPModel.ResultApiModel.ChartProject>(dt);
        }
        /// <summary>
        ///  获取项目总增长
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public List<HCQ2_Model.APPModel.ResultApiModel.ChartProject> GetProjectAllGrow(HCQ2_Model.APPModel.ParamModel.DebtAllGrantModel model)
        {
            sb?.Clear();
            sb.Append(string.Format(@"SELECT COUNT(UnitID) FROM dbo.B01 WHERE ISNULL(B0183,'')<>'' AND CONVERT(varchar(7),B0183,120)<=@date"));
            string[] start = model.startDate.Split('-');
            string[] end = model.endDate.Split('-');
            int startYear = Helper.ToInt(start[0]);
            int endYear = Helper.ToInt(end[0]);
            int startMonth = Helper.ToInt(start[1]);
            int endMonth = Helper.ToInt(end[1]);
            if ((startYear * 12 + startMonth) > (endYear * 12 + endMonth))
                return null;
            List<HCQ2_Model.APPModel.ResultApiModel.ChartProject> list = new List<HCQ2_Model.APPModel.ResultApiModel.ChartProject>();
            while (startYear+"-"+ (startMonth>9?startMonth.ToString(): "0"+startMonth.ToString()) != model.endDate)
            {
                _param?.Clear();
                _param.Add("@date", startYear + "-" + (startMonth > 9 ? startMonth.ToString() : "0" + startMonth.ToString()));
                int count = Helper.ToInt(SqlHelper.ExecuteScalar(sb.ToString(), CommandType.Text, SqlHelper.GetParameters(_param)));
                if (count > 0)
                    list.Add(new HCQ2_Model.APPModel.ResultApiModel.ChartProject { month = startMonth, projectCount = count });
                startMonth++;
                if (startMonth > 12)
                {
                    startMonth = 1;
                    startYear++;
                }
            }
            if(startYear + "-" + (startMonth > 9 ? startMonth.ToString() : "0" + startMonth.ToString()) == model.endDate)
            {
                _param?.Clear();
                _param.Add("@date", startYear + "-" + (startMonth > 9 ?  startMonth.ToString(): "0" + startMonth.ToString()));
                int count = Helper.ToInt(SqlHelper.ExecuteScalar(sb.ToString(), CommandType.Text, SqlHelper.GetParameters(_param)));
                if (count > 0)
                    list.Add(new HCQ2_Model.APPModel.ResultApiModel.ChartProject { month = startMonth, projectCount = count });
            }
            return list;
        }

        /// <summary>
        /// 根据年月获取采集数量
        /// </summary>
        /// <param name="year"></param>
        /// <param name="month"></param>
        /// <returns></returns>
        public int GetSaveByYearMonth(int year, int month) {
            sb = new StringBuilder();
            sb.AppendFormat(" select count(*) from b01 where year(b0183)={0}", year);
            sb.AppendFormat(" and month(b0183)={0} ", month);
            return Convert.ToInt32(HCQ2_Common.SQL.SqlHelper.ExecuteScalar(sb.ToString()));

        }
    }
}
