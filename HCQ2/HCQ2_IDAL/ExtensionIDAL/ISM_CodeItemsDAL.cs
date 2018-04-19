using HCQ2_Model.FormatModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HCQ2_IDAL
{
    public partial interface ISM_CodeItemsDAL
    {
        /// <summary>
        ///  根据code获取字典
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        List<CodeItemsModel> GetOldSysCode(string code);
    }
}
