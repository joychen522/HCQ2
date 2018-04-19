using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HCQ2WebAPI_Logic.BaseAPIController;
using System.Web.Http;
using HCQ2_Model.APPModel.ParamModel;
using HCQ2_Common.Constant;
using HCQ2_Model.APPModel.ResultApiModel;

namespace HCQ2WebAPI_Logic.APPController
{
    /// <summary>
    ///  务工人员控制器
    /// </summary>
    public class WorkerManagerController: BaseWeiXinApiLogic
    {
        #region 1.0 首页数字统计 + object GetIndexData()
        /// <summary>
        ///  1.0 首页数字统计
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public object GetIndexData(BaseAPI model)
        {
            if (!ModelState.IsValid)
                return operateContext.RedirectWebApi(WebResultCode.Exception, GlobalConstant.参数异常.ToString(), false);
            WorkIndexResult uModel = new WorkIndexResult();
            uModel.workMonth = operateContext.bllSession.View_A02.GetMonthByCard(model);
            uModel.workAll = operateContext.bllSession.View_A02.GetAllByCard(model);
            uModel.takeMoney = operateContext.bllSession.WGJG02.GetAllGrantMoney(model);
            uModel.payMoney = operateContext.bllSession.WGJG02.GetAllPayMoney(model);
            if (null == uModel)
                return operateContext.RedirectWebApi(WebResultCode.Ok, GlobalConstant.数据为空.ToString(), "");
            return operateContext.RedirectWebApi(WebResultCode.Ok, GlobalConstant.数据获取成功.ToString(), uModel);
        }
        #endregion

        #region 1.1 月出工详细列表 + object GetWorkMonthList()
        /// <summary>
        ///  1.1 月出工详细列表
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public object GetWorkMonthList(WorkMonthList model)
        {
            if (!ModelState.IsValid)
                return operateContext.RedirectWebApi(WebResultCode.Exception, GlobalConstant.参数异常.ToString(), false);
            List<WorkMonthResult> uResult = operateContext.bllSession.View_A02.GetMonthWorkData(model);
            if (null == uResult || uResult.Count <= 0)
                return operateContext.RedirectWebApi(WebResultCode.Ok, GlobalConstant.数据为空.ToString(), "");
            return operateContext.RedirectWebApi(WebResultCode.Ok, GlobalConstant.数据获取成功.ToString(), uResult);
        }
        #endregion

        #region 1.2 总出工详细列表 + object GetWorkAllList()
        /// <summary>
        ///  1.21 总出工详细列表
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public object GetWorkAllList(WorkAllList model)
        {
            if (!ModelState.IsValid)
                return operateContext.RedirectWebApi(WebResultCode.Exception, GlobalConstant.参数异常.ToString(), false);
            List<WorkAllResult> uResult = operateContext.bllSession.View_A02.GetAllWorkDays(model);
            if (null == uResult || uResult.Count <= 0)
                return operateContext.RedirectWebApi(WebResultCode.Ok, GlobalConstant.数据为空.ToString(), "");
            return operateContext.RedirectWebApi(WebResultCode.Ok, GlobalConstant.数据获取成功.ToString(), uResult);
        }
        #endregion

        #region 1.3 薪资发放列表 + object GetWorkMoneyList()
        /// <summary>
        ///  1.3 薪资发放列表
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public object GetWorkMoneyList(WorkAllList model)
        {
            if (!ModelState.IsValid)
                return operateContext.RedirectWebApi(WebResultCode.Exception, GlobalConstant.参数异常.ToString(), false);
            List<WorkMoneyResult> uResult = operateContext.bllSession.WGJG02.GetWageByYear(model);
            if (null == uResult || uResult.Count <= 0)
                return operateContext.RedirectWebApi(WebResultCode.Ok, GlobalConstant.数据为空.ToString(), "");
            return operateContext.RedirectWebApi(WebResultCode.Ok, GlobalConstant.数据获取成功.ToString(), uResult);
        }
        #endregion

        #region 1.4 拖欠薪资列表 + object GetBackWorkMoneyList()
        /// <summary>
        ///  1.4 拖欠薪资列表
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public object GetBackWorkMoneyList(WorkAllList model)
        {
            if (!ModelState.IsValid)
                return operateContext.RedirectWebApi(WebResultCode.Exception, GlobalConstant.参数异常.ToString(), false);
            List<WorkMoneyResult> uResult = operateContext.bllSession.WGJG02.GetTradyWageByYear(model);
            if (null == uResult || uResult.Count <= 0)
                return operateContext.RedirectWebApi(WebResultCode.Ok, GlobalConstant.数据为空.ToString(), "");
            return operateContext.RedirectWebApi(WebResultCode.Ok, GlobalConstant.数据获取成功.ToString(), uResult);
        }
        #endregion
    }
}
