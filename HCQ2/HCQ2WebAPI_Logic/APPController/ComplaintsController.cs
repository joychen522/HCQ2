using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HCQ2WebAPI_Logic.BaseAPIController;
using System.Web.Http;
using HCQ2_Common.Constant;
using HCQ2_Model.AppModel;

namespace HCQ2WebAPI_Logic.APPController
{
    public class ComplaintsController : BaseWeiXinApiLogic
    {
        /// <summary>
        /// 务工人员------提交投诉信息
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public object AddWorkPersonComplaints(HCQ2_Model.AppModel.Complaints com)
        {
            if (!ModelState.IsValid)
                return operateContext.RedirectWebApi(WebResultCode.Exception, GlobalConstant.参数异常.ToString(), null);
            string str = operateContext.bllSession.T_Complaints.AddComplaints(com) ? "投诉成功" : "投诉失败";
            return operateContext.RedirectWebApi(WebResultCode.Ok, GlobalConstant.操作成功.ToString(), str);
        }

        /// <summary>
        /// 务工人员------查看投诉历史
        /// </summary>
        /// <param name="person"></param>
        /// <returns></returns>
        [HttpPost]
        public object GetComplaintsHistory(WorkPerson person)
        {
            if (!ModelState.IsValid)
                return operateContext.RedirectWebApi(WebResultCode.Exception, GlobalConstant.参数异常.ToString(), null);
            var data = operateContext.bllSession.T_Complaints.GetByGuid(person.userid);
            if (data != null)
            {
                List<ComplaintsList> rList = new List<ComplaintsList>();
                ComplaintsList rCom = new ComplaintsList();
                foreach (var item in data)
                {
                    rCom = new ComplaintsList();
                    rCom.id = item.c_id;
                    rCom.title = item.c_title;
                    rCom.content = item.c_content;
                    rCom.date = Convert.ToDateTime(item.create_date).ToString("yyyy-MM-dd");
                    rList.Add(rCom);
                }
                return operateContext.RedirectWebApi(WebResultCode.Ok, GlobalConstant.操作成功.ToString(), rList);
            }
            else {
                return operateContext.RedirectWebApi(WebResultCode.Ok, GlobalConstant.操作成功.ToString(), null);
            }
        }

        /// <summary>
        /// 查看投诉详细信息
        /// </summary>
        /// <param name="com"></param>
        /// <returns></returns>
        [HttpPost]
        public object GetComplaintsDetail(ComDetail com)
        {
            if (!ModelState.IsValid)
                return operateContext.RedirectWebApi(WebResultCode.Exception, GlobalConstant.参数异常.ToString(), null);
            var data = operateContext.bllSession.T_Complaints.GetByComId(Convert.ToInt32(com.id));
            if(data == null)
                return operateContext.RedirectWebApi(WebResultCode.Ok, GlobalConstant.操作成功.ToString(), null);
            ComplaintsDetail detail = new ComplaintsDetail();
            detail.com_id = data.c_id;
            detail.com_title = data.c_title;
            detail.com_content = data.c_content;
            if(data.c_image != null)
                detail.com_image = Convert.ToBase64String(data.c_image);
            detail.com_date = Convert.ToDateTime(data.create_date).ToString("yyyy-MM-dd");
            detail.re_content = data.re_note;
            detail.unit_name = data.unit_name;
            if(data.re_date != null)
                detail.re_data = Convert.ToDateTime(data.re_date).ToString("yyyy-MM-dd");
            return operateContext.RedirectWebApi(WebResultCode.Ok, GlobalConstant.操作成功.ToString(), detail);
        }

        /// <summary>
        /// 根据处理类型分页获取投诉信息
        /// </summary>
        /// <param name="com"></param>
        /// <returns></returns>
        [HttpPost]
        public object GetComplaintsPageRow(ComReTypeInter com)
        {
            if (!ModelState.IsValid)
                return operateContext.RedirectWebApi(WebResultCode.Exception, GlobalConstant.参数异常.ToString(), null);
            var data = operateContext.bllSession.T_Complaints.GetComplaintsPageRow(com);
            return operateContext.RedirectWebApi(WebResultCode.Ok, GlobalConstant.操作成功.ToString(), data);
        }

        /// <summary>
        /// 处理投诉举报
        /// </summary>
        /// <param name="com"></param>
        /// <returns></returns>
        [HttpPost]
        public object SolveComplaints(ComSove com)
        {
            if (!ModelState.IsValid)
                return operateContext.RedirectWebApi(WebResultCode.Exception, GlobalConstant.参数异常.ToString(), null);
            var data = operateContext.bllSession.T_Complaints.SolveComplaints(com) ? "处理成功" : "处理失败";
            return operateContext.RedirectWebApi(WebResultCode.Ok, GlobalConstant.操作成功.ToString(), data);
        }
    }
}
