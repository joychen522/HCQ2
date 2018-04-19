using System.Collections.Generic;
using HCQ2_Model;
using HCQ2_Model.WeiXinApiModel.ParamModel;
using HCQ2_Model.APPModel.ResultApiModel;
using HCQ2_Model.APPModel.ParamModel;

namespace HCQ2_IDAL
{
    /// <summary>
    ///  欠薪统计
    /// </summary>
    public partial interface IView_QXTJDAL
    {
        /// <summary>
        ///  获取欠薪时间数据
        /// </summary>
        /// <returns></returns>
        List<HCQ2_Model.P_QianXin_ShiJian_Result> GetViewTimeData(string unitCode,int keyChild);
        /// <summary>
        ///  根据单位名称获取单位代码
        /// </summary>
        /// <param name="unitName"></param>
        /// <returns></returns>
        string GetUnitCodeByName(string unitName);

        /// <summary>
        /// 根据项目编号获取项目欠薪统计
        /// </summary>
        /// <param name="UnitID"></param>
        /// <returns></returns>
        System.Data.DataTable GetProjectQxtjByUnitID(string UnitID);

        //*********************************WebChat Service*************************************
        /// <summary>
        ///  根据单位/项目代码查询欠薪金额详细
        /// </summary>
        /// <param name="model">条件对象</param>
        /// <returns></returns>
        List<HCQ2_Model.WeiXinApiModel.ResultApiModel.DebtMoneyResultModel> GetDebtMoneyDetail(DebtMoneyPeopleModel model);
        /// <summary>
        ///  根据单位/项目代码查询欠薪人数详细信息
        /// </summary>
        /// <param name="model">条件对象</param>
        /// <returns></returns>
        List<HCQ2_Model.WeiXinApiModel.ResultApiModel.DebtPeopleResultModel> GetDebtPeopleDetail(DebtMoneyPeopleModel model);
        //*********************************APP Service*************************************
        /// <summary>
        ///  获取欠薪时间数据
        /// </summary>
        /// <param name="model"></param>
        /// <param name="user_id">用户id</param>
        /// <param name="orgid">权限单位</param>
        /// <returns></returns>
        List<DebtSelResultModel> GetDebtTime(DebtSelModel model,int user_id, List<string> orgid);
        /// <summary>
        ///  APP根据单位，时间条件查询欠薪数据汇总
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        List<DebtDataModel> GetDebtCountDataByOrg(DebtSelGrantModel model);
        /// <summary>
        ///  APP根据单位，查询时间获取欠薪图表月数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        List<DebtMoneyModel> GetDebtChartMonthDataByOrg(DebtSelGrantModel model);
        /// <summary>
        ///  APP根据单位，查询时间获取欠薪图表截止月数据汇总
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        List<DebtMoneyModel> GetDebtChartEndMonthDataByOrg(DebtSelGrantModel model);
    }
}
