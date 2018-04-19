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
    public partial class WGJG_ZXDAL : HCQ2_IDAL.IWGJG_ZXDAL
    {
        /// <summary>
        ///  参数
        /// </summary>
        private Dictionary<string, object> _param = new Dictionary<string, object>();
        private StringBuilder sb = new StringBuilder();
        public List<WGJG_ZX> SelUnitDataByName(int page, int rows, string keyword)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(string.Format(@"SELECT TOP {0} * FROM(
SELECT RowID,WGJG_ZX01,WGJG_ZX02,WGJG_ZX05,WGJG_ZX06,WGJG_ZX07,WGJG_ZX08,WGJG_ZX09,WGJG_ZX10,WGJG_ZX11,WGJG_ZX12,
	WGJG_ZX14,WGJG_ZX15,WGJG_ZX16,WGJG_ZX17,WGJG_ZX18,DispOrder,auto_id,w1.RowNumber,b01.WGJG_ZX03,b01.WGJG_ZX04,b01.WGJG_ZX13,ZXZT.WGJG_ZX06_text,
	LSGX.WGJG_ZX16_text,HYLB.WGJG_ZX17_text FROM
	(SELECT ROW_NUMBER() OVER(ORDER BY auto_id) AS RowNumber,* FROM dbo.WGJG_ZX WHERE 1=1 ", rows));
            if (!string.IsNullOrEmpty(keyword))
                sb.Append(string.Format(" AND WGJG_ZX02 LIKE '%{0}%' ", keyword));
            sb.Append(string.Format(@") w1 LEFT JOIN
(SELECT B0182 AS WGJG_ZX03,D010H AS WGJG_ZX04,UnitManage AS WGJG_ZX13,UnitName FROM dbo.B01) b01 ON w1.WGJG_ZX02=b01.UnitName LEFT JOIN
	(SELECT item2.WGJG_ZX06_text,item2.WGJG_ZX06_value FROM
		(SELECT item_id,item_code FROM dbo.T_ItemCode WHERE item_code='ZXZT') item1 INNER JOIN
		(SELECT code_name AS WGJG_ZX06_text,code_value AS WGJG_ZX06_value,item_id AS id FROM dbo.T_ItemCodeMenum) item2 ON item1.item_id = item2.id) ZXZT
	ON w1.WGJG_ZX06=ZXZT.WGJG_ZX06_value LEFT JOIN
	(SELECT item2.WGJG_ZX16_text,item2.WGJG_ZX16_value FROM
		(SELECT item_id,item_code FROM dbo.T_ItemCode WHERE item_code='LSGX') item1 INNER JOIN
		(SELECT code_name AS WGJG_ZX16_text,code_value AS WGJG_ZX16_value,item_id AS id FROM dbo.T_ItemCodeMenum) item2 ON item1.item_id = item2.id) LSGX
	ON w1.WGJG_ZX16=LSGX.WGJG_ZX16_value LEFT JOIN
	(SELECT item2.WGJG_ZX17_text,item2.WGJG_ZX17_value FROM
		(SELECT item_id,item_code FROM dbo.T_ItemCode WHERE item_code='HYLB') item1 INNER JOIN
		(SELECT code_name AS WGJG_ZX17_text,code_value AS WGJG_ZX17_value,item_id AS id FROM dbo.T_ItemCodeMenum) item2 ON item1.item_id = item2.id) HYLB
	ON w1.WGJG_ZX17=HYLB.WGJG_ZX17_value)tt
	WHERE tt.RowNumber>{0}", rows * (page - 1)));
            DataTable dt = HCQ2_Common.SQL.SqlHelper.ExecuteDataTable(sb.ToString(), System.Data.CommandType.Text);
            return HCQ2_Common.Data.DataTableHelper.DataTableToIList<WGJG_ZX>(dt);
        }

        public int SelCountByName(string keyword)
        {
            StringBuilder sb = new StringBuilder();
            if (!string.IsNullOrEmpty(keyword))
                sb.Append(string.Format("SELECT COUNT(*) FROM dbo.WGJG_ZX WHERE WGJG_ZX02 LIKE '%{0}%'", keyword));
            else
                sb.Append("SELECT COUNT(*) FROM dbo.WGJG_ZX");
            return HCQ2_Common.Helper.ToInt(HCQ2_Common.SQL.SqlHelper.ExecuteScalar(sb.ToString(), CommandType.Text));
        }

        public List<CompanyEnterResultModel> GetComEnterByName(CompanyModel model)
        {
            if (null == model)
                return null;
            StringBuilder sb = new StringBuilder();
            sb.Append(string.Format(@"select top {0} * from ( select w1.WGJG_ZX02,w1.WGJG_ZX03,w1.WGJG_ZX04,w1.WGJG_ZX05,ZXZT.WGJG_ZX06,w1.WGJG_ZX07,w1.WGJG_ZX09,ROW_NUMBER() OVER(order by w1.auto_id) as DispOrder from
                        (select auto_id,WGJG_ZX02,WGJG_ZX03,WGJG_ZX04,WGJG_ZX05,WGJG_ZX06,WGJG_ZX07,WGJG_ZX09 from WGJG_ZX ", model.size));
            if (!string.IsNullOrEmpty(model.keyword))
                sb.Append(" where WGJG_ZX02 like @keyword");
            sb.Append(string.Format(@") w1 left join
                        (SELECT item2.WGJG_ZX06,item2.WGJG_ZX06_value FROM
                        (SELECT item_id,item_code FROM dbo.T_ItemCode WHERE item_code='ZXZT') item1 INNER JOIN
                        (SELECT code_name AS WGJG_ZX06,code_value AS WGJG_ZX06_value,item_id AS id FROM dbo.T_ItemCodeMenum) item2 ON item1.item_id = item2.id) ZXZT
                        ON w1.WGJG_ZX06=ZXZT.WGJG_ZX06_value)as A where A.DispOrder>{0}", (model.page - 1) * model.size));
            _param?.Clear();
            if (!string.IsNullOrEmpty(model.keyword))
                _param.Add("@keyword", string.Format("%{0}%", model.keyword));
            DataTable dt = SqlHelper.ExecuteDataTable(sb.ToString(), CommandType.Text, SqlHelper.GetParameters(_param));
            return HCQ2_Common.Data.DataTableHelper.DataTableToIList<CompanyEnterResultModel>(dt);
        }

        /// <summary>
        /// 获取企业征信
        /// </summary>
        /// <param name="com"></param>
        /// <returns></returns>
        public List<HCQ2_Model.APPModel.ResultApiModel.CreditModelResult> GetCompayProobjectList(CompanyModel com)
        {
            sb?.Clear();
            sb.Append(string.Format(@"SELECT TOP {0} * FROM( SELECT cinfos.com_id,cinfos.UnitName,code1.UnitType,cinfos.TrustCode,cinfos.LegalPerson,del.ed_id,del.ent_name,code2.ent_type,del.update_time,ISNULL(del.update_name,'') AS update_name,del.solve_type,ROW_NUMBER() OVER(ORDER BY del.ent_type DESC) AS orderType FROM (SELECT com_id,dwmc AS UnitName,QXLB,tyshxydm AS TrustCode,Fddbrxm AS LegalPerson FROM dbo.T_CompProInfo ", com.size));
            if (!string.IsNullOrEmpty(com.keyword))
                sb.Append(string.Format(" WHERE dwmc LIKE '%{0}%' ", com.keyword));
            sb.Append(string.Format(@" ) cinfos INNER JOIN
            (SELECT * FROM (SELECT ed_id,ent_id,ent_name='双龙航空港经济区政法与群众工作局',ent_type,CONVERT(varchar(100),update_time,23) AS update_time,
            update_name,solve_type=(CASE WHEN solve_type=0 THEN '未处理' ELSE '已处理' END),ROW_NUMBER() OVER(partition BY ent_id ORDER BY solve_type,ent_type DESC) AS order_index 
                         FROM T_EnterDetail WHERE is_success=0) oder WHERE oder.order_index=1) del ON cinfos.com_id=del.ent_id LEFT JOIN
            (SELECT item2.UnitType,item2.code_value FROM
                (SELECT item_id,item_code FROM dbo.T_ItemCode WHERE item_code='QYLSZBFB') item1 INNER JOIN
                (SELECT code_name AS UnitType,code_value,item_id AS id FROM dbo.T_ItemCodeMenum) item2 
                ON item1.item_id = item2.id) code1 ON cinfos.QXLB=code1.code_value LEFT JOIN
            (SELECT item2.ent_type,item2.code_value FROM
                (SELECT item_id,item_code FROM dbo.T_ItemCode WHERE item_code='ZXZT') item1 INNER JOIN
                (SELECT code_name AS ent_type,code_value,item_id AS id FROM dbo.T_ItemCodeMenum) item2 
                ON item1.item_id = item2.id) code2 ON del.ent_type=code2.code_value) delInfo WHERE delInfo.orderType>{0};", (com.page - 1) * com.size));
            DataTable dt = SqlHelper.ExecuteDataTable(sb.ToString());
            return HCQ2_Common.Data.DataTableHelper.DataTableToIList<HCQ2_Model.APPModel.ResultApiModel.CreditModelResult>(dt);
        }
        /// <summary>
        /// 获取企业征信明细
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public List<HCQ2_Model.APPModel.ResultApiModel.EnterCompanyDetail> GetCompayEnterDetail(CompanyDetailModel model)
        {
            sb?.Clear();
            sb.Append(string.Format(@"SELECT TOP {0} * FROM 
(SELECT ed_id,ed_title,ed_reason,ed_note,CONVERT(varchar(100),ed_time,23) AS ed_time,ed_create,solve_type=(CASE WHEN solve_type=0 THEN '未处理' ELSE '已处理' END),ent_type,
ROW_NUMBER() OVER(partition BY ent_id ORDER BY solve_type,ent_type DESC) AS order_index 
 FROM dbo.T_EnterDetail WHERE ent_id={1}) infos WHERE infos.order_index>{2};", model.size,model.com_id, (model.page - 1) * model.size));
            DataTable dt = SqlHelper.ExecuteDataTable(sb.ToString());
            return HCQ2_Common.Data.DataTableHelper.DataTableToIList<HCQ2_Model.APPModel.ResultApiModel.EnterCompanyDetail>(dt);
        }
    }
}
