using HCQ2_Model.AfterSaleModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HCQ2_BLL
{
    public partial class BB_CashDetailBLL:HCQ2_IBLL.IBB_CashDetailBLL
    {
        /// <summary>
        ///  获取缴纳金额数据集合
        /// </summary>
        /// <param name="ip_id"></param>
        /// <param name="rows"></param>
        /// <param name="page"></param>
        /// <returns></returns>
        public List<CashDetailModel> GetInitCashData(int ip_id, int rows, int page)
        {
            List<HCQ2_Model.BB_CashDetail> list = Select<int>(s => s.ip_id == ip_id, s => s.cd_id, page, rows).ToList();
            if (null == list)
                return null;
            List<CashDetailModel> cList = new List<CashDetailModel>();
            foreach (var item in list)
                cList.Add(new CashDetailModel
                {
                    cd_id = item.cd_id,
                    ip_id = item.ip_id,
                    cash_start_date = item.cash_start_date.ToString("yyyy-MM-dd"),
                    cash_end_date = item.cash_end_date.ToString("yyyy-MM-dd"),
                    cash_money = item.cash_money
                });
            return cList;
        }
        /// <summary>
        ///  添加缴纳金额
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public int AddCashItem(CashDetailModel item)
        {
            if (null == item)
                return 0;
            HCQ2_Model.BB_CashDetail model = new HCQ2_Model.BB_CashDetail
            {
                ip_id = item.ip_id,
                cash_start_date = DateTime.ParseExact(item.cash_start_date, "yyyy-MM-dd", new System.Globalization.CultureInfo("zh-CN")),
                cash_end_date = DateTime.ParseExact(item.cash_end_date, "yyyy-MM-dd", new System.Globalization.CultureInfo("zh-CN")),
                cash_money = item.cash_money
            };
            return Add(model);
        }
        /// <summary>
        ///  编辑缴纳金额
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public int EditCashItem(CashDetailModel item,int cd_id)
        {
            if (null == item)
                return 0;
            HCQ2_Model.BB_CashDetail model = new HCQ2_Model.BB_CashDetail
            {
                ip_id = item.ip_id,
                cash_start_date = DateTime.ParseExact(item.cash_start_date, "yyyy-MM-dd", new System.Globalization.CultureInfo("zh-CN")),
                cash_end_date = DateTime.ParseExact(item.cash_end_date, "yyyy-MM-dd", new System.Globalization.CultureInfo("zh-CN")),
                cash_money = item.cash_money
            };
            return Modify(model, s => s.cd_id == cd_id, "cash_start_date", "cash_end_date", "cash_money");
        }
    }
}
