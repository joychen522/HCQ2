using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HCQ2_IBLL
{
    /// <summary>
    ///  工资发放模板业务层接口
    /// </summary>
    public partial interface IWGJG02_TemplateBLL
    {
        /// <summary>
        ///  通过id生成数据
        /// </summary>
        /// <param name="rowid"></param>
        /// <returns></returns>
        bool CreateDataByUnit(string rowid);
        /// <summary>
        ///  根据选中的人员字符串集合生成工资数据
        /// </summary>
        /// <param name="psersons">人员集合</param>
        /// <param name="rowid">rowid</param>
        /// <returns></returns>
        bool CreateDataByPsersons(string psersons,string rowid);
        /// <summary>
        ///  获取工资发放详细信息
        /// </summary>
        /// <param name="rowID">id</param>
        /// <param name="userName">用户名</param>
        /// <param name="page">第几页</param>
        /// <param name="rows">每页数量</param>
        /// <returns></returns>
        List<HCQ2_Model.ViewModel.WGJG02Model> GetWageDetailByRowId(string rowID,string userName, int page, int rows);
        /// <summary>
        ///  编辑数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        int EditWageTempModel(HCQ2_Model.ViewModel.WGJG02Model model);
        /// <summary>
        ///  编辑数据 一次只能编辑单个值
        /// </summary>
        /// <param name="model"></param>
        /// <param name="columnName">字段名</param>
        /// <returns></returns>
        int EditWageTempModelBySingle(HCQ2_Model.ViewModel.WGJG02Model model,string columnName);
        /// <summary>
        ///  根据单位代码 导出模板Excel
        /// </summary>
        /// <param name="model"></param>
        void ExportTemplateToExcel(string UnitID,string e0386,string in_type);
        /// <summary>
        ///  导入数据
        /// </summary>
        /// <param name="dt">数据源</param>
        /// <param name="UnitID">单位代码</param>
        /// <param name="RowID">模板ID</param>
        /// <returns></returns>
        bool ImportPersonData(System.Data.DataTable dt,string UnitID,string RowID);
    }
}
