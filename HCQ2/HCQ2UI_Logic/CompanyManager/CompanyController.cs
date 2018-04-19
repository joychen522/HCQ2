using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using HCQ2_Common;
using HCQ2_Common.Code;
using HCQ2_Model.ViewModel;
using RequestHelper = HCQ2_Common.RequestHelper;
using HCQ2_Model.ExtendsionModel;
using HCQ2_Model;

namespace HCQ2UI_Logic.CompanyManager
{
    /// <summary>
    ///  征信信息控制器
    /// </summary>
    public class CompanyController:BaseLogic
    {
        /******************************1.0个人征信*********************************/
        #region 1.0 个人征信首次进入页面 + ActionResult OwnPanyList()
        /// <summary>
        ///  1.0 个人征信首次进入页面
        /// </summary>
        /// <returns></returns>
        [HCQ2_Common.Attributes.Load]
        [HCQ2_Common.Attributes.Element]
        public ActionResult OwnPanyList()
        {
            return View();
        }
        #endregion

        #region 1.1 初始化个人征信信息Table + ActionResult InitOwnListTable()
        /// <summary>
        ///  1.1 初始化个人征信信息Table
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult InitOwnListTable()
        {
            int page = Helper.ToInt(Request["page"]);
            int rows = Helper.ToInt(Request["rows"]);
            string userName = RequestHelper.GetDeStrByName("userName");
            List<HCQ2_Model.WGJG_GRZX> list =
                operateContext.bllSession.WGJG_GRZX.SelectOwnDataByName(page, rows, userName);
            TableModel tModel = new TableModel()
            {
                total = operateContext.bllSession.WGJG_GRZX.SelectCount(s=>s.WGJG_GRZX02.Contains(userName)),
                rows = list
            };
            return Json(tModel, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region 1.2 添加个人征信  + ActionResult AddOwnPany(HCQ2_Model.WGJG_GRZX model)
        /// <summary>
        ///  1.2 添加个人征信 
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult AddOwnPany(HCQ2_Model.WGJG_GRZX model)
        {
            if (!ModelState.IsValid)
                return operateContext.RedirectAjax(1, "数据正确性验证失败~", null, null);
            model.RowID = OnlyCodeHelper.CreateOnlyCode();
            model.WGJG_GRZX01 = OnlyCodeHelper.CreateIntCode();
            model.WGJG_GRZX10 = operateContext.Usr.user_name;
            model.WGJG_GRZX11 = DateTime.Now;
            int mark = operateContext.bllSession.WGJG_GRZX.Add(model);
            if (mark > 0)
                return operateContext.RedirectAjax(0, "添加成功~", null, null);
            return operateContext.RedirectAjax(1, "添加失败~", null, null);
        }
        #endregion 

        #region 1.3 编辑个人征信 + EditOwnPany(HCQ2_Model.WGJG_GRZX model)
        /// <summary>
        ///  1.3 编辑个人征信
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult EditOwnPany(HCQ2_Model.WGJG_GRZX model)
        {
            if (!ModelState.IsValid)
                return operateContext.RedirectAjax(1, "数据正确性验证失败~", null, null);
            string rowID = Helper.ToString(Request["rowID"]);
            model.RowID = rowID;
            int mark = operateContext.bllSession.WGJG_GRZX.ModifyData(model);
            if (mark > 0)
                return operateContext.RedirectAjax(0, "编辑成功~", null, null);
            return operateContext.RedirectAjax(1, "编辑失败~", null, null);
        }
        #endregion

        #region 1.4 删除个人征信 + ActionResult DeleteOwnPany()
        /// <summary>
        ///  1.4 删除个人征信
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult DeleteOwnPany()
        {
            string RowID = Helper.ToString(Request["rowID"]);
            int mark = operateContext.bllSession.WGJG_GRZX.Delete(s => s.RowID == RowID);
            if (mark > 0)
                return operateContext.RedirectAjax(0, "删除成功~", "", "");
            return operateContext.RedirectAjax(1, "删除失败~", "", "");
        }
        #endregion

        /******************************2.0企业征信*********************************/

        #region 2.0 企业征信首次进入页面 + ActionResult EnterpriseList()
        /// <summary>
        ///  2.0 企业征信首次进入页面
        /// </summary>
        /// <returns></returns>
        [HCQ2_Common.Attributes.Load]
        [HCQ2_Common.Attributes.Element]
        public ActionResult EnterpriseList()
        {
            return View();
        }
        #endregion

        #region 2.1 初始化Table  + ActionResult InitEnterTable()
        /// <summary>
        ///  2.1 初始化Table 
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult InitEnterTable()
        {
            string unitName = RequestHelper.GetDeStrByName("unitName");
            int page = RequestHelper.GetIntByName("page");
            int rows = RequestHelper.GetIntByName("rows");
            List<HCQ2_Model.WGJG_ZX> list = operateContext.bllSession.WGJG_ZX.SelectUnitDataByName(page, rows, unitName);
            TableModel tModel = new TableModel()
            {
                rows = list,
                total = operateContext.bllSession.WGJG_ZX.SelCountData(unitName)
            };
            return Json(tModel, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region 2.5 获取企业名称集合 + ActionResult GetEnterData()
        /// <summary>
        ///  2.5 获取企业名称集合
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult GetEnterData()
        {
            List<HCQ2_Model.T_CompProInfo> list = operateContext.bllSession.T_CompProInfo.Select(s=>!string.IsNullOrEmpty(s.dwmc)).ToList();
            if(list!=null)
                return operateContext.RedirectAjax(0, "获取成功~", list.Select(s=>s.dwmc).ToList(), null);
            return operateContext.RedirectAjax(1, "获取失败~", null, null);
        } 
        #endregion

        /******************************3.0企业征信--详细信息*********************************/

        #region 3.0 征信详细一栏 + ActionResult EnterDetailList()
        /// <summary>
        ///  3.0 征信详细一栏
        /// </summary>
        /// <returns></returns>
        [HCQ2_Common.Attributes.Load]
        public ActionResult EnterDetailList()
        {
            return View();
        }
        #endregion

        #region 3.1 获取企业征信详细列表数据 + ActionResult InitEnterDeatilData(int id)
        /// <summary>
        ///  3.1 获取企业征信详细列表数据
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult InitEnterDeatilData(int id)
        {
            string keyword = RequestHelper.GetDeStrByName("keyword");//标题查询
            int page = RequestHelper.GetIntByName("page");
            int rows = RequestHelper.GetIntByName("rows");
            List<WGJG_ZXDetail> list = operateContext.bllSession.T_EnterDetail.GetEnterDetailData(page, rows, id, keyword);
            TableModel tModel = new TableModel()
            {
                rows = list,
                total = operateContext.bllSession.T_EnterDetail.SelectCount(s => s.ed_title.Contains(keyword))
            };
            return Json(tModel, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region 3.2 添加对象 + ActionResult AddEnterDetail(HCQ2_Model.T_EnterDetail model)
        /// <summary>
        ///  3.2 添加对象
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult AddEnterDetail(T_EnterDetail model)
        {
            if (!ModelState.IsValid)
                return operateContext.RedirectAjax(1, "数据正确性验证失败~", null, null);
            if(model.ed_time==null)
                model.ed_time = DateTime.Now;
            model.update_name = operateContext.Usr.user_name;
            model.update_time = DateTime.Now;
            model.ed_createId = operateContext.Usr.user_id;
            int mark = operateContext.bllSession.T_EnterDetail.Add(model);
            if (mark > 0)
                return operateContext.RedirectAjax(0, "添加成功~", null, null);
            return operateContext.RedirectAjax(1, "添加失败~", null, null);
        }
        #endregion

        #region 3.3 编辑对象 + ActionResult EditEnterDetail(HCQ2_Model.T_EnterDetail model)
        /// <summary>
        ///  3.3 编辑对象
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult EditEnterDetail(T_EnterDetail model)
        {
            if (!ModelState.IsValid)
                return operateContext.RedirectAjax(1, "数据正确性验证失败~", null, null);
            //string rowID = RequestHelper.GetStrByName("rowID");
            model.update_name = operateContext.Usr.user_name;
            model.update_time = DateTime.Now;
            int mark = operateContext.bllSession.T_EnterDetail.Modify(model,s=>s.ed_id==model.ed_id, "ed_title", "ed_reason", "ed_create", "ed_note", "ent_type", "is_success", "case_type", "pay_money", "pay_person", "solve_type", "ed_time", "update_name", "update_time");
            if (mark > 0)
                return operateContext.RedirectAjax(0, "编辑成功~", null, null);
            return operateContext.RedirectAjax(1, "编辑失败~", null, null);
        }
        #endregion

        #region 3.4 删除对象 + ActionResult DelEnterPany()
        /// <summary>
        ///  3.4 删除对象
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult DelEnterDetail(int id)
        {
            if (id<=0)
                return operateContext.RedirectAjax(1, "参数异常~", null, null);
            int mark = operateContext.bllSession.T_EnterDetail.Delete(s => s.ed_id == id);
            if (mark > 0)
                return operateContext.RedirectAjax(0, "删除成功~", null, null);
            return operateContext.RedirectAjax(1, "删除失败~", null, null);
        }
        #endregion

        #region 首页企业征信信息

        [HCQ2_Common.Attributes.Load]
        public ActionResult MainCompay()
        {
            return View();
        }

        public ActionResult GetMainCompaySoure(FormCollection form)
        {
            int rows = int.Parse(form["rows"]);
            int page = int.Parse(form["page"]);

            List<T_EnterDetail> enterList = operateContext.bllSession.T_EnterDetail.GetEnterByUserid(
                operateContext.Usr.user_id);
            if (!string.IsNullOrEmpty((form["project_name"])))
            {
                string ent_reason = form["project_name"];
                enterList = enterList.Where(o => o.ed_reason.Contains(ent_reason)).ToList();
            }
            TableModel modle = new TableModel
            {
                rows = enterList.Skip((rows * page) - rows).Take(rows),
                total = enterList.Count()
            };
            return Json(modle, JsonRequestBehavior.AllowGet);
        }

        #endregion
    }
}
