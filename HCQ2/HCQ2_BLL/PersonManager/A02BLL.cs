using HCQ2_Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using HCQ2_Model.WebApiModel.ParamModel;
using HCQ2_Model.APPModel.ResultApiModel;
using HCQ2_Model.APPModel.ParamModel;
using HCQ2_Model.ViewModel;
using System.Data;
using Newtonsoft.Json.Linq;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.Net.Security;

namespace HCQ2_BLL
{
    public partial class A02BLL : HCQ2_IBLL.IA02BLL
    {
        /// <summary>
        /// 获取所有的考勤情况
        /// </summary>
        /// <returns></returns>
        public List<A02> GetA02Info()
        {
            return base.Select(o => o.PersonID != "").OrderBy(k => k.DispOrder).ToList();
        }

        /// <summary>
        /// 根据PersonID获取考勤情况
        /// </summary>
        /// <param name="PersonID"></param>
        /// <returns></returns>
        public List<A02> GetByPersonID(string PersonID)
        {
            return base.Select(o => o.PersonID == PersonID).OrderBy(k => k.DispOrder).ToList();
        }

        /// <summary>
        /// 根据RowID获取实体
        /// </summary>
        /// <param name="RowID"></param>
        /// <returns></returns>
        public A02 GetByRowID(string RowID)
        {
            return base.Select(o => o.RowID == RowID).OrderBy(k => k.A0201).FirstOrDefault();
        }

        /// <summary>
        /// 添加、编辑考勤时间
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public bool OperAttendance(object obj)
        {
            FormCollection param = (FormCollection)obj;
            A01BLL aBll = new A01BLL();
            A02 a = new A02();

            a.A0201 = Convert.ToDateTime(param["A0201"]);

            bool returnBool = false;
            if (!string.IsNullOrEmpty(param["AttendanceIsEdit"]))
            {
                string RowID = param["AttendanceIsEdit"];
                returnBool = base.Modify(a, o => o.RowID == RowID, "A0201") > 0;
            }
            else
            {
                string RowID = param["AttendanceRowID"];
                a.PersonID = aBll.GetByRowID(RowID).PersonID;
                if (UpdateA02LastRow(a.PersonID))
                {
                    a.RowID = HCQ2_Common.RowIDHelp.GetNewRowID();
                    a.IsLastRow = 1; var data = GetA02Info();
                    if (data.Count() > 0)
                        a.DispOrder = data.Count() + 1;
                    else
                        a.DispOrder = 1;
                    returnBool = base.Add(a) > 0;
                }
                else
                {
                    returnBool = false;
                }
            }
            return returnBool;
        }

        /// <summary>
        /// 修改该人员的考勤记录为1的
        /// </summary>
        /// <param name="PersonID"></param>
        /// <returns></returns>
        private bool UpdateA02LastRow(string PersonID)
        {
            A02 a = new A02();
            a.IsLastRow = 0;
            var data = GetByPersonID(PersonID);
            if (data != null && data.Where(o => o.IsLastRow == 1).Count() > 0)
            {
                return base.Modify(a, o => o.PersonID == PersonID && o.IsLastRow == 1, "IsLastRow") > 0;
            }
            else
            {
                return true;
            }
        }

        /// <summary>
        /// API接口考勤签到
        /// </summary>
        /// <param name="model"></param>
        /// <param name="RowID"></param>
        /// <returns></returns>
        public bool ApiCheckPerson(HCQ2_Model.WebApiModel.ParamModel.CheckWorkModel model, ref string RowID)
        {
            A02 personCheck = new A02();

            //本次打卡记录
            personCheck.PersonID = model.personid;
            personCheck.A0201 = System.Convert.ToDateTime(model.signtime);
            RowID = HCQ2_Common.RowIDHelp.GetNewRowID();
            personCheck.RowID = RowID;
            personCheck.IsLastRow = 1;
            personCheck.if_upattend = "0";
            var dispOrder = base.Select(o => o.PersonID == model.personid);
            personCheck.DispOrder = dispOrder.Count > 0 ? dispOrder.Max(o => o.DispOrder) + 1 : 1;
            personCheck.A0202 = model.type;

            //判断是上班还是下班
            DateTime dt = System.Convert.ToDateTime(model.signtime);
            StringBuilder sbSql = new StringBuilder();
            sbSql.AppendFormat(" select * from A02 where YEAR(A0201)={0} and MONTH(A0201)={1} ", dt.Year, dt.Month);
            sbSql.AppendFormat(" and DAY(A0201)={0} and PersonID='{1}' ", dt.Day, model.personid);
            DataTable dtCheck = HCQ2_Common.SQL.SqlHelper.ExecuteDataTable(sbSql.ToString());
            if (dtCheck.Rows.Count > 0)
            {
                //有打卡记录
                var dataCheck = dtCheck.AsEnumerable().Where(o => o.Field<string>("A0204") == "1");
                if (dataCheck.Count() > 0)
                {
                    //今天有下班记录
                    string checkRowID = dataCheck.FirstOrDefault().Field<string>("RowID");
                    //修改下班记录为空
                    A02 cA02 = new A02();
                    cA02.A0204 = "";
                    Modify(cA02, o => o.RowID == checkRowID, "A0204");
                    //添加新的下班记录
                    personCheck.A0204 = "1";
                }
                else
                {
                    personCheck.A0204 = "1";
                }
            }
            else
            {
                personCheck.A0203 = "1";
            }

            var data = base.Select(o => o.PersonID == model.personid);
            if (data.Count() == 0)
            {
                return base.Add(personCheck) > 0;
            }
            else
            {
                A02 updateLastRow = new A02();
                updateLastRow.IsLastRow = 0;

                //有lastRow为1的要修改为0
                if (data.Where(o => o.IsLastRow == 1).Count() > 0)
                {
                    base.Modify(updateLastRow, o => o.PersonID == model.personid && o.IsLastRow == 1, "IsLastRow");
                }
                return base.Add(personCheck) > 0;
            }
        }

        private static string xxly = "HVvxulonjCwuD8Dogh20VLZvxKlejeRhr3HLXHlP9tT99q6x54eerLKH0qVDd6b5a7H7nJ0Z2ggc1GkXBYPK9LZN378zQpgy11UlQyIxpFfS0LYiHzGI6zI/YQDwhyNq5kgiOXeYvP6fZIwYKDtwvGx5xSgNtLrfNt3X8t7mFs=";

        /// <summary>
        /// 打卡上报
        /// </summary>
        /// <param name="PersonID"></param>
        /// <param name="checkDate"></param>
        /// <param name="checkTip"></param>
        public void UpCheck(string PersonID, string checkDate, string checkTip,string RowID)
        {
            View_A02 item = new View_A02BLL().Select(o => o.RowID == RowID).FirstOrDefault();
            string UnitID = item.UnitID;
            B01 Unit = new B01BLL().Select(o => o.UnitID == UnitID).FirstOrDefault();
            string realUnitID = string.IsNullOrEmpty(Unit.upLoadId) ? Unit.UnitID : Unit.UnitID;
            string param = "<?xml version=\"1.0\" encoding=\"GBK\"?><p>";
            param += "<d k=\"vds\">";
            param += " <r ";
            param += " kqid=\"" + RowID + "\"";
            param += " ryid=\"" + item.PersonID + "\"";
            param += " xxly=\"" + xxly + "\"";
            param += " xmbh=\"" + realUnitID + "\"";
            param += " sfzh=\"" + item.A0177 + "\"";
            param += " xm=\"" + item.A0101 + "\"";
            param += " kqsj=\"" + HCQ2_Common.DateHelper.GetCSTDate(checkDate) + "\"";
            param += " sbbs=\"" + (item.A0203 == "1" ? 1 : 2) + "\"";
            param += " kqtz=\"9\"";
            param += " kqsbbm=\"\"";
            param += " />";
            param += "</d>";
            param += "</p>";

            WebUpData.uddi client2 = new WebUpData.uddi();
            ServicePointManager.ServerCertificateValidationCallback = ValidateServerCertificate;
            client2.Url = "https://222.85.128.67:8088/dwlesbserver/services/uddi?wsdl";
            X509Certificate xs = new X509Certificate("E:\\RSA2008root.cer");
            client2.ClientCertificates.Add(xs);

            //基本信息上报字符串
            string serviceName = "HSMWService";
            string methodName = "UploadProAttendInfo";
            string mess = client2.invokeService(serviceName, methodName, param);
            if (mess.Contains("调用服务成功")) {
                //修改记录状态
                A02 att = new A02();
                att.if_upattend = "1";
                string updateRowID = item.RowID;
                base.Modify(att, o => o.RowID == updateRowID, "if_upattend");
            }
        }

        private bool ValidateServerCertificate(object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors)
        {
            return true;
        }

        /// <summary>
        /// 获取补签数据源
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public TableModel GetBuCheckSoure(object obj)
        {
            FormCollection param = (FormCollection)obj;
            TableModel model = new TableModel();

            if (string.IsNullOrEmpty(param["txtSearchDate"]))
                return model;
            string[] checkDate = param["txtSearchDate"].Split('-');
            if (checkDate.Length != 3)
                return model;
            string UnitID = param["UnitID"];
            if (string.IsNullOrEmpty(UnitID))
            {
                int user_id = HCQ2UI_Helper.OperateContext.Current.Usr.user_id;
                B01BLL unit = new B01BLL();
                UnitID = unit.GetB01PerData(user_id)[0].UnitID;
            }

            StringBuilder sbSql = new StringBuilder();
            //sbSql.AppendFormat("select PersonID,A0177,A0101,C0104,UnitID from A01 where UnitID='{0}' and PersonID not in (", UnitID);
            //sbSql.AppendFormat(" select distinct PersonID from View_A02 where YEAR(A0201)={0} ", checkDate[0]);
            //sbSql.AppendFormat(" and MONTH(A0201)={0} and DAY(A0201)={1} ", checkDate[1], checkDate[2]);
            //sbSql.AppendFormat(" and UnitID='{0}') ", UnitID);
            sbSql.AppendFormat(" select PersonID,A0177,A0101,C0104,UnitID from A01 ");
            sbSql.AppendFormat(" where UnitID='{0}' ", UnitID);
            DataTable dt = HCQ2_Common.SQL.SqlHelper.ExecuteDataTable(sbSql.ToString());

            if (dt == null)
                return model;

            List<A01> userList = HCQ2_Common.Data.DataTableHelper.DataTableToIList<A01>(dt);
            model.total = userList.Count();
            model.rows = userList;
            return model;
        }

        /// <summary>
        /// 补签到
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public bool BuCheckPerson(object obj, out string strMsg)
        {
            strMsg = "";
            FormCollection param = (FormCollection)obj;
            JArray json = JArray.Parse(param["rows"]);
            if (string.IsNullOrEmpty(param["check_date"]))
                return false;

            int user_id = HCQ2UI_Helper.OperateContext.Current.Usr.user_id;
            StringBuilder sbSql = new StringBuilder();
            foreach (var item in json)
            {
                sbSql.AppendFormat("insert A02(PersonID,A0201,DispOrder,fill_check,fill_reason,fill_user_id)");
                sbSql.AppendFormat(" values('{0}','{1}',(SELECT MAX(DispOrder)+1 from A02),'{2}','{3}','{4}');", item["PersonID"], param["check_date"], 1, param["check_reason"], user_id);
                if (string.IsNullOrEmpty(strMsg))
                    strMsg += "成功补签：" + item["A0101"];
                else
                    strMsg += "、" + item["A0101"];

            }
            int i = HCQ2_Common.SQL.SqlHelper.ExecuteNonQuery(sbSql.ToString());
            return true;
        }

        #region APP数据接口

        /// <summary>
        /// 统计图标出工打卡人数统计
        /// </summary>
        /// <param name="Model"></param>
        /// <returns></returns>
        public List<CheckDatePerson> GetPunchCardData(DebtChartMoneyModel Model)
        {
            List<CheckDatePerson> list = new List<CheckDatePerson>();
            CheckDatePerson rCheck = new CheckDatePerson();

            List<DateTime> timeList = HCQ2_Common.DateHelper.GetDateDetail(Convert.ToDateTime(Model.startDate), Convert.ToDateTime(Model.endDate));

            if (timeList == null)
                return null;

            StringBuilder sbSql = new StringBuilder();
            foreach (var item in timeList)
            {
                rCheck = new HCQ2_Model.APPModel.ResultApiModel.CheckDatePerson();
                sbSql = new StringBuilder();
                sbSql.AppendFormat("select COUNT(distinct(PersonID)) from A02 where YEAR(A0201)={0} ", item.Year);
                sbSql.AppendFormat(" and MONTH(A0201)={0} and DAY(A0201)={1}", item.Month, item.Day);

                rCheck.check_date = item.ToString("yyyy.MM.dd");
                rCheck.check_num = Convert.ToInt32(HCQ2_Common.SQL.SqlHelper.ExecuteScalar(sbSql.ToString()));
                list.Add(rCheck);
            }

            return list;
        }

        #endregion

        /// <summary>
        ///  获取工种分类
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public List<WorkTypeCount> GetWorkType(OrgModel model)
        {
            if (null == model)
                return null;
            return DBSession.IA02DAL.GetWorkType(model);
        }
    }
}
