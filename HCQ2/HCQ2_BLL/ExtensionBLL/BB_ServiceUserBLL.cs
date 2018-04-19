using System;
using System.Collections.Generic;
using System.Linq;
using HCQ2_Common;
using System.Text;
using System.Threading.Tasks;

namespace HCQ2_BLL
{
    public partial class BB_ServiceUserBLL : HCQ2_IBLL.IBB_ServiceUserBLL
    {
        /// <summary>
        ///  保存售后服务人员
        /// </summary>
        /// <param name="personData">采集数据</param>
        /// <returns></returns>
        public bool SaveServiceUserData(string personData)
        {
            if (string.IsNullOrEmpty(personData))
                return false;
            List<string> liStr = new List<string>(personData.Split(','));
            //1：删除数据
            //DBSession.IWGJG02_TemplateDAL.DeletePersonsData(liStr, rowid);
            //2：添加数据
            List<int> sb = new List<int>();
            foreach (string item in liStr)
            {
                if (item.Contains(":selected"))
                    sb.Add(Helper.ToInt(item.Split(':')[0]));
                else
                {
                    //并未保存过，需要添加
                    sb.Add(Helper.ToInt(item));
                    DBSession.IBB_ServiceUserDAL.Add(new HCQ2_Model.BB_ServiceUser { user_id=Helper.ToInt(item) });
                }
            }
            //删除被取消的记录
            DBSession.IBB_ServiceUserDAL.Delete(s => !sb.Contains(s.user_id));
            return true;
        }
        /// <summary>
        ///  获取所有已被分配的售后人员数据集合
        /// </summary>
        /// <returns></returns>
        public List<HCQ2_Model.ExtendsionModel.ServiceUserModel> GetServiceUser()
        {
            return DBSession.IBB_ServiceUserDAL.GetServiceUser();
        }
        /// <summary>
        ///  获取字典
        /// </summary>
        /// <returns></returns>
        public List<HCQ2_Model.FormatModel.CodeItemsModel> GetServiceUserDictionary()
        {
            List<HCQ2_Model.ExtendsionModel.ServiceUserModel> list = GetServiceUser();
            if (null == list || list.Count <= 0)
                return null;
            List<HCQ2_Model.FormatModel.CodeItemsModel> model = new List<HCQ2_Model.FormatModel.CodeItemsModel>();
            foreach (var item in list)
                model.Add(new HCQ2_Model.FormatModel.CodeItemsModel
                {
                    CodeText = item.user_name,
                    CodeValue = item.user_id.ToString()
                });
            return model;
        }
    }
}
