using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HCQ2WebAPI_Logic.BaseAPIController;
using System.Web.Http;
using HCQ2_Common.Constant;
using HCQ2_Model.AppModel;
using HCQ2_Model.APPModel.ParamModel;
using HCQ2_Model.APPModel.ResultApiModel;

namespace HCQ2WebAPI_Logic.APPController
{
    public class SystemSetController : BaseWeiXinApiLogic
    {
        /// <summary>
        /// 下发版本号
        /// </summary>
        /// <param name="person"></param>
        /// <returns></returns>
        [HttpPost]
        public object GetSoftVersion(Person person)
        {
            var data = "http://58.16.28.2:8885/liuyuntaiAPP/check.txt";
            return operateContext.RedirectWebApi(WebResultCode.Ok, GlobalConstant.操作成功.ToString(), data);
        }

        /// <summary>
        /// 下发安装包
        /// </summary>
        /// <param name="person"></param>
        /// <returns></returns>
        [HttpPost]
        public object GetSoftInstallation(Person person)
        {
            var data = "http://58.16.28.2:8885/liuyuntaiAPP/liuyuntaiAndroid.apk";
            return operateContext.RedirectWebApi(WebResultCode.Ok, GlobalConstant.操作成功.ToString(), data);
        }
    }
}
