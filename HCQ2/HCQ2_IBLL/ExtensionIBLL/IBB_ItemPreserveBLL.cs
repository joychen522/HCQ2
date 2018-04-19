using HCQ2_Model.AfterSaleModel;
using HCQ2_Model.Constant;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HCQ2_IBLL
{
    public partial interface IBB_ItemPreserveBLL
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
        ///  添加台账记录
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        int AddItem(ItemPreserveModel item);
        /// <summary>
        ///  编辑台账记录
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        int EditItem(ItemPreserveModel item, int id);
        /// <summary>
        ///  根据用户ID获取 区域结构树
        /// </summary>
        /// <param name="user_id"></param>
        /// <returns></returns>
        List<HCQ2_Model.TreeModel.B01TreeModel> GetAreaData(int user_id);
        /// <summary>
        ///  获取用户授权 区域信息集合
        /// </summary>
        /// <param name="user_id"></param>
        /// <returns></returns>
        List<AreaModel> GetPermissAreaData(int user_id);
    }
}
