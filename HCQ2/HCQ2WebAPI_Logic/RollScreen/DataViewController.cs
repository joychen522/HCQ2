using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HCQ2WebAPI_Logic.BaseAPIController;
using System.Web.Http;
using HCQ2_Common.Constant;
using HCQ2_Model;

namespace HCQ2WebAPI_Logic.RollScreen
{
    public class DataViewController : BaseWeiXinApiLogic
    {

        /// <summary>
        /// 企业、务工人员、打卡人员统计
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public object GetMainEnteriseStatis()
        {
            var data = operateContext.bllSession.B01.GetMainEnteriseStatis();
            return operateContext.RedirectWebApi(WebResultCode.Ok, GlobalConstant.操作成功.ToString(), data);
        }

        /// <summary>
        /// 项目详情统计
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public object GetProjectDetailList()
        {
            var data = operateContext.bllSession.B01.GetProjectDetailList();
            return operateContext.RedirectWebApi(WebResultCode.Ok, GlobalConstant.操作成功.ToString(), data);
        }

        /// <summary>
        /// 项目详细统计 具体打卡人员信息
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public object GetProjectCheckDetail(HCQ2_Model.RollScreenModel.ProjectCheckUnit unit)
        {
            if (!ModelState.IsValid)
                return operateContext.RedirectWebApi(WebResultCode.Exception, GlobalConstant.参数异常.ToString(), null);
            var data = operateContext.bllSession.B01.GetProjectCheckDetail(unit);
            return operateContext.RedirectWebApi(WebResultCode.Ok, GlobalConstant.操作成功.ToString(), data);
        }

        /// <summary>
        /// 欠薪预警
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public object GetDeWageList()
        {
            var data = operateContext.bllSession.B01.GetDeWageList();
            return operateContext.RedirectWebApi(WebResultCode.Ok, GlobalConstant.操作成功.ToString(), data);
        }

        /// <summary>
        /// 欠薪预警>>项目详细信息
        /// </summary>
        /// <param name="unit"></param>
        /// <returns></returns>
        [HttpPost]
        public object GetDeWageProjectDetail(HCQ2_Model.RollScreenModel.ProjectCheckUnit unit)
        {
            if (!ModelState.IsValid)
                return operateContext.RedirectWebApi(WebResultCode.Exception, GlobalConstant.参数异常.ToString(), null);
            var data = operateContext.bllSession.B01.GetDeWageProjectDetail(unit);
            return operateContext.RedirectWebApi(WebResultCode.Ok, GlobalConstant.操作成功.ToString(), data);
        }

        /// <summary>
        /// 务工人员统计>年龄统计
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public object GetStatisAge()
        {
            var data = operateContext.bllSession.B01.GetStatisAge();
            return operateContext.RedirectWebApi(WebResultCode.Ok, GlobalConstant.操作成功.ToString(), data);
        }

        /// <summary>
        /// 务工人员统计>工种统计
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public object GetStatisJobs(HCQ2_Model.RollScreenModel.DataViewJosb job)
        {
            if (job.rows == 0)
                job.rows = 5;
            var data = operateContext.bllSession.B01.GetStatisJobs(job);
            return operateContext.RedirectWebApi(WebResultCode.Ok, GlobalConstant.操作成功.ToString(), data);
        }

        /// <summary>
        /// 获取地图项目信息
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public object GetMiddleMapStatis()
        {
            var data = operateContext.bllSession.B01.GetMiddleMapStatis();
            return operateContext.RedirectWebApi(WebResultCode.Ok, GlobalConstant.操作成功.ToString(), data);
        }

        /// <summary>
        /// 采集趋势图
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public object GetCollectTrend()
        {
            var data = operateContext.bllSession.B01.GetCollectTrend();
            return operateContext.RedirectWebApi(WebResultCode.Ok, GlobalConstant.操作成功.ToString(), data);
        }

        //Credit reporting
        /// <summary>
        /// 获取企业征信
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public object GetCreditReporting()
        {
            var data = operateContext.bllSession.T_EnterDetail.GetDataApiView();
            return operateContext.RedirectWebApi(WebResultCode.Ok, GlobalConstant.操作成功.ToString(), data);
        }

        /// <summary>
        /// 获取失信企业详细信息
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public object GetCompayCredit()
        {
            var data = operateContext.bllSession.T_EnterDetail.GetCompay();
            return operateContext.RedirectWebApi(WebResultCode.Ok, GlobalConstant.操作成功.ToString(), data);
        }

        /// <summary>
        /// 获取记录事件详细信息
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public object GetEventCredit()
        {
            var data = operateContext.bllSession.T_EnterDetail.GetEvent();
            return operateContext.RedirectWebApi(WebResultCode.Ok, GlobalConstant.操作成功.ToString(), data);
        }

        /// <summary>
        /// 案事件处理
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public object SolveCount()
        {
            var data = operateContext.bllSession.T_EnterDetail.SolveCount();
            return operateContext.RedirectWebApi(WebResultCode.Ok, GlobalConstant.操作成功.ToString(), data);
        }

        /// <summary>
        /// 企业类型统计
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public object CompayWorkerType()
        {
            var data = operateContext.bllSession.T_CompProInfo.GetCompayQXLB();
            return operateContext.RedirectWebApi(WebResultCode.Ok, GlobalConstant.操作成功.ToString(), data);
        }
    }
}
