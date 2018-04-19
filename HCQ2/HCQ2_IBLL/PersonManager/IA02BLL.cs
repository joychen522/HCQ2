using HCQ2_Model;
using HCQ2_Model.APPModel.ParamModel;
using HCQ2_Model.APPModel.ResultApiModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HCQ2_Model.ViewModel;

namespace HCQ2_IBLL
{
    public partial interface IA02BLL
    {
        /// <summary>
        /// 获取所有的考勤情况
        /// </summary>
        /// <returns></returns>
        List<A02> GetA02Info();

        /// <summary>
        /// 根据PersonID获取考勤情况
        /// </summary>
        /// <param name="PersonID"></param>
        /// <returns></returns>
        List<A02> GetByPersonID(string PersonID);

        /// <summary>
        /// 根据RowID获取实体
        /// </summary>
        /// <param name="RowID"></param>
        /// <returns></returns>
        A02 GetByRowID(string RowID);

        /// <summary>
        /// 添加、编辑考勤时间
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        bool OperAttendance(object obj);

        /// <summary>
        /// API接口考勤签到
        /// </summary>
        /// <param name="model"></param>
        /// <param name="RowID"></param>
        /// <returns></returns>
        bool ApiCheckPerson(HCQ2_Model.WebApiModel.ParamModel.CheckWorkModel model, ref string RowID);

        /// <summary>
        /// 打卡上报
        /// </summary>
        /// <param name="PersonID"></param>
        /// <param name="checkDate"></param>
        /// <param name="checkTip"></param>
        void UpCheck(string PersonID,string checkDate,string checkTip,string RowID);

        /// <summary>
        /// 获取补签数据源
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        TableModel GetBuCheckSoure(object obj);

        /// <summary>
        /// 补签到
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        bool BuCheckPerson(object obj, out string strMsg);

        #region APP数据接口

        /// <summary>
        /// 统计图标出工打卡人数统计
        /// </summary>
        /// <param name="Model"></param>
        /// <returns></returns>
        List<CheckDatePerson> GetPunchCardData(DebtChartMoneyModel Model);

        #endregion

        /// <summary>
        ///  获取工种分类
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        List<WorkTypeCount> GetWorkType(OrgModel model);
    }
}
