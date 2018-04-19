using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HCQ2_Model.ExtendsionModel;
using HCQ2_Common.SQL;
using HCQ2_Model.ViewModel;
using HCQ2_Model.APPModel.ParamModel;
using HCQ2_Model.APPModel.ResultApiModel;

namespace HCQ2_DAL_MSSQL
{
    public partial class A02DAL:HCQ2_IDAL.IA02DAL
    {
        /// <summary>
        ///  参数
        /// </summary>
        private Dictionary<string, object> _param = new Dictionary<string, object>();
        /// <summary>
        ///  sql语句
        /// </summary>
        private StringBuilder sb = new StringBuilder();
        public List<WorkTypeCount> GetWorkType(OrgModel model)
        {
            sb?.Clear();
            sb.Append(string.Format(@"SELECT ISNULL(code1.E0386,'其他') AS E0386,A.numCount FROM
                (SELECT ISNULL(E0386,'00') AS E0386,COUNT(ISNULL(E0386,'00')) AS numCount FROM dbo.A01 WHERE UnitID=@UnitID GROUP BY E0386) A LEFT JOIN
                (SELECT CodeItemID,CodeItemName AS E0386 FROM dbo.SM_CodeItems WHERE CodeID='JA') code1 
                ON A.E0386=code1.CodeItemID "));
            _param?.Clear();
            _param.Add("@UnitID", model.orgid);
            DataTable dt = SqlHelper.ExecuteDataTable(sb.ToString(), CommandType.Text, SqlHelper.GetParameters(_param));
            return HCQ2_Common.Data.DataTableHelper.DataTableToIList<WorkTypeCount>(dt);
        }

        public List<A02Model> SelectA02CheckByMonthData(HCQ2_Model.SelectModel.A02Model model)
        {
            StringBuilder sb = new StringBuilder();
            if (model == null || string.IsNullOrEmpty(model.unitID))
                return null;
            sb.Append(@"SELECT a2.A0201 as cardDate,COUNT(*) AS countPersons FROM (SELECT a1.PersonID, a1.A0201 FROM
                (SELECT LEFT(convert(char(10), A0201, 23), 7) AS A0201, PersonID FROM dbo.A02 WHERE 1=1 ");
            if (!string.IsNullOrEmpty(model.dateStart) && !string.IsNullOrEmpty(model.dateEnd))
                sb.AppendLine(string.Format(" AND LEFT(convert(char(10), A0201, 23), 7) BETWEEN '{0}' AND '{1}' ", model.dateStart, model.dateEnd));
            else if (!string.IsNullOrEmpty(model.dateStart))
                sb.AppendLine(string.Format(" AND LEFT(convert(char(10), A0201, 23), 7)>='{0}' ", model.dateStart));
            else if (!string.IsNullOrEmpty(model.dateEnd))
                sb.AppendLine(string.Format(" AND LEFT(convert(char(10), A0201, 23), 7)<='{0}' ", model.dateEnd));
            sb.Append(string.Format(@"AND PersonID IN(SELECT PersonID FROM dbo.A01 WHERE UnitID LIKE '{0}%')) a1 
	            GROUP BY a1.PersonID,a1.A0201)a2 GROUP BY a2.A0201", model.unitID));
            DataTable dt = SqlHelper.ExecuteDataTable(sb.ToString(), CommandType.Text);
            return HCQ2_Common.Data.DataTableHelper.DataTableToIList<A02Model>(dt);
        }

        public List<PunchCardModel> SelectCardPersons(HCQ2_Model.SelectModel.A02Model model)
        {
            StringBuilder sb = new StringBuilder();
            if (model == null || string.IsNullOrEmpty(model.unitID))
                return null;
            sb.Append(string.Format(@"SELECT * FROM(
                SELECT a1.A0177, a1.A0101, a1.A0178, a1.UnitID, a1.A0141, a1.A0142, b1.UnitName, a2.A0201,
                    ROW_NUMBER() OVER(ORDER BY a1.DispOrder ASC) as rank FROM
                (SELECT A0177, A0101, A0178,UnitID, A0141, A0142, PersonID, DispOrder FROM dbo.A01 WHERE UnitID LIKE '{0}%') a1 INNER JOIN
                (SELECT PersonID, LEFT(convert(char(10), MAX(A0201), 23), 7) AS A0201 FROM dbo.A02 WHERE 1=1 ", model.unitID));
            if (!string.IsNullOrEmpty(model.cardDate))
                sb.AppendLine(string.Format(" AND LEFT(convert(char(10),A0201,23),7)='{0}' ", model.cardDate));
            else
            {
                if (!string.IsNullOrEmpty(model.dateStart) && !string.IsNullOrEmpty(model.dateEnd))
                    sb.AppendLine(string.Format(" AND LEFT(convert(char(10),A0201,23),7) BETWEEN '{0}' AND '{1}' ", model.dateStart, model.dateEnd));
                else if (!string.IsNullOrEmpty(model.dateStart))
                    sb.AppendLine(string.Format(" AND LEFT(convert(char(10),A0201,23),7)>='{0}' ", model.dateStart));
                else if (!string.IsNullOrEmpty(model.dateEnd))
                    sb.AppendLine(string.Format(" AND LEFT(convert(char(10),A0201,23),7)<='{0}' ", model.dateEnd));
            }
            sb.AppendLine(string.Format(@" GROUP BY PersonID) a2 ON a1.PersonID = a2.PersonID LEFT JOIN
                    (SELECT UnitName, UnitID FROM dbo.B01) b1 ON a1.UnitID = b1.UnitID
                ) info "));
            if (model.page > 0 && model.rows > 0)
                sb.AppendLine(string.Format(" WHERE info.rank BETWEEN {0} AND {1}",
                    (model.page - 1) * model.rows, model.page * model.rows));
            sb.AppendLine("ORDER BY info.rank ASC;");
            DataTable dt = SqlHelper.ExecuteDataTable(sb.ToString(), CommandType.Text);
            return HCQ2_Common.Data.DataTableHelper.DataTableToIList<PunchCardModel>(dt);
        }
    }
}
