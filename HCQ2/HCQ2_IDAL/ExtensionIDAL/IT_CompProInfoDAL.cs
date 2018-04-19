using HCQ2_Model.ExtendsionModel;
using HCQ2_Model.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HCQ2_Model;

namespace HCQ2_IDAL
{
    public partial interface IT_CompProInfoDAL
    {
        /// <summary>
        ///  获取指定企业的所属队伍
        /// </summary>
        /// <param name="unitID"></param>
        /// <returns></returns>
        List<ComProModel> GetComProData(string unitID);
        /// <summary>
        /// 获取页面显示数据源
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        List<ComProInfoDalModel> GetPageComInfoModle(ComProInfoModel obj);

        /// <summary>
        /// 获取已经被项目绑定的企业
        /// </summary>
        /// <returns></returns>
        List<T_CompProInfo> GetBindProjectCom();
    }
}
