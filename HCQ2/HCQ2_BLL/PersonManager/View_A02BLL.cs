using HCQ2_IBLL;
using HCQ2_Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using HCQ2_Model.WebApiModel.ParamModel;
using HCQ2_Model.AppModel;
using HCQ2_Model.APPModel.ParamModel;
using HCQ2_Model.APPModel.ResultApiModel;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Net;
using HCQ2_Model.ViewModel;
using Newtonsoft.Json.Linq;

namespace HCQ2_BLL
{
    public partial class View_A02BLL : IView_A02BLL
    {
        /// <summary>
        /// 获取View_A02信息，已经打卡的人员信息
        /// </summary>
        /// <returns></returns>
        public List<View_A02> GetView()
        {
            SM_CodeItemsBLL codeItem = new SM_CodeItemsBLL();
            List<View_A02> returnList = new List<View_A02>();
            List<View_A02> list = base.DBSession.IView_A02DAL.Select(o => o.A0101 != "")
                .OrderByDescending(k => k.A0201)
                .ThenBy(n => n.PersonID).ToList();
            return list;
        }

        /// <summary>
        /// 获取已经打卡的人员信息2017-6-2
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public List<View_A02> CheckPerson(object obj)
        {
            FormCollection param = (FormCollection)obj;
            DataTable dt = new DataTable();
            StringBuilder sbSql = new StringBuilder();
            sbSql.AppendFormat("select E0386=(select CodeItemName from SM_CodeItems where CodeID='JA' and CodeItemID=a.E0386),* from view_a02 a where ");
            string unit_id = string.Empty;
            if (!string.IsNullOrEmpty(param["unitID"]))
            {
                unit_id = param["unitID"];
            }
            else
            {
                unit_id = HCQ2UI_Helper.OperateContext.Current.bllSession.B01.
                    GetB01PerData(HCQ2UI_Helper.OperateContext.Current.Usr.user_id)[0].UnitID;
            }
            sbSql.AppendFormat(" UnitID='{0}'", unit_id);
            if (!string.IsNullOrEmpty(param["txtSearchDate"]))
            {
                string[] searchTime = param["txtSearchDate"].Split('-');
                sbSql.AppendFormat(" and year(a0201)={0} and month(a0201)={1} and day(a0201)={2} ",
                    searchTime[0], searchTime[1], searchTime[2]);
            }
            dt = HCQ2_Common.SQL.SqlHelper.ExecuteDataTable(sbSql.ToString());
            return HCQ2_Common.Data.DataTableHelper.DataTableToIList<View_A02>(dt);
        }

        /// <summary>
        /// 获取View_A02信息
        /// </summary>
        /// <param name="bindDate">年月日</param>
        /// <returns></returns>
        public DataTable GetView(object obj)
        {
            FormCollection form = (FormCollection)obj;
            int page = int.Parse(form["page"]);
            int rows = int.Parse(form["rows"]);
            List<View_A02> list = CheckPerson(obj);

            //获取所有人员
            A01BLL abll = new A01BLL();
            var personData = abll.GetA01Info().AsEnumerable();

            //获取当前已经打卡的人数集合
            var data = list.AsEnumerable();
            if (!string.IsNullOrEmpty(form["unitID"].Trim()))
            {
                switch (form["unitID"].Length)
                {
                    case 3:
                        data = data.Where(o => o.B0001 == form["unitID"].Trim());
                        personData = personData.Where(o => o.B0001 == form["unitID"].Trim());
                        break;
                    case 6:
                        data = data.Where(o => o.B000201 == form["unitID"].Trim());
                        personData = personData.Where(o => o.B000201 == form["unitID"].Trim());
                        break;
                    case 9:
                        data = data.Where(o => o.B000202 == form["unitID"].Trim());
                        personData = personData.Where(o => o.B000202 == form["unitID"].Trim());
                        break;
                    default:
                        break;
                }
            }
            else
            {
                HCQ2UI_Helper.OperateContext context = new HCQ2UI_Helper.OperateContext();
                string unit_id = context.bllSession.B01.GetB01PerData(context.Usr.user_id)[0].UnitID;
                data = data.Where(o => o.B0001 == unit_id);
                personData = personData.Where(o => o.B0001 == unit_id);
            }
            if (!string.IsNullOrEmpty(form["txtSearchDate"]))
            {
                string[] searchTime = form["txtSearchDate"].Split('-');
                data = data.Where(o => Convert.ToDateTime(o.A0201).Year == int.Parse(searchTime[0])
                && Convert.ToDateTime(o.A0201).Month == int.Parse(searchTime[1])
                && Convert.ToDateTime(o.A0201).Day == int.Parse(searchTime[2]));
            }
            if (!string.IsNullOrEmpty(form["search"]))
            {
                data = data.Where(o => o.A0101 == form["search"].Trim());
                personData = personData.Where(o => o.A0101 == form["search"].Trim());
            }

            string PersonIDStr = "''";
            if (personData.Count() > 0)
            {
                foreach (var item in personData)
                {
                    string personID = item.PersonID;
                    var dataNull = data.Where(o => o.PersonID == personID);
                    if (dataNull.Count() <= 0)
                    {
                        if (PersonIDStr == "''")
                            PersonIDStr = "'" + item.PersonID + "'";
                        else
                            PersonIDStr += ",'" + item.PersonID + "'";
                    }
                }
            }

            StringBuilder sbSql = new StringBuilder();
            sbSql.AppendFormat("select A0201='',A0101,B0001Name=(select unitname from B01 where UnitID=a.B0001)");
            sbSql.AppendFormat(" ,B0002Name=(select unitname from B01 where UnitID=a.B0002),");
            sbSql.AppendFormat(" E0386=(select CodeItemName from SM_CodeItems where CodeID='JA' and CodeItemID=a.E0386),C0104,A0177");
            sbSql.AppendFormat(" from A01 a where PersonID in ({0})", PersonIDStr);
            return HCQ2_Common.SQL.SqlHelper.ExecuteDataTable(sbSql.ToString());
        }

        /// <summary>
        /// 替换数据源里面的字典值
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public List<View_A02> GetViewReplace(List<View_A02> list)
        {
            SM_CodeItemsBLL codeItem = new SM_CodeItemsBLL();
            List<View_A02> returnList = new List<View_A02>();
            for (int i = 0; i < list.Count; i++)
            {
                View_A02 view = list[i];
                if (!string.IsNullOrEmpty(view.E0386))
                    view.E0386 = codeItem.GetCodeItemDetail("JA", view.E0386).CodeItemName;
                returnList.Add(view);
            }
            return returnList;
        }

        /// <summary>
        /// 根据PersonID筛选数据
        /// </summary>
        /// <param name="personID"></param>
        /// <returns></returns>
        public List<View_A02> GetViewByPersonID(string personID)
        {
            return base.DBSession.IView_A02DAL.Select(o => o.PersonID == personID);
        }

        /// <summary>
        /// 根据RowID筛选
        /// </summary>
        /// <param name="rowID"></param>
        /// <returns></returns>
        public View_A02 GetByRowID(string rowID)
        {
            return base.DBSession.IView_A02DAL.Select(o => o.RowID == rowID).FirstOrDefault();
        }

        /// <summary>
        /// 将对象转化为JSON数组
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public string ObjectToJson(List<View_A02> list)
        {
            return HCQ2_Common.JsonHelper.objectToJsonStr(list);
        }

        /// <summary>
        /// 根据单位代码筛选数据
        /// </summary>
        /// <param name="UnitID"></param>
        /// <returns></returns>
        public List<View_A02> GetByUnitID(string UnitID)
        {
            return base.DBSession.IView_A02DAL.Select(o => o.B0001 != UnitID);
        }

        /// <summary>
        /// 获取某年某月某日到岗人数
        /// </summary>
        /// <param name="year"></param>
        /// <param name="month"></param>
        /// <param name="day"></param>
        /// <returns></returns>
        public int GetAttendanceTrue(int year, int month, int day)
        {
            StringBuilder sbSql = new StringBuilder();
            sbSql.Append("select distinct PersonID from View_A02 where YEAR(A0201)=@year and MONTH(A0201)=@month and DAY(A0201)=@day");
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@year",year),
                new SqlParameter("@month",month),
                new SqlParameter("@day",day)
            };

            DataTable dt = HCQ2_Common.SQL.SqlHelper.ExecuteDataTable(sbSql.ToString(), CommandType.Text, param);
            return dt.Rows.Count;
        }

        /// <summary>
        /// 根据用户ID获取某年某月某天到岗人数
        /// </summary>
        /// <param name="year"></param>
        /// <param name="month"></param>
        /// <param name="day"></param>
        /// <param name="user_id"></param>
        /// <returns></returns>
        public int GetAttendanceTrue(int year, int month, int day, string user_id)
        {
            List<B01> unitList = HCQ2UI_Helper.OperateContext.Current.bllSession.B01.GetUnitDataByPermiss(Convert.ToInt32(user_id));
            StringBuilder sbSql = new StringBuilder();
            sbSql.AppendFormat("SELECT COUNT(distinct PersonID) FROM View_A02 where ");
            sbSql.AppendFormat("YEAR(A0201)={0} and MONTH(A0201)={1} and DAY(A0201)={2}", year, month, day);
            sbSql.AppendFormat("and UnitID in ({0})", "'" + string.Join("','", unitList.Where(o => o.UnitType == "N")?.Select(o => o.UnitID)) + "'");
            return Convert.ToInt32(HCQ2_Common.SQL.SqlHelper.ExecuteScalar(sbSql.ToString()));
        }

        /// <summary>
        /// 获取某年某月某日到岗人员的单位树
        /// </summary>
        /// <param name="year"></param>
        /// <param name="month"></param>
        /// <param name="day"></param>
        /// <param name="user_id"></param>
        /// <returns></returns>
        public List<Dictionary<string, object>> GetAttendanceDate(int year, int month, int day, int user_id)
        {
            List<Dictionary<string, object>> rList = new List<Dictionary<string, object>>();
            Dictionary<string, object> dic = new Dictionary<string, object>();
            List<View_A02> checkList = GetCheckPersonDisintct(year, month, day, user_id);
            string unit_id = "'" + string.Join("','", checkList.Select(o => o.UnitID)) + "'";
            StringBuilder sbSql = new StringBuilder();
            sbSql.AppendFormat("select * from b01 where UnitID in ({0})", unit_id);
            List<B01> unitList = HCQ2_Common.Data.DataTableHelper.DataTableToIList<B01>(
                HCQ2_Common.SQL.SqlHelper.ExecuteDataTable(sbSql.ToString()));
            foreach (var item in unitList)
            {
                dic = new Dictionary<string, object>();
                int check_count = checkList.Where(o => o.UnitID == item.UnitID).Count();
                dic.Add("UnitID", item.UnitID);
                dic.Add("text", item.UnitName + "(" + check_count + ")");
                rList.Add(dic);
            }
            return rList;
        }

        /// <summary>
        /// 获取某年某月某日到岗人员
        /// </summary>
        /// <param name="year"></param>
        /// <param name="month"></param>
        /// <param name="day"></param>
        /// <param name="user_id"></param>
        /// <returns></returns>
        public List<View_A02> GetAttendanceDatePerson(int year, int month, int day, int user_id)
        {
            List<B01> unitList = HCQ2UI_Helper.OperateContext.Current.bllSession.B01.GetUnitDataByPermiss(user_id);
            StringBuilder sbSql = new StringBuilder();
            sbSql.AppendFormat("SELECT E0386=(select CodeItemName from SM_CodeItems where CodeID='JA' and CodeItemID=a.E0386),* FROM View_A02 a where ");
            sbSql.AppendFormat("YEAR(A0201)={0} and MONTH(A0201)={1} and DAY(A0201)={2}", year, month, day);
            sbSql.AppendFormat("and UnitID in ({0})", "'" + string.Join("','", unitList.Where(o => o.UnitType == "N")?.Select(o => o.UnitID)) + "'");
            return HCQ2_Common.Data.DataTableHelper.DataTableToIList<View_A02>(
                HCQ2_Common.SQL.SqlHelper.ExecuteDataTable(sbSql.ToString()));
        }

        /// <summary> 
        /// 获取年月日下打卡的人员情况（一人一条记录）
        /// </summary>
        /// <param name="year"></param>
        /// <param name="month"></param>
        /// <param name="day"></param>
        /// <param name="user_id"></param>
        /// <returns></returns>
        private List<View_A02> GetCheckPersonDisintct(int year, int month, int day, int user_id)
        {
            List<B01> unitList = HCQ2UI_Helper.OperateContext.Current.bllSession.B01.GetUnitDataByPermiss(user_id);
            string UnitID = "'" + string.Join("','", unitList.Where(o => o.UnitType == "N")?.Select(o => o.UnitID)) + "'";
            StringBuilder sbSql = new StringBuilder();
            sbSql.AppendFormat("select PersonID,A0101,A0177,UnitID from View_A02 where");
            sbSql.AppendFormat(" UnitID in ({0}) and YEAR(A0201)={1} and MONTH(A0201)={2} and", UnitID, year, month);
            sbSql.AppendFormat(" DAY(A0201)={0} group by PersonID,A0101,A0177,UnitID", day);
            return HCQ2_Common.Data.DataTableHelper.DataTableToIList<View_A02>(
                HCQ2_Common.SQL.SqlHelper.ExecuteDataTable(sbSql.ToString()));
        }

        /// <summary>
        /// 获取包含打卡次数的数据源
        /// </summary>
        /// <param name="viewList"></param>
        /// <returns></returns>
        public List<HCQ2_Model.ViewModel.CheckModle> GetCheckCount(List<View_A02> viewList)
        {
            List<HCQ2_Model.ViewModel.CheckModle> rList = new List<HCQ2_Model.ViewModel.CheckModle>();
            if (viewList == null)
                return rList;

            HCQ2_Model.ViewModel.CheckModle modle = new HCQ2_Model.ViewModel.CheckModle();
            foreach (var item in viewList)
            {
                var data = rList.Where(o => o.A0177 == item.A0177);
                if (data.Count() > 0)
                    continue;
                var checkData = viewList.Where(o => o.PersonID == item.PersonID);
                modle = new HCQ2_Model.ViewModel.CheckModle();
                modle.PersonID = item.PersonID;
                modle.A0101 = item.A0101;
                modle.A0177 = item.A0177;
                modle.A0201 = item.A0201;
                modle.A0202 = item.A0202;
                modle.B0001Name = item.B0001Name;
                modle.C0104 = item.C0104;
                modle.E0386 = item.E0386;
                modle.check_count = string.Join(",", checkData.Select(n => n.A0201));
                modle.isFill = item.fill_check;
                if (item.fill_check == "1")
                {
                    modle.buReason = item.fill_reason;
                    modle.buUser = new T_UserBLL().Select(o => o.user_id == item.fill_user_id).FirstOrDefault().user_name;
                }
                if (checkData.Count() > 1)
                {
                    var lastModel = checkData.OrderByDescending(o => o.DispOrder).FirstOrDefault();
                    modle.lowWorkDate = lastModel.A0201;
                    modle.lowIsFill = lastModel.fill_check;
                    if (lastModel.fill_check == "1")
                    {
                        modle.lowReason = lastModel.fill_reason;
                        modle.lowUser = new T_UserBLL().Select(o => o.user_id == lastModel.fill_user_id).FirstOrDefault().user_name;
                    }

                }

                rList.Add(modle);
            }
            return rList;
        }

        /// <summary>
        /// 异常考勤上报
        /// </summary>
        /// <param name="strUnit">单位编号的字符串</param>
        /// <returns></returns>
        public string UpAttends(string strUnit)
        {
            string rStr = "ok,0";
            List<View_A02> attList = DBSession.IView_A02DAL.GetAttendsByUnit(strUnit);

            if (attList.Count() <= 0)
                return rStr;

            string param = "<?xml version=\"1.0\" encoding=\"GBK\"?><p>";
            param += "<d k=\"vds\">";
            param += UploadAttends(attList);
            param += "</d>";
            param += "</p>";

            string serviceName = "HSMWService";
            string methodName = "UploadProAttendInfo";
            //正式地址
            WebUpData.uddi client2 = new WebUpData.uddi();
            ServicePointManager.ServerCertificateValidationCallback = ValidateServerCertificate;
            client2.Url = "https://222.85.128.67:8088/dwlesbserver/services/uddi?wsdl";
            X509Certificate xs = new X509Certificate("E:\\RSA2008root.cer");
            client2.ClientCertificates.Add(xs);

            string mess = client2.invokeService(serviceName, methodName, param);
            if (mess.Contains("服务调用成功！"))
            {
                rStr = "ok" + "," + attList.Count();
            }
            else
            {
                rStr = "fin" + ",0";
            }
            return rStr;
        }

        private bool ValidateServerCertificate(object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors)
        {
            return true;
        }

        private static string xxly = "HVvxulonjCwuD8Dogh20VLZvxKlejeRhr3HLXHlP9tT99q6x54eerLKH0qVDd6b5a7H7nJ0Z2ggc1GkXBYPK9LZN378zQpgy11UlQyIxpFfS0LYiHzGI6zI/YQDwhyNq5kgiOXeYvP6fZIwYKDtwvGx5xSgNtLrfNt3X8t7mFs=";
        private string UploadAttends(List<View_A02> attList)
        {
            string strXml = "";

            foreach (var item in attList)
            {
                strXml += " <r ";
                strXml += " kqid=\"" + item.RowID + "\"";
                strXml += " ryid=\"" + item.PersonID + "\"";
                strXml += " xxly=\"" + xxly + "\"";
                strXml += " xmbh=\"" + GetRealUnitID(item.UnitID) + "\"";
                strXml += " sfzh=\"" + item.A0177 + "\"";
                strXml += " xm=\"" + item.A0101 + "\"";
                strXml += " kqsj=\"" + HCQ2_Common.DateHelper.GetCSTDate(item.A0201.ToString()) + "\"";
                strXml += " sbbs=\"" + (item.A0203 == "1" ? 1 : 2) + "\"";
                strXml += " kqtz=\"9\"";
                strXml += " kqsbbm=\"\"";
                strXml += " />";
            }

            return strXml;
        }

        private string GetRealUnitID(string UnitID)
        {
            B01 unit = new B01BLL().GetByUnitID(UnitID);
            if (!string.IsNullOrEmpty(unit.if_upload))
                return unit.if_upload;
            else
                return UnitID;
        }

        /// <summary>
        /// 获取考勤异常上报页面数据源
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public TableModel GetExcptionUpSoure(object obj)
        {
            FormCollection param = (FormCollection)obj;
            int rows = int.Parse(param["rows"]);
            int page = int.Parse(param["page"]);
            TableModel model = new TableModel();
            string UnitID = param["UnitID"];
            if (string.IsNullOrEmpty(UnitID))
            {
                var dataUnit = new B01BLL().GetPerUnitByUserID(HCQ2UI_Helper.OperateContext.Current.Usr.user_id);
                UnitID = string.Join("','", dataUnit.Select(o => o.UnitID));
            }

            List<View_A02> attList = DBSession.IView_A02DAL.GetAttendsByUnit("'" + UnitID + "'");

            if (!string.IsNullOrEmpty(param["txtSreachName"]))
            {
                string txtName = param["txtSreachName"];
                attList = attList.Where(o => o.A0101.Contains(txtName)).ToList();
            }

            model.total = attList.Count();
            model.rows = attList.Skip((rows * page) - rows).Take(rows);

            return model;
        }

        /// <summary>
        /// 上报异常考勤
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public bool UpLoadExcptionAttend(object obj)
        {
            List<string> strXmlList = new List<string>();
            FormCollection param = (FormCollection)obj;
            JArray comJson = JArray.Parse(param["rows"]);
            List<View_A02> viewList = new List<View_A02>();

            StringBuilder sbSql = new StringBuilder();
            //收集上报的项目的ID
            string strRowID = "";
            foreach (JObject item in comJson)
            {
                View_A02 at = new View_A02();
                at.RowID = item["RowID"].ToString();
                viewList.Add(at);
                if (string.IsNullOrEmpty(strRowID))
                    strRowID = "'" + item["RowID"].ToString() + "'";
                else
                    strRowID += ",'" + item["RowID"].ToString() + "'";
            }
            //需要上报的数据
            List<View_A02> attList = DBSession.IView_A02DAL.GetAttendsByRowID(strRowID);

            string xmlParam = "<?xml version=\"1.0\" encoding=\"GBK\"?><p>";
            xmlParam += "<d k=\"vds\">";
            xmlParam += UploadAttends(attList);
            xmlParam += "</d>";
            xmlParam += "</p>";

            string serviceName = "HSMWService";
            string methodName = "UploadProAttendInfo";

            //正式地址
            WebUpData.uddi client2 = new WebUpData.uddi();
            ServicePointManager.ServerCertificateValidationCallback = ValidateServerCertificate;
            client2.Url = "https://222.85.128.67:8088/dwlesbserver/services/uddi?wsdl";
            X509Certificate xs = new X509Certificate("E:\\RSA2008root.cer");
            client2.ClientCertificates.Add(xs);

            string mess = client2.invokeService(serviceName, methodName, xmlParam);
            if (mess.Contains("服务调用成功"))
            {
                foreach (var item in viewList)
                {
                    string upRowID = item.RowID;
                    A02 view = new A02();
                    view.if_upattend = "1";
                    new A02BLL().Modify(view, o => o.RowID == upRowID, "if_upattend");
                }
                return true;
            }
            else
                return false;
        }

        #region 用工接口

        /// <summary>
        /// 用工接口
        /// </summary>
        /// <param name="work"></param>
        /// <returns></returns>
        public object GetApiWorkTime(CheckUseWorker work)
        {
            B01BLL unit = new B01BLL();
            List<B01> unitList = unit.GetB01Info();
            var data = unitList.Where(o => o.UnitName == work.unitName);
            if (data.Count() > 0)
            {
                string unit_code = data.FirstOrDefault().UnitID;
                return NoCard(unit_code, work.checkDate);
            }
            else
            {
                //项目名称不正确
                return null;
            }
        }

        /// <summary>
        /// 没有打卡的人员
        /// </summary>
        /// <returns></returns>
        private object NoCard(string unit_code, string check_time)
        {
            SM_CodeItemsBLL code = new SM_CodeItemsBLL();

            //项目SQL语句
            StringBuilder sbUnit = new StringBuilder();
            switch (unit_code.Length)
            {
                case 3:
                    sbUnit.AppendFormat(" and a.B0001='{0}' ", unit_code);
                    break;
                case 6:
                    sbUnit.AppendFormat(" and a.B000201='{0}' ", unit_code);
                    break;
                case 9:
                    sbUnit.AppendFormat(" and a.B000202='{0}' ", unit_code);
                    break;
                default:
                    break;
            }

            StringBuilder sbSql = new StringBuilder();

            //已经打卡的人员
            sbSql = new StringBuilder();
            string[] time = check_time.Split('-');
            sbSql.AppendFormat(" select * from View_A02 a left join A01 b on a.PersonID=b.PersonID ");
            sbSql.AppendFormat(" WHERE YEAR(A0201)={0} and MONTH(A0201)={1} and DAY(A0201)={2} ", time[0], time[1], time[2]);
            sbSql.AppendFormat(sbUnit.ToString());
            DataTable dtOk = HCQ2_Common.SQL.SqlHelper.ExecuteDataTable(sbSql.ToString());

            //已打卡人员集合
            List<Dictionary<string, object>> listOk = new List<Dictionary<string, object>>();
            Dictionary<string, object> dicOk = new Dictionary<string, object>();

            //接收已经打卡人员的person_id
            string person_id = string.Empty;
            for (int i = 0; i < dtOk.Rows.Count; i++)
            {
                dicOk = new Dictionary<string, object>();
                dicOk.Add("personName", dtOk.Rows[i]["A0101"]);
                dicOk.Add("personSex", dtOk.Rows[i]["A0107"]);
                dicOk.Add("personPhone", dtOk.Rows[i]["C0104"]);
                if (dtOk.Rows[i]["E0386"] != null)
                {
                    dicOk.Add("personWorkType",
                        code.GetCodeItemByCodeID("JA").
                        Where(o => o.CodeItemID == dtOk.Rows[i]["E0386"].ToString()).
                        FirstOrDefault().CodeItemName);
                }
                else
                {
                    dicOk.Add("personWorkType", "");
                }
                dicOk.Add("personHomeTown", dtOk.Rows[i]["A0114"]);
                listOk.Add(dicOk);

                if (string.IsNullOrEmpty(person_id))
                    person_id = "'" + dtOk.Rows[i]["PersonID"].ToString() + "'";
                else
                    person_id += ",'" + dtOk.Rows[i]["PersonID"].ToString() + "'";
            }

            //没有打卡的人员
            sbSql = new StringBuilder();
            sbSql.AppendFormat("select * from A01 a where 1=1 ");
            if (!string.IsNullOrEmpty(person_id))
                sbSql.AppendFormat(" and PersonID not in ({0}) ", person_id);
            sbSql.AppendFormat(sbUnit.ToString());
            DataTable dtNot = HCQ2_Common.SQL.SqlHelper.ExecuteDataTable(sbSql.ToString());

            List<Dictionary<string, object>> listFin = new List<Dictionary<string, object>>();
            Dictionary<string, object> dicFin = new Dictionary<string, object>();
            for (int i = 0; i < dtNot.Rows.Count; i++)
            {
                dicFin = new Dictionary<string, object>();
                dicFin.Add("personName", dtNot.Rows[i]["A0101"]);
                dicFin.Add("personSex", dtNot.Rows[i]["A0107"]);
                dicFin.Add("personPhone", dtNot.Rows[i]["C0104"]);
                if (!string.IsNullOrEmpty(dtNot.Rows[i]["E0386"].ToString()))
                {
                    dicFin.Add("personWorkType",
                        code.GetCodeItemByCodeID("JA").
                        Where(o => o.CodeItemID == dtNot.Rows[i]["E0386"].ToString()).
                        FirstOrDefault().CodeItemName);
                }
                else
                {
                    dicFin.Add("personWorkType", "");
                }
                dicFin.Add("personHomeTown", dtNot.Rows[i]["A0114"]);
                listFin.Add(dicFin);
            }

            List<Dictionary<string, object>> list = new List<Dictionary<string, object>>();
            Dictionary<string, object> dic = new Dictionary<string, object>();
            dic.Add("ok", listOk);
            dic.Add("fin", listFin);
            list.Add(dic);

            return list;

        }
        #endregion
        /// <summary>
        ///  获取已出工情况 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public List<string> GetWorkPersonList(WorkCount model)
        {
            if (null == model)
                return null;
            return DBSession.IView_A02DAL.GetWorkPersonList(model);
        }

        /// <summary>
        ///  获取已出工人数
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int GetWorkPersonCount(WorkCount model)
        {
            if (null == model)
                return 0;
            return DBSession.IView_A02DAL.GetWorkPersonCount(model);
        }
        /// <summary>
        ///  获取未出工情况
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public List<string> GetonWorkPersonList(WorkCount model)
        {
            if (null == model)
                return null;
            return DBSession.IView_A02DAL.GetonWorkPersonList(model);
        }
        /// <summary>
        ///  获取未出工人数
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int GetonWorkPersonCount(WorkCount model)
        {
            if (null == model)
                return 0;
            return DBSession.IView_A02DAL.GetonWorkPersonCount(model);
        }
        /// <summary>
        ///  根据工种统计出工情况
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public List<WorkTypeCount> GetToWorkByType(WorkCount model)
        {
            if (null == model)
                return null;
            return DBSession.IView_A02DAL.GetToWorkByType(model);
        }

        List<WorkMonthResult> IView_A02BLL.GetMonthWorkData(WorkMonthList model)
        {
            if (null == model)
                return null;
            List<WorkSQLMonth> list = DBSession.IView_A02DAL.GetMonthWorkData(model);
            List<WorkMonthResult> rList = new List<WorkMonthResult>();
            if (null == list)
                return null;
            List<int> days = list.Select(s => s.day).Distinct().ToList();
            List<WorkSQLMonth> markList = new List<WorkSQLMonth>();
            foreach (var day in days)
            {
                markList = list.Where(s => s.day == day).ToList();
                string start = markList[0].hour, end = "";
                if (markList.Count > 1 && !markList[0].RowID.Equals(markList[1].RowID))
                    end = markList[1].hour;
                rList.Add(new WorkMonthResult { day = day, start_work = start, end_work = end });
            }
            return rList;
        }

        public List<WorkAllResult> GetAllWorkDays(WorkAllList model)
        {
            if (null == model)
                return null;
            return DBSession.IView_A02DAL.GetAllWorkDays(model);
        }

        public int GetMonthByCard(BaseAPI model)
        {
            if (null == model)
                return 0;
            return DBSession.IView_A02DAL.GetMonthByCard(model);
        }

        public int GetAllByCard(BaseAPI model)
        {
            if (null == model)
                return 0;
            return DBSession.IView_A02DAL.GetAllByCard(model);
        }

    }
}
