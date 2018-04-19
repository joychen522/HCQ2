using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HCQ2_Model;
using HCQ2_Model.ViewModel;

namespace HCQ2_IBLL
{
    public partial interface IBB_UpDataLogBLL
    {
        /// <summary>
        /// 获取所有的上记录日志
        /// </summary>
        /// <returns></returns>
        List<BB_UpDataLog> GetLogInfo();

        /// <summary>
        /// 根据用户ID获取上报记录
        /// </summary>
        /// <param name="user_id"></param>
        /// <returns></returns>
        List<BB_UpDataLog> GetByUserID(int user_id);

        /// <summary>
        /// 写入上报信息
        /// </summary>
        /// <param name="log_type"></param>
        /// <param name="log_content"></param>
        /// <returns></returns>
        bool InsertDataLog(string log_type,string log_content, int result,string unit_id);

        /// <summary>
        /// 获取页面显示所需要的数据源
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        TableModel GetPageModel(object obj);

        /// <summary>
        /// 新增上报日志
        /// </summary>
        /// <param name="log"></param>
        /// <returns></returns>
        int AddLog(BB_UpDataLog log);

        /// <summary>
        /// 删除上报日志
        /// </summary>
        /// <param name="up_id"></param>
        /// <returns></returns>
        int Delete(int up_id);
    }
}
