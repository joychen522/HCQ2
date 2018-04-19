using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HCQ2_IDAL
{
    /// <summary>
    ///  单位--权限关系表数据层接口
    /// </summary>
    public partial interface IT_B01PermissRelationDAL
    {
        /// <summary>
        ///  需要删除的权限配置
        /// </summary>
        /// <param name="unit_ids">单位代码集合</param>
        /// <param name="per_id">权限代码</param>
        /// <returns></returns>
        int Delete(List<string>unit_ids, int per_id);
    }
}
