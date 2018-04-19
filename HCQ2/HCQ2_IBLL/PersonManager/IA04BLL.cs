using HCQ2_Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HCQ2_IBLL
{
    public partial interface IA04BLL
    {
        /// <summary>
        /// 获取所有人员学历信息
        /// </summary>
        /// <returns></returns>
        List<A04> GetA04Info();

        /// <summary>
        /// 根据人员编号获取学历信息
        /// </summary>
        /// <param name="PersonID"></param>
        /// <returns></returns>
        List<A04> GetByPersonID(string PersonID);

        /// <summary>
        /// 将一个学历集合里面的代码行字段全部替换
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        List<A04> GetCodeItemA04(List<A04> list);

        /// <summary>
        /// 将一个学历实体类里面的代码行字段全部替换
        /// </summary>
        /// <param name="A04"></param>
        /// <returns></returns>
        A04 GetCodeItemEntity(A04 A04);

        /// <summary>
        /// 根据RowID获取一条学历信息
        /// </summary>
        /// <param name="RowID"></param>
        /// <returns></returns>
        A04 GetByRowID(string RowID);

        /// <summary>
        /// 添加学历学位信息
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        bool AddEdu(object obj);

        /// <summary>
        /// 修改学历学位信息
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        bool EditEdu(object obj);
    }
}
