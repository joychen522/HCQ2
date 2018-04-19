using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using HCQ2_Model;
using HCQ2_Model.ViewModel;
using HCQ2_Model.ExtendsionModel;

namespace HCQ2UI_Logic
{
    public class CompProInfoController : BaseLogic
    {
        /// <summary>
        /// 数据获取私有变量
        /// </summary>
        private HCQ2_IBLL.IBLLSession bll;

        /// <summary>
        /// 企业信息含上报数据
        /// </summary>
        /// <returns></returns>
        [HCQ2_Common.Attributes.Load]
        public ActionResult Index()
        {
            bll = operateContext.bllSession;
            List<T_CompProInfo> comList = operateContext.bllSession.T_CompProInfo.GetComPro();
            ViewBag.TreeJson = HCQ2_Common.JsonHelper.objectToJsonStr(
                operateContext.bllSession.T_CompProInfo.GetComTreeModle(comList));

            List<HCQ2_Model.TreeModel.B01PerTreeModel> list = operateContext.bllSession.B01.GetB01PerData(operateContext.Usr.user_id);
            ViewBag.TreeProject = HCQ2_Common.JsonHelper.ObjectToJson(list).ToString();

            //数据字典
            ViewBag.GSDJZZZL = bll.T_ItemCodeMenum.GetByItemId(
                bll.T_ItemCode.GetByItemCode("GSDJZZZL").item_id);
            ViewBag.JJLX = bll.T_ItemCodeMenum.GetByItemId(
                bll.T_ItemCode.GetByItemCode("JJLX").item_id);
            ViewBag.LSGX = bll.T_ItemCodeMenum.GetByItemId(
                bll.T_ItemCode.GetByItemCode("QXLSGX").item_id);
            ViewBag.JYFS = bll.T_ItemCodeMenum.GetByItemId(
                bll.T_ItemCode.GetByItemCode("JYFS").item_id);
            ViewBag.DJZCLX = bll.T_ItemCodeMenum.GetByItemId(
                bll.T_ItemCode.GetByItemCode("DJZCLX").item_id);
            ViewBag.HYDM = bll.T_ItemCodeMenum.GetByItemId(
                bll.T_ItemCode.GetByItemCode("HYDM").item_id);
            ViewBag.JGLB = bll.T_ItemCodeMenum.GetByItemId(
                bll.T_ItemCode.GetByItemCode("JGLB").item_id);
            ViewBag.Dwlx = bll.T_ItemCodeMenum.GetByItemId(
                bll.T_ItemCode.GetByItemCode("Dwlx").item_id);
            ViewBag.QXLB = bll.T_ItemCodeMenum.GetByItemId(
                bll.T_ItemCode.GetByItemCode("QYLSZBFB").item_id);
            ViewBag.QXLBJSON = HCQ2_Common.JsonHelper.objectToJsonStr(ViewBag.QXLB);

            List<SM_CodeItems> listCodeItem = bll.SM_CodeItems.GetCodeItemByCodeID("AB").ToList();
            ViewBag.SSWG = HCQ2_Common.JsonHelper.objectToJsonStr(operateContext.bllSession.SM_CodeItems.GetCodeItemTree(listCodeItem));

            return View();
        }

        /// <summary>
        /// 获取数据源
        /// </summary>
        /// <param name="form"></param>
        /// <returns></returns>
        public ActionResult GetComSoure(FormCollection form)
        {
            var data = operateContext.bllSession.T_CompProInfo.GetPageModle(form);
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 获取已经绑定项目的数据源
        /// </summary>
        /// <param name="form"></param>
        /// <returns></returns>
        public ActionResult GetComBindSoure(FormCollection form)
        {
            var data = operateContext.bllSession.T_CompProInfo.GetBindPageModel(form);
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 获取数据源
        /// </summary>
        /// <param name="form"></param>
        /// <returns></returns>
        public ActionResult GetComInfosSoure(FormCollection form)
        {
            List<ComProInfoDalModel> list = operateContext.bllSession.T_CompProInfo.GetPageComInfoModle(form);
            TableModel data = new TableModel
            {
                rows = list,
                total = operateContext.bllSession.T_CompProInfo.GetPageComInfoCount(form)
            };
            return Json(data, JsonRequestBehavior.AllowGet);
        }
        /// <summary>
        /// 刷新目录树需要的数据源
        /// </summary>
        /// <returns></returns>
        public ActionResult GetComTree()
        {
            List<T_CompProInfo> comList = operateContext.bllSession.T_CompProInfo.GetComPro();
            var data = HCQ2_Common.JsonHelper.objectToJsonStr(
                operateContext.bllSession.T_CompProInfo.GetComTreeModle(comList));
            return Content(data);
        }

        /// <summary>
        /// 删除企业信息
        /// </summary>
        /// <param name="com_id"></param>
        /// <returns></returns>
        public ActionResult DeleteCom(int com_id)
        {
            string str = operateContext.bllSession.T_CompProInfo.DeleteCom(com_id) ? "ok" : "fin";
            return Content(str);
        }

        /// <summary>
        /// 保存企业信息
        /// </summary>
        /// <param name="form"></param>
        /// <returns></returns>
        public ActionResult AddComInfo(FormCollection form)
        {
            string str = operateContext.bllSession.T_CompProInfo.OperionCom(form) ? "ok" : "fin";
            return Content(str);
        }

        public ActionResult AddFbdwComInfo(FormCollection form) {
            string str = operateContext.bllSession.T_CompProInfo.OperionFbdwCom(form) ? "ok" : "fin";
            return Content(str);
        }

        /// <summary>
        /// 获取企业分包公司信息
        /// </summary>
        /// <param name="form"></param>
        /// <returns></returns>
        public ActionResult GetFbComSoure(FormCollection form)
        {
            int rows = int.Parse(form["rows"]);
            int page = int.Parse(form["page"]);
            var data = operateContext.bllSession.T_CompProInfo.GetComPro().
                Where(o => o.SJDW == form["JianDieUnitID"]);
            if (!string.IsNullOrEmpty(form["fbtxtSearchName"]))
            {
                string txtName = form["fbtxtSearchName"];
                data = data.Where(o => o.dwmc.Contains(txtName));
            }
            TableModel model = new TableModel
            {
                total = data.Count(),
                rows = data.Skip((rows * page) - rows).Take(rows)
            };
            return Json(model, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 企业项目
        /// </summary>
        /// <returns></returns>
        [HCQ2_Common.Attributes.Load]
        public ActionResult CompanyProject()
        {
            //int user_id = operateContext.Usr.user_id;
            //List<T_CompProInfo> comList = operateContext.bllSession.T_CompProInfo.GetPerCompanyByUserID(user_id);
            //ViewBag.tree = HCQ2_Common.JsonHelper.objectToJsonStr(
            //    operateContext.bllSession.T_CompProInfo.GetZtreeModel(comList));

            return View();
        }

        /// <summary>
        /// 获取企业项目显示的数据源
        /// </summary>
        /// <param name="form"></param>
        /// <returns></returns>
        public ActionResult GetCompanyPojectSoure(FormCollection form)
        {
            TableModel model = new TableModel();
            int user_id = operateContext.Usr.user_id;
            List<T_CompProInfo> comList = operateContext.bllSession.T_CompProInfo.GetPerCompanyByUserID(user_id);

            if (!string.IsNullOrEmpty(form["txtSearchName"]))
            {
                string txtSearch = form["txtSearchName"];
                comList = comList.Where(o => o.dwmc.Contains(txtSearch)).ToList();
            }

            Company com = new Company();
            List<Company> list = new List<Company>();
            foreach (var item in comList)
            {
                int com_id = item.com_id;
                com = new Company();
                com.com_id = com_id;
                com.dwmc = item.dwmc;
                com.tyshxydm = item.tyshxydm;
                com.fddbrxm = item.Fddbrxm;
                com.projectCount = operateContext.bllSession.B01.GetByComID(com_id).Count();
                list.Add(com);
            }

            int rows = int.Parse(form["rows"]);
            int page = int.Parse(form["page"]);
            model.total = list.Count;
            model.rows = list.Skip((rows * page) - rows).Take(rows);

            //model = operateContext.bllSession.T_CompProInfo.GetComProjectSoure(form);
            return Json(model, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetComPany(FormCollection form)
        {
            int com_id = int.Parse(form["com_id"]);
            List<B01> projectList = operateContext.bllSession.B01.GetByComID(com_id);
            TableModel model = new TableModel();
            model.total = projectList.Count;
            model.rows = projectList;
            return Json(model, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 完善企业信息
        /// </summary>
        /// <returns></returns>
        [HCQ2_Common.Attributes.Load]
        public ActionResult CompanyPerfect()
        {
            bll = operateContext.bllSession;
            int user_id = operateContext.Usr.user_id;
            List<T_CompProInfo> comList = operateContext.bllSession.T_CompProInfo.GetPerCompanyByUserID(user_id);
            ViewBag.tree = HCQ2_Common.JsonHelper.objectToJsonStr(
                operateContext.bllSession.T_CompProInfo.GetZtreeModel(comList));
            //数据字典
            ViewBag.GSDJZZZL = bll.T_ItemCodeMenum.GetByItemId(
                bll.T_ItemCode.GetByItemCode("GSDJZZZL").item_id);
            ViewBag.JJLX = bll.T_ItemCodeMenum.GetByItemId(
                bll.T_ItemCode.GetByItemCode("JJLX").item_id);
            ViewBag.LSGX = bll.T_ItemCodeMenum.GetByItemId(
                bll.T_ItemCode.GetByItemCode("QXLSGX").item_id);
            ViewBag.JYFS = bll.T_ItemCodeMenum.GetByItemId(
                bll.T_ItemCode.GetByItemCode("JYFS").item_id);
            ViewBag.DJZCLX = bll.T_ItemCodeMenum.GetByItemId(
                bll.T_ItemCode.GetByItemCode("DJZCLX").item_id);
            ViewBag.HYDM = bll.T_ItemCodeMenum.GetByItemId(
                bll.T_ItemCode.GetByItemCode("HYDM").item_id);
            ViewBag.JGLB = bll.T_ItemCodeMenum.GetByItemId(
                bll.T_ItemCode.GetByItemCode("JGLB").item_id);
            ViewBag.Dwlx = bll.T_ItemCodeMenum.GetByItemId(
                bll.T_ItemCode.GetByItemCode("Dwlx").item_id);
            ViewBag.QXLB = bll.T_ItemCodeMenum.GetByItemId(
                bll.T_ItemCode.GetByItemCode("QYLSZBFB").item_id);
            ViewBag.QXLBJSON = HCQ2_Common.JsonHelper.objectToJsonStr(ViewBag.QXLB);

            List<SM_CodeItems> listCodeItem = bll.SM_CodeItems.GetCodeItemByCodeID("AB").ToList();
            ViewBag.SSWG = HCQ2_Common.JsonHelper.objectToJsonStr(operateContext.bllSession.SM_CodeItems.GetCodeItemTree(listCodeItem));


            return View();
        }

        /// <summary>
        /// 完善企业项目数据源
        /// </summary>
        /// <param name="form"></param>
        /// <returns></returns>
        public ActionResult GetCompanyPerfectSoure(FormCollection form)
        {
            TableModel model = new TableModel();
            model = operateContext.bllSession.T_CompProInfo.GetComPerfectSoure(form);
            return Json(model, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 非建筑企业管理
        /// </summary>
        /// <returns></returns>
        [HCQ2_Common.Attributes.Load]
        public ActionResult DefactBuilding()
        {
            bll = operateContext.bllSession;
            List<T_CompProInfo> comList = operateContext.bllSession.T_CompProInfo.GetComPro();
            ViewBag.TreeJson = HCQ2_Common.JsonHelper.objectToJsonStr(
                operateContext.bllSession.T_CompProInfo.GetComTreeModle(comList));

            //数据字典
            ViewBag.GSDJZZZL = bll.T_ItemCodeMenum.GetByItemId(
                bll.T_ItemCode.GetByItemCode("GSDJZZZL").item_id);
            ViewBag.JJLX = bll.T_ItemCodeMenum.GetByItemId(
                bll.T_ItemCode.GetByItemCode("JJLX").item_id);
            ViewBag.LSGX = bll.T_ItemCodeMenum.GetByItemId(
                bll.T_ItemCode.GetByItemCode("QXLSGX").item_id);
            ViewBag.JYFS = bll.T_ItemCodeMenum.GetByItemId(
                bll.T_ItemCode.GetByItemCode("JYFS").item_id);
            ViewBag.DJZCLX = bll.T_ItemCodeMenum.GetByItemId(
                bll.T_ItemCode.GetByItemCode("DJZCLX").item_id);
            ViewBag.HYDM = bll.T_ItemCodeMenum.GetByItemId(
                bll.T_ItemCode.GetByItemCode("HYDM").item_id);
            ViewBag.JGLB = bll.T_ItemCodeMenum.GetByItemId(
                bll.T_ItemCode.GetByItemCode("JGLB").item_id);
            ViewBag.Dwlx = bll.T_ItemCodeMenum.GetByItemId(
                bll.T_ItemCode.GetByItemCode("Dwlx").item_id);
            ViewBag.QXLB = bll.T_ItemCodeMenum.GetByItemId(
                bll.T_ItemCode.GetByItemCode("QYLSZBFB").item_id);
            ViewBag.QXLBJSON = HCQ2_Common.JsonHelper.objectToJsonStr(ViewBag.QXLB);
            return View();
        }

        /// <summary>
        /// 项目管理员添加分包单位
        /// </summary>
        /// <returns></returns>
        [HCQ2_Common.Attributes.Load]
        public ActionResult ProjectFbdw()
        {
            bll = operateContext.bllSession;
            List<T_CompProInfo> comList = operateContext.bllSession.T_CompProInfo.GetComPro();
            ViewBag.TreeJson = HCQ2_Common.JsonHelper.objectToJsonStr(
                operateContext.bllSession.T_CompProInfo.GetComTreeModle(comList));

            //数据字典
            ViewBag.GSDJZZZL = bll.T_ItemCodeMenum.GetByItemId(
                bll.T_ItemCode.GetByItemCode("GSDJZZZL").item_id);
            ViewBag.JJLX = bll.T_ItemCodeMenum.GetByItemId(
                bll.T_ItemCode.GetByItemCode("JJLX").item_id);
            ViewBag.LSGX = bll.T_ItemCodeMenum.GetByItemId(
                bll.T_ItemCode.GetByItemCode("QXLSGX").item_id);
            ViewBag.JYFS = bll.T_ItemCodeMenum.GetByItemId(
                bll.T_ItemCode.GetByItemCode("JYFS").item_id);
            ViewBag.DJZCLX = bll.T_ItemCodeMenum.GetByItemId(
                bll.T_ItemCode.GetByItemCode("DJZCLX").item_id);
            ViewBag.HYDM = bll.T_ItemCodeMenum.GetByItemId(
                bll.T_ItemCode.GetByItemCode("HYDM").item_id);
            ViewBag.JGLB = bll.T_ItemCodeMenum.GetByItemId(
                bll.T_ItemCode.GetByItemCode("JGLB").item_id);
            ViewBag.Dwlx = bll.T_ItemCodeMenum.GetByItemId(
                bll.T_ItemCode.GetByItemCode("Dwlx").item_id);
            ViewBag.QXLB = bll.T_ItemCodeMenum.GetByItemId(
                bll.T_ItemCode.GetByItemCode("QYLSZBFB").item_id);
            ViewBag.QXLBJSON = HCQ2_Common.JsonHelper.objectToJsonStr(ViewBag.QXLB);

            List<SM_CodeItems> listCodeItem = bll.SM_CodeItems.GetCodeItemByCodeID("AB").ToList();
            ViewBag.SSWG = HCQ2_Common.JsonHelper.objectToJsonStr(operateContext.bllSession.SM_CodeItems.GetCodeItemTree(listCodeItem));

            return View();
        }

        public ActionResult GetProjectSoure(FormCollection form)
        {
            int page = int.Parse(form["page"]);
            int rows = int.Parse(form["rows"]);

            List<B01> unitList = operateContext.bllSession.B01.GetPerUnitByUserID(
                HCQ2UI_Helper.OperateContext.Current.Usr.user_id);

            if (!string.IsNullOrEmpty(form["txtSearchName"]))
            {
                string txtName = form["txtSearchName"];
                unitList = unitList.Where(o => o.UnitName.Contains(txtName)).ToList();
            }

            TableModel model = new TableModel();
            model.rows = unitList.Skip((rows * page) - rows).Take(rows);
            model.total = unitList.Count();

            return Json(model, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetProjectdwSoure(FormCollection form)
        {
            string UnitID = form["UnitID"];
            var data = operateContext.bllSession.T_CompProInfo.GetByUnitID(UnitID);

            if (!string.IsNullOrEmpty(form["fbName"]))
            {
                string fbName = form["fbName"];
                data = data.Where(o => o.dwmc.Contains(fbName)).ToList();
            }

            int page = int.Parse(form["page"]);
            int rows = int.Parse(form["rows"]);
            TableModel model = new TableModel();
            model.total = data.Count();
            model.rows = data.Skip((rows * page) - rows).Take(rows);

            return Json(model, JsonRequestBehavior.AllowGet);
        }
    }

    public class Company
    {
        public int com_id { get; set; }
        public string dwmc { get; set; }
        public string tyshxydm { get; set; }
        public string fddbrxm { get; set; }
        public int projectCount { get; set; }
    }

}
