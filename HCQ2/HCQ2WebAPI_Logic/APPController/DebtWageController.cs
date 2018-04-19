using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HCQ2WebAPI_Logic.BaseAPIController;
using HCQ2_Common.Constant;
using HCQ2_Model.APPModel.ParamModel;
using HCQ2_Model.APPModel.ResultApiModel;
using HCQ2_Model.WeiXinApiModel.ParamModel;
using System.Web.Http;

namespace HCQ2WebAPI_Logic.APPController
{
    /// <summary>
    ///  APP欠薪控制器
    /// </summary>
    public class DebtWageController: BaseWeiXinApiLogic
    {
        #region 1.0 获取欠薪时间数据 + object GetDebtTime(DebtSelModel model)
        /// <summary>
        ///  1.0 获取欠薪时间数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public object GetDebtTime(DebtSelModel model)
        {
            if (!ModelState.IsValid)
                return operateContext.RedirectWebApi(WebResultCode.Exception, GlobalConstant.参数异常.ToString(), false);
            List<DebtSelResultModel> uModel = operateContext.bllSession.View_QXTJ.GetDebtTime(model);
            if(null==uModel || uModel.Count<=0)
                return operateContext.RedirectWebApi(WebResultCode.Ok, GlobalConstant.数据为空.ToString(), "");
            return operateContext.RedirectWebApi(WebResultCode.Ok, GlobalConstant.数据获取成功.ToString(), uModel);
        }
        #endregion

        #region 1.1 根据项目名获取发放信息 + object GetGrantInfoByUnit(DebtSelGrantModel model)
        /// <summary>
        ///  1.1 根据项目名获取发放信息
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public object GetGrantInfoByUnit(DebtSelGrantModel model)
        {
            if (!ModelState.IsValid)
                return operateContext.RedirectWebApi(WebResultCode.Exception, GlobalConstant.参数异常.ToString(), false);
            List<DebtWGJG01Model> uModel = operateContext.bllSession.WGJG01.GetGrantInfoByUnit(model);
            if(null==uModel)
                return operateContext.RedirectWebApi(WebResultCode.Error, GlobalConstant.数据获取失败.ToString(),"");
            return operateContext.RedirectWebApi(WebResultCode.Ok, GlobalConstant.操作成功.ToString(), uModel);
        }
        #endregion

        #region 1.2 根据项目统计欠薪数据 + object GetDebtDataByUnit(DebtSelGrantModel model)
        /// <summary>
        ///  1.2 根据项目统计欠薪数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public object GetDebtDataByUnit(DebtSelGrantModel model)
        {
            if (!ModelState.IsValid)
                return operateContext.RedirectWebApi(WebResultCode.Exception, GlobalConstant.参数异常.ToString(), false);
            List<DebtDataModel> uModel = operateContext.bllSession.View_QXTJ.GetDebtCountDataByOrg(model);
            if(null==uModel || uModel.Count<=0)
                return operateContext.RedirectWebApi(WebResultCode.Error, GlobalConstant.数据获取失败.ToString(), "");
            return operateContext.RedirectWebApi(WebResultCode.Ok, GlobalConstant.操作成功.ToString(), uModel);
        }
        #endregion

        #region 1.3 根据单位，日期获取欠薪金额图表数据 + object GetDebtMonthMoney(DebtSelGrantModel model)
        /// <summary>
        ///  1.3 根据单位，日期获取欠薪金额图表数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public object GetDebtMonthMoney(DebtSelGrantModel model)
        {
            if (!ModelState.IsValid)
                return operateContext.RedirectWebApi(WebResultCode.Exception, GlobalConstant.参数异常.ToString(), false);
            List<DebtMoneyModel> uMonth = operateContext.bllSession.View_QXTJ.GetDebtChartMonthDataByOrg(model);
            List<DebtMoneyModel> uEndMonth = operateContext.bllSession.View_QXTJ.GetDebtChartEndMonthDataByOrg(model);
            Dictionary <string, List<DebtMoneyModel>> obj = new Dictionary<string, List<DebtMoneyModel>>();
            obj.Add("dtmonth", uMonth);//月欠薪金额
            obj.Add("allMoney", uEndMonth);//总欠薪金额
            if(uMonth==null || uEndMonth==null)
                return operateContext.RedirectWebApi(WebResultCode.Error, GlobalConstant.数据获取失败.ToString(), obj);
            return operateContext.RedirectWebApi(WebResultCode.Ok, GlobalConstant.数据获取成功.ToString(), obj);
        }
        #endregion
    }
}
