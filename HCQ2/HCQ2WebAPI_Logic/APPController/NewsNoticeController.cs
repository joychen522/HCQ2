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
    public class NewsNoticeController : BaseWeiXinApiLogic
    {
        /// <summary>
        /// 分页获取新闻通知
        /// </summary>
        /// <param name="notice"></param>
        /// <returns></returns>
        [HttpPost]
        public object GetPageRowNewsNoticeList(NoticeModel notice)
        {
            if (!ModelState.IsValid)
                return operateContext.RedirectWebApi(WebResultCode.Exception, GlobalConstant.参数异常.ToString(), null);
            var data = operateContext.bllSession.T_MessageNotice.GetPageRowList(notice,request.ApplicationPath.ToString());
            return operateContext.RedirectWebApi(WebResultCode.Ok, GlobalConstant.操作成功.ToString(), data);
        }

        /// <summary>
        /// 分页获取新闻通知
        /// </summary>
        /// <param name="notice"></param>
        /// <returns></returns>
        [HttpPost]
        public object GetNoticeSimplifyList(NoticeModel notice)
        {
            if (!ModelState.IsValid)
                return operateContext.RedirectWebApi(WebResultCode.Exception, GlobalConstant.参数异常.ToString(), null);
            var data = operateContext.bllSession.T_MessageNotice.GetNoticeByType(notice, request.ApplicationPath.ToString());
            return operateContext.RedirectWebApi(WebResultCode.Ok, GlobalConstant.操作成功.ToString(), data);
        }
    }
}
