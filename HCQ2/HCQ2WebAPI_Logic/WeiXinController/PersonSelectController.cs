using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HCQ2WebAPI_Logic.BaseAPIController;
using System.Web.Http;
using HCQ2_Common.Constant;
using HCQ2_Model.WeiXinApiModel.ParamModel;

namespace HCQ2WebAPI_Logic.WeiXinController
{
    public class PersonSelectController : BaseWeiXinApiLogic
    {

        /// <summary>
        /// 人员基本信息
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public object PersonDetail(PersonSelect person)
        {
            if (string.IsNullOrEmpty(person.person_name) && string.IsNullOrEmpty(person.person_identity_code))
                return operateContext.RedirectWebApi(WebResultCode.Exception, GlobalConstant.参数异常.ToString(), null);

            List<PersonDetail> list = new List<HCQ2_Model.WeiXinApiModel.ParamModel.PersonDetail>();
            PersonDetail detail = new HCQ2_Model.WeiXinApiModel.ParamModel.PersonDetail();
            //根据姓名查找
            if (!string.IsNullOrEmpty(person.person_name)) {
                var data = operateContext.bllSession.A01.Select(o => o.A0101 == person.person_name);
                foreach (var item in data)
                {
                    detail = new HCQ2_Model.WeiXinApiModel.ParamModel.PersonDetail();
                    detail.person_name = item.A0101;
                    detail.person_sex = item.A0107;
                    detail.person_birth = item.A0111;
                    detail.person_address = item.A0115;
                    detail.person_photo = item.PersonPhoto;
                    list.Add(detail);
                }
            }
            //根据身份证查找
            if (!string.IsNullOrEmpty(person.person_identity_code)) {
                var data = operateContext.bllSession.A01.Select(o => o.A0177 == person.person_identity_code);
                foreach (var item in data)
                {
                    detail = new HCQ2_Model.WeiXinApiModel.ParamModel.PersonDetail();
                    detail.person_name = item.A0101;
                    detail.person_sex = item.A0107;
                    detail.person_birth = item.A0111;
                    detail.person_address = item.A0115;
                    detail.person_photo = item.PersonPhoto;
                    list.Add(detail);
                }
            }
            return operateContext.RedirectWebApi(WebResultCode.Exception, GlobalConstant.操作成功.ToString(), list);
        }

        /// <summary>
        /// 项目信息
        /// </summary>
        /// <param name="person"></param>
        /// <returns></returns>
        [HttpPost]
        public object UnitDetail(PersonSelect person)
        {
            if (string.IsNullOrEmpty(person.person_name) && string.IsNullOrEmpty(person.person_identity_code))
                return operateContext.RedirectWebApi(WebResultCode.Exception, GlobalConstant.参数异常.ToString(), null);

            List<UnitDetail> list = new List<HCQ2_Model.WeiXinApiModel.ParamModel.UnitDetail>();
            UnitDetail unit = new HCQ2_Model.WeiXinApiModel.ParamModel.UnitDetail();

            if (!string.IsNullOrEmpty(person.person_name)) {
                var data = operateContext.bllSession.A01.Select(o => o.A0101 == person.person_name);
                foreach (var item in data)
                {
                    unit = new HCQ2_Model.WeiXinApiModel.ParamModel.UnitDetail();
                    //所属企业
                    var unitData = operateContext.bllSession.B01.Select(o => o.UnitID == item.B0001);
                    unit.unit_enterprise = unitData.FirstOrDefault().UnitName;

                    //所属项目
                    unitData = operateContext.bllSession.B01.Select(o => o.UnitID == item.B0002);
                    unit.unit_project = unitData.FirstOrDefault().UnitName;
                    //联系人
                    unit.unit_contact = unitData.FirstOrDefault().B0180;
                    //联系电话
                    unit.unit_contact_phone = "";
                    list.Add(unit);
                }
            }
            if (!string.IsNullOrEmpty(person.person_identity_code))
            {
                var data = operateContext.bllSession.A01.Select(o => o.A0177 == person.person_identity_code);
                foreach (var item in data)
                {
                    unit = new HCQ2_Model.WeiXinApiModel.ParamModel.UnitDetail();
                    //所属企业
                    var unitData = operateContext.bllSession.B01.Select(o => o.UnitID == item.B0001);
                    unit.unit_enterprise = unitData.FirstOrDefault().UnitName;

                    //所属项目
                    unitData = operateContext.bllSession.B01.Select(o => o.UnitID == item.B0002);
                    unit.unit_project = unitData.FirstOrDefault().UnitName;
                    //联系人
                    unit.unit_contact = unitData.FirstOrDefault().B0180;
                    //联系电话
                    unit.unit_contact_phone = "";
                    list.Add(unit);
                }
            }
            return operateContext.RedirectWebApi(WebResultCode.Exception, GlobalConstant.操作成功.ToString(), list);
        }

        /// <summary>
        /// 薪资信息
        /// </summary>
        /// <param name="person"></param>
        /// <returns></returns>
        public object WageDetail(PersonSelect person)
        {
            if (string.IsNullOrEmpty(person.person_name) && string.IsNullOrEmpty(person.person_identity_code))
                return operateContext.RedirectWebApi(WebResultCode.Exception, GlobalConstant.参数异常.ToString(), null);



            return null;
        }

        /// <summary>
        /// 出工信息
        /// </summary>
        /// <param name="person"></param>
        /// <returns></returns>
        public object WorkDetail(PersonSelect person)
        {
            if (string.IsNullOrEmpty(person.person_name) && string.IsNullOrEmpty(person.person_identity_code))
                return operateContext.RedirectWebApi(WebResultCode.Exception, GlobalConstant.参数异常.ToString(), null);



            return null;
        }
    }
}
