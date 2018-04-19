using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HCQ2_Model.SelectModel;

namespace HCQ2_BLL
{
    public partial class A01BLL:HCQ2_IBLL.IA01BLL
    {
        public List<ListBoxModel> GetPersonsByB0002(string unitID)
        {
            return DBSession.IA01DAL.GetPersonByB0002(unitID);
        }
        /// <summary>
        ///  获取人员月增长
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public List<HCQ2_Model.APPModel.ResultApiModel.ChartPerson> GetPersonMonthGrow(HCQ2_Model.APPModel.ParamModel.DebtAllGrantModel model)
        {
            if (null == model)
                return null;
            return DBSession.IA01DAL.GetPersonMonthGrow(model);
        }
        /// <summary>
        ///  获取人员总增长
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public List<HCQ2_Model.APPModel.ResultApiModel.ChartPerson> GetPersonAllGrow(HCQ2_Model.APPModel.ParamModel.DebtAllGrantModel model)
        {
            if (null == model)
                return null;
            return DBSession.IA01DAL.GetPersonAllGrow(model);
        }
    }
}
