using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HCQ2_Common.SQL;
using HCQ2_Model;
using HCQ2_Model.WeiXinApiModel.ParamModel;
using HCQ2_Model.WeiXinApiModel.ResultApiModel;

namespace HCQ2_DAL_MSSQL
{
    public partial class WGJG_GRZXDAL:HCQ2_IDAL.IWGJG_GRZXDAL
    {
        /// <summary>
        ///  参数
        /// </summary>
        private Dictionary<string, object> _param=new Dictionary<string, object>();
        public List<WGJG_GRZX> SelectOwnDataByName(int page, int rows, string userName)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(string.Format(@"SELECT TOP {0} * FROM
                (SELECT TOP {1} w1.RowID,w1.WGJG_GRZX01,w1.WGJG_GRZX02,w1.WGJG_GRZX03,w1.WGJG_GRZX05,w1.WGJG_GRZX07,
		                w1.WGJG_GRZX08,w1.WGJG_GRZX09,w1.WGJG_GRZX10,w1.WGJG_GRZX11,MZ.WGJG_GRZX04,ZXZT.WGJG_GRZX06 FROM
	                (SELECT * FROM dbo.WGJG_GRZX ", rows, page*rows));
            if (!string.IsNullOrEmpty(userName))
                sb.Append(string.Format(" WHERE WGJG_GRZX02 LIKE '%{0}%' ",userName));
            sb.Append(@"  ) w1 LEFT JOIN
	                (SELECT item2.WGJG_GRZX04,item2.WGJG_GRZX04_value FROM
		                (SELECT item_id,item_code FROM dbo.T_ItemCode WHERE item_code='MZ') item1 INNER JOIN
		                (SELECT code_name AS WGJG_GRZX04,code_value AS WGJG_GRZX04_value,item_id AS id FROM dbo.T_ItemCodeMenum) item2 ON item1.item_id = item2.id) MZ
	                ON w1.WGJG_GRZX04=MZ.WGJG_GRZX04_value LEFT JOIN
	                (SELECT item2.WGJG_GRZX06,item2.WGJG_GRZX06_value FROM
		                (SELECT item_id,item_code FROM dbo.T_ItemCode WHERE item_code='ZXZT') item1 INNER JOIN
		                (SELECT code_name AS WGJG_GRZX06,code_value AS WGJG_GRZX06_value,item_id AS id FROM dbo.T_ItemCodeMenum) item2 ON item1.item_id = item2.id) ZXZT
	                ON w1.WGJG_GRZX06=ZXZT.WGJG_GRZX06_value
	                ORDER BY w1.auto_id DESC
                ) wg");
            DataTable dt = HCQ2_Common.SQL.SqlHelper.ExecuteDataTable(sb.ToString(), System.Data.CommandType.Text);
            return HCQ2_Common.Data.DataTableHelper.DataTableToIList<HCQ2_Model.WGJG_GRZX>(dt);
        }

        public int SelectCountOwnData(string userName)
        {
            if (!string.IsNullOrEmpty(userName))
                return SelectCount(s => s.WGJG_GRZX02.Contains(userName));
            return SelectCount(s => !string.IsNullOrEmpty(s.WGJG_GRZX02));
        }

        public List<CompanyOwnResultModel> GetComOwnByName(CompanyModel model)
        {
            if (null == model)
                return null;
            StringBuilder sb=new StringBuilder();
            sb.Append(string.Format(@"select top {0} * from(
select w1.WGJG_GRZX02,w1.WGJG_GRZX03,w1.WGJG_GRZX05,ZXZT.WGJG_ZX06,w1.WGJG_GRZX07,w1.WGJG_GRZX09,ROW_NUMBER() OVER(order by w1.auto_id) as DispOrder from
(select auto_id,WGJG_GRZX02,WGJG_GRZX03,WGJG_GRZX05,WGJG_GRZX06,WGJG_GRZX07,WGJG_GRZX09 from WGJG_GRZX ", model.size));
            if (!string.IsNullOrEmpty(model.keyword))
                sb.Append(" where WGJG_GRZX02 like @keyword ");
            sb.Append(string.Format(@") w1 left join
            (SELECT item2.WGJG_ZX06,item2.WGJG_ZX06_value FROM
            (SELECT item_id,item_code FROM dbo.T_ItemCode WHERE item_code='ZXZT') item1 INNER JOIN
            (SELECT code_name AS WGJG_ZX06,code_value AS WGJG_ZX06_value,item_id AS id FROM dbo.T_ItemCodeMenum) item2 ON item1.item_id = item2.id) ZXZT
            ON w1.WGJG_GRZX06=ZXZT.WGJG_ZX06_value) as A where A.DispOrder>{0}", (model.page - 1) * model.size));
            _param?.Clear();
            if(!string.IsNullOrEmpty(model.keyword))
                _param.Add("@keyword", string.Format("%{0}%", model.keyword));
            DataTable dt = SqlHelper.ExecuteDataTable(sb.ToString(), CommandType.Text, SqlHelper.GetParameters(_param));
            return HCQ2_Common.Data.DataTableHelper.DataTableToIList<CompanyOwnResultModel>(dt);
        }
    }
}
