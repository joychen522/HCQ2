using HCQ2_Model.AfterSaleModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HCQ2_IBLL
{
    public partial interface IBB_TrackRecordBLL
    {
        /// <summary>
        ///  获取跟踪记录集合
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        List<TrackRecordModel> GetInitData(TrackRecordParam param);
        /// <summary>
        ///  获取根据记录总数
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        int GetCountData(TrackRecordParam param);
        /// <summary>
        ///  添加跟踪记录
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        int AddTrack(TrackRecordModel item);
        /// <summary>
        ///  编辑跟踪记录
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        int EditTrack(TrackRecordModel item, int id);
    }
}
