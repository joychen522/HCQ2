using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HCQ2_Model;
using HCQ2_Model.WeiXinApiModel.ParamModel;
using HCQ2_Model.WeiXinApiModel.ResultApiModel;

namespace HCQ2_BLL
{
    public partial class WGJG_GRZXBLL:HCQ2_IBLL.IWGJG_GRZXBLL
    {
        public List<WGJG_GRZX> SelectOwnDataByName(int page, int rows, string userName)
        {
            return DBSession.IWGJG_GRZXDAL.SelectOwnDataByName(page, rows, userName);
        }

        public int SelectCountOwnData(string userName)
        {
            return DBSession.IWGJG_GRZXDAL.SelectCountOwnData(userName);
        }

        public int ModifyData(WGJG_GRZX model)
        {
            if (model == null)
                return 0;
            model.WGJG_GRZX10 = HCQ2UI_Helper.OperateContext.Current.Usr.user_name;
            model.WGJG_GRZX11 = DateTime.Now;
            return Modify(model, s => s.RowID == model.RowID, "WGJG_GRZX05", "WGJG_GRZX07", "WGJG_GRZX08", "WGJG_GRZX09",
                "WGJG_GRZX10",
                "WGJG_GRZX11", "WGJG_GRZX04", "WGJG_GRZX06");
        }

        public List<CompanyOwnResultModel> GetComOwnByName(CompanyModel model)
        {
            if (null == model)
                return null;
            return DBSession.IWGJG_GRZXDAL.GetComOwnByName(model);
        }
    }
}
