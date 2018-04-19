using HCQ2_Common;
using HCQ2_Common.SQL;
using HCQ2_Model.AfterSaleModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HCQ2_DAL_MSSQL
{
    public partial class BB_TrackRecordDAL:HCQ2_IDAL.IBB_TrackRecordDAL
    {
        /// <summary>
        ///  参数
        /// </summary>
        private Dictionary<string, object> _param = new Dictionary<string, object>();
        private StringBuilder sb = new StringBuilder();
        /// <summary>
        ///  获取跟踪记录集合
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public List<TrackRecordModel> GetInitData(TrackRecordParam param)
        {
            sb?.Clear();
            sb.Append(string.Format(@"SELECT TOP {0} tt.*,code.tr_status_text FROM 
(SELECT ROW_NUMBER() OVER(ORDER BY tr_id) AS RowNumber,tr_id,area_code,unit_name,unit_code,fa_number,tr_status,
CONVERT(varchar(100),track_date,23) AS track_date,track_name,tr_note FROM BB_TrackRecord WHERE 1=1 ", param.rows));
            _param?.Clear();
            //项目/区域
            if (!string.IsNullOrEmpty(param.unit_code))
            {
                sb.Append(" AND unit_code = @unit_code ");
                _param.Add("@unit_code", param.unit_code);
            }
            else if (!string.IsNullOrEmpty(param.area_code))
            {
                sb.Append(" AND area_code = @area_code ");
                _param.Add("@area_code", param.area_code);
            }
            else
                sb.Append(" AND 1=0 ");
            //设备编码
            if (!string.IsNullOrEmpty(param.fa_number))
            {
                sb.Append(" AND fa_number = @fa_number ");
                _param.Add("@fa_number", param.fa_number);
            }
            //状态
            if (!string.IsNullOrEmpty(param.trackStatus))
            {
                sb.Append(" AND tr_status = @tr_status ");
                _param.Add("@tr_status", param.trackStatus);
            }
            //跟踪时间
            if (!string.IsNullOrEmpty(param.trackDate))
            {
                sb.Append(string.Format(" AND CONVERT(varchar(100),track_date,23)=@track_date "));
                _param.Add("@track_date", param.trackDate);
            }      
            sb.Append(string.Format(@" ) tt LEFT JOIN(SELECT item1.*,item2.* FROM
            (SELECT item_id, item_code FROM dbo.T_ItemCode WHERE item_code = 'TrackStatus') item1 INNER JOIN
            (SELECT code_name AS tr_status_text, code_value AS tr_status, item_id AS id FROM dbo.T_ItemCodeMenum) item2 ON item1.item_id = item2.id) code ON tt.tr_status = code.tr_status WHERE tt.RowNumber > {0} ORDER BY tt.RowNumber;", (param.page - 1) * param.rows));
            DataTable dt = SqlHelper.ExecuteDataTable(sb.ToString(), CommandType.Text, SqlHelper.GetParameters(_param));
            return HCQ2_Common.Data.DataTableHelper.DataTableToIList<TrackRecordModel>(dt);
        }
        /// <summary>
        ///  获取根据记录总数
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public int GetCountData(TrackRecordParam param)
        {
            sb?.Clear();
            sb.Append(string.Format(@"SELECT COUNT(*) FROM BB_TrackRecord WHERE 1=1 "));
            _param?.Clear();
            //项目/区域
            if (!string.IsNullOrEmpty(param.unit_code))
            {
                sb.Append(" AND unit_code = @unit_code ");
                _param.Add("@unit_code", param.unit_code);
            }
            else if (!string.IsNullOrEmpty(param.area_code))
            {
                sb.Append(" AND area_code = @area_code ");
                _param.Add("@area_code", param.area_code);
            }
            else
                sb.Append(" AND 1=0 ");
            //状态
            if (!string.IsNullOrEmpty(param.trackStatus))
            {
                sb.Append(" AND tr_status = @tr_status ");
                _param.Add("@tr_status", param.trackStatus);
            }
            //跟踪时间
            if (!string.IsNullOrEmpty(param.trackDate))
            {
                sb.Append(string.Format(" AND CONVERT(varchar(100),track_date,23)=@track_date "));
                _param.Add("@track_date", param.trackDate);
            }
           return Helper.ToInt(SqlHelper.ExecuteScalar(sb.ToString(), CommandType.Text, SqlHelper.GetParameters(_param)));
        }
    }
}
