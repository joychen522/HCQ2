using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HCQ2_BLL
{
    public partial class BB_PactDetailFlieBLL:HCQ2_IBLL.IBB_PactDetailFlieBLL
    {
        /// <summary>
        ///  获取缴纳金额数据集合
        /// </summary>
        /// <param name="ip_id">项目id</param>
        /// <param name="rows"></param>
        /// <param name="page"></param>
        /// <returns></returns>
        public List<HCQ2_Model.BB_PactDetailFlie> GetInitPactData(int ip_id, int rows, int page)
        {
            List<HCQ2_Model.BB_PactDetailFlie> list = Select<int>(s => s.ip_id == ip_id, s => s.pd_id, page, rows).ToList();
            if (null == list)
                return null;
            return list;
        }
        /// <summary>
        ///  添加缴纳金额
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public int AddCashItem(HCQ2_Model.BB_PactDetailFlie item)
        {
            return 0;
        }
        /// <summary>
        ///  编辑缴纳金额
        /// </summary>
        /// <param name="item"></param>
        /// <param name="pd_id"></param>
        /// <returns></returns>
        public int EditCashItem(HCQ2_Model.BB_PactDetailFlie item, int pd_id)
        {
            return 0;
        }
    }
}
