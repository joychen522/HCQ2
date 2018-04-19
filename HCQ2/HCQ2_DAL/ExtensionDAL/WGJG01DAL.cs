using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using HCQ2_Model.APPModel.ParamModel;
using HCQ2_Model.APPModel.ResultApiModel;
using HCQ2_Model.ViewModel;
using HCQ2_Common.SQL;

namespace HCQ2_DAL_MSSQL
{
    public partial class WGJG01DAL: HCQ2_IDAL.IWGJG01DAL
    {
        /// <summary>
        ///  参数
        /// </summary>
        private Dictionary<string, object> _param = new Dictionary<string, object>();
        public List<DebtWGJG01Model> GetGrantInfoByUnit(DebtSelGrantModel model)
        {
            _param.Clear();
            _param.Add("@orgid", model.orgid);
            StringBuilder sb = new StringBuilder();
            sb.Append(string.Format(@"SELECT CONVERT(varchar(100), wg.WGJG0107, 23) as WGJG0102,WGJG0103,code.CodeItemName as WGJG0101 FROM
                (SELECT WGJG0107,WGJG0103,WGJG0101 FROM dbo.WGJG01 WHERE UnitID=@orgid) wg LEFT JOIN
                (SELECT item1.*,item2.* FROM
                (SELECT item_id,item_code FROM dbo.T_ItemCode WHERE item_code='GDBS') item1 INNER JOIN
                (SELECT code_name AS CodeItemName,code_value AS CodeItemValue,item_id AS id FROM dbo.T_ItemCodeMenum) item2 ON item1.item_id = item2.id) code
                ON wg.WGJG0101=code.CodeItemValue"));
            DataTable dt = SqlHelper.ExecuteDataTable(sb.ToString(), CommandType.Text, SqlHelper.GetParameters(_param));
            return HCQ2_Common.Data.DataTableHelper.DataTableToIList<DebtWGJG01Model>(dt);
        }

        public List<WGJG01Model> GetWageListDataByUnit(HCQ2_Model.SelectModel.WGJG01ChartModel model)
        {
            if(string.IsNullOrEmpty(model.rowID) && string.IsNullOrEmpty(model.unitID))
                return null;
            StringBuilder sb = new StringBuilder();
            sb.Append("SELECT ");
            if (!model.isAll)
                sb.Append(" TOP " + model.rows);
            sb.Append(@" g1.RowID,b1.modelName,b2.UnitName,g1.UnitID,code.CodeItemName,code.CodeItemValue,g1.WGJG0102,g1.WGJG0103,g1.WGJG0104
, g1.WGJG0105, g1.WGJG0106, g1.WGJG0107,allPerson=(SELECT COUNT(*) FROM dbo.WGJG02 w2 WHERE w2.WGJG01RowID=g1.RowID),
surePerson=(SELECT COUNT(*) FROM dbo.WGJG02 w2 WHERE w2.WGJG01RowID=g1.RowID AND w2.WGJG0211='1'),payPerson=(SELECT COUNT(*) FROM dbo.WGJG02 w2 WHERE w2.WGJG01RowID=g1.RowID AND w2.WGJG0211<>'1'),allMoney=(SELECT SUM(WGJG0207) FROM dbo.WGJG02 w2 WHERE w2.WGJG01RowID=g1.RowID),sureMoney=(SELECT SUM(WGJG0208) FROM dbo.WGJG02 w2 WHERE w2.WGJG01RowID=g1.RowID AND ISNULL(WGJG0211,'')='1'),payMoney=(SELECT SUM(WGJG0207) FROM dbo.WGJG02 w2 WHERE w2.WGJG01RowID=g1.RowID AND ISNULL(WGJG0211,'')<>'1') FROM ");
            if (!string.IsNullOrEmpty(model.rowID))
                sb.Append(
                    string.Format("(SELECT * FROM dbo.WGJG01 WHERE RowID='{0}' ", model.rowID));
            else
                sb.Append(
                   string.Format("(SELECT * FROM dbo.WGJG01 WHERE UnitID='" + model.unitID + "'"));
            //1.关键字
            if (!string.IsNullOrEmpty(model.keyword))
                sb.Append(string.Format(" AND WGJG0103 LIKE '%{0}%' ", model.keyword));    
            //2.状态
            if(!string.IsNullOrEmpty(model.stauts))
                sb.Append(string.Format(" AND WGJG0101='{0}' ", model.stauts));
            //3.日期
            if (!string.IsNullOrEmpty(model.dateStart) && !string.IsNullOrEmpty(model.dateEnd))
                sb.Append(string.Format(" AND WGJG0102 BETWEEN '{0}' AND '{1}' ", model.dateStart, model.dateEnd));
            else if (!string.IsNullOrEmpty(model.dateStart))
                sb.Append(string.Format(" AND WGJG0102>='{0}' ", model.dateStart));
            else if (!string.IsNullOrEmpty(model.dateEnd))
                sb.Append(string.Format(" AND WGJG0102<='{0}' ", model.dateEnd));
            sb.Append(" ) g1 LEFT JOIN ");
            sb.Append(@"(SELECT UnitID,UnitName AS modelName FROM dbo.B01) b1 ON g1.UnitID=b1.UnitID LEFT JOIN
(SELECT UnitID, UnitName FROM dbo.B01) b2 ON g1.UnitID = b2.UnitID LEFT JOIN
(SELECT item1.*,item2.* FROM
(SELECT item_id,item_code FROM dbo.T_ItemCode WHERE item_code='GDBS') item1 INNER JOIN
(SELECT code_name AS CodeItemName,code_value AS CodeItemValue,item_id AS id FROM dbo.T_ItemCodeMenum) item2 ON item1.item_id = item2.id) code ON g1.WGJG0101=code.CodeItemValue ");
            sb.Append(" WHERE b1.modelName IS NOT NULL ");
            if (model.page >1 && !model.isAll)
                sb.Append(string.Format(@" and  g1.DispOrder>
(SELECT MAX(CASE WHEN LEN(DispOrder)=0 THEN 0 ELSE DispOrder END) FROM(SELECT TOP {0} DispOrder FROM dbo.WGJG01 ORDER BY DispOrder ASC) g) ", model.rows * (model.page - 1)));
            sb.Append(" ORDER BY g1.WGJG0102 DESC");
            DataTable dt = HCQ2_Common.SQL.SqlHelper.ExecuteDataTable(sb.ToString(), CommandType.Text);
            return HCQ2_Common.Data.DataTableHelper.DataTableToIList<WGJG01Model>(dt);
        }

        public int SelMaxOrder()
        {
            HCQ2_Model.WGJG01 wg =(from o in db.Set<HCQ2_Model.WGJG01>() orderby o.DispOrder descending select o).
            FirstOrDefault();
            if (null == wg)
                return 0;
            return wg.DispOrder;
        }
    }
}
