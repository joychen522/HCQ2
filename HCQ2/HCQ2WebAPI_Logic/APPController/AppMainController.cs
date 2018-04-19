using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HCQ2WebAPI_Logic.BaseAPIController;
using System.Web.Http;
using HCQ2_Common.Constant;
using HCQ2_Model.AppModel;

namespace HCQ2WebAPI_Logic.APPController
{
    public class AppMainController : BaseWeiXinApiLogic
    {

        /// <summary>
        /// 首页统计数字
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public object GetStatisNum(HCQ2_Model.AppModel.WorkPerson orgid)
        {
            var data = operateContext.bllSession.B01.GetStatisNum(orgid);
            return operateContext.RedirectWebApi(WebResultCode.Ok, GlobalConstant.操作成功.ToString(), data);
        }
    }
}
