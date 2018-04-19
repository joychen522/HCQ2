using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HCQ2_Model;

namespace HCQ2_BLL
{
   public partial class T_B01PermissRelationBLL:HCQ2_IBLL.IT_B01PermissRelationBLL
    {
        public List<Dictionary<string, object>> GetLimitUnitDataById(int per_id)
        {
            //封装单位键值对数据
            List<Dictionary<string, object>> listUnit = new List<Dictionary<string, object>>();
            Dictionary<string, object> map = null;
            //1 获取所有单位
            List<B01> listAll = DBSession.IB01DAL.Select(s => (!string.IsNullOrEmpty(s.UnitName))).ToList();
            //2 获取权限对应单位
            List<T_B01PermissRelation> listPer = Select(s => s.per_id == per_id);
            //3 设置单位
            foreach (B01 unit in listAll)
            {
                map = new Dictionary<string, object>();
                map.Add("id", unit.UnitID);
                map.Add("pId", unit.KeyParent);
                map.Add("name", unit.UnitName);
                //3.1当前节点是否被选中
                var temp = listPer.Where(s => s.UnitID == unit.UnitID).ToList();
                if (temp.Count > 0){
                    map.Add("checked", true);
                    map.Add("everstate", "checked");//标记
                }else
                    map.Add("everstate", "uncheck");//标记

                //3.2 是否有子节点
                if (unit.KeyChild > 0)
                {
                    map.Add("open", true);
                    map.Add("children", GetChildData(listAll, listPer, unit.UnitID));
                }

                listUnit.Add(map);
            }
            return listUnit;
        }

       public bool SaveUserUnitData(string userData,string reak, int per_id)
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
                DBSession.IT_B01PermissRelationDAL.Delete(new List<string>(menu[1].Trim(',').Split(',')), per_id);
            //3. 添加前先判断
            if (string.IsNullOrEmpty(menu[0].Trim(',').Trim()))
                return true;
            string[] str = menu[0].Trim(',').Split(',');//添加
            if (str.Length > 0)
            {
                foreach (string item in str)
                {
                    DBSession.IT_B01PermissRelationDAL.Add(
                        new T_B01PermissRelation()
                        {
                            UnitID = item,
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
        private List<Dictionary<string, object>> GetChildData(List<B01> listAll, List<T_B01PermissRelation> listPer, string parentID)
        {
            List<Dictionary<string, object>> listChild = new List<Dictionary<string, object>>();
            List<B01> list = listAll.Where(s => s.KeyParent == parentID).ToList();
            Dictionary<string, object> map = null;
            if (list.Count > 0)
            {
                foreach (B01 unit in list)
                {
                    map = new Dictionary<string, object>();
                    map.Add("id", unit.UnitID);
                    map.Add("pId", unit.KeyParent);
                    map.Add("name", unit.UnitName);
                    //1.1当前节点是否被选中
                    var temp = listPer.Where(s => s.UnitID == unit.UnitID).ToList();
                    if (temp.Count > 0)
                        map.Add("checked", true);
                    //1.2 是否有子节点
                    if (unit.KeyChild > 0)
                    {
                        map.Add("open", true);
                        map.Add("children", GetChildData(listAll, listPer, unit.UnitID));
                    }
                }
            }
            return listChild;
        }
    }
}
