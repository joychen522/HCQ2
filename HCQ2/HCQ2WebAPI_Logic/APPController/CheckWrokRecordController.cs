using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HCQ2WebAPI_Logic.BaseAPIController;
using System.Web.Http;
using HCQ2_Common.Constant;
using HCQ2_Model.AppModel;
using HCQ2_Model.APPModel.ParamModel;
using HCQ2_Model.APPModel.ResultApiModel;
using HCQ2_Model;

namespace HCQ2WebAPI_Logic.APPController
{
    /// <summary>
    /// 出工情况
    /// </summary>
    public class CheckWrokRecordController : BaseWeiXinApiLogic
    {
        /// <summary>
        /// 获取所有出工情况列表
        /// </summary>
        /// <param name="checkWork"></param>
        /// <returns></returns>
        [HttpPost]
        public object GetCheckWorkList(CheckWork checkWork)
        {
            if (!ModelState.IsValid)
                return operateContext.RedirectWebApi(WebResultCode.Exception, GlobalConstant.参数异常.ToString(), null);

            var data = operateContext.bllSession.A01.GetCheckWorkList(checkWork);
            return operateContext.RedirectWebApi(WebResultCode.Ok, GlobalConstant.操作成功.ToString(), data);
        }

        /// <summary>
        /// 分页获取出工情况列表
        /// </summary>
        /// <param name="checkWork"></param>
        /// <returns></returns>
        [HttpPost]
        public object GetRowPageList(CheckWorkPageRow checkWork)
        {
            if (!ModelState.IsValid)
                return operateContext.RedirectWebApi(WebResultCode.Exception, GlobalConstant.参数异常.ToString(), null);

            var data = operateContext.bllSession.A01.GetRowPageList(checkWork);
            return operateContext.RedirectWebApi(WebResultCode.Ok, GlobalConstant.操作成功.ToString(), data);
        }

        /// <summary>
        /// 获取具体项目出工情况列表
        /// </summary>
        /// <param name="checkWork"></param>
        /// <returns></returns>
        [HttpPost]
        public object GetPersonList(CheckWork checkWork)
        {
            if (!ModelState.IsValid || string.IsNullOrEmpty(checkWork.unit_name))
                return operateContext.RedirectWebApi(WebResultCode.Exception, GlobalConstant.参数异常.ToString(), null);
            var data = operateContext.bllSession.A01.GetPersonList(checkWork);
            return operateContext.RedirectWebApi(WebResultCode.Ok, GlobalConstant.操作成功.ToString(), data);
        }

        /// <summary>
        /// 项目人员出工统计
        /// </summary>
        /// <param name="checkWork"></param>
        /// <returns></returns>
        [HttpPost]
        public object GetPersonStatis(CheckWorkStatic checskStatic)
        {
            if (!ModelState.IsValid)
                return operateContext.RedirectWebApi(WebResultCode.Exception, GlobalConstant.参数异常.ToString(), null);
            var data = operateContext.bllSession.A01.GetPersonStatis(checskStatic);
            return operateContext.RedirectWebApi(WebResultCode.Ok, GlobalConstant.操作成功.ToString(), data);
        }

        /// <summary>
        /// 获取所有项目的平均出工率
        /// </summary>
        /// <param name="checkWork"></param>
        /// <returns></returns>
        [HttpPost]
        public object GetAllProjectAvg(CheckWork checkWork)
        {
            if (!ModelState.IsValid)
                return operateContext.RedirectWebApi(WebResultCode.Exception, GlobalConstant.参数异常.ToString(), null);
            var data = operateContext.bllSession.A01.GetAllProjectAvg(checkWork);
            return operateContext.RedirectWebApi(WebResultCode.Ok, GlobalConstant.操作成功.ToString(), data);
        }

        /// <summary>
        /// 获取所有项目某个月的全部出工情况
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public object GetDayWorkByMonth(CheckWork checkWork)
        {
            if (!ModelState.IsValid)
                return operateContext.RedirectWebApi(WebResultCode.Exception, GlobalConstant.参数异常.ToString(), null);
            var data = operateContext.bllSession.A01.GetDayWorkByMonth(checkWork);
            return operateContext.RedirectWebApi(WebResultCode.Ok, GlobalConstant.操作成功.ToString(), data);
        }

        /// <summary>
        ///  出工统计 
        ///  根据项目，出工日期
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public object GetPersonWorkByUnit(WorkCount model)
        {
            if (!ModelState.IsValid)
                return operateContext.RedirectWebApi(WebResultCode.Exception, GlobalConstant.参数异常.ToString(), null);
            HCQ2_IBLL.IView_A02BLL View02 = operateContext.bllSession.View_A02;
            int toWork = View02.GetWorkPersonCount(model);
            int onWork = View02.GetonWorkPersonCount(model);
            ToWorkResultModel rModel = new ToWorkResultModel
            {
                allCount = toWork + onWork,
                toWork = toWork,
                onWork = onWork,
                toWorkList = operateContext.bllSession.View_A02.GetWorkPersonList(model),
                onWorkList = operateContext.bllSession.View_A02.GetonWorkPersonList(model)
            };
            if (null == rModel)
                return operateContext.RedirectWebApi(WebResultCode.Exception, GlobalConstant.数据获取失败.ToString(), null);
            return operateContext.RedirectWebApi(WebResultCode.Ok, GlobalConstant.操作成功.ToString(), rModel);
        }
        /// <summary>
        ///  工种统计 根据项目
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public object GetWorkTypeByUnit(WorkCount model)
        {
            if (!ModelState.IsValid)
                return operateContext.RedirectWebApi(WebResultCode.Exception, GlobalConstant.参数异常.ToString(), null);
            List<WorkTypeCount> cList = operateContext.bllSession.View_A02.GetToWorkByType(model);
            Dictionary<string, object> obj = new Dictionary<string, object>();
            obj.Add("allCount", operateContext.bllSession.View_A02.GetWorkPersonCount(model));
            obj.Add("personList", cList);
            return operateContext.RedirectWebApi(WebResultCode.Ok, GlobalConstant.数据获取成功.ToString(), obj);
        }
    }
}
