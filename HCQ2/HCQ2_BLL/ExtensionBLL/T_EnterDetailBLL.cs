using HCQ2_Model.ExtendsionModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HCQ2_BLL
{
    public partial class T_EnterDetailBLL:HCQ2_IBLL.IT_EnterDetailBLL
    {
        /// <summary>
        ///  根据企业ID获取，企业征信详细信息
        /// </summary>
        /// <param name="page">第几页</param>
        /// <param name="rows">每页数</param>
        /// <param name="id">主键</param>
        /// <param name="keyword">关键字</param>
        /// <returns></returns>
        public List<WGJG_ZXDetail> GetEnterDetailData(int page, int rows, int id, string keyword)
        {
            if (id <= 0)
                return null;
            return DBSession.IT_EnterDetailDAL.GetEnterDetailData(page,rows,id,keyword);
        }
    }
}
