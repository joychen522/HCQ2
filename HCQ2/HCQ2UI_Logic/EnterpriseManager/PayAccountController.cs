using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using HCQ2_Model.ViewModel;

namespace HCQ2UI_Logic
{
    public class PayAccountController : BaseLogic
    {
        /// <summary>
        /// 工资专户
        /// </summary>
        /// <returns></returns>
        [HCQ2_Common.Attributes.Load]
        public ActionResult Index()
        {
            ViewBag.ssyh = operateContext.bllSession.T_ItemCodeMenum.GetByItemId(
                operateContext.bllSession.T_ItemCode.GetByItemCode("ssyh").item_id);
            ViewBag.ssyhJson = HCQ2_Common.JsonHelper.objectToJsonStr(ViewBag.ssyh);
            ViewBag.project = operateContext.bllSession.B01.GetPerUnitByUserID(
                operateContext.Usr.user_id).Where(o => o.UnitID.Length == 3).ToList();
            return View();
        }

        /// <summary>
        /// 工资专户显示数据源
        /// </summary>
        /// <param name="form"></param>
        /// <returns></returns>
        public ActionResult GetPaySoure(FormCollection form)
        {
            TableModel model = operateContext.bllSession.T_PayAccount.GetPageViewSoure(form);
            return Json(model, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 保存专户信息
        /// </summary>
        /// <param name="form"></param>
        /// <returns></returns>
        public ActionResult SavePayAccount(FormCollection form)
        {
            string str = operateContext.bllSession.T_PayAccount.SavePayAccount(form) ? "ok" : "fin";
            return Content(str);
        }

        /// <summary>
        /// 删除专户信息
        /// </summary>
        /// <param name="pay_id"></param>
        /// <returns></returns>
        public ActionResult DeletePayAccount(int pay_id)
        {
            string str = operateContext.bllSession.T_PayAccount.DeletePayAccount(pay_id) ? "ok" : "fin";
            return Content(str);
        }
    }
}
