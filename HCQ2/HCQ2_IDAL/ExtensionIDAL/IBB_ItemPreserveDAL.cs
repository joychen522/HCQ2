using HCQ2_Model.AfterSaleModel;
using HCQ2_Model.Constant;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HCQ2_IDAL
{
    /// <summary>
    ///  项目台账 数据接口层定义
    /// </summary>
    public partial interface IBB_ItemPreserveDAL
    {
        /// <summary>
        ///  根据条件 获取项目台账数据集合
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        List<ItemPreserveModel> GetInitData(ItemPreserveParam param);
        /// <summary>
        ///  根据条件 获取项目台账记录总数
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        int GetCountData(ItemPreserveParam param);
        /// <summary>
        ///  获取用户 授权区域
        /// </summary>
        /// <param name="user_id"></param>
        /// <returns></returns>
        List<AreaModel> GetPermissAreaData(int user_id);
    }
}
