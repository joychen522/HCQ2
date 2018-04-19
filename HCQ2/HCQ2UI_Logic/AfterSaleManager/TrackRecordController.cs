using HCQ2_Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using HCQ2_Model.AfterSaleModel;
using HCQ2_Model.ViewModel;
using HCQ2_Model.FormatModel;

namespace HCQ2UI_Logic.AfterSaleManager
{
    /// <summary>
    ///  跟踪记录
    /// </summary>
    public class TrackRecordController:BaseLogic
    {
        #region 1.0 跟踪记录页面首次进入 + ActionResult TrackList()
        /// <summary>
        ///  1.0 跟踪记录页面首次进入
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [HCQ2_Common.Attributes.Load]
        [HCQ2_Common.Attributes.Element]
        public ActionResult TrackList()
        {
            return View();
        }
        #endregion

        #region 1.1 初始化Table数据表 + ActionResult InitTable()
        /// <summary>
        ///  1.1 初始化Table数据表
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult InitTable()
        {
            string area_code = RequestHelper.GetStrByName("area_code"),//区域代码
                unit_code = RequestHelper.GetStrByName("unit_code"),//项目代码
                trackStatus = RequestHelper.GetDeStrByName("trackStatus"),//设备状态
                trackDate = RequestHelper.GetDeStrByName("trackDate");//跟踪时间
            int page = RequestHelper.GetIntByName("page"),
               rows = RequestHelper.GetIntByName("rows");
            TrackRecordParam param = new TrackRecordParam { rows = rows, page = page, unit_code = unit_code, area_code = area_code, trackStatus = trackStatus, trackDate = trackDate };
            List<TrackRecordModel> list = operateContext.bllSession.BB_TrackRecord.GetInitData(param);
            TableModel tModel = new TableModel()
            {
                total = operateContext.bllSession.BB_TrackRecord.GetCountData(param),
                rows = list
            };
            return Json(tModel, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region 1.2 添加设备记录 + ActionResult AddTrack(TrackRecordModel item)
        /// <summary>
        ///  添加设备记录
        /// </summary>
        /// <param name="item">跟踪对象</param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult AddTrack(TrackRecordModel item)
        {
            if (!ModelState.IsValid)
                return operateContext.RedirectAjax(1, "数据验证失败~", "", "");
            try
            {
                int mark = operateContext.bllSession.BB_TrackRecord.AddTrack(item);
                if (mark > 0)
                    return operateContext.RedirectAjax(0, "添加记录成功~", "", "");
                return operateContext.RedirectAjax(1, "添加记录失败~", "", "");
            }
            catch (Exception ex)
            {
                return operateContext.RedirectAjax(1, ex.Message, "", "");
            }
        }
        #endregion

        #region 1.3 编辑台账记录 + ActionResult EditTrack(TrackRecordModel item)
        /// <summary>
        ///  编辑台账记录
        /// </summary>
        /// <param name="item">项目记录</param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult EditTrack(TrackRecordModel item)
        {
            if (!ModelState.IsValid)
                return operateContext.RedirectAjax(1, "数据验证失败~", "", "");
            try
            {
                int tr_id = Helper.ToInt(Request["tr_id"]);
                if (tr_id <= 0)
                    return operateContext.RedirectAjax(1, "编辑记录主键值为空~", "", "");
                operateContext.bllSession.BB_TrackRecord.EditTrack(item, tr_id);
                return operateContext.RedirectAjax(0, "编辑记录成功~", "", "");
            }
            catch(Exception ex) {
                return operateContext.RedirectAjax(1, ex.Message, "", "");
            }
        }
        #endregion

        #region 1.4 删除项目记录 + ActionResult DelTrackByID(int id)
        /// <summary>
        ///  1.4 删除项目记录
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult DelTrackByID(int id)
        {
            if (id <= 0)
                return operateContext.RedirectAjax(1, "需要删除的数据不存在~", "", "");
            int mark = operateContext.bllSession.BB_TrackRecord.Delete(s => s.tr_id == id);
            if (mark > 0)
                return operateContext.RedirectAjax(0, "数据删除成功~", "", "");
            return operateContext.RedirectAjax(1, "数据删除失败~", "", "");
        }
        #endregion

        #region 1.5 根据设备编码获得设备跟踪详细信息 + ActionResult GetTrackObjByID()
        /// <summary>
        ///  1.5 根据设备编码获得设备跟踪详细信息
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult GetTrackObjByID()
        {
            string unit_code = RequestHelper.GetStrByName("unit_code"),
                fa_number = RequestHelper.GetStrByName("fa_number");
            if (string.IsNullOrEmpty(unit_code) || string.IsNullOrEmpty(fa_number))
                return null;
            TrackRecordParam param = new TrackRecordParam { rows = 10, page = 1, unit_code = unit_code, fa_number = fa_number };
            List<TrackRecordModel> list = operateContext.bllSession.BB_TrackRecord.GetInitData(param);
            if(null==list || list.Count<=0)
                return operateContext.RedirectAjax(1, "数据不存在~", "", "");
            return operateContext.RedirectAjax(0, "数据删除成功~", list.FirstOrDefault(), "");
        } 
        #endregion

        /// <summary>
        ///  1.6 获取设备编码字典
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult GetNumberDictionary()
        {
            string area_code = RequestHelper.GetStrByName("area_code"),
                unit_code = RequestHelper.GetStrByName("unit_code");
            if(string.IsNullOrEmpty(area_code) || string.IsNullOrEmpty(unit_code))
                return operateContext.RedirectAjax(1, "", "", null);
            List<CodeItemsModel> model = new List<CodeItemsModel>();
            List<string> list = operateContext.bllSession.BB_FacilityPreserve.Select(s => s.area_code == area_code && s.unit_code == unit_code).Select(s => s.fa_number).ToList();
            list.Distinct();
            foreach (var item in list)
                model.Add(new CodeItemsModel { CodeText = item, CodeValue = item });
            return operateContext.RedirectAjax(0, "", model, null);
        }
    }
}
