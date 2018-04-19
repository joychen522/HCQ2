using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HCQ2_Model.ExtendsionModel;

namespace HCQ2_BLL
{
    /// <summary>
    ///  请假管理业务层实现
    /// </summary>
    public partial class T_AskManagerBLL:HCQ2_IBLL.IT_AskManagerBLL
    {
        public List<T_AskManagerModel> SelectAskManagerData(HCQ2_Model.SelectModel.T_AskManagerModel model)
        {
            return DBSession.IT_AskManagerDAL.SelectAskData(model);
        }

        public int SelectCountAskUserData(HCQ2_Model.SelectModel.T_AskManagerModel model)
        {
            return DBSession.IT_AskManagerDAL.SelectCountData(model);
        }

        public int AddAskModel(T_AskManagerModel model)
        {
            model.ask_operUser = HCQ2UI_Helper.OperateContext.Current.Usr.user_name;
            return Add(model.ToPOCO());
        }

        public int ModifyAskModel(T_AskManagerModel model)
        {
            model.ask_operUser = HCQ2UI_Helper.OperateContext.Current.Usr.user_name;
            return Modify(model.ToPOCO(), s => s.ask_id == model.ask_id, "user_name", "ask_startDate", "ask_endDate",
                "ask_day", "ask_title",
                "ask_context", "ask_type", "ask_status", "ask_operUser", "ask_operDate");
        }
    }
}
