using HCQ2_Common.SQL;
using HCQ2_Model.ExtendsionModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HCQ2_DAL_MSSQL
{
    public partial class T_EnterDetailDAL:HCQ2_IDAL.IT_EnterDetailDAL
    {
        /// <summary>
        ///  参数
        /// </summary>
        private Dictionary<string, object> _param = new Dictionary<string, object>();
        private StringBuilder sb = new StringBuilder();
        /// <summary>
        ///  根据企业ID获取，企业征信详细信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public List<WGJG_ZXDetail> GetEnterDetailData(int page, int rows, int id,string keyword)
        {
            if (id <= 0)
                return null;
            sb?.Clear();
            sb.Append(string.Format(@"SELECT TOP {0} zx.WGJG_ZX02,ed.ed_id,code.ent_text, ed.is_success,ed.ent_type,ed.ent_id,ed.ed_title,ed.ed_reason,ed.ed_create,ed.ed_time,ed.rank,ed.ed_note,ed.case_type,ed.pay_money,ed.pay_person,ed.solve_type FROM 
            (SELECT com_id AS auto_id,dwmc AS WGJG_ZX02 FROM dbo.T_CompProInfo WHERE com_id={1}) zx INNER JOIN
            (SELECT ed_id,ent_type,ent_id,ed_title,ed_reason,ed_create,CONVERT(varchar(100), ed_time, 23) AS ed_time,ed_note,case_type,pay_money,pay_person,solve_type,is_success,
            ROW_NUMBER() OVER (ORDER BY ed_id) as rank FROM T_EnterDetail WHERE ent_id={1}", rows, id));
            if (!string.IsNullOrEmpty(keyword))
                sb.Append(string.Format(" AND ed_title LIKE '%{0}%' ", keyword));
            sb.Append(string.Format(@" ) ed ON zx.auto_id=ed.ent_id LEFT JOIN(
	        SELECT item2.ent_text,item2.ent_type FROM
            (SELECT item_id,item_code FROM dbo.T_ItemCode WHERE item_code='ZXZT') item1 INNER JOIN
            (SELECT code_name AS ent_text,code_value AS ent_type,item_id FROM dbo.T_ItemCodeMenum) item2 ON item1.item_id = item2.item_id) code ON ed.ent_type=code.ent_type WHERE ed.rank>{0} ORDER BY ed.is_success,ed.ent_type DESC;", (page - 1) * rows));
            DataTable dt = SqlHelper.ExecuteDataTable(sb.ToString(), CommandType.Text, SqlHelper.GetParameters(_param));
            return HCQ2_Common.Data.DataTableHelper.DataTableToIList<WGJG_ZXDetail>(dt);
        }
    }
}
