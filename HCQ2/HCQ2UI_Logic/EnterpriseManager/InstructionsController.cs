using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using HCQ2_Model.ViewModel;
using System.Web;
using System.IO;

namespace HCQ2UI_Logic
{
    public class InstructionsController : BaseLogic
    {

        [HCQ2_Common.Attributes.Load]
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// 页面显示数据源
        /// </summary>
        /// <param name="form"></param>
        /// <returns></returns>
        public ActionResult GetTableModel(FormCollection form)
        {
            int rows = int.Parse(form["rows"]);
            int page = int.Parse(form["page"]);
            var data = operateContext.bllSession.T_Instructions.GetInstruction()
                .OrderByDescending(o => o.create_date).ToList();
            if (!string.IsNullOrEmpty(form["txtSearchName"]))
            {
                string txtTitle = form["txtSearchName"];
                data = data.Where(o => o.in_title.Contains(txtTitle)).ToList();
            }
            TableModel model = new TableModel();
            model.total = data.Count();
            model.rows = data.Skip((rows * page) - rows);
            return Json(model, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 上传附件
        /// </summary>
        /// <returns></returns>
        public ActionResult FileUrl()
        {
            string returnStr = "";
            HttpFileCollection hfc = System.Web.HttpContext.Current.Request.Files;
            if (hfc.Count > 0 && !string.IsNullOrEmpty(hfc[0].FileName))
            {
                string image = "~/UpFile/Instructions";
                if (Directory.Exists(System.Web.HttpContext.Current.Server.MapPath(image)) == false)//如果不存在就创建file文件夹
                    Directory.CreateDirectory(System.Web.HttpContext.Current.Server.MapPath(image));
                hfc[0].SaveAs(System.Web.HttpContext.Current.Server.MapPath(image + "/" + hfc[0].FileName));
                returnStr = image + "/" + hfc[0].FileName;
            }
            return Content(returnStr);
        }

        /// <summary>
        /// 保存
        /// </summary>
        /// <param name="form"></param>
        /// <returns></returns>
        public ActionResult SaveFiles(FormCollection form)
        {
            string str = operateContext.bllSession.T_Instructions.SaveInstruction(form) ? "ok" : "fin";
            return Content(str);
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="in_id"></param>
        /// <returns></returns>
        public ActionResult DeleteFiles(int in_id)
        {
            string str = operateContext.bllSession.T_Instructions.DeleteInstruction(in_id) ? "ok" : "fin";
            return Content(str);
        }

        /// <summary>
        /// 获取首页显示的说明书数据
        /// </summary>
        /// <returns></returns>
        public ActionResult GetMainList()
        {
            var data = operateContext.bllSession.T_Instructions.GetInstruction();
            return Content(HCQ2_Common.JsonHelper.objectToJsonStr(data));
        }
    }
}
