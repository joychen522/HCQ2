using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HCQ2_Model.ExtendsionModel;
using HCQ2_Common;

namespace HCQ2_DAL_MSSQL
{
    public partial class T_AskManagerDAL:HCQ2_IDAL.IT_AskManagerDAL
    {
        public List<T_AskManagerModel> SelectAskData(HCQ2_Model.SelectModel.T_AskManagerModel model)
        {
            if (model == null)
                return null;
            StringBuilder sb = new StringBuilder();
            sb.Append(string.Format(@" SELECT TOP {0} * FROM
                (
                    SELECT TOP {1} ask.ask_id, ask.ask_unit, ask.user_name, ask.ask_startDate, ask.ask_endDate,
                            ask.ask_day, ask.ask_title, ask.ask_context, ask.ask_operUser, ask.ask_operDate,
                            code_type.*, code_status.* FROM
                    (SELECT * FROM dbo.T_AskManager WHERE 1 = 1 ", model.rows, model.page*model.rows));
            if (!string.IsNullOrEmpty(model.unitID))
                sb.AppendLine(string.Format(" AND ask_unit LIKE '{0}%' ", model.unitID));
            if (!string.IsNullOrEmpty(model.userName))
                sb.Append(string.Format(" AND user_name LIKE '%{0}%' ", model.userName));
            if (!string.IsNullOrEmpty(model.dateStart) && !string.IsNullOrEmpty(model.dateEnd))
                sb.Append(string.Format(" AND ask_startDate>='{0}' AND ask_endDate<='{1}' ", model.dateStart, model.dateEnd));
            else if (!string.IsNullOrEmpty(model.dateStart))
                sb.Append(string.Format(" AND ask_startDate>='{0}' ", model.dateStart));
            else if (!string.IsNullOrEmpty(model.dateEnd))
                sb.Append(string.Format(" AND ask_endDate<='{0}' ", model.dateEnd));
            sb.Append(string.Format(@") ask INNER JOIN
                    (SELECT item2.ask_type, item2.ask_type_text FROM
                        (SELECT item_id, item_code FROM dbo.T_ItemCode WHERE item_code = 'QJTYPE') item1 INNER JOIN
                        (SELECT code_name AS ask_type_text, code_value AS ask_type, item_id AS id FROM dbo.T_ItemCodeMenum) item2 ON item1.item_id = item2.id) code_type
                     ON ask.ask_type = code_type.ask_type INNER JOIN
                    (SELECT item2.ask_status, item2.ask_status_text FROM
                        (SELECT item_id, item_code FROM dbo.T_ItemCode WHERE item_code = 'QJSTATUS') item1 INNER JOIN
                        (SELECT code_name AS ask_status_text, code_value AS ask_status, item_id AS id FROM dbo.T_ItemCodeMenum) item2 ON item1.item_id = item2.id) code_status
                     ON ask.ask_status = code_status.ask_status
                     ORDER BY ask.ask_id DESC
                 ) w1"));
            DataTable dt = HCQ2_Common.SQL.SqlHelper.ExecuteDataTable(sb.ToString(), System.Data.CommandType.Text);
            return HCQ2_Common.Data.DataTableHelper.DataTableToIList<T_AskManagerModel>(dt,true);
        }

        public int SelectCountData(HCQ2_Model.SelectModel.T_AskManagerModel model)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(
                "SELECT COUNT(*) FROM dbo.T_AskManager WHERE 1=1 ");
            if (!string.IsNullOrEmpty(model.unitID))
                sb.AppendLine(string.Format(" AND ask_unit LIKE '{0}%' ", model.unitID));
            if (!string.IsNullOrEmpty(model.userName))
                sb.Append(string.Format(" AND user_name LIKE '%{0}%' ", model.userName));
            if (!string.IsNullOrEmpty(model.dateStart) && !string.IsNullOrEmpty(model.dateEnd))
                sb.Append(string.Format("  AND ask_startDate>='{0}' AND ask_endDate<='{1}' ", model.dateStart,
                    model.dateEnd));
            else if (!string.IsNullOrEmpty(model.dateStart))
                sb.Append(string.Format(" AND ask_startDate>='{0}' ", model.dateStart));
            else if (!string.IsNullOrEmpty(model.dateEnd))
                sb.Append(string.Format(" AND ask_endDate<='{0}' ", model.dateEnd));
            return Helper.ToInt(HCQ2_Common.SQL.SqlHelper.ExecuteScalar(sb.ToString(), CommandType.Text));
        }
    }
}
