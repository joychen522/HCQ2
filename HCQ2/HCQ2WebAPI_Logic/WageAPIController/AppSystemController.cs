using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Web.Http;
using HCQ2_Common.Constant;
using HCQ2_Model.WebApiModel.ParamModel;
using HCQ2WebAPI_Logic.BaseAPIController;

namespace HCQ2WebAPI_Logic.WageAPIController
{
    /// <summary>
    ///  App Service控制器
    /// </summary>
    public class AppSystemController:BaseWeiXinApiLogic
    {
        #region 1.0 App设备日志上传 + object LogUpload(AppLogModel log)
        /// <summary>
        ///  App设备日志上传
        /// </summary>
        /// <param name="log">日志对象</param>
        /// <returns></returns>
        [HttpPost]
        public object LogUpload(AppLogModel log)
        {
            if (!ModelState.IsValid)
                return operateContext.RedirectWebApi(WebResultCode.Exception, GlobalConstant.参数异常.ToString(), false);
            int mark = operateContext.bllSession.Project_LogApi.Add(log);
            if (mark > 0)
                return operateContext.RedirectWebApi(WebResultCode.Ok, GlobalConstant.操作成功.ToString(), true);
            return operateContext.RedirectWebApi(WebResultCode.Exception, GlobalConstant.操作异常.ToString(), false);
        }
        #endregion

        #region 1.1 同步时间 + object TimeSentDown()
        /// <summary>
        ///  同步时间
        ///  时间戳，年月日时分秒 yyyyMMddHHmmss
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public object TimeSentDown()
        {
            Dictionary<string, string> result = new Dictionary<string, string>();
            result.Add("value", DateTime.Now.ToString("yyyyMMddHHmmss"));
            return result;
            //dynamic obj =new ExpandoObject();
            //obj.match_nonce = "123";
            //string map = DateTime.Now.ToString("yyyyMMddHHmmss");
            //obj.match_timestamp = map;
            //obj.match_signature = Authority.AuthorityCheck.CreateMatchSignature(map, "123");
            //return obj;
        }
        #endregion

        #region 1.2 下发版本号 + object VersionSentDown()
        /// <summary>
        ///  下发版本号
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public object VersionSentDown()
        {
            Dictionary<string, string> result = new Dictionary<string, string>();
            result.Add("value", "http://" + request.Url.Authority + request.ApplicationPath + "/Resources/check.txt");
            return result;
        }
        #endregion

        #region 1.3 下发APK + object APKSentDown()
        /// <summary>
        ///  下发APK
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public object APKSentDown()
        {
            Dictionary<string, string> result = new Dictionary<string, string>();
            result.Add("value", "http://" + request.Url.Authority + request.ApplicationPath + "/Resources/wgjg.apk");
            return result;
        } 
        #endregion
    }
}
