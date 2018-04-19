using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using HCQ2_Model;
using HCQ2_Model.ViewModel;

namespace HCQ2UI_Logic
{
    public class CheckGroupController : BaseLogic
    {
        /// <summary>
        /// 考勤群组分配
        /// </summary>
        /// <returns></returns>
        [HCQ2_Common.Attributes.Load]
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// 获取显示数据源
        /// </summary>
        /// <param name="form"></param>
        /// <returns></returns>
        public ActionResult GetSoure(FormCollection form)
        {
            TableModel model = operateContext.bllSession.T_CheckGroup.GetPageView(form);
            return Json(model, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 验证用户名
        /// </summary>
        /// <param name="person_name"></param>
        /// <param name="UnitID"></param>
        /// <returns></returns>
        public ActionResult CheckUser(string person_name, string UnitID)
        {
            if (string.IsNullOrEmpty(person_name))
                return Content("false");
            List<A01> user = operateContext.bllSession.T_CheckGroup.GetUserByUnitNotCheck(UnitID, "");
            string userName = person_name.Substring(0, person_name.IndexOf('('));
            string person_identifycode = person_name.Substring(person_name.IndexOf('(') + 1, person_name.IndexOf(')') - person_name.IndexOf('(') - 1);
            var data = user.Where(o => o.A0101.Contains(userName) && o.A0177 == person_identifycode);
            if (data.Count() > 0)
                return Content("true");
            else
                return Content("false");
        }

        /// <summary>
        /// 添加考勤组长
        /// </summary>
        /// <param name="UnitID"></param>
        /// <param name="Person"></param>
        /// <returns></returns>
        public ActionResult AddGroupLeader(string UnitID, string Person, string group_name, string xMin, string yMin, string xyAoe)
        {
            string str = operateContext.bllSession.T_CheckGroup.AddGroupLeader(UnitID, Person, group_name, xMin, yMin, xyAoe) ? "ok"
                : "fin";
            return Content(str);
        }

        /// <summary>
        /// 编辑考勤组情况
        /// </summary>
        /// <param name="UnitID"></param>
        /// <param name="Person"></param>
        /// <param name="group_name"></param>
        /// <param name="xMin"></param>
        /// <param name="yMin"></param>
        /// <param name="xyAoe"></param>
        /// <param name="group_id"></param>
        /// <returns></returns>
        public ActionResult EditGroupLeader(string xMin, string yMin, string xyAoe,string group_name, string group_id)
        {
            string str = operateContext.bllSession.T_CheckGroup.EditGroupLeader(xMin, yMin, xyAoe, group_id, group_name) ? "ok"
                : "fin";
            return Content(str);
        }

        /// <summary>
        /// 查询考勤组成员信息
        /// </summary>
        /// <param name="group_id"></param>
        /// <returns></returns>
        public ActionResult GetGroupMenber(FormCollection form)
        {
            string group_id = form["group_id"];
            int rows = int.Parse(form["rows"]);
            int page = int.Parse(form["page"]);
            var data = operateContext.bllSession.T_CheckGroup.GetGroupMenber(group_id);
            TableModel model = new TableModel();
            model.total = data.Count();
            model.rows = data.Skip((rows * page) - rows).Take(rows);
            return Json(model, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 新增考勤组成员
        /// </summary>
        /// <param name="form"></param>
        /// <returns></returns>
        public ActionResult AddGroupMenber(string group_id, string rows)
        {
            string str = operateContext.bllSession.T_CheckGroup.AddGroupMenber(group_id, rows)
                ? "ok" : "fin";
            return Content(str);
        }

        /// <summary>
        /// 删除一个考勤组成员
        /// </summary>
        /// <param name="group_id"></param>
        /// <returns></returns>
        public ActionResult DeleteMenber(string rows)
        {
            string str = operateContext.bllSession.T_CheckGroup.DeleteGroupMenber(rows)
                ? "ok" : "fin";
            return Content(str);
        }

        /// <summary>
        /// 删除整个考勤组
        /// </summary>
        /// <param name="rows"></param>
        /// <returns></returns>
        public ActionResult DeleteGroupLeader(string rows)
        {
            string str = operateContext.bllSession.T_CheckGroup.DeleteGroupLeader(rows)
                ? "ok" : "fin";
            return Content(str);
        }

        /// <summary>
        /// 获取该项目的最大考勤组数量
        /// </summary>
        /// <param name="UnitID"></param>
        /// <returns></returns>
        public ActionResult GetMaxGroup(string UnitID)
        {
            var data = operateContext.bllSession.B01.GetByUnitID(UnitID);
            int? maxGroup = string.IsNullOrEmpty(data.maxGroupCount.ToString()) ? 0 : data.maxGroupCount;
            return Content(maxGroup.ToString());
        }

        /// <summary>
        /// 获取该项目的最大考勤组数量
        /// </summary>
        /// <param name="UnitID"></param>
        /// <returns></returns>
        public ActionResult GetMaxGroupCount(string UnitID)
        {
            var data = operateContext.bllSession.B01.GetByUnitID(UnitID);
            int? maxGroup = string.IsNullOrEmpty(data.maxGroupPer.ToString()) ? 0 : data.maxGroupPer;
            return Content(maxGroup.ToString());
        }

        /// <summary>
        /// 获取没有分配考勤组的人员信息
        /// </summary>
        /// <param name="UnitID"></param>
        /// <returns></returns>
        public ActionResult GetNotCheck(string UnitID, string PersonName)
        {
            List<A01> user = operateContext.bllSession.T_CheckGroup.GetUserByUnitNotCheck(UnitID, PersonName);
            List<SearchUser> seaList = new List<SearchUser>();
            foreach (var item in user)
            {
                SearchUser se = new SearchUser();
                se.A0101 = item.A0101;
                se.A0177 = item.A0177;
                se.PersonID = item.PersonID;
                se.UnitID = item.UnitID;
                seaList.Add(se);
            }
            return Json(seaList, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 为分配考勤组的数据信息
        /// </summary>
        /// <returns></returns>
        public ActionResult GetNotCheckPageModel(FormCollection form)
        {
            string UnitID = form["UnitID"];
            string PersonName = form["PersonName"];
            List<A01> user = operateContext.bllSession.T_CheckGroup.GetUserByUnitNotCheck(UnitID, PersonName);
            List<SearchUser> seaList = new List<SearchUser>();
            foreach (var item in user)
            {
                SearchUser se = new SearchUser();
                se.A0101 = item.A0101;
                se.A0177 = item.A0177;
                se.PersonID = item.PersonID;
                se.UnitID = item.UnitID;
                seaList.Add(se);
            }
            TableModel model = new TableModel();
            model.total = seaList.Count();
            model.rows = seaList;
            return Json(model, JsonRequestBehavior.AllowGet);
        }
    }

    public class SearchUser
    {
        public string A0101;
        public string A0177;
        public string PersonID;
        public string UnitID;
    }

}
