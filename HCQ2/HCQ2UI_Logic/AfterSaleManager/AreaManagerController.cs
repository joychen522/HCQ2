using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace HCQ2UI_Logic.AfterSaleManager
{
    public class AreaManagerController:BaseLogic
    {
        /// <summary>
        ///  根据权限 获取区域结构树
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult GetAreaData()
        {
            return operateContext.RedirectAjax(0, "成功", operateContext.bllSession.T_User.GetB01Data(operateContext.Usr.user_id), "");
        }
    }
}
