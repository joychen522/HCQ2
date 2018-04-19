using HCQ2_Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace HCQ2UI_Logic
{
    public class EnterpriseController : BaseLogic
    {
        /// <summary>
        /// 数据获取私有变量
        /// </summary>
        private HCQ2_IBLL.IBLLSession bll;

        [HCQ2_Common.Attributes.Load]
        public ActionResult Index()
        {
            bll = operateContext.bllSession;

            ViewBag.in_compay = bll.T_CompProInfo.GetComPro().Where(o => o.QXLB == "01").ToList();
            ViewBag.in_compay_json = HCQ2_Common.JsonHelper.objectToJsonStr(bll.T_CompProInfo.GetComPro().Where(o => o.QXLB == "01").ToList());

            ViewBag.UnitType = bll.SM_CodeItems.GetCodeItemByCodeID("SMOT");
            ViewBag.B0175 = bll.SM_CodeItems.GetCodeItemByCodeID("CP");
            ViewBag.B0117 = bll.SM_CodeItems.GetCodeItemByCodeID("45");
            ViewBag.project_status = bll.T_ItemCodeMenum.GetByItemId(
                bll.T_ItemCode.GetByItemCode("project_status").item_id);

            ViewBag.SSXZZGBM = bll.T_ItemCodeMenum.GetByItemId(
                bll.T_ItemCode.GetByItemCode("SSXZZGBM").item_id);
            ViewBag.GSDJZZZL = bll.T_ItemCodeMenum.GetByItemId(
                bll.T_ItemCode.GetByItemCode("GSDJZZZL").item_id);
            ViewBag.GCLB = HCQ2_Common.JsonHelper.objectToJsonStr(bll.T_ItemCodeMenum.GetByItemId(
                bll.T_ItemCode.GetByItemCode("ZCLB").item_id));
            //行政区域代码目录树
            List<SM_CodeItems> listCodeItem = bll.SM_CodeItems.GetCodeItemByCodeID("AB").ToList();
            ViewBag.AB = HCQ2_Common.JsonHelper.objectToJsonStr(operateContext.bllSession.SM_CodeItems.GetCodeItemTree(listCodeItem));

            ViewBag.ComName = HCQ2_Common.JsonHelper.objectToJsonStr(ViewBag.in_compay);
            ViewBag.GZFFZHSSYH = bll.T_ItemCodeMenum.GetByItemId(
                bll.T_ItemCode.GetByItemCode("SSYH").item_id);

            ViewBag.upLoadId = bll.B01.GetPerUnitByUserID(operateContext.Usr.user_id);

            return View();
        }

        /// <summary>
        /// 根据UnitID获取详细信息
        /// </summary>
        /// <param name="unit_id"></param>
        /// <returns></returns>
        public ActionResult IndexDetail(string unit_id)
        {
            bll = operateContext.bllSession;
            var data = bll.B01.GetByUnitID(unit_id);
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 企业信息管理
        /// </summary>
        /// <returns></returns>
        [HCQ2_Common.Attributes.Load]
        public ActionResult Manage()
        {
            bll = operateContext.bllSession;
            //List<HCQ2_Model.TreeModel.B01PerTreeModel> list = operateContext.bllSession.B01.GetB01PerData(operateContext.Usr.user_id);
            //ViewBag.json = bll.B01.GetTreeString(bll.B01.GetB01Info().Where(o => o.KeyParent == ".").ToList());

            var data = bll.B01.GetPerUserAreaUnit(0);
            ViewBag.json = HCQ2_Common.JsonHelper.objectToJsonStr(data);

            ViewBag.UnitType = bll.SM_CodeItems.GetCodeItemByCodeID("SMOT");
            ViewBag.B0175 = bll.SM_CodeItems.GetCodeItemByCodeID("CP");
            ViewBag.B0117 = bll.SM_CodeItems.GetCodeItemByCodeID("45");
            ViewBag.project_status = bll.T_ItemCodeMenum.GetByItemId(
                bll.T_ItemCode.GetByItemCode("project_status").item_id);

            ViewBag.SSXZZGBM = bll.T_ItemCodeMenum.GetByItemId(
                bll.T_ItemCode.GetByItemCode("SSXZZGBM").item_id);
            ViewBag.GSDJZZZL = bll.T_ItemCodeMenum.GetByItemId(
                bll.T_ItemCode.GetByItemCode("GSDJZZZL").item_id);
            ViewBag.GCLB = HCQ2_Common.JsonHelper.objectToJsonStr(bll.T_ItemCodeMenum.GetByItemId(
                bll.T_ItemCode.GetByItemCode("ZCLB").item_id));
            //行政区域代码目录树
            List<SM_CodeItems> listCodeItem = bll.SM_CodeItems.GetCodeItemByCodeID("AB").ToList();
            ViewBag.AB = HCQ2_Common.JsonHelper.objectToJsonStr(operateContext.bllSession.SM_CodeItems.GetCodeItemTree(listCodeItem));

            ViewBag.in_compay = bll.T_CompProInfo.GetComPro().Where(o => o.QXLB == "01").ToList();
            ViewBag.ComName = HCQ2_Common.JsonHelper.objectToJsonStr(ViewBag.in_compay);
            ViewBag.GZFFZHSSYH = bll.T_ItemCodeMenum.GetByItemId(
                bll.T_ItemCode.GetByItemCode("SSYH").item_id);

            ViewBag.upLoadId = bll.B01.GetPerUnitByUserID(operateContext.Usr.user_id);

            return View();
        }

        /// <summary>
        /// 获取企业目录树（全部）
        /// </summary>
        /// <returns></returns>
        public ActionResult GetEnterTree()
        {
            bll = operateContext.bllSession;
            var data = bll.B01.GetPerUserAreaUnit(0);
            return Content(HCQ2_Common.JsonHelper.objectToJsonStr(data));
        }

        /// <summary>
        /// 获取企业目录树（根据权限）
        /// </summary>
        /// <returns></returns>
        public ActionResult GetEnterByUserID()
        {
            bll = operateContext.bllSession;
            var data = bll.B01.GetPerUserAreaUnit(operateContext.Usr.user_id);
            return Content(HCQ2_Common.JsonHelper.objectToJsonStr(data));
        }

        public ActionResult GetTreeList(int type)
        {
            bll = operateContext.bllSession;
            var data = bll.B01.GetPerUserAreaUnitInfo(type != 0 ? operateContext.Usr.user_id : 0);
            return Content(HCQ2_Common.JsonHelper.objectToJsonStr(data));
        }

        /// <summary>
        /// 企业信息获取数据源
        /// </summary>
        /// <returns></returns>
        public ActionResult GetManage(FormCollection form)
        {
            bll = operateContext.bllSession;
            List<B01> list = bll.B01.GetB01Info().Where(o=>o.UnitID.Length == 3).ToList();
            var data = list.AsEnumerable();
            if (!string.IsNullOrEmpty(form["UnitID"]))
            {
                data = data.Where(o => o.UnitID == form["UnitID"].Trim());
            }
            //else
            //{
            //    data = data.Where(o => o.UnitID == operateContext.bllSession.B01.GetB01PerData(operateContext.Usr.user_id)[0].UnitID);
            //}
            if (!string.IsNullOrEmpty(form["txtSearchName"])) {
                string unitName = form["txtSearchName"].Trim();
                data = data.Where(o => o.UnitName.Contains(unitName));
            }
            
            string returnJson = string.Empty;
            int page = int.Parse(form["page"]);
            int rows = int.Parse(form["rows"]);
            var dataPage = data.Skip((page * rows) - rows).Take(rows);
            returnJson = "{\"total\":" + data.Count() + ",\"rows\":" + HCQ2_Common.JsonHelper.ObjectToJson(dataPage) + "}";
            return Content(returnJson);
        }

        /// <summary>
        /// 添加单位、部门
        /// </summary>
        /// <returns></returns>
        public ActionResult AddUnit(FormCollection form)
        {
            bll = operateContext.bllSession;
            string returnJson = bll.B01.AddUnit(form) ? "ok" : "find";
            //if (returnJson == "ok") {
            //    string UnitName = form["UnitName"];
            //    try
            //    {
            //        string UnitID = operateContext.bllSession.B01.GetByUnitName(UnitName).UnitID;
            //        operateContext.bllSession.B01.UpDataProject(UnitID);
            //    }
            //    catch (Exception ex)
            //    {
            //        string error = ex.ToString();
            //    }
            //}
                
            return Content(returnJson);
        }

        /// <summary>
        /// 获取代码型字段
        /// </summary>
        /// <param name="RowID"></param>
        /// <returns></returns>
        public ActionResult GetEditDropValue(string RowID)
        {
            bll = operateContext.bllSession;
            var b = bll.B01.GetB01Info().Where(o => o.RowID == RowID).FirstOrDefault();
            string B0175 = " ";
            if (!string.IsNullOrEmpty(b.B0175))
                B0175 = bll.SM_CodeItems.GetCodeItemByCodeID("CP").Where(o => o.CodeItemID == b.B0175).FirstOrDefault().CodeItemName;
            string B0117 = " ";
            if (!string.IsNullOrEmpty(b.B0117))
                B0117 = bll.SM_CodeItems.GetCodeItemByCodeID("45").Where(o => o.CodeItemID == b.B0117).FirstOrDefault().CodeItemName;
            return Content(B0175 + "," + B0117);
        }

        /// <summary>
        /// 编辑单位、部门
        /// </summary>
        /// <param name="form"></param>
        /// <returns></returns>
        public ActionResult Edit(FormCollection form)
        {
            bll = operateContext.bllSession;
            string returnJson = bll.B01.EditUnit(form) ? "ok" : "find";
            //if (returnJson == "ok")
            //{
            //    string UnitName = form["UnitName"];
            //    try
            //    {
            //        string UnitID = operateContext.bllSession.B01.GetByUnitName(UnitName).UnitID;
            //        operateContext.bllSession.B01.UpDataProject(UnitID);
            //    }
            //    catch (Exception ex)
            //    {
            //        string error = ex.ToString();
            //    }
            //}
            return Content(returnJson);
        }

        /// <summary>
        /// 删除部门
        /// </summary>
        /// <param name="RowID"></param>
        /// <returns></returns>
        public ActionResult Delete(string RowID)
        {
            bll = operateContext.bllSession;
            string returnJson = bll.B01.Delete(o => o.RowID == RowID) > 0 ? "ok" : "find";
            if (returnJson == "ok") {
                B01 unit = bll.B01.GetByRowID(RowID);
                string UnitID = unit.UnitID;
                bll.A01.Delete(o => o.UnitID == UnitID);
            }
            return Content(returnJson);
        }

        /// <summary>
        /// 首页点项目名称的详细页面
        /// </summary>
        /// <returns></returns>
        public ActionResult GetMainProject()
        {
            return View();
        }

        /// <summary>
        /// 首页点项目名称的详细页面 获取数据源
        /// </summary>
        /// <param name="form"></param>
        /// <returns></returns>
        public ActionResult GetProjectSoure(FormCollection form)
        {
            var data = operateContext.bllSession.B01.GetPerUnitByUserID(
                HCQ2UI_Helper.OperateContext.Current.Usr.user_id);
            int rows = int.Parse(form["rows"]);
            int page = int.Parse(form["page"]);
            if (!string.IsNullOrEmpty(form["project_name"]))
            {
                string project_name = form["project_name"];
                data = data.Where(o => o.UnitName.Contains(project_name)).ToList();
            }
            var viewData = data.Skip((rows * page) - rows).Take(rows);
            HCQ2_Model.ViewModel.TableModel modle = new HCQ2_Model.ViewModel.TableModel
            {
                total = data.Count(),
                rows = viewData
            };
            return Json(modle, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 根据code获取name
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public ActionResult GetaAreaName(string code)
        {
            if (string.IsNullOrEmpty(code))
                return Content("");
            bll = operateContext.bllSession;
            List<SM_CodeItems> listCodeItem = bll.SM_CodeItems.GetCodeItemByCodeID("AB").ToList();
            string codeName = "";
            try
            {
                codeName = listCodeItem.Where(o => o.CodeItemID == code).FirstOrDefault().CodeItemName;
            }
            catch (Exception e)
            {}
            return Content(codeName);
        }

        /// <summary>
        /// 根据企业ID获取其下属分包单位
        /// </summary>
        /// <param name="com_id"></param>
        /// <returns></returns>
        public ActionResult GetFbdwSoure(int com_id)
        {
            List<T_CompProInfo> comList = new List<T_CompProInfo>();
            var data = operateContext.bllSession.T_CompProInfo.GetComPro().Where(o => o.SJDW == com_id.ToString());
            if (data.Count() > 0)
                comList = data.ToList();
            return Json(comList, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 欠薪统计人数、金额详细
        /// </summary>
        /// <returns></returns>
        [HCQ2_Common.Attributes.Load]
        public ActionResult ProjectQXTJ()
        {
            return View();
        }

        /// <summary>
        /// 获取欠薪人数、金额统计的详细信息
        /// </summary>
        /// <param name="form"></param>
        /// <returns></returns>
        public ActionResult GetQXTJSoure(FormCollection form)
        {
            var data = operateContext.bllSession.View_QXTJ.GetMainWagePerson(
                HCQ2UI_Helper.OperateContext.Current.Usr.user_id);
            int rows = int.Parse(form["rows"]);
            int page = int.Parse(form["page"]);
            if (!string.IsNullOrEmpty(form["project_name"]))
            {
                string project_name = form["project_name"];
                data = data.Where(o => o.B0001Name.Contains(project_name)).ToList();
            }
            var viewData = data.Skip((rows * page) - rows).Take(rows);
            HCQ2_Model.ViewModel.TableModel modle = new HCQ2_Model.ViewModel.TableModel
            {
                total = data.Count(),
                rows = viewData
            };
            return Json(modle, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 企业信息完善
        /// </summary>
        /// <returns></returns>
        [HCQ2_Common.Attributes.Load]
        public ActionResult UnitPerfect()
        {
            bll = operateContext.bllSession;
            List<HCQ2_Model.TreeModel.B01PerTreeModel> list = operateContext.bllSession.B01.GetB01PerData(operateContext.Usr.user_id);
            ViewBag.json = bll.B01.GetTreeString(bll.B01.GetB01Info().Where(o => o.KeyParent == ".").ToList());
            ViewBag.UnitType = bll.SM_CodeItems.GetCodeItemByCodeID("SMOT");
            ViewBag.B0175 = bll.SM_CodeItems.GetCodeItemByCodeID("CP");
            ViewBag.B0117 = bll.SM_CodeItems.GetCodeItemByCodeID("45");
            ViewBag.project_status = bll.T_ItemCodeMenum.GetByItemId(
                bll.T_ItemCode.GetByItemCode("project_status").item_id);

            ViewBag.SSXZZGBM = bll.T_ItemCodeMenum.GetByItemId(
                bll.T_ItemCode.GetByItemCode("SSXZZGBM").item_id);
            ViewBag.GSDJZZZL = bll.T_ItemCodeMenum.GetByItemId(
                bll.T_ItemCode.GetByItemCode("GSDJZZZL").item_id);
            ViewBag.GCLB = HCQ2_Common.JsonHelper.objectToJsonStr(bll.T_ItemCodeMenum.GetByItemId(
                bll.T_ItemCode.GetByItemCode("ZCLB").item_id));
            //行政区域代码目录树
            List<SM_CodeItems> listCodeItem = bll.SM_CodeItems.GetCodeItemByCodeID("AB").ToList();
            ViewBag.AB = HCQ2_Common.JsonHelper.objectToJsonStr(operateContext.bllSession.SM_CodeItems.GetCodeItemTree(listCodeItem));

            ViewBag.in_compay = bll.T_CompProInfo.GetComPro().Where(o => o.QXLB == "01").ToList();
            ViewBag.ComName = HCQ2_Common.JsonHelper.objectToJsonStr(ViewBag.in_compay);
            ViewBag.GZFFZHSSYH = bll.T_ItemCodeMenum.GetByItemId(
                bll.T_ItemCode.GetByItemCode("SSYH").item_id);
            ViewBag.upLoadId = bll.B01.GetPerUnitByUserID(operateContext.Usr.user_id);
            return View();
        }

        /// <summary>
        /// 获取企业信息完善的数据源
        /// </summary>
        /// <param name="form"></param>
        /// <returns></returns>
        public ActionResult GetUnitPerfectSoure(FormCollection form)
        {
            int rows = int.Parse(form["rows"]);
            int page = int.Parse(form["page"]);
            int user_id = operateContext.Usr.user_id;
            List<B01> unitList = operateContext.bllSession.B01.GetPerUnitByUserID(user_id);
            if (!string.IsNullOrEmpty(form["txtSearchName"]))
            {
                string unitName = form["txtSearchName"];
                unitList = unitList.Where(o => o.UnitName.Contains(unitName)).ToList();
            }
            HCQ2_Model.ViewModel.TableModel modle = new HCQ2_Model.ViewModel.TableModel
            {
                rows = unitList.Skip((rows * page) - rows).Take(rows),
                total = unitList.Count
            };
            return Json(modle, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 完善项目信息
        /// </summary>
        /// <param name="form"></param>
        /// <returns></returns>
        public ActionResult EditProject(FormCollection form)
        {
            string str = operateContext.bllSession.B01.EditPorject(form) ? "ok" : "fin";
            return Content(str);
        }
    }
}
