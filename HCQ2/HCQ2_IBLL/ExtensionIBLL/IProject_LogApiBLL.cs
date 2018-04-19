using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HCQ2_Model.WebApiModel.ParamModel;

namespace HCQ2_IBLL
{
    /// <summary>
    ///  设备日志
    /// </summary>
    public partial interface IProject_LogApiBLL
    {
        /// <summary>
        ///  添加设备日志
        /// </summary>
        /// <param name="mdoel">模型</param>
        /// <returns></returns>
       int  Add(AppLogModel mdoel);
    }
}
