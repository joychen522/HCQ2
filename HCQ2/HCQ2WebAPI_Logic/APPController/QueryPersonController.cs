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

namespace HCQ2WebAPI_Logic.APPController
{
    public class QueryPersonController : BaseWeiXinApiLogic
    {
        /// <summary>
        /// 根据姓名或身份证号码获取人员列表
        /// </summary>
        /// <param name="person"></param>
        /// <returns></returns>
        [HttpPost]
        public object GetPersonQueryList(Person person)
        {
            if (!ModelState.IsValid)
                return operateContext.RedirectWebApi(WebResultCode.Exception, GlobalConstant.参数异常.ToString(), null);

            var data = operateContext.bllSession.A01.GetPersonQueryList(person);
            return operateContext.RedirectWebApi(WebResultCode.Ok, GlobalConstant.操作成功.ToString(), data);
        }

        /// <summary>
        /// 根据姓名和项目名称获取人员基本信息
        /// </summary>
        /// <param name="person"></param>
        /// <returns></returns>
        [HttpPost]
        public object GetPersonDetail(PersonDetail person)
        {
            if (!ModelState.IsValid)
                return operateContext.RedirectWebApi(WebResultCode.Exception, GlobalConstant.参数异常.ToString(), null);

            var data = operateContext.bllSession.A01.GetPersonDetail(person);
            return operateContext.RedirectWebApi(WebResultCode.Ok, GlobalConstant.操作成功.ToString(), data);
        }

        /// <summary>
        /// 根据姓名和项目名称获取人员当前所在项目
        /// </summary>
        /// <param name="person"></param>
        /// <returns></returns>
        [HttpPost]
        public object GetPersonUnitDetail(PersonDetail person)
        {
            if (!ModelState.IsValid)
                return operateContext.RedirectWebApi(WebResultCode.Exception, GlobalConstant.参数异常.ToString(), null);

            var data = operateContext.bllSession.A01.GetPersonUnitDetail(person);
            return operateContext.RedirectWebApi(WebResultCode.Ok, GlobalConstant.操作成功.ToString(), data);
        }

        /// <summary>
        /// 根据姓名和项目名称获取人员出工记录
        /// </summary>
        /// <param name="person"></param>
        /// <returns></returns>
        [HttpPost]
        public object GetCheckDaysRecord(PersonDetailCkeck person)
        {
            if (!ModelState.IsValid)
                return operateContext.RedirectWebApi(WebResultCode.Exception, GlobalConstant.参数异常.ToString(), null);

            var data = operateContext.bllSession.A01.GetCheckDaysRecord(person);
            return operateContext.RedirectWebApi(WebResultCode.Ok, GlobalConstant.操作成功.ToString(), data);
        }

        /// <summary>
        ///  薪资发放
        /// </summary>
        /// <param name="person"></param>
        /// <returns></returns>
        [HttpPost]
        public object GetWageDetail(WageGrantParamModel person)
        {
            if (!ModelState.IsValid)
                return operateContext.RedirectWebApi(WebResultCode.Exception, GlobalConstant.参数异常.ToString(), null);
            List<WageDetialResult> list = operateContext.bllSession.WGJG02.GetWageDetialByPerson(person);
            if (null == list || list.Count <= 0)
                return operateContext.RedirectWebApi(WebResultCode.Error, GlobalConstant.数据获取失败.ToString(), "");
            return operateContext.RedirectWebApi(WebResultCode.Ok, GlobalConstant.数据获取成功.ToString(), list);
        }

        /// <summary>
        /// 获取工种备选项
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public object GetWorkerType()
        {
            var data = operateContext.bllSession.A01.GetWorkerType();
            return operateContext.RedirectWebApi(WebResultCode.Ok, GlobalConstant.数据获取成功.ToString(), data);
        }

        /// <summary>
        /// 下发该项目劳务公司
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public object GetProjectTeam(EditPerson person)
        {
            if (!ModelState.IsValid)
                return operateContext.RedirectWebApi(WebResultCode.Exception, GlobalConstant.参数异常.ToString(), null);
            var data = operateContext.bllSession.T_CompProInfo.GetComByGuID(person);
            return operateContext.RedirectWebApi(WebResultCode.Ok, GlobalConstant.数据获取成功.ToString(), data);
        }

        /// <summary>
        /// 获取需要编辑的人员信息
        /// </summary>
        /// <param name="person"></param>
        /// <returns></returns>
        [HttpPost]
        public object GetEditPersonDetail(EditPerson person)
        {
            if (!ModelState.IsValid)
                return operateContext.RedirectWebApi(WebResultCode.Exception, GlobalConstant.参数异常.ToString(), null);
            var data = operateContext.bllSession.A01.GetEditPersonDetail(person);
            return operateContext.RedirectWebApi(WebResultCode.Ok, GlobalConstant.数据获取成功.ToString(), data);
        }

        /// <summary>
        /// 删除人员信息
        /// </summary>
        /// <param name="person"></param>
        /// <returns></returns>
        [HttpPost]
        public object DeletePerson(EditPerson person)
        {
            if (!ModelState.IsValid)
                return operateContext.RedirectWebApi(WebResultCode.Exception, GlobalConstant.参数异常.ToString(), null);
            var data = operateContext.bllSession.A01.DeletePerson(person) ? "01" : "02";
            return operateContext.RedirectWebApi(WebResultCode.Ok, GlobalConstant.数据获取成功.ToString(), data);
        }

        /// <summary>
        /// 编辑人员信息
        /// </summary>
        /// <param name="person"></param>
        /// <returns></returns>
        [HttpPost]
        public object ApiEditPerson(EditPersonToSave person)
        {
            if (!ModelState.IsValid)
                return operateContext.RedirectWebApi(WebResultCode.Exception, GlobalConstant.参数异常.ToString(), null);
            var data = operateContext.bllSession.A01.ApiEditPerson(person) ? "01" : "02";
            return operateContext.RedirectWebApi(WebResultCode.Ok, GlobalConstant.数据获取成功.ToString(), data);
        }
    }
}
