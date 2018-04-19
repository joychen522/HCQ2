using System;
using System.Collections.Generic;
using HCQ2_Model;
using HCQ2_Model.WeiXinApiModel.ParamModel;
using HCQ2_Model.WeiXinApiModel.ResultApiModel;
using HCQ2_Model.APPModel.ResultApiModel;

namespace HCQ2_BLL
{
    public partial class WGJG_ZXBLL : HCQ2_IBLL.IWGJG_ZXBLL
    {
        public List<WGJG_ZX> SelectUnitDataByName(int page, int rows, string keyword)
        {
            return DBSession.IWGJG_ZXDAL.SelUnitDataByName(page, rows, keyword);
        }

        public int SelCountData(string keyword)
        {
            return DBSession.IWGJG_ZXDAL.SelCountByName(keyword);
        }

        public int ModifyData(WGJG_ZX model, string rowID)
        {
            if (model == null || string.IsNullOrEmpty(rowID))
                return 0;
            model.WGJG_ZX10 = HCQ2UI_Helper.OperateContext.Current.Usr.user_name;
            model.WGJG_ZX11 = DateTime.Now;
            return Modify(model, s => s.RowID == rowID, "WGJG_ZX02", "WGJG_ZX06", "WGJG_ZX14", "WGJG_ZX16", "WGJG_ZX17", "WGJG_ZX05", "WGJG_ZX12", "WGJG_ZX07", "WGJG_ZX15", "WGJG_ZX09");
        }

        public List<CompanyEnterResultModel> GetComEnterByName(HCQ2_Model.WeiXinApiModel.ParamModel.CompanyModel model)
        {
            if (null == model)
                return null;
            return DBSession.IWGJG_ZXDAL.GetComEnterByName(model);
        }

        /// <summary>
        /// 获取企业征信
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public List<EnterCompanyResult> GetCompayEnter(HCQ2_Model.WeiXinApiModel.ParamModel.CompanyModel model)
        {
            List<CreditModelResult> list = DBSession.IWGJG_ZXDAL.GetCompayProobjectList(model);
            List<EnterCompanyResult> rList = new List<EnterCompanyResult>();
            if (null!=list && list.Count > 0)
            {
                foreach (var item in list)
                {
                    rList.Add(new EnterCompanyResult()
                    {
                        enter = new EnterModel()
                        {
                            com_id=item.com_id,
                            UnitName = item.UnitName,
                            UnitType=item.UnitType,
                            TrustCode=item.TrustCode,
                            LegalPerson=item.LegalPerson
                        },
                        company = new HCQ2_Model.APPModel.ResultApiModel.CompanyModel()
                        {
                            ed_id=item.ed_id,
                            ent_name=item.ent_name,
                            ent_type=item.ent_type,
                            update_time=item.update_time,
                            update_name=item.update_name,
                            solve_type=item.solve_type
                        }
                    });
                }                    
            }
            return rList;
        }
        /// <summary>
        /// 获取企业征信明细
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public List<EnterCompanyDetail> GetCompayEnterDetail(CompanyDetailModel model)
        {
            if (null == model || model.com_id <= 0)
                return null;
            return DBSession.IWGJG_ZXDAL.GetCompayEnterDetail(model);
        }
    }
}
