using HCQ2_Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HCQ2_BLL
{
    public partial class T_AreaPermissRelationBLL : HCQ2_IBLL.IT_AreaPermissRelationBLL
    {
        public List<Dictionary<string, object>> GetLimitAreaDataById(int per_id)
        {
            //封装单位键值对数据
            List<Dictionary<string, object>> listUnit = new List<Dictionary<string, object>>();
            Dictionary<string, object> map = null;
            //1 获取所有区域
            List<SM_CodeItems> listAll = DBSession.ISM_CodeItemsDAL.Select(s => s.CodeID.Equals("AB")).ToList();
            //2 获取权限对应区域
            List<T_AreaPermissRelation> listPer = Select(s => s.per_id == per_id);
            //3 设置区域
            foreach (SM_CodeItems area in listAll)
            {
                map = new Dictionary<string, object>();
                map.Add("id", area.CodeItemID);
                map.Add("pId", area.Parent);
                map.Add("name", area.CodeItemName);
                //3.1当前节点是否被选中
                var temp = listPer.Where(s => s.area_code == area.CodeItemID).ToList();
                if (temp.Count > 0)
                {
                    map.Add("checked", true);
                    map.Add("everstate", "checked");//标记
                }
                else
                    map.Add("everstate", "uncheck");//标记

                //3.2 是否有子节点
                if (area.Child > 0)
                {
                    //map.Add("open", true);
                    map.Add("children", GetChildData(listAll, listPer, area.CodeItemID));
                }
                listUnit.Add(map);
            }
            return listUnit;
        }

        public bool SaveAreaPerData(string userData, string reak, int per_id)
        {
            if (reak.Equals("undeal"))
                return true;//无需后端处理
            if (per_id <= 0)
                return false;//权限主键值有误
            //1. 判断是否删除全部
            if (string.IsNullOrEmpty(userData) || userData.Replace(";", "").Trim().Length == 0)
            {
                Delete(s => s.per_id == per_id);
                return true;
            }
            //2. 保存之前删除之前设置的权限
            string[] menu = userData.Split(';');//0添加，1删除
            if (menu.Length > 1 && !string.IsNullOrEmpty(menu[1].Trim(',')))
                DBSession.IT_AreaPermissRelationDAL.Delete(new List<string>(menu[1].Trim(',').Split(',')), per_id);
            //3. 添加前先判断
            if (string.IsNullOrEmpty(menu[0].Trim(',').Trim()))
                return true;
            string[] str = menu[0].Trim(',').Split(',');//添加
            if (str.Length > 0)
            {
                foreach (string item in str)
                {
                    DBSession.IT_AreaPermissRelationDAL.Add(
                        new T_AreaPermissRelation()
                        {
                            area_code = item,
                            per_id = per_id
                        });
                }
            }
            return true;
        }

        /// <summary>
        ///  递归获取子节点
        /// </summary>
        /// <param name="listAll"></param>
        /// <param name="parentID"></param>
        /// <returns></returns>
        private List<Dictionary<string, object>> GetChildData(List<SM_CodeItems> listAll, List<T_AreaPermissRelation> listPer, string parentID)
        {
            List<Dictionary<string, object>> listChild = new List<Dictionary<string, object>>();
            List<SM_CodeItems> list = listAll.Where(s => s.Parent == parentID).ToList();
            Dictionary<string, object> map = null;
            if (list.Count > 0)
            {
                foreach (SM_CodeItems area in list)
                {
                    map = new Dictionary<string, object>();
                    map.Add("id", area.CodeItemID);
                    map.Add("pId", area.Parent);
                    map.Add("name", area.CodeItemName);
                    //1.1当前节点是否被选中
                    var temp = listPer.Where(s => s.area_code == area.CodeItemID).ToList();
                    if (temp.Count > 0)
                        map.Add("checked", true);
                    //1.2 是否有子节点
                    if (area.Child > 0)
                    {
                        //map.Add("open", true);
                        map.Add("children", GetChildData(listAll, listPer, area.CodeItemID));
                    }
                }
            }
            return listChild;
        }
    }
}
