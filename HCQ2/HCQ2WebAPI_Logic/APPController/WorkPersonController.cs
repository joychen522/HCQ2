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
    public class WorkPersonController: BaseWeiXinApiLogic
    {
        /// <summary>
        /// 维权凭证
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public object GetWorkPersonDetail(HCQ2_Model.AppModel.WorkPersonDetail person)
        {
            if (!ModelState.IsValid)
                return operateContext.RedirectWebApi(WebResultCode.Exception, GlobalConstant.参数异常.ToString(), null);
            var data = operateContext.bllSession.A01.GetWorkPersonDetail(person);
            return operateContext.RedirectWebApi(WebResultCode.Ok, GlobalConstant.操作成功.ToString(), data);
        }

        /// <summary>
        /// 人员所在项目列表
        /// </summary>
        /// <param name="person"></param>
        /// <returns></returns>
        [HttpPost]
        public object GetWorkPersonUnit(HCQ2_Model.AppModel.WorkPerson person)
        {
            if (!ModelState.IsValid)
                return operateContext.RedirectWebApi(WebResultCode.Exception, GlobalConstant.参数异常.ToString(), null);
            var data = operateContext.bllSession.A01.GetWorkPersonUnit(person);
            return operateContext.RedirectWebApi(WebResultCode.Ok, GlobalConstant.操作成功.ToString(), data);
        }
    }
}
