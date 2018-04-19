using HCQ2_Common;
using HCQ2_Model.AfterSaleModel;
using HCQ2_Model.ViewModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace HCQ2UI_Logic.AfterSaleManager
{
    /// <summary>
    ///  项目台账 控制器
    /// </summary>
    public class ItemPreserveController:BaseLogic
    {
        //**********************************1.0 项目台账************************************

        #region 1.0 首次进入项目台账 + ActionResult ItemList()
        /// <summary>
        ///  1.0 首次进入项目台账 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [HCQ2_Common.Attributes.Load]
        [HCQ2_Common.Attributes.Element]
        public ActionResult ItemList()
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
                status = RequestHelper.GetDeStrByName("status");//状态
            int page = RequestHelper.GetIntByName("page"),
               rows = RequestHelper.GetIntByName("rows");
            ItemPreserveParam param = new ItemPreserveParam { rows = rows, page = page, unit_code = unit_code, area_code = area_code, status = status };
            List<ItemPreserveModel> list = operateContext.bllSession.BB_ItemPreserve.GetInitData(param);
            TableModel tModel = new TableModel()
            {
                total = operateContext.bllSession.BB_ItemPreserve.GetCountData(param),
                rows = list
            };
            return Json(tModel, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region 1.2 添加项目记录 + ActionResult AddItem(UserModel user)
        /// <summary>
        ///  添加用户
        /// </summary>
        /// <param name="user">用户对象</param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult AddItem(ItemPreserveModel item)
        {
            if (!ModelState.IsValid)
                return operateContext.RedirectAjax(1, "数据验证失败~", "", "");
            item.record_name = operateContext.Usr.user_name;
            try
            {
                int mark = operateContext.bllSession.BB_ItemPreserve.AddItem(item);
                if (mark>0)
                    return operateContext.RedirectAjax(0, "添加用户成功~", "", "");
                return operateContext.RedirectAjax(1, "添加用户失败~", "", "");
            }
            catch (Exception ex)
            {
                return operateContext.RedirectAjax(1, ex.Message, "", "");
            }
        }
        #endregion

        #region 1.3 编辑台账记录 + ActionResult EditItem(ItemPreserveModel item)
        /// <summary>
        ///  编辑台账记录
        /// </summary>
        /// <param name="item">项目记录</param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult EditItem(ItemPreserveModel item)
        {
            if (!ModelState.IsValid)
                return operateContext.RedirectAjax(1, "数据验证失败~", "", "");
            int ip_id = Helper.ToInt(Request["ip_id"]);
            item.record_name= operateContext.Usr.user_name;
            if (ip_id <= 0)
                return operateContext.RedirectAjax(1, "编辑台账主键值为空~", "", "");
            operateContext.bllSession.BB_ItemPreserve.EditItem(item,ip_id);
            return operateContext.RedirectAjax(0, "编辑用户成功~", "", "");
        }
        #endregion

        #region 1.4 删除项目记录 + ActionResult DelItemByID(int id)
        /// <summary>
        ///  1.4 删除项目记录
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult DelItemByID(int id)
        {
            if (id <= 0)
                return operateContext.RedirectAjax(1, "需要删除的数据不存在~", "", "");
            int mark = operateContext.bllSession.BB_ItemPreserve.Delete(s => s.ip_id == id);
            if (mark > 0)
                return operateContext.RedirectAjax(0, "数据删除成功~", "", "");
            return operateContext.RedirectAjax(1, "数据删除失败~", "", "");
        }
        #endregion

        #region 1.5 初始化区域树 + ActionResult InitAreaTreeData()
        /// <summary>
        ///  1.5 初始化区域树
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult InitAreaTreeData()
        {
            return operateContext.RedirectAjax(0, "成功", operateContext.bllSession.BB_ItemPreserve.GetAreaData(operateContext.Usr.user_id), "");
        }
        #endregion

        //**********************************2.0 缴纳金额************************************

        #region 2.0 缴纳金额首次页面进入 + ActionResult CashList()
        /// <summary>
        ///  2.0 缴纳金额首次页面进入
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [HCQ2_Common.Attributes.Load]
        [HCQ2_Common.Attributes.Element]
        public ActionResult CashList()
        {
            return View();
        }
        #endregion

        #region 2.1 初始化缴纳金额Table数据表 + ActionResult InitCashTable()
        /// <summary>
        ///  2.1 初始化缴纳金额Table数据表
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult InitCashTable()
        {
            int page = RequestHelper.GetIntByName("page"),
               rows = RequestHelper.GetIntByName("rows"),
               ip_id = RequestHelper.GetIntByName("ip_id");//项目ID
            List<CashDetailModel> list = operateContext.bllSession.BB_CashDetail.GetInitCashData(ip_id, rows, page);
            TableModel tModel = new TableModel()
            {
                total = operateContext.bllSession.BB_CashDetail.SelectCount(s => s.ip_id == ip_id),
                rows = list
            };
            return Json(tModel, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region 2.2 添加项目缴纳金额记录 + ActionResult AddCashItem(UserModel user)
        /// <summary>
        ///  添加项目缴纳金额记录
        /// </summary>
        /// <param name="item">缴纳金额对象</param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult AddCashItem(CashDetailModel item)
        {
            if (!ModelState.IsValid)
                return operateContext.RedirectAjax(1, "数据验证失败~", "", "");
            try
            {
                int mark = operateContext.bllSession.BB_CashDetail.AddCashItem(item);
                if (mark > 0)
                    return operateContext.RedirectAjax(0, "添加用户成功~", "", "");
                return operateContext.RedirectAjax(1, "添加用户失败~", "", "");
            }
            catch (Exception ex)
            {
                return operateContext.RedirectAjax(1, ex.Message, "", "");
            }
        }
        #endregion

        #region 2.3 编辑台账记录 + ActionResult EditCashItem(ItemPreserveModel item)
        /// <summary>
        ///  编辑台账记录
        /// </summary>
        /// <param name="item">项目记录</param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult EditCashItem(CashDetailModel item)
        {
            if (!ModelState.IsValid)
                return operateContext.RedirectAjax(1, "数据验证失败~", "", "");
            int cd_id = Helper.ToInt(Request["cd_id"]);
            if (cd_id <= 0)
                return operateContext.RedirectAjax(1, "编辑缴纳金额主键值为空~", "", "");
            operateContext.bllSession.BB_CashDetail.EditCashItem(item, cd_id);
            return operateContext.RedirectAjax(0, "编辑数据成功~", "", "");
        }
        #endregion

        #region 2.4 删除缴纳金额项目记录 + ActionResult DelItemCashByID(int id)
        /// <summary>
        ///  2.4 删除缴纳金额项目记录
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult DelItemCashByID(int id)
        {
            if (id <= 0)
                return operateContext.RedirectAjax(1, "需要删除的数据不存在~", "", "");
            int mark = operateContext.bllSession.BB_CashDetail.Delete(s => s.cd_id == id);
            if (mark > 0)
                return operateContext.RedirectAjax(0, "数据删除成功~", "", "");
            return operateContext.RedirectAjax(1, "数据删除失败~", "", "");
        }
        #endregion

        #region 2.5 重新计算 缴纳金额 + ActionResult CalculateCashMoney(int id)
        /// <summary>
        ///  2.5 重新计算 缴纳金额
        /// </summary>
        /// <param name="id">台账ID</param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult CalculateCashMoney(int id)
        {
            if(id<=0)
                return operateContext.RedirectAjax(1, "需要计算的缴纳金额记录不存在~", "", "");
            List<HCQ2_Model.BB_CashDetail> list = operateContext.bllSession.BB_CashDetail.Select(s => s.ip_id == id).ToList();
            if(list==null || list.Count<=0)
                return operateContext.RedirectAjax(0, "需要计算的缴纳金额记录不存在~", "", "");
            decimal total = list.Sum(s => s.cash_money);
            operateContext.bllSession.BB_ItemPreserve.Modify(new HCQ2_Model.BB_ItemPreserve { pay_money = total }, s => s.ip_id == id, "pay_money");
            return operateContext.RedirectAjax(0, "成功重新统计缴纳金额~", "", "");
        } 
        #endregion

        //**********************************3.0 合同附件************************************

        #region 3.0.0 合同附件页面首次进入 + ActionResult PactFlieList()
        /// <summary>
        ///  3.0.0 合同附件页面首次进入
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [HCQ2_Common.Attributes.Load]
        [HCQ2_Common.Attributes.Element]
        public ActionResult PactFlieList()
        {
            return View();
        }
        #endregion

        #region 3.0.1上传页面首次进入 + ActionResult PactUpLoadFile()
        /// <summary>
        ///  上传页面首次进入
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [HCQ2_Common.Attributes.Load]
        public ActionResult PactUpLoadFile()
        {
            return View();
        } 
        #endregion

        #region 3.1 初始化附件Table数据表 + ActionResult InitPactTable()
        /// <summary>
        ///  3.1 初始化附件Table数据表
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult InitPactTable()
        {
            int page = RequestHelper.GetIntByName("page"),
               rows = RequestHelper.GetIntByName("rows"),
               ip_id = RequestHelper.GetIntByName("ip_id");//项目ID
            List<HCQ2_Model.BB_PactDetailFlie> list = operateContext.bllSession.BB_PactDetailFlie.GetInitPactData(ip_id, rows, page);
            TableModel tModel = new TableModel()
            {
                total = operateContext.bllSession.BB_PactDetailFlie.SelectCount(s => s.ip_id == ip_id),
                rows = list
            };
            return Json(tModel, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region 3.2 上传合同附件 + ActionResult UpLoadFile(int id)
        /// <summary>
        ///  3.2 上传合同附件
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult UpLoadFile(int id)
        {
            var files = Request.Files;
            if (id <= 0 || files == null || files.Count <= 0)
                return null;
            string pd_name = RequestHelper.GetStrByName("pd_name");//合同名称
            HCQ2_Model.BB_PactDetailFlie model = new HCQ2_Model.BB_PactDetailFlie();
            #region 1.0 处理上传文件夹
            string pathServer = "~/UpFile/AfterSale/" + DateTime.Now.ToString("yyyy-MM") + "/" + operateContext.Usr.user_name + "/" + id;
            string path = Server.MapPath(pathServer);//文档存放路径：~/UpFile/AfterSale/2017-05/系统管理/1
            if (!Directory.Exists(path.ToString()))
                Directory.CreateDirectory(path.ToString());//文件夹不存在则创建
            #endregion

            #region 2.0 处理文档
            int file_id = 0;
            for (int i = 0; i < files.Count; i++)
            {
                HttpPostedFileBase file = files[i];
                if (null == file)
                    continue;
                //1.上传文档
                file.SaveAs(Server.MapPath(pathServer + "/" + file.FileName));//上传文件
                //2.保存文档信息
                model.ip_id = id;
                model.pd_date = DateTime.Now;
                model.pd_name = (!string.IsNullOrEmpty(pd_name)) ? pd_name : file.FileName.Split('.')[0];//文件名
                model.pd_file = pathServer + "/" + file.FileName;
                file_id = operateContext.bllSession.BB_PactDetailFlie.Add(model);
            }
            #endregion
            if (file_id > 0)
                return operateContext.RedirectAjax(0, "文档上传成功~", "", "");
            return operateContext.RedirectAjax(1, "文档上传失败~", "", "");
        } 
        #endregion

        #region 3.3 删除附件项目 + ActionResult DelItemPactByID(int id)
        /// <summary>
        ///  3.3 删除附件项目
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult DelItemPactByID(int id)
        {
            HCQ2_Model.BB_PactDetailFlie fileObj = operateContext.bllSession.BB_PactDetailFlie.Select(s => s.pd_id == id).FirstOrDefault();
            if (fileObj == null)
                return operateContext.RedirectAjax(1, "需要删除的数据不存在~", "", "");
            string url = fileObj.pd_file;//存档路径
            //1.删除数据库记录
            int mark = operateContext.bllSession.BB_PactDetailFlie.Delete(s => s.pd_id == id);
            //2.删除文档
            if (System.IO.File.Exists(Server.MapPath(url)))
                System.IO.File.Delete(Server.MapPath(url));
            if (mark > 0)
                return operateContext.RedirectAjax(0, "数据删除成功~", "", "");
            return operateContext.RedirectAjax(1, "数据删除失败~", "", "");
        }
        #endregion
    }
}
