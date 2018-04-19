using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using HCQ2_Common.SQL;
using HCQ2_Common;
using HCQ2_IDAL;
using HCQ2_Model;
using HCQ2_Model.WeiXinApiModel.ResultApiModel;
using HCQ2_Model.WeiXinApiModel.ParamModel;
using HCQ2_Model.APPModel.ParamModel;
using HCQ2_Model.APPModel.ResultApiModel;

namespace HCQ2_DAL_MSSQL
{
    public partial class View_QXTJDAL : IView_QXTJDAL
    {
        /// <summary>
        ///  参数
        /// </summary>
        private Dictionary<string, object> _param = new Dictionary<string, object>();
        /// <summary>
        ///  根据单位代码获取欠薪时间数据模型
        /// </summary>
        /// <param name="unitCode">单位代码</param>
        /// <returns></returns>
        public List<P_QianXin_ShiJian_Result> GetViewTimeData(string unitCode, int keyChild)
        {
            Dictionary<string, object> param = new Dictionary<string, object>();
            param.Add("@B0110", keyChild > 0 ? unitCode + "%" : unitCode);
            param.Add("@startTime", "2016-1-1");
            param.Add("@endTime", "2016-1-1");
            //var query =
            //    (from o in
            //        db.Set<HCQ2_Model.P_QianXin_ShiJian_Result>()
            //            .SqlQuery("exec P_QianXin_ShiJian @B0110,@startTime,@endTime",
            //                HCQ2_Common.SQL.SqlHelper.GetParameters(param))
            //     select o
            //    ).ToList();
            //采用Ado.net方式执行存储过程获取数据
            List<P_QianXin_ShiJian_Result> result = new List<P_QianXin_ShiJian_Result>();
            DataTable dt = SqlHelper.ExecuteDataTable("exec P_QianXin_ShiJian @B0110,@startTime,@endTime",
                CommandType.Text, SqlHelper.GetParameters(param));
            if (null != dt && dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    result.Add(new P_QianXin_ShiJian_Result()
                    {
                        shijian = HCQ2_Common.Helper.ToString(dt.Rows[i]["shijian"]),
                        renshu = HCQ2_Common.Helper.ToInt(dt.Rows[i]["renshu"])
                    });
                }
            }
            return result;
        }
        /// <summary>
        ///  根据单位名称获取单位代码
        /// </summary>
        /// <param name="unitName"></param>
        /// <returns></returns>
        public string GetUnitCodeByName(string unitName)
        {
            if (string.IsNullOrEmpty(unitName))
                return string.Empty;
            var query = (from o in db.Set<View_QXTJ>()
                         where o.B0001Name == unitName
                         select new { o.UnitID }).SingleOrDefault();
            if (query != null)
                return query.UnitID.ToString();
            return string.Empty;
        }

        /// <summary>
        /// 根据项目编号获取项目欠薪统计
        /// </summary>
        /// <param name="UnitID"></param>
        /// <returns></returns>
        public DataTable GetProjectQxtjByUnitID(string UnitID)
        {
            StringBuilder sbSql = new StringBuilder();
            sbSql.AppendFormat("select People,QXTJ01,B0109,B0114,a.B0116,B0180,B0181,B0111,a.UnitID,B0112,SGDWLXR,SGDWLXRDH");
            sbSql.AppendFormat(" from View_QXTJ a left join B01 b on a.UnitID=b.UnitID ");
            sbSql.AppendFormat(" where a.UnitID='{0}' ", UnitID);
            return HCQ2_Common.SQL.SqlHelper.ExecuteDataTable(sbSql.ToString());
        }

        //*********************************WebChat Service*************************************
        /// <summary>
        ///  根据单位/项目代码查询欠薪金额详细
        /// </summary>
        /// <param name="page"></param>
        /// <param name="size"></param>
        /// <param name="orgid"></param>
        /// <returns></returns>
        public List<DebtMoneyResultModel> GetDebtMoneyDetail(DebtMoneyPeopleModel model)
        {
            if (string.IsNullOrEmpty(model.orgid))
                return null;
            StringBuilder sb = new StringBuilder();
            sb.Append(string.Format(@" select top {0} * from
                        (select b1.UnitID,b1.UnitName,SUM(ISNULL(w2.QXTJ01,0)) as QXTJ01,COUNT(w2.A0177) as People,ROW_NUMBER() OVER(order by b1.DispOrder asc) as DispOrder from 
	                        (select UnitName,UnitID,DispOrder from B01) b1 inner join
	                        (select RowID,UnitID from WGJG01 where UnitID=@orgid) w1 on b1.UnitID=w1.UnitID inner join
	                        (select CONVERT(decimal(18, 2), SUM(ISNULL(WGJG0208, 0)) / 10000) AS QXTJ01,A0177,WGJG01RowID from WGJG02 
		                        where ISNULL(WGJG0211,'2')='2' group by WGJG01RowID,A0177) w2 on w1.RowID=w2.WGJG01RowID
	                        group by b1.UnitID,b1.UnitName,b1.DispOrder 
                        ) as A where A.DispOrder>{1};", model.size, (model.page - 1) * model.size));

            _param?.Clear();
            _param.Add("@orgid", model.orgid);
            DataTable dt = SqlHelper.ExecuteDataTable(sb.ToString(), CommandType.Text, SqlHelper.GetParameters(_param));
            return HCQ2_Common.Data.DataTableHelper.DataTableToIList<DebtMoneyResultModel>(dt);
        }
        /// <summary>
        ///   根据单位/项目代码查询欠薪人数详细信息
        /// </summary>
        /// <param name="page"></param>
        /// <param name="size"></param>
        /// <param name="orgid"></param>
        /// <returns></returns>
        public List<DebtPeopleResultModel> GetDebtPeopleDetail(DebtMoneyPeopleModel model)
        {
            if (string.IsNullOrEmpty(model.orgid))
                return null;
            StringBuilder sb = new StringBuilder();
            sb.Append(string.Format(@"select top {0} * from(
                    select w2.WGJG01RowID,b1.UnitID,b1.UnitName,w2.A0101,w2.PersonID,w2.QXTJ01,ROW_NUMBER() OVER(order by WGJG01RowID,PersonID) as DispOrder from 
                    (select UnitName,UnitID from B01) b1 inner join
                    (select RowID,UnitID from WGJG01 where UnitID=@orgid) w1 on b1.UnitID=w1.UnitID inner join
                    (select PersonID,A0101,WGJG01RowID,CONVERT(decimal(18, 2),ISNULL(WGJG0208, 0)) AS QXTJ01 from WGJG02 
	                    where ISNULL(WGJG0211,'2')='2') w2 on w1.RowID=w2.WGJG01RowID
                    )as A where A.DispOrder>{1};", model.size, (model.page - 1) * model.size));
            _param?.Clear();
            _param.Add("@orgid", model.orgid);
            DataTable dt = SqlHelper.ExecuteDataTable(sb.ToString(), CommandType.Text, SqlHelper.GetParameters(_param));
            return HCQ2_Common.Data.DataTableHelper.DataTableToIList<DebtPeopleResultModel>(dt);
        }
        //*********************************APP Service*************************************
        public List<DebtSelResultModel> GetDebtTime(DebtSelModel model, int user_id, List<string> orgid)
        {
            //1：判断是否分配范围
            if (null != orgid || orgid.Count > 0)
            {
                _param.Clear();
                _param.Add("@UnitID", string.Join(",", orgid));
                _param.Add("@startDate", model.startDate);
                _param.Add("@endDate", model.endDate);
                DataTable dt = SqlHelper.ExecuteDataTable("exec P_GetQianXin_ShiJian @UnitID,@startDate,@endDate",
                 CommandType.Text, SqlHelper.GetParameters(_param));
                return HCQ2_Common.Data.DataTableHelper.DataTableToIList<DebtSelResultModel>(dt);
            }
            //2：没有分配范围获取所在单位数据
            List<T_Org_User> oList = new T_Org_UserDAL().Select(s => s.user_id == user_id);
            if (null != oList && oList.Count > 0)
            {
                _param.Clear();
                _param.Add("@UnitID", oList[0].UnitID);
                _param.Add("@startDate", model.startDate);
                _param.Add("@endDate", model.endDate);
                DataTable dt = SqlHelper.ExecuteDataTable("exec P_GetQianXin_ShiJian @UnitID,@startDate,@endDate",
                 CommandType.Text, SqlHelper.GetParameters(_param));
                return HCQ2_Common.Data.DataTableHelper.DataTableToIList<DebtSelResultModel>(dt);
            }
            return null;
        }
        /// <summary>
        ///  APP根据单位，时间条件查询欠薪数据汇总
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public List<DebtDataModel> GetDebtCountDataByOrg(DebtSelGrantModel model)
        {
            _param.Clear();
            _param.Add("@UnitID", model.orgid);
            if (!string.IsNullOrEmpty(model.startDate))
                _param.Add("@startDate", model.startDate + "-01");
            else
                _param.Add("@startDate", "");
            if (!string.IsNullOrEmpty(model.endDate))
                _param.Add("@endDate", model.endDate + "-" + DateTime.DaysInMonth(Helper.ToInt(model.endDate.Split('-')[0]), Helper.ToInt(model.endDate.Split('-')[1])));
            //_param.Add("@endDate", model.endDate+"-"+ Helper.DayByMonth(Helper.ToInt(model.endDate.Split('-')[1])));
            else
                _param.Add("@endDate", "");
            DataTable dt = SqlHelper.ExecuteDataTable("exec P_GetQianXin_Detail @UnitID,@startDate,@endDate",
                 CommandType.Text, SqlHelper.GetParameters(_param));
            return HCQ2_Common.Data.DataTableHelper.DataTableToIList<DebtDataModel>(dt);
        }
        /// <summary>
        ///  APP根据单位，查询时间获取欠薪图表数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public List<DebtMoneyModel> GetDebtChartMonthDataByOrg(DebtSelGrantModel model)
        {
            string[] start = model.startDate.Split('-');
            string[] end = model.endDate.Split('-');
            int startYear = Helper.ToInt(start[0]), endYear = Helper.ToInt(end[0]);
            int startMonth = Helper.ToInt(start[1]),//开始月
                endMonth = Helper.ToInt(end[1]);//结束月
            int temp = Helper.ToInt(end[0]) - Helper.ToInt(start[0]);
            int month = Helper.ToInt(start[1]);
            List<DebtMoneyModel> list = new List<DebtMoneyModel>();
            for (int i = month; i <= (temp * 12 + Helper.ToInt(end[1])); i++)
            {
                if (i % 12 == 0)
                {
                    month = 1;
                    startYear++;
                }
                _param.Clear();
                _param.Add("@UnitID", model.orgid);
                string str = (month > 9) ? month.ToString() : "0" + month.ToString();
                _param.Add("@startDate", startYear.ToString() + "-" + str + "-01");
                _param.Add("@endDate", startYear + "-" + str + "-" + DateTime.DaysInMonth(startYear, month));
                //_param.Add("@endDate", startYear + "-" + str + "-" + Helper.DayByMonth(month));
                DataTable dt = SqlHelper.ExecuteDataTable("exec P_GetQianXin_Detail @UnitID,@startDate,@endDate",
                 CommandType.Text, SqlHelper.GetParameters(_param));
                list.Add(HCQ2_Common.Data.DataTableHelper.DataTableToIList<DebtMoneyModel>(dt).FirstOrDefault());
                month++;
            }
            return list;
        }
        /// <summary>
        ///  APP根据单位，查询时间获取欠薪图表截止月数据汇总
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public List<DebtMoneyModel> GetDebtChartEndMonthDataByOrg(DebtSelGrantModel model)
        {
            string[] start = model.startDate.Split('-');
            string[] end = model.endDate.Split('-');
            int startYear = Helper.ToInt(start[0]), endYear = Helper.ToInt(end[0]);
            int startMonth = Helper.ToInt(start[1]),//开始月
                endMonth = Helper.ToInt(end[1]);//结束月
            int temp = Helper.ToInt(end[0]) - Helper.ToInt(start[0]);
            int month = Helper.ToInt(start[1]);
            List<DebtMoneyModel> list = new List<DebtMoneyModel>();
            for (int i = month; i <= (temp * 12 + Helper.ToInt(end[1])); i++)
            {
                if (i % 12 == 0)
                {
                    month = 1;
                    startYear++;
                }
                _param.Clear();
                _param.Add("@UnitID", model.orgid);
                _param.Add("@startDate", "");
                string str = (month > 9) ? month.ToString() : "0" + month.ToString();
                _param.Add("@endDate", startYear + "-" + str + "-" + DateTime.DaysInMonth(startYear, month));
                //_param.Add("@endDate", startYear + "-" + str + "-" + Helper.DayByMonth(month));
                DataTable dt = SqlHelper.ExecuteDataTable("exec P_GetQianXin_Detail @UnitID,@startDate,@endDate",
                 CommandType.Text, SqlHelper.GetParameters(_param));
                list.Add(HCQ2_Common.Data.DataTableHelper.DataTableToIList<DebtMoneyModel>(dt).FirstOrDefault());
                month++;
            }
            return list;
        }
    }
}
