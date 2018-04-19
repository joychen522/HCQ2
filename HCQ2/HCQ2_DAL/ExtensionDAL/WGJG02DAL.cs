using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using HCQ2_Model;
using HCQ2_Model.SelectModel;
using HCQ2_Model.ViewModel;
using HCQ2_Common;
using HCQ2_Common.SQL;
using HCQ2_Model.WebApiModel.ParamModel;
using HCQ2_Model.WebApiModel.ResultApiModel;
using HCQ2_Model.APPModel.ParamModel;
using HCQ2_Model.APPModel.ResultApiModel;

namespace HCQ2_DAL_MSSQL
{
    public partial class WGJG02DAL:HCQ2_IDAL.IWGJG02DAL
    {
        /// <summary>
        ///  参数
        /// </summary>
        private Dictionary<string, object> _param = new Dictionary<string, object>(); 
        /// <summary>
        ///  sql
        /// </summary>
        private StringBuilder sb = new StringBuilder();
        public List<WGJG02Model> GetWageDetailByRowId(HCQ2_Model.SelectModel.WGJG01ChartModel model)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(@"SELECT w1.WGJG0201,w1.WGJG0202,w1.A0101,w1.A0177,b1.B0002,b1.B0002 AS UnitID,code1.E0386,code2.WGJG0203,w1.WGJG0204,
w1.WGJG0205,w1.WGJG0206,w1.WGJG0207,w1.WGJG0208,w1.WGJG0209,w1.WGJG0211,w1.WGJG0212,w1.PClassID FROM ");
            sb.Append(" (SELECT *,ROW_NUMBER() OVER (ORDER BY RowID) as rank FROM dbo.WGJG02 WHERE PersonID IN (SELECT PersonID FROM dbo.A01) AND ");
            if (!string.IsNullOrEmpty(model.rowID))
                sb.Append(string.Format(" WGJG01RowID='{0}' ", model.rowID));
            else
            {
                sb.Append(string.Format(" WGJG01RowID IN(SELECT RowID FROM dbo.WGJG01 WHERE UnitID LIKE '{0}%' ", model.unitID));
                if (!string.IsNullOrEmpty(model.dateStart) && !string.IsNullOrEmpty(model.dateEnd))
                    sb.Append(string.Format(" AND WGJG0102 BETWEEN '{0}' AND '{1}' ",model.dateStart,model.dateEnd));
                else if (!string.IsNullOrEmpty(model.dateStart))
                    sb.Append(string.Format(" AND WGJG0102>='{0}' ", model.dateStart));
                else if (!string.IsNullOrEmpty(model.dateEnd))
                    sb.Append(string.Format(" AND WGJG0102<='{0}' ", model.dateEnd));
            }
            //关键字
            if (!string.IsNullOrEmpty(model.keyword))
                sb.Append(string.Format(" AND A0101 LIKE '%{0}%' ", model.keyword));
            if (!string.IsNullOrEmpty(model.isGive) && model.isGive.Equals("1"))
                sb.Append(" AND WGJG0211='1'");
            else if (!string.IsNullOrEmpty(model.isGive))
                sb.Append(" AND ISNULL(WGJG0211,'')<>'1'");
            if (string.IsNullOrEmpty(model.rowID))
                sb.Append(")");
            sb.Append(") w1 LEFT JOIN ");
            sb.Append(@"(SELECT UnitID,UnitName AS B0002 FROM dbo.B01) b1 ON w1.UnitID=b1.UnitID LEFT JOIN
(SELECT CodeItemID,CodeItemName AS E0386 FROM dbo.SM_CodeItems WHERE CodeID='JA') code1 ON w1.E0386=code1.CodeItemID LEFT JOIN
(SELECT CodeItemID,CodeItemName AS WGJG0203 FROM dbo.SM_CodeItems WHERE CodeID='GZFFFS') code2 ON w1.WGJG0203=code2.CodeItemID ");
            sb.Append(string.Format(" WHERE w1.rank between {0} and {1};", (model.page - 1)* model.rows, model.page * model.rows));
            DataTable dt = HCQ2_Common.SQL.SqlHelper.ExecuteDataTable(sb.ToString(), CommandType.Text);
            return HCQ2_Common.Data.DataTableHelper.DataTableToIList<WGJG02Model>(dt);
        }

        public List<WGJG02Model> GetWageDetailByUnitID(HCQ2_Model.SelectModel.WGJG02ByUnitID model)
        {
            if (string.IsNullOrEmpty(model.UnitID))
                return null;
            StringBuilder sb = new StringBuilder();
            sb.Append(@"SELECT w1.WGJG0201,w1.WGJG0202,w1.A0101,w1.A0177,b1.B0002,b1.B0002 AS UnitID,code1.E0386,code2.WGJG0203,w1.WGJG0204,w1.WGJG0205, w1.WGJG0206, w1.WGJG0207, w1.WGJG0208, w1.WGJG0209, w1.WGJG0211, w1.WGJG0212, w1.PClassID FROM ");
            sb.Append(string.Format("(SELECT *,ROW_NUMBER() OVER (ORDER BY A0101) as rank FROM dbo.WGJG02 WHERE PersonID IN (SELECT PersonID FROM dbo.A01) AND UnitID LIKE '{0}%' ", model.UnitID));
            //时间发放区间
            if (!string.IsNullOrEmpty(model.DateStart) && !string.IsNullOrEmpty(model.DateEnd))
                sb.Append(string.Format(" AND WGJG0201 BETWEEN '{0}' AND '{1}' ",model.DateStart,model.DateEnd));
            else if(!string.IsNullOrEmpty(model.DateStart) && string.IsNullOrEmpty(model.DateEnd))
                sb.Append(string.Format(" AND WGJG0201>='{0}' ", model.DateStart));
            else if(string.IsNullOrEmpty(model.DateStart) && !string.IsNullOrEmpty(model.DateEnd))
                sb.Append(string.Format(" AND WGJG0201<='{0}' ", model.DateEnd));
            sb.Append(") w1 LEFT JOIN ");
            sb.Append(@" (SELECT UnitID,UnitName AS B0002 FROM dbo.B01) b1 ON w1.UnitID=b1.UnitID LEFT JOIN
(SELECT CodeItemID, CodeItemName AS E0386 FROM dbo.SM_CodeItems WHERE CodeID = 'JA') code1 ON w1.E0386 = code1.CodeItemID LEFT JOIN
(SELECT CodeItemID, CodeItemName AS WGJG0203 FROM dbo.SM_CodeItems WHERE CodeID = 'GZFFFS') code2 ON w1.WGJG0203 = code2.CodeItemID ");
            sb.Append(string.Format(" WHERE w1.rank between {0} and {1} ORDER BY w1.A0101,w1.WGJG0202;", (model.page - 1) * model.rows, model.page * model.rows));
            DataTable dt = HCQ2_Common.SQL.SqlHelper.ExecuteDataTable(sb.ToString(), CommandType.Text);
            return HCQ2_Common.Data.DataTableHelper.DataTableToIList<WGJG02Model>(dt);
        }

        public int CountPersonsByModel(WGJG02ByUnitID model)
        {
            if (model == null)
                return 0;
            StringBuilder sb = new StringBuilder();
            sb.Append(string.Format("select count(*) from WGJG02 where PersonID IN (SELECT PersonID FROM dbo.A01) AND UnitID LIKE '{0}%' ", model.UnitID));
            //关键字
            if(!string.IsNullOrEmpty(model.A0101))
                sb.Append(string.Format(" and A0101 like '%{0}%' ", model.A0101));
            //时间发放区间
            if (!string.IsNullOrEmpty(model.DateStart) && !string.IsNullOrEmpty(model.DateEnd))
                sb.Append(string.Format(" and WGJG0201 BETWEEN '{0}' AND '{1}' ", model.DateStart, model.DateEnd));
            else if (!string.IsNullOrEmpty(model.DateStart) && string.IsNullOrEmpty(model.DateEnd))
                sb.Append(string.Format(" and WGJG0201>='{0}' ", model.DateStart));
            else if (string.IsNullOrEmpty(model.DateStart) && !string.IsNullOrEmpty(model.DateEnd))
                sb.Append(string.Format(" and WGJG0201<='{0}' ", model.DateEnd));
            return Helper.ToInt(SqlHelper.ExecuteScalar(sb.ToString(), CommandType.Text));
        }

        public DataTable GetExportData(WGJG02ByUnitID model)
        {
            if (string.IsNullOrEmpty(model.UnitID))
                return null;
            StringBuilder sb = new StringBuilder();
            sb.Append(@"SELECT w1.WGJG0201,w1.WGJG0202,w1.A0101,w1.A0177,b1.B0002,b1.B0002 AS UnitID,code1.E0386,code2.WGJG0203,w1.WGJG0204,w1.WGJG0205, w1.WGJG0206, w1.WGJG0207, w1.WGJG0208, w1.WGJG0209, w1.WGJG0211, w1.WGJG0212, w1.PClassID FROM ");
            sb.Append(string.Format("(SELECT * FROM dbo.WGJG02 WHERE PersonID IN (SELECT PersonID FROM dbo.A01) AND UnitID LIKE '{0}%' ", model.UnitID));
            //时间发放区间
            if (!string.IsNullOrEmpty(model.DateStart) && !string.IsNullOrEmpty(model.DateEnd))
                sb.Append(string.Format(" AND WGJG0201 BETWEEN '{0}' AND '{1}' ", model.DateStart, model.DateEnd));
            else if (!string.IsNullOrEmpty(model.DateStart) && string.IsNullOrEmpty(model.DateEnd))
                sb.Append(string.Format(" AND WGJG0201>='{0}' ", model.DateStart));
            else if (string.IsNullOrEmpty(model.DateStart) && !string.IsNullOrEmpty(model.DateEnd))
                sb.Append(string.Format(" AND WGJG0201<='{0}' ", model.DateEnd));
            sb.Append(") w1 LEFT JOIN ");
            sb.Append(@" (SELECT UnitID,UnitName AS B0002 FROM dbo.B01) b1 ON w1.UnitID=b1.UnitID LEFT JOIN
(SELECT CodeItemID, CodeItemName AS E0386 FROM dbo.SM_CodeItems WHERE CodeID = 'JA') code1 ON w1.E0386 = code1.CodeItemID LEFT JOIN
(SELECT CodeItemID, CodeItemName AS WGJG0203 FROM dbo.SM_CodeItems WHERE CodeID = 'GZFFFS') code2 ON w1.WGJG0203 = code2.CodeItemID ");
            sb.Append(string.Format(" ORDER BY w1.A0177,w1.WGJG0201;"));
            return SqlHelper.ExecuteDataTable(sb.ToString(), CommandType.Text);
        }

        public int CountGrantPersons(WGJG01ChartModel model)
        {
            if (!string.IsNullOrEmpty(model.rowID))
            {
                if (!string.IsNullOrEmpty(model.keyword))
                    return SelectCount(s => s.WGJG01RowID == model.rowID && s.A0101.Contains(model.keyword));
                return SelectCount(s => s.WGJG01RowID == model.rowID);
            }
            StringBuilder sb = new StringBuilder();
            sb.Append(string.Format("SELECT COUNT(*) FROM dbo.WGJG02 WHERE PersonID IN (SELECT PersonID FROM dbo.A01) AND WGJG01RowID IN(SELECT RowID FROM dbo.WGJG01 WHERE UnitID LIKE '{0}%' ", model.unitID));
            if (!string.IsNullOrEmpty(model.dateStart) && !string.IsNullOrEmpty(model.dateEnd))
                sb.Append(string.Format(" AND WGJG0102 BETWEEN '{0}' AND '{1}' ",model.dateStart,model.dateEnd));
            else if (!string.IsNullOrEmpty(model.dateStart))
                sb.Append(string.Format(" AND WGJG0102>='{0}' ", model.dateStart));
            else if(!string.IsNullOrEmpty(model.dateEnd))
                sb.Append(string.Format(" AND WGJG0102<='{0}' ", model.dateEnd));
            if (!string.IsNullOrEmpty(model.keyword))
                sb.Append(string.Format(" AND A0101 LIKE '%{0}%' ", model.keyword));
            if (!string.IsNullOrEmpty(model.isGive) && model.isGive.Equals("1"))
                sb.Append(" AND WGJG0211='1' ");
            else if (!string.IsNullOrEmpty(model.isGive))
                sb.Append(" AND ISNULL(WGJG0211,'')<>'1' ");
            sb.Append(")");
            return Helper.ToInt(SqlHelper.ExecuteScalar(sb.ToString(), CommandType.Text));
        }

        public bool EditAffirmWageByPerson(WageRegisterModel model)
        {
            DateTime de;
            if (!DateTime.TryParse(model.signtime, out de))
                return false;
            WGJG02 wg1 =
                Select(s => s.PersonID == model.personid && s.PersonSalaryID == model.personsalaryid && s.WGJG0211 == "1").FirstOrDefault();
            if (null != wg1)
                return true;
            //1：更新是否发放，签到时间，发放时间
            int mark = Modify(new WGJG02() { WGJG0211 = "1", WGJG0201=de, WGJG0212 = de },
                s => s.PersonID == model.personid && s.PersonSalaryID == model.personsalaryid, "WGJG0211", "WGJG0201", "WGJG0212");
            return mark > 0 ? true : false;
        }

        public int GetWagePersonCount(WageRegisterModel model)
        {
            //2：判断是否需要更新WGJG01表
            var query = (from s in db.Set<WGJG02>()
                         join
                             o in db.Set<WGJG02>()
                             on s.WGJG01RowID equals o.WGJG01RowID
                         where !s.WGJG0211.Equals("1") && o.PersonID.Equals(model.personid)
                               && o.PersonSalaryID.Equals(model.personsalaryid)
                         select s).
                ToList();
            return (query != null) ? query.Count : 0;
        }

        public List<WageSentDownModel> GetWageSentDownByOrgId(string orgid)
        {
            if (string.IsNullOrEmpty(orgid))
                return null;
            StringBuilder sb = new StringBuilder();
            sb.Append(@"SELECT orgid=@orgid,w2.PersonID,w2.PersonSalaryID,w2.WGJG0204 AS person_salaryvalue,w2.WGJG0207 AS person_salaryplanvalue,
w2.WGJG0208 AS person_salaryrealvalue,b1.person_project,b2.person_enduser,E0386Code.person_jobtype,a1.A0101 AS person_name,a1.A0177 AS person_cardno,
a1.A0118 AS iris_data,a1.big_iris_data FROM
(SELECT TOP 1 RowID FROM dbo.WGJG01 WHERE UnitID=@orgid AND WGJG0101='02' ORDER BY WGJG0107) w1 INNER JOIN
(SELECT PersonID,PersonSalaryID,WGJG0204,WGJG0207=ISNULL(WGJG0207,0),WGJG0208=ISNULL(WGJG0208,0),
	WGJG01RowID FROM dbo.WGJG02 WHERE UnitID=@orgid) w2 ON w1.RowID=w2.WGJG01RowID INNER JOIN
(SELECT B0001,B0002,UnitID,E0386,A0177,A0118,A0101,PersonID,big_iris_data FROM dbo.A01 WHERE UnitID=@orgid) a1 ON w2.PersonID = a1.PersonID LEFT JOIN
(SELECT UnitName AS person_project,UnitID FROM dbo.B01 WHERE UnitID=@orgproject) b1 ON a1.B0001=b1.UnitID INNER JOIN
(SELECT UnitName AS person_enduser,UnitID FROM dbo.B01 WHERE UnitID=@orgid) b2 ON a1.UnitID=b2.UnitID  LEFT JOIN
(SELECT CodeItemName AS person_jobtype,CodeItemID FROM dbo.SM_CodeItems WHERE CodeID='JA') E0386Code ON a1.E0386=E0386Code.CodeItemID");
            Dictionary<string, object> dis = new Dictionary<string, object>();
            dis.Add("@orgid", orgid);
            dis.Add("@orgproject", orgid.Substring(0, 3));
            DataTable dt = SqlHelper.ExecuteDataTable(sb.ToString(), CommandType.Text, SqlHelper.GetParameters(dis));
            return HCQ2_Common.Data.DataTableHelper.DataTableToIList<WageSentDownModel>(dt);
        }

        public WGJG02 GetFirstCheckInUser(WageRegisterModel model)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(
                string.Format(
                    @"SELECT TOP 1 * FROM dbo.WGJG02 WHERE PersonID IN (SELECT PersonID FROM dbo.A01) AND WGJG01RowID IN(SELECT WGJG01RowID FROM dbo.WGJG02 WHERE PersonID=@PersonID AND PersonSalaryID=@PersonSalaryID) AND WGJG0211='1' ORDER BY dbo.WGJG02.WGJG0212 ASC "));
            Dictionary<string, object> dis = new Dictionary<string, object>();
            dis.Add("@PersonID", model.personid);
            dis.Add("@PersonSalaryID", model.personsalaryid);
            DataTable dt = SqlHelper.ExecuteDataTable(sb.ToString(), CommandType.Text, SqlHelper.GetParameters(dis));
            return HCQ2_Common.Data.DataTableHelper.DataTableToIList<WGJG02>(dt).FirstOrDefault();
        }

        /// <summary>
        ///  工资下发
        /// </summary>
        /// <param name="person"></param>
        /// <returns></returns>
        public List<WageDetialResult> GetWageDetialByPerson(WageGrantParamModel person)
        {
            if (null == person)
                return null;
            sb?.Clear();
            sb.Append(string.Format(@"SELECT c1.WGJG0203,ISNULL(w1.WGJG0204,0) AS WGJG0204,w1.WGJG0501,w1.WGJG0502,ISNULL(w1.WGJG0207,0) AS WGJG0207,ISNULL(w1.WGJG0208,0) AS WGJG0208,w1.WGJG0202 FROM
        (SELECT TOP 1 WGJG0203,WGJG0204,WGJG0501=0.00,WGJG0502=0.00,WGJG0207,WGJG0208,CONVERT(varchar(100), WGJG0202, 23) AS WGJG0202 FROM dbo.WGJG02 WHERE PersonID IN (SELECT PersonID FROM dbo.A01) AND UnitID=@UnitID AND A0177=@A0177 ORDER BY WGJG0202 DESC) w1 LEFT JOIN 
        (SELECT CodeItemID,CodeItemName AS WGJG0203 FROM dbo.SM_CodeItems WHERE CodeID='GZFFFS') c1 ON w1.WGJG0203 = c1.CodeItemID;"));
            _param?.Clear();
            _param.Add("@UnitID", person.orgid);
            _param.Add("@A0177", person.A0177);
            DataTable dt = SqlHelper.ExecuteDataTable(sb.ToString(), CommandType.Text, SqlHelper.GetParameters(_param));
            return HCQ2_Common.Data.DataTableHelper.DataTableToIList<WageDetialResult>(dt);
        }
        /// <summary>
        ///  根据年份获取指定人员 一年的薪资发放情况
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public List<WorkMoneyResult> GetWageByYear(WorkAllList model)
        {
            sb?.Clear();
            sb.Append(string.Format(@"SELECT CONVERT(varchar(100), pay_date, 23) AS pay_date,WGJG0207,WGJG0208,code.WGJG0211 FROM
            (SELECT pay_date=(CASE WHEN ISNULL(WGJG0201,'')='' THEN WGJG0202 ELSE WGJG0201 END),
	            ISNULL(WGJG0207,0) AS WGJG0207,ISNULL(WGJG0208,0) AS WGJG0208,WGJG0211,A0177 FROM dbo.WGJG02 
	            WHERE ISNULL(WGJG0207,0)<>0 AND ISNULL(WGJG0208,0)<>0)wg INNER JOIN
            (SELECT CodeItemID, CodeItemName AS WGJG0211 FROM dbo.SM_CodeItems WHERE CodeID = '45') code ON wg.WGJG0211=code.CodeItemID 
            INNER JOIN (SELECT user_identify FROM dbo.T_User WHERE user_guid=@userid) u ON wg.A0177=u.user_identify
            WHERE YEAR(pay_date)={0} ORDER BY pay_date;", model.year));
            _param?.Clear();
            _param.Add("@userid", model.userid);
            DataTable dt = SqlHelper.ExecuteDataTable(sb.ToString(), CommandType.Text, SqlHelper.GetParameters(_param));
            return HCQ2_Common.Data.DataTableHelper.DataTableToIList<WorkMoneyResult>(dt);
        }
        /// <summary>
        ///  获取个人拖欠薪资
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public List<WorkMoneyResult> GetTradyWageByYear(WorkAllList model)
        {
            sb?.Clear();
            sb.Append(string.Format(@"SELECT CONVERT(varchar(100), pay_date, 23) AS pay_date,WGJG0207,WGJG0208,code.WGJG0211 FROM
            (SELECT pay_date=(CASE WHEN ISNULL(WGJG0201,'')='' THEN WGJG0202 ELSE WGJG0201 END),
	            ISNULL(WGJG0207,0) AS WGJG0207,ISNULL(WGJG0208,0) AS WGJG0208,WGJG0211,A0177 FROM dbo.WGJG02 
	            WHERE ISNULL(WGJG0211,'2')='2' AND ISNULL(WGJG0207,0)<>0 AND ISNULL(WGJG0208,0)<>0)wg INNER JOIN
            (SELECT CodeItemID, CodeItemName AS WGJG0211 FROM dbo.SM_CodeItems WHERE CodeID = '45') code ON wg.WGJG0211=code.CodeItemID 
            INNER JOIN (SELECT user_identify FROM dbo.T_User WHERE user_guid=@userid) u ON wg.A0177=u.user_identify
            WHERE YEAR(pay_date)={0} ORDER BY pay_date;", model.year));
            _param?.Clear();
            _param.Add("@userid", model.userid);
            DataTable dt = SqlHelper.ExecuteDataTable(sb.ToString(), CommandType.Text, SqlHelper.GetParameters(_param));
            return HCQ2_Common.Data.DataTableHelper.DataTableToIList<WorkMoneyResult>(dt);
        }
        /// <summary>
        ///  获取总的发放金额
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public decimal GetAllGrantMoney(BaseAPI model)
        {
            sb?.Clear();
            sb.Append(string.Format(@"SELECT CONVERT(DECIMAL(18,2),SUM(ISNULL(WGJG0208,0))/10000) AS WGJG0208 FROM
            (SELECT ISNULL(WGJG0208,0) AS WGJG0208,A0177 FROM dbo.WGJG02 
	            WHERE ISNULL(WGJG0211,'2')='1' AND ISNULL(WGJG0207,0)<>0 AND ISNULL(WGJG0208,0)<>0)wg INNER JOIN
            (SELECT user_identify FROM dbo.T_User WHERE user_guid=@userid) u ON wg.A0177=u.user_identify"));
            _param?.Clear();
            _param.Add("@userid", model.userid);
            return Helper.ToDecimal(SqlHelper.ExecuteScalar(sb.ToString(), CommandType.Text, SqlHelper.GetParameters(_param)));
        }
        /// <summary>
        ///  获取总的欠薪金额
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public decimal GetAllPayMoney(BaseAPI model)
        {
            sb?.Clear();
            sb.Append(string.Format(@"SELECT CONVERT(DECIMAL(18,2),(SUM(ISNULL(WGJG0207,0))-SUM(ISNULL(WGJG0208,0)))/10000) AS payMoney FROM
            (SELECT ISNULL(WGJG0207,0) AS WGJG0207,A0177,
	            WGJG0208=(CASE WHEN ISNULL(WGJG0211,'2')='2' THEN 0 ELSE ISNULL(WGJG0208,0) END)
	             FROM dbo.WGJG02 
	            WHERE ISNULL(WGJG0211,'2') IN('1','2') AND ISNULL(WGJG0207,0)<>0 AND ISNULL(WGJG0208,0)<>0)wg INNER JOIN
            (SELECT user_identify FROM dbo.T_User WHERE user_guid=@userid) u ON wg.A0177=u.user_identify"));
            _param?.Clear();
            _param.Add("@userid", model.userid);
            return Helper.ToDecimal(SqlHelper.ExecuteScalar(sb.ToString(), CommandType.Text, SqlHelper.GetParameters(_param)));
        }
        /// <summary>
        ///  获取欠薪金额趋势数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public List<DebtMoneyModel> GetPayMoneyByDate(DebtChartByYearModel model)
        {
            sb?.Clear();
            sb.Append(string.Format(@"SELECT T.month,T.money FROM
(SELECT wg.month,CONVERT(DECIMAL(18,2),(SUM(ISNULL(WGJG0207,0))-SUM(ISNULL(WGJG0208,0)))/10000) AS money FROM
 (SELECT CAST(MONTH(WGJG0202) AS INT) AS month,ISNULL(WGJG0207,0) AS WGJG0207,
 WGJG0208=(CASE WHEN ISNULL(WGJG0211,'2')='2' THEN 0 ELSE ISNULL(WGJG0208,0) END)
	FROM dbo.WGJG02 WHERE ISNULL(WGJG0211,'2') IN('1','2') AND YEAR(WGJG0202)=@year)wg GROUP BY wg.month)T WHERE T.money>0 ORDER BY T.month ASC;"));
            _param?.Clear();
            _param.Add("@year", model.year);
            DataTable dt = SqlHelper.ExecuteDataTable(sb.ToString(), CommandType.Text, SqlHelper.GetParameters(_param));
            return HCQ2_Common.Data.DataTableHelper.DataTableToIList<DebtMoneyModel>(dt);
        }
        /// <summary>
        ///  获取欠薪人数趋势
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public List<DebtPersonsModel> GetPayCountPerson(DebtChartByYearModel model)
        {
            sb?.Clear();
            sb.Append(string.Format(@"SELECT TT.month,TT.number FROM 
            (SELECT T.month,COUNT(T.month) AS number FROM 
            (SELECT CAST(MONTH(WGJG0202) AS INT) AS month FROM dbo.WGJG02 
            WHERE ISNULL(WGJG0211,'2')='2' AND ISNULL(dbo.WGJG02.WGJG0202,'')<>''
            AND YEAR(WGJG0202)=@year)T GROUP BY T.month)TT WHERE TT.number>0;"));
            _param?.Clear();
            _param.Add("@year", model.year);
            DataTable dt = SqlHelper.ExecuteDataTable(sb.ToString(), CommandType.Text, SqlHelper.GetParameters(_param));
            return HCQ2_Common.Data.DataTableHelper.DataTableToIList<DebtPersonsModel>(dt);
        }
    }
}
