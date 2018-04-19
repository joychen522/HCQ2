using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HCQ2_Model;
using HCQ2_Model.ViewModel;
using HCQ2_Model.ExtendsionModel;

namespace HCQ2_IBLL
{
    public partial interface IT_CompProInfoBLL
    {
        /// <summary>
        /// 获取所有的企业信息
        /// </summary>
        /// <returns></returns>
        List<T_CompProInfo> GetComPro();

        /// <summary>
        /// 根据企业ID获取企业信息
        /// </summary>
        /// <param name="com_id"></param>
        /// <returns></returns>
        T_CompProInfo GetByComID(int com_id);

        /// <summary>
        /// 根据UnitID获取所属队伍
        /// </summary>
        /// <param name="RowID"></param>
        /// <returns></returns>
        List<T_CompProInfo> GetInTeamByUnitID(string UnitID);

        /// <summary>
        /// 新增或者编辑企业信息
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        bool OperionCom(object obj);

        /// <summary>
        /// 删除企业信息
        /// </summary>
        /// <param name="com_id"></param>
        /// <returns></returns>
        bool DeleteCom(int com_id);

        /// <summary>
        /// 获取一个可以直接显示的企业目录实体集合
        /// </summary>
        /// <param name="comList"></param>
        /// <returns></returns>
        List<Dictionary<string, object>> GetComTreeModle(List<T_CompProInfo> comList);

        /// <summary>
        /// 获取页面显示数据源
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        TableModel GetPageModle(object obj);
        /// <summary>
        /// 获取已经被绑定的数据源
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        TableModel GetBindPageModel(object obj);

        /// <summary>
        /// 获取页面显示数据源
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        List<ComProInfoDalModel> GetPageComInfoModle(object obj);
        int GetPageComInfoCount(object obj);
        /// <summary>
        /// 获取企业项目显示数据源
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        TableModel GetComProjectSoure(object obj);

        /// <summary>
        /// 获取完善企业信息显示数据源
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        TableModel GetComPerfectSoure(object obj);

        /// <summary>
        /// 根据用户ID获取该用户权限下的项目信息以及企业信息
        /// </summary>
        /// <param name="user_id"></param>
        /// <returns></returns>
        List<T_CompProInfo> GetPerCompanyByUserID(int user_id);

        #region api数据

        /// <summary>
        /// 根据用户GUID获取所属项目下的劳务公司
        /// </summary>
        /// <param name="person"></param>
        /// <returns></returns>
        List<Dictionary<string, object>> GetComByGuID(HCQ2_Model.AppModel.EditPerson person);

        /// <summary>
        /// 根据企业类别统计人数
        /// </summary>
        /// <returns></returns>
        List<Dictionary<string, object>> GetCompayQXLB();

        #endregion
    }
}
