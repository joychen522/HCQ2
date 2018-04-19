using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HCQ2_Model.ViewModel;
using HCQ2_Common.SQL;

namespace HCQ2_DAL_MSSQL
{
    public partial class WGJG01_TemplateDAL:HCQ2_IDAL.IWGJG01_TemplateDAL
    {
        public List<WGJG01Model> GetWageListDataByUnit(string unitID, int page, int rows)
        {
            if (string.IsNullOrEmpty(unitID))
                return null;
            StringBuilder sb = new StringBuilder();
            sb.Append("SELECT TOP " + rows);
            sb.Append(@" g1.DispOrder,g1.RowID,g1.B0002,g1.UnitID,b1.modelName,b2.UnitName,code.WGJG0101,code2.WGJG0203,code2.WGJG0203_Name,code.CodeItemValue,g1.WGJG0102,g1.WGJG0103,g1.WGJG0104
, g1.WGJG0105, g1.WGJG0106, g1.WGJGDAY,allPerson=(SELECT COUNT(*) FROM dbo.WGJG02_Template w2 WHERE w2.WGJG01RowID=g1.RowID) FROM ");
            sb.Append(string.Format("(SELECT * FROM dbo.WGJG01_Template WHERE UnitID='"+ unitID + "') g1 LEFT JOIN "));
            sb.Append(@"(SELECT UnitID,UnitName AS modelName FROM dbo.B01) b1 ON g1.B0001=b1.UnitID LEFT JOIN
(SELECT UnitID, UnitName FROM dbo.B01) b2 ON g1.UnitID = b2.UnitID LEFT JOIN
(SELECT item1.*,item2.* FROM
(SELECT item_id,item_code FROM dbo.T_ItemCode WHERE item_code='ZJFFBJ') item1 INNER JOIN
(SELECT code_name AS WGJG0101,code_value AS CodeItemValue,item_id AS id FROM dbo.T_ItemCodeMenum) item2 ON item1.item_id = item2.id) code ON g1.WGJG0101=code.CodeItemValue INNER JOIN ");
            //发放方式
            sb.Append(@"(SELECT item2.WGJG0203,item2.WGJG0203_Name FROM 
(SELECT item_id, item_code FROM dbo.T_ItemCode WHERE item_code = 'GZFFFS') item1 INNER JOIN
(SELECT code_name AS WGJG0203, code_value AS WGJG0203_Name, item_id AS id FROM dbo.T_ItemCodeMenum) item2
ON item1.item_id = item2.id) code2 ON g1.WGJG0203 = code2.WGJG0203_Name ");
            sb.Append(" WHERE b2.UnitName IS NOT NULL ");
            if (page > 1)
                sb.Append(string.Format(@" and  g1.DispOrder>
(SELECT MAX(CASE WHEN LEN(DispOrder)=0 THEN 0 ELSE DispOrder END) FROM(SELECT TOP {0} DispOrder FROM dbo.WGJG01_Template ORDER BY DispOrder ASC) g) ", rows * (page - 1)));
            sb.Append(" ORDER BY g1.DispOrder");
            DataTable dt = SqlHelper.ExecuteDataTable(sb.ToString(), CommandType.Text);
            return HCQ2_Common.Data.DataTableHelper.DataTableToIList<WGJG01Model>(dt);
        }

        public bool StartGrantByWGJG01(string wgDate, string rowId)
        {
            Dictionary<string, object> dis = new Dictionary<string, object>();
            dis.Add("@WGJG0107", wgDate);
            dis.Add("@UnitCode", rowId);
            SqlHelper.ExecuteNonQuery("Pk_AutoGrantWage", CommandType.StoredProcedure,
                SqlHelper.GetParameters(dis));
            return true;
        }
    }
}
