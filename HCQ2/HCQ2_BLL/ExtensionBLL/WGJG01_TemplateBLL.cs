using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HCQ2_Model;
using HCQ2_Model.ViewModel;
using HCQ2_Common.Code;
using HCQ2_Common.Encrypt;

namespace HCQ2_BLL 
{
    public partial class WGJG01_TemplateBLL:HCQ2_IBLL.IWGJG01_TemplateBLL
    {
        public List<WGJG01Model> GetWageListDataByUnit(string unitID, int page, int rows)
        {
            if (string.IsNullOrEmpty(unitID))
                return null;
            return DBSession.IWGJG01_TemplateDAL.GetWageListDataByUnit(unitID, page, rows);
        }

        public int AddWGJG01(WGJG01_Template model)
        {
            B01 b01 = DBSession.IB01DAL.Select(s => s.UnitID == model.UnitID).FirstOrDefault();
            if (b01 == null)
                return 0;
            WGJG01_Template wg = new WGJG01_Template()
            {
                B0001 = (b01.KeyParent.Equals(".")) ? model.UnitID : b01.KeyParent,
                B0002 = "",//(model.UnitID.Length == 3) ? "" : model.UnitID,
                UnitID = model.UnitID,
                RowID = EncryptHelper.Md5Encryption(OnlyCodeHelper.CreateOnlyCode()),
                WGJG0101 = model.WGJG0101,
                WGJG0103 = model.WGJG0103,
                WGJG0104 = model.WGJG0104,
                WGJG0106 = model.WGJG0106,
                WGJG0203 = model.WGJG0203,
                WGJGDAY = model.WGJGDAY
            };
           return Add(wg);
        }

        public int EditWGJG01(WGJG01_Template model)
        {
            return Modify(model, "WGJG0101", "WGJG0103", "WGJGDAY", "WGJG0104", "WGJG0203");
        }

        public bool StartGrantByWGJG01(string wgDate, string rowId)
        {
            return DBSession.IWGJG01_TemplateDAL.StartGrantByWGJG01(wgDate.Replace('-', '/'), rowId);
        }

        public bool CheckGrantWage(string wgDate, string rowId)
        {
            WGJG01_Template wt1 = DBSession.IWGJG01_TemplateDAL.Select(s => s.RowID == rowId).FirstOrDefault();
            if (wt1 == null)
                return false;
            DateTime? dt = DateTime.ParseExact(wgDate, "yyyy-MM-dd", new System.Globalization.CultureInfo("zh-CN"));
            WGJG01 wg = DBSession.IWGJG01DAL.Select(s => s.ModelID == rowId && s.WGJG0103==wt1.WGJG0103 && s.WGJG0107 == dt).FirstOrDefault();
            if (null != wg)
                return true;
            return false;
        }
    }
}
