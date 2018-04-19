using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using HCQ2_Common;
using HCQ2_Model;
using HCQ2_Model.ViewModel;

namespace HCQ2UI_Logic
{
    /// <summary>
    ///  欠薪统计，控制器
    /// </summary>
    public class DebtStatisticsController : BaseLogic
    {
        #region 1.0 欠薪时间首次进入页面跳转 + ActionResult DebtTime()
        /// <summary>
        ///  欠薪时间首次进入页面跳转
        /// </summary>
        /// <returns></returns>
        [HCQ2_Common.Attributes.Load]
        public ActionResult DebtTime()
        {
            return View("DebtTime");
        }
        #endregion

        #region 1.1 获取欠薪时间数据 + ActionResult GetDebtTimeData()
        /// <summary>
        ///  根据单位代码获取欠薪时间数据
        /// </summary>
        /// <param name="unitCode">单位代码</param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult GetDebtTimeData()
        {
            //string unitID = "011002";
            string unitID = Helper.ToString(Request["unitID"]);
            int keyChild = Helper.ToInt(Request["keyChild"]);
            EchartsVo dm = base.operateContext.bllSession.View_QXTJ.GetDebtTimeData(unitID, keyChild);
            return operateContext.RedirectAjax(0, "", dm, null);
        }
        #endregion

        #region 1.2 获取单位信息数据 +ActionResult GetUnitInfo()
        /// <summary>
        ///  获取单位信息数据
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult GetUnitInfo()
        {
            return operateContext.RedirectAjax(0,"成功", operateContext.bllSession.B01.GetB01Data(operateContext.Usr.user_id), "");
        }
        #endregion

        #region 1.3 根据权限获取单位信息数据 必须在View_QXTJ单位表存在 +ActionResult GetUnitInfo()
        /// <summary>
        ///  获取单位信息数据
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult GetUnitInfoByView_QXTJ()
        {
            return operateContext.RedirectAjax(0, "成功", operateContext.bllSession.B01.GetB01InfoByQXTJ(operateContext.Usr.user_id), "");
        }
        #endregion

        #region 2.0 欠薪金额首次页面进入 +ActionResult DebtMoney()
        /// <summary>
        ///  欠薪金额首次页面进入
        /// </summary>
        /// <returns></returns>
        [HCQ2_Common.Attributes.Load]
        public ActionResult DebtMoney()
        {
            return View();
        } 
        #endregion

        #region 2.1 获取欠薪金额前端数据 + ActionResult GetMoneyData()
        /// <summary>
        ///  获取欠薪金额数据 首页统计前7条记录
        /// </summary>
        /// <returns></returns>
        public ActionResult GetMoneyData()
        {
            EchartsVo dm = base.operateContext.bllSession.View_QXTJ.GetDebtData();
            return operateContext.RedirectAjax(0, "", dm, null);
        }
        #endregion

        #region 2.2 获取欠薪金额 根据选中单位进行统计 + ActionResult GetMoneyData()
        /// <summary>
        ///  获取欠薪金额数据 首页统计前7条记录
        /// </summary>
        /// <returns></returns>
        public ActionResult GetMoneyDataBySelUnit()
        {
            string json = RequestHelper.GetStrByName("selUnit");
            EchartsVo dm = operateContext.bllSession.View_QXTJ.GetDebtMoneyData(json);
            return operateContext.RedirectAjax(0, "", dm, null);
        }
        #endregion

        #region 3.0 获取欠薪人数数据 +ActionResult GetPersonData()
        /// <summary>
        ///  获取欠薪人数数据
        /// </summary>
        /// <returns></returns>
        public ActionResult GetPersonData()
        {
            EchartsVo dm = base.operateContext.bllSession.View_QXTJ.GetDebtPerson();
            return operateContext.RedirectAjax(0, "", dm, null);
        }
        #endregion

        #region 4.0 根据单位名称获取单位代码 +ActionResult GetUnitCodeByName()
        /// <summary>
        ///  根据单位名称获取单位代码
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult GetUnitCodeByName()
        {
            string unitName = Request["unitName"];
            unitName = (!string.IsNullOrEmpty(unitName)) ? HttpUtility.UrlDecode(unitName) : "";
            string unitCode = operateContext.bllSession.View_QXTJ.GetUnitCodeByUnitName(unitName);
            return operateContext.RedirectAjax(0, "", unitCode, null);
        } 
        #endregion
    }
}
