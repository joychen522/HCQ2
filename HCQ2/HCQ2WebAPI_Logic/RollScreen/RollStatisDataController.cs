using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HCQ2WebAPI_Logic.BaseAPIController;
using System.Web.Http;
using HCQ2_Common.Constant;
using HCQ2_Model.RollScreenModel;

namespace HCQ2WebAPI_Logic.RollScreen
{
    public class RollStatisDataController : BaseWeiXinApiLogic
    {

        /// <summary>
        /// 获取工种的滚屏数量
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public object GetRollScreenWorkList(Roll roll)
        {
            if (!ModelState.IsValid)
                return operateContext.RedirectWebApi(WebResultCode.Exception, GlobalConstant.参数异常.ToString(), null);

            var data = operateContext.bllSession.A01.GetWorkerJobsRollSrcen(roll);
            return operateContext.RedirectWebApi(WebResultCode.Ok, GlobalConstant.操作成功.ToString(), data);
        }
    }
}
