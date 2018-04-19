using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HCQ2_IDAL
{
    public partial interface IWGJG02_TemplateDAL
    {
        /// <summary>
        ///  获取工资发放详细信息
        /// </summary>
        /// <param name="rowID">id</param>
        /// <param name="page">第几页</param>
        /// <param name="rows">每页数量</param>
        /// <returns></returns>
        List<HCQ2_Model.ViewModel.WGJG02Model> GetWageDetailByRowId(string rowID,string userName, int page, int rows);
        /// <summary>
        ///  根据人员字符串集合删除数据
        /// </summary>
        /// <param name="persons"></param>
        /// <param name="rowID"></param>
        /// <returns></returns>
        bool DeletePersonsData(List<string> persons,string rowID);
        /// <summary>
        ///  获取导出数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        DataTable GetExportPersonData(string UnitID, string e0386, string in_type);
    }
}
