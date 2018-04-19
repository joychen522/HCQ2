using System.Collections.Generic;
using System.Web.Http;
using HCQ2_Common.Constant;
using System.Linq;
using HCQ2_Model.WebApiModel.ParamModel;

namespace HCQ2WebAPI_Logic.WageAPIController
{
    /// <summary>
    ///  员工管理Service服务控制器
    ///  liqiang
    /// </summary> 
    public class StaffManagerController : BaseApiLogic
    {
        #region 1.0 入职登记 + object PersonRegister(PersonModel person)

        /// <summary>
        ///  入职登记
        /// </summary>
        /// <param name="person"></param>
        /// <returns></returns>
        [HttpPost]
        public object PersonRegister(PersonModel person)
        {
            if (!ModelState.IsValid)
                return operateContext.RedirectWebApi(WebResultCode.Exception, GlobalConstant.参数异常.ToString(), null);

            //判断该项目是否存在
            var data = operateContext.bllSession.A01.GetA01Info().
                Where(o => o.A0177 == person.person_cardno && o.UnitID == person.orgid);
            if (data.Count() > 0)
                return operateContext.RedirectWebApi(WebResultCode.Ok, "该身份证号码已经存在！", null);

            string personId = "";
            if (operateContext.bllSession.A01.ApiAddPerson(person, ref personId))
            {
                returnPerson re = new returnPerson()
                {
                    personid = personId
                };
                return operateContext.RedirectWebApi(WebResultCode.Ok, GlobalConstant.保存成功.ToString(), re);
            }
            else
                return operateContext.RedirectWebApi(WebResultCode.Exception, GlobalConstant.保存失败.ToString(), null);
        }
        #endregion

        #region 1.1 考勤登记 + object CheckWork(CheckWorkModel model)

        /// <summary>
        ///  1.1 考勤登记
        /// 返回本次签到RowID
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public object CheckWork(CheckWorkModel model)
        {
            if (!ModelState.IsValid)
                return operateContext.RedirectWebApi(WebResultCode.Exception, GlobalConstant.参数异常.ToString(), null);

            string RowID = "";
            if (operateContext.bllSession.A02.ApiCheckPerson(model, ref RowID))
            {
                ReturnCheckModle returnModle = new ReturnCheckModle()
                {
                    worksignid = RowID
                };
                try
                {
                    //上报
                    operateContext.bllSession.A02.UpCheck(model.personid, model.signtime, "1", RowID);
                }
                catch (System.Exception)
                {
                    
                }
                return operateContext.RedirectWebApi(WebResultCode.Ok, GlobalConstant.操作成功.ToString(), returnModle);
            }
            else
                return operateContext.RedirectWebApi(WebResultCode.Exception, GlobalConstant.保存失败.ToString(), null);
        }
        #endregion

        #region 1.3 人员信息和虹膜下发 + object PersonsSentDown(BaseModel wage)

        /// <summary>
        ///  1.3 人员信息和虹膜下发
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public object PersonsSentDown(BaseModel wage)
        {
            if (!ModelState.IsValid)
                return operateContext.RedirectWebApi(WebResultCode.Exception, GlobalConstant.参数异常.ToString(), null);
            string unit_id = wage.orgid;
            var data = operateContext.bllSession.A01.GetA01Info().Where(o => o.UnitID == unit_id);
            if (data.Count() > 0)
            {
                List<PersonIris> list = new List<PersonIris>();
                PersonIris person = new PersonIris();
                foreach (var item in data)
                {
                    person = new PersonIris();
                    person.orgid = unit_id;
                    person.person_name = item.A0101;
                    person.person_cardno = item.A0177;
                    person.personid = item.PersonID;
                    person.iris_data = item.A0118;
                    person.big_iris_data = item.big_iris_data;
                    list.Add(person);
                }
                return operateContext.RedirectWebApi(WebResultCode.Ok, GlobalConstant.操作成功.ToString(), list);
            }
            else
                return operateContext.RedirectWebApi(WebResultCode.Exception, GlobalConstant.操作成功.ToString(), null);
        }

        #endregion

        #region 1.4 人员同步 + object PersonsSynchronous(BaseModel wage)

        /// <summary>
        ///  1.4 人员同步
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public object PersonsSynchronous(PersonSysn person)
        {
            if (!ModelState.IsValid)
                return operateContext.RedirectWebApi(WebResultCode.Exception, GlobalConstant.参数异常.ToString(), null);

            var data = operateContext.bllSession.A01.PersonsSynchronous(person.match_timestamp, person.orgid, person.userid, person.deviceid);
            if(data == null)
                return operateContext.RedirectWebApi(WebResultCode.Ok, GlobalConstant.操作成功.ToString(), "没有需要同步的数据！");
            List<PersonCL> userList = new List<PersonCL>();
            PersonCL user = new PersonCL();
            foreach (var item in data)
            {
                user = new PersonCL();
                user.orgid = person.orgid;
                user.personid = item.PersonID;
                user.person_name = item.A0101;
                user.person_sex = item.A0107;
                user.person_nation = item.A0121;
                user.person_cardno = item.A0177;
                user.person_address = item.A0115;
                user.iris_data = item.A0118;
                user.big_iris_data = item.big_iris_data;
                user.person_police = item.A0112;

                if (!string.IsNullOrEmpty(item.A0111.ToString()))
                    user.person_birthday = System.Convert.ToDateTime(item.A0111).ToString("yyyy-MM-dd");
                else
                    user.person_birthday = "";

                if (!string.IsNullOrEmpty(item.A0116.ToString()))
                    user.person_userlifebegin = System.Convert.ToDateTime(item.A0116).ToString("yyyy-MM-dd");
                else
                    user.person_userlifebegin = "";

                if (!string.IsNullOrEmpty(item.A0117.ToString()))
                    user.person_userlifeend = System.Convert.ToDateTime(item.A0117).ToString("yyyy-MM-dd");
                else
                    user.person_userlifeend = "";

                if (item.PersonPhoto != null)
                    user.person_photo = System.Convert.ToBase64String(item.PersonPhoto);
                else
                    user.person_photo = "";

                userList.Add(user);
            }
            return operateContext.RedirectWebApi(WebResultCode.Ok, GlobalConstant.操作成功.ToString(), userList);
        }

        #endregion
    }
}
