using HCQ2_Model.AfterSaleModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HCQ2_IDAL
{
    public partial interface IBB_FacilityPreserveDAL
    {
        /// <summary>
        ///  根据条件 获取设备数据集合
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        List<FacilityPreserveModel> GetInitData(ItemPreserveParam param);
        /// <summary>
        ///  根据条件 获取项目台账记录总数
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        int GetCountData(ItemPreserveParam param);
    }
}
