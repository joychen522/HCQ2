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
    public partial class BB_FacilityPreserveDAL:HCQ2_IDAL.IBB_FacilityPreserveDAL
    {
        /// <summary>
        ///  参数
        /// </summary>
        private Dictionary<string, object> _param = new Dictionary<string, object>();
        private StringBuilder sb = new StringBuilder();
        /// <summary>
        ///  根据条件 获取设备数据集合
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public List<FacilityPreserveModel> GetInitData(ItemPreserveParam param)
        {
            sb?.Clear();
            sb.Append(string.Format(@"SELECT TOP {0} * FROM (SELECT tt.*,ROW_NUMBER() OVER(ORDER BY fp_id) AS RowNumber,CAST(DATEDIFF(day,track.track_date,GETDATE()) AS NVARCHAR(10)) AS tail_after,ylong.deviceid,(CASE WHEN (ylong.preDate>30 or ISNULL(ylong.deviceid,'')='') THEN '异常' ELSE '正常' END) as fa_status_text FROM 
(SELECT fp_id,area_code,unit_name,unit_code,fa_number,touch_name,
touch_phone,install_name,install_id,CONVERT(varchar(100),install_date,23) AS install_date,skiller,skiller_id,user_note FROM BB_FacilityPreserve WHERE 1=1 ", param.rows));
            _param?.Clear();
            //项目/区域
            if (!string.IsNullOrEmpty(param.unit_code))
            {
                sb.Append(" AND unit_code = @unit_code ");
                _param.Add("@unit_code", param.unit_code);
            }
            else if (!string.IsNullOrEmpty(param.area_code))
            {
                //区域代码
                sb.Append(" AND area_code = @area_code ");
                _param.Add("@area_code", param.area_code);
            }
            else
                sb.Append(" AND 1=0 ");
            //安装人
            if (!string.IsNullOrEmpty(param.install_name))
                sb.Append(string.Format(" AND install_name LIKE '%{0}%' ", param.install_name));
            //技术支持
            if (!string.IsNullOrEmpty(param.skiller))
                sb.Append(string.Format(" AND skiller LIKE '%{0}%' ", param.skiller));
            sb.Append(") tt LEFT JOIN (SELECT t.deviceid,t.sy_date,DATEDIFF(mi,sy_date,GETDATE()) AS preDate FROM (SELECT *,ROW_NUMBER() OVER (PARTITION BY deviceid ORDER BY sy_date DESC) AS number FROM T_Synchronous WHERE 1=1 ");
            if (!string.IsNullOrEmpty(param.unit_code))
            {
                sb.Append(" AND sy_unit_id = @sy_unit_id ");
                _param.Add("@sy_unit_id", param.unit_code);
            }
            sb.Append(string.Format(@") t WHERE t.number=1) ylong ON tt.fa_number=ylong.deviceid  LEFT JOIN (SELECT * FROM (SELECT fa_number,track_date,ROW_NUMBER() OVER(PARTITION BY fa_number ORDER BY track_date DESC) AS RowCordNumber FROM dbo.BB_TrackRecord WHERE tr_status='01' "));
            if (!string.IsNullOrEmpty(param.unit_code))
            {
                sb.Append(" AND unit_code = @track_code ");
                _param.Add("@track_code", param.unit_code);
            }
            else if (!string.IsNullOrEmpty(param.area_code))
            {
                //区域代码
                sb.Append(" AND area_code = @track_code ");
                _param.Add("@track_code", param.area_code);
            }
            else
                sb.Append(" AND 1=0 ");
            sb.Append(string.Format(" ) Record WHERE Record.RowCordNumber=1) track ON track.fa_number=tt.fa_number WHERE 1=1 "));
            if (!string.IsNullOrEmpty(param.status))
            {
                //正常
                if (param.status == "1")
                    sb.Append(" AND DATEDIFF(mi,ylong.sy_date,GETDATE())<=30 ");
                else
                    sb.Append(" AND (DATEDIFF(mi,ylong.sy_date,GETDATE())>30 OR ISNULL(ylong.sy_date,'')='')");
            }
            sb.Append(string.Format(") item WHERE item.RowNumber > {0};", (param.page - 1) * param.rows));
            DataTable dt = SqlHelper.ExecuteDataTable(sb.ToString(), CommandType.Text, SqlHelper.GetParameters(_param));
            return HCQ2_Common.Data.DataTableHelper.DataTableToIList<FacilityPreserveModel>(dt);
        }
        /// <summary>
        ///  根据条件 获取项目台账记录总数
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public int GetCountData(ItemPreserveParam param)
        {
            sb?.Clear();
            sb.Append(string.Format("SELECT COUNT(*) FROM (SELECT fa_number FROM BB_FacilityPreserve WHERE 1=1 "));
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
            //安装人
            if (!string.IsNullOrEmpty(param.install_name))
                sb.Append(string.Format(" AND install_name LIKE '%{0}%' ", param.install_name));
            //技术支持
            if (!string.IsNullOrEmpty(param.skiller))
                sb.Append(string.Format(" AND skiller LIKE '%{0}%' ", param.skiller));
            sb.Append(string.Format(@") tt LEFT JOIN (SELECT t.deviceid,t.sy_date FROM (SELECT *,ROW_NUMBER() OVER (PARTITION BY deviceid ORDER BY sy_date DESC) AS number FROM T_Synchronous WHERE 1=1 "));
            if (!string.IsNullOrEmpty(param.unit_code))
            {
                sb.Append(" AND sy_unit_id = @sy_unit_id ");
                _param.Add("@sy_unit_id", param.unit_code);
            }
            sb.Append(string.Format(@" ) t WHERE t.number=1) ylong ON tt.fa_number=ylong.deviceid WHERE 1=1  "));
            if (!string.IsNullOrEmpty(param.status))
            {
                //正常
                if(param.status == "1")
                    sb.Append(" AND DATEDIFF(mi,ylong.sy_date,GETDATE())<=30 ");
                else
                    sb.Append(" AND (DATEDIFF(mi,ylong.sy_date,GETDATE())>30 OR ISNULL(ylong.sy_date,'')='')");
            }
            return Helper.ToInt(SqlHelper.ExecuteScalar(sb.ToString(), CommandType.Text, SqlHelper.GetParameters(_param)));
        }
    }
}
