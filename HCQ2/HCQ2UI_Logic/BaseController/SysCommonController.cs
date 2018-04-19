﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using HCQ2_Common;
using HCQ2_Model.FormatModel;

namespace HCQ2UI_Logic.BaseController
{
    /// <summary>
    ///  系统公用控制器
    /// </summary>
    public class SysCommonController:BaseLogic
    {
        /// <summary>
        ///  获取字典信息
        /// </summary>
        /// <returns></returns>
        public ActionResult GetDictionaryByCode()
        {
            string fieldCode = Helper.ToString(Request["fieldCode"]);
            List<HCQ2_Model.T_ItemCodeMenum> list = null;
            if (string.IsNullOrEmpty(fieldCode))
                return null;
            list = operateContext.bllSession.T_ItemCode.GetItemByCode(fieldCode);
            return operateContext.RedirectAjax(0, "", list, null);
        }

        /// <summary>
        ///  获取老系统字典信息
        /// </summary>
        /// <returns></returns>
        public ActionResult GetDictionaryByOldSysCode()
        {
            string fieldCode = Helper.ToString(Request["fieldCode"]);
            List<CodeItemsModel> list = null;
            if (string.IsNullOrEmpty(fieldCode))
                return null;
            list = operateContext.bllSession.SM_CodeItems.GetOldSysCode(fieldCode);
            if(null==list || list.Count<=0)
                return operateContext.RedirectAjax(0,"数据字典为空！","","");
            return operateContext.RedirectAjax(0, "", list, null);
        }

        /// <summary>
        ///  获取老系统字典信息
        /// </summary>
        /// <returns></returns>
        public ActionResult GetWorkCityDictionary()
        {
            List<Dictionary<string, string>> list = new List<Dictionary<string, string>>();
            List<HCQ2_Model.SM_CodeItems> tempList = operateContext.bllSession.SM_CodeItems.Select(s => s.CodeID.Equals("AB") && s.CodeItemID.Length == 6).ToList();
            if (tempList == null || tempList.Count <= 0)
                return operateContext.RedirectAjax(1, "数据异常或字典为空！", "", "");
            Dictionary<string, string> str;
            foreach (var item in tempList)
            {
                str = new Dictionary<string, string>();
                str.Add("code_name", item.CodeItemName);
                str.Add("code_value", item.JPSign);
                list.Add(str);
            }
            return operateContext.RedirectAjax(0, "", list, null);
        }

        /// <summary>
        ///  获取模块下拉数据
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult GetModuleDictionaryByCode()
        {
            List<HCQ2_Model.SelectModel.SelectModel> json = new List<HCQ2_Model.SelectModel.SelectModel>();
            List<HCQ2_Model.T_SysModule> list = operateContext.bllSession.T_SysModule.Select(s => s.if_start == true).ToList();
            if(null==list)
                return operateContext.RedirectAjax(1, "", "模块子系统为空！", null);
            foreach (var item in list)
                json.Add(new HCQ2_Model.SelectModel.SelectModel { text = item.sm_name, value = item.sm_code });
            return operateContext.RedirectAjax(0, "", json, null);
        }
    }
}
