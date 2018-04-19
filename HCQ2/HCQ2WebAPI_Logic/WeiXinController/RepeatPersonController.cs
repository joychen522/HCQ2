using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HCQ2WebAPI_Logic.BaseAPIController;
using System.Web.Http;
using HCQ2_Common.Constant;
using HCQ2_Model.WeiXinApiModel.ParamModel;
using System.Data;

namespace HCQ2WebAPI_Logic.WeiXinController
{
    public class RepeatPersonController : BaseWeiXinApiLogic
    {
        /// <summary>
        /// 重复用工查询
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public object GetPerson(HCQ2_Model.AppModel.RepeatPerson person)
        {
            List<object> rList = new List<object>();
            List<RepeatWorker> list = new List<RepeatWorker>();
            RepeatWorker work = new RepeatWorker();
            DataTable dt = operateContext.bllSession.A01.GetApiRepeatPerson(person.userid);
            if (!string.IsNullOrEmpty(person.person_name)) {
                var data = dt.Select("A0101 like '%" + person.person_name + "%'");
                if (data.Count() > 0)
                    dt = data.CopyToDataTable();
                else
                    return operateContext.RedirectWebApi(WebResultCode.Ok, GlobalConstant.操作成功.ToString(), null);
            }

            DataTable dtIdentifyCode = dt.DefaultView.ToTable(true, "A0177");

            StringBuilder sbSql = new StringBuilder();
            for (int i = 0; i < dtIdentifyCode.Rows.Count; i++)
            {
                DataTable dtNow = dt.Select("A0177='" + dtIdentifyCode.Rows[i]["A0177"] + "'").CopyToDataTable();
                list = new List<RepeatWorker>();
                for (int j = 0; j < dtNow.Rows.Count; j++)
                {
                    work = new RepeatWorker();
                    sbSql = new StringBuilder();
                    sbSql.AppendFormat("select distinct YEAR(A0201),MONTH(A0201),DAY(A0201) from A02 where PersonID='{0}'", dtNow.Rows[j]["PersonID"]);
                    work.person_name = StringBase(dtNow.Rows[j]["A0101"]);
                    work.person_zx = StringBase(dtNow.Rows[j]["zx"]);
                    if(!string.IsNullOrEmpty(dtNow.Rows[j]["UnitGroup"].ToString()))
                        work.unit_project = StringBase(dtNow.Rows[j]["UnitGroup"]);
                    else
                        work.unit_project = StringBase(dtNow.Rows[j]["UnitName"]);
                    work.person_jobs = StringBase(dtNow.Rows[j]["E0386"]);
                    work.work_start = StringBase(dtNow.Rows[j]["work_start"]);
                    work.work_days = HCQ2_Common.SQL.SqlHelper.ExecuteDataTable(sbSql.ToString()).Rows.Count;
                    work.person_wage = StringBase(dtNow.Rows[j]["E0368"]);
                    work.contact = StringBase(dtNow.Rows[j]["C01SS"]);
                    work.contact_phone = StringBase(dtNow.Rows[j]["C01RV"]);
                    work.A0177 = StringBase(dtNow.Rows[j]["A0177"]);
                    list.Add(work);
                }
                rList.Add(list);
            }
            return operateContext.RedirectWebApi(WebResultCode.Ok, GlobalConstant.操作成功.ToString(), rList);
        }

        /// <summary>
        /// 处理数据
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        private string StringBase(object obj)
        {
            if (obj.Equals(null) || obj == null || obj.Equals(""))
            {
                return "";
            }
            return obj.ToString();
        }
    }
}
