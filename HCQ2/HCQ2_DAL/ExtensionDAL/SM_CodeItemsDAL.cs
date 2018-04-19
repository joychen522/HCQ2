using HCQ2_Model.FormatModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HCQ2_Common.SQL;

namespace HCQ2_DAL_MSSQL
{
    public partial  class SM_CodeItemsDAL:HCQ2_IDAL.ISM_CodeItemsDAL
    {
        /// <summary>
        ///  参数
        /// </summary>
        private Dictionary<string, object> _param = new Dictionary<string, object>();
        /// <summary>
        ///  sql语句
        /// </summary>
        private StringBuilder sb = new StringBuilder();
        /// <summary>
        ///  根据code获取字典
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public List<CodeItemsModel> GetOldSysCode(string code)
        {
            if (string.IsNullOrEmpty(code))
                return null;
            sb?.Clear();
            sb.Append(string.Format(@"SELECT item.CodeItemID AS CodeValue,item.CodeItemName AS CodeText FROM
(SELECT DISTINCT E0386 FROM dbo.A01 WHERE UnitID=@code AND ISNULL(E0386,'')<>'') a01 LEFT JOIN
(SELECT CodeItemID,CodeItemName FROM dbo.SM_CodeItems WHERE CodeID='JA') item ON a01.E0386=item.CodeItemID;"));
            _param?.Clear();
            _param.Add("@code", code);
            DataTable dt = SqlHelper.ExecuteDataTable(sb.ToString(), CommandType.Text, SqlHelper.GetParameters(_param));
            return HCQ2_Common.Data.DataTableHelper.DataTableToIList<CodeItemsModel>(dt);
        }
    }
}
