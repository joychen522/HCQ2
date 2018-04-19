using HCQ2_Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HCQ2_IBLL
{
    public partial interface ISM_CodeItemsBLL
    {
        /// <summary>
        /// 获取所有字典信息
        /// </summary>
        /// <returns></returns>
        List<SM_CodeItems> GetCodeItems();

        /// <summary>
        /// 根据CodeId获取字典信息
        /// </summary>
        /// <param name="codeId"></param>
        /// <returns></returns>
        List<SM_CodeItems> GetCodeItemByCodeID(string codeId);

        /// <summary>
        /// 根据CodeItemID获取字典信息
        /// </summary>
        /// <param name="codeItemId"></param>
        /// <returns></returns>
        List<SM_CodeItems> GetCodeItemByCodeItemID(string codeItemId);

        /// <summary>
        /// 获取具体的字典值
        /// </summary>
        /// <param name="codeId"></param>
        /// <param name="codeItemID"></param>
        /// <returns></returns>
        SM_CodeItems GetCodeItemDetail(string codeId, string codeItemID);

        /// <summary>
        /// 根据具体的字典值ID
        /// </summary>
        /// <param name="codeId"></param>
        /// <param name="codeItemName"></param>
        /// <returns></returns>
        SM_CodeItems GetCodeItemID(string codeId,string codeItemName);

        /// <summary>
        /// 根据字典代码获取整个数据字典的目录
        /// </summary>
        /// <returns></returns>
        List<Dictionary<string, object>> GetCodeItemTree(List<SM_CodeItems> list);
    }
}
