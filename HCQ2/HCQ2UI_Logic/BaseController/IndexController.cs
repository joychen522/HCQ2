using HCQ2_Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace HCQ2UI_Logic
{
    /// <summary>
    ///  首页控制器
    /// </summary>
    public class IndexController : BaseLogic
    {
        /// <summary>
        /// 数据获取私有变量
        /// </summary>
        private HCQ2_IBLL.IBLLSession bll;

        /// <summary>
        /// 首页
        /// </summary>
        /// <returns></returns>
        public ActionResult List()
        {
            bll = operateContext.bllSession;

            //推送代办事宜
            bll.T_TodoList.WriteRepostLog(operateContext.Usr.user_id);

            //总人数
            ViewBag.Count = bll.A01.GetPeopleSum(operateContext.Usr.user_id);

            //今日到岗人员
            ViewBag.Attendance = bll.View_A02.GetAttendanceTrue(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, operateContext.Usr.user_id.ToString());

            //工地数量
            ViewBag.UnitTypeM = bll.B01.GetProjectCount(operateContext.Usr.user_id.ToString());

            //欠薪金额、欠薪人数
            DataTable dt = bll.View_QXTJ.GetStaticWagePerson(operateContext.Usr.user_id);
            ViewBag.QxWage = dt.Rows[0]["wage"];
            ViewBag.QxCount = dt.Rows[0]["count"];

            //待整改
            ViewBag.WGJGZX = bll.T_EnterDetail.GetEnterByUserid(operateContext.Usr.user_id).Count();

            //政策信息
            ViewBag.BMQ = bll.BMQ_Document.GetDocumentSortName(bll.BMQ_Document.GetDocumentInfo());

            //欠薪统计:金额
            ViewBag.QXTJMoney = bll.View_QXTJ.GetDebtUnitDataByPermissTopSeven();

            //欠薪统计:人数
            ViewBag.QXTJPerson = bll.View_QXTJ.GetDebtPersonByPermissTopSeren();

            //待办事宜
            ViewBag.DBSY = bll.T_TodoList.SendTodo(operateContext.Usr.user_id);

            //工种人数统计
            List<string> ListJobs = new List<string>();
            List<int> ListCount = new List<int>();
            bll.A01.StaticJobsCoumt(operateContext.Usr.user_id, ref ListJobs, ref ListCount);
            ViewBag.Jobs = HCQ2_Common.JsonHelper.objectToJsonStr(ListJobs);
            ViewBag.JobsCount = HCQ2_Common.JsonHelper.objectToJsonStr(ListCount);

            //新闻公告
            List<T_MessageNotice> messList = operateContext.bllSession.T_MessageNotice.GetAllMess();
            ViewBag.Mess = messList.Take(4).ToList();

            return View("List");
        }

        /// <summary>
        /// 出工排名统计
        /// </summary>
        /// <returns></returns>
        public ActionResult GetWorkDays()
        {
            List<string> unitName = new List<string>();
            List<int> totalPerson = new List<int>();
            List<int> workPerson = new List<int>();
            List<decimal> pepe = new List<decimal>();

            List<StaticWorkDay> list = new List<StaticWorkDay>();
            int user_id = operateContext.Usr.user_id;
            List<B01> unitList = operateContext.bllSession.B01.GetPerUnitByUserID(user_id);
            List<A01> personList = operateContext.bllSession.A01.GetA01Info();
            StaticWorkDay workDay = new StaticWorkDay();

            StringBuilder sbSql = new StringBuilder();
            foreach (var item in unitList)
            {
                List<A01> listTotal = new List<A01>();
                workDay = new StaticWorkDay();
                string arrPersonID = string.Empty;
                listTotal = personList.Where(o => o.UnitID == item.UnitID).ToList();
                //取得总人数的身份证号码集合
                foreach (var p in listTotal)
                {
                    if (string.IsNullOrEmpty(arrPersonID))
                        arrPersonID = "'" + p.PersonID + "'";
                    else
                        arrPersonID += ",'" + p.PersonID + "'";
                }
                //取得已打卡人数
                sbSql = new StringBuilder();
                sbSql.AppendFormat("select distinct PersonID from A02 where YEAR(A0201)={0}",DateTime.Now.Year);
                sbSql.AppendFormat("and MONTH(A0201)={1} and DAY(A0201)={2} and PersonID in ({0})", string.IsNullOrEmpty(arrPersonID) ? "''" : arrPersonID, DateTime.Now.Month, DateTime.Now.Day);
                DataTable dt = HCQ2_Common.SQL.SqlHelper.ExecuteDataTable(sbSql.ToString());

                //unitName.Add(item.UnitName);
                //totalPerson.Add(listTotal.Count());
                workDay = new StaticWorkDay();
                workDay.unitName = item.UnitName;
                workDay.totalPerson = listTotal.Count();
                workDay.workPerson = dt.Rows.Count;
                if (workDay.totalPerson > 0)
                    workDay.pepe = Convert.ToDouble((((decimal)workDay.workPerson / workDay.totalPerson) * 100).ToString("f2"));
                else
                    workDay.pepe = 0;
                list.Add(workDay);
            }
            return Json(list.OrderByDescending(o => o.pepe), JsonRequestBehavior.AllowGet);
        }

        #region 政策新闻

        [HCQ2_Common.Attributes.Load]
        public ActionResult DocumentDetail(string documentID)
        {
            bll = operateContext.bllSession;
            ViewBag.Title = "政策详细信息";
            ViewBag.Document = bll.BMQ_Document.GetByDocumentID(documentID);
            return View("DocumentDetail");
        }

        /// <summary>
        /// 获取政策对象
        /// </summary>
        /// <param name="documentID"></param>
        /// <returns></returns>
        public ActionResult GetDocument(string documentID)
        {
            var data = operateContext.bllSession.BMQ_Document.GetByDocumentID(documentID);
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        #endregion
    }

    public class StaticWorkDay
    {
        /// <summary>
        /// 总人数
        /// </summary>
        public int totalPerson { get; set; }
        /// <summary>
        /// 打卡人数
        /// </summary>
        public int workPerson { get; set; }
        /// <summary>
        /// 打卡率
        /// </summary>
        public double pepe { get; set; }
        /// <summary>
        /// 项目名称
        /// </summary>
        public string unitName { get; set; }
    }
}
