using HCQ2_Model.ExtendsionModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HCQ2_IBLL
{
    public partial interface IT_CompProInfoBLL
    {
        List<ComProModel> GetComProData(string unitID);
        /// <summary>
        ///  获取企业单位信息
        /// </summary>
        /// <returns></returns>
        List<HCQ2_Model.TreeModel.ProInfoTreeModel> GetUnitData(int use_status);
    }
}
