using HCQ2_Model.AppModel;
using HCQ2_Model.APPModel.ParamModel;
using HCQ2_Model.APPModel.ResultApiModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HCQ2_Model;

namespace HCQ2_IDAL
{
    public partial interface IView_A02DAL
    {
        /// <summary>
        ///  获取已出工情况 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        List<string> GetWorkPersonList(WorkCount model);
        /// <summary>
        ///  获取已出工人数
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        int GetWorkPersonCount(WorkCount model);
        /// <summary>
        ///  获取未出工情况
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        List<string> GetonWorkPersonList(WorkCount model);
        /// <summary>
        ///  获取未出工人数
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        int GetonWorkPersonCount(WorkCount model);
        /// <summary>
        ///  根据工种统计出工情况
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        List<WorkTypeCount> GetToWorkByType(WorkCount model);

        /// <summary>
        /// 获取某一个项目的出工情况
        /// </summary>
        /// <param name="UnitID"></param>
        /// <param name="CheckDate"></param>
        /// <returns></returns>
        System.Data.DataTable GetWorkByUnitData(string UnitID, string year, string month, string day);

        /// <summary>
        /// 获取某一个项目某一天的出工人数
        /// </summary>
        /// <param name="UnitID"></param>
        /// <param name="year"></param>
        /// <param name="month"></param>
        /// <param name="day"></param>
        /// <returns></returns>
        int GetWorkCountByUnitID(string UnitID, string year, string month, string day);

        /// <summary>
        /// 根据项目编号获取上报异常的数据
        /// </summary>
        /// <param name="strUnit"></param>
        /// <returns></returns>
        List<View_A02> GetAttendsByUnit(string strUnit);

        /// <summary>
        /// 根据RowID的集合获取数据源
        /// </summary>
        /// <param name="strRowID"></param>
        /// <returns></returns>
        List<View_A02> GetAttendsByRowID(string strRowID);

        //*******************************APP 务工人员统计************************************
        /// <summary>
        ///  获取个人月出工记录
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        List<WorkSQLMonth> GetMonthWorkData(WorkMonthList model);
        /// <summary>
        ///  根据年份统计具体人员每月出工情况
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        List<WorkAllResult> GetAllWorkDays(WorkAllList model);
        /// <summary>
        ///  获取当月打卡天数
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        int GetMonthByCard(BaseAPI model);
        /// <summary>
        ///  获取总的打卡天数
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        int GetAllByCard(BaseAPI model);
    }
}
