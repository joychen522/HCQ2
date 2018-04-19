using HCQ2_Common.SQL;
using HCQ2_Model.ExtendsionModel;
using HCQ2_Model.ViewModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HCQ2_Model.ViewModel;
using HCQ2_Model;

namespace HCQ2_DAL_MSSQL
{
    public partial class T_CompProInfoDAL : HCQ2_IDAL.IT_CompProInfoDAL
    {
        /// <summary>
        ///  参数
        /// </summary>
        private Dictionary<string, object> _param = new Dictionary<string, object>();
        /// <summary>
        ///  sql
        /// </summary>
        private StringBuilder sb = new StringBuilder();
        /// <summary>
        ///  获取指定企业的所属队伍
        /// </summary>
        /// <param name="unitID"></param>
        /// <returns></returns>
        public List<ComProModel> GetComProData(string unitID)
        {
            if (string.IsNullOrEmpty(unitID))
                return null;
            sb?.Clear();
            sb.Append(string.Format(@"SELECT info.* FROM 
            (SELECT DISTINCT in_team FROM dbo.A01 WHERE UnitID = @UnitID AND ISNULL(in_team, '') <> '') team INNER JOIN
            (SELECT com_id AS com_value, dwmc AS com_text FROM dbo.T_CompProInfo) info ON team.in_team = info.com_value"));
            _param?.Clear();
            _param.Add("@UnitID", unitID);
            DataTable dt = SqlHelper.ExecuteDataTable(sb.ToString(), CommandType.Text, SqlHelper.GetParameters(_param));
            return HCQ2_Common.Data.DataTableHelper.DataTableToIList<ComProModel>(dt);
        }
        /// <summary>
        /// 获取页面显示数据源
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public List<ComProInfoDalModel> GetPageComInfoModle(ComProInfoModel obj)
        {
            sb?.Clear();
            sb.Append(string.Format(@"SELECT TOP {0} * FROM(SELECT *,ROW_NUMBER() OVER(ORDER BY ent_type DESC) AS orderType FROM 
            (SELECT infos.com_id,infos.dwmc,infos.tyshxydm,infos.Fddbrxm,infos.Fddbrdh,CAST(infos.RowNumber AS INT) AS RowNumber,codes.WGJG_ZX06,del.ent_type,del.solve_type FROM 
            (SELECT *,ROW_NUMBER() OVER(ORDER BY com_id) AS RowNumber FROM dbo.T_CompProInfo WHERE 1=1 ", obj.rows));
            if (!string.IsNullOrEmpty(obj.txtSearchName))
                sb.Append(string.Format(" AND dwmc LIKE '%{0}%' ", obj.txtSearchName));
            if (!string.IsNullOrEmpty(obj.JianDieUnitID))
                sb.Append(string.Format(" AND SJDW='{0}' ", obj.JianDieUnitID));
            sb.Append(string.Format(@" )infos LEFT JOIN
             (SELECT * FROM (SELECT *,ROW_NUMBER() OVER(partition BY ent_id ORDER BY solve_type,ent_type DESC) AS order_index FROM T_EnterDetail WHERE is_success=0) del WHERE del.order_index=1) del ON infos.com_id=del.ent_id LEFT JOIN
             (SELECT item2.WGJG_ZX06,item2.WGJG_ZX06_value FROM
                (SELECT item_id,item_code FROM dbo.T_ItemCode WHERE item_code='ZXZT') item1 INNER JOIN
                (SELECT code_name AS WGJG_ZX06,code_value AS WGJG_ZX06_value,item_id AS id FROM dbo.T_ItemCodeMenum) item2 ON item1.item_id = item2.id) codes 
                ON del.ent_type=codes.WGJG_ZX06_value) coms) infos WHERE infos.orderType>{0};", obj.rows * (obj.page - 1)));
            DataTable dt = SqlHelper.ExecuteDataTable(sb.ToString());
            return HCQ2_Common.Data.DataTableHelper.DataTableToIList<ComProInfoDalModel>(dt);
        }

        /// <summary>
        /// 获取已经被项目绑定的企业
        /// </summary>
        /// <returns></returns>
        public List<T_CompProInfo> GetBindProjectCom()
        {
            List<T_CompProInfo> comList = new List<T_CompProInfo>();
            sb = new StringBuilder();
            sb.AppendFormat(" select * from T_CompProInfo where QXLB='01' and com_id in (");
            sb.AppendFormat(" select in_compay from B01 where LEN(UnitID)=3)");
            comList = HCQ2_Common.Data.DataTableHelper.DataTableToIList<T_CompProInfo>(
                HCQ2_Common.SQL.SqlHelper.ExecuteDataTable(sb.ToString()));
            return comList;
        }
    }
}
