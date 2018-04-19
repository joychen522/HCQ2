using HCQ2_Common;
using HCQ2_Common.SQL;
using HCQ2_Model.ExtendsionModel;
using HCQ2_Model.ParamsModel;
using HCQ2_Model.SelectModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HCQ2_DAL_MSSQL
{
    public partial class T_UseWorkerDAL:HCQ2_IDAL.IT_UseWorkerDAL
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
        ///  获取一栏数据
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public List<T_UseWorkerModel> GetUseWorkListData(T_UseWorkerParam param)
        {
            sb?.Clear();
            sb.Append(string.Format(@"SELECT TOP {0} use_id,com_id,use_title,addr,postNote,code.CodeItemName as 'work_type_value',work_type,trade_type,work_city,use_wage_start,
 use_wage_end,use_sex,use_age,use_edu,use_ageLimit,code1.ageLimit,use_major,
  work_start,CONVERT(varchar(100),issue_start,23) AS 'issue_start',use_status,use_note FROM 
  (SELECT *, ROW_NUMBER() OVER(ORDER BY use_id) AS RowNumber FROM dbo.T_UseWorker WHERE com_id={1} AND use_status=1 ", param.rows, param.com_id));
            if (!string.IsNullOrEmpty(param.jobName))
                sb.Append(string.Format(@" AND trade_type LIKE '%@jobName%' "));
            if (param.jobStartMoney > 0 && param.jobEndMoney > 0)
                sb.Append(string.Format(" AND use_wage_start>={0} AND use_wage_end<={1} ", param.jobStartMoney, param.jobEndMoney));
            else if(param.jobStartMoney > 0 && param.jobEndMoney <= 0)
                sb.Append(string.Format(" AND use_wage_start>={0} ", param.jobStartMoney));
            else if (param.jobStartMoney <= 0 && param.jobEndMoney > 0)
                sb.Append(string.Format(" AND use_wage_end<={0} ",  param.jobEndMoney));
            sb.Append(string.Format(@") job INNER JOIN
  (SELECT item1.*,item2.* FROM
  (SELECT item_id,item_code FROM dbo.T_ItemCode WHERE item_code='JobPost') item1 INNER JOIN
  (SELECT code_name AS CodeItemName,code_value AS CodeItemValue,item_id AS id FROM dbo.T_ItemCodeMenum) item2 ON item1.item_id = item2.id) code ON job.work_type=code.CodeItemValue INNER JOIN
  (SELECT item1.*,item2.* FROM
  (SELECT item_id,item_code FROM dbo.T_ItemCode WHERE item_code='WorkExperience') item1 INNER JOIN
  (SELECT code_name AS ageLimit,code_value AS CodeItemValue,item_id AS id FROM dbo.T_ItemCodeMenum) item2 ON item1.item_id = item2.id) code1 ON job.use_ageLimit=code1.CodeItemValue WHERE job.RowNumber>{0} ", (param.page - 1) * param.rows));
            if (!string.IsNullOrEmpty(param.jobName))
            {
                sb.Append(string.Format(@" AND code.CodeItemName LIKE '%@jobName%';"));
                _param.Add("@jobName", param.jobName);
            }
            DataTable dt = SqlHelper.ExecuteDataTable(sb.ToString(), CommandType.Text, SqlHelper.GetParameters(_param));
            return HCQ2_Common.Data.DataTableHelper.DataTableToIList<T_UseWorkerModel>(dt);
        }
        /// <summary>
        ///  获取查看用工一栏数据
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public List<T_UseIssueListModel> GetUseIssueListData(T_UseWorkerParam param)
        {
            sb?.Clear();
            sb.Append(string.Format(@"SELECT TOP {0} job.use_id,ISNULL(rel.subLen,0) AS 'subLen',com_id,code.CodeItemName as 'work_type_value',work_type,trade_type,work_city,use_wage_start,
 use_wage_end,use_sex,use_age,use_edu,use_ageLimit,code1.ageLimit,use_major,
  work_start,CONVERT(varchar(100),issue_start,23) AS 'issue_start',use_status,use_note FROM 
  (SELECT *, ROW_NUMBER() OVER(ORDER BY use_id) AS RowNumber FROM dbo.T_UseWorker WHERE com_id={1} AND use_status={2} ", param.rows, param.com_id,param.use_status));
            if (!string.IsNullOrEmpty(param.jobName))
                sb.Append(string.Format(@" AND trade_type LIKE '%@jobName%' "));
            if (param.jobStartMoney > 0 && param.jobEndMoney > 0)
                sb.Append(string.Format(" AND use_wage_start>={0} AND use_wage_end<={1} ", param.jobStartMoney, param.jobEndMoney));
            else if (param.jobStartMoney > 0 && param.jobEndMoney <= 0)
                sb.Append(string.Format(" AND use_wage_start>={0} ", param.jobStartMoney));
            else if (param.jobStartMoney <= 0 && param.jobEndMoney > 0)
                sb.Append(string.Format(" AND use_wage_end<={0} ", param.jobEndMoney));
            sb.Append(string.Format(@") job INNER JOIN
  (SELECT item1.*,item2.* FROM
  (SELECT item_id,item_code FROM dbo.T_ItemCode WHERE item_code='JobPost') item1 INNER JOIN
  (SELECT code_name AS CodeItemName,code_value AS CodeItemValue,item_id AS id FROM dbo.T_ItemCodeMenum) item2 ON item1.item_id = item2.id) code ON job.work_type=code.CodeItemValue LEFT JOIN
  (SELECT use_id,subLen=COUNT(use_id) FROM dbo.T_JobResumeRelation WHERE com_id={0} GROUP BY use_id) rel ON job.use_id=rel.use_id  INNER JOIN
  (SELECT item1.*,item2.* FROM
  (SELECT item_id,item_code FROM dbo.T_ItemCode WHERE item_code='WorkExperience') item1 INNER JOIN
  (SELECT code_name AS ageLimit,code_value AS CodeItemValue,item_id AS id FROM dbo.T_ItemCodeMenum) item2 ON item1.item_id = item2.id) code1 ON job.use_ageLimit=code1.CodeItemValue WHERE job.RowNumber>{1} ", param.com_id, (param.page - 1) * param.rows));
            if (!string.IsNullOrEmpty(param.jobName))
            {
                sb.Append(string.Format(@" AND code.CodeItemName LIKE '%@jobName%';"));
                _param.Add("@jobName", param.jobName);
            }
            DataTable dt = SqlHelper.ExecuteDataTable(sb.ToString(), CommandType.Text, SqlHelper.GetParameters(_param));
            return HCQ2_Common.Data.DataTableHelper.DataTableToIList<T_UseIssueListModel>(dt);
        }
        /// <summary>
        ///  获取简历数据
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public List<T_JobResumeRelationModel> GetIssueListData(T_IssueListParam param)
        {
            sb?.Clear();
            sb.Append(string.Format(@"SELECT TOP {0} rel.job_id,a01.A0101,a01.C0104,code1.A0114,A0111=CONVERT(varchar(100),a01.A0111,23),code3.A0107,code2.A0108,a04.A0410,rel.send_date,rel.job_status FROM 
(SELECT send_date=CONVERT(varchar(100),send_date,23),UnitID,A0177,job_id,use_id,job_status,ROW_NUMBER() OVER(ORDER BY job_id) AS rowNumber FROM dbo.T_JobResumeRelation WHERE use_id={1}) rel INNER JOIN
(SELECT A0101,C0104,A0114,A0111,A0107,A0108,UnitID,A0177,PersonID FROM dbo.A01 WHERE 1=1 ", param.rows, param.use_id));
            if (!string.IsNullOrEmpty(param.A0101))
                sb.Append(string.Format(" AND A0101 LIKE '%{0}%' ", param.A0101));
            if(!string.IsNullOrEmpty(param.C0104))
                sb.Append(string.Format(" AND C0104='{0}' ", param.C0104));
            sb.Append(string.Format(@" ) a01 ON rel.UnitID=a01.UnitID LEFT JOIN
(SELECT A0410,PersonID FROM dbo.A04 WHERE 1=1 "));
            if (!string.IsNullOrEmpty(param.A0410))
                sb.Append(string.Format(" AND A0410 LIKE '%{0}%' ", param.A0410));
            sb.Append(string.Format(@" ) a04 ON a01.PersonID=a04.PersonID LEFT JOIN
(SELECT CodeItemID,CodeItemName AS A0114 FROM dbo.SM_CodeItems WHERE CodeID='AB') code1 ON a01.A0114=code1.CodeItemID LEFT JOIN
(SELECT CodeItemID,CodeItemName AS A0108 FROM dbo.SM_CodeItems WHERE CodeID='JDXL') code2 ON a01.A0108=code2.CodeItemID LEFT JOIN
(SELECT CodeItemID,CodeItemName AS A0107 FROM dbo.SM_CodeItems WHERE CodeID='AX') code3 ON a01.A0107=code3.CodeItemID
 WHERE rel.A0177=a01.A0177 AND rel.rowNumber>{0};", (param.page - 1) * param.rows));
            DataTable dt = SqlHelper.ExecuteDataTable(sb.ToString(), CommandType.Text);
            return HCQ2_Common.Data.DataTableHelper.DataTableToIList<T_JobResumeRelationModel>(dt);
        }
        /// <summary>
        ///  获取招聘对于简历数据总量
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public int GetIssueListDataCount(T_IssueListParam param)
        {
            sb?.Clear();
            sb.Append(string.Format(@"SELECT COUNT(*) FROM 
(SELECT UnitID,A0177,use_id,job_status FROM dbo.T_JobResumeRelation WHERE use_id={0}) rel INNER JOIN
(SELECT A0101,C0104,A0114,A0111,A0107,A0108,UnitID,A0177,PersonID FROM dbo.A01 WHERE 1=1 ",param.use_id));
            if (!string.IsNullOrEmpty(param.A0101))
                sb.Append(string.Format(" AND A0101 LIKE '%{0}%' ", param.A0101));
            if (!string.IsNullOrEmpty(param.C0104))
                sb.Append(string.Format(" AND C0104='{0}' ", param.C0104));
            sb.Append(string.Format(@" ) a01 ON rel.UnitID=a01.UnitID LEFT JOIN
(SELECT A0410,PersonID FROM dbo.A04 WHERE 1=1 "));
            if (!string.IsNullOrEmpty(param.A0410))
                sb.Append(string.Format(" AND A0410 LIKE '%{0}%' ", param.A0410));
            sb.Append(@") a04 ON a01.PersonID=a04.PersonID WHERE rel.A0177 = a01.A0177");
            return Helper.ToInt(SqlHelper.ExecuteScalar(sb.ToString(), CommandType.Text));
        }
        /// <summary>
        ///  获取一栏数据总量
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public int GetWorkListDataCount(T_UseWorkerParam param)
        {
            sb?.Clear();
            sb.Append(string.Format(@"SELECT COUNT(*) FROM dbo.T_UseWorker WHERE com_id={0} AND use_status={1} ",  param.com_id,param.use_status));
            if (!string.IsNullOrEmpty(param.jobName))
                sb.Append(string.Format(@" AND trade_type LIKE '%@jobName%' "));
            if (param.jobStartMoney > 0 && param.jobEndMoney > 0)
                sb.Append(string.Format(" AND use_wage_start>={0} AND use_wage_end<={1} ", param.jobStartMoney, param.jobEndMoney));
            else if (param.jobStartMoney > 0 && param.jobEndMoney <= 0)
                sb.Append(string.Format(" AND use_wage_start>={0} ", param.jobStartMoney));
            else if (param.jobStartMoney <= 0 && param.jobEndMoney > 0)
                sb.Append(string.Format(" AND use_wage_end<={0} ", param.jobEndMoney));
            if (!string.IsNullOrEmpty(param.jobName))
                _param.Add("@jobName", param.jobName);
            return Helper.ToInt(SqlHelper.ExecuteScalar(sb.ToString(), CommandType.Text, SqlHelper.GetParameters(_param)));
        }
        /// <summary>
        ///  更新状态
        /// </summary>
        /// <param name="job_ids"></param>
        /// <param name="job_status"></param>
        /// <returns></returns>
        public void ModifyStatus(string job_ids, string job_status)
        {
            sb?.Clear();
            sb.Append(string.Format(@"UPDATE dbo.T_JobResumeRelation SET job_status='{0}' WHERE job_id IN({1});", job_status, job_ids));
            SqlHelper.ExecuteNonQuery(sb.ToString());
        }
        /// <summary>
        ///  获取字典集合
        /// </summary>
        /// <param name="item_code"></param>
        /// <returns></returns>
        public List<SelectValueModel> GetJobDictionary(string item_code)
        {
            sb?.Clear();
            if (string.IsNullOrEmpty(item_code))
                return null;
            sb.Append(string.Format(@"SELECT item2.text,item2.value,item1.item_code FROM
		(SELECT item_id,item_code FROM dbo.T_ItemCode WHERE item_code IN({0})) item1 INNER JOIN
		(SELECT code_name AS text,code_value AS value,item_id AS id FROM dbo.T_ItemCodeMenum) item2 ON item1.item_id = item2.id;",item_code));
            DataTable dt = SqlHelper.ExecuteDataTable(sb.ToString(), CommandType.Text);
            return HCQ2_Common.Data.DataTableHelper.DataTableToIList<SelectValueModel>(dt);
        }

        //************************************APP Service*****************************************
        /// <summary>
        ///  获取职位列表
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public List<HCQ2_Model.APPModel.ResultApiModel.JobEmployResultModel> GetJobEmployList(HCQ2_Model.APPModel.ParamModel.JobEmployModel model)
        {
            sb?.Clear();
            sb.Append(string.Format(@"SELECT TOP {0} info.unitName,work.use_title,work.header_img as 'logo',work.work_city AS 'addr',CONVERT(varchar(100),work.issue_start,23) AS 'issueDate',work.payMoney,work.use_id FROM 
(SELECT dwmc AS 'unitName',com_id FROM dbo.T_CompProInfo
WHERE 1=1 ", model.size));
            if (!string.IsNullOrEmpty(model.busType))
                sb.Append(string.Format(" AND bus_type='{0}' ",model.busType));
            if (!string.IsNullOrEmpty(model.busScale))
                sb.Append(string.Format(" AND bus_scale='{0}' ", model.busScale));
            string str = "issue_start";
            if (!string.IsNullOrEmpty(model.orderType) && model.orderType.Equals("money"))
                str = "use_wage_end";
            sb.Append(string.Format(@" ) info RIGHT JOIN
(SELECT use_title,header_img,work_city,issue_start,payMoney=(CASE WHEN use_wage_end=0 THEN '面议' ELSE CAST(use_wage_start AS NVARCHAR(10))+'-'+CAST(use_wage_end AS NVARCHAR(10)) END),use_id,com_id,ROW_NUMBER() OVER(ORDER BY {0} DESC) AS 'rowNumber' FROM dbo.T_UseWorker WHERE 1=1 ", str));
            //工作城市
            if (!string.IsNullOrEmpty(model.city))
                sb.Append(string.Format(" AND work_city LIKE '%{0}%' ",model.city));
            //薪资范围
            if (model.payStart > 0 && model.payEnd > 0)
                sb.Append(string.Format(" AND use_wage_start>={0} AND use_wage_end<={1} ", model.payStart, model.payEnd));
            else if(model.payStart > 0 && model.payEnd <= 0)
                sb.Append(string.Format(" AND use_wage_start>={0} ", model.payStart));
            else if (model.payStart <= 0 && model.payEnd > 0)
                sb.Append(string.Format(" AND use_wage_end<={0} ", model.payEnd));
            //学历
            if(!string.IsNullOrEmpty(model.use_edu))
                sb.Append(string.Format(" AND use_edu='{0}' ", model.use_edu));
            //工作经验
            if (!string.IsNullOrEmpty(model.useLimit))
                sb.Append(string.Format(" AND use_ageLimit='{0}' ", model.useLimit));
            //发布时间
            if (!string.IsNullOrEmpty(model.issueDate))
                sb.Append(string.Format(" AND CONVERT(VARCHAR(100),issue_start,23)='{0}' ", model.issueDate));
            //职位类型
            if (!string.IsNullOrEmpty(model.postType))
                sb.Append(string.Format(" AND work_type='{0}' ", model.postType));
            sb.Append(string.Format(@" ) work ON info.com_id = work.com_id WHERE work.rowNumber>{0};", (model.page - 1) * model.size));
            DataTable dt = SqlHelper.ExecuteDataTable(sb.ToString(), CommandType.Text);
            return HCQ2_Common.Data.DataTableHelper.DataTableToIList<HCQ2_Model.APPModel.ResultApiModel.JobEmployResultModel>(dt);
        }
        /// <summary>
        ///  根据招聘信息 获取职位详情
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public List<HCQ2_Model.APPModel.ResultApiModel.PostDetialResultModel> GetPostDetialByID(HCQ2_Model.APPModel.ParamModel.PostDetialParam model)
        {
            sb?.Clear();
            sb.Append(string.Format(@"SELECT TOP {0} info.unitName,work.use_title,work.header_img as 'logo',work.work_city,SUBSTRING(CONVERT(varchar(100), GETDATE(),23),6,6) AS 'issueDate',
            work.payMoney,work.use_id,info.com_id,work.use_edu,code1.useLimit,work.addr,work.postNote FROM 
            (SELECT dwmc AS 'unitName',com_id FROM dbo.T_CompProInfo) info RIGHT JOIN
            (SELECT use_title,addr,work_city,issue_start,payMoney=(CASE WHEN use_wage_end=0 THEN '面议' ELSE CAST(use_wage_start AS NVARCHAR(10))+'-'+CAST(use_wage_end AS NVARCHAR(10)) END),
            use_id,com_id,use_ageLimit,postNote,header_img,use_edu=(CASE WHEN use_edu='0' THEN '不限' ELSE use_edu END),ROW_NUMBER() OVER(ORDER BY issue_start DESC) AS 'rowNumber' FROM dbo.T_UseWorker
            WHERE use_id={1}) work ON info.com_id = work.com_id INNER JOIN
            (SELECT item2.useLimit,item2.ageLimit_value FROM
            (SELECT item_id,item_code FROM dbo.T_ItemCode WHERE item_code='WorkExperience') item1 INNER JOIN
            (SELECT code_name AS useLimit,code_value AS ageLimit_value,item_id AS id FROM dbo.T_ItemCodeMenum) item2 ON item1.item_id = item2.id) code1 ON code1.ageLimit_value=work.use_ageLimit
            WHERE work.rowNumber>{2};", model.size, model.use_id, (model.page - 1) * model.size));
            DataTable dt = SqlHelper.ExecuteDataTable(sb.ToString(), CommandType.Text);
            return HCQ2_Common.Data.DataTableHelper.DataTableToIList<HCQ2_Model.APPModel.ResultApiModel.PostDetialResultModel>(dt);
        }
        /// <summary>
        ///  获取公司详情
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public List<HCQ2_Model.APPModel.ResultApiModel.BusComProinfoResult> GetComProDetailByID(HCQ2_Model.APPModel.ParamModel.BusComProinfo model)
        {
            sb?.Clear();
            sb.Append(string.Format("SELECT dwmc AS 'unitName',bus_nature AS 'busType',bus_scale AS 'busScale',BGDZ AS 'addr',bus_note AS 'busNotes' FROM dbo.T_CompProInfo WHERE com_id={0};",model.com_id));
            DataTable dt = SqlHelper.ExecuteDataTable(sb.ToString(), CommandType.Text);
            return HCQ2_Common.Data.DataTableHelper.DataTableToIList<HCQ2_Model.APPModel.ResultApiModel.BusComProinfoResult>(dt);
        }
    }
}
