using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HCQ2_Model;
using System.Data;

namespace HCQ2_BLL
{
    public partial class T_EnterDetailBLL : HCQ2_IBLL.IT_EnterDetailBLL
    {
        /// <summary>
        /// 根据用户ID获取所分配权限项目的所有征信记录
        /// </summary>
        /// <param name="user_id"></param>
        /// <returns></returns>
        public List<T_EnterDetail> GetEnterByUserid(int user_id)
        {
            StringBuilder sbSql = new StringBuilder();
            List<B01> unitList = new B01BLL().GetPerUnitByUserID(user_id);
            string strUnit = "'" + string.Join("','", unitList.Select(o => o.UnitID)) + "'";
            sbSql.AppendFormat("select b.* from  ( select * from T_CompProInfo where com_id in");
            sbSql.AppendFormat(" ( select in_compay from b01 where UnitID in ({0})))a ", strUnit);
            sbSql.AppendFormat(" inner join T_EnterDetail b on a.com_id=b.ent_id where b.is_success=0 and b.solve_type=0 ");
            sbSql.AppendFormat(" union all ");
            sbSql.AppendFormat(" select b.* from  ( select * from T_CompProInfo where QXLB<>'01' and QXLB<>'02')a ");
            sbSql.AppendFormat(" inner join T_EnterDetail b on a.com_id=b.ent_id where b.is_success=0 and b.solve_type=0 ");
            return HCQ2_Common.Data.DataTableHelper.DataTableToIList<T_EnterDetail>(
            HCQ2_Common.SQL.SqlHelper.ExecuteDataTable(sbSql.ToString()));
        }

        /// <summary>
        /// 获取失信企业以及记录事件数量
        /// </summary>
        /// <returns></returns>
        public Dictionary<string, object> GetDataApiView()
        {
            Dictionary<string, object> rDic = new Dictionary<string, object>();

            StringBuilder sbSql = new StringBuilder();
            //失信企业数量
            sbSql.AppendFormat("select COUNT(*) from T_CompProInfo where com_id in (select ent_id from T_EnterDetail where ent_type<>'01' and is_success=0)");
            rDic.Add("compay_count", HCQ2_Common.SQL.SqlHelper.ExecuteScalar(sbSql.ToString()));

            //记录事件
            sbSql = new StringBuilder();
            sbSql.AppendFormat(" select COUNT(*) from T_EnterDetail where ent_id in (select com_id from T_CompProInfo)");
            rDic.Add("event_count", HCQ2_Common.SQL.SqlHelper.ExecuteScalar(sbSql.ToString()));

            return rDic;
        }

        /// <summary>
        /// 获取失信企业信息
        /// </summary>
        /// <returns></returns>
        public List<Dictionary<string, object>> GetCompay()
        {
            List<Dictionary<string, object>> rList = new List<Dictionary<string, object>>();
            Dictionary<string, object> rDic = new Dictionary<string, object>();
            StringBuilder sbSql = new StringBuilder();
            sbSql.AppendFormat("select *,zxxy=(select code_name from T_ItemCodeMenum where item_id=(select item_id from T_ItemCode where item_code='ZXZT')");
            sbSql.AppendFormat(" and code_value=(select top 1 ent_type from T_EnterDetail where ent_id=T_CompProInfo.com_id order by ent_type desc)),[status]=(select count(*) from T_EnterDetail where");
            sbSql.AppendFormat(" ent_id=T_CompProInfo.com_id and solve_type=0) from T_CompProInfo where com_id in");
            sbSql.AppendFormat(" (select ent_id from T_EnterDetail where ent_type<>'01' and is_success=0)");
            DataTable dt = HCQ2_Common.SQL.SqlHelper.ExecuteDataTable(sbSql.ToString());
            if (dt == null || dt.Rows.Count <= 0)
                return rList;

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                rDic = new Dictionary<string, object>();
                rDic.Add("dwmc", dt.Rows[i]["dwmc"]);
                rDic.Add("tyshxydm", dt.Rows[i]["tyshxydm"]);
                rDic.Add("zzjgdm", dt.Rows[i]["zzjgdm"]);
                rDic.Add("gsdjzzhm", dt.Rows[i]["gsdjzzhm"]);
                rDic.Add("Fddbrxm", dt.Rows[i]["Fddbrxm"]);
                rDic.Add("Fddbrsfzhm", dt.Rows[i]["Fddbrsfzhm"]);
                rDic.Add("Status", Convert.ToInt32(dt.Rows[i]["status"]) > 0 ? "未处理" : "已处理");
                rDic.Add("LXR", dt.Rows[i]["LXR"]);
                rDic.Add("LXDH", dt.Rows[i]["LXDH"]);
                rDic.Add("ZYZT", dt.Rows[i]["zxxy"]);
                rList.Add(rDic);
            }

            return rList;
        }

        /// <summary>
        /// 获取征信记录事件信息
        /// </summary>
        /// <returns></returns>
        public List<Dictionary<string, object>> GetEvent()
        {
            List<Dictionary<string, object>> rList = new List<Dictionary<string, object>>();
            Dictionary<string, object> rDic = new Dictionary<string, object>();

            StringBuilder sbSql = new StringBuilder();
            sbSql.AppendFormat("select company_name=(select dwmc from T_CompProInfo where com_id=a.ent_id),* from T_EnterDetail a where ent_id in (select com_id from T_CompProInfo)");
            DataTable dt = HCQ2_Common.SQL.SqlHelper.ExecuteDataTable(sbSql.ToString());
            if (dt == null || dt.Rows.Count <= 0)
                return rList;

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                rDic = new Dictionary<string, object>();
                rDic.Add("ed_title", dt.Rows[i]["ed_title"]);
                rDic.Add("ed_reason", dt.Rows[i]["ed_reason"]);
                rDic.Add("ed_create", dt.Rows[i]["ed_create"]);
                if (!string.IsNullOrEmpty(dt.Rows[i]["ed_time"].ToString()))
                {
                    rDic.Add("ed_time", dt.Rows[i]["ed_time"].ToString());
                }
                else
                    rDic.Add("ed_time", "");
                //处理意见
                rDic.Add("solve_type", dt.Rows[i]["ed_note"].ToString());
                //处理状态
                rDic.Add("status", dt.Rows[i]["solve_type"].ToString() == "0" ? "未处理" : "已处理");
                //公司名称
                rDic.Add("company_name", dt.Rows[i]["company_name"]);
                rList.Add(rDic);
            }

            return rList;
        }

        /// <summary>
        /// 处理案件事件统计
        /// </summary>
        /// <returns></returns>
        public List<Dictionary<string, object>> SolveCount()
        {
            List<Dictionary<string, object>> rList = new List<Dictionary<string, object>>();
            Dictionary<string, object> rDic = new Dictionary<string, object>();

            StringBuilder sbSql = new StringBuilder();
            sbSql.AppendFormat("select SUM(pay_person)as person_count,SUM(pay_money) as total_money,COUNT(*)");
            sbSql.AppendFormat(" as solve_count from T_EnterDetail where case_type=0 and solve_type=1 ");
            DataTable dt = HCQ2_Common.SQL.SqlHelper.ExecuteDataTable(sbSql.ToString());

            rDic.Add("person_count", dt.Rows[0]["person_count"]);
            rDic.Add("total_money", dt.Rows[0]["total_money"]);
            rDic.Add("solve_count", dt.Rows[0]["solve_count"]);
            rList.Add(rDic);
            return rList;
        }
    }
}
