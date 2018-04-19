using HCQ2_Model;
using HCQ2_Model.ExtendsionModel;
using HCQ2_Model.ParamsModel;
using HCQ2_Model.SelectModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HCQ2_BLL
{
     public partial class T_UseWorkerBLL:HCQ2_IBLL.IT_UseWorkerBLL
    {
        /// <summary>
        ///  添加招聘信息
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
       public int AddUseWork(T_UseWorkerModel model)
        {
            if (null == model)
                return 0;
            HCQ2_Model.T_UseWorker job = new HCQ2_Model.T_UseWorker
            {
                com_id = model.com_id,
                use_title = model.use_title,
                work_type = model.work_type,
                trade_type = model.trade_type,
                work_city = model.work_city,
                addr = model.addr,
                use_wage_start = model.use_wage_start,
                use_wage_end = model.use_wage_end,
                use_sex = model.use_sex,
                use_age = model.use_age,
                use_edu = model.use_edu,
                use_ageLimit = model.use_ageLimit,
                use_major = model.use_major,
                work_start = model.work_start,
                issue_start = DateTime.Now,
                use_status = model.use_status,
                postNote = model.postNote,
                use_note = model.use_note,
                header_img = model.logo
            };
            return Add(job);
        }
        /// <summary>
        ///  编辑招聘信息
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int EditUseWork(T_UseWorkerModel model)
        {
            if (null == model)
                return 0;
            HCQ2_Model.T_UseWorker job = new HCQ2_Model.T_UseWorker
            {
                com_id = model.com_id,
                use_title = model.use_title,
                work_type = model.work_type,
                trade_type = model.trade_type,
                work_city = model.work_city,
                addr = model.addr,
                use_wage_start = model.use_wage_start,
                use_wage_end = model.use_wage_end,
                use_sex = model.use_sex,
                use_age = model.use_age,
                use_edu = model.use_edu,
                use_ageLimit = model.use_ageLimit,
                use_major = model.use_major,
                work_start = model.work_start,
                issue_start = DateTime.Now,
                use_status = model.use_status,
                postNote = model.postNote,
                use_note = model.use_note,
                header_img = model.logo
            };
            return Modify(job, s => s.use_id == model.use_id, "work_type", "use_title", "trade_type", "work_city", "addr", "use_wage_start", "use_wage_end", "use_sex", "use_age", "use_edu", "use_ageLimit", "use_major", "work_start", "issue_start", "use_status", "postNote", "use_note", "header_img");
        }
        /// <summary>
        ///  删除招聘信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int DelUseWork(int id)
        {
            if (id <= 0)
                return 0;
            DBSession.IT_JobResumeRelationDAL.Delete(s => s.use_id == id);
            return Delete(s => s.use_id == id);
        }
        /// <summary>
        ///  获取一栏数据
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public List<T_UseWorkerModel> GetUseWorkListData(T_UseWorkerParam param)
        {
            if (null == param)
                return null;
            return DBSession.IT_UseWorkerDAL.GetUseWorkListData(param);
        }
        /// <summary>
        ///  获取查看用工一栏数据
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public List<T_UseIssueListModel> GetUseIssueListData(T_UseWorkerParam param)
        {
            if (null == param)
                return null;
            return DBSession.IT_UseWorkerDAL.GetUseIssueListData(param);
        }
        /// <summary>
        ///  获取简历数据
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public List<T_JobResumeRelationModel> GetIssueListData(T_IssueListParam param)
        {
            if (null == param)
                return null;
            return DBSession.IT_UseWorkerDAL.GetIssueListData(param);
        }
        /// <summary>
        ///  获取招聘对于简历数据总量
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public int GetIssueListDataCount(T_IssueListParam param)
        {
            if (null == param)
                return 0;
            return DBSession.IT_UseWorkerDAL.GetIssueListDataCount(param);
        }
        /// <summary>
        ///  获取一栏数据总量
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public int GetWorkListDataCount(T_UseWorkerParam param)
        {
            if (null == param)
                return 0;
            return DBSession.IT_UseWorkerDAL.GetWorkListDataCount(param);
        }
        /// <summary>
        ///  更新状态
        /// </summary>
        /// <param name="job_ids"></param>
        /// <param name="job_status"></param>
        /// <returns></returns>
        public void ModifyStatus(string job_ids, string job_status)
        {
            DBSession.IT_UseWorkerDAL.ModifyStatus(job_ids, job_status);
        }
        /// <summary>
        ///  获取字典集合
        /// </summary>
        /// <param name="item_code"></param>
        /// <returns></returns>
        public Dictionary<string, List<SelectModel>> GetJobDictionary()
        {
            string item_code = "'JobPost','JobEdu','WorkExperience','BusNature','BusScale'";
            List<SelectValueModel> list = DBSession.IT_UseWorkerDAL.GetJobDictionary(item_code);
            if (null == list)
                return null;
            Dictionary<string, List<SelectModel>> obj = new Dictionary<string, List<SelectModel>>();
            List<SelectModel> sel = new List<SelectModel>();
            var listTemp = list.Where(s => s.item_code.Equals("JobPost")).ToList();
            //1.职位类型
            foreach (var item in listTemp)
                sel.Add(new SelectModel { text = item.text, value = item.value });
            obj.Add("jobPost", sel);
            //2.学历
            sel = new List<SelectModel>();
            listTemp = list.Where(s => s.item_code.Equals("JobEdu")).ToList();
            foreach (var item in listTemp)
                sel.Add(new SelectModel { text = item.text, value = item.value });
            obj.Add("jobEdu", sel);
            //3.工种经验
            sel = new List<SelectModel>();
            listTemp = list.Where(s => s.item_code.Equals("WorkExperience")).ToList();
            foreach (var item in listTemp)
                sel.Add(new SelectModel { text = item.text, value = item.value });
            obj.Add("workExperience", sel);
            //4.公司性质
            sel = new List<SelectModel>();
            listTemp = list.Where(s => s.item_code.Equals("BusNature")).ToList();
            foreach (var item in listTemp)
                sel.Add(new SelectModel { text = item.text, value = item.value });
            obj.Add("busNature", sel);
            //5.公司规模
            sel = new List<SelectModel>();
            listTemp = list.Where(s => s.item_code.Equals("BusScale")).ToList();
            foreach (var item in listTemp)
                sel.Add(new SelectModel { text = item.text, value = item.value });
            obj.Add("busScale", sel);
            return obj;
        }

        //************************************APP Service*****************************************
        /// <summary>
        ///  获取职位列表
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public List<HCQ2_Model.APPModel.ResultApiModel.JobEmployResultModel> GetJobEmployList(HCQ2_Model.APPModel.ParamModel.JobEmployModel model)
        {
            if (null == model)
                return null;
            return DBSession.IT_UseWorkerDAL.GetJobEmployList(model);
        }
        /// <summary>
        ///  根据招聘信息 获取职位详情
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public  List<HCQ2_Model.APPModel.ResultApiModel.PostDetialResultModel> GetPostDetialByID(HCQ2_Model.APPModel.ParamModel.PostDetialParam model)
        {
            if (null == model)
                return null;
            return DBSession.IT_UseWorkerDAL.GetPostDetialByID(model);
        }
        /// <summary>
        ///  投递简历
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool SendResumeByID(HCQ2_Model.APPModel.ParamModel.PostDetialParam model)
        {
            HCQ2_Model.T_User user = DBSession.IT_UserDAL.Select(s => s.user_guid.Equals(model.userid)).FirstOrDefault();
            if (null == user)
                return false;
            HCQ2_Model.A01 a01 = DBSession.IA01DAL.Select(s => s.A0177.Equals(user.user_identify)).FirstOrDefault();
            if (null == a01)
                return false;
            HCQ2_Model.T_UseWorker work = DBSession.IT_UseWorkerDAL.Select(s => s.use_id == model.use_id).FirstOrDefault();
            HCQ2_Model.T_JobResumeRelation job = new HCQ2_Model.T_JobResumeRelation
            {
                com_id = work.com_id,
                use_id = model.use_id,
                A0177 = a01.A0177,
                UnitID = a01.UnitID,
                send_date = DateTime.Now,
                job_status = "01"
            };
            int mark = DBSession.IT_JobResumeRelationDAL.Add(job);
            return mark > 0 ? true : false;
        }
        /// <summary>
        ///  获取公司详情
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public List<HCQ2_Model.APPModel.ResultApiModel.BusComProinfoResult> GetComProDetailByID(HCQ2_Model.APPModel.ParamModel.BusComProinfo model)
        {
            if (null == model)
                return null;
            return DBSession.IT_UseWorkerDAL.GetComProDetailByID(model);
        }
        /// <summary>
        ///  获取行政区划
        /// </summary>
        /// <returns></returns>
        public List<ddlSelectModel> GetCity()
        {
            List<SM_CodeItems> value = DBSession.ISM_CodeItemsDAL.Select(s => s.CodeID.Equals("AB")).ToList();
            if (null == value || value.Count <= 0)
                return null;
            List<ddlSelectModel> result = new List<ddlSelectModel>();
            var temp = value.Where(s => s.Parent == ".").ToList();
            foreach (var item in temp)
            {
                if(item.Child>0)
                    result.Add(new ddlSelectModel { text = item.CodeItemName, value = item.JPSign,child= GetChildCity(value,item.CodeItemID) });
                else
                    result.Add(new ddlSelectModel { text = item.CodeItemName, value = item.JPSign });
            }
            return result;
        }

        private List<ddlSelectModel> GetChildCity(List<SM_CodeItems> model,string parent)
        {
            var value = model.Where(s => s.Parent.Equals(parent)).ToList();
            if (null == value || value.Count <= 0)
                return null;
            List<ddlSelectModel> result = new List<ddlSelectModel>();
            foreach (var item in value)
            {
                if(item.Child>0)
                    result.Add(new ddlSelectModel { text = item.CodeItemName, value = item.JPSign, child = GetChildCity(value, item.CodeItemID) });
                else
                    result.Add(new ddlSelectModel { text = item.CodeItemName, value = item.JPSign });
            }
            return result;
        }
    }
}
