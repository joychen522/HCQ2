using HCQ2_Common;
using HCQ2_Common.SQL;
using HCQ2_Model.AfterSaleModel;
using HCQ2_Model.Constant;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HCQ2_DAL_MSSQL
{
    public  partial class BB_ItemPreserveDAL:HCQ2_IDAL.IBB_ItemPreserveDAL
    {
        /// <summary>
        ///  参数
        /// </summary>
        private Dictionary<string, object> _param = new Dictionary<string, object>();
        private StringBuilder sb = new StringBuilder();
        /// <summary>
        ///  根据条件 获取项目台账数据集合
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public List<ItemPreserveModel> GetInitData(ItemPreserveParam param)
        {
            sb?.Clear();
            sb.Append(string.Format(@"SELECT TOP {0} tt.*,code.ip_status_text,record.tail_after FROM 
(SELECT ROW_NUMBER() OVER(ORDER BY ip_id) AS RowNumber, ip_id,
 unit_name, unit_code, ip_status, area_code, pact_money, pay_money,
 CONVERT(varchar(100), pay_date, 23) AS pay_date, pay_cash_money, pra_cash_money, duty_person, touch_phone,
 CONVERT(varchar(100), pact_start, 23) AS pact_start, record_name, CONVERT(varchar(100), update_date, 23) AS update_date, user_note FROM BB_ItemPreserve WHERE 1=1 ", param.rows));
            _param?.Clear();
            if (!string.IsNullOrEmpty(param.unit_code))
            {
                sb.Append(" AND unit_code = @unit_code ");
                _param.Add("@unit_code", param.unit_code);
            } else if (!string.IsNullOrEmpty(param.area_code))
            {
                sb.Append(" AND area_code = @area_code "); 
                _param.Add("@area_code", param.area_code);
            }else
                sb.Append(" AND 1=0 ");
            if (!string.IsNullOrEmpty(param.status))
            {
                sb.Append(" AND ip_status = @status ");
                _param.Add("@status", param.status);
            }
            sb.Append(string.Format(@" ) tt LEFT JOIN  (SELECT DATEDIFF(dd,tt.track_date,GETDATE()) AS tail_after,tt.unit_code FROM (SELECT ROW_NUMBER() OVER(PARTITION BY unit_code ORDER BY track_date ASC) AS RowNumber,unit_code,track_date FROM BB_TrackRecord WHERE tr_status='02') AS tt WHERE tt.RowNumber=1) record ON tt.unit_code=record.unit_code LEFT JOIN  (SELECT item1.*,item2.* FROM
            (SELECT item_id, item_code FROM dbo.T_ItemCode WHERE item_code = 'ItemStatus') item1 INNER JOIN
            (SELECT code_name AS ip_status_text, code_value AS ip_status, item_id AS id FROM dbo.T_ItemCodeMenum) item2 ON item1.item_id = item2.id) code ON tt.ip_status = code.ip_status WHERE tt.RowNumber > {0} ORDER BY tt.RowNumber;", (param.page-1)*param.rows));
            DataTable dt = SqlHelper.ExecuteDataTable(sb.ToString(), CommandType.Text, SqlHelper.GetParameters(_param));
            return HCQ2_Common.Data.DataTableHelper.DataTableToIList<ItemPreserveModel>(dt);
        }
        /// <summary>
        ///  根据条件 获取项目台账记录总数
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public int GetCountData(ItemPreserveParam param)
        {
            sb?.Clear();
            sb.Append(string.Format("SELECT COUNT(*) FROM  BB_ItemPreserve WHERE 1=1 "));
            _param?.Clear();
            if (!string.IsNullOrEmpty(param.unit_code))
            {
                sb.Append(" AND unit_code = @unit_code ");
                _param.Add("@unit_code", param.unit_code);
            }
            else if (!string.IsNullOrEmpty(param.area_code))
            {
                sb.Append(" AND area_code = @area_code ");
                _param.Add("@area_code", param.area_code);
            }else
                sb.Append(" AND 1=0 ");
            if (!string.IsNullOrEmpty(param.status))
            {
                sb.Append(" AND ip_status = @status ");
                _param.Add("@status", param.status);
            }
            return Helper.ToInt(SqlHelper.ExecuteScalar(sb.ToString(), CommandType.Text, SqlHelper.GetParameters(_param)));
        }
        /// <summary>
        ///  获取用户 授权区域
        /// </summary>
        /// <param name="user_id"></param>
        /// <returns></returns>
        public List<AreaModel> GetPermissAreaData(int user_id)
        {
            List<int> rolelist = new T_PermissionsDAL().GetRolesListById(user_id);
            if (null == rolelist || rolelist.Count <= 0)
            {
                rolelist = new List<int>();
                rolelist.Add(0);
            }
            sb?.Clear();
            sb.Append(string.Format(@"SELECT code.* FROM 
            (SELECT CodeItemID,CodeItemName,Parent,Child,JPSign FROM dbo.SM_CodeItems WHERE CodeID='AB') code INNER JOIN
            (SELECT DISTINCT area.area_code FROM 
            (SELECT per_id FROM dbo.T_RolePermissRelation WHERE role_id IN({0})) a1 INNER JOIN
            (SELECT per_id FROM dbo.T_Permissions WHERE per_type = 'areaManager') p1 ON a1.per_id = p1.per_id INNER JOIN
            (SELECT per_id,area_code FROM dbo.T_AreaPermissRelation) area ON a1.per_id = area.per_id) tt ON code.CodeItemID=tt.area_code;", string.Join(",", rolelist.ToArray())));
            DataTable dt = SqlHelper.ExecuteDataTable(sb.ToString(), CommandType.Text);
            return HCQ2_Common.Data.DataTableHelper.DataTableToIList<AreaModel>(dt);
        }
    }
}
