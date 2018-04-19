using HCQ2_Common;
using HCQ2_Model.AfterSaleModel;
using HCQ2_Model.FormatModel;
using HCQ2_Model.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace HCQ2UI_Logic.AfterSaleManager
{
    /// <summary>
    ///  设备维护&售后人员管理
    /// </summary>
    public  class FacilityPlantController:BaseLogic
    {
        //**********************************1.0 设备维护**************************************
        #region 1.0 设备维护页面首次进入 + ActionResult FacityList()
        /// <summary>
        ///  1.0 设备维护页面首次进入
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [HCQ2_Common.Attributes.Load]
        [HCQ2_Common.Attributes.Element]
        public ActionResult FacityList()
        {
            return View();
        }
        #endregion

        #region 1.1 初始化Table数据表 + ActionResult InitTable()
        /// <summary>
        ///  1.1 初始化Table数据表
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult InitTable()
        {
            string area_code = RequestHelper.GetStrByName("area_code"),//区域代码
                unit_code = RequestHelper.GetStrByName("unit_code"),//项目代码
                facityStatus = RequestHelper.GetDeStrByName("facityStatus"),//设备状态
                installName = RequestHelper.GetDeStrByName("installName"),//安装人
                skillName = RequestHelper.GetDeStrByName("skillName");//技术支持
            int page = RequestHelper.GetIntByName("page"),
               rows = RequestHelper.GetIntByName("rows");
            ItemPreserveParam param = new ItemPreserveParam { rows = rows, page = page, unit_code = unit_code, area_code = area_code, status = facityStatus,install_name=installName, skiller = skillName };
            List<FacilityPreserveModel> list = operateContext.bllSession.BB_FacilityPreserve.GetInitData(param);
            TableModel tModel = new TableModel()
            {
                total = operateContext.bllSession.BB_FacilityPreserve.GetCountData(param),
                rows = list
            };
            return Json(tModel, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region 1.2 添加设备记录 + ActionResult AddFacility(FacilityPreserveModel item)
        /// <summary>
        ///  添加设备记录
        /// </summary>
        /// <param name="user">设备对象</param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult AddFacility(FacilityPreserveModel item)
        {
            if (!ModelState.IsValid)
                return operateContext.RedirectAjax(1, "数据验证失败~", "", "");
            try
            {
                int mark = operateContext.bllSession.BB_FacilityPreserve.AddFacility(item);
                if (mark > 0)
                    return operateContext.RedirectAjax(0, "添加用户成功~", "", "");
                return operateContext.RedirectAjax(1, "添加用户失败~", "", "");
            }
            catch (Exception ex)
            {
                return operateContext.RedirectAjax(1, ex.Message, "", "");
            }
        }
        #endregion

        #region 1.3 编辑台账记录 + ActionResult EditItem(FacilityPreserveModel item)
        /// <summary>
        ///  编辑台账记录
        /// </summary>
        /// <param name="item">项目记录</param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult EditFacility(FacilityPreserveModel item)
        {
            if (!ModelState.IsValid)
                return operateContext.RedirectAjax(1, "数据验证失败~", "", "");
            try
            {
                int fp_id = Helper.ToInt(Request["fp_id"]);
                if (fp_id <= 0)
                    return operateContext.RedirectAjax(1, "编辑台账主键值为空~", "", "");
                operateContext.bllSession.BB_FacilityPreserve.EditFacility(item, fp_id);
                return operateContext.RedirectAjax(0, "编辑用户成功~", "", "");
            }
            catch (Exception ex)
            {
                return operateContext.RedirectAjax(1, ex.Message, "", "");
            }
        }
        #endregion

        #region 1.4 删除项目记录 + ActionResult DelFacilityByID(int id)
        /// <summary>
        ///  1.4 删除项目记录
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult DelFacilityByID(int id)
        {
            if (id <= 0)
                return operateContext.RedirectAjax(1, "需要删除的数据不存在~", "", "");
            int mark = operateContext.bllSession.BB_FacilityPreserve.Delete(s => s.fp_id == id);
            if (mark > 0)
                return operateContext.RedirectAjax(0, "数据删除成功~", "", "");
            return operateContext.RedirectAjax(1, "数据删除失败~", "", "");
        }
        #endregion

        //**********************************2.0 售后人员管理**************************************
        #region  2.0 售后人员管理首次进入 + ActionResult ServiceList()
        /// <summary>
        ///  2.0 售后人员管理首次进入
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [HCQ2_Common.Attributes.Load]
        [HCQ2_Common.Attributes.Element]
        public ActionResult ServiceList()
        {
            return View();
        }
        #endregion

        #region 2.1 获取所有平台用户 + ActionResult GetPersons()
        /// <summary>
        ///  获取所有平台用户
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult GetAllPersons()
        {
            List<HCQ2_Model.SelectModel.ListBoxModel> list = operateContext.bllSession.T_User.GetBasePersions();
            return operateContext.RedirectAjax(0, "人员数据获取成功~", list, "");
        }
        #endregion

        #region 2.2 保存被选中的数据 + ActionResult SaveUserDataBySelect()
        /// <summary>
        ///  2.2 保存被选中的数据
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult SaveUserDataBySelect()
        {
            string personData = RequestHelper.GetStrByName("personData");//数据
            if (string.IsNullOrEmpty(personData))
                return operateContext.RedirectAjax(1, "需要生成的数据为空~", "", "");
            bool mark = operateContext.bllSession.BB_ServiceUser.SaveServiceUserData(personData);
            if (mark)
                return operateContext.RedirectAjax(0, "数据保存成功~", "", "");
            return operateContext.RedirectAjax(1, "数据保存失败~", "", "");
        }
        #endregion

        #region 2.3 移除售后用户 + ActionResult DelServiceUserByID(int id)
        /// <summary>
        ///  2.3 移除售后用户
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult DelServiceUserByID(int id)
        {
            if (id <= 0)
                return operateContext.RedirectAjax(1, "需要移除的数据不存在~", "", "");
            int mark = operateContext.bllSession.BB_ServiceUser.Delete(s => s.su_id == id);
            if (mark > 0)
                return operateContext.RedirectAjax(0, "数据移除成功~", "", "");
            return operateContext.RedirectAjax(1, "数据移除失败~", "", "");
        }
        #endregion

        #region 2.4 初始化售后人员列表 + ActionResult InitServiceUserTable()
        /// <summary>
        ///  2.4 初始化售后人员列表
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult InitServiceUserTable()
        {
            List<HCQ2_Model.ExtendsionModel.ServiceUserModel> list = operateContext.bllSession.BB_ServiceUser.GetServiceUser();
            TableModel tModel = new TableModel()
            {
                total = operateContext.bllSession.BB_ServiceUser.SelectCount(s=>s.user_id>0),
                rows = list
            };
            return Json(tModel, JsonRequestBehavior.AllowGet);
        }
        #endregion

        //**********************************3.0 售后人员管理**************************************
        #region 3.0 获取售后服务人员字典 + ActionResult GetServiceUserDictionary()
        /// <summary>
        ///  3.0 获取售后服务人员字典
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult GetServiceUserDictionary()
        {
            List<CodeItemsModel> list = operateContext.bllSession.BB_ServiceUser.GetServiceUserDictionary();
            return operateContext.RedirectAjax(0, "", list, null);
        } 
        #endregion
    }
}
