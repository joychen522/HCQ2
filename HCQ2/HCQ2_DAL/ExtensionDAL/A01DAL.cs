using System.Collections.Generic;
using System.Linq;
using HCQ2_Model;
using HCQ2_Model.SelectModel;
using System.Data;
using HCQ2_Common.SQL;
using HCQ2_Common;
using System.Text;
using System;

namespace HCQ2_DAL_MSSQL
{
    public partial class A01DAL : HCQ2_IDAL.IA01DAL
    {
        /// <summary>
        ///  参数
        /// </summary>
        private Dictionary<string, object> _param = new Dictionary<string, object>();
        /// <summary>
        ///  sql语句
        /// </summary>
        private StringBuilder sb = new StringBuilder();

        public List<ListBoxModel> GetPersonByB0002(string unitID)
        {
            List<ListBoxModel> list = new List<ListBoxModel>();
            var query = (from o in db.Set<A01>()
                         where o.UnitID == unitID
                         select new { o.A0101, o.A0177 }).ToList();
            foreach (var item in query)
                list.Add(new ListBoxModel() { text = item.A0101, value = item.A0177 });
            return list;
        }

        public List<A01> GetPeronsBySel(List<string> pserons, string UnitID)
        {
            return (from o in db.Set<A01>()
                    where pserons.Contains(o.A0177) && o.UnitID == UnitID
                    select o).ToList();
        }
        /// <summary>
        ///  获取人员月增长
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public List<HCQ2_Model.APPModel.ResultApiModel.ChartPerson> GetPersonMonthGrow(HCQ2_Model.APPModel.ParamModel.DebtAllGrantModel model)
        {
            sb?.Clear();
            sb.Append(string.Format(@"SELECT CAST(SUBSTRING(T.createDate,6,2) AS INT) AS month,COUNT(T.UnitID) AS perCount FROM 
(SELECT CONVERT(varchar(7),create_time,120) AS createDate,UnitID FROM dbo.A01 WHERE ISNULL(create_time,'')<>'' AND 
CONVERT(varchar(7),create_time,120) BETWEEN @startDate AND @endDate )T GROUP BY T.createDate;"));
            _param?.Clear();
            _param.Add("@startDate", model.startDate);
            _param.Add("@endDate", model.endDate);
            DataTable dt = SqlHelper.ExecuteDataTable(sb.ToString(), CommandType.Text, SqlHelper.GetParameters(_param));
            return HCQ2_Common.Data.DataTableHelper.DataTableToIList<HCQ2_Model.APPModel.ResultApiModel.ChartPerson>(dt);
        }
        /// <summary>
        ///  获取人员总增长
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public List<HCQ2_Model.APPModel.ResultApiModel.ChartPerson> GetPersonAllGrow(HCQ2_Model.APPModel.ParamModel.DebtAllGrantModel model)
        {
            sb?.Clear();
            sb.Append(string.Format(@"SELECT COUNT(UnitID) FROM dbo.A01 WHERE ISNULL(create_time,'')<>'' AND CONVERT(varchar(7),create_time,120)<=@date;"));
            string[] start = model.startDate.Split('-');
            string[] end = model.endDate.Split('-');
            int startYear = Helper.ToInt(start[0]);
            int endYear = Helper.ToInt(end[0]);
            int startMonth = Helper.ToInt(start[1]);
            int endMonth = Helper.ToInt(end[1]);
            if ((startYear * 12 + startMonth) > (endYear * 12 + endMonth))
                return null;
            List<HCQ2_Model.APPModel.ResultApiModel.ChartPerson> list = new List<HCQ2_Model.APPModel.ResultApiModel.ChartPerson>();
            while (startYear + "-" + (startMonth > 9 ? startMonth.ToString() : "0" + startMonth.ToString()) != model.endDate)
            {
                _param?.Clear();
                _param.Add("@date", startYear + "-" + (startMonth > 9 ? startMonth.ToString() : "0" + startMonth.ToString()));
                int count = Helper.ToInt(SqlHelper.ExecuteScalar(sb.ToString(), CommandType.Text, SqlHelper.GetParameters(_param)));
                if (count > 0)
                    list.Add(new HCQ2_Model.APPModel.ResultApiModel.ChartPerson { month = startMonth, perCount = count });
                startMonth++;
                if (startMonth > 12)
                {
                    startMonth = 1;
                    startYear++;
                }
            }
            if (startYear + "-" + (startMonth > 9 ? startMonth.ToString() : "0" + startMonth.ToString()) == model.endDate)
            {
                _param?.Clear();
                _param.Add("@date", startYear + "-" + (startMonth > 9 ? startMonth.ToString() : "0" + startMonth.ToString()));
                int count = Helper.ToInt(SqlHelper.ExecuteScalar(sb.ToString(), CommandType.Text, SqlHelper.GetParameters(_param)));
                if (count > 0)
                    list.Add(new HCQ2_Model.APPModel.ResultApiModel.ChartPerson { month = startMonth, perCount = count });
            }
            return list;
        }

        #region    信息获取

        /// <summary>
        /// 根据RowID获取人员信息
        /// </summary>
        /// <param name="RowID"></param>
        /// <returns></returns>
        public DataTable GetA01ByRowID(string RowID)
        {
            sb = new StringBuilder();
            sb.AppendFormat("select E03861=(select CodeItemName from SM_CodeItems where CodeID='JA' and CodeItemID=E0386),");
            sb.AppendFormat("B00031=(select CodeItemName from SM_CodeItems where CodeID='J' and CodeItemID=B0003),");
            sb.AppendFormat("A01071=(select CodeItemName from SM_CodeItems where CodeID='AX' and CodeItemID=A0107),");
            sb.AppendFormat("A01081=(select CodeItemName from SM_CodeItems where CodeID='JDXL' and CodeItemID=A0108),");
            sb.AppendFormat("A01211=(select CodeItemName from SM_CodeItems where CodeID='AE' and CodeItemID=A0121),");
            sb.AppendFormat("A01141=(select CodeItemName from SM_CodeItems where CodeID='AB' and CodeItemID=A0114),");
            sb.AppendFormat("A01101=(select CodeItemName from SM_CodeItems where CodeID='HP' and CodeItemID=A0110),");
            sb.AppendFormat("A01271=(select CodeItemName from SM_CodeItems where CodeID='BG' and CodeItemID=A0127),");
            sb.AppendFormat("A01281=(select CodeItemName from SM_CodeItems where CodeID='AT' and CodeItemID=A0128),");
            sb.AppendFormat("A01201=(select CodeItemName from SM_CodeItems where CodeID='45' and CodeItemID=A0120),");
            sb.AppendFormat("B0001x=(select UnitName from B01 where UnitID=B0001),");
            sb.AppendFormat("B0002x=(select UnitName from B01 where UnitID=B0002),");
            sb.AppendFormat("B000201x=(select UnitName from B01 where UnitID=B000201),");
            sb.AppendFormat("B000202x=(select UnitName from B01 where UnitID=B000202),");
            sb.AppendFormat("B000203x=(select UnitName from B01 where UnitID=B000203),");
            sb.AppendFormat("* from A01 where RowID='{0}' and if_remove=0 order by DispOrder", RowID);
            DataTable dt = HCQ2_Common.SQL.SqlHelper.ExecuteDataTable(sb.ToString());
            dt.Columns.Remove("A0118");
            dt.Columns.Remove("PersonPhoto");
            dt.Columns.Remove("big_iris_data");
            return dt;
        }

        /// <summary>
        /// 根据单位编号获取人员信息
        /// </summary>
        /// <param name="UnitID"></param>
        /// <returns></returns>
        public DataTable GetA01ByUnitID(string UnitID)
        {
            sb = new StringBuilder();
            sb.AppendFormat("select E03861=(select CodeItemName from SM_CodeItems where CodeID='JA' and CodeItemID=E0386),");
            sb.AppendFormat("B00031=(select CodeItemName from SM_CodeItems where CodeID='J' and CodeItemID=B0003),");
            sb.AppendFormat("A01071=(select CodeItemName from SM_CodeItems where CodeID='AX' and CodeItemID=A0107),");
            sb.AppendFormat("A01081=(select CodeItemName from SM_CodeItems where CodeID='JDXL' and CodeItemID=A0108),");
            sb.AppendFormat("A01211=(select CodeItemName from SM_CodeItems where CodeID='AE' and CodeItemID=A0121),");
            sb.AppendFormat("A01141=(select CodeItemName from SM_CodeItems where CodeID='AB' and CodeItemID=A0114),");
            sb.AppendFormat("A01101=(select CodeItemName from SM_CodeItems where CodeID='HP' and CodeItemID=A0110),");
            sb.AppendFormat("A01271=(select CodeItemName from SM_CodeItems where CodeID='BG' and CodeItemID=A0127),");
            sb.AppendFormat("A01281=(select CodeItemName from SM_CodeItems where CodeID='AT' and CodeItemID=A0128),");
            sb.AppendFormat("A01201=(select CodeItemName from SM_CodeItems where CodeID='45' and CodeItemID=A0120),");
            sb.AppendFormat("B0001x=(select UnitName from B01 where UnitID=B0001),");
            sb.AppendFormat("B0002x=(select UnitName from B01 where UnitID=B0002),");
            sb.AppendFormat("B000201x=(select UnitName from B01 where UnitID=B000201),");
            sb.AppendFormat("B000202x=(select UnitName from B01 where UnitID=B000202),");
            sb.AppendFormat("B000203x=(select UnitName from B01 where UnitID=B000203),");
            sb.AppendFormat("* from A01 where UnitID='{0}' and if_remove=0 order by DispOrder", UnitID);
            DataTable dt = HCQ2_Common.SQL.SqlHelper.ExecuteDataTable(sb.ToString());
            dt.Columns.Remove("A0118");
            dt.Columns.Remove("PersonPhoto");
            dt.Columns.Remove("big_iris_data");
            return dt;
        }

        /// <summary>
        /// 根据单位编号获取人员信息（替换字典）
        /// </summary>
        /// <param name="UnitID"></param>
        /// <returns></returns>
        public DataTable GetPersonByUnitID(string UnitID)
        {
            sb = new StringBuilder();
            sb.AppendFormat("select E0386=(select CodeItemName from SM_CodeItems where CodeID='JA' and CodeItemID=E0386),");
            sb.AppendFormat("B0003=(select CodeItemName from SM_CodeItems where CodeID='J' and CodeItemID=B0003),");
            sb.AppendFormat("A0107=(select CodeItemName from SM_CodeItems where CodeID='AX' and CodeItemID=A0107),");
            sb.AppendFormat("A0108=(select CodeItemName from SM_CodeItems where CodeID='JDXL' and CodeItemID=A0108),");
            sb.AppendFormat("A0121=(select CodeItemName from SM_CodeItems where CodeID='AE' and CodeItemID=A0121),");
            sb.AppendFormat("A0114=(select CodeItemName from SM_CodeItems where CodeID='AB' and CodeItemID=A0114),");
            sb.AppendFormat("A0110=(select CodeItemName from SM_CodeItems where CodeID='HP' and CodeItemID=A0110),");
            sb.AppendFormat("A0127=(select CodeItemName from SM_CodeItems where CodeID='BG' and CodeItemID=A0127),");
            sb.AppendFormat("A0128=(select CodeItemName from SM_CodeItems where CodeID='AT' and CodeItemID=A0128),");
            sb.AppendFormat("A0120=(select CodeItemName from SM_CodeItems where CodeID='45' and CodeItemID=A0120),");
            sb.AppendFormat("B0001=(select UnitName from B01 where UnitID=B0001),");
            sb.AppendFormat("B0002=(select UnitName from B01 where UnitID=B0002),");
            sb.AppendFormat(" * from A01 where UnitID='{0}' and if_remove=0", UnitID);
            return HCQ2_Common.SQL.SqlHelper.ExecuteDataTable(sb.ToString());
        }

        /// <summary>
        /// 获取当前系统所有人员
        /// </summary>
        /// <returns></returns>
        public int GetTotalPersonCount()
        {
            sb = new StringBuilder();
            sb.Append("SELECT COUNT(PersonID) FROM A01 WHERE UnitID in (SELECT UnitID FROM B01) AND if_remove=0 ");
            return Convert.ToInt32(HCQ2_Common.SQL.SqlHelper.ExecuteScalar(sb.ToString()));
        }

        /// <summary>
        /// 根据用户ID获取当前系统所有人员
        /// </summary>
        /// <param name="strUnitID"></param>
        /// <returns></returns>
        public int GetTotalPersonCountByUser(string strUnitID)
        {
            sb = new StringBuilder();
            sb.AppendFormat("select count(*) from A01 where UnitID in ( ");
            sb.AppendFormat(" {0}) and if_remove=0 ", strUnitID);
            return Convert.ToInt32(HCQ2_Common.SQL.SqlHelper.ExecuteScalar(sb.ToString()));
        }

        /// <summary>
        /// 根据项目编号集合获取工种
        /// </summary>
        /// <param name="strUnit"></param>
        /// <returns></returns>
        public DataTable GetWorkJobsByUnitInfo(string strUnit)
        {
            sb = new StringBuilder();
            sb.AppendFormat("select distinct E0386 from A01 where 1=1 and ");
            sb.AppendFormat(" UnitID in ({0}) and if_remove=0", strUnit);
            return HCQ2_Common.SQL.SqlHelper.ExecuteDataTable(sb.ToString());
        }

        /// <summary>
        /// 根据项目编号集合获取工种、姓名集合
        /// </summary>
        /// <param name="strUnit"></param>
        /// <returns></returns>
        public DataTable GetWorkJobsByUnit(string strUnit)
        {
            sb = new StringBuilder();
            sb.AppendFormat("select E0386,A0101 from A01 where  ");
            sb.AppendFormat(" UnitID in ({0}) and if_remove=0", strUnit);
            return HCQ2_Common.SQL.SqlHelper.ExecuteDataTable(sb.ToString());
        }

        /// <summary>
        /// 根据PersonID集合获取人员
        /// </summary>
        /// <param name="strPersonID"></param>
        /// <returns></returns>
        public DataTable GetPersonByStrPersonID(string UnitID, string strPersonID)
        {
            sb = new StringBuilder();
            sb.AppendFormat("select E0386=(select CodeItemName from SM_CodeItems where CodeID='JA' and CodeItemID=E0386),* from A01 ");
            sb.AppendFormat(" where UnitID='{0}' ", UnitID);
            if (!string.IsNullOrEmpty(strPersonID))
                sb.AppendFormat(" and PersonID not in ({0}) ", strPersonID);
            return HCQ2_Common.SQL.SqlHelper.ExecuteDataTable(sb.ToString());
        }

        /// <summary>
        /// 根据年龄段统计人员数量
        /// </summary>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <returns></returns>
        public int GetPersonCountByAge(int start, int end)
        {
            sb = new StringBuilder();
            sb.AppendFormat("select COUNT(distinct A0177) from A01 where C0101<={0} and C0101>{1} and UnitID in (SELECT UnitID FROM B01) AND if_remove=0 and ISNULL(retire_time,'')='' ", end, start);
            return Convert.ToInt32(SqlHelper.ExecuteScalar(sb.ToString()));
        }

        /// <summary>
        /// 获取已经使用的工种的集合
        /// </summary>
        /// <param name="strUnit"></param>
        /// <returns></returns>
        public DataTable GetUserWork(string strUnit)
        {
            sb = new StringBuilder();
            sb.AppendFormat("select distinct E0386 from A01 where if_remove=0 and UnitID in ({0}) ", strUnit);
            return HCQ2_Common.SQL.SqlHelper.ExecuteDataTable(sb.ToString());
        }

        /// <summary>
        /// 根据项目编号获取姓名和工种
        /// </summary>
        /// <param name="strUnit"></param>
        /// <returns></returns>
        public DataTable GetPersonWorkByUnit(string strUnit) {
            sb = new StringBuilder();
            sb.AppendFormat("select E0386,A0101 from A01 where if_remove=0 and UnitID in ({0})", strUnit);
            return HCQ2_Common.SQL.SqlHelper.ExecuteDataTable(sb.ToString());
        }

        /// <summary>
        /// 获取数据展示的项目信息
        /// </summary>
        /// <returns></returns>
        public DataTable GetRollViewModel() {
            sb = new StringBuilder();
            sb.AppendFormat("select UnitID as unit_id,UnitName as unit_name,person_count=(select COUNT(*) from A01");
            sb.AppendFormat(" where UnitID=a.UnitID");
            sb.AppendFormat(" ) from B01 a where len(UnitID)=3 order by person_count desc");
            return HCQ2_Common.SQL.SqlHelper.ExecuteDataTable(sb.ToString());
        }

        /// <summary>
        /// 根据年月获取采集数量
        /// </summary>
        /// <param name="year"></param>
        /// <param name="month"></param>
        /// <returns></returns>
        public int GetSaveByYearMonth(int year, int month) {
            sb = new StringBuilder();
            sb.AppendFormat("select count(*) from a01 where year(create_time)={0}", year);
            sb.AppendFormat(" and month(create_time)={0} ", month);
            return Convert.ToInt32(HCQ2_Common.SQL.SqlHelper.ExecuteScalar(sb.ToString()));
        }

        #endregion
    }
}
