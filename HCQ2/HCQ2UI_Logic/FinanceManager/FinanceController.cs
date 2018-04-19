using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using HCQ2_Common;
using HCQ2_Model.ViewModel;
using System.IO;
using System.Web;
using HCQ2_Model.ExtendsionModel;

namespace HCQ2UI_Logic.FinanceManager
{
    /// <summary>
    ///  工资发放管理控制器
    /// </summary>
    public class FinanceController:BaseLogic
    {
        #region 1.0 工资管理 + ActionResult WageManagerList()
        /// <summary>
        ///  1.0 工资管理
        /// </summary>
        /// <returns></returns>
        [HCQ2_Common.Attributes.Load]
        [HCQ2_Common.Attributes.Element]
        public ActionResult WageManagerList()
        {
            return View();
        }
        #endregion

        #region 1.1 工资维护一栏 + ActionResult InitGroupTableData()
        /// <summary>
        ///  1.1 工资维护一栏
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult InitGroupTableData()
        {
            string unitID = Helper.ToString(Request["unitID"]);
            if (string.IsNullOrEmpty(unitID))
                return null;
            int page = Helper.ToInt(Request["page"]);
            int rows = Helper.ToInt(Request["rows"]);
            List<WGJG01Model> list = operateContext.bllSession.WGJG01_Template.GetWageListDataByUnit(unitID, page, rows);
            TableModel tModel = new TableModel()
            {
                total = operateContext.bllSession.WGJG01_Template.SelectCount(s => s.UnitID == unitID),
                rows = list
            };
            return Json(tModel, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region 1.2 添加工资模板 + ActionResult AddTemplate(HCQ2_Model.WGJG01_Template model)
        /// <summary>
        ///  1.2 添加工资模板
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult AddTemplate(HCQ2_Model.WGJG01_Template model)
        {
            if(null==model)
                return operateContext.RedirectAjax(1, "数据获取失败~", "", "");
            model.WGJG0106 = operateContext.Usr.user_name;
            int back = operateContext.bllSession.WGJG01_Template.AddWGJG01(model);
            if(back>0)
                return operateContext.RedirectAjax(0, "添加数据成功~", "", "");
            return operateContext.RedirectAjax(1, "数据保存失败~", "", "");
        }
        #endregion

        #region 1.3 编辑工资模板 + ActionResult EditTemplate(HCQ2_Model.WGJG01_Template model)
        /// <summary>
        ///  1.3 编辑工资模板 
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult EditTemplate(HCQ2_Model.WGJG01_Template model)
        {
            if (null == model)
                return operateContext.RedirectAjax(1, "数据获取失败~", "", "");
            int DispOrder = HCQ2_Common.Helper.ToInt(Request["id"]);
            model.DispOrder = DispOrder;
            int back = operateContext.bllSession.WGJG01_Template.EditWGJG01(model);
            if (back > 0)
                return operateContext.RedirectAjax(0, "添加数据成功~", "", "");
            return operateContext.RedirectAjax(1, "数据保存失败~", "", "");
        }
        #endregion

        #region 1.4 删除工资模板 + ActionResult DelTemplateById(int id)
        /// <summary>
        ///  1.4 删除工资模板
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns>
        public ActionResult DelTemplateById(int id)
        {
            if (id <= 0)
                return operateContext.RedirectAjax(1, "关键字为空~", "", "");
            int back = operateContext.bllSession.WGJG01_Template.Delete(s => s.DispOrder == id);
            if (back > 0)
                return operateContext.RedirectAjax(0, "删除成功~", "", "");
            return operateContext.RedirectAjax(1, "删除失败~", "", "");
        }
        #endregion

        //************************************************************
        #region 1.1.5 工资模板一栏 + ActionResult WageTempList()
        /// <summary>
        ///  1.5 工资模板一栏 
        /// </summary>
        /// <returns></returns>
        public ActionResult WageTempList()
        {
            return View();
        }
        #endregion

        #region 1.1.6  获取工资模板数据 + ActionResult InitWageTempTableData()
        /// <summary>
        ///  1.6 获取工资模板数据
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult InitWageTempTableData()
        {
            string rowid = Helper.ToString(Request["rowid"]);
            if (string.IsNullOrEmpty(rowid))
                return null;
            string userName = RequestHelper.GetDeStrByName("userName");//关键字查询
            int page = Helper.ToInt(Request["page"]);
            int rows = Helper.ToInt(Request["rows"]);
            List<WGJG02Model> list = operateContext.bllSession.WGJG02_Template.GetWageDetailByRowId(rowid, userName, page, rows);
            TableModel tModel = new TableModel()
            {
                total =
                    operateContext.bllSession.WGJG02_Template.SelectCount(
                        s => s.WGJG01RowID == rowid && s.A0101.Contains(userName)),
                rows = list
            };
            return Json(tModel, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region 1.1.7 根据单位选择生成数据 + ActionResult CreateDataByRowId()
        /// <summary>
        ///  1.7 根据单位选择生成数据
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult CreateDataByRowId()
        {
            string rowid = Helper.ToString(Request["rowid"]);
            bool flay = operateContext.bllSession.WGJG02_Template.CreateDataByUnit(rowid);
            if(flay)
                return operateContext.RedirectAjax(0, "生成成功~", "", "");
            return operateContext.RedirectAjax(1, "生成失败~", "", "");
        }
        #endregion

        #region 1.1.8 从模板中删除人员 + ActionResult DelWageTemp()
        /// <summary>
        ///  1.1.8 从模板中删除人员
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult DelWageTemp()
        {
            string a0177 = Helper.ToString(Request["a0177"]);
            if(string.IsNullOrEmpty(a0177))
                return operateContext.RedirectAjax(1, "删除失败~", "", "");
            int mark = operateContext.bllSession.WGJG02_Template.Delete(s => s.A0177 == a0177);
            if(mark>0)
                return operateContext.RedirectAjax(0, "删除成功~", "", "");
            return operateContext.RedirectAjax(1, "删除失败~", "", "");
        }
        #endregion

        #region 1.1.9 编辑模板数据 + ActionResult EditWageTemp(HCQ2_Model.ViewModel.WGJG02Model model)
        /// <summary>
        ///  1.1.9 编辑模板数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public ActionResult EditWageTemp(WGJG02Model model)
        {
            if (null == model)
                return null;
            int mark = operateContext.bllSession.WGJG02_Template.EditWageTempModel(model);
            if (mark > 0)
                return operateContext.RedirectAjax(0, "编辑保存成功~", "", "");
            return operateContext.RedirectAjax(1, "编辑保存失败~", "", "");
        }
        #endregion

        #region 1.2.0 编辑模板数据 一次只能编辑一个项目 + ActionResult EditWageTempBySingle(HCQ2_Model.ViewModel.WGJG02Model model)
        /// <summary>
        ///  1.2.0 编辑模板数据 一次只能编辑一个项目 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult EditWageTempBySingle(HCQ2_Model.ViewModel.WGJG02Model model)
        {
            if(!ModelState.IsValid)
                return operateContext.RedirectAjax(1, "数据类型录入有误~", "", "");
            string columnName = RequestHelper.GetStrByName("columnName");
            if (model == null || string.IsNullOrEmpty(columnName))
                return operateContext.RedirectAjax(1, "必要参数为空~", "", "");
            int mark = operateContext.bllSession.WGJG02_Template.EditWageTempModelBySingle(model, columnName);
            if (mark > 0)
                return operateContext.RedirectAjax(0, "编辑保存成功~", "", "");
            return operateContext.RedirectAjax(1, "编辑保存失败~", "", "");
        } 
        #endregion

        #region 1.2.1 开始发放  + ActionResult StartGrantWage()
        /// <summary>
        ///  1.2.1 开发发放 
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult StartGrantWage()
        {
            string wgDate = Helper.ToString(Request["wgDate"]);
            string rowid = Helper.ToString(Request["rowid"]);
            if (string.IsNullOrEmpty(rowid))
                return null;
            bool mark = operateContext.bllSession.WGJG01_Template.StartGrantByWGJG01(wgDate, rowid);
            if(mark)
                return operateContext.RedirectAjax(0, "发放成功~", "", "");
            return operateContext.RedirectAjax(1, "发放失败~", "", "");
        }
        #endregion

        #region 1.2.2 验证是否发放 + ActionResult CheckGrantWage()
        /// <summary>
        ///  1.2.2 验证是否发放
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult CheckGrantWage()
        {
            string wgDate = Helper.ToString(Request["wgDate"]);
            string rowid = Helper.ToString(Request["rowid"]);
            if (string.IsNullOrEmpty(rowid))
                return operateContext.RedirectAjax(1, "数据异常~", "", "");
            bool mark = operateContext.bllSession.WGJG01_Template.CheckGrantWage(wgDate, rowid);
            if(mark)
                return operateContext.RedirectAjax(1, "数据已被发放~", "", "");
            return operateContext.RedirectAjax(0, "发放成功~", "", "");
        }
        #endregion

        #region 1.2.3 根据选中人员生成工资数据 + 根据选中人员生成工资数据
        /// <summary>
        ///  根据选中人员生成工资数据
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult CreateDataBySelect()
        {
            string personData = RequestHelper.GetStrByName("personData"),
                rowid = RequestHelper.GetStrByName("rowid");
            if (string.IsNullOrEmpty(personData))
                return operateContext.RedirectAjax(1, "需要生成的数据为空~", "", "");
            bool mark = operateContext.bllSession.WGJG02_Template.CreateDataByPsersons(personData, rowid);
            if (mark)
                return operateContext.RedirectAjax(0, "数据生成成功~", "", "");
            return operateContext.RedirectAjax(1, "数据生成失败~", "", "");
        }
        #endregion

        #region 1.2.4 获取单位人员数据 + ActionResult GetPersonByUnitID()
        /// <summary>
        ///  获取单位人员数据
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult GetPersonByUnitID()
        {
            string unitID = RequestHelper.GetStrByName("UnitID");
            if(string.IsNullOrEmpty(unitID))
                return operateContext.RedirectAjax(1, "单位信息为空~", "", "");
            List<HCQ2_Model.SelectModel.ListBoxModel> list = operateContext.bllSession.A01.GetPersonsByB0002(unitID);
            return operateContext.RedirectAjax(0, "发放成功~", list, "");
        }
        #endregion

        #region 1.2.5 导入人员工资信息 + ActionResult ImportPersonData()
        /// <summary>
        ///  1.2.5 导入人员工资信息
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult ImportPersonData()
        {
            string UnitID = RequestHelper.GetStrByName("UnitID"),
                RowID = RequestHelper.GetStrByName("RowID");
            if(string.IsNullOrEmpty(UnitID) || string.IsNullOrEmpty(RowID))
                return operateContext.RedirectAjax(1, "参数异常~", "", "");
            var files = Request.Files;
            if (files == null || files.Count <= 0)
                return null;
            string file_name = "工资模板"+operateContext.Usr.login_name;
            string pathServer = "~/UpFile/WageManager";
            string path = Server.MapPath(pathServer);
            if (!Directory.Exists(path.ToString()))
                Directory.CreateDirectory(path.ToString());//文件夹不存在则创建
            HttpPostedFileBase file = Request.Files["filePerson"];
            //1.上传文档
            string sreUrl = Server.MapPath(pathServer + "/" + file_name + "." + file.FileName.Split('.')[1]);
            file.SaveAs(sreUrl);//上传文件
           System.Data.DataTable dt = NpoiHelper.ImportExcelToDataTable(sreUrl);
            if(null==dt || dt.Rows.Count<=0)
                return operateContext.RedirectAjax(1, "导入数据为空~", "", "");
            bool mark = operateContext.bllSession.WGJG02_Template.ImportPersonData(dt, UnitID, RowID);
            if(mark)
                return operateContext.RedirectAjax(0, "导入成功~", "", "");
            return operateContext.RedirectAjax(1, "导入失败~", "", "");
        }
        #endregion

        #region 1.2.6 下载导入模板 根据单位下载 + void DownLoadTemplate()
        /// <summary>
        ///  1.2.6 下载导入模板 根据单位下载
        /// </summary>
        /// <returns></returns>
        public void DownLoadTemplate()
        {
            string UnitID = RequestHelper.GetStrByName("UnitID"),
                E0386 = RequestHelper.GetStrByName("post0386"),//工种
                in_team = RequestHelper.GetStrByName("in_team");//所属队伍
            // 写入到客户端  
            operateContext.bllSession.WGJG02_Template.ExportTemplateToExcel(UnitID, E0386, in_team);
        }
        #endregion

        #region 1.2.7 获取所属 队伍数据 + ActionResult GetInTeamData()
        /// <summary>
        ///  1.2.7 获取所属 队伍数据
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult GetInTeamData()
        {
            string unitID = RequestHelper.GetStrByName("UnitID");
            List<ComProModel> list = operateContext.bllSession.T_CompProInfo.GetComProData(unitID);
            if (null == list || list.Count <= 0)
                return operateContext.RedirectAjax(1, "项目无所属队伍设置！", "", "");
            return operateContext.RedirectAjax(0, "数据获取成功~", list, "");
        } 
        #endregion

        //***************************工资发放**********************

        #region 2.0 工资发放 + ActionResult WageList()
        /// <summary>
        ///  2.0 工资发放
        /// </summary>
        /// <returns></returns>
        [HCQ2_Common.Attributes.Load]
        [HCQ2_Common.Attributes.Element]
        public ActionResult WageList()
        {
            return View();
        }
        #endregion

        #region 2.1 工资发放一栏 + ActionResult InitTableData()
        /// <summary>
        ///  2.1 工资发放一栏
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult InitTableData()
        {
            string unitID = Helper.ToString(Request["unitID"]);
            if (string.IsNullOrEmpty(unitID))
                return null;
            string WGJG0103 = RequestHelper.GetDeStrByName("WGJG0103"),
                CodeItemValue = RequestHelper.GetStrByName("CodeItemValue"),
                startDate = RequestHelper.GetStrByName("startDate"),
                endDate = RequestHelper.GetStrByName("endDate");
            int page = Helper.ToInt(Request["page"]);
            int rows = Helper.ToInt(Request["rows"]);
            HCQ2_Model.SelectModel.WGJG01ChartModel model = new HCQ2_Model.SelectModel.WGJG01ChartModel()
            {
                unitID = unitID,keyword = WGJG0103,stauts = CodeItemValue,dateStart = startDate,dateEnd = endDate,page = page, rows = rows
            };
            List<WGJG01Model> list = operateContext.bllSession.WGJG01.GetWageListDataByUnit(model);
            TableModel tModel = new TableModel()
            {
                total = operateContext.bllSession.WGJG01.SelectCount(s=>s.UnitID ==unitID),
                rows = list
            };
            return Json(tModel, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region 2.2 获取备注信息 +ActionResult GetNoteByRowId()
        /// <summary>
        ///  获取备注信息
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult GetNoteByRowId()
        {
            string rowid = Helper.ToString(Request["rowid"]);
            HCQ2_Model.WGJG01 wg =
                operateContext.bllSession.WGJG01.Select(s => s.RowID == rowid).FirstOrDefault();
            if(wg!=null)
                return operateContext.RedirectAjax(0, wg.WGJG0104, "", "");
            return operateContext.RedirectAjax(1, "备注信息为空~", "", "");
        }
        #endregion

        #region 2.3 添加工资发放 +  ActionResult AddFinance()
        /// <summary>
        ///  2.3 添加工资发放
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult AddFinance()
        {
            return null;
        }
        #endregion

        #region 2.4 编辑工资发放 +  ActionResult EditFinance()
        /// <summary>
        ///  2.3 编辑工资发放
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult EditFinance(HCQ2_Model.WGJG01 model)
        {
            if (null == model)
                return operateContext.RedirectAjax(1, "数据获取失败~", "", "");
            int back = operateContext.bllSession.WGJG01.EditWGJG01(model);
            if (back > 0)
                return operateContext.RedirectAjax(0, "添加数据成功~", "", "");
            return operateContext.RedirectAjax(1, "数据保存失败~", "", "");
        }
        #endregion

        #region 2.5 删除工资发放 + ActionResult DelFinace()
        /// <summary>
        ///  2.5 删除工资发放
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult DelFinace()
        {
            string rowID = Helper.ToString(Request["rowid"]);
            int mark = operateContext.bllSession.WGJG01.Delete(s => s.RowID == rowID);
            mark += operateContext.bllSession.WGJG02.Delete(s => s.WGJG01RowID == rowID);
            if(mark>0)
                return operateContext.RedirectAjax(0,"删除成功~", "", "");
            return operateContext.RedirectAjax(1, "删除失败~", "", "");
        } 
        #endregion

        //***************************发放人员***************************
        #region 3.0 发放人员一栏 + ActionResult GrantPersonsList()
        /// <summary>
        ///  3.0 发放人员一栏
        /// </summary>
        /// <returns></returns>
        [HCQ2_Common.Attributes.Load]
        public ActionResult GrantPersonsList()
        {
            return View();
        }
        #endregion

        #region 3.1 获取发放人员数据 + ActionResult InitWageTableData()
        /// <summary>
        ///  3.1 获取发放人员数据
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult InitWageTableData()
        {
            string rowid = Helper.ToString(Request["rowid"]);
            string unitID = Helper.ToString(Request["unitID"]);
            string dateStart = Helper.ToString(Request["dateStart"]);
            string dateEnd = Helper.ToString(Request["dateEnd"]);
            string sendType = Helper.ToString(Request["sendType"]);
            string userName = RequestHelper.GetDeStrByName("userName");//关键字
            int page = Helper.ToInt(Request["page"]);
            int rows = Helper.ToInt(Request["rows"]);
            HCQ2_Model.SelectModel.WGJG01ChartModel model = new HCQ2_Model.SelectModel.WGJG01ChartModel() { rowID = rowid, keyword=userName, unitID = unitID, isGive = sendType, dateStart = dateStart, dateEnd = dateEnd, page = page, rows = rows };
            List<WGJG02Model> list = operateContext.bllSession.WGJG02.GetWageDetailByRowId(model);
            TableModel tModel = new TableModel()
            {
                total = operateContext.bllSession.WGJG02.CountGrantPersons(model),
                rows = list
            };
            return Json(tModel, JsonRequestBehavior.AllowGet);
        } 
        #endregion
    }
}
