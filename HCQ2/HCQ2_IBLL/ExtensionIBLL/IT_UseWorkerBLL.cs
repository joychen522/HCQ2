using HCQ2_Model.ExtendsionModel;
using HCQ2_Model.ParamsModel;
using HCQ2_Model.SelectModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HCQ2_IBLL
{
    /// <summary>
    ///  发布招聘信息业务层接口
    /// </summary>
    public partial interface IT_UseWorkerBLL
    {
        /// <summary>
        ///  添加招聘信息
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        int AddUseWork(T_UseWorkerModel model);
        /// <summary>
        ///  编辑招聘信息
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        int EditUseWork(T_UseWorkerModel model);
        /// <summary>
        ///  删除招聘信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        int DelUseWork(int id);
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
        void ModifyStatus(string job_ids, string job_status);
        /// <summary>
        ///  获取字典集合
        /// </summary>
        /// <returns></returns>
        Dictionary<string, List<SelectModel>> GetJobDictionary();

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
        ///  投递简历
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        bool SendResumeByID(HCQ2_Model.APPModel.ParamModel.PostDetialParam model);
        /// <summary>
        ///  获取公司详情
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        List<HCQ2_Model.APPModel.ResultApiModel.BusComProinfoResult> GetComProDetailByID(HCQ2_Model.APPModel.ParamModel.BusComProinfo model);
        /// <summary>
        ///  获取行政区划
        /// </summary>
        /// <returns></returns>
        List<ddlSelectModel> GetCity();
    }
}
