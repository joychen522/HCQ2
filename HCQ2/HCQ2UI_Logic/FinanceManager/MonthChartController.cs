using System.Collections.Generic;
using System.Web.Mvc;
using HCQ2_Common;
using HCQ2_Model.ViewModel;


namespace HCQ2UI_Logic.FinanceManager
{
    /// <summary>
    ///  创建者：joychen
    ///  月趋势图控制器
    ///  请假管理
    /// </summary>
    public class MonthChartController:BaseLogic
    {
        //**************************1.月趋势图**************************
        #region 1.0 月趋势图首次进入 +  ActionResult MonthList()
        /// <summary>
        ///  1.0 月趋势图首次进入
        /// </summary>
        /// <returns></returns>
        [HCQ2_Common.Attributes.Load]
        [HCQ2_Common.Attributes.Element]
        public ActionResult MonthList()
        {
            return View();
        }
        #endregion

        #region  1.1 获取一栏数据 + ActionResult GetTableData(FormCollection form)
        /// <summary>
        ///  1.1 获取一栏数据
        /// </summary>
        /// <param name="form"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult GetTableData(FormCollection form)
        {
            string unitId = Helper.ToString(form["unitID"]);
            string dateStart = Helper.ToString(form["dateStart"]);
            string dateEnd = Helper.ToString(form["dateEnd"]);
            List<HCQ2_Model.ExtendsionModel.A02Model> list =
                operateContext.bllSession.A02.SelectA02Data(new HCQ2_Model.SelectModel.A02Model()
                {
                    unitID = unitId,
                    dateStart = dateStart,
                    dateEnd = dateEnd
                });
            TableModel tModel = new TableModel()
            {
                total = list.Count,
                rows = list
            };
            return Json(tModel, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region 1.2 获取图表信息 + ActionResult GetChartDataByUnit()
        /// <summary>
        ///  1.2 获取图表信息 
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult GetChartDataByUnit(FormCollection form)
        {
            string unitID = Helper.ToString(form["unitID"]);
            string dateStart = Helper.ToString(form["dateStart"]);
            string dateEnd = Helper.ToString(form["dateEnd"]);
            EchartsVo Ev = operateContext.bllSession.A02.GetMonthChartData(new HCQ2_Model.SelectModel.A02Model()
            {unitID = unitID,dateStart = dateStart,dateEnd = dateEnd});
            return operateContext.RedirectAjax(0, "", Ev, null);
        }
        #endregion

        //**************************2.详细信息**************************
        #region 2.0 详细信息初次进入 + ActionResult PersonList()
        /// <summary>
        ///  2.0 详细信息初次进入
        /// </summary>
        /// <returns></returns>
        public ActionResult PersonList()
        {
            return View();
        }
        #endregion

        #region 2.1 初始化Table + ActionResult InitPersonsTable()
        /// <summary>
        ///  2.1 初始化Table
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult InitPersonsTable()
        {
            int page = Helper.ToInt(Request["page"]);
            int rows = Helper.ToInt(Request["rows"]);
            string unitID = Helper.ToString(Request["unitID"]);
            string cardDate = Helper.ToString(Request["cardDate"]);
            HCQ2_Model.SelectModel.A02Model model = new HCQ2_Model.SelectModel.A02Model() {
                page = page,
                rows = rows,
                unitID = unitID,
                cardDate= cardDate
            };
            List<HCQ2_Model.ViewModel.PunchCardModel> list =
                operateContext.bllSession.A02.SelectCardPersons(model);
            model.page = 0;
            model.rows = 0;
            TableModel tModel = new TableModel()
            {
                total = operateContext.bllSession.A02.SelectCardPersons(model).Count,
                rows = list
            };
            return Json(tModel, JsonRequestBehavior.AllowGet);
        }
        #endregion

        //**************************3.请假管理**************************
        #region 3.0 请假管理首次进入 + ActionResult UserAskList()
        /// <summary>
        ///  3.0 请假管理首次进入
        /// </summary>
        /// <returns></returns>
        [HCQ2_Common.Attributes.Load]
        [HCQ2_Common.Attributes.Element]
        public ActionResult UserAskList()
        {
            return View();
        }
        #endregion

        #region 3.1 初始化请假管理列表 + ActionResult InitAskTable()
        /// <summary>
        ///  初始化请假管理列表 
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult InitAskTable()
        {
            int page = Helper.ToInt(Request["page"]);
            int rows = Helper.ToInt(Request["rows"]);
            string unitID = Helper.ToString(Request["unitID"]);
            string userName = Helper.ToString(Request["userName"]);
            string dateStart = Helper.ToString(Request["dateStart"]);
            string dateEnd = Helper.ToString(Request["dateEnd"]);
            HCQ2_Model.SelectModel.T_AskManagerModel model = new HCQ2_Model.SelectModel.T_AskManagerModel()
            {
                unitID = unitID,
                page = page,
                rows = rows,
                userName = userName,
                dateStart = dateStart,
                dateEnd = dateEnd
            };
            List<HCQ2_Model.ExtendsionModel.T_AskManagerModel> list =
                operateContext.bllSession.T_AskManager.SelectAskManagerData(model);
            HCQ2_Model.ViewModel.TableModel tModel = new TableModel()
            {
                total = operateContext.bllSession.T_AskManager.SelectCountAskUserData(model),
                rows = list
            };
            return Json(tModel, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region 3.2 添加请假数据  + ActionResult AddAsk(HCQ2_Model.ExtendsionModel.T_AskManagerModel model)
        /// <summary>
        ///  3.2 添加请假数据 
        /// </summary>
        /// <returns></returns>
        public ActionResult AddAsk(HCQ2_Model.ExtendsionModel.T_AskManagerModel model)
        {
            if (!ModelState.IsValid)
                return operateContext.RedirectAjax(1, "数据正确性验证失败~", null, null);
            int mark = operateContext.bllSession.T_AskManager.AddAskModel(model);
            if(mark>0)
                return operateContext.RedirectAjax(0, "添加成功~", null, null);
            return operateContext.RedirectAjax(1, "添加失败~", null, null);
        }
        #endregion

        #region 3.3 编辑请假数据 + ActionResult EditAsk(HCQ2_Model.ExtendsionModel.T_AskManagerModel model)
        /// <summary>
        ///  3.3 编辑请假数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public ActionResult EditAsk(HCQ2_Model.ExtendsionModel.T_AskManagerModel model)
        {
            if (!ModelState.IsValid)
                return operateContext.RedirectAjax(1, "数据正确性验证失败~", null, null);
            int ask_id = Helper.ToInt(Request["ask_id"]);
            model.ask_id = ask_id;
            int mark = operateContext.bllSession.T_AskManager.ModifyAskModel(model);
            if (mark > 0)
                return operateContext.RedirectAjax(0, "编辑成功~", null, null);
            return operateContext.RedirectAjax(1, "编辑失败~", null, null);
        }
        #endregion

        #region 3.4 删除请假数据 + ActionResult DeleteAsk(int id)
        /// <summary>
        ///  3.4 删除请假数据
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult DeleteAsk(int id)
        {
            int mark = operateContext.bllSession.T_AskManager.Delete(s => s.ask_id == id);
            if(mark>0)
                return operateContext.RedirectAjax(0, "删除成功~", "", "");
            return operateContext.RedirectAjax(1, "删除失败~", "", "");
        } 
        #endregion
    }
}
