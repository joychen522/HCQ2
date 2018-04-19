using System.Collections.Generic;
using HCQ2WebAPI_Logic.BaseAPIController;
using HCQ2_Common.Constant;
using HCQ2_Model.APPModel.ParamModel;
using HCQ2_Model.APPModel.ResultApiModel;
using System.Web.Http;

namespace HCQ2WebAPI_Logic.APPController
{
    /// <summary>
    ///  统计图表数据控制器
    /// </summary>
    public class ChartDateController: BaseWeiXinApiLogic
    {
        #region 1.0 出工打卡趋势 + object GetPunchCardData(DebtChartMoneyModel model)
        /// <summary>
        ///  1.0 出工打卡趋势
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public object GetPunchCardData(DebtChartMoneyModel model)
        {
            if (!ModelState.IsValid)
                return operateContext.RedirectWebApi(WebResultCode.Exception, GlobalConstant.参数异常.ToString(), false);
            var data = operateContext.bllSession.A02.GetPunchCardData(model);
            return operateContext.RedirectWebApi(WebResultCode.Ok, GlobalConstant.操作成功.ToString(), data);
        }
        #endregion

        #region  1.1 欠薪金额趋势 + object GetDebtAllMoney(DebtChartByYearModel model)
        /// <summary>
        ///  1.1 欠薪金额趋势
        ///  注意后台需要根据userid获取用户分配的范围数据，如没有分配则查询用户所在项目数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public object GetDebtAllMoney(DebtChartByYearModel model)
        {
            if (!ModelState.IsValid)
                return operateContext.RedirectWebApi(WebResultCode.Exception, GlobalConstant.参数异常.ToString(), false);
            List<DebtMoneyModel> uModel = operateContext.bllSession.WGJG02.GetPayMoneyByDate(model);
            if(null==uModel || uModel.Count<=0)
                return operateContext.RedirectWebApi(WebResultCode.Ok, GlobalConstant.数据为空.ToString(), null);
            return operateContext.RedirectWebApi(WebResultCode.Ok, GlobalConstant.操作成功.ToString(), uModel);
        }
        #endregion

        #region 1.2 欠薪人数趋势 + object GetDebtPersons(DebtChartByYearModel model)
        /// <summary>
        ///  1.2  欠薪人数趋势
        ///  注意后台需要根据userid获取用户分配的范围数据，如没有分配则查询用户所在项目数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public object GetDebtPersons(DebtChartByYearModel model)
        {
            if (!ModelState.IsValid)
                return operateContext.RedirectWebApi(WebResultCode.Exception, GlobalConstant.参数异常.ToString(), false);
            List<DebtPersonsModel> uModel = operateContext.bllSession.WGJG02.GetPayCountPerson(model);
            if (null == uModel || uModel.Count <= 0)
                return operateContext.RedirectWebApi(WebResultCode.Ok, GlobalConstant.数据为空.ToString(), null);
            return operateContext.RedirectWebApi(WebResultCode.Ok, GlobalConstant.操作成功.ToString(), uModel);
        }
        #endregion

        #region 1.3 获取项目增长趋势+object GetProjectTrend(DebtAllGrantModel model) 
        /// <summary>
        ///  获取项目增长趋势
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public object GetProjectTrend(DebtAllGrantModel model)
        {
            if (!ModelState.IsValid)
                return operateContext.RedirectWebApi(WebResultCode.Exception, GlobalConstant.参数异常.ToString(), false);
            List<ChartProject> uMonth = operateContext.bllSession.B01.GetProjectMonthGrow(model);
            List<ChartProject> uEndMonth = operateContext.bllSession.B01.GetProjectAllGrow(model);
            Dictionary<string, List<ChartProject>> obj = new Dictionary<string, List<ChartProject>>();
            obj.Add("monthGrow", uMonth);//月项目增长数
            obj.Add("allGrow", uEndMonth);//总项目增长数
            if (uMonth == null || uEndMonth == null)
                return operateContext.RedirectWebApi(WebResultCode.Ok, GlobalConstant.数据为空.ToString(), obj);
            return operateContext.RedirectWebApi(WebResultCode.Ok, GlobalConstant.数据获取成功.ToString(), obj);
        }
        #endregion

        #region 1.4 获取人员增长趋势数据 + object GetPersonTrend(DebtAllGrantModel model)
        /// <summary>
        ///  获取人员增长趋势数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public object GetPersonTrend(DebtAllGrantModel model)
        {
            if (!ModelState.IsValid)
                return operateContext.RedirectWebApi(WebResultCode.Exception, GlobalConstant.参数异常.ToString(), false);
            List<ChartPerson> uMonth = operateContext.bllSession.A01.GetPersonMonthGrow(model);
            List<ChartPerson> uEndMonth = operateContext.bllSession.A01.GetPersonAllGrow(model);
            Dictionary<string, List<ChartPerson>> obj = new Dictionary<string, List<ChartPerson>>();
            obj.Add("monthGrow", uMonth);//月人员增长数
            obj.Add("allGrow", uEndMonth);//总人员增长数
            if (uMonth == null || uEndMonth == null)
                return operateContext.RedirectWebApi(WebResultCode.Ok, GlobalConstant.数据为空.ToString(), obj);
            return operateContext.RedirectWebApi(WebResultCode.Ok, GlobalConstant.数据获取成功.ToString(), obj);
        } 
        #endregion
    }
}
