using HCQ2_Model.AfterSaleModel;
using HCQ2_Model.Constant;
using HCQ2_Model.TreeModel;
using System.Collections.Generic;
using HCQ2_Model;
using System;

namespace HCQ2_BLL
{
    public partial class BB_ItemPreserveBLL:HCQ2_IBLL.IBB_ItemPreserveBLL
    {
        /// <summary>
        ///  根据条件 获取项目台账数据集合
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public List<ItemPreserveModel> GetInitData(ItemPreserveParam param)
        {
            if (null != param)
                return DBSession.IBB_ItemPreserveDAL.GetInitData(param);
            return null;
        }
        /// <summary>
        ///  根据条件 获取项目台账记录总数
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public int GetCountData(ItemPreserveParam param)
        {
            if (null != param)
                return DBSession.IBB_ItemPreserveDAL.GetCountData(param);
            return 0;
        }
        /// <summary>
        ///  添加台账记录
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public int AddItem(ItemPreserveModel item)
        {
            if (null == item)
                return 0;
            BB_ItemPreserve model = new BB_ItemPreserve
            {
                unit_name = item.unit_name,
                unit_code = item.unit_code,
                ip_status = item.ip_status,
                pact_money = item.pact_money,
                pay_money = item.pay_money,
                area_code = item.area_code,
                pay_date = DateTime.ParseExact(item.pay_date, "yyyy-MM-dd", new System.Globalization.CultureInfo("zh-CN")),
                pay_cash_money=item.pay_cash_money,
                pra_cash_money = item.pra_cash_money,
                duty_person = item.duty_person,
                touch_phone = item.touch_phone,
                pact_start = DateTime.ParseExact(item.pact_start, "yyyy-MM-dd", new System.Globalization.CultureInfo("zh-CN")),
                record_name = item.record_name,
                user_note = item.user_note
            };
            return base.Add(model);
        }
        /// <summary>
        ///  编辑台账记录
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public int EditItem(ItemPreserveModel item,int id)
        {
            if (null == item)
                return 0;
            BB_ItemPreserve model = new BB_ItemPreserve
            {
                unit_name = item.unit_name,
                unit_code = item.unit_code,
                ip_status = item.ip_status,
                pact_money = item.pact_money,
                pay_money = item.pay_money,
                area_code = item.area_code,
                pay_date = DateTime.ParseExact(item.pay_date, "yyyy-MM-dd", new System.Globalization.CultureInfo("zh-CN")),
                pra_cash_money = item.pra_cash_money,
                pay_cash_money=item.pay_cash_money,
                duty_person = item.duty_person,
                touch_phone = item.touch_phone,
                pact_start = DateTime.ParseExact(item.pact_start, "yyyy-MM-dd", new System.Globalization.CultureInfo("zh-CN")),
                record_name = item.record_name,
                update_date = DateTime.Now,
                user_note = item.user_note
            };
            return Modify(model, s => s.ip_id == id, "unit_name", "unit_code", "ip_status", "pact_money", "pay_money", "pay_date", "area_code", "pay_cash_money", "pra_cash_money", "duty_person", "touch_phone", "bag_file", "pact_start", "record_name", "update_date", "user_note");
        }
        /// <summary>
        ///  获取用户授权 区域信息集合
        /// </summary>
        /// <param name="user_id"></param>
        /// <returns></returns>
         public List<AreaModel> GetPermissAreaData(int user_id)
        {
            if (user_id <= 0)
                return null;
            return DBSession.IBB_ItemPreserveDAL.GetPermissAreaData(user_id);
        }
        /// <summary>
        ///  根据用户ID获取 区域结构树
        /// </summary>
        /// <param name="user_id"></param>
        /// <returns></returns>
        public List<B01TreeModel> GetAreaData(int user_id)
        {
            List<AreaModel> areaList = GetPermissAreaData(user_id);
            if (areaList == null || areaList.Count <= 0)
                return null;
            List<B01TreeModel> listModel = new List<B01TreeModel>();
            //查找一级目录
            List<AreaModel> first = areaList.FindAll(s => s.Parent == ".");
            if (first.Count > 0)
            {
                foreach(var item in first)
                {
                    listModel.Add(new B01TreeModel()
                    {
                        text = item.CodeItemName,
                        unitID = item.CodeItemID,
                        keyChild = item.Child,
                        JPSign = item.JPSign,
                        nodes = GetModelById(areaList, item.CodeItemID)
                    });
                }
            }
            return listModel;
        }
        private List<B01TreeModel> GetModelById(List<AreaModel> list, string unitID)
        {
            List<B01TreeModel> listModel = null;
            List<AreaModel> listKey = list.FindAll(s => s.Parent == unitID);
            if (listKey.Count > 0)
            {
                listModel = new List<B01TreeModel>();
                B01TreeModel temp = null;
                for (int i = 0; i < listKey.Count; i++)
                {
                    temp = new B01TreeModel();
                    temp.text = listKey[i].CodeItemName;
                    temp.unitID = listKey[i].CodeItemID;
                    temp.keyChild = listKey[i].Child;
                    temp.JPSign= listKey[i].JPSign;
                    if (temp.keyChild > 0)
                        temp.nodes = GetModelById(list, listKey[i].CodeItemID);
                    listModel.Add(temp);
                }
            }
            return listModel;
        }
    }
}
