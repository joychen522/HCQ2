using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using HCQ2_Model.ViewModel;
using System.IO;

namespace HCQ2UI_Logic
{
    public class AttendanceController : BaseLogic
    {
        /// <summary>
        /// 数据获取私有变量
        /// </summary>
        private HCQ2_IBLL.IBLLSession bll;

        #region 工时月信息

        /// <summary>
        /// 工时月信息获取table数据源
        /// </summary>
        /// <returns></returns>
        [HCQ2_Common.Attributes.Load]
        [HCQ2_Common.Attributes.Element]
        public ActionResult Attendance()
        {
            List<HCQ2_Model.TreeModel.B01PerTreeModel> list = operateContext.bllSession.B01.GetB01PerData(operateContext.Usr.user_id);
            ViewBag.TreeJson = HCQ2_Common.JsonHelper.ObjectToJson(list).ToString();
            return View();
        }

        /// <summary>
        /// 工时月信息获取table数据源
        /// </summary>
        /// <param name="form"></param>
        /// <returns></returns>
        public ActionResult GetAttendinfo(FormCollection form)
        {
            bll = operateContext.bllSession;
            int page = int.Parse(form["page"]);
            int rows = int.Parse(form["rows"]);
            string yearStr = DateTime.Now.Year.ToString();
            string monthStr = DateTime.Now.Month.ToString();
            if (!string.IsNullOrEmpty(form["txtSearchDate"]))
            {
                string[] searchDate = form["txtSearchDate"].ToString().Split('-');
                yearStr = searchDate[0];
                monthStr = searchDate[1];
            }
            DataTable dt = bll.A01.GetAttendance(yearStr, monthStr);
            if (!string.IsNullOrEmpty(form["UnitID"]))
            {
                dt = dt.Select("UnitID='" + form["UnitID"].Trim() + "'").CopyToDataTable();
            }
            else
            {
                dt = dt.Select("UnitID='" + operateContext.bllSession.B01.GetB01PerData(operateContext.Usr.user_id)[0].UnitID + "'").CopyToDataTable();
            }
            if (!string.IsNullOrEmpty(form["txtSearchName"]))
            {
                dt = dt.Select("A0101 like '%" + form["txtSearchName"].Trim() + "%'").CopyToDataTable();
            }
            TableModel model = new TableModel();
            if (dt.Rows.Count > 0)
            {
                List<AttendanceModel> attList = HCQ2_Common.Data.DataTableHelper.DataTableToIList<AttendanceModel>(dt);
                model.rows = attList.Skip((page * rows) - rows).Take(rows);
                model.total = attList.Count();
            }
            return Json(model, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 导出考勤的Excel
        /// </summary>
        /// <param name="UnitID"></param>
        /// <param name="date"></param>
        /// <returns></returns>
        public ActionResult AttendExcel(string UnitID, string date)
        {
            System.IO.MemoryStream ms = operateContext.bllSession.View_A02.GetAttendBook(UnitID, date);
            ms.Seek(0, SeekOrigin.Begin);
            return File(ms, "application/vnd.ms-excel", "考勤信息.xls");
        }

        #endregion

        #region 发放明细

        /// <summary>
        /// 发放明细
        /// </summary>
        /// <returns></returns>
        [HCQ2_Common.Attributes.Load]
        [HCQ2_Common.Attributes.Element]
        public ActionResult WageDetail()
        {
            List<HCQ2_Model.TreeModel.B01PerTreeModel> list = operateContext.bllSession.B01.GetB01PerData(operateContext.Usr.user_id);
            ViewBag.TreeJson = HCQ2_Common.JsonHelper.ObjectToJson(list).ToString();
            return View();
        }

        /// <summary>
        /// 工资发放明细
        /// </summary>
        /// <param name="form"></param>
        /// <returns></returns>
        public ActionResult GetWageDetail(FormCollection form)
        {
            var data = GetWorkView(form);
            return Json(GetReturnJson(form, data), JsonRequestBehavior.AllowGet);
        }

        #endregion

        #region 用工信息

        /// <summary>
        /// 用工信息
        /// </summary>
        /// <returns></returns>
        [HCQ2_Common.Attributes.Load]
        [HCQ2_Common.Attributes.Element]
        public ActionResult WorkInformation()
        {
            ViewBag.title = "用工信息";
            List<HCQ2_Model.TreeModel.B01PerTreeModel> list = operateContext.bllSession.B01.GetB01PerData(operateContext.Usr.user_id);
            ViewBag.TreeJson = HCQ2_Common.JsonHelper.ObjectToJson(list).ToString();
            return View();
        }

        /// <summary>
        /// 用工信息数据获取
        /// </summary>
        /// <param name="form"></param>
        /// <returns></returns>
        public ActionResult GetWorkInfor(FormCollection form)
        {
            int page = int.Parse(form["page"]);
            int rows = int.Parse(form["rows"]);
            var data = GetWorkView(form);
            if (!string.IsNullOrEmpty(form["txtSearchDate"]))
            {
                data = data.Select("WGJG0202 = '" + form["txtSearchDate"].Trim() + "'").CopyToDataTable();
            }
            else
            {
                data = data.Select("WGJG0202 = '1990-1-1'").CopyToDataTable();
            }
            return Json(GetReturnJson(form, data), JsonRequestBehavior.AllowGet);
        }

        #endregion

        #region 薪资发放信息

        /// <summary>
        /// 薪资发放信息
        /// </summary>
        /// <returns></returns>
        [HCQ2_Common.Attributes.Load]
        [HCQ2_Common.Attributes.Element]
        public ActionResult PayWorkMoney()
        {
            ViewBag.title = "薪级发放信息";
            List<HCQ2_Model.TreeModel.B01PerTreeModel> list = operateContext.bllSession.B01.GetB01PerData(operateContext.Usr.user_id);
            ViewBag.TreeJson = HCQ2_Common.JsonHelper.ObjectToJson(list).ToString();
            return View();
        }

        /// <summary>
        /// 薪资发放信息数据源获取
        /// </summary>
        /// <param name="form"></param>
        /// <returns></returns>
        public ActionResult GetPayMoney(FormCollection form)
        {
            int page = int.Parse(form["page"]);
            int rows = int.Parse(form["rows"]);
            var data = GetWorkView(form);
            if (!string.IsNullOrEmpty(form["txtSearchDate"]))
            {
                data = data.Select("WGJG0202 = '" + form["txtSearchDate"].Trim() + "'").CopyToDataTable();
            }
            else
            {
                data = data.Select("WGJG0202 = '1990-1-1'").CopyToDataTable();
            }
            return Json(GetReturnJson(form, data), JsonRequestBehavior.AllowGet);
        }

        #endregion

        /// <summary>
        /// 获取数据查询公共方法
        /// </summary>
        /// <param name="form"></param>
        /// <returns></returns>
        private DataTable GetWorkView(FormCollection form)
        {
            bll = operateContext.bllSession;
            DataTable dt = bll.WGJG02.GetWGJG02DataTable();
            if (!string.IsNullOrEmpty(form["UnitID"]))
            {
                dt = dt.Select("UnitID='" + form["UnitID"].Trim() + "'").CopyToDataTable();
            }
            else
            {
                dt = dt.Select("UnitID='" + operateContext.bllSession.B01.GetB01PerData(operateContext.Usr.user_id)[0].UnitID + "'").CopyToDataTable();
            }
            if (!string.IsNullOrEmpty(form["txtSearchName"]))
            {
                dt = dt.Select("UnitID like '%" + form["txtSearchName"].Trim() + "%'").CopyToDataTable();
            }
            return dt;
        }

        /// <summary>
        /// 分页于返回json数据判断
        /// </summary>
        /// <param name="form"></param>
        /// <param name="totalData"></param>
        /// <returns></returns>
        private TableModel GetReturnJson(FormCollection form, DataTable totalData)
        {
            string returnJson = string.Empty;
            int page = int.Parse(form["page"]);
            int rows = int.Parse(form["rows"]);

            TableModel model = new TableModel();
            if (totalData.Rows.Count > 0)
            {
                List<WorkInformationModel> workList = HCQ2_Common.Data.DataTableHelper.DataTableToIList<WorkInformationModel>(totalData);
                model.rows = workList.Skip((page * rows) - rows).Take(rows);
                model.total = workList.Count();
            }
            return model;
        }
    }
}
