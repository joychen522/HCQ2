using HCQ2_Model.AfterSaleModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HCQ2_IBLL
{
    public partial interface IBB_CashDetailBLL
    {
        /// <summary>
        ///  获取缴纳金额数据集合
        /// </summary>
        /// <param name="ip_id">项目id</param>
        /// <param name="rows"></param>
        /// <param name="page"></param>
        /// <returns></returns>
        List<CashDetailModel> GetInitCashData(int ip_id, int rows, int page);
        /// <summary>
        ///  添加缴纳金额
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        int AddCashItem(CashDetailModel item);
        /// <summary>
        ///  编辑缴纳金额
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        int EditCashItem(CashDetailModel item, int cd_id);
    }
}
