using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HCQ2WebAPI_Logic.BaseAPIController;
using HCQ2_Common.Constant;
using HCQ2_Model.WeiXinApiModel.ParamModel;
using HCQ2_Model.WeiXinApiModel.ResultApiModel;

namespace HCQ2WebAPI_Logic.WeiXinController
{
    /// <summary>
    ///  欠薪金额，人数查询控制器
    /// </summary>
    public class DebtMoneyController:BaseWeiXinApiLogic
    {
        #region 1.0 查询欠薪项目 + object SelDebtQXTJ(DebtQXTJModel model)
        /// <summary>
        ///  1.0 查询欠薪项目
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public object SelDebtQXTJ(DebtQXTJModel model)
        {
            if (!ModelState.IsValid)
                return operateContext.RedirectWebApi(WebResultCode.Exception, GlobalConstant.参数异常.ToString(), false);
            List<DebtQXTJResultModel> list = operateContext.bllSession.View_QXTJ.GetViewDataByName(model);
            if(null==list)
                return operateContext.RedirectWebApi(WebResultCode.Exception, GlobalConstant.操作异常.ToString(), false);
            return operateContext.RedirectWebApi(WebResultCode.Ok, GlobalConstant.操作成功.ToString(), list);
        }
        #endregion

        #region 1.1 查询欠薪金额 + object SelDebtMoney(DebtMoneyPeopleModel model)
        /// <summary>
        ///  1.1 查询欠薪金额
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public object SelDebtMoney(DebtMoneyPeopleModel model)
        {
            if (!ModelState.IsValid)
                return operateContext.RedirectWebApi(WebResultCode.Exception, GlobalConstant.参数异常.ToString(), false);
            List<DebtMoneyResultModel> list = operateContext.bllSession.View_QXTJ.GetDebtMoneyDetail(model);
            if(null==list)
                return operateContext.RedirectWebApi(WebResultCode.Exception, GlobalConstant.操作异常.ToString(), false);
            return operateContext.RedirectWebApi(WebResultCode.Ok, GlobalConstant.操作成功.ToString(), list);
        }
        #endregion

        #region 1.2 查询欠薪人数 + object SelDebtPeople(DebtMoneyPeopleModel model)
        /// <summary>
        ///  1.2 查询欠薪人数
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public object SelDebtPeople(DebtMoneyPeopleModel model)
        {
            if (!ModelState.IsValid)
                return operateContext.RedirectWebApi(WebResultCode.Exception, GlobalConstant.参数异常.ToString(), false);
            List<DebtPeopleResultModel> list = operateContext.bllSession.View_QXTJ.GetDebtPeopleDetail(model);
            if (null == list)
                return operateContext.RedirectWebApi(WebResultCode.Exception, GlobalConstant.操作异常.ToString(), false);
            return operateContext.RedirectWebApi(WebResultCode.Ok, GlobalConstant.操作成功.ToString(), list);
        } 
        #endregion
    }
}
