using HCQ2_Common.SQL;
using HCQ2_Model.AppModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using HCQ2_Common;
using HCQ2_Model.APPModel.ParamModel;
using HCQ2_Model.APPModel.ResultApiModel;
using HCQ2_IDAL;
using HCQ2_Model;

namespace HCQ2_DAL_MSSQL
{
    public partial class View_A02DAL : HCQ2_IDAL.IView_A02DAL
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
        ///  获取已出工情况 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public List<string> GetWorkPersonList(WorkCount model)
        {
            sb?.Clear();
            sb.Append(string.Format(@"SELECT A.A0101 FROM 
                    (SELECT A0177,A0101,UnitID FROM dbo.A01 WHERE UnitID=@UnitID AND ISNULL(retire_time,'')='') A INNER JOIN
                    (SELECT DISTINCT A0177,UnitID FROM dbo.View_A02 WHERE UnitID=@UnitID AND CONVERT(varchar(100), A0201, 23)=@dateStart) B
                    ON A.A0177 = B.A0177 WHERE A.UnitID=B.UnitID;"));
            _param?.Clear();
            _param.Add("@UnitID", model.orgid);
            _param.Add("@dateStart", model.work_date);
            DataTable dt = SqlHelper.ExecuteDataTable(sb.ToString(), CommandType.Text, SqlHelper.GetParameters(_param));
            List<WorkParamModel> list = HCQ2_Common.Data.DataTableHelper.DataTableToIList<WorkParamModel>(dt);
            if (null == list)
                return null;
            return list.Select(s => s.A0101).ToList();
        }

        /// <summary>
        ///  获取已出工人数
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int GetWorkPersonCount(WorkCount model)
        {
            sb?.Clear();
            sb.Append(string.Format(@"SELECT COUNT(A.A0101) FROM 
                    (SELECT A0177,A0101,UnitID FROM dbo.A01 WHERE UnitID=@UnitID AND ISNULL(retire_time,'')='') A INNER JOIN
                    (SELECT DISTINCT A0177,UnitID FROM dbo.View_A02 WHERE UnitID=@UnitID AND CONVERT(varchar(100), A0201, 23)=@dateStart) B
                    ON A.A0177 = B.A0177 WHERE A.UnitID=B.UnitID"));
            _param?.Clear();
            _param.Add("@UnitID", model.orgid);
            _param.Add("@dateStart", model.work_date);
            return Helper.ToInt(SqlHelper.ExecuteScalar(sb.ToString(), CommandType.Text, SqlHelper.GetParameters(_param)));
        }

        /// <summary>
        ///  获取未出工情况
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public List<string> GetonWorkPersonList(WorkCount model)
        {
            sb?.Clear();
            sb.Append(string.Format(@"SELECT A0101 FROM dbo.A01 WHERE UnitID=@UnitID AND ISNULL(retire_time,'')='' AND PersonID NOT IN(
	            SELECT DISTINCT PersonID FROM dbo.View_A02 WHERE UnitID=@UnitID AND CONVERT(varchar(100), A0201, 23)=@dateStart
            ); "));
            _param?.Clear();
            _param.Add("@UnitID", model.orgid);
            _param.Add("@dateStart", model.work_date);
            DataTable dt = SqlHelper.ExecuteDataTable(sb.ToString(), CommandType.Text, SqlHelper.GetParameters(_param));
            List<WorkParamModel> list = HCQ2_Common.Data.DataTableHelper.DataTableToIList<WorkParamModel>(dt);
            if (null == list)
                return null;
            return list.Select(s => s.A0101).ToList();
        }

        /// <summary>
        ///  获取未出工人数
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int GetonWorkPersonCount(WorkCount model)
        {
            sb?.Clear();
            sb.Append(string.Format(@"SELECT COUNT(A0101) FROM dbo.A01 WHERE UnitID=@UnitID AND ISNULL(retire_time,'')='' AND PersonID NOT IN(
	            SELECT DISTINCT PersonID FROM dbo.View_A02 WHERE UnitID=@UnitID AND CONVERT(varchar(100), A0201, 23)=@dateStart
            )"));
            _param?.Clear();
            _param.Add("@UnitID", model.orgid);
            _param.Add("@dateStart", model.work_date);
            return Helper.ToInt(SqlHelper.ExecuteScalar(sb.ToString(), CommandType.Text, SqlHelper.GetParameters(_param)));
        }

        /// <summary>
        ///  根据工种统计出工情况
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public List<WorkTypeCount> GetToWorkByType(WorkCount model)
        {
            sb?.Clear();
            sb.Append(string.Format(@"SELECT A22.E0386,B22.numCount,(C22.allCount-B22.numCount) AS unCount FROM
                (
	                SELECT ISNULL(code1.E0386,'其他') AS E0386,A2.gong FROM
	                (SELECT DISTINCT ISNULL(E0386,'00') AS gong FROM dbo.A01 WHERE UnitID=@UnitID) A2 LEFT JOIN
	                (SELECT CodeItemID,CodeItemName AS E0386 FROM dbo.SM_CodeItems WHERE CodeID='JA') code1 
	                ON A2.gong=code1.CodeItemID
                ) A22 INNER JOIN
                (
	                SELECT gong,COUNT(A11.gong) AS numCount FROM 
	                (
		                SELECT ISNULL(A1.E0386,'00') AS gong FROM 
		                (SELECT A0177,UnitID,E0386 FROM dbo.A01) A1 INNER JOIN
		                (SELECT DISTINCT A0177,UnitID FROM dbo.View_A02 WHERE UnitID=@UnitID AND CONVERT(varchar(100), A0201, 23)=@dateStart) B
		                ON A1.A0177 = B.A0177 WHERE A1.UnitID=B.UnitID
	                ) A11 GROUP BY A11.gong
                )B22 ON A22.gong = B22.gong INNER JOIN
                (
					SELECT gong,COUNT(gong) AS allCount FROM 
					(SELECT ISNULL(E0386,'00') AS gong FROM dbo.A01 WHERE UnitID=@UnitID)C11 GROUP BY C11.gong
                )C22 ON B22.gong=C22.gong;"));
            _param?.Clear();
            _param.Add("@UnitID", model.orgid);
            _param.Add("@dateStart", model.work_date);
            DataTable dt = SqlHelper.ExecuteDataTable(sb.ToString(), CommandType.Text, SqlHelper.GetParameters(_param));
            return HCQ2_Common.Data.DataTableHelper.DataTableToIList<WorkTypeCount>(dt);
        }

        public List<WorkSQLMonth> GetMonthWorkData(WorkMonthList model)
        {
            sb?.Clear();
            sb.Append(string.Format(@"SELECT A.RowID,mark,A0177,day,hour FROM (
            SELECT RowID,mark='in',A0177,DAY(A0201) AS day,Datename(HH,A0201)+':'+Datename(MI,A0201) AS HOUR,A0201  FROM 
            (SELECT row_number() over(partition by T.checkDate order by T.A0201 ASC) as rownum,RowID,A0177,A0201 FROM
            (SELECT RowID,A0177,B0001,B0002,A0201,A0202,CONVERT(varchar(100), A0201, 23) AS checkDate FROM dbo.View_A02 WHERE
            convert(varchar(7),A0201,120)=@dateStart AND A0177=(SELECT user_identify FROM dbo.T_User WHERE user_guid=@userid)) T )TT
            WHERE TT.rownum=1
            UNION 
            SELECT RowID,mark='out',A0177,DAY(A0201) AS DAY,Datename(HH,A0201)+':'+Datename(MI,A0201) AS hour,A0201 FROM 
            (SELECT row_number() over(partition by T.checkDate order by T.A0201 DESC) as rownum,RowID,A0177,A0201 FROM
            (SELECT RowID,A0177,B0001,B0002,A0201,A0202,CONVERT(varchar(100), A0201, 23) AS checkDate FROM dbo.View_A02 WHERE 
            convert(varchar(7),A0201,120)=@dateStart AND A0177=(SELECT user_identify FROM dbo.T_User WHERE user_guid=@userid)) T )TT
            WHERE TT.rownum=1
            ) A ORDER BY A.A0201;"));
            _param?.Clear();
            _param.Add("@dateStart", model.work_date);
            _param.Add("@userid", model.userid);
            DataTable dt = SqlHelper.ExecuteDataTable(sb.ToString(), CommandType.Text, SqlHelper.GetParameters(_param));
            return HCQ2_Common.Data.DataTableHelper.DataTableToIList<WorkSQLMonth>(dt);
        }

        /// <summary>
        ///  根据年份统计具体人员每月出工情况
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public List<WorkAllResult> GetAllWorkDays(WorkAllList model)
        {
            sb?.Clear();
            sb.Append(string.Format(@"SELECT COUNT(T1.checkDate) AS work_days,work_date FROM 
            (SELECT DISTINCT CONVERT(varchar(100), A0201, 23) AS checkDate,convert(varchar(7),A0201,120) AS work_date FROM View_A02 
            WHERE A0177=(SELECT user_identify FROM dbo.T_User WHERE user_guid=@userid)
            AND YEAR(A0201)={0}) T1
            GROUP BY T1.work_date ORDER BY T1.work_date ASC;", model.year));
            _param?.Clear();
            _param.Add("@userid", model.userid);
            DataTable dt = SqlHelper.ExecuteDataTable(sb.ToString(), CommandType.Text, SqlHelper.GetParameters(_param));
            return HCQ2_Common.Data.DataTableHelper.DataTableToIList<WorkAllResult>(dt);
        }

        /// <summary>
        ///  务工人员党员总打卡天数
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int GetMonthByCard(BaseAPI model)
        {
            DateTime dt = DateTime.Now;
            string date = dt.Year + "-" + (dt.Month > 9 ? dt.Month.ToString() : "0" + dt.Month);
            sb?.Clear();
            sb.Append(string.Format(@"SELECT COUNT(*) AS monthCount FROM 
            (SELECT row_number() over(partition by T.dayDate order by T.dayDate) as rownum,* FROM
            (SELECT convert(varchar(7),A0201,120) AS monthDate,convert(varchar(10),A0201,120) AS dayDate FROM dbo.View_A02 
            WHERE A0177=(SELECT user_identify FROM dbo.T_User WHERE user_guid=@userid) AND convert(varchar(7),A0201,120)=@date) T)TT
            WHERE TT.rownum=1"));
            _param?.Clear();
            _param.Add("@userid", model.userid);
            _param.Add("@date", date);
            return Helper.ToInt(SqlHelper.ExecuteScalar(sb.ToString(), CommandType.Text, SqlHelper.GetParameters(_param)));
        }

        /// <summary>
        ///  务工人员总打卡天数
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int GetAllByCard(BaseAPI model)
        {
            sb?.Clear();
            sb.Append(string.Format(@"SELECT ISNULL(SUM(T2.work_days),0) AS allDays FROM 
            (SELECT COUNT(T1.checkDate) AS work_days FROM 
            (SELECT DISTINCT CONVERT(varchar(100), A0201, 23) AS checkDate,convert(varchar(7),A0201,120) AS work_date FROM View_A02 
            WHERE A0177=(SELECT user_identify FROM dbo.T_User WHERE user_guid=@userid)) T1
            GROUP BY T1.work_date) T2;"));
            _param?.Clear();
            _param.Add("@userid", model.userid);
            return Helper.ToInt(SqlHelper.ExecuteScalar(sb.ToString(), CommandType.Text, SqlHelper.GetParameters(_param)));
        }

        /// <summary>
        /// 获取某一个项目的出工情况
        /// </summary>
        /// <param name="UnitID"></param>
        /// <param name="CheckDate"></param>
        /// <returns></returns>
        public DataTable GetWorkByUnitData(string UnitID, string year, string month, string day)
        {
            sb = new StringBuilder();
            sb.AppendFormat("select E0386=(select CodeItemName from SM_CodeItems where CodeID='JA'");
            sb.AppendFormat(" and CodeItemID=a.E0386),* from View_A02 a where year(A0201)={0}", year);
            sb.AppendFormat(" and MONTH(A0201)={0} and DAY(A0201)={1} and UnitID='{2}'", month, day, UnitID);
            return HCQ2_Common.SQL.SqlHelper.ExecuteDataTable(sb.ToString());
        }

        /// <summary>
        /// 获取某一个项目某一天的出工人数
        /// </summary>
        /// <param name="UnitID"></param>
        /// <param name="year"></param>
        /// <param name="month"></param>
        /// <param name="day"></param>
        /// <returns></returns>
        public int GetWorkCountByUnitID(string UnitID, string year, string month, string day)
        {
            sb = new StringBuilder();
            sb.AppendFormat("SELECT COUNT(distinct(PersonID)) FROM View_A02 where");
            sb.AppendFormat(" YEAR(A0201)={0} and MONTH(A0201)={1} and DAY(A0201)={2}", year, month, day);
            sb.AppendFormat(" and UnitID='{0}'", UnitID);
            return Convert.ToInt32(HCQ2_Common.SQL.SqlHelper.ExecuteScalar(sb.ToString()));
        }

        /// <summary>
        /// 根据项目编号获取上报异常的数据
        /// </summary>
        /// <param name="strUnit"></param>
        /// <returns></returns>
        public List<View_A02> GetAttendsByUnit(string strUnit)
        {
            if (!string.IsNullOrEmpty(strUnit))
            {
                sb = new StringBuilder();
                sb.AppendFormat("select * from View_A02 where (ISNULL(A0203,'')<>'' or ISNULL(A0204,'')<>'')");
                sb.AppendFormat(" and UnitID in ({0}) and if_upattend=0", strUnit);
                DataTable dt = HCQ2_Common.SQL.SqlHelper.ExecuteDataTable(sb.ToString());
                return HCQ2_Common.Data.DataTableHelper.DataTableToIList<View_A02>(dt);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 根据RowID的集合获取数据源
        /// </summary>
        /// <param name="strRowID"></param>
        /// <returns></returns>
        public List<View_A02> GetAttendsByRowID(string strRowID) {
            if (!string.IsNullOrEmpty(strRowID))
            {
                sb = new StringBuilder();
                sb.AppendFormat("select * from View_A02 where (ISNULL(A0203,'')<>'' or ISNULL(A0204,'')<>'')");
                sb.AppendFormat(" and RowID in ({0}) and if_upattend=0", strRowID);
                DataTable dt = HCQ2_Common.SQL.SqlHelper.ExecuteDataTable(sb.ToString());
                return HCQ2_Common.Data.DataTableHelper.DataTableToIList<View_A02>(dt);
            }
            else
            {
                return null;
            }
        }
    }
}
