using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HCQ2_IDAL
{
    /// <summary>
    ///  工资发放模板
    /// </summary>
    public partial interface IWGJG01_TemplateDAL
    {
        /// <summary>
        ///  根据单位id获取工资发放数据
        /// </summary>
        /// <param name="unitID">单位代码</param>
        /// <param name="page">第几页</param>
        /// <param name="rows">每页数量</param>
        /// <returns></returns>
        List<HCQ2_Model.ViewModel.WGJG01Model> GetWageListDataByUnit(string unitID, int page, int rows);
        /// <summary>
        ///  从模板中发放工资
        /// </summary>
        /// <param name="wgDate">约定发放日期</param>
        /// <param name="rowId">模板id</param>
        /// <returns></returns>
        bool StartGrantByWGJG01(string wgDate, string rowId);
    }
}
