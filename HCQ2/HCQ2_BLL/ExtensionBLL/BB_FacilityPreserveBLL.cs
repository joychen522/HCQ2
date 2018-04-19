using HCQ2_Model;
using HCQ2_Model.AfterSaleModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HCQ2_BLL
{
    public partial class BB_FacilityPreserveBLL:HCQ2_IBLL.IBB_FacilityPreserveBLL
    {
        /// <summary>
        ///  根据条件 获取设备数据集合
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public List<FacilityPreserveModel> GetInitData(ItemPreserveParam param)
        {
            if (null != param)
                return DBSession.IBB_FacilityPreserveDAL.GetInitData(param);
            return null;
        }
        /// <summary>
        ///  添加台账记录
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public int AddFacility(FacilityPreserveModel item)
        {
            if (null == item)
                return 0;
            BB_FacilityPreserve model = new BB_FacilityPreserve
            {
                unit_name=item.unit_name,
                unit_code=item.unit_code,
                fa_number=item.fa_number,
                touch_phone=item.touch_phone,
                install_id=item.install_id,
                install_name = item.install_name,
                install_date = DateTime.ParseExact(item.install_date, "yyyy-MM-dd", new System.Globalization.CultureInfo("zh-CN")),
                skiller_id=item.skiller_id,
                skiller = item.skiller,
                user_note =item.user_note,
                area_code=item.area_code,
                touch_name=item.touch_name
            };
            return base.Add(model);
        }
        /// <summary>
        ///  编辑台账记录
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public int EditFacility(FacilityPreserveModel item, int id)
        {
            if (null == item)
                return 0;
            BB_FacilityPreserve model = new BB_FacilityPreserve
            {
                unit_name = item.unit_name,
                unit_code = item.unit_code,
                fa_number = item.fa_number,
                touch_phone = item.touch_phone,
                install_id = item.install_id,
                install_name = item.install_name,
                install_date = DateTime.ParseExact(item.install_date, "yyyy-MM-dd", new System.Globalization.CultureInfo("zh-CN")),
                skiller = item.skiller,
                skiller_id = item.skiller_id,
                user_note = item.user_note,
                area_code = item.area_code,
                touch_name = item.touch_name
            };
            return base.Modify(model, s =>s.fp_id==id, "fa_number", "touch_phone", "install_id", "install_name", "install_date", "skiller_id", "skiller", "user_note", "touch_name");
        }
        /// <summary>
        ///  根据条件 获取项目台账记录总数
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public int GetCountData(ItemPreserveParam param)
        {
            if (null != param)
                return DBSession.IBB_FacilityPreserveDAL.GetCountData(param);
            return 0;
        }
    }
}
