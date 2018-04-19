using HCQ2_Common.Constant;
using HCQ2_Model.APPModel.ParamModel;
using HCQ2_Model.APPModel.ResultApiModel;
using HCQ2WebAPI_Logic.BaseAPIController;
using System.Collections.Generic;
using System.Web.Http;
using HCQ2_Model.SelectModel;

namespace HCQ2WebAPI_Logic.APPController
{
    /// <summary>
    ///  就业招聘
    /// </summary>
    public class JobEmploymentController: BaseWeiXinApiLogic
    {
        #region 1.0 获取职位查询字典 + object GetJobDictionary()
        /// <summary>
        ///  获取职位查询字典
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public object GetJobDictionary()
        {
            Dictionary<string, List<SelectModel>> list = operateContext.bllSession.T_UseWorker.GetJobDictionary();
            if(null==list)
               return operateContext.RedirectWebApi(WebResultCode.Ok, GlobalConstant.数据为空.ToString(), "");
            return operateContext.RedirectWebApi(WebResultCode.Ok, GlobalConstant.数据获取成功.ToString(), list);
        }
        #endregion

        #region 1.0.1 获取城市字典 + object GetCityDictionary()
        /// <summary>
        ///  获取城市字典
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public object GetCityDictionary()
        {
            List<ddlSelectModel> list = operateContext.bllSession.T_UseWorker.GetCity();
            if (null == list)
                return operateContext.RedirectWebApi(WebResultCode.Ok, GlobalConstant.数据为空.ToString(), "");
            return operateContext.RedirectWebApi(WebResultCode.Ok, GlobalConstant.数据获取成功.ToString(), list);
        }
        #endregion

        #region 1.1 获取职位列表数据 + object GetCheckWorkList(JobEmployModel model)
        /// <summary>
        /// 获取职位列表数据
        /// </summary>
        /// <param name="checkWork"></param>
        /// <returns></returns>
        [HttpPost]
        public object GetCheckWorkList(JobEmployModel model)
        {
            if (!ModelState.IsValid)
                return operateContext.RedirectWebApi(WebResultCode.Exception, GlobalConstant.参数异常.ToString(), null);
            //获取数据
            List<JobEmployResultModel> result = operateContext.bllSession.T_UseWorker.GetJobEmployList(model);
            if(null== result || result.Count<=0)
                return operateContext.RedirectWebApi(WebResultCode.Ok, GlobalConstant.数据为空.ToString(), null);
            return operateContext.RedirectWebApi(WebResultCode.Ok, GlobalConstant.操作成功.ToString(), result);
        }
        #endregion

        #region 1.2 获取职位详情 + object GetPostDetial(PostDetialParam model)
        /// <summary>
        ///  1.2 获取职位详情 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public object GetPostDetial(PostDetialParam model)
        {
            if (!ModelState.IsValid)
                return operateContext.RedirectWebApi(WebResultCode.Exception, GlobalConstant.参数异常.ToString(), null);
            //获取数据
            List<PostDetialResultModel> result = operateContext.bllSession.T_UseWorker.GetPostDetialByID(model);
            if (null == result || result.Count <= 0)
                return operateContext.RedirectWebApi(WebResultCode.Ok, GlobalConstant.数据为空.ToString(), null);
            return operateContext.RedirectWebApi(WebResultCode.Ok, GlobalConstant.操作成功.ToString(), result);
        }
        #endregion

        #region 1.3 投递简历 + object SendResume(PostDetialParam model)
        /// <summary>
        ///  1.3 投递简历 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost] 
        public object SendResume(PostDetialParam model)
        {
            if (!ModelState.IsValid)
                return operateContext.RedirectWebApi(WebResultCode.Exception, GlobalConstant.参数异常.ToString(), null);
            bool mark = operateContext.bllSession.T_UseWorker.SendResumeByID(model);
            if(mark)
                return operateContext.RedirectWebApi(WebResultCode.Ok, "简历投递成功！", "");
            return operateContext.RedirectWebApi(WebResultCode.Error, "简历投递失败！", "");
        }
        #endregion

        #region 1.4 获取公司详情 + object GetBusDetail(BusComProinfo model)
        /// <summary>
        ///  1.4 获取公司详情
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public object GetBusDetail(BusComProinfo model)
        {
            if (!ModelState.IsValid)
                return operateContext.RedirectWebApi(WebResultCode.Exception, GlobalConstant.参数异常.ToString(), null);
            //获取数据
            List<BusComProinfoResult> result = operateContext.bllSession.T_UseWorker.GetComProDetailByID(model);
            if (null == result)
                return operateContext.RedirectWebApi(WebResultCode.Ok, GlobalConstant.数据为空.ToString(), null);
            return operateContext.RedirectWebApi(WebResultCode.Ok, GlobalConstant.操作成功.ToString(), result);
        } 
        #endregion
    }
}
