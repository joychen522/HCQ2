using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HCQ2_Model.ViewModel;
using HCQ2_Model;

namespace HCQ2_IBLL
{
    public partial interface IWGJG01_TemplateBLL
    {
        /// <summary>
        ///  根据单位代码获取数据
        /// </summary>
        /// <param name="unitID">单位代码</param>
        /// <param name="page">第几页</param>
        /// <param name="rows">每页数量</param>
        /// <returns></returns>
        List<WGJG01Model> GetWageListDataByUnit(string unitID, int page, int rows);
        /// <summary>
        ///  添加对象
        /// </summary>
        /// <param name="model">对象</param>
        /// <returns></returns>
        int AddWGJG01(WGJG01_Template model);
        /// <summary>
        ///  编辑对象
        /// </summary>
        /// <param name="model">对象</param>
        /// <returns></returns>
        int EditWGJG01(WGJG01_Template model);
        /// <summary>
        ///  根据模板生成数据
        /// </summary>
        /// <param name="wgDate">约定发薪日期</param>
        /// <param name="rowId">rowID</param>
        /// <returns></returns>
        bool StartGrantByWGJG01(string wgDate,string rowId);
        /// <summary>
        ///  验证是否发放
        /// </summary>
        /// <param name="wgDate"></param>
        /// <param name="rowId"></param>
        /// <returns></returns>
        bool CheckGrantWage(string wgDate, string rowId);
    }
}
