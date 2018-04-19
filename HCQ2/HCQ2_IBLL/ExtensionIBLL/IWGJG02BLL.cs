using HCQ2_Model.APPModel.ParamModel;
using HCQ2_Model.APPModel.ResultApiModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HCQ2_IBLL
{
    /// <summary>
    ///  工资发放详细信息业务接口层
    /// </summary>
    public partial interface IWGJG02BLL
    {
        /// <summary>
        ///  获取工资发放详细信息
        /// </summary>
        /// <param name="model">查询对象</param>
        /// <returns></returns>
        List<HCQ2_Model.ViewModel.WGJG02Model> GetWageDetailByRowId(HCQ2_Model.SelectModel.WGJG01ChartModel model);
        /// <summary>
        ///  根据单位ID获取工资发放详细信息
        /// </summary>
        /// <param name="model">查询对象</param>
        /// <returns></returns>
        List<HCQ2_Model.ViewModel.WGJG02Model> GetWageDetailByUnitID(HCQ2_Model.SelectModel.WGJG02ByUnitID model);
        /// <summary>
        ///  根据条件获取记录条数
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        int CountPersonsByModel(HCQ2_Model.SelectModel.WGJG02ByUnitID model);
        /// <summary>
        ///  导出Excel
        /// </summary>
        /// <param name="model"></param>
        void ExportToExcel(HCQ2_Model.SelectModel.WGJG02ByUnitID model);
        /// <summary>
        ///  根据查询条件统计数量
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        int CountGrantPersons(HCQ2_Model.SelectModel.WGJG01ChartModel model);

        //***************************************WebAPI服务*****************************************
        /// <summary>
        ///  工人确认打卡
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        string EditAffirmWageByPerson(HCQ2_Model.WebApiModel.ParamModel.WageRegisterModel model);
        /// <summary>
        ///  获取工资下发数据
        /// </summary>
        /// <param name="orgid">组织机构代码证</param>
        /// <returns></returns>
        List<HCQ2_Model.WebApiModel.ResultApiModel.WageSentDownModel> GetWageSentDownByOrgId(string orgid);
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
        ///  获取欠薪人数趋势
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        List<DebtPersonsModel> GetPayCountPerson(DebtChartByYearModel model);
    }
}
