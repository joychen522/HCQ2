using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using HCQ2_Model;
using HCQ2_Model.ViewModel;

namespace HCQ2UI_Logic.EnterpriseManager
{
    public class ImplementController : BaseLogic
    {
        [HCQ2_Common.Attributes.Element]
        [HCQ2_Common.Attributes.Load]
        public ActionResult Index()
        {
            List<HCQ2_Model.TreeModel.B01PerTreeModel> list = operateContext.bllSession.B01.GetB01PerData(operateContext.Usr.user_id);
            ViewBag.TreeJson = HCQ2_Common.JsonHelper.ObjectToJson(list).ToString();
            var item_code = operateContext.bllSession.T_ItemCode.GetByItemCode("ImplementStatus");
            ViewBag.ImplementStatus = operateContext.bllSession.T_ItemCodeMenum.GetByItemId(item_code.item_id);
            return View("");
        }

        /// <summary>
        /// 获取实施记录信息
        /// </summary>
        /// <param name="form"></param>
        /// <returns></returns>
        public ActionResult GetSoure(FormCollection form)
        {
            List<T_Implement> implementList = operateContext.bllSession.T_Implement.GetImplement();
            int page = int.Parse(form["page"]);
            int rows = int.Parse(form["rows"]);
            if (!string.IsNullOrEmpty(form["txtSearchName"]))
            {
                string searchName = form["txtSearchName"];
                implementList = implementList.Where(o => o.B000201.Contains(searchName)).ToList();
            }
            var data = implementList.Skip((page * rows) - rows).Take(rows);
            TableModel modle = new TableModel()
            {
                total = implementList.Count(),
                rows = data
            };
            return Json(modle, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 保存实施记录
        /// </summary>
        /// <param name="form"></param>
        /// <returns></returns>
        public ActionResult SaveImplement(FormCollection form)
        {
            bool isAccess = operateContext.bllSession.T_Implement.SaveImplement(form);
            HCQ2_Model.JsonData.JsonModel modle = new HCQ2_Model.JsonData.JsonModel()
            {
                Statu = isAccess ? 1 : 0,
                Msg = isAccess ? "保存成功" : "保存失败"
            };
            return Json(modle, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 删除实施记录
        /// </summary>
        /// <param name="implement_id"></param>
        /// <returns></returns>
        public ActionResult DeleteImplement(int implement_id)
        {
            string accessStr = operateContext.bllSession.T_Implement.Delete(o => o.imp_id == implement_id)
                > 0 ? "ok" : "find";
            return Content(accessStr);
        }
    }
}
