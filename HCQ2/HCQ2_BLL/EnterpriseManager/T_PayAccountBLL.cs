using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HCQ2_Model;
using HCQ2_Model.ViewModel;
using System.Web.Mvc;
using System.Data;

namespace HCQ2_BLL
{
    public partial class T_PayAccountBLL : HCQ2_IBLL.IT_PayAccountBLL
    {
        /// <summary>
        /// 获取所有的项目工资账户
        /// </summary>
        /// <returns></returns>
        public List<T_PayAccount> GetPayAccount()
        {
            return Select(o => o.if_remove == 0);
        }

        /// <summary>
        /// 根据项目编号获取账户信息
        /// </summary>
        /// <param name="UnitID"></param>
        /// <returns></returns>
        public List<T_PayAccount> GetByUnitID(string UnitID)
        {
            return Select(o => o.UnitID == UnitID).ToList();
        }

        /// <summary>
        /// 根据ID获取专户
        /// </summary>
        /// <param name="pay_id"></param>
        /// <returns></returns>
        public T_PayAccount GetByPayID(int pay_id)
        {
            return Select(o => o.pay_id == pay_id).FirstOrDefault();
        }

        /// <summary>
        /// 获取页面显示的数据源
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public TableModel GetPageViewSoure(object obj)
        {
            FormCollection param = (FormCollection)obj;
            int rows = int.Parse(param["rows"]);
            int page = int.Parse(param["page"]);
            int user_id = HCQ2UI_Helper.OperateContext.Current.Usr.user_id;
            List<B01> unitList = new B01BLL().GetPerUnitByUserID(user_id);
            string unitidInfo = "'" + string.Join("','", unitList.Select(o => o.UnitID)) + "'";
            List<T_PayAccount> payList = new List<T_PayAccount>();

            StringBuilder sbSql = new StringBuilder();
            sbSql.AppendFormat("select * from T_PayAccount where if_remove=0 and UnitID in ({0}) ", unitidInfo);

            if (!string.IsNullOrEmpty(param["bank_name"])) {
                sbSql.AppendFormat(" and khh like '{0}' ", param["bank_name"]);
            }
            DataTable dt = HCQ2_Common.SQL.SqlHelper.ExecuteDataTable(sbSql.ToString());
            payList = HCQ2_Common.Data.DataTableHelper.DataTableToIList<T_PayAccount>(dt);
            TableModel model = new TableModel();
            model.rows = payList.Skip((rows * page) - rows).Take(rows);
            model.total = payList.Count();
            return model;
        }

        /// <summary>
        /// 保存或者编辑工资专户
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public bool SavePayAccount(object obj)
        {
            FormCollection param = (FormCollection)obj;
            T_PayAccount pay = new T_PayAccount();

            pay.UnitID = param["UnitID"];
            pay.UnitName = new B01BLL().GetByUnitID(param["UnitID"]).UnitName;
            pay.ssyh = param["ssyh"];
            pay.khmc = param["khmc"];
            pay.zh = param["zh"];
            pay.khh = param["khh"];
            pay.pzzl = param["pzzl"];
            pay.pzhm = param["pzhm"];
            pay.ye = decimal.Parse(param["ye"]);
            pay.if_remove = 0;

            string pay_id = param["JianDie"];
            if (string.IsNullOrEmpty(pay_id))
            {
                //新增
                pay.create_date = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                pay.create_name = HCQ2UI_Helper.OperateContext.Current.Usr.user_id;
                return Add(pay) > 0;
            }
            else {
                pay.update_date = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                pay.update_name = HCQ2UI_Helper.OperateContext.Current.Usr.user_id;
                int payId = int.Parse(pay_id);
                return Modify(pay, o => o.pay_id == payId, "UnitID", "UnitName", "ssyh",
                    "khmc", "zh", "khh", "pzzl", "pzhm", "ye") > 0;
            }
        }

        /// <summary>
        /// 删除工资专户信息
        /// </summary>
        /// <param name="pay_id"></param>
        /// <returns></returns>
        public bool DeletePayAccount(int pay_id)
        {
            T_PayAccount pay = new T_PayAccount();
            pay.if_remove = 1;
            return Modify(pay, o => o.pay_id == pay_id, "if_remove") > 0;
        }
    }
}
