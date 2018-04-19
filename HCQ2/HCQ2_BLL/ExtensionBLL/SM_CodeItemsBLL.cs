using HCQ2_Model.FormatModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HCQ2_BLL
{
    public partial class SM_CodeItemsBLL:HCQ2_IBLL.ISM_CodeItemsBLL
    {
        /// <summary>
        ///  根据code获取字典
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public List<CodeItemsModel> GetOldSysCode(string code)
        {
            if (string.IsNullOrEmpty(code))
                return null;
            return DBSession.ISM_CodeItemsDAL.GetOldSysCode(code);
        }
    }
}
