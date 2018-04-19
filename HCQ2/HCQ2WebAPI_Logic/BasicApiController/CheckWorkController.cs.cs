using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using HCQ2_Common.Constant;
using HCQ2_Model.WebApiModel.ParamModel;
using System.Data;
using HCQ2WebAPI_Logic.BaseAPIController;

namespace HCQ2WebAPI_Logic.BasicApiController
{
    public class CheckWorkController : BaseWeiXinApiLogic
    {

        /// <summary>
        /// 用工查询
        /// </summary>
        /// <param name="work"></param>
        /// <returns></returns>
        [HttpPost]
        public object GetUnitNameWorkPerson(CheckUseWorker work)
        {
            if (!ModelState.IsValid)
                return operateContext.RedirectWebApi(WebResultCode.Exception, GlobalConstant.参数异常.ToString(), null);

            var data = operateContext.bllSession.B01.GetB01Info().Where(o => o.UnitName == work.unitName);
            if (data.Count() > 0)
            {
                string unit_code = data.FirstOrDefault().UnitID;
                var Card = operateContext.bllSession.View_A02.GetApiWorkTime(work);
                return operateContext.RedirectWebApi(WebResultCode.Ok, GlobalConstant.操作成功.ToString(), Card);
            }
            else {
                return operateContext.RedirectWebApi(WebResultCode.Ok, GlobalConstant.操作成功.ToString(), null);
            }
        }
    }
}
