using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HCQ2_IDAL
{
    /// <summary>
    ///  请假管理数据层接口定义
    /// </summary>
    public partial interface IT_AskManagerDAL
    {
        /// <summary>
        ///  根据条件查询请假管理数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        List<HCQ2_Model.ExtendsionModel.T_AskManagerModel> SelectAskData(HCQ2_Model.SelectModel.T_AskManagerModel model);
        /// <summary>
        ///  统计数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        int SelectCountData(HCQ2_Model.SelectModel.T_AskManagerModel model);
    }
}
