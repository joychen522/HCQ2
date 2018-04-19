using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HCQ2_Model;
using HCQ2_Model.ViewModel;

namespace HCQ2_IBLL
{
    public partial interface IT_PayAccountBLL
    {
        /// <summary>
        /// 获取所有的项目工资账户
        /// </summary>
        /// <returns></returns>
        List<T_PayAccount> GetPayAccount();

        /// <summary>
        /// 根据项目编号获取账户信息
        /// </summary>
        /// <param name="UnitID"></param>
        /// <returns></returns>
        List<T_PayAccount> GetByUnitID(string UnitID);

        /// <summary>
        /// 根据ID获取专户
        /// </summary>
        /// <param name="pay_id"></param>
        /// <returns></returns>
        T_PayAccount GetByPayID(int pay_id);

        /// <summary>
        /// 获取页面显示的数据源
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        TableModel GetPageViewSoure(object obj);

        /// <summary>
        /// 保存或者编辑工资专户
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        bool SavePayAccount(object obj);

        /// <summary>
        /// 删除工资专户信息
        /// </summary>
        /// <param name="pay_id"></param>
        /// <returns></returns>
        bool DeletePayAccount(int pay_id);
    }
}
