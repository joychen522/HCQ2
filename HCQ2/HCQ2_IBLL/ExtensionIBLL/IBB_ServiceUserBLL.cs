using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HCQ2_IBLL
{
    public partial interface IBB_ServiceUserBLL
    {
        /// <summary>
        ///  保存售后服务人员
        /// </summary>
        /// <param name="personData">采集数据</param>
        /// <returns></returns>
        bool SaveServiceUserData(string personData);
        /// <summary>
        ///  获取所有已被分配的售后人员数据集合
        /// </summary>
        /// <returns></returns>
        List<HCQ2_Model.ExtendsionModel.ServiceUserModel> GetServiceUser();
        /// <summary>
        ///  获取字典
        /// </summary>
        /// <returns></returns>
        List<HCQ2_Model.FormatModel.CodeItemsModel> GetServiceUserDictionary();
    }
}
