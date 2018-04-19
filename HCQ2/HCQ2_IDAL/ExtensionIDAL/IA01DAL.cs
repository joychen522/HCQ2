using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HCQ2_Model;
using System.Data;

namespace HCQ2_IDAL
{
    public partial interface IA01DAL
    {
        /// <summary>
        ///  根据单位ID获取单位信息集合
        /// </summary>
        /// <param name="unitID"></param>
        /// <returns></returns>
        List<HCQ2_Model.SelectModel.ListBoxModel> GetPersonByB0002(string unitID);

        /// <summary>
        ///  根据需要的人员查询A01
        /// </summary>
        /// <param name="pserons"></param>
        /// <returns></returns>
        List<HCQ2_Model.A01> GetPeronsBySel(List<string> pserons, string UnitID);

        /// <summary>
        ///  获取人员月增长
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        List<HCQ2_Model.APPModel.ResultApiModel.ChartPerson> GetPersonMonthGrow(HCQ2_Model.APPModel.ParamModel.DebtAllGrantModel model);
        
        /// <summary>
        ///  获取人员总增长
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        List<HCQ2_Model.APPModel.ResultApiModel.ChartPerson> GetPersonAllGrow(HCQ2_Model.APPModel.ParamModel.DebtAllGrantModel model);

        #region    信息获取

        /// <summary>
        /// 根据RowID获取人员信息
        /// </summary>
        /// <param name="RowID"></param>
        /// <returns></returns>
        DataTable GetA01ByRowID(string RowID);

        /// <summary>
        /// 根据单位编号获取人员信息
        /// </summary>
        /// <param name="UnitID"></param>
        /// <returns></returns>
        DataTable GetA01ByUnitID(string UnitID);

        /// <summary>
        /// 根据单位编号获取人员信息（替换字典）
        /// </summary>
        /// <param name="UnitID"></param>
        /// <returns></returns>
        DataTable GetPersonByUnitID(string UnitID);

        /// <summary>
        /// 获取当前系统所有人员
        /// </summary>
        /// <returns></returns>
        int GetTotalPersonCount();

        /// <summary>
        /// 根据用户ID获取当前系统所有人员
        /// </summary>
        /// <param name="user_id"></param>
        /// <returns></returns>
        int GetTotalPersonCountByUser(string strUnit);

        /// <summary>
        /// 根据项目编号集合获取工种
        /// </summary>
        /// <param name="strUnit"></param>
        /// <returns></returns>
        DataTable GetWorkJobsByUnitInfo(string strUnit);

        /// <summary>
        /// 根据项目编号集合获取工种、姓名集合
        /// </summary>
        /// <param name="strUnit"></param>
        /// <returns></returns>
        DataTable GetWorkJobsByUnit(string strUnit);

        /// <summary>
        /// 根据PersonID集合获取人员
        /// </summary>
        /// <param name="strPersonID"></param>
        /// <returns></returns>
        DataTable GetPersonByStrPersonID(string UnitID, string strPersonID);

        /// <summary>
        /// 根据年龄段统计人员数量
        /// </summary>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <returns></returns>
        int GetPersonCountByAge(int start, int end);

        /// <summary>
        /// 获取已经使用的工种的集合
        /// </summary>
        /// <param name="strUnit"></param>
        /// <returns></returns>
        DataTable GetUserWork(string strUnit);

        /// <summary>
        /// 根据项目编号获取姓名和工种
        /// </summary>
        /// <param name="strUnit"></param>
        /// <returns></returns>
        DataTable GetPersonWorkByUnit(string strUnit);

        /// <summary>
        /// 获取数据展示的项目信息
        /// </summary>
        /// <returns></returns>
        DataTable GetRollViewModel();

        /// <summary>
        /// 根据年月获取采集数量
        /// </summary>
        /// <param name="year"></param>
        /// <param name="month"></param>
        /// <returns></returns>
        int GetSaveByYearMonth(int year, int month);

        #endregion
    }
}
