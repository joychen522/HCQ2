using HCQ2_Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HCQ2_BLL
{
    public partial class WGJG02BLL : HCQ2_IBLL.IWGJG02BLL
    {
        /// <summary>
        /// 获取所有数据
        /// </summary>
        /// <returns></returns>
        public List<WGJG02> GetWGJG02()
        {
            return base.Select(o => o.A0101 != "");
        }

        /// <summary>
        /// 获取发放信息
        /// </summary>
        /// <returns></returns>
        public DataTable GetWGJG02DataTable()
        {
            StringBuilder sbSql = new StringBuilder();
            sbSql.AppendFormat("select PersonID,UnitID=a.B0001,WGJG0212,UnitChildID=b.B0002,WGJG0209,");
            sbSql.AppendFormat(" WGJGFather = dateadd(month,-1,WGJG0201), ");//上期发放时间
            sbSql.AppendFormat(" B0002=(select UnitName from B01 where UnitID=b.B0002 ),");
            sbSql.AppendFormat(" B0001=(select UnitName from B01 where UnitID=a.B0001),");
            sbSql.AppendFormat(" E0386=(isnull((SELECT CodeItemName FROM SM_CodeItems WHERE CodeID='JA' AND CodeItemID=b.E0386),' ')),");
            sbSql.AppendFormat(" A0145=(SELECT CodeItemName FROM SM_CodeItems WHERE CodeID='YGZT' AND CodeItemID=b.A0145),");
            sbSql.AppendFormat(" WGJG0203=(SELECT CodeItemName FROM SM_CodeItems WHERE CodeID='GZFFFS' AND CodeItemID=b.WGJG0203),");
            sbSql.AppendFormat(" WGJG0211=(SELECT CodeItemName FROM SM_CodeItems WHERE CodeID='45' AND CodeItemID=b.WGJG0211),");
            sbSql.AppendFormat(" WGJG0201,WGJG0202 ,b.A0101 ,b.A0177,WGJG0204 ,WGJG0205 ,WGJG0206 ,WGJG0207 ,WGJG0208");
            sbSql.AppendFormat(" from WGJG01 a left join  WGJG02 b on a.RowID=b.WGJG01RowID where ISNULL(b.A0101,'')<>'' order by WGJG0201 desc, b.DispOrder");
            return HCQ2_Common.SQL.SqlHelper.ExecuteDataTable(sbSql.ToString(), CommandType.Text, null);
        }
    }
}
