using HCQ2_IBLL;
using HCQ2_Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HCQ2_BLL
{
    public partial class SM_CodeItemsBLL : ISM_CodeItemsBLL
    {
        /// <summary>
        /// 获取所有字典信息
        /// </summary>
        /// <returns></returns>
        public List<SM_CodeItems> GetCodeItems()
        {
            return base.Select(o => o.CodeID != "");
        }

        /// <summary>
        /// 根据CodeId获取字典信息
        /// </summary>
        /// <param name="codeId"></param>
        /// <returns></returns>
        public List<SM_CodeItems> GetCodeItemByCodeID(string codeId)
        {
            return base.Select(o => o.CodeID == codeId);
        }

        /// <summary>
        /// 根据CodeItemID获取字典信息
        /// </summary>
        /// <param name="codeItemId"></param>
        /// <returns></returns>
        public List<SM_CodeItems> GetCodeItemByCodeItemID(string codeItemId)
        {
            return base.Select(o => o.CodeItemID == codeItemId);
        }

        /// <summary>
        /// 获取具体的字典值
        /// </summary>
        /// <param name="codeId"></param>
        /// <param name="codeItemID"></param>
        /// <returns></returns>
        public SM_CodeItems GetCodeItemDetail(string codeId, string codeItemID)
        {
            return base.Select(o => o.CodeID == codeId && o.CodeItemID == codeItemID).FirstOrDefault();
        }

        /// <summary>
        /// 根据具体的字典值ID
        /// </summary>
        /// <param name="codeId"></param>
        /// <param name="codeItemName"></param>
        /// <returns></returns>
        public SM_CodeItems GetCodeItemID(string codeId, string codeItemName)
        {
            return base.Select(o => o.CodeID == codeId && o.CodeItemName == codeItemName).FirstOrDefault();
        }

        /// <summary>
        /// 根据字典代码获取整个数据字典的目录
        /// </summary>
        /// <returns></returns>
        public List<Dictionary<string, object>> GetCodeItemTree(List<SM_CodeItems> list)
        {
            List<Dictionary<string, object>> listDic = new List<Dictionary<string, object>>();
            Dictionary<string, object> dic = new Dictionary<string, object>();

            if (list == null)
                return null;

            List<SM_CodeItems> listFirst = list.Where(o => o.Parent == ".")
                .OrderBy(n => n.CodeOrder).ToList();
            foreach (var item in listFirst)
            {
                dic = new Dictionary<string, object>();
                dic.Add("text", item.CodeItemName);
                dic.Add("codeitemid", item.CodeItemID);
                dic.Add("codeid", item.CodeID);
                dic.Add("parent", item.Parent);
                var data = list.Where(o => o.Parent == item.CodeItemID);
                if (data.Count() > 0) {
                    dic.Add("nodes", GetChildTree(list,data.ToList()));
                }
                listDic.Add(dic);
            }

            return listDic;
        }

        /// <summary>
        /// 添加子节点
        /// </summary>
        /// <param name="list"></param>
        /// <param name="listChild"></param>
        /// <returns></returns>
        public List<Dictionary<string, object>> GetChildTree(List<SM_CodeItems> list,List<SM_CodeItems> listChild)
        {
            List<Dictionary<string, object>> listDic = new List<Dictionary<string, object>>();
            Dictionary<string, object> dic = new Dictionary<string, object>();

            foreach (var item in listChild)
            {
                dic = new Dictionary<string, object>();
                dic.Add("text", item.CodeItemName);
                dic.Add("codeitemid", item.CodeItemID);
                dic.Add("codeid", item.CodeID);
                dic.Add("parent", item.Parent);
                var data = list.Where(o => o.Parent == item.CodeItemID);
                if (data.Count() > 0)
                {
                    dic.Add("nodes", GetChildTree(list, data.ToList()));
                }
                listDic.Add(dic);
            }

            return listDic;
        }
    }
}
