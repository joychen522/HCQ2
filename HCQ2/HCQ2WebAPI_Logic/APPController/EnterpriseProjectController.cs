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
    /// <summary>
    /// 企业项目
    /// </summary>
    public class EnterpriseProjectController : BaseWeiXinApiLogic
    {
        /// <summary>
        /// 获取企业项目
        /// </summary>
        /// <param name="compay"></param>
        /// <returns></returns>
        [HttpPost]
        public object GetEnterList(Compay compay)
        {
            if (!ModelState.IsValid)
                return operateContext.RedirectWebApi(WebResultCode.Exception, GlobalConstant.参数异常.ToString(), null);
            var data = operateContext.bllSession.B01.GetEnterList(compay);
            return operateContext.RedirectWebApi(WebResultCode.Ok, GlobalConstant.操作成功.ToString(), data);
        }

        /// <summary>
        /// 分页获取企业项目
        /// </summary>
        /// <param name="compay"></param>
        /// <returns></returns>
        [HttpPost]
        public object GetEnterRowPageList(CompayList compay)
        {
            if (!ModelState.IsValid)
                return operateContext.RedirectWebApi(WebResultCode.Exception, GlobalConstant.参数异常.ToString(), null);

            var data = operateContext.bllSession.B01.GetEnterRowPageList(compay);
            return operateContext.RedirectWebApi(WebResultCode.Ok, GlobalConstant.操作成功.ToString(), data);
        }

        /// <summary>
        /// 获取详细企业项目
        /// </summary>
        /// <param name="compay"></param>
        /// <returns></returns>
        [HttpPost]
        public object GetEnterProjectDetail(Compay compay)
        {
            if (string.IsNullOrEmpty(compay.unit_name))
                return operateContext.RedirectWebApi(WebResultCode.Exception, GlobalConstant.参数异常.ToString(), null);

            var data = operateContext.bllSession.B01.GetEnterProjectDetail(compay);
            return operateContext.RedirectWebApi(WebResultCode.Ok, GlobalConstant.操作成功.ToString(), data);
        }

        /// <summary>
        /// 获取项目人员明细
        /// </summary>
        /// <param name="compay"></param>
        /// <returns></returns>
        [HttpPost]
        public object GetEnterPersonList(CompayPersonDetail compay)
        {
            if (string.IsNullOrEmpty(compay.unit_name))
                return operateContext.RedirectWebApi(WebResultCode.Exception, GlobalConstant.参数异常.ToString(), null);

            var data = operateContext.bllSession.B01.GetEnterPersonList(compay);
            return operateContext.RedirectWebApi(WebResultCode.Ok, GlobalConstant.操作成功.ToString(), data);
        }
    }
}
