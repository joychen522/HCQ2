using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HCQ2_IBLL
{
    public partial interface IBB_PactDetailFlieBLL
    {
        /// <summary>
        ///  获取缴纳金额数据集合
        /// </summary>
        /// <param name="ip_id">项目id</param>
        /// <param name="rows"></param>
        /// <param name="page"></param>
        /// <returns></returns>
        List<HCQ2_Model.BB_PactDetailFlie> GetInitPactData(int ip_id, int rows, int page);
        /// <summary>
        ///  添加缴纳金额
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        int AddCashItem(HCQ2_Model.BB_PactDetailFlie item);
        /// <summary>
        ///  编辑缴纳金额
        /// </summary>
        /// <param name="item"></param>
        /// <param name="pd_id"></param>
        /// <returns></returns>
        int EditCashItem(HCQ2_Model.BB_PactDetailFlie item, int pd_id);
    }
}
