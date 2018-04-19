using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using HCQ2_Common;
using HCQ2_Model.ViewModel;

namespace HCQ2UI_Logic.FinanceManager
{
    /// <summary>
    ///  发放汇总控制器
    /// </summary>
    public class SumGrantController:BaseLogic
    {
        //***********************************1：发放汇总************************************
        #region  1.0 发放汇总首次进入页面 + ActionResult SumList()
        /// <summary>
        ///  1.0 发放汇总首次进入页面
        /// </summary>
        /// <returns></returns>
        [HCQ2_Common.Attributes.Load]
        [HCQ2_Common.Attributes.Element]
        public ActionResult SumList()
        {
            return View();
        }
        #endregion

        #region 1.1 获取一栏数据 + ActionResult initSumGrantDataList()
        /// <summary>
        ///  1.1 获取一栏数据
        /// </summary>
        /// <returns></returns>
        public ActionResult initSumGrantDataList()
        {
            string unitID = Helper.ToString(Request["unitID"]);
            if (string.IsNullOrEmpty(unitID))
                return null;
            string a0101= Helper.ToString(Request["a0101"]);
            string dateStart = Helper.ToString(Request["dateStart"]);
            string dateEnd = Helper.ToString(Request["dateEnd"]);
            int page = Helper.ToInt(Request["page"]);
            int rows = Helper.ToInt(Request["rows"]);
            HCQ2_Model.SelectModel.WGJG02ByUnitID model = new HCQ2_Model.SelectModel.WGJG02ByUnitID()
            {
                UnitID = unitID,
                A0101 = a0101,
                DateStart = dateStart,
                DateEnd = dateEnd,
                page = page,
                rows = rows
            };
            List<WGJG02Model> list = operateContext.bllSession.WGJG02.GetWageDetailByUnitID(model);
            TableModel tModel = new TableModel()
            {
                total = operateContext.bllSession.WGJG02.CountPersonsByModel(model),
                rows = list
            };
            return Json(tModel, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region 1.2 导出Excel + ActionResult ExportToExcel()
        /// <summary>
        ///  1.2 导出Excel
        /// </summary>
        /// <returns></returns>
        public void ExportToExcel()
        {
            string unitID = Helper.ToString(Request["unitID"]);
            string a0101 = Helper.ToString(Request["a0101"]);
            string dateStart = Helper.ToString(Request["dateStart"]);
            string dateEnd = Helper.ToString(Request["dateEnd"]);
            HCQ2_Model.SelectModel.WGJG02ByUnitID model = new HCQ2_Model.SelectModel.WGJG02ByUnitID()
            {
                UnitID = unitID,
                A0101 = a0101,
                DateStart = dateStart,
                DateEnd = dateEnd
            };
            // 写入到客户端  
            operateContext.bllSession.WGJG02.ExportToExcel(model);
        }
        #endregion

        //***********************************2：发放统计************************************
        #region 2.0 发放统计页面首次进入 + ActionResult CountGrantList()
        /// <summary>
        ///  发放统计页面首次进入
        /// </summary>
        /// <returns></returns>
        [HCQ2_Common.Attributes.Load]
        [HCQ2_Common.Attributes.Element]
        public ActionResult CountGrantList()
        {
            return View();
        }
        #endregion

        #region 2.1 初始化Table + ActionResult InitTable()
        /// <summary>
        ///  2.1 初始化Table
        /// </summary>
        /// <returns></returns>
        public ActionResult InitTable()
        {
            string unitID = Helper.ToString(Request["unitID"]);
            if (string.IsNullOrEmpty(unitID))
                return null;
            string dateStart = Helper.ToString(Request["dateStart"]);
            string dateEnd = Helper.ToString(Request["dateEnd"]);
            int page = Helper.ToInt(Request["page"]);
            int rows = Helper.ToInt(Request["rows"]);
            List<WGJG01Model> list = operateContext.bllSession.WGJG01.GetWageListDataByUnit(new HCQ2_Model.SelectModel.WGJG01ChartModel() { unitID = unitID,dateStart=dateStart,dateEnd=dateEnd, page = page, rows = rows });
            TableModel tModel = new TableModel()
            {
                total = operateContext.bllSession.WGJG01.SelectCount(s => s.UnitID == unitID),
                rows = list
            };
            return Json(tModel, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region 2.2 获取汇总统计数据 + ActionResult GetCountGrantData( FormCollection form)
        /// <summary>
        ///  2.1 获取汇总统计数据
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult GetCountGrantData( FormCollection form)
        {
            string rowID = Helper.ToString(form["rowID"]); 
            string unitID = Helper.ToString(form["unitID"]);
            string dateStart = Helper.ToString(form["dateStart"]);
            string dateEnd = Helper.ToString(form["dateEnd"]);
            EchartsVo vo = operateContext.bllSession.WGJG01.GetChartData(new HCQ2_Model.SelectModel.WGJG01ChartModel()
            {
                rowID= rowID,
                unitID = unitID,
                dateStart = dateStart,
                dateEnd = dateEnd,
                isAll = true
            });
            return operateContext.RedirectAjax(0, "", vo, null);
        } 
        #endregion
    }
}
