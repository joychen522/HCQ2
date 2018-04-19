using HCQ2_Common;
using HCQ2_Model.ExtendsionModel;
using HCQ2_Model.ParamsModel;
using HCQ2_Model.ViewModel;
using System.Collections.Generic;
using System.IO;
using System.Web;
using System.Web.Mvc;

namespace HCQ2UI_Logic.JobManager
{
    /// <summary>
    ///  就业模块控制器
    /// </summary>
    public class JobController:BaseLogic
    {
        //***************************01：发布用工需求******************************
        #region 1.0：发布用工需求首次进入 + ActionResult IssueWorkList()
        /// <summary>
        ///  1.0：发布用工需求首次进入
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [HCQ2_Common.Attributes.Element]
        [HCQ2_Common.Attributes.Load]
        public ActionResult  IssueWorkList()
        {
            return View();
        }
        #endregion

        #region 1.1：获取企业单位数据 + ActionResult GetUnitData()
        /// <summary>
        ///  1.1：获取企业单位数据
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult GetUnitData()
        {
            int use_status = RequestHelper.GetIntByName("use_status");
            return operateContext.RedirectAjax(0, "成功", operateContext.bllSession.T_CompProInfo.GetUnitData(use_status), "");
        }
        #endregion

        #region 1.2 初始化Table + ActionResult InitJobTable(int id)
        /// <summary>
        ///  1.2 初始化Table
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult InitJobTable()
        {
            string jobName = RequestHelper.GetStrByName("jobName");//行业，岗位
            int page = RequestHelper.GetIntByName("page"),
               rows = RequestHelper.GetIntByName("rows"),
               com_id=RequestHelper.GetIntByName("com_id"),
               jobStartMoney = RequestHelper.GetIntByName("jobStartMoney"),
               jobEndMoney = RequestHelper.GetIntByName("jobEndMoney");
            jobName = (!string.IsNullOrEmpty(jobName)) ? HttpUtility.UrlDecode(jobName) : "";
            T_UseWorkerParam param = new T_UseWorkerParam { com_id = com_id, jobName = jobName, jobStartMoney = jobStartMoney, jobEndMoney = jobEndMoney, page = page, rows = rows };
            List<T_UseWorkerModel> user = operateContext.bllSession.T_UseWorker.GetUseWorkListData(param);
            TableModel tModel = new TableModel()
            {
                total = operateContext.bllSession.T_UseWorker.GetWorkListDataCount(param),
                rows = user
            };
            return Json(tModel, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region 1.3 删除招聘信息 + ActionResult delJobData(int id)
        /// <summary>
        ///  1.3 删除招聘信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult delJobData(int id)
        {
            int mark = operateContext.bllSession.T_UseWorker.DelUseWork(id);
            if (mark <= 0)
                return operateContext.RedirectAjax(1, "删除招聘信息失败！", "", "");
            return operateContext.RedirectAjax(0, "删除招聘信息成功~", "", "");
        }
        #endregion

        #region 1.4 添加招聘信息 + ActionResult AddJobData(T_UseWorkerModel model)
        /// <summary>
        ///  1.4 添加招聘信息
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult AddJobData(T_UseWorkerModel model)
        {
            if (!ModelState.IsValid)
                return operateContext.RedirectAjax(1, "数据验证失败~", "", "");
            int com_id = RequestHelper.GetIntByName("com_id");
            model.com_id = com_id;
            model.logo = UploadImg();
            int mark = operateContext.bllSession.T_UseWorker.AddUseWork(model);
            if (mark <= 0)
                return operateContext.RedirectAjax(1, "添加招聘信息失败！", "", "");
            return operateContext.RedirectAjax(0, "添加招聘信息成功~", "", "");
        }
        #endregion

        #region 1.5 编辑招聘信息 + ActionResult EditJobData(T_UseWorkerModel model)
        /// <summary>
        ///  1.5 编辑招聘信息
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult EditJobData(T_UseWorkerModel model)
        {
            if (!ModelState.IsValid)
                return operateContext.RedirectAjax(1, "数据验证失败~", "", "");
            int use_id = RequestHelper.GetIntByName("use_id");
            model.use_id = use_id;
            model.logo = UploadImg();
            int mark = operateContext.bllSession.T_UseWorker.EditUseWork(model);
            if (mark <= 0)
                return operateContext.RedirectAjax(1, "编辑招聘信息失败！", "", "");
            return operateContext.RedirectAjax(0, "编辑招聘信息成功~", "", "");
        } 
        #endregion

        private byte[] UploadImg()
        {
            byte[] logo = null;
            #region 1.0 处理上传文件夹
            string pathServer = "~/UpFile/Logo";
            string path = Server.MapPath(pathServer);
            if (!Directory.Exists(path.ToString()))
                Directory.CreateDirectory(path.ToString());//文件夹不存在则创建
            #endregion

            #region 2.0 处理文档
            var files = Request.Files;
            int file_id = 0;
            for (int i = 0; i < files.Count; i++)
            {
                HttpPostedFileBase file = files[i];
                if (null == file)
                    continue;
                //0.判断格式是否为：png/jpg/jpeg不是则不处理图片
                string Filetype = file.FileName.Substring(file.FileName.LastIndexOf('.') + 1).ToLower();
                if (Filetype != "png" && Filetype != "jpg" && Filetype != "jpeg")
                    break;
                string sFile = Server.MapPath(pathServer + "/" + operateContext.Usr.user_name + "_old." + Filetype),//原始图片
                    dFile =Server.MapPath(pathServer + "/" + operateContext.Usr.user_name + "_new." + Filetype);//新图片
                //1.上传文档
                file.SaveAs(Server.MapPath(pathServer + "/" + operateContext.Usr.user_name + "_old."+ Filetype));//上传文件
                //2.裁剪保存图片进数据库
                bool mar = ImageHelper.CompressImage(sFile, dFile, 100, 100, 50, ImageHelper.ImageCompressType.Wh);
                if (mar)
                    logo = ImageHelper.ImageToBytes(dFile);
                try
                {
                    if (System.IO.File.Exists(sFile))
                        System.IO.File.Delete(sFile);
                    if (System.IO.File.Exists(dFile))
                        System.IO.File.Delete(dFile); 
                }
                catch
                {
                	
                }
            }
            #endregion
            return logo;
        }

        //***************************02：查看用工需求******************************
        #region 2.0：查看用工需求首次进入 + ActionResult LockWorkList()
        /// <summary>
        ///  2.0：查看用工需求首次进入
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [HCQ2_Common.Attributes.Element]
        [HCQ2_Common.Attributes.Load]
        public ActionResult  LockWorkList()
        {
            return View();
        }
        #endregion

        #region 2.1 初始化Table + ActionResult InitIssueTable(int id)
        /// <summary>
        ///  2.1 初始化Table
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult InitIssueTable()
        {
            string jobName = RequestHelper.GetDeStrByName("jobName");//行业，岗位
            int page = RequestHelper.GetIntByName("page"),
               rows = RequestHelper.GetIntByName("rows"),
               com_id = RequestHelper.GetIntByName("com_id"),
               use_status = RequestHelper.GetIntByName("use_status"),
               jobStartMoney = RequestHelper.GetIntByName("jobStartMoney"),
               jobEndMoney = RequestHelper.GetIntByName("jobEndMoney");
            jobName = (!string.IsNullOrEmpty(jobName)) ? HttpUtility.UrlDecode(jobName) : "";
            T_UseWorkerParam param = new T_UseWorkerParam { com_id = com_id, use_status = use_status, jobName = jobName, jobStartMoney = jobStartMoney, jobEndMoney = jobEndMoney, page = page, rows = rows };
            List<T_UseIssueListModel> user = operateContext.bllSession.T_UseWorker.GetUseIssueListData(param);
            TableModel tModel = new TableModel()
            {
                total = operateContext.bllSession.T_UseWorker.GetWorkListDataCount(param),
                rows = user
            };
            return Json(tModel, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region 2.2 撤销发布 + ActionResult RepealJob(int id)
        /// <summary>
        ///  2.2 撤销发布
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult RepealJob(int id)
        {
            if(id<=0)
                return operateContext.RedirectAjax(1, "撤销招聘信息失败！", "", "");
            operateContext.bllSession.T_JobResumeRelation.Delete(s => s.use_id == id);
            int mark = operateContext.bllSession.T_UseWorker.Modify(new HCQ2_Model.T_UseWorker { use_status = 1 }, s => s.use_id == id, "use_status");
            if (mark <= 0)
                return operateContext.RedirectAjax(1, "撤销招聘信息失败！", "", "");
            return operateContext.RedirectAjax(0, "成功撤销招聘信息~", "", "");
        }
        #endregion

        //***************************03：查看简历******************************
        #region 3.0 首次进入简历管理页面 + ActionResult IssueList() 
        /// <summary>
        ///  3.0 首次进入简历管理页面
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [HCQ2_Common.Attributes.Load]
        public ActionResult IssueList()
        {
            return View();
        } 
        #endregion

        #region 3.1 获取简历列表 + ActionResult InitResumeTable(int id)
        /// <summary>
        ///  3.1 获取简历列表
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult InitResumeTable(int id)
        {
            string A0101 = RequestHelper.GetDeStrByName("A0101"),//姓名
               C0104 = RequestHelper.GetStrByName("C0104"),//电话
               A0410 = RequestHelper.GetDeStrByName("A0410");//专业
            int page = RequestHelper.GetIntByName("page"),
               rows = RequestHelper.GetIntByName("rows");
            T_IssueListParam param = new T_IssueListParam { use_id = id, A0101 = A0101, C0104 = C0104, A0410 = A0410, page = page, rows = rows };
            List<T_JobResumeRelationModel> user = operateContext.bllSession.T_UseWorker.GetIssueListData(param);
            TableModel tModel = new TableModel()
            {
                total = operateContext.bllSession.T_UseWorker.GetIssueListDataCount(param),
                rows = user
            };
            return Json(tModel, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region 3.2 修改状态 + ActionResult ModifyIssue()
        /// <summary>
        /// 3.2 修改状态 
        /// </summary>
        /// <returns></returns>
        public ActionResult ModifyIssue()
        {
            string job_id = RequestHelper.GetStrByName("job_id"),
                job_status = RequestHelper.GetStrByName("job_status");
            if (string.IsNullOrEmpty(job_id))
                return operateContext.RedirectAjax(1, "需要更新的简历为空！", "", "");
            job_id = job_id.Trim(',');
            operateContext.bllSession.T_UseWorker.ModifyStatus(job_id, job_status);
            return operateContext.RedirectAjax(0, "状态修改成功！", "", "");
        } 
        #endregion
    }
}
