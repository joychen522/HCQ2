using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HCQ2_IDAL
{
    public partial interface IBB_ServiceUserDAL
    {
        /// <summary>
        ///  获取所有已被分配的售后人员数据集合
        /// </summary>
        /// <returns></returns>
        List<HCQ2_Model.ExtendsionModel.ServiceUserModel> GetServiceUser();
    }
}
