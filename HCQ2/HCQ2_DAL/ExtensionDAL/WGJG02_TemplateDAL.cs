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
    public partial class WGJG02_TemplateDAL:HCQ2_IDAL.IWGJG02_TemplateDAL
    {
        /// <summary>
        ///  参数
        /// </summary>
        private Dictionary<string, object> _param = new Dictionary<string, object>();
        /// <summary>
        ///  sql语句
        /// </summary>
        private StringBuilder sb = new StringBuilder();
        public List<WGJG02Model> GetWageDetailByRowId(string rowID, string userName, int page, int rows)
        {
            if (string.IsNullOrEmpty(rowID))
                return null;
            StringBuilder sb = new StringBuilder();
            sb.Append(@"SELECT w1.RowID,w1.WGJG0201,w1.WGJG0202,w1.A0101,w1.A0177,b1.B0002,b1.B0002 AS UnitID,code1.E0386,code2.WGJG0203,w1.WGJG0204,
w1.WGJG0205,w1.WGJG0206,w1.WGJG0207,w1.WGJG0208,w1.WGJG0209,w1.WGJG0211,w1.WGJG0212,w1.PClassID FROM ");
            sb.Append(string.Format("(SELECT *,ROW_NUMBER() OVER (ORDER BY RowID) as rank FROM dbo.WGJG02_Template WHERE WGJG01RowID='{0}' AND PersonID IN (SELECT PersonID FROM dbo.A01) ", rowID));
            if(!string.IsNullOrEmpty(userName))
                sb.Append(string.Format(" AND A0101 LIKE '%{0}%' ",userName));
            sb.Append(") w1 LEFT JOIN ");
            sb.Append(@"(SELECT UnitID,UnitName AS B0002 FROM dbo.B01) b1 ON w1.UnitID=b1.UnitID LEFT JOIN
(SELECT CodeItemID,CodeItemName AS E0386 FROM dbo.SM_CodeItems WHERE CodeID='JA') code1 ON w1.E0386=code1.CodeItemID LEFT JOIN
(SELECT CodeItemID,CodeItemName AS WGJG0203 FROM dbo.SM_CodeItems WHERE CodeID='GZFFFS') code2 ON w1.WGJG0203=code2.CodeItemID ");
            sb.Append(string.Format(" WHERE w1.rank between {0} and {1};", (page - 1) * rows, page * rows));
            DataTable dt = HCQ2_Common.SQL.SqlHelper.ExecuteDataTable(sb.ToString(), CommandType.Text);
            return HCQ2_Common.Data.DataTableHelper.DataTableToIList<WGJG02Model>(dt);
        }

        public bool DeletePersonsData(List<string> persons,string rowID)
        {
            if (persons==null || string.IsNullOrEmpty(rowID))
                return false;
            StringBuilder sb = new StringBuilder();
            sb.Append(string.Format("DELETE FROM dbo.WGJG02_Template WHERE A0177 IN('{0}') AND WGJG01RowID='{1}';",
                string.Join("','",persons.ToArray()), rowID));
            HCQ2_Common.SQL.SqlHelper.ExecuteNonQuery(sb.ToString(), CommandType.Text);
            return true;
        }
        /// <summary>
        ///  获取导出数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public DataTable GetExportPersonData(string UnitID, string e0386, string in_type)
        {
            sb?.Clear();
            sb.Append(string.Format(@"SELECT A0101,A0177,ISNULL(A0178,0) AS A0178,ISNULL(A0178,0) AS W0178,PersonID FROM dbo.A01 WHERE UnitID=@UnitID "));
            if (!string.IsNullOrEmpty(e0386) && !e0386.Equals("00"))
                sb.Append(string.Format(" AND E0386={0} ",e0386));
            if (!string.IsNullOrEmpty(in_type) && !in_type.Equals("00"))
                sb.Append(string.Format(" AND in_team={0} ", in_type));
            _param?.Clear();
            _param.Add("@UnitID", UnitID);
            return SqlHelper.ExecuteDataTable(sb.ToString(), CommandType.Text, SqlHelper.GetParameters(_param));
        }
    }
}
