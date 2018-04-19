using HCQ2_Model.AfterSaleModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HCQ2_BLL
{
    public partial class BB_TrackRecordBLL:HCQ2_IBLL.IBB_TrackRecordBLL
    {
        /// <summary>
        ///  获取跟踪记录集合
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public List<TrackRecordModel> GetInitData(TrackRecordParam param)
        {
            if (null == param)
                return null;
            return DBSession.IBB_TrackRecordDAL.GetInitData(param);
        }
        /// <summary>
        ///  获取根据记录总数
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public int GetCountData(TrackRecordParam param)
        {
            return DBSession.IBB_TrackRecordDAL.GetCountData(param);
        }
        /// <summary>
        ///  添加跟踪记录
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public int AddTrack(TrackRecordModel item)
        {
            if (null == item)
                return 0;
            HCQ2_Model.BB_TrackRecord model = new HCQ2_Model.BB_TrackRecord
            {
                unit_name = item.unit_name,
                unit_code = item.unit_code,
                tr_status = item.tr_status,
                fa_number = item.fa_number,
                track_date = DateTime.ParseExact(item.track_date, "yyyy-MM-dd", new System.Globalization.CultureInfo("zh-CN")),
                tr_note = item.tr_note,
                area_code = item.area_code,
                track_name = item.track_name
            };
            return base.Add(model);
        }
        /// <summary>
        ///  编辑跟踪记录
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public int EditTrack(TrackRecordModel item, int id)
        {
            if (null == item)
                return 0;
            HCQ2_Model.BB_TrackRecord model = new HCQ2_Model.BB_TrackRecord
            {
                unit_name = item.unit_name,
                unit_code = item.unit_code,
                tr_status = item.tr_status,
                fa_number=item.fa_number,
                track_date = DateTime.ParseExact(item.track_date, "yyyy-MM-dd", new System.Globalization.CultureInfo("zh-CN")),
                tr_note = item.tr_note,
                area_code = item.area_code,
                track_name = item.track_name
            };
            return base.Modify(model, s => s.tr_id == id, "tr_status", "fa_number", "track_date", "tr_note", "track_name");
        }
    }
}
