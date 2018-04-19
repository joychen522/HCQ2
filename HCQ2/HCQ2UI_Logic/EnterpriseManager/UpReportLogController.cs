using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace HCQ2UI_Logic
{
    public class UpReportLogController : BaseLogic
    {

        [HCQ2_Common.Attributes.Load]
        public ActionResult Index()
        {
            ViewBag.Project = HCQ2_Common.JsonHelper.objectToJsonStr(operateContext.bllSession.B01.Select(o => o.UnitID.Length == 3));
            return View();
        }

        /// <summary>
        /// 获取上报日志数据源
        /// </summary>
        /// <param name="form"></param>
        /// <returns></returns>
        public ActionResult GetLogSoure(FormCollection form)
        {
            var data = operateContext.bllSession.BB_UpDataLog.GetPageModel(form);
            return Json(data, JsonRequestBehavior.AllowGet);
        }
    }
}
