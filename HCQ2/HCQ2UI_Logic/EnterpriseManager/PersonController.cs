using HCQ2_Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using HCQ2_Model.ViewModel;
using System.Security.Cryptography.X509Certificates;

namespace HCQ2UI_Logic
{
    public class PersonController : BaseLogic
    {
        /// <summary>
        /// 数据获取私有变量
        /// </summary>
        private HCQ2_IBLL.IBLLSession bll;

        #region 个人信息

        /// <summary>
        /// 各人信息Index
        /// </summary>
        /// <returns></returns>
        [HCQ2_Common.Attributes.Load]
        [HCQ2_Common.Attributes.Element]
        public ActionResult Index()
        {
            List<HCQ2_Model.TreeModel.B01PerTreeModel> list = operateContext.bllSession.B01.GetB01PerData(operateContext.Usr.user_id);
            ViewBag.TreeJson = HCQ2_Common.JsonHelper.ObjectToJson(list).ToString();
            return View();
        }

        /// <summary>
        /// 获取所有人员
        /// </summary>
        /// <returns></returns>
        public ActionResult GetPersonInfo()
        {
            List<A01> list = operateContext.bllSession.A01.GetA01Info();
            string strJson = operateContext.bllSession.A01.GetA01Json(list);
            return Content(strJson);
        }

        /// <summary>
        /// 获取所有人员的json数据
        /// </summary>
        /// <param name="form"></param>
        /// <returns></returns>
        public ActionResult GetByUnitID(FormCollection form)
        {
            string strJson = operateContext.bllSession.A01.GetA01Json(
                operateContext.bllSession.A01.GetByUnitID(form["unitID"]));
            return Content(strJson);
        }

        /// <summary>
        /// 个人信息获取显示数据源
        /// </summary>
        /// <param name="form"></param>
        /// <returns></returns>
        public ActionResult GetTablePersonInfo(FormCollection form)
        {
            int page = int.Parse(form["page"]);
            int rows = int.Parse(form["rows"]);
            DataTable dt = operateContext.bllSession.A01.GetPageTableModle(form);
            //去掉虹膜和照片信息
            dt.Columns.Remove("A0118");
            dt.Columns.Remove("PersonPhoto");
            dt.Columns.Remove("big_iris_data");
            var dataPage = dt.AsEnumerable().Skip((rows * page) - rows).Take(rows);

            string returnJson = "";
            if (dataPage.Count() > 0)
                returnJson = "{\"total\":" + dt.Rows.Count + ",\"rows\":" + HCQ2_Common.JsonHelper.DataTableToJson(dataPage.CopyToDataTable()) + "}";
            else
                returnJson = "{\"total\":" + dt.Rows.Count + ",\"rows\":[]}";
            return Content(returnJson);
        }

        #endregion

        #region 工时记录

        /// <summary>
        /// 工时记录
        /// </summary>
        /// <returns></returns>
        [HCQ2_Common.Attributes.Load]
        [HCQ2_Common.Attributes.Element]
        public ActionResult WorkTime()
        {
            List<HCQ2_Model.TreeModel.B01PerTreeModel> list = operateContext.bllSession.B01.GetB01PerData(operateContext.Usr.user_id);
            ViewBag.TreeJson = HCQ2_Common.JsonHelper.ObjectToJson(list).ToString();
            return View();
        }

        /// <summary>
        /// 获取工时记的数据源
        /// </summary>
        /// <param name="page"></param>
        /// <param name="rows"></param>
        /// <param name="UnitID"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult GetWorkTime(FormCollection form)
        {
            bll = operateContext.bllSession;
            int page = int.Parse(form["page"]);
            int rows = int.Parse(form["rows"]);
            int skip = (page * rows) - rows;

            string returnJson = string.Empty;
            if (string.IsNullOrEmpty(form["isType"].Trim()) || form["isType"] == "已签到")
            {
                List<HCQ2_Model.ViewModel.CheckModle> list = bll.View_A02.GetCheckCount(bll.View_A02.CheckPerson(form));
                var data = list.AsEnumerable();
                if (!string.IsNullOrEmpty(form["search"]))
                {
                    data = data.Where(o => o.A0101.Contains(form["search"].Trim()));
                }
                list = data.ToList();
                var dataJson = list.Skip(skip).Take(rows).ToList();
                returnJson = "{\"total\":" + list.Count() + ",\"rows\":" + HCQ2_Common.JsonHelper.ObjectToJson(dataJson.ToList()) + "}";
            }
            else
            {
                //未签到
                var PersonData = bll.View_A02.GetView(form);
                if (PersonData.Rows.Count > 0)
                {
                    var Json = PersonData.AsEnumerable().Skip(skip).Take(rows).CopyToDataTable();
                    returnJson = "{\"total\":" + PersonData.Rows.Count + ",\"rows\":" + HCQ2_Common.JsonHelper.DataTableToJson(Json) + "}";
                }
                else
                {
                    returnJson = "{\"total\":0,\"rows\":[]}";

                }
            }
            return Content(returnJson);
        }

        /// <summary>
        /// 首页出工人员详细
        /// </summary>
        /// <returns></returns>
        [HCQ2_Common.Attributes.Load]
        [HCQ2_Common.Attributes.Element]
        public ActionResult CheckWorkDay()
        {
            var data = operateContext.bllSession.View_A02.GetAttendanceDate(
                DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, operateContext.Usr.user_id);
            ViewBag.Tree = HCQ2_Common.JsonHelper.ObjectToJson(data);
            return View();
        }

        public ActionResult GetCheckWorkDaySoure(FormCollection form)
        {
            var treeData = operateContext.bllSession.View_A02.GetAttendanceDate(
                DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, operateContext.Usr.user_id);
            List<View_A02> list = operateContext.bllSession.View_A02.GetAttendanceDatePerson(
                DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, operateContext.Usr.user_id);
            int rows = int.Parse(form["rows"]);
            int page = int.Parse(form["page"]);
            string UnitID = "";
            if (!string.IsNullOrEmpty(form["UnitID"]))
                UnitID = form["UnitID"];
            else
            {
                UnitID = treeData[0].Where(o => o.Key != null).FirstOrDefault().Value.ToString();
            }
            list = list.Where(o => o.UnitID == UnitID).ToList();
            if (!string.IsNullOrEmpty(form["PersonName"]))
            {
                string PersonName = form["PersonName"];
                list = list.Where(o => o.A0101.Contains(PersonName)).ToList();
            }
            TableModel modle = new TableModel
            {
                total = list.Count,
                rows = list.Skip((rows * page) - rows).Take(rows)
            };
            return Json(modle, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 补签数据源
        /// </summary>
        /// <param name="form"></param>
        /// <returns></returns>
        public ActionResult GetBuCheckSoure(FormCollection form)
        {
            TableModel model = operateContext.bllSession.A02.GetBuCheckSoure(form);
            return Json(model, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 补签到
        /// </summary>
        /// <param name="form"></param>
        /// <returns></returns>
        public ActionResult BuCheckPerson(FormCollection form)
        {
            string strMsg = "";
            string reStr = operateContext.bllSession.A02.BuCheckPerson(form, out strMsg) ? "0" : "1";
            Dictionary<string, object> dic = new Dictionary<string, object>();
            dic.Add("status", reStr);
            dic.Add("msg", strMsg);
            return Json(dic, JsonRequestBehavior.AllowGet);
        }

        #endregion

        #region 重复数据

        /// <summary>
        /// 重复数据
        /// </summary>
        /// <returns></returns>
        [HCQ2_Common.Attributes.Load]
        [HCQ2_Common.Attributes.Element]
        public ActionResult GetRepeat()
        {
            ViewBag.title = "重复数据";
            return View();
        }

        /// <summary>
        /// 获取重复用工显示数据
        /// </summary>
        /// <param name="form"></param>
        /// <returns></returns>
        public ActionResult GetReaptData(FormCollection form)
        {
            bll = operateContext.bllSession;
            DataTable dt = bll.A01.GetReaptPerson();
            int page = int.Parse(form["page"]);
            int rows = int.Parse(form["rows"]);
            var data = dt.AsEnumerable();
            if (!string.IsNullOrEmpty(form["txtSearchName"]))
            {
                data = data.Where(o => o.Field<string>("A0101") == form["txtSearchName"].Trim());
            }
            var dataJson = data.Skip((page * rows) - rows).Take(rows);
            string viewJson = dataJson.Count() > 0 ? HCQ2_Common.JsonHelper.DataTableToJson(dataJson.CopyToDataTable()) : "[]";
            string returnJson = "{\"total\":" + data.Count() + ",\"rows\":" + viewJson + "}";
            return Content(returnJson);
        }

        #endregion

        #region 人员详细信息

        [HCQ2_Common.Attributes.Load]
        public ActionResult ArchiveDetail(string PersonID)
        {
            bll = operateContext.bllSession;
            A01 user = bll.A01.GetBySmCodeItem(bll.A01.GetByPersonID(PersonID));
            ViewBag.title = "人员详细信息";
            ViewBag.persondetail = user;
            ViewBag.Content = HCQ2_Common.JsonHelper.objectToJsonStr(user);

            string personPhoto = "";
            if (user.PersonPhoto != null)
            {
                string image = "File/ReadPhoto/" + user.A0101;
                byte[] PersonPhoto = user.PersonPhoto;
                string str = HCQ2_Common.ImageHelper.CreateImageFromBytes(HttpContext.Server.MapPath(image), user.A0101, PersonPhoto);
                personPhoto = image + "/" + str;
            }
            ViewBag.photo = personPhoto;

            return View();
        }

        /// <summary>
        /// 人员详细信息显示学习学位
        /// </summary>
        /// <param name="form"></param>
        /// <returns></returns>
        public ActionResult GetEduInfor(FormCollection form)
        {
            bll = operateContext.bllSession;
            int page = int.Parse(form["page"]);
            int rows = int.Parse(form["rows"]);
            string PersonID = form["PersonID"];
            List<A04> list = bll.A04.GetCodeItemA04(bll.A04.GetByPersonID(PersonID));

            string returnJson = "";
            if (list.Count() > 0)
            {
                returnJson = "{\"total\":" + list.Count() + ",\"rows\":" + HCQ2_Common.JsonHelper.ObjectToJson(list.Skip((page * rows) - rows).Take(rows)) + "}";
            }
            else
            {
                returnJson = "{\"total\":\"0\",\"rows\":[]}";
            }
            return Content(returnJson);
        }

        /// <summary>
        /// 人员详细信息显示工作经历
        /// </summary>
        /// <param name="form"></param>
        /// <returns></returns>
        public ActionResult GetWorkInfo(FormCollection form)
        {
            bll = operateContext.bllSession;
            int page = int.Parse(form["page"]);
            int rows = int.Parse(form["rows"]);
            string PersonID = form["PersonID"];
            List<A19> list = bll.A19.GetByPersonID(PersonID);

            string returnJson = "";
            if (list.Count() > 0)
            {
                returnJson = "{\"total\":" + list.Count() + ",\"rows\":" + HCQ2_Common.JsonHelper.ObjectToJson(list.Skip((page * rows) - rows).Take(rows)) + "}";
            }
            else
            {
                returnJson = "{\"total\":\"0\",\"rows\":[]}";
            }
            return Content(returnJson);
        }

        /// <summary>
        /// 考勤情况
        /// </summary>
        /// <param name="form"></param>
        /// <returns></returns>
        public ActionResult GetAttendanceInfo(FormCollection form)
        {
            bll = operateContext.bllSession;
            int page = int.Parse(form["page"]);
            int rows = int.Parse(form["rows"]);
            string PersonID = form["PersonID"];
            List<A02> list = bll.A02.GetByPersonID(PersonID);

            string returnJson = "";
            if (list.Count() > 0)
            {
                returnJson = "{\"total\":" + list.Count() + ",\"rows\":" + HCQ2_Common.JsonHelper.ObjectToJson(list.Skip((page * rows) - rows).Take(rows)) + "}";
            }
            else
            {
                returnJson = "{\"total\":\"0\",\"rows\":[]}";
            }
            return Content(returnJson);
        }

        /// <summary>
        /// 员工工资发放登记
        /// </summary>
        /// <param name="form"></param>
        /// <returns></returns>
        public ActionResult GetWageInfo(FormCollection form)
        {
            bll = operateContext.bllSession;
            int page = int.Parse(form["page"]);
            int rows = int.Parse(form["rows"]);
            string PersonID = form["PersonID"];
            List<A03> list = bll.A03.GetByPersonID(PersonID);

            string returnJson = "";
            if (list.Count() > 0)
            {
                returnJson = "{\"total\":" + list.Count() + ",\"rows\":" + HCQ2_Common.JsonHelper.ObjectToJson(list.Skip((page * rows) - rows).Take(rows)) + "}";
            }
            else
            {
                returnJson = "{\"total\":\"0\",\"rows\":[]}";
            }
            return Content(returnJson);
        }

        /// <summary>
        /// 根据unit_id获取B01信息
        /// </summary>
        /// <param name="unit_id"></param>
        /// <returns></returns>
        public ActionResult GetUnit(string unitid)
        {
            var b01 = operateContext.bllSession.B01.GetByUnitID(unitid);
            Dictionary<string, object> dic = new Dictionary<string, object>();
            dic.Add("cjdw", string.IsNullOrEmpty(b01.B0180) ? "" : b01.B0180);
            dic.Add("jsdwlxr", b01.JSDWLXR + "(" + b01.JSDWLXRDH + ")");
            return Json(dic, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 获取统计图月打卡天数的json数据
        /// </summary>
        /// <param name="person_id"></param>
        /// <returns></returns>
        public ActionResult GetMonthTime(string person_id)
        {
            var a = operateContext.bllSession.A01.GetByPersonID(person_id);
            StringBuilder sbSql = new StringBuilder();
            sbSql.AppendFormat("select distinct time=CAST(YEAR(A0201) as nvarchar(4))  +'.'+ CAST(MONTH(A0201) as nvarchar(4)),A0201");
            sbSql.AppendFormat(" from A02 where PersonID='{0}' order by A0201 ", person_id);
            DataTable dt = HCQ2_Common.SQL.SqlHelper.ExecuteDataTable(sbSql.ToString());
            monthDay day = new monthDay();
            if (dt != null && dt.Rows.Count > 0)
            {
                DataTable dtMonth = dt.DefaultView.ToTable(true, "time");
                List<string> listMonth = new List<string>();
                List<int> listDay = new List<int>();
                for (int i = 0; i < dtMonth.Rows.Count; i++)
                {
                    listMonth.Add(dtMonth.Rows[i]["time"].ToString());
                    listDay.Add(dt.AsEnumerable().Where(o => o.Field<string>("time") == dtMonth.Rows[i]["time"].ToString()).Count());
                }
                day.month = listMonth;
                day.day = listDay;
            }
            else
            {
                day.month = "";
                day.day = "";
            }
            return Json(day, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 个人征信
        /// </summary>
        /// <param name="person_id"></param>
        /// <returns></returns>
        public ActionResult WGJGGRZX(FormCollection form)
        {
            var data = operateContext.bllSession.A01.GetByPersonID(form["PersonID"]);
            var grzx = operateContext.bllSession.WGJG_GRZX.Select(o => o.WGJG_GRZX03 == data.A0177);
            int page = int.Parse(form["page"]);
            int rows = int.Parse(form["rows"]);

            TableModel modle = new TableModel()
            {
                total = grzx.Count(),
                rows = GetStatus(grzx)
            };
            return Json(modle, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 替换征信状态
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        private List<WGJG_GRZX> GetStatus(List<WGJG_GRZX> list)
        {
            if (list == null || list.Count() <= 0)
            {
                return list;
            }
            var codeItem = operateContext.bllSession.SM_CodeItems.GetCodeItemByCodeID("ZXZT");
            List<WGJG_GRZX> newList = new List<WGJG_GRZX>();
            foreach (var item in list)
            {
                try
                {
                    item.WGJG_GRZX06 = codeItem.Where(o => o.CodeItemID == item.WGJG_GRZX06).FirstOrDefault().CodeItemName;
                }
                catch (Exception e)
                {
                    item.WGJG_GRZX06 = "";
                }
                newList.Add(item);
            }
            return newList;
        }

        #endregion

        #region 信息管理>>新增人员信息

        /// <summary>
        /// 信息管理
        /// </summary>
        /// <returns></returns>
        [HCQ2_Common.Attributes.Element]
        [HCQ2_Common.Attributes.Load]
        public ActionResult NewPerson()
        {
            bll = operateContext.bllSession;
            List<HCQ2_Model.TreeModel.B01PerTreeModel> list = operateContext.bllSession.B01.GetB01PerData(operateContext.Usr.user_id);
            ViewBag.TreeJson = HCQ2_Common.JsonHelper.ObjectToJson(list).ToString();
            ViewBag.UnitID = operateContext.bllSession.B01.GetUnitDataByPermiss(
                operateContext.Usr.user_id).FirstOrDefault().UnitID;
            return View();
        }

        /// <summary>
        /// 信息管理获取人员信息
        /// </summary>
        /// <param name="form"></param>
        /// <returns></returns>
        public ActionResult GetPersonNewinfor(FormCollection form)
        {
            int page = int.Parse(form["page"]);
            int rows = int.Parse(form["rows"]);
            if (!string.IsNullOrEmpty(form["txtSearchName"]))
                page = 1;//搜索永远从第一页开始显示
            DataTable dt = operateContext.bllSession.A01.GetPageTableModle(form);
            //一览去掉虹膜和照片信息
            dt.Columns.Remove("A0118");
            dt.Columns.Remove("PersonPhoto");
            dt.Columns.Remove("big_iris_data");

            string strWhere = "";
            if (form["btnPersonType"] == "在职人员")
            {
                strWhere = " retire_handle_user is null ";
            }
            if (form["btnPersonType"] == "离职人员")
            {
                strWhere = " retire_handle_user > 0 ";
            }
            if (!string.IsNullOrEmpty(form["btnTeam"]) && form["btnTeam"] != "所属队伍")
            {
                if (string.IsNullOrEmpty(strWhere))
                    strWhere += " in_team='" + form["btnTeam"] + "' ";
                else
                    strWhere += " and in_team='" + form["btnTeam"] + "' ";
            }
            if (!string.IsNullOrEmpty(strWhere))
            {
                DataRow[] dr = dt.Select(strWhere);
                if (dr.Count() <= 0)
                {
                    return Content("{\"total\":" + dt.Rows.Count + ",\"rows\":[]}");
                }
                dt = dr.CopyToDataTable();
            }

            var dataPage = dt.AsEnumerable().Skip((rows * page) - rows).Take(rows);
            string returnJson = "";
            if (dataPage.Count() > 0)
                returnJson = "{\"total\":" + dt.Rows.Count + ",\"rows\":" + HCQ2_Common.JsonHelper.DataTableToJson(dataPage.CopyToDataTable()) + "}";
            else
                returnJson = "{\"total\":" + dt.Rows.Count + ",\"rows\":[]}";
            return Content(returnJson);
        }

        /// <summary>
        /// 具体新增人员的办法
        /// </summary>
        /// <param name="unit_id"></param>
        /// <returns></returns>
        public ActionResult NewPersonDetail(string RowID, string UnitID)
        {
            bll = operateContext.bllSession;
            List<HCQ2_Model.TreeModel.B01PerTreeModel> list = operateContext.bllSession.B01.GetB01PerData(operateContext.Usr.user_id);
            ViewBag.TreeJson = HCQ2_Common.JsonHelper.ObjectToJson(list).ToString();
            ViewBag.PClassID = bll.SM_CodeItems.GetCodeItemByCodeID("C");
            ViewBag.B0003 = bll.SM_CodeItems.GetCodeItemByCodeID("J");
            ViewBag.A0107 = bll.SM_CodeItems.GetCodeItemByCodeID("AX");
            ViewBag.A0108 = bll.SM_CodeItems.GetCodeItemByCodeID("JDXL");
            ViewBag.A0121 = bll.SM_CodeItems.GetCodeItemByCodeID("AE");
            ViewBag.A0114 = bll.SM_CodeItems.GetCodeItemByCodeID("AB");
            ViewBag.A0110 = bll.SM_CodeItems.GetCodeItemByCodeID("HP");
            ViewBag.A0127 = bll.SM_CodeItems.GetCodeItemByCodeID("BG");
            ViewBag.A0128 = bll.SM_CodeItems.GetCodeItemByCodeID("AT");

            //学历编辑这边的记录
            ViewBag.C0401 = bll.SM_CodeItems.GetCodeItemByCodeID("KF");

            //所在工区字典
            ViewBag.A0181 = bll.T_ItemCodeMenum.GetByItemId(bll.T_ItemCode.GetByItemCode("JobsAreaType").item_id);

            //所属队伍，从企业表获取
            ViewBag.InTeam = bll.T_CompProInfo.GetInTeamByUnitID(UnitID);

            //编辑
            string PersonEduJson = "";
            string photo = "";
            if (!string.IsNullOrEmpty(RowID))
            {
                DataTable dt = bll.A01.GetA01ItemByRowID(RowID);
                //string strSmall = dt.Rows[0]["A0118"].ToString();
                //string strBig = dt.Rows[0]["big_iris_data"].ToString();
                //byte[] sm = Convert.FromBase64String(strSmall);
                //string ww = byteToHexStr(sm);

                PersonEduJson = HCQ2_Common.JsonHelper.DataTableToJson(dt);

                string timeStr = DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Day.ToString() + DateTime.Now.Minute.ToString();
                string image = "File/ReadPhoto/" + dt.Rows[0]["A0101"];
                byte[] PersonPhoto = bll.A01.GetByRowID(RowID).PersonPhoto;
                string str = "";
                if (PersonPhoto != null)
                {
                    str = HCQ2_Common.ImageHelper.CreateImageFromBytes(HttpContext.Server.MapPath(image), dt.Rows[0]["A0101"].ToString(), PersonPhoto);
                    photo = image + "/" + str;
                }
            }
            ViewBag.photo = photo;
            ViewBag.Edu = PersonEduJson;

            //上报数据
            ViewBag.SSDWLB = bll.T_ItemCodeMenum.GetByItemId(
                bll.T_ItemCode.GetByItemCode("DWLX").item_id);
            ViewBag.SSDWZW = bll.T_ItemCodeMenum.GetByItemId(
                bll.T_ItemCode.GetByItemCode("SSDWZW").item_id);
            ViewBag.GZGZHDFS = bll.T_ItemCodeMenum.GetByItemId(
                bll.T_ItemCode.GetByItemCode("GZGZHDFS").item_id);
            ViewBag.SSBZ = bll.T_ItemCodeMenum.GetByItemId(
                bll.T_ItemCode.GetByItemCode("SSBZ").item_id);

            ViewBag.NMGZHSSYH = bll.T_ItemCodeMenum.GetByItemId(
                bll.T_ItemCode.GetByItemCode("SSYH").item_id);

            return View();
        }

        /// <summary> 
        /// 字符串转16进制字节数组 
        /// </summary> 
        /// <param name="hexString"></param> 
        /// <returns></returns> 
        private static byte[] strToToHexByte(string hexString)
        {
            hexString = hexString.Replace(" ", "");
            if ((hexString.Length % 2) != 0)
                hexString += " ";
            byte[] returnBytes = new byte[hexString.Length / 2];
            for (int i = 0; i < returnBytes.Length; i++)
                returnBytes[i] = Convert.ToByte(hexString.Substring(i * 2, 2), 16);
            return returnBytes;
        }

        /// <summary> 
        /// 字节数组转16进制字符串 
        /// </summary> 
        /// <param name="bytes"></param> 
        /// <returns></returns> 
        public static string byteToHexStr(byte[] bytes)
        {
            string returnStr = "";
            if (bytes != null)
            {
                for (int i = 0; i < bytes.Length; i++)
                {
                    returnStr += bytes[i].ToString("X2");
                }
            }
            return returnStr;
        }

        /// <summary>
        /// 上传照片
        /// </summary>
        /// <returns></returns>
        public ActionResult PersonPhoto()
        {
            string returnStr = "";
            HttpFileCollection hfc = System.Web.HttpContext.Current.Request.Files;
            if (hfc.Count > 0 && !string.IsNullOrEmpty(hfc[0].FileName))
            {
                Random r = new Random(10000000);
                string result = r.Next(10000000, 99999999).ToString();
                string timeStr = DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Day.ToString() + DateTime.Now.Minute.ToString();
                string image = "File/PersonImage/" + timeStr + "/" + result;
                if (Directory.Exists(System.Web.HttpContext.Current.Server.MapPath(image)) == false)//如果不存在就创建file文件夹
                    Directory.CreateDirectory(System.Web.HttpContext.Current.Server.MapPath(image));
                hfc[0].SaveAs(System.Web.HttpContext.Current.Server.MapPath(image + "/" + hfc[0].FileName));
                returnStr = image + "/" + hfc[0].FileName;
            }
            return Content(returnStr);
        }

        /// <summary>
        /// 上传照片
        /// </summary>
        /// <returns></returns>
        public ActionResult PersonScan()
        {
            string returnStr = "";
            HttpFileCollection hfc = System.Web.HttpContext.Current.Request.Files;
            if (hfc.Count > 0 && !string.IsNullOrEmpty(hfc[0].FileName))
            {
                string image = "~/UpFile/PersonScan/" + DateTime.Now.ToString("yyyyMMdd");
                if (Directory.Exists(System.Web.HttpContext.Current.Server.MapPath(image)) == false)//如果不存在就创建file文件夹
                    Directory.CreateDirectory(System.Web.HttpContext.Current.Server.MapPath(image));
                hfc[0].SaveAs(System.Web.HttpContext.Current.Server.MapPath(image + "/" + hfc[0].FileName));
                returnStr = image + "/" + hfc[0].FileName;
            }
            return Content(returnStr);
        }

        /// <summary>
        /// 新增人员信息
        /// </summary>
        /// <param name="form"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult InsertNewPerson(FormCollection form)
        {
            bll = operateContext.bllSession;
            string result = bll.A01.AddPerson(form);
            //if (result.Substring(0, 2) == "ok")
            //{
            //    //保存成功，则上报
            //    try
            //    {
            //        string UnitID = form["B00011"];
            //        string IndentifyCode = form["A0177"];
            //        operateContext.bllSession.A01.UpLoadPerson(UnitID, IndentifyCode);
            //        //UpDataPerson(form);
            //    }
            //    catch (Exception ex)
            //    {
            //        string error = ex.ToString();
            //    }
            //}
            return Content(result);
        }

        /// <summary>
        /// 验证是否重复注册
        /// </summary>
        /// <param name="form"></param>
        /// <returns></returns>
        public ActionResult ValidateUnitPerson(FormCollection form)
        {
            bll = operateContext.bllSession;
            string identify_code = form["A0177"];
            string unit_id = form["B00011"];
            string result = bll.A01.ValidatePerson(identify_code, unit_id) ? "ok" : "fin";
            return Content(result);
        }

        /// <summary>
        /// 删除人员信息
        /// </summary>
        /// <param name="RowID"></param>
        /// <returns></returns>
        public ActionResult DeletePerson(string RowID)
        {
            bll = operateContext.bllSession;
            string returnStr = bll.A01.Delete(o => o.RowID == RowID) > 0 ? "ok" : "find";
            return Content(returnStr);
        }

        /// <summary>
        /// 人员移动
        /// </summary>
        /// <param name="form"></param>
        /// <returns></returns>
        public ActionResult MovePerson(FormCollection form)
        {
            string strMes = "";
            string str = operateContext.bllSession.A01.MovePerson(form, ref strMes) ? "ok" : "fin";
            return Content(strMes);
        }

        /// <summary>
        /// 人员复制
        /// </summary>
        /// <param name="form"></param>
        /// <returns></returns>
        public ActionResult CopyPerson(FormCollection form)
        {
            string strMes = "";
            string str = operateContext.bllSession.A01.CpoyPerson(form, ref strMes) ? "ok" : "fin";
            return Content(strMes);
        }

        /// <summary>
        /// 办理离职手续
        /// </summary>
        /// <param name="form"></param>
        /// <returns></returns>
        public ActionResult RetirePerson(FormCollection form)
        {
            string strMes = "";
            string str = operateContext.bllSession.A01.HandleRetire(form, ref strMes) ? "ok" : "fin";
            return Content(strMes);
        }

        /// <summary>
        /// 还原已经退休的人员信息
        /// </summary>
        /// <param name="PersonID"></param>
        /// <returns></returns>
        public ActionResult ReplaseRetire(string PersonID)
        {
            string str = operateContext.bllSession.A01.HandleStaff(PersonID) ? "ok" : "fin";
            return Content(str);
        }

        /// <summary>
        /// 办理离职手续备选人员
        /// </summary>
        /// <param name="form"></param>
        /// <returns></returns>
        public ActionResult HandleRetireSoure(FormCollection form)
        {
            int page = int.Parse(form["page"]);
            int rows = int.Parse(form["rows"]);
            if (!string.IsNullOrEmpty(form["txtSearchName"]))
                page = 1;//搜索永远从第一页开始显示
            DataTable dt = operateContext.bllSession.A01.GetPageTableModle(form);
            //一览去掉虹膜和照片信息
            dt.Columns.Remove("A0118");
            dt.Columns.Remove("PersonPhoto");
            dt.Columns.Remove("big_iris_data");
            if (dt != null)
            {
                dt = dt.Select(" isnull(retire_handle_user,'')='' ").CopyToDataTable();
            }
            var dataPage = dt.AsEnumerable().Skip((rows * page) - rows).Take(rows);
            string returnJson = "";
            if (dataPage.Count() > 0)
                returnJson = "{\"total\":" + dt.Rows.Count + ",\"rows\":" + HCQ2_Common.JsonHelper.DataTableToJson(dataPage.CopyToDataTable()) + "}";
            else
                returnJson = "{\"total\":" + dt.Rows.Count + ",\"rows\":[]}";
            return Content(returnJson);
        }

        /// <summary>
        /// 获取所属队伍字典值
        /// </summary>
        /// <param name="code_id"></param>
        /// <returns></returns>
        public ActionResult GetPersonTeam(string code_id)
        {
            var data = operateContext.bllSession.T_ItemCodeMenum.GetByCodeId(Convert.ToInt32(code_id));
            return Content(data.code_name);
        }

        /// <summary>
        /// 导出Excel
        /// </summary>
        /// <returns></returns>
        public ActionResult Excel(string UnitID)
        {
            System.IO.MemoryStream ms = operateContext.bllSession.A01.GetWorkBook(UnitID);
            ms.Seek(0, SeekOrigin.Begin);
            return File(ms, "application/vnd.ms-excel", "用户信息.xls");
        }

        /// <summary>
        /// 获取所属队伍SelectBox
        /// </summary>
        /// <param name="UnitID"></param>
        /// <returns></returns>
        public ActionResult GetSelectTeamBox(string UnitID)
        {
            string unit_id = UnitID;
            List<T_CompProInfo> comList = operateContext.bllSession.T_CompProInfo.GetInTeamByUnitID(UnitID);
            return Json(comList, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 根据UnitID获取UnitName
        /// </summary>
        /// <returns></returns>
        public ActionResult GetUnitNameByUnitID(string UnitID)
        {
            var data = operateContext.bllSession.B01.GetByUnitID(UnitID);
            return Content(data.UnitName);
        }

        /// <summary>
        /// 获取虹膜信息
        /// </summary>
        /// <param name="RowID"></param>
        /// <returns></returns>
        public ActionResult GetBugIrisStr(string RowID)
        {
            string str = "";
            var data = operateContext.bllSession.A01.GetByRowID(RowID);
            string strBe = data.A0118;
            string strAf = data.big_iris_data;
            if (!string.IsNullOrEmpty(strBe))
            {
                byte[] be = Convert.FromBase64String(strBe);
                str = byteToHexStr(be);
            }
            if (!string.IsNullOrEmpty(strAf))
            {
                byte[] af = Convert.FromBase64String(strAf);
                str += byteToHexStr(af);
            }
            return Content(str);
        }

        /// <summary>
        /// 获取工种列表
        /// </summary>
        /// <param name="txtName"></param>
        /// <returns></returns>
        public ActionResult GetWorkType(string txtName)
        {
            var data = operateContext.bllSession.SM_CodeItems.GetUserWorkType(txtName);
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        #endregion

        #region 档案袋信息

        //学历学位信息

        /// <summary>
        /// 获取学位学历信息
        /// </summary>
        /// <param name="RowID"></param>
        /// <returns></returns>
        public ActionResult GetEdu(string RowID)
        {
            bll = operateContext.bllSession;
            string PersonID = bll.A01.GetByRowID(RowID).PersonID;
            return Content(HCQ2_Common.ReturnJson.GetReturnJson<A04>(bll.A04.GetCodeItemA04(bll.A04.GetByPersonID(PersonID)), 1, 9999));
        }

        /// <summary>
        /// 新增学历学位信息
        /// </summary>
        /// <param name="form"></param>
        /// <returns></returns>
        public ActionResult PersonEduAdd(FormCollection form)
        {
            bll = operateContext.bllSession;
            string returnStr = bll.A04.AddEdu(form) ? "ok" : "find";
            return Content(returnStr);
        }

        /// <summary>
        /// 删除学历学位信息
        /// </summary>
        /// <param name="RowID"></param>
        /// <returns></returns>
        public ActionResult DeletePersonEdu(string RowID)
        {
            bll = operateContext.bllSession;
            string returnStr = bll.A04.Delete(o => o.RowID == RowID) > 0 ? "ok" : "find";
            return Content(returnStr);
        }

        /// <summary>
        /// 编辑学历学位信息
        /// </summary>
        /// <param name="form"></param>
        /// <returns></returns>
        public ActionResult PersonEduEdit(FormCollection form)
        {
            bll = operateContext.bllSession;
            string returnStr = bll.A04.EditEdu(form) ? "ok" : "find";
            return Content(returnStr);
        }

        //工作经历

        /// <summary>
        /// 获取工作经历的数据源
        /// </summary>
        /// <returns></returns>
        public ActionResult GetWork(string RowID)
        {
            bll = operateContext.bllSession;
            var data = bll.A19.GetByPersonID(bll.A01.GetByRowID(RowID).PersonID);
            return Content(HCQ2_Common.ReturnJson.GetReturnJson<A19>(data, 1, 999));
        }

        /// <summary>
        /// 保存工作经历
        /// </summary>
        /// <param name="form"></param>
        /// <returns></returns>
        public ActionResult PersonWorkAdd(FormCollection form)
        {
            bll = operateContext.bllSession;
            string returnStr = bll.A19.OperWork(form) ? "ok" : "find";
            return Content(returnStr);
        }

        /// <summary>
        /// 删除工作经历
        /// </summary>
        /// <param name="RowID"></param>
        /// <returns></returns>
        public ActionResult DeletePersonWork(string RowID)
        {
            bll = operateContext.bllSession;
            string returnStr = bll.A19.Delete(o => o.RowID == RowID) > 0 ? "ok" : "find";
            return Content(returnStr);
        }

        //考勤情况

        /// <summary>
        /// 获取考勤情况信息根据人员RowID
        /// </summary>
        /// <param name="RowID"></param>
        /// <returns></returns>
        public ActionResult GetPersonAttendance(string RowID)
        {
            bll = operateContext.bllSession;
            var data = bll.A02.GetByPersonID(bll.A01.GetByRowID(RowID).PersonID);
            return Content(HCQ2_Common.ReturnJson.GetReturnJson<A02>(data, 1, 999));
        }

        /// <summary>
        /// 编辑或者删除考勤
        /// </summary>
        /// <param name="form"></param>
        /// <returns></returns>
        public ActionResult PersonAttendanceAdd(FormCollection form)
        {
            bll = operateContext.bllSession;
            string returnStr = bll.A02.OperAttendance(form) ? "ok" : "find";
            return Content(returnStr);
        }

        /// <summary>
        /// 删除考勤
        /// </summary>
        /// <param name="RowID"></param>
        /// <returns></returns>
        public ActionResult DeletePersonAttendance(string RowID)
        {
            bll = operateContext.bllSession;
            string returnStr = bll.A02.Delete(o => o.RowID == RowID) > 0 ? "ok" : "";
            return Content(returnStr);
        }


        //员工工资发放登记

        /// <summary>
        /// 员工工资发放登记数据源
        /// </summary>
        /// <param name="RowID"></param>
        /// <returns></returns>
        public ActionResult GetPersonWage(string RowID)
        {
            bll = operateContext.bllSession;
            var data = bll.A03.GetByPersonID(bll.A01.GetByRowID(RowID).PersonID);
            return Content(HCQ2_Common.ReturnJson.GetReturnJson<A03>(data, 1, 999));
        }

        /// <summary>
        /// 添加或者编辑员工工资发放登记
        /// </summary>
        /// <param name="form"></param>
        /// <returns></returns>
        public ActionResult PersonWageAdd(FormCollection form)
        {
            bll = operateContext.bllSession;
            string returnStr = bll.A03.OperWage(form) ? "ok" : "find";
            return Content(returnStr);
        }

        /// <summary>
        /// 删除员工工资发放登记
        /// </summary>
        /// <param name="RowID"></param>
        /// <returns></returns>
        public ActionResult DeletePersonWage(string RowID)
        {
            bll = operateContext.bllSession;
            string returnStr = bll.A03.Delete(o => o.RowID == RowID) > 0 ? "ok" : "find";
            return Content(returnStr);
        }

        #endregion

        #region 首页出工详情

        /// <summary>
        /// 首页出工详情
        /// </summary>
        /// <returns></returns>
        [HCQ2_Common.Attributes.Load]
        public ActionResult MainCheckUnit()
        {
            return View();
        }

        /// <summary>
        /// 首页出工详情 数据源
        /// </summary>
        /// <param name="form"></param>
        /// <returns></returns>
        public ActionResult GetMainCheckUnitSoure(FormCollection form)
        {
            string check_date = form["select_date"];
            var data = operateContext.bllSession.A01.GetMainCheckUnit(check_date);
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
        /// 人数详情
        /// </summary>
        /// <param name="UnitID"></param>
        /// <returns></returns>
        [HCQ2_Common.Attributes.Load]
        public ActionResult MainCheckUnitPerson(string UnitID)
        {
            return View();
        }

        public ActionResult GetMainCheckPerosn(FormCollection form)
        {
            string UnitID = form["UnitID"];
            string checkDate = form["checkDate"];
            var data = operateContext.bllSession.A01.GetMainCheckPerson(UnitID, checkDate);
            List<HCQ2_Model.ViewModel.CheckModle> list = operateContext.bllSession.View_A02.GetCheckCount(data);
            int rows = int.Parse(form["rows"]);
            int page = int.Parse(form["page"]);
            if (!string.IsNullOrEmpty(form["personName"]))
            {
                string personName = form["personName"];
                list = list.Where(o => o.A0101.Contains(personName)).ToList();
            }
            var viewData = list.Skip((rows * page) - rows).Take(rows);
            TableModel modle = new TableModel
            {
                rows = viewData,
                total = list.Count
            };
            return Json(modle, JsonRequestBehavior.AllowGet);
        }

        #endregion

        #region  查看图片

        /// <summary>
        /// 查看图片
        /// </summary>
        /// <returns></returns>
        public ActionResult LookPri(string url)
        {
            ViewBag.url = url;
            return View();
        }

        #endregion
    }

    public class monthDay
    {
        public object month { get; set; }
        public object day { get; set; }
    }


}
