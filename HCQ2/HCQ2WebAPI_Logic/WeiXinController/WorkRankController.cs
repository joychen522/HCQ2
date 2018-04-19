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
    public class WorkRankController : BaseWeiXinApiLogic
    {

        /// <summary>
        /// 获取出工排名
        /// </summary>
        /// <param name="work"></param>
        /// <returns></returns>
        [HttpPost]
        public object GetWorkDays(WorkRank work)
        {
            if (!ModelState.IsValid)
                return operateContext.RedirectWebApi(WebResultCode.Exception, GlobalConstant.参数异常.ToString(), null);

            var unit = operateContext.bllSession.B01.Select(o => o.UnitName == work.unit_name);
            if (!string.IsNullOrEmpty(unit[0].UnitID))
            {
                StringBuilder sbSql = new StringBuilder();
                sbSql.AppendFormat("select PersonID,A0177,A0101 from A01 where 1=1 ");
                switch (unit[0].UnitID.Length)
                {
                    case 3:
                        sbSql.AppendFormat(" and B0001='{0}' ", unit[0].UnitID);
                        break;
                    default:
                        sbSql.AppendFormat(" and B0002='{0}' ", unit[0].UnitID);
                        break;
                }
                DataTable dt = HCQ2_Common.SQL.SqlHelper.ExecuteDataTable(sbSql.ToString());
                string person_id = string.Empty;
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if (string.IsNullOrEmpty(person_id))
                        person_id = "'"+ dt.Rows[i]["PersonID"] + "'";
                    else
                        person_id += ",'" + dt.Rows[i]["PersonID"] + "'";
                }

                sbSql = new StringBuilder();
                sbSql.AppendFormat("select PersonID,A0177,A0101,workday=(");
                sbSql.AppendFormat(" select COUNT(distinct DAY(a0201)) from A02 where YEAR(A0201)={0} and", work.work_year);
                sbSql.AppendFormat(" MONTH(A0201)={0} and PersonID=a.PersonID) from A01 a", work.work_month);
                sbSql.AppendFormat(" where PersonID in ({0}) order by workday desc", !string.IsNullOrEmpty(person_id) ? person_id : "''");
                DataTable dtWorkDay = HCQ2_Common.SQL.SqlHelper.ExecuteDataTable(sbSql.ToString());

                List<Rank> list = new List<Rank>();
                Rank rk = new Rank();
                for (int i = 0; i < dtWorkDay.Rows.Count; i++)
                {
                    rk = new Rank();
                    rk.person_name = dtWorkDay.Rows[i]["A0101"].ToString();
                    rk.person_identify_code = dtWorkDay.Rows[i]["A0177"].ToString();
                    rk.work_days = Convert.ToInt32(dtWorkDay.Rows[i]["workday"]);
                    list.Add(rk);
                }
                return operateContext.RedirectWebApi(WebResultCode.Ok, GlobalConstant.操作成功.ToString(), list);
            }
            return operateContext.RedirectWebApi(WebResultCode.Ok, GlobalConstant.参数异常.ToString(), null);
        }
    }
}
