using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HCQ2_Model;
using HCQ2_Common.Code;
using HCQ2_Common.Encrypt;
using HCQ2_Model.ViewModel;
using System.Data;
namespace HCQ2_BLL
{
    public partial class WGJG02_TemplateBLL:HCQ2_IBLL.IWGJG02_TemplateBLL
    {
        public bool CreateDataByUnit(string rowid)
        {
            if (string.IsNullOrEmpty(rowid))
                return false;
            //1：删除数据
            Delete(s => s.WGJG01RowID == rowid);
            //2：重新生成数据
            WGJG01_Template wg1 = DBSession.IWGJG01_TemplateDAL.Select(s => s.RowID == rowid).FirstOrDefault();
            if (wg1==null)
                return false;
            //3：添加数据
            List<A01> list = DBSession.IA01DAL.Select(s => s.UnitID == wg1.UnitID);
            foreach (A01 item in list)
            {
                Add(new WGJG02_Template()
                {
                    RowID = EncryptHelper.Md5Encryption(OnlyCodeHelper.CreateOnlyCode()),
                    WGJG01RowID = rowid,
                    PersonSalaryID = EncryptHelper.Md5Encryption(OnlyCodeHelper.CreateOnlyCode()),
                    PersonID = item.PersonID,
                    A0101 = item.A0101,
                    A0177 = item.A0177,
                    B0002 = "",//item.B0002,
                    UnitID=item.UnitID,
                    E0386 = item.E0386,
                    WGJG0203 = wg1.WGJG0203,
                    WGJG0204 = item.A0178, //工资
                    WGJG0207 = item.A0178,
                    WGJG0208 = item.A0178
                });
            }
            return true;
        }

        public bool CreateDataByPsersons(string psersons, string rowid)
        {
            if (string.IsNullOrEmpty(psersons))
                return false;
            List<string> liStr = new List<string>(psersons.Split(','));
            //1：删除数据
            DBSession.IWGJG02_TemplateDAL.DeletePersonsData(liStr, rowid);
            //2：添加数据
            WGJG01_Template wg1 = DBSession.IWGJG01_TemplateDAL.Select(s => s.RowID == rowid).FirstOrDefault();
            List<A01> list = DBSession.IA01DAL.GetPeronsBySel(liStr,wg1.UnitID);
            foreach (A01 item in list)
            {
                Add(new WGJG02_Template()
                {
                    RowID = EncryptHelper.Md5Encryption(OnlyCodeHelper.CreateOnlyCode()),
                    WGJG01RowID = rowid,
                    PersonSalaryID = EncryptHelper.Md5Encryption(OnlyCodeHelper.CreateOnlyCode()),
                    PersonID = item.PersonID,
                    A0101 = item.A0101,
                    A0177 = item.A0177,
                    B0002 = "",//item.B0002,
                    UnitID=item.UnitID,
                    E0386 = item.E0386,
                    WGJG0203 = wg1?.WGJG0203,
                    WGJG0204 = item.A0178, //工资
                    WGJG0207 = item.A0178,
                    WGJG0208 = item.A0178
                });
            }
            return true;
        }

        public List<WGJG02Model> GetWageDetailByRowId(string rowID, string userName, int page, int rows)
        {
            if (string.IsNullOrEmpty(rowID))
                return null;
            return DBSession.IWGJG02_TemplateDAL.GetWageDetailByRowId(rowID,userName, page, rows);
        }

        public int EditWageTempModel(WGJG02Model model)
        {
            if (null == model)
                return 0;
            HCQ2_Model.WGJG02_Template wg2 = new WGJG02_Template()
            {
                WGJG0204 = model.WGJG0204,
                WGJG0205 = model.WGJG0205,
                WGJG0206 = model.WGJG0206,
                WGJG0207 = model.WGJG0207,
                WGJG0208 = model.WGJG0208
            };
           return Modify(wg2, s => s.A0177 == model.A0177, "WGJG0204", "WGJG0205", "WGJG0206", "WGJG0207", "WGJG0208");
        }

        public int EditWageTempModelBySingle(WGJG02Model model, string columnName)
        {
            if (null == model || string.IsNullOrEmpty(columnName))
                return 0;
            WGJG02_Template wg2 = new WGJG02_Template()
            {
                WGJG0204 = model.WGJG0204,
                WGJG0205 = model.WGJG0205,
                WGJG0206 = model.WGJG0206,
                WGJG0207 = model.WGJG0207,
                WGJG0208 = model.WGJG0208
            };
            return Modify(wg2, s => s.A0177 == model.A0177 && s.RowID==model.RowID, columnName);
        }
        /// <summary>
        ///  根据单位代码 导出模板Excel
        /// </summary>
        /// <param name="model"></param>
        public void ExportTemplateToExcel(string UnitID, string e0386, string in_type)
        {
            //1.0获取待导出数据
            List<A01> list = DBSession.IA01DAL.Select(s => s.UnitID.Equals(UnitID));
            if (null == list || list.Count <= 0)
                return;
            DataTable dt = DBSession.IWGJG02_TemplateDAL.GetExportPersonData(UnitID,e0386,in_type);
            Dictionary<string, string> dict = new Dictionary<string, string>();
            dict.Add("A0101", "姓名");
            dict.Add("A0177", "身份证");
            dict.Add("W0178", "应发工资");
            dict.Add("A0178", "实发工资"); 
            dict.Add("PersonID", "唯一标记");
            HCQ2_Common.NpoiHelper.DataTableToExeclForNpoi(dt, dict, "工资模板", "工资模板", "PersonID", false);
        }
        /// <summary>
        ///  导入数据
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public bool ImportPersonData(DataTable dt, string UnitID, string RowID)
        {
            if (null == dt || dt.Rows.Count <= 0)
                return false;
            List<A01> a01 = DBSession.IA01DAL.Select(s => s.UnitID.Equals(UnitID));
            if (null == a01 || a01.Count <= 0)
                return false;
            //删除之前的模板数据
            DBSession.IWGJG02_TemplateDAL.Delete(s => s.WGJG01RowID.Equals(RowID));
            WGJG01_Template wg1 = DBSession.IWGJG01_TemplateDAL.Select(s => s.RowID == RowID).FirstOrDefault();
            foreach (DataRow item in dt.Rows)
            {
                A01 temp = a01.Where(s => s.PersonID.Equals(item["F5"])).FirstOrDefault();
                if (null == temp)
                    continue;
                decimal W0178 = 0,//应发
                    A0178 = 0;//实发
                try{
                    W0178 = Convert.ToDecimal(item["F3"]);
                    A0178 = Convert.ToDecimal(item["F4"]);
                }
                catch
                { W0178 = 0; A0178 = 0; }
                Add(new WGJG02_Template()
                {
                    RowID = EncryptHelper.Md5Encryption(OnlyCodeHelper.CreateOnlyCode()),
                    WGJG01RowID = RowID,
                    PersonSalaryID = EncryptHelper.Md5Encryption(OnlyCodeHelper.CreateOnlyCode()),
                    PersonID = temp.PersonID,
                    A0101 = temp.A0101,
                    A0177 = temp.A0177,
                    B0002 = "",//item.B0002,
                    UnitID = temp.UnitID,
                    E0386 = temp.E0386,
                    WGJG0203 = wg1?.WGJG0203,
                    WGJG0204 = temp.A0178, //工资
                    WGJG0207 = W0178,//应发
                    WGJG0208 = A0178//实发
                });
            }
            return true;
        }
    }
}
