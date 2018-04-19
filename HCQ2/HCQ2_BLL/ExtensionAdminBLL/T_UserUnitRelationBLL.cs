using System.Collections.Generic;
using System.Linq;
using HCQ2_Model;

namespace HCQ2_BLL
{
    public partial class T_UserUnitRelationBLL:HCQ2_IBLL.IT_UserUnitRelationBLL
    {
        public List<Dictionary<string, object>> GetUserUnitDataById(int user_id)
        {
            //封装单位键值对数据
            List<Dictionary<string, object>> listUnit = new List<Dictionary<string, object>>();
            Dictionary<string, object> map = null;
            //1 获取所有单位
            List<B01> listAll = DBSession.IB01DAL.Select(s => (!string.IsNullOrEmpty(s.UnitName))).ToList();
            //2 获取用户对应单位
            List<T_UserUnitRelation> listUser = Select(s => s.user_id == user_id);
            //3 设置单位
            foreach (B01 unit in listAll)
            {
                map = new Dictionary<string, object>();
                map.Add("id",unit.UnitID);
                map.Add("pId", unit.KeyParent);
                map.Add("name", unit.UnitName);
                //3.1当前节点是否被选中
                var temp = listUser.Where(s => s.unit_id == unit.UnitID).ToList();
                if (temp.Count> 0)
                    map.Add("checked", true);
                //3.2 是否有子节点
                if (unit.KeyChild > 0)
                {
                    map.Add("open",true);
                    map.Add("children", GetChildData(listAll, listUser, unit.UnitID));
                }
                    
                listUnit.Add(map);
            }
            return listUnit;
        }

        public bool SaveUserUnitData(string userData, int user_id)
        {
            //保存之前先清理
            Delete(s => s.user_id == user_id);
            if (string.IsNullOrEmpty(userData))
                return true;
            List<T_UserUnitRelation> list = new List<T_UserUnitRelation>();
            list = HCQ2_Common.JsonHelper.JsonStrToList(userData, list);
            int addCount = 1;
            if (list != null && list.Count > 0)
                foreach (T_UserUnitRelation item in list)
                    if(Add(item)<=0)
                        addCount = 0;
            return addCount > 0 ? true : false;
        }

        /// <summary>
        ///  递归获取子节点
        /// </summary>
        /// <param name="listAll"></param>
        /// <param name="parentID"></param>
        /// <returns></returns>
        private List<Dictionary<string, object>> GetChildData(List<B01> listAll, List<T_UserUnitRelation> listUser, string parentID)
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
                    var temp = listUser.Where(s => s.unit_id == unit.UnitID).ToList();
                    if (temp.Count > 0)
                        map.Add("checked", true);
                    //1.2 是否有子节点
                    if (unit.KeyChild > 0)
                    {
                        map.Add("open", true);
                        map.Add("children", GetChildData(listAll, listUser, unit.UnitID));
                    }
                }
            }
            return listChild;
        }
    }
}
