using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HCQ2_IBLL
{
    /// <summary>
    ///  请假管理业务层接口定义
    /// </summary>
    public partial interface IT_AskManagerBLL
    {
        /// <summary>
        ///  获取请假管理数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        List<HCQ2_Model.ExtendsionModel.T_AskManagerModel> SelectAskManagerData(HCQ2_Model.SelectModel.T_AskManagerModel model);
        /// <summary>
        ///  统计符合条件的记录数据量
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        int SelectCountAskUserData(HCQ2_Model.SelectModel.T_AskManagerModel model);
        /// <summary>
        ///  添加请假数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        int AddAskModel(HCQ2_Model.ExtendsionModel.T_AskManagerModel model);
        /// <summary>
        ///  编辑请假数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        int ModifyAskModel(HCQ2_Model.ExtendsionModel.T_AskManagerModel model);
    }
}
