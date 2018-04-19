using HCQ2_Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using HCQ2_Model.WebApiModel.ParamModel;
using HCQ2_Model.AppModel;
using HCQ2_Model.APPModel.ParamModel;
using HCQ2_Model.APPModel.ResultApiModel;
using HCQ2_Model.ViewModel;

namespace HCQ2_IBLL
{
    public partial interface IView_A02BLL
    {
        /// <summary>
        /// 获取View_A02信息，已经打卡的人员信息
        /// </summary>
        /// <returns></returns>
        List<View_A02> GetView();

        /// <summary>
        /// 获取已经打卡的人员信息2017-6-2
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        List<View_A02> CheckPerson(object obj);

        /// <summary>
        /// 获取View_A02信息，未打卡的人员信息
        /// </summary>
        /// <param name="bindDate">年月日</param>
        /// <returns></returns>
        DataTable GetView(object obj);

        /// <summary>
        /// 替换数据源里面的字典值
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        List<View_A02> GetViewReplace(List<View_A02> list);

        /// <summary>
        /// 根据PersonID筛选数据
        /// </summary>
        /// <param name="personID"></param>
        /// <returns></returns>
        List<View_A02> GetViewByPersonID(string personID);

        /// <summary>
        /// 根据RowID筛选
        /// </summary>
        /// <param name="rowID"></param>
        /// <returns></returns>
        View_A02 GetByRowID(string rowID);

        /// <summary>
        /// 将对象转化为JSON数组
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        string ObjectToJson(List<View_A02> list);

        /// <summary>
        /// 根据单位代码筛选数据
        /// </summary>
        /// <param name="UnitID"></param>
        /// <returns></returns>
        List<View_A02> GetByUnitID(string UnitID);

        /// <summary>
        /// 获取某年某月某天到岗人数
        /// </summary>
        /// <param name="year"></param>
        /// <param name="month"></param>
        /// <param name="day"></param>
        /// <returns></returns>
        int GetAttendanceTrue(int year, int month, int day);

        /// <summary>
        /// 根据用户ID获取某年某月某天到岗人数
        /// </summary>
        /// <param name="year"></param>
        /// <param name="month"></param>
        /// <param name="day"></param>
        /// <param name="user_id"></param>
        /// <returns></returns>
        int GetAttendanceTrue(int year, int month, int day, string user_id);

        /// <summary>
        /// 获取某年某月某日到岗人员的单位树
        /// </summary>
        /// <param name="year"></param>
        /// <param name="month"></param>
        /// <param name="day"></param>
        /// <param name="user_id"></param>
        /// <returns></returns>
        List<Dictionary<string, object>> GetAttendanceDate(int year, int month, int day, int user_id);

        /// <summary>
        /// 获取某年某月某日到岗人员
        /// </summary>
        /// <param name="year"></param>
        /// <param name="month"></param>
        /// <param name="day"></param>
        /// <param name="user_id"></param>
        /// <returns></returns>
        List<View_A02> GetAttendanceDatePerson(int year, int month, int day, int user_id);

        /// <summary>
        /// 获取包含打卡次数的数据源
        /// </summary>
        /// <param name="viewList"></param>
        /// <returns></returns>
        List<HCQ2_Model.ViewModel.CheckModle> GetCheckCount(List<View_A02> viewList);

        /// <summary>
        /// 异常考勤上报
        /// </summary>
        /// <param name="strUnit">单位编号的字符串</param>
        /// <returns></returns>
        string UpAttends(string strUnit);

        /// <summary>
        /// 获取考勤异常上报页面数据源
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        TableModel GetExcptionUpSoure(object obj);

        /// <summary>
        /// 上报异常考勤
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        bool UpLoadExcptionAttend(object obj);

        #region  API用工记录接口

        /// <summary>
        /// 用工接口
        /// </summary>
        /// <param name="work"></param>
        /// <returns></returns>
        object GetApiWorkTime(CheckUseWorker work);

        #endregion

        //APP接口
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
    }
}
