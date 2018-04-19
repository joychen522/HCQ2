using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Net;
using System.IO;
using System.Data;
using HCQ2UI_Logic.ServiceReference1;
using HCQ2_Model;
using System.Xml;
using HCQ2_Model.ViewModel;
using Newtonsoft.Json.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Net.Security;
using HCQ2_Model.UpData;

namespace HCQ2UI_Logic
{
    /// <summary>
    /// 数据上报
    /// </summary>
    public class UpReportController : BaseLogic
    {
        #region 数据上报

        private static string xxly = HCQ2_Common.UpDataLoad.GetRealXxly;

        /// <summary>
        /// 数据上报
        /// </summary>
        /// <returns></returns>
        [HCQ2_Common.Attributes.Load]
        public ActionResult Index()
        {
            int user_id = operateContext.Usr.user_id;
            List<T_CompProInfo> comList = operateContext.bllSession.T_CompProInfo.GetPerCompanyByUserID(user_id);
            ViewBag.TreeJson = HCQ2_Common.JsonHelper.objectToJsonStr(
                operateContext.bllSession.T_CompProInfo.GetComTreeModle(comList));
            ViewBag.UpDate = operateContext.bllSession.T_ItemCodeMenum.GetByItemId(
                operateContext.bllSession.T_ItemCode.GetByItemCode("UpData").item_id);
            ViewBag.ComName = HCQ2_Common.JsonHelper.objectToJsonStr(operateContext.bllSession.T_CompProInfo.GetComPro().Where(o => o.QXLB == "01").ToList());
            return View();
        }

        /// <summary>
        /// 上报测试数据库
        /// </summary>
        /// <param name="form"></param>
        /// <returns></returns>
        public ActionResult UpLoad(FormCollection form)
        {
            string upType = form["upType"];

            string serviceName = "";
            string methodName = "";

            List<string> reComList = new List<string>();
            List<string> reProjectList = new List<string>();
            List<string> xmlList = operateContext.bllSession.A01.UpLoadData(form, ref reComList, ref reProjectList, "test");

            switch (upType)
            {
                case "01":
                    serviceName = "HSMWService";
                    methodName = "UploadCompProInfo";
                    break;
                case "02":
                    serviceName = "HSMWService";
                    methodName = "UploadProPerInfo";
                    break;
                case "03":
                    serviceName = "HSMWService";
                    methodName = "UploadProPhotoInfo";
                    break;
                case "04":
                    serviceName = "HSMWService";
                    methodName = "UploadProAttendInfo";
                    break;
                case "05":
                    serviceName = "HSMWService";
                    methodName = "UploadProSalaryInfo";
                    break;
                case "06":
                    serviceName = "HSMWService";
                    methodName = "UploadProBackPayInfo";
                    break;
                case "07":
                    serviceName = "HSMWService";
                    methodName = "UploadProBackPayForPerInfo";
                    break;
                case "08":
                    serviceName = "HSMWService";
                    methodName = "UploadProFileInfo";
                    break;
                case "09":
                    serviceName = "HSMWService";
                    methodName = "UploadPayrollAccountInfo";
                    break;
                default:
                    break;
            }

            List<PortErrorMess> errorList = new List<PortErrorMess>();
            uddiPortTypeClient client = new uddiPortTypeClient();
            if (xmlList.Count() > 0)
            {
                for (int i = 0; i < xmlList.Count(); i++)
                {
                    string strXml = xmlList[i];
                    PortErrorMess error = new PortErrorMess();
                    error.comName = reComList[i];
                    error.projectName = reProjectList[i];
                    string mess = client.invokeService(serviceName, methodName, strXml);
                    if (mess.Contains("服务调用成功！"))
                    {
                        if (upType == "01")
                            operateContext.bllSession.B01.ChangeUnitUpLoad(reProjectList[i], upType);
                        error.mess = "成功！";
                    }
                    else if (mess.Contains("解析XML出错"))
                    {
                        error.mess = "解析失败！请检查上报档案信息特殊符号。";
                        ErrorMess(mess, error.comName);
                        ErrorMess(xmlList[i], error.comName + "File");
                    }
                    else
                    {
                        error.mess = "失败！";
                        ErrorMess(mess, error.comName);
                        ErrorMess(xmlList[i], error.comName + "File");
                        error.errorMsg = GetErrorDataMsg(mess);
                    }

                    errorList.Add(error);
                }
            }
            return Json(errorList, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 上报正式数据库
        /// </summary>
        /// <param name="form"></param>
        /// <returns></returns>
        public ActionResult UpLoadForm(FormCollection form)
        {
            string upType = form["upType"];

            string serviceName = "";
            string methodName = "";

            List<string> reComList = new List<string>();
            List<string> reProjectList = new List<string>();
            List<string> xmlList = operateContext.bllSession.A01.UpLoadData(form, ref reComList, ref reProjectList, "1");

            switch (upType)
            {
                case "01":
                    serviceName = "HSMWService";
                    methodName = "UploadCompProInfo";
                    break;
                case "02":
                    serviceName = "HSMWService";
                    methodName = "UploadProPerInfo";
                    break;
                case "03":
                    serviceName = "HSMWService";
                    methodName = "UploadProPhotoInfo";
                    break;
                case "04":
                    serviceName = "HSMWService";
                    methodName = "UploadProAttendInfo";
                    break;
                case "05":
                    serviceName = "HSMWService";
                    methodName = "UploadProSalaryInfo";
                    break;
                case "06":
                    serviceName = "HSMWService";
                    methodName = "UploadProBackPayInfo";
                    break;
                case "07":
                    serviceName = "HSMWService";
                    methodName = "UploadProBackPayForPerInfo";
                    break;
                case "08":
                    serviceName = "HSMWService";
                    methodName = "UploadProFileInfo";
                    break;
                case "09":
                    serviceName = "HSMWService";
                    methodName = "UploadPayrollAccountInfo";
                    break;
                default:
                    break;
            }
            List<PortErrorMess> errorList = new List<PortErrorMess>();
            ServiceUpReport.uddiPortTypeClient client2 = new ServiceUpReport.uddiPortTypeClient();

            WebDataUpLoad.uddi client = GetClient();

            if (xmlList.Count() > 0)
            {
                string mess = "";
                for (int i = 0; i < xmlList.Count(); i++)
                {
                    string strXml = xmlList[i];
                    PortErrorMess error = new PortErrorMess();
                    error.comName = reComList[i];
                    error.projectName = reProjectList[i];
                    mess = client.invokeService(serviceName, methodName, strXml);
                    if (mess.Contains("服务调用成功！"))
                    {
                        if (upType == "01")
                            operateContext.bllSession.B01.ChangeUnitUpLoad(reProjectList[i], upType);

                        error.mess = "成功！";
                    }
                    else if (mess.Contains("解析XML出错"))
                    {
                        error.mess = "解析失败！请检查上报档案信息特殊符号。";
                        ErrorMess(mess, error.comName);
                        ErrorMess(xmlList[i], error.comName + "File");
                    }
                    else
                    {
                        error.mess = "失败！";
                        ErrorMess(mess, error.comName);
                        ErrorMess(xmlList[i], error.comName + "File");
                        error.errorMsg = GetErrorDataMsg(mess);
                    }

                    errorList.Add(error);
                }
            }
            return Json(errorList, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 人员信息、照片、合同上报
        /// </summary>
        /// <param name="form"></param>
        /// <returns></returns>
        public ActionResult UpLoadPersonSoure(FormCollection form)
        {
            string upType = form["upType"];
            string unitID = form["unitID"];
            string type = form["type"];
            string dateSelect = form["dateSelect"];

            if (string.IsNullOrEmpty(unitID))
            {
                unitID = operateContext.bllSession.B01.GetB01PerData(operateContext.Usr.user_id)[0].UnitID;
            }

            string serviceName = "";
            string methodName = "";

            List<string> reComList = new List<string>();
            List<string> reProjectList = new List<string>();

            List<A01> userList = new List<A01>();
            List<string> xmlList = operateContext.bllSession.A01.UpLoadDataFormPerson(form, ref reComList, ref reProjectList, type, ref userList, unitID);

            switch (upType)
            {
                case "02":
                    serviceName = "HSMWService";
                    methodName = "UploadProPerInfo";
                    break;
                case "03":
                    serviceName = "HSMWService";
                    methodName = "UploadProPhotoInfo";
                    break;
                case "04":
                    serviceName = "HSMWService";
                    methodName = "UploadProAttendInfo";
                    break;
                case "08":
                    serviceName = "HSMWService";
                    methodName = "UploadProFileInfo";
                    break;
                default:
                    break;
            }
            List<PortErrorMess> errorList = new List<PortErrorMess>();

            //测试地址
            uddiPortTypeClient client = new uddiPortTypeClient();
            //正式地址
            WebDataUpLoad.uddi client2 = GetClient(); ;

            if (xmlList.Count() > 0)
            {
                string mess = "";
                for (int i = 0; i < xmlList.Count(); i++)
                {
                    string strXml = xmlList[i];
                    PortErrorMess error = new PortErrorMess();
                    error.comName = reComList[i];
                    error.projectName = reProjectList[i];
                    if (type == "test")
                        mess = client.invokeService(serviceName, methodName, strXml);
                    else
                        mess = client2.invokeService(serviceName, methodName, strXml);
                    if (mess.Contains("服务调用成功！"))
                    {
                        operateContext.bllSession.A01.ChangePersonUpLoad(userList, upType);
                        error.mess = "成功！";
                    }
                    else if (mess.Contains("解析XML出错"))
                    {
                        error.mess = "解析失败！请检查上报档案信息特殊符号。";
                        ErrorMess(mess, error.comName);
                        ErrorMess(xmlList[i], error.comName + "File");
                    }
                    else
                    {
                        error.mess = "失败！";
                        ErrorMess(mess, error.comName);
                        ErrorMess(xmlList[i], error.comName + "File");
                        error.errorMsg = GetErrorDataMsg(mess);
                    }

                    errorList.Add(error);
                }
            }
            return Json(errorList, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 错误信息写入后台管理
        /// </summary>
        /// <param name="text"></param>
        /// <param name="comName"></param>
        private void ErrorMess(string text, string comName)
        {
            string path = "~/UpFile/UpLoadError/" + DateTime.Now.Year + "/" + DateTime.Now.Month + "/" + DateTime.Now.Day;
            string fileName = comName + DateTime.Now.ToString("yyyyMMddHHmmss") + ".txt";
            HCQ2_Common.FileHelper.CreateFile(path, fileName, text);
        }

        /// <summary>
        /// 获取报错信息
        /// </summary>
        /// <returns></returns>
        private string GetErrorDataMsg(string errorMsg)
        {
            string strError = "";

            XmlDocument doc = new XmlDocument();
            doc.LoadXml(errorMsg);
            XmlNode xNode = doc.SelectSingleNode("/p/d");

            StringBuilder sbParam = new StringBuilder();
            //组件一个新的xml字符串
            sbParam.AppendFormat("<?xml version=\"1.0\" encoding=\"GBK\"?>");
            sbParam.AppendFormat("<p>");
            sbParam.AppendFormat(xNode.InnerXml.ToString().Replace("/>", ">{0}</r>"), 123);
            sbParam.AppendFormat("</p>");

            XmlDocument xDoc = new XmlDocument();
            xDoc.LoadXml(sbParam.ToString());
            XmlNodeList parentNode = xDoc.SelectSingleNode("/p").ChildNodes;

            for (int i = 0; i < parentNode.Count; i++)
            {
                strError += "<br />" + parentNode[i].Attributes["colerr"].Value;
            }

            return strError;
        }

        /// <summary>
        /// 人员基本信息、照片、附件（合同）上报
        /// </summary>
        /// <returns></returns>
        [HCQ2_Common.Attributes.Load]
        public ActionResult UpLoadPerson()
        {
            return View();
        }

        #endregion

        #region 企业项目信息上报查询

        /// <summary>
        /// 企业信息上报数据查询
        /// </summary>
        /// <returns></returns>
        [HCQ2_Common.Attributes.Load]
        public ActionResult UpCompanyQuery()
        {
            return View();
        }

        /// <summary>
        /// 企业信息上报获取数据源
        /// </summary>
        /// <param name="form"></param>
        /// <returns></returns>
        public ActionResult GetUpCompanySoure(FormCollection form)
        {
            //xxly = "JvHZhv4X3trzG+kzFom8+US5tBs91mq38cv1piRTimR9e/L7j719YhIQ6ttRyO7xt7ljLmpL1Z6+K0vG1V3sZea4/KVyltRQhVRkW9aZb+DW/iMUdjtqQKhkbBIUZgQ2wkqgB7vYd+pGkiwFSPZN7HcE4P96FMpLI6pHAZWsLcA=";

            string service = "";
            string method = "";
            GetServcieMethod("01", ref service, ref method);

            //uddiPortTypeClient client = new uddiPortTypeClient();

            WebDataUpLoad.uddi client = GetClient();

            string param = "<?xml version=\"1.0\" encoding=\"GBK\"?><p>";
            param += "<s dwbh=\"\" />";

            if (!string.IsNullOrEmpty(form["dwmc"]))
                param += "<s dwmc=\"" + form["dwmc"] + "\" />";
            else
                param += "<s dwmc=\"\" />";

            param += "<s xxly=\"" + xxly + "\" />";
            param += "</p>";
            string result = client.invokeService(service, method, param);
            SaveCompanyQueryResult(result);

            XmlDocument doc = new XmlDocument();
            doc.LoadXml(result);
            XmlNode xNode = doc.SelectSingleNode("/p/s");

            StringBuilder sbParam = new StringBuilder();
            //组件一个新的xml字符串
            sbParam.AppendFormat("<?xml version=\"1.0\" encoding=\"GBK\"?>");
            sbParam.AppendFormat("<p>");
            //获取此次查询结果
            var company = xNode.NextSibling.NextSibling.NextSibling.NextSibling.ChildNodes;
            for (int i = 0; i < company.Count; i++)
            {
                //循环获得每一个查询出来的上报信息
                sbParam.AppendFormat(company[i].OuterXml.Replace("/>", ">{0}</r>"), i);
            }
            sbParam.AppendFormat("</p>");

            XmlDocument xDoc = new XmlDocument();
            xDoc.LoadXml(sbParam.ToString());
            XmlNodeList parentNode = xDoc.SelectSingleNode("/p").ChildNodes;

            List<string> strList = GetCumList();
            JArray jArr = new JArray();

            foreach (XmlNode item in parentNode)
            {
                jArr.Add(GetJsonStr(item, strList));
            }

            JArray viewJa = new JArray();
            int user_id = operateContext.Usr.user_id;
            List<B01> unitList = operateContext.bllSession.B01.GetPerUnitByUserID(user_id);
            string strUnit = string.Join(",", unitList.Select(o => o.UnitName));
            foreach (var item in jArr)
            {
                string UnitName = JObject.Parse(item.ToString())["xmmc"].ToString();
                if (strUnit.Contains(UnitName)) {
                    viewJa.Add(item);
                }
            }

            string returnJson = "{\"total\":" + parentNode.Count + ",\"rows\":" + GetPaddingSoure(form, viewJa).ToString() + "}";
            return Content(returnJson);
        }

        /// <summary>
        /// 从XML节点获取json字符串
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        public JObject GetJsonStr(XmlNode node, List<string> strList)
        {
            JObject result = new JObject();
            string value = "";
            for (int i = 0; i < strList.Count(); i++)
            {
                value = node.Attributes[strList[i]].Value;
                if (value == "`k")
                    value = "";
                result.Add(strList[i], value);
            }
            return result;
        }

        /// <summary>
        /// 企业项目上报获取需要处理字段的集合
        /// </summary>
        /// <returns></returns>
        public List<string> GetCumList()
        {
            List<string> strList = new List<string>();
            #region 字符串处理
            strList.Add("lsgx");
            strList.Add("lzfzrdh");
            strList.Add("xmbzjycje");
            strList.Add("zzjgdm");
            strList.Add("xmjhjgrq");
            strList.Add("fbr");
            strList.Add("gszzhm");
            strList.Add("sbsj");
            strList.Add("xmjhzgq");
            strList.Add("fxrq");
            strList.Add("sshy");
            strList.Add("zczb");
            strList.Add("dwlx");
            strList.Add("dwfzrxm");
            strList.Add("qyhtj");
            strList.Add("fddbrdh");
            strList.Add("bgdz");
            strList.Add("jjlx");
            strList.Add("dwmc");
            strList.Add("lzzgy");
            strList.Add("cbr");
            strList.Add("xmmc");
            strList.Add("fddbrxm");
            strList.Add("djzclx");
            strList.Add("ssxzzgbm");
            strList.Add("jyfs");
            strList.Add("gcdd");
            strList.Add("zcdz");
            strList.Add("lxr");
            strList.Add("lzfzr");
            strList.Add("fddbrsfzhm");
            strList.Add("lxdh");
            strList.Add("xmhtqdrq");
            strList.Add("dwid");
            strList.Add("xmjhkgrq");
            strList.Add("tyshxydm");
            strList.Add("dwfzrdh");
            #endregion
            return strList;
        }

        /// <summary>
        /// 将获取到的XML数据存入XML文件
        /// </summary>
        /// <param name="strXml"></param>
        private void SaveCompanyQueryResult(string strXml)
        {
            string strPath = "~/UpFile/UpLoadCompanyQuery/" + DateTime.Now.Year + "/" + DateTime.Now.Month + "/" + DateTime.Now.Day;
            string fileName = DateTime.Now.ToString("HHmmss") + ".txt";
            HCQ2_Common.FileHelper.CreateFile(strPath, fileName, strXml);
        }

        #endregion

        #region 人员信息上报查询

        /// <summary>
        /// 人员上报信息查询
        /// </summary>
        /// <returns></returns>
        [HCQ2_Common.Attributes.Load]
        public ActionResult UpPersonQuery()
        {
            List<HCQ2_Model.TreeModel.B01PerTreeModel> list = operateContext.bllSession.B01.GetB01PerData(operateContext.Usr.user_id);
            ViewBag.TreeJson = HCQ2_Common.JsonHelper.ObjectToJson(list).ToString();
            return View();
        }

        /// <summary>
        /// 人员上报信息数据源获取
        /// </summary>
        /// <param name="form"></param>
        /// <returns></returns>
        public ActionResult GetUpPersonQuerySoure(FormCollection form)
        {
            string unit_id = form["unitId"];
            string unit_name = form["unitName"];
            if (string.IsNullOrEmpty(unit_id))
            {
                int user_id = HCQ2UI_Helper.OperateContext.Current.Usr.user_id;
                var unit = operateContext.bllSession.B01.GetB01PerData(user_id)[0];
                unit_id = unit.UnitID;
                unit_name = unit.UnitName;
            }
            string service = "";
            string method = "";
            GetServcieMethod("02", ref service, ref method);
            WebDataUpLoad.uddi client = GetClient();
            //uddiPortTypeClient client = new uddiPortTypeClient();
            string param = "<?xml version=\"1.0\" encoding=\"GBK\"?><p>";
            param += "<s xmbh=\"" + unit_id + "\" />";
            param += "<s xmmc=\"" + unit_name + "\" />";
            param += "<s ryid=\"\" />";
            if (!string.IsNullOrEmpty(form["personName"]))
                param += "<s xm=\"" + form["personName"] + "\" />";
            else
                param += "<s xm=\"\" />";
            param += "<s sfzhm=\"\" />";
            param += "<s xxly=\"" + xxly + "\" />";
            param += "</p>";
            string result = client.invokeService(service, method, param);
            SaveCompanyQueryResult(result);

            XmlDocument doc = new XmlDocument();
            doc.LoadXml(result);
            XmlNode xNode = doc.SelectSingleNode("/p/s");

            StringBuilder sbParam = new StringBuilder();
            //组件一个新的xml字符串
            sbParam.AppendFormat("<?xml version=\"1.0\" encoding=\"GBK\"?>");
            sbParam.AppendFormat("<p>");
            //获取此次查询结果
            var company = xNode.NextSibling.NextSibling.NextSibling.NextSibling.ChildNodes;
            for (int i = 0; i < company.Count; i++)
            {
                //循环获得每一个查询出来的上报信息
                sbParam.AppendFormat(company[i].OuterXml.Replace("/>", ">{0}</r>"), i);
            }
            sbParam.AppendFormat("</p>");

            XmlDocument xDoc = new XmlDocument();
            xDoc.LoadXml(sbParam.ToString());
            XmlNodeList parentNode = xDoc.SelectSingleNode("/p").ChildNodes;

            List<string> strList = GetPersonQuery();
            JArray jArr = new JArray();

            foreach (XmlNode item in parentNode)
            {
                jArr.Add(GetJsonStr(item, strList));
            }

            string returnJson = "{\"total\":" + parentNode.Count + ",\"rows\":" + GetPaddingSoure(form,jArr).ToString() + "}";
            return Content(returnJson);
        }

        public JObject GetPersonQuery(XmlNode node, List<string> list)
        {
            JObject result = new JObject();

            string value = "";
            for (int i = 0; i < list.Count(); i++)
            {
                value = node.Attributes[list[i]].Value;
                if (value == "`k")
                    value = "";
                result.Add(list[i], value);
            }

            return result;
        }

        /// <summary>
        /// 保存人员上报查询返回的XML字符串
        /// </summary>
        /// <param name="result"></param>
        private void SavePersonQuery(string result)
        {
            string strPath = "~/UpFile/UpPersonQuery/" + DateTime.Now.Year + "/" + DateTime.Now.Month + "/" + DateTime.Now.Day;
            string fileName = DateTime.Now.ToString("HHmmss") + ".txt";
            HCQ2_Common.FileHelper.CreateFile(strPath, fileName, result);
        }

        /// <summary>
        /// 人员信息查询需要的字段
        /// </summary>
        /// <returns></returns>
        private List<string> GetPersonQuery()
        {
            List<string> list = new List<string>();
            list.Add("sfzhm");
            list.Add("ssbz");
            list.Add("gz");
            list.Add("xm");
            list.Add("gzgzhdbz");
            list.Add("sfbzfzr");
            list.Add("sbsj");
            list.Add("ssdwzw");
            list.Add("jkzk");
            list.Add("xmbh");
            list.Add("ryid");
            list.Add("xb");
            list.Add("gzgzhdfs");
            list.Add("ssdwlb");
            list.Add("sfqdjyyght");
            list.Add("ssdwmc");
            list.Add("nl");
            return list;
        }

        #endregion

        #region 考勤上报查询

        [HCQ2_Common.Attributes.Load]
        public ActionResult UpCheckQuery()
        {
            List<HCQ2_Model.TreeModel.B01PerTreeModel> list = operateContext.bllSession.B01.GetB01PerData(operateContext.Usr.user_id);
            ViewBag.TreeJson = HCQ2_Common.JsonHelper.ObjectToJson(list).ToString();
            return View();
        }

        /// <summary>
        /// 获取数据源
        /// </summary>
        /// <param name="form"></param>
        /// <returns></returns>
        public ActionResult GetUpCheckSoure(FormCollection form)
        {
            string unit_id = form["unitId"];
            string unit_name = form["unitName"];
            if (string.IsNullOrEmpty(unit_id))
            {
                int user_id = HCQ2UI_Helper.OperateContext.Current.Usr.user_id;
                var unit = operateContext.bllSession.B01.GetB01PerData(user_id)[0];
                unit_id = unit.UnitID;
                unit_name = unit.UnitName;
            }

            string service = "";
            string method = "";
            GetServcieMethod("08", ref service, ref method);
            //uddiPortTypeClient client = new uddiPortTypeClient();
            WebDataUpLoad.uddi client = GetClient();
            string param = "<?xml version=\"1.0\" encoding=\"GBK\"?><p>";
            param += "<s xmbh=\"" + unit_id + "\" />";
            param += "<s xmmc=\"" + unit_name + "\" />";
            param += "<s ryid=\"\" />";
            if (!string.IsNullOrEmpty(form["personName"]))
                param += "<s xm=\"" + form["personName"] + "\" />";
            else
                param += "<s xm=\"\" />";
            param += "<s sfzhm=\"\" />";
            param += "<s xxly=\"" + xxly + "\" />";
            param += "</p>";
            string result = client.invokeService(service, method, param);

            XmlDocument doc = new XmlDocument();
            doc.LoadXml(result);
            XmlNode xNode = doc.SelectSingleNode("/p/s");

            StringBuilder sbParam = new StringBuilder();
            //组件一个新的xml字符串
            sbParam.AppendFormat("<?xml version=\"1.0\" encoding=\"GBK\"?>");
            sbParam.AppendFormat("<p>");
            //获取此次查询结果
            var company = xNode.NextSibling.NextSibling.NextSibling.NextSibling.ChildNodes;
            for (int i = 0; i < company.Count; i++)
            {
                //循环获得每一个查询出来的上报信息
                sbParam.AppendFormat(company[i].OuterXml.Replace("/>", ">{0}</r>"), i);
            }
            sbParam.AppendFormat("</p>");

            XmlDocument xDoc = new XmlDocument();
            xDoc.LoadXml(sbParam.ToString());
            XmlNodeList parentNode = xDoc.SelectSingleNode("/p").ChildNodes;

            List<string> strList = GetCheckList();
            JArray jArr = new JArray();

            foreach (XmlNode item in parentNode)
            {
                jArr.Add(GetCheckQueryJobject(item, strList));
            }

            string returnJson = "{\"total\":" + parentNode.Count + ",\"rows\":" + GetPaddingSoure(form, jArr).ToString() + "}";
            return Content(returnJson);
        }

        public JObject GetCheckQueryJobject(XmlNode node, List<string> list)
        {
            JObject result = new JObject();

            string value = "";
            for (int i = 0; i < list.Count(); i++)
            {
                value = node.Attributes[list[i]].Value;
                if (value == "`k")
                    value = "";
                result.Add(list[i], value);
            }

            return result;
        }

        private List<string> GetCheckList()
        {
            List<string> list = new List<string>();

            list.Add("kqid");
            list.Add("sbbs");
            list.Add("xm");
            list.Add("kqsj");
            list.Add("xmbh");
            list.Add("sfzh");
            list.Add("ryid");
            list.Add("kqsbbm");
            list.Add("kqtz");
            list.Add("sbsj");

            return list;
        }

        #endregion

        #region 工资发放上报查询

        /// <summary>
        /// 工资发放上报查询
        /// </summary>
        /// <returns></returns>
        [HCQ2_Common.Attributes.Load]
        public ActionResult UploadWage()
        {
            List<HCQ2_Model.TreeModel.B01PerTreeModel> list = operateContext.bllSession.B01.GetB01PerData(operateContext.Usr.user_id);
            ViewBag.TreeJson = HCQ2_Common.JsonHelper.ObjectToJson(list).ToString();
            return View();
        }

        /// <summary>
        /// 工资发放上报查询
        /// </summary>
        /// <param name="form"></param>
        /// <returns></returns>
        public ActionResult GetUploadWageSoure(FormCollection form)
        {
            string service = "";
            string method = "";
            GetServcieMethod("04", ref service, ref method);
            WebDataUpLoad.uddi client = GetClient();
            //uddiPortTypeClient client = new uddiPortTypeClient();
            string param = "<?xml version=\"1.0\" encoding=\"GBK\"?><p>";
            param += "<s xmbh=\"\" />";
            param += "<s xmmc=\"\" />";
            param += "<s xxly=\"" + xxly + "\" />";
            param += "</p>";
            string result = client.invokeService(service, method, param);

            XmlDocument doc = new XmlDocument();
            doc.LoadXml(result);
            XmlNode xNode = doc.SelectSingleNode("/p/s");

            StringBuilder sbParam = new StringBuilder();
            //组件一个新的xml字符串
            sbParam.AppendFormat("<?xml version=\"1.0\" encoding=\"GBK\"?>");
            sbParam.AppendFormat("<p>");
            //获取此次查询结果
            var company = xNode.NextSibling.NextSibling.NextSibling.NextSibling.ChildNodes;
            for (int i = 0; i < company.Count; i++)
            {
                //循环获得每一个查询出来的上报信息
                sbParam.AppendFormat(company[i].OuterXml.Replace("/>", ">{0}</r>"), i);
            }
            sbParam.AppendFormat("</p>");

            XmlDocument xDoc = new XmlDocument();
            xDoc.LoadXml(sbParam.ToString());
            XmlNodeList parentNode = xDoc.SelectSingleNode("/p").ChildNodes;

            List<string> strList = GetUploadWageList();
            JArray jArr = new JArray();

            foreach (XmlNode item in parentNode)
            {
                jArr.Add(GetCheckQueryJobject(item, strList));
            }

            string returnJson = "{\"total\":" + parentNode.Count + ",\"rows\":" + GetPaddingSoure(form, jArr).ToString() + "}";
            return Content(returnJson);
        }

        private List<string> GetUploadWageList()
        {
            List<string> list = new List<string>();

            list.Add("gzffid");
            list.Add("yfgz");
            list.Add("nmgzhzh");
            list.Add("sm");
            list.Add("wgf");
            list.Add("sfgz");
            list.Add("xm");
            list.Add("jsl");
            list.Add("sfzh");
            list.Add("ffzq");
            list.Add("gzffzhssyh");
            list.Add("sbsj");
            list.Add("nmgzhssyh");
            list.Add("ffrq");
            list.Add("xmbh");
            return list;
        }

        #endregion

        #region 欠薪上报查询

        /// <summary>
        /// 欠薪上报查询
        /// </summary>
        /// <returns></returns>
        [HCQ2_Common.Attributes.Load]
        public ActionResult UploadDeWage()
        {
            return View();
        }

        /// <summary>
        /// 欠薪上报查询
        /// </summary>
        /// <param name="form"></param>
        /// <returns></returns>
        public ActionResult GetUploadDeWageSoure(FormCollection form)
        {
            string service = "";
            string method = "";
            GetServcieMethod("05", ref service, ref method);
            //uddiPortTypeClient client = new uddiPortTypeClient();
            WebDataUpLoad.uddi client = GetClient();
            string param = "<?xml version=\"1.0\" encoding=\"GBK\"?><p>";
            param += "<s xmbh=\"\" />";
            if (!string.IsNullOrEmpty(form["xmmc"]))
                param += "<s xmmc=\"" + form["xmmc"] + "\" />";
            else
                param += "<s xmmc=\"\" />";
            param += "<s xxly=\"" + xxly + "\" />";
            param += "</p>";
            string result = client.invokeService(service, method, param);

            XmlDocument doc = new XmlDocument();
            doc.LoadXml(result);
            XmlNode xNode = doc.SelectSingleNode("/p/s");

            StringBuilder sbParam = new StringBuilder();
            //组件一个新的xml字符串
            sbParam.AppendFormat("<?xml version=\"1.0\" encoding=\"GBK\"?>");
            sbParam.AppendFormat("<p>");
            //获取此次查询结果
            var company = xNode.NextSibling.NextSibling.NextSibling.NextSibling.ChildNodes;
            for (int i = 0; i < company.Count; i++)
            {
                //循环获得每一个查询出来的上报信息
                sbParam.AppendFormat(company[i].OuterXml.Replace("/>", ">{0}</r>"), i);
            }
            sbParam.AppendFormat("</p>");

            XmlDocument xDoc = new XmlDocument();
            xDoc.LoadXml(sbParam.ToString());
            XmlNodeList parentNode = xDoc.SelectSingleNode("/p").ChildNodes;

            List<string> strList = GetUploadDeWageList();
            JArray jArr = new JArray();

            foreach (XmlNode item in parentNode)
            {
                jArr.Add(GetCheckQueryJobject(item, strList));
            }

            string returnJson = "{\"total\":" + parentNode.Count + ",\"rows\":" + GetPaddingSoure(form, jArr).ToString() + "}";
            return Content(returnJson);
        }

        private List<string> GetUploadDeWageList()
        {
            List<string> list = new List<string>();

            list.Add("qxzje");
            list.Add("ldzrs");
            list.Add("bz");
            list.Add("qsny");
            list.Add("sbsj");
            list.Add("dysqxrs");
            list.Add("dwlx");
            list.Add("xmfrspsm");
            list.Add("xjspyj");
            list.Add("xjspsm");
            list.Add("dwmc");
            list.Add("qxid");
            list.Add("qxzrs");
            list.Add("sjspsm");
            list.Add("xmmc");
            list.Add("zzny");
            list.Add("zrld");
            list.Add("djrq");
            list.Add("yhid");
            list.Add("xmfrsprq");
            list.Add("qyfzrxm");
            list.Add("xmdz");
            list.Add("lxdh");
            list.Add("jgbmzrr");
            list.Add("xmbh");
            list.Add("sjspyj");
            list.Add("xmfrspyj");
            list.Add("qxlb");
            list.Add("dwid");
            list.Add("dysqxje");

            return list;
        }

        #endregion

        #region 异常考勤上报

        /// <summary>
        /// 异常考情信息上报
        /// </summary>
        /// <returns></returns>
        [HCQ2_Common.Attributes.Load]
        public ActionResult UpAttendExcption()
        {
            return View();
        }

        public ActionResult GetUpAttendExcption(FormCollection form)
        {
            TableModel model = new TableModel();
            model = operateContext.bllSession.View_A02.GetExcptionUpSoure(form);
            return Json(model, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 上报异常考勤
        /// </summary>
        /// <param name="form"></param>
        /// <returns></returns>
        public ActionResult UpLoadExcptionAttend(FormCollection form)
        {
            bool result = operateContext.bllSession.View_A02.UpLoadExcptionAttend(form);
            string str = result ? "ok" : "find";
            return Content(str);
        }

        /// <summary>
        /// 异常考勤上报
        /// </summary>
        /// <param name="upType"></param>
        /// <returns></returns>
        public ActionResult UpLoadAttend(string upType)
        {
            var data = operateContext.bllSession.B01.GetUnitDataByPermiss(HCQ2UI_Helper.OperateContext.Current.Usr.user_id);
            string strUnit = "'" + string.Join("','", data.Select(o => o.UnitID)) + "'";
            string result = operateContext.bllSession.View_A02.UpAttends(strUnit);
            return Content(result);
        }

        #endregion

        /// <summary>
        /// 获取人员上报的照片
        /// </summary>
        /// <param name="RowID"></param>
        /// <returns></returns>
        public ActionResult GetPersonPhoto(string RowID)
        {
            string service = "";
            string method = "";
            GetServcieMethod("03", ref service, ref method);
            //uddiPortTypeClient client = new uddiPortTypeClient();
            WebDataUpLoad.uddi client = GetClient();
            string param = "<?xml version=\"1.0\" encoding=\"GBK\"?><p>";
            param += "<s ryid=\"" + RowID + "\" />";
            param += "<s xm=\"\" />";
            param += "<s xxly=\"" + xxly + "\" />";
            param += "</p>";
            string result = client.invokeService(service, method, param);

            XmlDocument doc = new XmlDocument();
            doc.LoadXml(result);
            XmlNode xNode = doc.SelectSingleNode("/p/s");

            StringBuilder sbParam = new StringBuilder();
            //组件一个新的xml字符串
            sbParam.AppendFormat("<?xml version=\"1.0\" encoding=\"GBK\"?>");
            sbParam.AppendFormat("<p>");
            //获取此次查询结果
            var company = xNode.NextSibling.NextSibling.NextSibling.NextSibling.ChildNodes;
            for (int i = 0; i < company.Count; i++)
            {
                //循环获得每一个查询出来的上报信息
                sbParam.AppendFormat(company[i].OuterXml.Replace("/>", ">{0}</r>"), i);
            }
            sbParam.AppendFormat("</p>");

            XmlDocument xDoc = new XmlDocument();
            xDoc.LoadXml(sbParam.ToString());
            XmlNodeList parentNode = xDoc.SelectSingleNode("/p").ChildNodes;

            string photo = parentNode[0].Attributes["zp"].Value;
            return Content(photo);
        }

        /// <summary>
        /// 获取上报的劳务合同
        /// </summary>
        /// <param name="RowID"></param>
        /// <returns></returns>
        public ActionResult GetPersonHetong(string RowID)
        {
            string service = "";
            string method = "";
            GetServcieMethod("06", ref service, ref method);
            //uddiPortTypeClient client = new uddiPortTypeClient();
            WebDataUpLoad.uddi client = GetClient();
            string param = "<?xml version=\"1.0\" encoding=\"GBK\"?><p>";
            param += "<s ryid=\"" + RowID + "\" />";
            param += "<s xm=\"\" />";
            param += "<s xxly=\"" + xxly + "\" />";
            param += "</p>";
            string result = client.invokeService(service, method, param);

            XmlDocument doc = new XmlDocument();
            doc.LoadXml(result);
            XmlNode xNode = doc.SelectSingleNode("/p/s");

            StringBuilder sbParam = new StringBuilder();
            //组件一个新的xml字符串
            sbParam.AppendFormat("<?xml version=\"1.0\" encoding=\"GBK\"?>");
            sbParam.AppendFormat("<p>");
            //获取此次查询结果
            var company = xNode.NextSibling.NextSibling.NextSibling.NextSibling.ChildNodes;
            for (int i = 0; i < company.Count; i++)
            {
                //循环获得每一个查询出来的上报信息
                sbParam.AppendFormat(company[i].OuterXml.Replace("/>", ">{0}</r>"), i);
            }
            sbParam.AppendFormat("</p>");

            XmlDocument xDoc = new XmlDocument();
            xDoc.LoadXml(sbParam.ToString());
            XmlNodeList parentNode = xDoc.SelectSingleNode("/p").ChildNodes;

            string hetong = parentNode[0].Attributes["filecontent"].Value;
            return Content(hetong);
        }

        /// <summary>
        /// 获取上报查询需要的服务和方法
        /// </summary>
        /// <param name="upType"></param>
        /// <param name="serviceName"></param>
        /// <param name="methodName"></param>
        private void GetServcieMethod(string upType, ref string serviceName, ref string methodName)
        {
            switch (upType)
            {
                case "01":
                    serviceName = "HSMWService";
                    methodName = "QueryCompProInfo";
                    break;
                case "02":
                    serviceName = "HSMWService";
                    methodName = "QueryProPerInfo";
                    break;
                case "03":
                    serviceName = "HSMWService";
                    methodName = "QueryProPhotoInfo";
                    break;
                case "04":
                    serviceName = "HSMWService";
                    methodName = "QueryProSalaryInfo";
                    break;
                case "05":
                    serviceName = "HSMWService";
                    methodName = "QueryProBackPayInfo";
                    break;
                case "06":
                    serviceName = "HSMWService";
                    methodName = "QueryProFileInfo";
                    break;
                case "07":
                    serviceName = "HSMWService";
                    methodName = "QueryDataCheckWarnInfo";
                    break;
                case "08":
                    serviceName = "HSMWService";
                    methodName = "QueryProAttendInfo";
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// 获取正式地址的上报对象
        /// </summary>
        /// <returns></returns>
        private WebDataUpLoad.uddi GetClient()
        {
            WebDataUpLoad.uddi client = new WebDataUpLoad.uddi();
            client.Url = HCQ2_Common.UpDataLoad.GetRealUrl;
            client.ClientCertificates.Add(HCQ2_Common.UpDataLoad.xs);
            return client;
        }

        /// <summary>
        /// 获取分页显示的数据源
        /// </summary>
        /// <param name="form"></param>
        /// <param name="jArr"></param>
        /// <returns></returns>
        private JArray GetPaddingSoure(FormCollection form, JArray jArr)
        {
            int rows = int.Parse(form["rows"]);
            int page = int.Parse(form["page"]);
            var data = jArr.Skip((rows * page) - rows).Take(rows).ToList();
            JArray modelJson = new JArray();
            if (data.Count > 0)
            {
                for (int i = 0; i < data.Count; i++)
                {
                    modelJson.Add(JObject.Parse(data[i].ToString()));
                }
            }
            return modelJson;
        }
    }
}
