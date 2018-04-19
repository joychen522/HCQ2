using HCQ2_Model.ExtendsionModel;
using HCQ2_Model.ParamsModel;
using HCQ2_Model.SelectModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HCQ2_IDAL
{
    public partial interface IT_UseWorkerDAL
    {
        /// <summary>
        ///  获取一栏数据
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        List<T_UseWorkerModel> GetUseWorkListData(T_UseWorkerParam param);
        /// <summary>
        ///  获取查看用工一栏数据
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        List<T_UseIssueListModel> GetUseIssueListData(T_UseWorkerParam param);
        /// <summary>
        ///  获取简历数据
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        List<T_JobResumeRelationModel> GetIssueListData(T_IssueListParam param);
        /// <summary>
        ///  获取招聘对于简历数据总量
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        int GetIssueListDataCount(T_IssueListParam param);
        /// <summary>
        ///  获取一栏数据总量
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        int GetWorkListDataCount(T_UseWorkerParam param);
        /// <summary>
        ///  更新状态
        /// </summary>
        /// <param name="job_ids"></param>
        /// <param name="job_status"></param>
        /// <returns></returns>
        void ModifyStatus(string job_ids,string job_status);
        /// <summary>
        ///  获取字典集合
        /// </summary>
        /// <param name="item_code"></param>
        /// <returns></returns>
        List<SelectValueModel> GetJobDictionary(string item_code);

        //************************************APP Service*****************************************
        /// <summary>
        ///  获取职位列表
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        List<HCQ2_Model.APPModel.ResultApiModel.JobEmployResultModel> GetJobEmployList(HCQ2_Model.APPModel.ParamModel.JobEmployModel model);
        /// <summary>
        ///  根据招聘信息 获取职位详情
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        List<HCQ2_Model.APPModel.ResultApiModel.PostDetialResultModel> GetPostDetialByID(HCQ2_Model.APPModel.ParamModel.PostDetialParam model);
        /// <summary>
        ///  获取公司详情
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        List<HCQ2_Model.APPModel.ResultApiModel.BusComProinfoResult> GetComProDetailByID(HCQ2_Model.APPModel.ParamModel.BusComProinfo model);
    }
}
