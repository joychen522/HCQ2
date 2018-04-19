using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using HCQ2_Model.WebApiModel.ParamModel;
using HCQ2_Model.APPModel.ResultApiModel;
using HCQ2_Model.APPModel.ParamModel;

namespace HCQ2_IDAL
{
    /// <summary>
    ///  工资发放详细数据层接口定义
    /// </summary>
    public partial interface IWGJG02DAL
    {
        /// <summary>
        ///  获取工资发放详细信息
        /// </summary>
        /// <param name="model">查询对象</param>
        /// <returns></returns>
        List<HCQ2_Model.ViewModel.WGJG02Model> GetWageDetailByRowId(HCQ2_Model.SelectModel.WGJG01ChartModel model);
        /// <summary>
        ///  根据单位id获取工资发放详细信息
        /// </summary>
        /// <param name="rowID">id</param>
        /// <param name="page">第几页</param>
        /// <param name="rows">每页数量</param>
        /// <returns></returns>
        List<HCQ2_Model.ViewModel.WGJG02Model> GetWageDetailByUnitID(HCQ2_Model.SelectModel.WGJG02ByUnitID model);
        /// <summary>
        ///  根据查询对象获取总记录条数
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        int CountPersonsByModel(HCQ2_Model.SelectModel.WGJG02ByUnitID model);
        /// <summary>
        ///  获取导出数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        DataTable GetExportData(HCQ2_Model.SelectModel.WGJG02ByUnitID model);
        /// <summary>
        ///  根据查询条件统计数量
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        int CountGrantPersons(HCQ2_Model.SelectModel.WGJG01ChartModel model);

        //****************************************WebAPI_Serveice********************************
        /// <summary>
        ///  设置当前对象确认工资
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        bool EditAffirmWageByPerson(WageRegisterModel model);
        /// <summary>
        ///  根据当前对象查询 对应项目是否全部确认
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        int GetWagePersonCount(WageRegisterModel model);
        /// <summary>
        ///  获取下发工资数据对象
        /// </summary>
        /// <param name="orgid"></param>
        /// <returns></returns>
        List<HCQ2_Model.WebApiModel.ResultApiModel.WageSentDownModel> GetWageSentDownByOrgId(string orgid);
        /// <summary>
        ///  获取第一个确认登记农民工对象
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        HCQ2_Model.WGJG02 GetFirstCheckInUser(WageRegisterModel model);
        /// <summary>
        ///  工资下发
        /// </summary>
        /// <param name="person"></param>
        /// <returns></returns>
        List<WageDetialResult> GetWageDetialByPerson(WageGrantParamModel person);
        /// <summary>
        ///  根据年份获取指定人员 一年的薪资发放情况
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        List<WorkMoneyResult> GetWageByYear(WorkAllList model);
        /// <summary>
        ///  获取个人拖欠薪资
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        List<WorkMoneyResult> GetTradyWageByYear(WorkAllList model);
        /// <summary>
        ///  获取总的发放金额
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        decimal GetAllGrantMoney(BaseAPI model);
        /// <summary>
        ///  获取总的欠薪金额
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        decimal GetAllPayMoney(BaseAPI model);
        /// <summary>
        ///  获取欠薪金额趋势数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        List<DebtMoneyModel> GetPayMoneyByDate(DebtChartByYearModel model);
        /// <summary>
        ///  获取欠薪人数趋势
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        List<DebtPersonsModel> GetPayCountPerson(DebtChartByYearModel model);
    }
}
