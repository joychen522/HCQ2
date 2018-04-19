using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HCQ2_Model.ViewModel;
using System.Data;
using HCQ2_Model;
using HCQ2_Model.WeiXinApiModel.ParamModel;
using HCQ2_Model.APPModel.ResultApiModel;
using HCQ2_Model.APPModel.ParamModel;

namespace HCQ2_IBLL
{
    /// <summary>
    ///  欠薪统计：业务层
    /// </summary>
    public partial interface IView_QXTJBLL
    {
        /// <summary>
        ///  获取欠薪ViewModel数据
        ///  统计欠薪金额前7条记录
        /// </summary>
        /// <returns></returns>
        EchartsVo GetDebtData();
        /// <summary>
        ///  统计前期金额
        ///  根据用户选择单位统计
        /// </summary>
        /// <param name="unit">选中单位</param>
        /// <returns></returns>
        EchartsVo GetDebtMoneyData(string unit);
        /// <summary>
        ///  获取欠薪时间ViewModel数据
        /// </summary>
        /// <returns></returns>
        EchartsVo GetDebtTimeData(string unitCode,int keyChild);
        /// <summary>
        ///  获取欠薪人数ViewModel数据
        /// </summary>
        /// <returns></returns>
        EchartsVo GetDebtPerson();
        /// <summary>
        ///  根据单位名称获取单位代码
        /// </summary>
        /// <param name="unitName"></param>
        /// <returns></returns>
        string GetUnitCodeByUnitName(string unitName);

        /// <summary>
        /// 获取欠薪金额、欠薪人数
        /// </summary>
        /// <returns></returns>
        DataTable GetStaticWagePerson(int user_id);
        /// <summary>
        /// 获取详细的欠薪金额和欠薪人数
        /// </summary>
        /// <returns></returns>
        List<View_QXTJ> GetMainWagePerson(int user_id);
        /// <summary>
        ///  根据权限获取前7条欠薪金额数据
        /// </summary>
        /// <param name="task">获取前几条数据 默认top 7</param>
        /// <returns></returns>
        List<View_QXTJ> GetDebtUnitDataByPermissTopSeven(int task = 7);
        /// <summary>
        ///  根据权限获取前7条欠薪人数数据
        /// </summary>
        /// <param name="task">获取前几条数据 默认top 7</param>
        /// <returns></returns>
        List<View_QXTJ> GetDebtPersonByPermissTopSeren(int task = 7);

        //*********************************WebChar Service BLL*************************************
        /// <summary>
        ///  根据名称查询欠薪数据
        /// </summary>
        /// <param name="model">条件对象</param>
        /// <returns></returns>
        List<HCQ2_Model.WeiXinApiModel.ResultApiModel.DebtQXTJResultModel> GetViewDataByName(DebtQXTJModel model);
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
        //*********************************APP Service BLL*************************************
        /// <summary>
        ///  APP获取欠薪时间数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        List<DebtSelResultModel> GetDebtTime(DebtSelModel model);
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
