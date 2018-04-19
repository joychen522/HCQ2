using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HCQ2_IBLL;
using HCQ2_Model;
using System.Data;
using System.Data.SqlClient;
using System.Web.Mvc;
using System.IO;
using Spring.Globalization;
using System.Runtime.Serialization.Formatters.Binary;
using HCQ2_Model.ViewModel;
using System.Web;
using HCQ2_Model.SelectModel;
using Newtonsoft.Json.Linq;
using NPOI.SS.Util;
using NPOI.HSSF.UserModel;
using System.Security.Cryptography.X509Certificates;
using System.Net;
using System.Net.Security;

namespace HCQ2_BLL
{
    public partial class A01BLL : IA01BLL
    {

        #region —————————基础数据获取—————

        /// <summary>
        /// 获取所有人员信息
        /// </summary>
        /// <returns></returns>
        public List<A01> GetA01Info()
        {
            return Select(o => o.PersonID != null).OrderBy(o => o.DispOrder).ToList();
        }

        /// <summary>
        /// 获取一个包含字典表的人员信息集合根据RowID
        /// </summary>
        /// <returns></returns>
        public DataTable GetA01ItemByRowID(string RowID)
        {
            return DBSession.IA01DAL.GetA01ByRowID(RowID);
        }

        /// <summary>
        /// 获取查询人员数据的字符串,不包含where条件
        /// </summary>
        /// <returns></returns>
        private StringBuilder GetPersonStr()
        {
            StringBuilder sbSql = new StringBuilder();
            sbSql.AppendFormat("select E03861=(select CodeItemName from SM_CodeItems where CodeID='JA' and CodeItemID=E0386),");
            sbSql.AppendFormat("B00031=(select CodeItemName from SM_CodeItems where CodeID='J' and CodeItemID=B0003),");
            sbSql.AppendFormat("A01071=(select CodeItemName from SM_CodeItems where CodeID='AX' and CodeItemID=A0107),");
            sbSql.AppendFormat("A01081=(select CodeItemName from SM_CodeItems where CodeID='JDXL' and CodeItemID=A0108),");
            sbSql.AppendFormat("A01211=(select CodeItemName from SM_CodeItems where CodeID='AE' and CodeItemID=A0121),");
            sbSql.AppendFormat("A01141=(select CodeItemName from SM_CodeItems where CodeID='AB' and CodeItemID=A0114),");
            sbSql.AppendFormat("A01101=(select CodeItemName from SM_CodeItems where CodeID='HP' and CodeItemID=A0110),");
            sbSql.AppendFormat("A01271=(select CodeItemName from SM_CodeItems where CodeID='BG' and CodeItemID=A0127),");
            sbSql.AppendFormat("A01281=(select CodeItemName from SM_CodeItems where CodeID='AT' and CodeItemID=A0128),");
            sbSql.AppendFormat("A01201=(select CodeItemName from SM_CodeItems where CodeID='45' and CodeItemID=A0120),");
            sbSql.AppendFormat("B0001x=(select UnitName from B01 where UnitID=B0001),");
            sbSql.AppendFormat("B0002x=(select UnitName from B01 where UnitID=B0002),");
            sbSql.AppendFormat("B000201x=(select UnitName from B01 where UnitID=B000201),");
            sbSql.AppendFormat("B000202x=(select UnitName from B01 where UnitID=B000202),");
            sbSql.AppendFormat("B000203x=(select UnitName from B01 where UnitID=B000203)");
            sbSql.AppendFormat(" ,* from A01");
            return sbSql;
        }

        /// <summary>
        /// 根据传入对象获取JSON字符串
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public string GetA01Json(List<A01> list)
        {
            return HCQ2_Common.JsonHelper.ObjectToJson(list);
        }

        /// <summary>
        /// 根据单位代码获取人员信息
        /// </summary>
        /// <param name="unitID"></param>
        /// <returns></returns>
        public List<A01> GetByUnitID(string unitID)
        {
            DataTable dt = DBSession.IA01DAL.GetA01ByUnitID(unitID);
            return HCQ2_Common.Data.DataTableHelper.DataTableToIList<A01>(dt);
        }

        /// <summary>
        /// 根据PersonID获取人员信息实体类
        /// </summary>
        /// <param name="PersonID"></param>
        /// <returns></returns>
        public A01 GetByPersonID(string PersonID)
        {
            return GetA01Info().Where(o => o.PersonID == PersonID).FirstOrDefault();
        }

        /// <summary>
        /// 根据RowID获取人员信息
        /// </summary>
        /// <param name="RowID"></param>
        /// <returns></returns>
        public A01 GetByRowID(string RowID)
        {
            return base.Select(o => o.RowID == RowID).FirstOrDefault();
        }

        /// <summary>
        /// 获取总人数
        /// </summary>
        /// <returns></returns>
        public int GetPeopleSum()
        {
            return DBSession.IA01DAL.GetTotalPersonCount();
        }

        /// <summary>
        /// 获取总人数，根据用户ID
        /// </summary>
        /// <param name="user_id"></param>
        /// <returns></returns>
        public int GetPeopleSum(int user_id)
        {
            List<B01> unitList = new B01BLL().GetPerUnitByUserID(user_id);
            string strUnit = "'" + string.Join("','", unitList.Where(o => o.UnitType == "N")?.Select(o => o.UnitID)) + "'";
            return DBSession.IA01DAL.GetTotalPersonCountByUser(strUnit);
        }

        /// <summary>
        /// 工种和人数统计
        /// </summary>
        /// <param name="user_id"></param>
        public void StaticJobsCoumt(int user_id, ref List<string> listJobs, ref List<int> listCount)
        {
            StringBuilder sbSql = new StringBuilder();
            List<B01> unitList = new B01BLL().GetPerUnitByUserID(user_id);
            string unitCodeWhere = "'" + string.Join("','", unitList.Select(n => n.UnitID)) + "'";

            if (unitList != null)
            {
                DataTable dtJobs = DBSession.IA01DAL.GetWorkJobsByUnitInfo(unitCodeWhere);
                DataTable dtTotal = DBSession.IA01DAL.GetWorkJobsByUnit(unitCodeWhere);

                SM_CodeItemsBLL codeItem = new SM_CodeItemsBLL();
                var data = codeItem.GetCodeItemByCodeID("JA");

                JobsModel job = new JobsModel();
                List<JobsModel> jobList = new List<JobsModel>();

                for (int i = 0; i < dtJobs.Rows.Count; i++)
                {
                    if (string.IsNullOrEmpty(dtJobs.Rows[i]["E0386"].ToString()))
                    {
                        job = new JobsModel();
                        job.jobsName = "未知工种";
                        job.jobsCount = dtTotal.Select(" isnull(E0386,'')='' ").Count();
                    }
                    else
                    {
                        job = new JobsModel();
                        job.jobsName = data.Where(o => o.CodeItemID == dtJobs.Rows[i]["E0386"].ToString()).FirstOrDefault().CodeItemName;
                        job.jobsCount = dtTotal.Select(" E0386='" + dtJobs.Rows[i]["E0386"] + "' ").Count();
                    }
                    jobList.Add(job);
                }

                jobList = jobList.OrderByDescending(o => o.jobsCount).ToList();
                for (int i = 0; i < jobList.Count; i++)
                {
                    if (i > 19)
                        break;
                    listJobs.Add(jobList[i].jobsName);
                    listCount.Add(jobList[i].jobsCount);
                }
            }
        }

        /// <summary>
        /// 获取页面需要显示的数据源
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public DataTable GetPageTableModle(object obj)
        {
            FormCollection param = (FormCollection)obj;
            TableModel modle = new TableModel();
            StringBuilder sbSql = new StringBuilder();
            sbSql = GetPersonStr();
            sbSql.AppendFormat(" where 1=1 ");

            int rows = int.Parse(param["rows"]);
            int page = int.Parse(param["page"]);

            #region 单位判断
            //单位
            if (!string.IsNullOrEmpty(param["UnitID"]))
            {
                string unit_id = param["UnitID"];
                sbSql.AppendFormat(" and UnitID = '{0}' ", unit_id);
            }
            //首次进入
            else
            {
                int user_id = HCQ2UI_Helper.OperateContext.Current.Usr.user_id;
                B01BLL unit = new B01BLL();
                string unit_id = unit.GetB01PerData(user_id)[0].UnitID;
                sbSql.AppendFormat(" and UnitID = '{0}' ", unit_id);
            }

            #endregion

            #region 关键字判断

            if (!string.IsNullOrEmpty(param["txtSearchName"]))
            {
                string searchName = param["txtSearchName"];
                sbSql.AppendFormat(" and A0101 like '%{0}%' ", searchName);
            }

            #endregion

            return HCQ2_Common.SQL.SqlHelper.ExecuteDataTable(sbSql.ToString());
        }

        /// <summary>
        /// 获取首页出工详情
        /// </summary>
        /// <returns></returns>
        public List<HCQ2_Model.ViewModel.MainCheckUnit> GetMainCheckUnit(string check_date)
        {
            List<HCQ2_Model.ViewModel.MainCheckUnit> rList = new List<MainCheckUnit>();
            string[] checkDate = check_date.Split('-');
            if (checkDate.Count() != 3)
                return rList;
            MainCheckUnit check = new MainCheckUnit();
            int user_id = HCQ2UI_Helper.OperateContext.Current.Usr.user_id;
            List<B01> unitList = HCQ2UI_Helper.OperateContext.Current.bllSession.B01.GetUnitDataByPermiss(user_id);
            string strUnitID = "'" + string.Join("','", unitList.Select(o => o.UnitID)) + "'";
            unitList = unitList.Where(o => o.UnitType == "N").ToList();
            if (unitList == null)
                return rList;

            StringBuilder sbSql = new StringBuilder();

            foreach (var item in unitList)
            {
                check = new MainCheckUnit();
                check.UnitID = item.UnitID;
                check.UnitName = item.UnitName;

                check.CheckWorkers = DBSession.IView_A02DAL.GetWorkCountByUnitID(item.UnitID, checkDate[0], checkDate[1], checkDate[2]);

                //sbSql = new StringBuilder();
                //sbSql.AppendFormat("select COUNT(distinct PersonID) from View_A02 where YEAR(A0201)={0} and MONTH(A0201)={1}", checkDate[0], checkDate[1]);
                //sbSql.AppendFormat(" and DAY(A0201)={0} and UnitID='{1}' ", checkDate[2], item.UnitID);
                //check.CheckWorkers = Convert.ToInt32(HCQ2_Common.SQL.SqlHelper.ExecuteScalar(sbSql.ToString()));
                check.totalWorkers = DBSession.IA01DAL.GetTotalPersonCountByUser("'" + item.UnitID + "'");

                //sbSql = new StringBuilder();
                //sbSql.AppendFormat("select COUNT(distinct PersonID) from A01 where UnitID='{0}'", item.UnitID);
                //check.totalWorkers = Convert.ToInt32(HCQ2_Common.SQL.SqlHelper.ExecuteScalar(sbSql.ToString()));

                if (check.CheckWorkers > 0 && check.totalWorkers > 0)
                    check.CheckPepe = Convert.ToDouble((((decimal)check.CheckWorkers / check.totalWorkers) * 100).ToString("f2"));
                else
                    check.CheckPepe = 0;
                rList.Add(check);
            }
            rList = rList.OrderByDescending(o => o.CheckPepe).ToList();
            return rList;
        }

        /// <summary>
        /// 获取首页出工详细人员
        /// </summary>
        /// <param name="unitid"></param>
        /// <returns></returns>
        public List<View_A02> GetMainCheckPerson(string unitid, string check_date)
        {
            List<View_A02> pList = new List<View_A02>();
            string[] checkDate = check_date.Split('-');
            if (checkDate.Count() != 3)
                return pList;
            DataTable dt = DBSession.IView_A02DAL.GetWorkByUnitData(unitid, checkDate[0], checkDate[1], checkDate[2]);
            pList = HCQ2_Common.Data.DataTableHelper.DataTableToIList<View_A02>(dt);
            return pList;
        }

        /// <summary>
        /// 创建一个hssfworkbook信息流
        /// </summary>
        /// <param name="userList"></param>
        /// <returns></returns>
        public System.IO.MemoryStream GetWorkBook(string UnitID)
        {
            DataTable dt = DBSession.IA01DAL.GetPersonByUnitID(UnitID);
            List<NpoiPersonModel> modelList = GetItemList();
            HSSFWorkbook workbook = new HSSFWorkbook();
            HSSFSheet sheet = (HSSFSheet)workbook.CreateSheet("sheet1");

            //表头--标题
            HSSFRow tr = (HSSFRow)sheet.CreateRow(0);
            tr.Height = 40 * 20;
            HSSFCell tc = (HSSFCell)tr.CreateCell(0);
            //获取全部的数据行数
            CellRangeAddress thinStyle = new CellRangeAddress(0, 0, 0, modelList.Count() - 1);
            sheet.AddMergedRegion(thinStyle);
            tc.SetCellValue("人员基本信息表");
            tc.CellStyle = GetStyleTitle(workbook);

            tr = (HSSFRow)sheet.CreateRow(1);
            for (int i = 0; i < modelList.Count; i++)
            {
                tc = (HSSFCell)tr.CreateCell(i);
                tc.SetCellValue(modelList[i].item_cname);
            }
            tc.CellStyle = GetStyleUnitName(workbook);

            List<T_ItemCodeMenum> menuList = new T_ItemCodeMenumBLL().GetByItemId(new T_ItemCodeBLL().GetByItemCode("InTeam").item_id);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                tr = (HSSFRow)sheet.CreateRow(i + 2);
                for (int j = 0; j < modelList.Count; j++)
                {
                    tc = (HSSFCell)tr.CreateCell(j);
                    if (modelList[j].item_name == "A0179" || modelList[j].item_name == "E0359" ||
                        modelList[j].item_name == "A0111" || modelList[j].item_name == "A0116" ||
                        modelList[j].item_name == "A0117" || modelList[j].item_name == "A0179")
                    {
                        if (!string.IsNullOrEmpty(dt.Rows[i][modelList[j].item_name].ToString()))
                        {
                            tc.SetCellValue(Convert.ToDateTime(dt.Rows[i][modelList[j].item_name]).ToString("yyyy-MM-dd"));
                        }
                    }
                    else if (modelList[j].item_name == "in_team")
                    {
                        if (!string.IsNullOrEmpty(dt.Rows[i][modelList[j].item_name].ToString()))
                        {
                            string code_value = dt.Rows[i][modelList[j].item_name].ToString();
                            tc.SetCellValue(menuList.Where(o => o.code_value == code_value).FirstOrDefault().code_name);
                        }
                    }
                    else
                        tc.SetCellValue(dt.Rows[i][modelList[j].item_name].ToString());
                }
            }

            System.IO.MemoryStream ms = new System.IO.MemoryStream();
            workbook.Write(ms);
            return ms;
        }

        /// <summary>
        /// 获取标题样式
        /// </summary>
        /// <param name="work"></param>
        /// <returns></returns>
        private static HSSFCellStyle GetStyleTitle(HSSFWorkbook work)
        {
            HSSFCellStyle style = (HSSFCellStyle)work.CreateCellStyle();
            style.Alignment = NPOI.SS.UserModel.HorizontalAlignment.CENTER;
            style.VerticalAlignment = NPOI.SS.UserModel.VerticalAlignment.CENTER;
            HSSFFont font = (HSSFFont)work.CreateFont();
            font.FontName = "宋体";
            font.FontHeightInPoints = 20;
            font.Boldweight = short.MaxValue;
            style.SetFont(font);
            style.WrapText = true;
            return style;
        }

        /// <summary>
        /// 获取单位样式
        /// </summary>
        /// <param name="work"></param>
        /// <returns></returns>
        public static HSSFCellStyle GetStyleUnitName(HSSFWorkbook work)
        {
            HSSFCellStyle style = (HSSFCellStyle)work.CreateCellStyle();
            style.Alignment = NPOI.SS.UserModel.HorizontalAlignment.LEFT;
            style.VerticalAlignment = NPOI.SS.UserModel.VerticalAlignment.CENTER;
            HSSFFont font = (HSSFFont)work.CreateFont();
            font.FontName = "宋体";
            font.FontHeightInPoints = 10;
            style.SetFont(font);
            return style;
        }

        /// <summary>
        /// 获取需要导出的字段对照表
        /// </summary>
        /// <returns></returns>
        private List<NpoiPersonModel> GetItemList()
        {
            List<NpoiPersonModel> rList = new List<NpoiPersonModel>();
            NpoiPersonModel modle = new NpoiPersonModel();
            modle.item_name = "A0101";
            modle.item_cname = "姓名";
            rList.Add(modle);

            modle = new NpoiPersonModel();
            modle.item_name = "C0104";
            modle.item_cname = "移动电话";
            rList.Add(modle);

            modle = new NpoiPersonModel();
            modle.item_name = "A0178";
            modle.item_cname = "基本工资";
            rList.Add(modle);

            modle = new NpoiPersonModel();
            modle.item_name = "A0179";
            modle.item_cname = "预计发放时间";
            rList.Add(modle);

            modle = new NpoiPersonModel();
            modle.item_name = "E0386";
            modle.item_cname = "工种";
            rList.Add(modle);

            modle = new NpoiPersonModel();
            modle.item_name = "B0003";
            modle.item_cname = "岗位";
            rList.Add(modle);

            modle = new NpoiPersonModel();
            modle.item_name = "E0387";
            modle.item_cname = "兼职岗位信息";
            rList.Add(modle);

            modle = new NpoiPersonModel();
            modle.item_name = "E0359";
            modle.item_cname = "入职日期";
            rList.Add(modle);

            modle = new NpoiPersonModel();
            modle.item_name = "A0180";
            modle.item_cname = "发放批次";
            rList.Add(modle);

            modle = new NpoiPersonModel();
            modle.item_name = "E0394";
            modle.item_cname = "发薪模式";
            rList.Add(modle);

            modle = new NpoiPersonModel();
            modle.item_name = "E0368";
            modle.item_cname = "薪酬";
            rList.Add(modle);

            modle = new NpoiPersonModel();
            modle.item_name = "A0177";
            modle.item_cname = "身份证号";
            rList.Add(modle);

            modle = new NpoiPersonModel();
            modle.item_name = "A0111";
            modle.item_cname = "出生日期";
            rList.Add(modle);

            modle = new NpoiPersonModel();
            modle.item_name = "A0107";
            modle.item_cname = "性别";
            rList.Add(modle);

            modle = new NpoiPersonModel();
            modle.item_name = "C0101";
            modle.item_cname = "年龄";
            rList.Add(modle);

            modle = new NpoiPersonModel();
            modle.item_name = "A0121";
            modle.item_cname = "民族";
            rList.Add(modle);

            modle = new NpoiPersonModel();
            modle.item_name = "A0114";
            modle.item_cname = "籍贯";
            rList.Add(modle);

            modle = new NpoiPersonModel();
            modle.item_name = "A0115";
            modle.item_cname = "居住地";
            rList.Add(modle);

            modle = new NpoiPersonModel();
            modle.item_name = "A0109";
            modle.item_cname = "户籍地址";
            rList.Add(modle);

            modle = new NpoiPersonModel();
            modle.item_name = "A0112";
            modle.item_cname = "签发机关";
            rList.Add(modle);

            modle = new NpoiPersonModel();
            modle.item_name = "A0116";
            modle.item_cname = "有效日期起";
            rList.Add(modle);

            modle = new NpoiPersonModel();
            modle.item_name = "A0117";
            modle.item_cname = "有效日期止";
            rList.Add(modle);

            modle = new NpoiPersonModel();
            modle.item_name = "A0110";
            modle.item_cname = "户口类型";
            rList.Add(modle);

            modle = new NpoiPersonModel();
            modle.item_name = "A0127";
            modle.item_cname = "婚姻状况";
            rList.Add(modle);

            modle = new NpoiPersonModel();
            modle.item_name = "C01SS";
            modle.item_cname = "紧急联系人";
            rList.Add(modle);

            modle = new NpoiPersonModel();
            modle.item_name = "C01RV";
            modle.item_cname = "紧急联系人电话";
            rList.Add(modle);

            modle = new NpoiPersonModel();
            modle.item_name = "A0181";
            modle.item_cname = "工区";
            rList.Add(modle);

            modle = new NpoiPersonModel();
            modle.item_name = "in_team";
            modle.item_cname = "所属队伍";
            rList.Add(modle);

            return rList;
        }

        /// <summary>
        /// 获取人员信息表所用到的全部工种
        /// </summary>
        /// <returns></returns>
        public List<Dictionary<string, object>> GetWorkerType()
        {
            List<Dictionary<string, object>> rList = new List<Dictionary<string, object>>();
            Dictionary<string, object> rDic = new Dictionary<string, object>();

            StringBuilder sbSql = new StringBuilder();
            sbSql.AppendFormat("select CodeItemName,CodeItemID,JPSign from SM_CodeItems where CodeID='JA'");
            sbSql.AppendFormat(" and CodeItemID in (select distinct E0386 from A01) and Parent<>'.'");
            DataTable dt = HCQ2_Common.SQL.SqlHelper.ExecuteDataTable(sbSql.ToString());
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                rDic = new Dictionary<string, object>();
                rDic.Add("CodeItemID", dt.Rows[i]["CodeItemID"]);
                rDic.Add("CodeItemName", dt.Rows[i]["CodeItemName"]);
                rDic.Add("JPSign", dt.Rows[i]["JPSign"]);
                rList.Add(rDic);
            }
            return rList;
        }

        #endregion

        #region ————————基础数据操作——————

        /// <summary>
        /// 判断项目里面是否存在某个身份证的人
        /// </summary>
        /// <param name="identifyCode"></param>
        /// <param name="unit_id"></param>
        /// <returns></returns>
        public bool ValidatePerson(string identifyCode, string unit_id)
        {
            return Select(o => o.A0177 == identifyCode && o.UnitID == unit_id).Count() > 0;
        }

        /// <summary>
        /// 新增人员信息
        /// </summary>
        /// <param name="obj">System.Web.Mvc.FormCollection类型数据</param>
        /// <returns></returns>
        public string AddPerson(object obj)
        {
            bool isAdd = false;
            string RowID = "";
            FormCollection param = (FormCollection)obj;
            A01 a = new A01();

            if (!string.IsNullOrEmpty(param["RowID"]))
            {
                RowID = param["RowID"];
            }
            else
            {
                RowID = GetNewRowID();
                isAdd = true;
                a.DispOrder = GetPeopleSum() + 1;
                a.PClassID = "00001";
                a.PersonID = GetNewRowID();
                a.RowID = RowID;
            }

            #region 字符串类型、日期类型，数字类型处理
            a.A0101 = param["A0101"];
            a.C0104 = param["C0104"];

            if (!string.IsNullOrEmpty(param["A0178"]))
                a.A0178 = long.Parse(param["A0178"]);
            if (!string.IsNullOrEmpty(param["A0179"]))
                a.A0179 = Convert.ToDateTime(param["A0179"]);
            a.E0387 = param["E0387"];

            //入职时间需要默认
            if (!string.IsNullOrEmpty(param["E0359"]))
                a.E0359 = Convert.ToDateTime(param["E0359"]);
            else
                a.E0359 = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));

            a.E0394 = param["E0394"];
            a.A0177 = param["A0177"];
            if (!string.IsNullOrEmpty(param["A0111"]))
                a.A0111 = Convert.ToDateTime(param["A0111"]);
            if (!string.IsNullOrEmpty(param["C0101"]))
                a.C0101 = int.Parse(param["C0101"]);
            a.A0115 = param["A0115"];
            a.A0109 = param["A0109"];
            a.A0112 = param["A0112"];
            if (!string.IsNullOrEmpty(param["A0116"]))
                a.A0116 = Convert.ToDateTime(param["A0116"]);
            if (!string.IsNullOrEmpty(param["A0117"]))
                a.A0117 = Convert.ToDateTime(param["A0117"]);
            a.C01SS = param["C01SS"];
            a.C01RV = param["C01RV"];
            if (!string.IsNullOrEmpty(param["A0119"]))
                a.A0119 = Convert.ToDateTime(param["A0119"]);
            a.A0122 = param["A0122"];
            a.A0181 = param["A0181"];
            a.create_time = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
            a.create_user_id = HCQ2UI_Helper.OperateContext.Current.Usr.user_id.ToString();
            a.update_id = HCQ2UI_Helper.OperateContext.Current.Usr.user_id;
            a.update_time = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
            a.in_type = "手工";
            a.scan_contract = param["scan_contract"];
            a.A0146 = param["A0146"];
            a.NMGZHSSYH = param["NMGZHSSYH"];
            #endregion

            #region 代码型处理
            //工种：JA、性别：AX、最高学历：JDXL、民族：AE、籍贯：AB、户口类型：HP
            //婚姻状况：BG、政治面貌：AT、黑名单：45
            if (!string.IsNullOrEmpty(param["E0386"].Trim()))
                a.E0386 = GetCodeItemNamebyID(param["E0386"].Trim(), "JA");
            if (!string.IsNullOrEmpty(param["A0107"].Trim()))
                a.A0107 = GetCodeItemNamebyID(param["A0107"].Trim(), "AX");
            if (!string.IsNullOrEmpty(param["A0121"].Trim()))
                a.A0121 = GetCodeItemNamebyID(param["A0121"].Trim(), "AE");
            if (!string.IsNullOrEmpty(param["A0114"].Trim()))
                a.A0114 = GetCodeItemNamebyID(param["A0114"].Trim(), "AB");
            //所属队伍处理
            a.in_team = param["in_team"];
            #endregion

            #region 单位代码处理
            if (!string.IsNullOrEmpty(param["B00011"]))
            {
                a.B0001 = param["B00011"];
                a.UnitID = param["B00011"];
            }
            #endregion

            #region 照片处理

            if (!string.IsNullOrEmpty(param["PersonPhotoSrc"]))
            {
                string imagePath = param["PersonPhotoSrc"];
                byte[] str = HCQ2_Common.ImageHelper.ImageToBytes(HttpContext.Current.Server.MapPath(imagePath));
                a.PersonPhoto = str;
            }
            if (!string.IsNullOrEmpty(param["identifyCodeCardPhoto"]))
            {
                a.PersonPhoto = Convert.FromBase64String(param["identifyCodeCardPhoto"]);
            }
            if (!string.IsNullOrEmpty(param["big_iris"]))
            {
                string iris = param["big_iris"];

                byte[] small = String16ToByte(iris.Substring(0, iris.Length / 2));
                a.A0118 = Convert.ToBase64String(small);

                byte[] big = String16ToByte(iris.Substring(iris.Length / 2, iris.Length / 2));
                a.big_iris_data = Convert.ToBase64String(big);
            }
            #endregion

            #region 上报数据处理

            a.SSDWLB = param["SSDWLB"];
            a.SSDWZW = param["SSDWZW"];
            a.GZGZHDFS = param["GZGZHDFS"];
            a.GZGZHDBZ = param["GZGZHDBZ"];
            a.SSBZ = param["SSBZ"];
            a.SFBZFZR = param["SFBZFZR"];
            a.SFQDJYYGHT = param["SFQDJYYGHT"];
            a.lzyy = param["lzyy"];

            #endregion

            bool returnAccess = isAdd ? base.Add(a) > 0 : base.Modify(a, o => o.RowID == RowID,
                "A0101", "C0104", "A0178", "A0179", "E0387", "E0359", "A0118"
                , "E0394", "A0111", "C0101", "A0115", "A0109", "A0112", "big_iris_data"
                , "A0116", "A0117", "C01SS", "C01RV", "A0119", "in_team"
                , "A0122", "E0386", "A0107", "A0121", "A0114", "update_id", "update_time"
                , "A0120", "B0001", "B0002", "B000201", "B000202", "A0181", "in_team", "scan_contract",
                "SSDWLB", "SSDWZW", "GZGZHDFS", "GZGZHDBZ", "SSBZ", "SFBZFZR", "SFQDJYYGHT", "lzyy", "A0146", "NMGZHSSYH") >= 0;

            string returnStr = returnAccess ? "ok" : "find";
            return returnStr + "," + RowID;
        }

        /// <summary>
        /// 16进制转化为byte[]
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        private static byte[] String16ToByte(string str)
        {
            str = str.ToUpper();
            char[] hexChars = str.ToCharArray();
            byte[] returnBytes = new byte[str.Length / 2];
            for (int i = 0; i < returnBytes.Length; i++)
            {
                returnBytes[i] = (byte)(charToBtye(hexChars[i * 2]) << 4 | charToBtye(hexChars[i * 2 + 1]));
            }
            return returnBytes;
        }

        /// <summary>
        /// 处理16进制字符串
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        private static byte charToBtye(char str)
        {
            return (byte)"0123456789ABCDEF".IndexOf(str);
        }

        /// <summary>
        /// 获取字典值
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        private string GetCodeItemNamebyID(string obj, string item_id)
        {
            SM_CodeItemsBLL item = new SM_CodeItemsBLL();
            return item.GetCodeItemByCodeID(item_id).Where(o => o.CodeItemName == obj).FirstOrDefault().CodeItemID;
        }

        /// <summary>
        /// 获取新字典值
        /// </summary>
        /// <param name="item_code"></param>
        /// <param name="code_name"></param>
        /// <param name="unit_id"></param>
        /// <returns></returns>
        private string GetCodeNewItemName(string item_code, string code_name, string unit_id)
        {
            T_ItemCode itemCode = new T_ItemCodeBLL().GetByItemCode(item_code);
            List<T_ItemCodeMenum> menuList = new T_ItemCodeMenumBLL().GetByItemId(itemCode.item_id);
            B01 unit = new B01BLL().GetByUnitID(unit_id);
            var data = menuList.Where(o => o.code_name == code_name && o.code_type == unit.UnitName);
            if (data.Count() <= 0)
            {
                data = menuList.Where(o => o.code_name == code_name);
            }
            return data.FirstOrDefault().code_value;
        }

        /// <summary>
        /// 获取一个新的编号
        /// </summary>
        /// <returns></returns>
        public string GetNewRowID()
        {
            return HCQ2_Common.SQL.SqlHelper.ExecuteScalar("select NEWID()").ToString().Replace("-", "").ToUpper();
        }

        /// <summary>
        /// 人员移动
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public bool MovePerson(object obj, ref string strMsg)
        {
            FormCollection param = (FormCollection)obj;
            JArray json = JArray.Parse(param["rows"]);
            //判断目标单位是否有重复
            if (!isPersonExixts(json, param["id"], out strMsg))
            {
                return false;
            }
            StringBuilder sbSql = new StringBuilder();
            //开始移动
            foreach (JObject item in json)
            {
                sbSql.AppendFormat("update A01 set B0001='{0}',UnitID='{1}' where A0177='{2}' and UnitID='{3}';",
                    param["id"], param["id"], item["A0177"], item["UnitID"]);
                strMsg += "转移成功：" + item["A0101"].ToString() + "；";
            }
            return HCQ2_Common.SQL.SqlHelper.ExecuteNonQuery(sbSql.ToString()) > 0;
        }

        /// <summary>
        /// 人员复制
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="strMsg"></param>
        /// <returns></returns>
        public bool CpoyPerson(object obj, ref string strMsg)
        {
            FormCollection param = (FormCollection)obj;
            JArray json = JArray.Parse(param["rows"]);
            //判断目标单位是否有重复
            if (!isPersonExixts(json, param["id"], out strMsg))
            {
                return false;
            }
            string old_unit_id = json[0]["UnitID"].ToString();
            List<A01> userList = Select(o => o.UnitID == old_unit_id);
            int dispOrder = userList.Count();
            StringBuilder sbSql = new StringBuilder();
            //开始复制
            foreach (JObject item in json)
            {
                dispOrder++;
                A01 user = new A01();
                string personName = item["A0101"].ToString();
                string personCarno = item["A0177"].ToString();
                string UnitID = item["UnitID"].ToString();
                user = userList.Where(o => o.A0177 == personCarno && o.UnitID == UnitID).FirstOrDefault();

                A01 newUser = new A01();

                #region 档案信息
                newUser.PClassID = user.PClassID;
                newUser.A01C01 = user.A01C01;
                newUser.E0389 = user.E0389;
                newUser.A0101 = user.A0101;
                newUser.C0104 = user.C0104;
                newUser.A0178 = user.A0178;
                newUser.A0179 = user.A0179;
                newUser.E0386 = user.E0386;
                newUser.B0003 = user.B0003;
                newUser.E0387 = user.E0387;
                newUser.E0359 = user.E0359;
                newUser.A0180 = user.A0180;
                newUser.E0394 = user.E0394;
                newUser.E0368 = user.E0368;
                newUser.PersonPhoto = user.PersonPhoto;
                newUser.A0177 = user.A0177;
                newUser.A0111 = user.A0111;
                newUser.A0107 = user.A0107;
                newUser.C0101 = user.C0101;
                newUser.A0108 = user.A0108;
                newUser.A0121 = user.A0121;
                newUser.A0114 = user.A0114;
                newUser.A0115 = user.A0115;
                newUser.A0109 = user.A0109;
                newUser.A0112 = user.A0112;
                newUser.A0116 = user.A0116;
                newUser.A0117 = user.A0117;
                newUser.A0110 = user.A0110;
                newUser.A0127 = user.A0127;
                newUser.A0128 = user.A0128;
                newUser.C01SS = user.C01SS;
                newUser.C01RV = user.C01RV;
                newUser.C0102 = user.C0102;
                newUser.A0141 = user.A0141;
                newUser.A0142 = user.A0142;
                newUser.A0143 = user.A0143;
                newUser.A0145 = user.A0145;
                newUser.A0146 = user.A0146;
                newUser.A0118 = user.A0118;
                newUser.A0119 = user.A0119;
                newUser.OrgDispOrder = user.OrgDispOrder;
                newUser.A0122 = user.A0122;

                #endregion

                newUser.B0001 = param["id"];
                newUser.UnitID = param["id"];
                newUser.RowID = HCQ2_Common.RowIDHelp.GetNewRowID();
                newUser.PersonID = HCQ2_Common.RowIDHelp.GetNewRowID();
                newUser.create_time = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                newUser.update_time = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                newUser.create_user_id = HCQ2UI_Helper.OperateContext.Current.Usr.user_id.ToString();
                newUser.update_id = HCQ2UI_Helper.OperateContext.Current.Usr.user_id;
                newUser.in_type = "复制";
                newUser.DispOrder = dispOrder;
                if (Add(newUser) > 0)
                    strMsg += "复制成功：" + personName + "；";
                else
                    strMsg += "复制失败：" + personName + "；";
            }
            return true;
        }

        /// <summary>
        /// 办离职
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="strMsg"></param>
        /// <returns></returns>
        public bool HandleRetire(object obj, ref string strMsg)
        {
            bool isAccess = false;
            FormCollection param = (FormCollection)obj;
            JArray json = JArray.Parse(param["rows"]);
            string retire_time = param["retire_time"];
            StringBuilder sbSql = new StringBuilder();
            //开始移动
            foreach (JObject item in json)
            {
                sbSql.AppendFormat("update A01 set retire_time='{0}',retire_handle_user='{1}' where PersonID='{2}';",
                    retire_time, HCQ2UI_Helper.OperateContext.Current.Usr.user_id, item["PersonID"]);
                strMsg += "办理离职成功：" + item["A0101"].ToString() + "；";
            }
            isAccess = HCQ2_Common.SQL.SqlHelper.ExecuteNonQuery(sbSql.ToString()) > 0;
            if (!isAccess)
                strMsg = "办理失败！";
            return isAccess;
        }

        /// <summary>
        /// 判断目标单位是否存在数组中的人员
        /// </summary>
        /// <param name="json"></param>
        /// <param name="unit_id"></param>
        /// <param name="msg"></param>
        /// <returns></returns>
        public bool isPersonExixts(JArray json, string unit_id, out string msg)
        {
            msg = "";
            var data = GetA01Info().Where(o => o.UnitID == unit_id);
            foreach (JObject item in json)
            {
                string personName = item["A0101"].ToString();
                string identifyCode = item["A0177"].ToString();
                data = data.Where(o => o.A0177 == identifyCode);
                if (data.Count() > 0)
                {
                    msg = "身份证号码为：" + identifyCode + "在目标单位已经存在";
                    break;
                }
            }
            return msg.Length == 0;
        }

        /// <summary>
        /// API接口新增用户
        /// </summary>
        /// <param name="person"></param>
        /// <param name="RowID"></param>
        /// <returns></returns>
        public bool ApiAddPerson(HCQ2_Model.WebApiModel.ParamModel.PersonModel person, ref string PersonID)
        {
            A01 a = new A01();
            a.PClassID = "00001";
            a.DispOrder = GetA01Info().Max(o => o.DispOrder) + 1;
            a.RowID = HCQ2_Common.RowIDHelp.GetNewRowID();
            PersonID = HCQ2_Common.RowIDHelp.GetNewRowID();
            a.PersonID = PersonID;
            a.A0101 = person.person_name;
            a.create_time = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
            a.update_time = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
            a.E0359 = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
            SM_CodeItemsBLL codeItem = new SM_CodeItemsBLL();
            //获取代码型的性别
            if (!string.IsNullOrEmpty(person.person_sex))
            {
                a.A0107 = person.person_sex;
            }

            //获取代码型的民族
            if (!string.IsNullOrEmpty(person.person_nation))
            {
                a.A0121 = person.person_nation;
            }

            //身份证和年龄
            if (!string.IsNullOrEmpty(person.person_cardno))
            {
                a.A0177 = person.person_cardno;
                string Sub_str = person.person_cardno.Substring(6, 8).Insert(4, "-").Insert(7, "-");
                TimeSpan ts = DateTime.Now.Subtract(Convert.ToDateTime(Sub_str));
                a.C0101 = (ts.Days / 365);
            }

            if (!string.IsNullOrEmpty(person.person_birthday))
                a.A0111 = System.Convert.ToDateTime(person.person_birthday);
            a.A0115 = person.person_address;
            a.A0112 = person.person_police;
            if (!string.IsNullOrEmpty(person.person_userlifebegin))
                a.A0116 = System.Convert.ToDateTime(person.person_userlifebegin);
            if (!string.IsNullOrEmpty(person.person_userlifeend))
                a.A0117 = System.Convert.ToDateTime(person.person_userlifeend);
            if (!string.IsNullOrEmpty(person.person_photo))
            {
                a.PersonPhoto = Convert.FromBase64String(person.person_photo);
                //a.PersonPhoto = System.Text.Encoding.Default.GetBytes(person.person_photo);
            }
            if (!string.IsNullOrEmpty(person.iris_data))
                a.A0118 = person.iris_data;
            if (!string.IsNullOrEmpty(person.big_iris_data))
                a.big_iris_data = person.big_iris_data;
            a.in_type = "虹膜";
            switch (person.orgid.Length)
            {
                case 3:
                    a.B0001 = person.orgid;
                    a.UnitID = person.orgid;
                    break;
                case 6:
                    a.B0001 = person.orgid.Substring(0, 3);
                    a.B0002 = person.orgid;
                    a.B000201 = person.orgid;
                    break;
                case 9:
                    a.B0001 = person.orgid.Substring(0, 3);
                    a.B0002 = person.orgid;
                    a.B000201 = person.orgid.Substring(0, 6);
                    a.B000202 = person.orgid;
                    break;
                default:
                    break;
            }
            return base.Add(a) > 0;
        }

        /// <summary>
        /// API编辑工人信息获取数据
        /// </summary>
        /// <param name="person"></param>
        /// <returns></returns>
        public Dictionary<string, object> GetEditPersonDetail(HCQ2_Model.AppModel.EditPerson person)
        {
            Dictionary<string, object> dic = new Dictionary<string, object>();
            StringBuilder sbSql = new StringBuilder();
            sbSql.AppendFormat("select work_type=(select CodeItemName from SM_CodeItems");
            sbSql.AppendFormat(" where CodeID='JA' and CodeItemID=A.E0386),team_name=( ");
            sbSql.AppendFormat(" select dwmc from T_CompProInfo where com_id=a.in_team), ");
            sbSql.AppendFormat(" UnitID,A0177,C0104 from A01 a where UnitID='{0}' and A0177='{1}' ", person.unit_code, person.identify_code);
            DataTable dt = HCQ2_Common.SQL.SqlHelper.ExecuteDataTable(sbSql.ToString());

            if (dt == null)
                return dic;

            dic.Add("unit_code", person.unit_code);
            dic.Add("identify_code", person.identify_code);
            dic.Add("work_type", dt.Rows[0]["work_type"]);
            dic.Add("team_name", dt.Rows[0]["team_name"]);
            dic.Add("person_phone", dt.Rows[0]["C0104"]);

            return dic;
        }

        /// <summary>
        /// 删除人员信息
        /// </summary>
        /// <param name="person"></param>
        /// <returns></returns>
        public bool DeletePerson(HCQ2_Model.AppModel.EditPerson person)
        {
            return Delete(o => o.UnitID == person.unit_code && o.A0177 == person.identify_code) > 0;
        }

        /// <summary>
        /// 编辑人员信息
        /// </summary>
        /// <param name="person"></param>
        /// <returns></returns>
        public bool ApiEditPerson(HCQ2_Model.AppModel.EditPersonToSave person)
        {
            T_User user = new T_UserBLL().Select(o => o.user_guid == person.userid).FirstOrDefault();

            A01 worker = new A01();

            StringBuilder sbSql = new StringBuilder();
            if (!string.IsNullOrEmpty(person.work_type))
            {
                sbSql = new StringBuilder();
                sbSql.AppendFormat("select CodeItemName,CodeItemID,JPSign from SM_CodeItems where CodeID='JA'");
                sbSql.AppendFormat(" and CodeItemID in (select distinct E0386 from A01) and Parent<>'.'");
                DataTable dt = HCQ2_Common.SQL.SqlHelper.ExecuteDataTable(sbSql.ToString());
                var data = dt.Select("CodeItemName='" + person.work_type + "'");
                if (data.Count() > 0)
                {
                    worker.E0386 = data.FirstOrDefault()["CodeItemID"].ToString();
                }
            }
            if (!string.IsNullOrEmpty(person.team_name))
            {
                sbSql = new StringBuilder();
                sbSql.AppendFormat("select com_id,dwmc from T_CompProInfo where COMPATH like (");
                sbSql.AppendFormat(" select dwmc from T_CompProInfo where com_id=( ");
                sbSql.AppendFormat(" select in_compay from B01 where UnitID='{0}')) + '%' ", person.unit_code);
                sbSql.AppendFormat(" and dwmc='{0}' ", person.team_name);
                DataTable dt = HCQ2_Common.SQL.SqlHelper.ExecuteDataTable(sbSql.ToString());
                if (dt != null && dt.Rows.Count > 0)
                {
                    worker.in_team = dt.Rows[0]["com_id"].ToString();
                }
            }
            worker.C0104 = person.person_phone;
            worker.update_time = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
            worker.create_user_id = user.user_id.ToString();

            return Modify(worker, o => o.UnitID == person.unit_code && o.A0177 == person.identify_code,
                "E0386", "in_team", "C0104") > 0;
        }

        #endregion

        #region ——————————数据上报 基于项目——————

        private static string xxly = "HVvxulonjCwuD8Dogh20VLZvxKlejeRhr3HLXHlP9tT99q6x54eerLKH0qVDd6b5a7H7nJ0Z2ggc1GkXBYPK9LZN378zQpgy11UlQyIxpFfS0LYiHzGI6zI/YQDwhyNq5kgiOXeYvP6fZIwYKDtwvGx5xSgNtLrfNt3X8t7mFs=";

        /// <summary>
        /// 数据上报组装上报字符串
        /// </summary>
        /// <param name="obj">FormCollection 类型参数</param>
        /// <returns></returns>
        public List<string> UpLoadData(object obj, ref List<string> reComList, ref List<string> reProjectList, string type)
        {
            if (type == "test")
                xxly = "JvHZhv4X3trzG+kzFom8+US5tBs91mq38cv1piRTimR9e/L7j719YhIQ6ttRyO7xt7ljLmpL1Z6+K0vG1V3sZea4/KVyltRQhVRkW9aZb+DW/iMUdjtqQKhkbBIUZgQ2wkqgB7vYd+pGkiwFSPZN7HcE4P96FMpLI6pHAZWsLcA=";
            else
                xxly = "HVvxulonjCwuD8Dogh20VLZvxKlejeRhr3HLXHlP9tT99q6x54eerLKH0qVDd6b5a7H7nJ0Z2ggc1GkXBYPK9LZN378zQpgy11UlQyIxpFfS0LYiHzGI6zI/YQDwhyNq5kgiOXeYvP6fZIwYKDtwvGx5xSgNtLrfNt3X8t7mFs=";

            List<string> strXmlList = new List<string>();
            FormCollection param = (FormCollection)obj;
            JArray comJson = JArray.Parse(param["rows"]);
            string upType = param["upType"];
            StringBuilder sbSql = new StringBuilder();
            //收集上报的项目的ID
            string strUnitID = "";
            foreach (JObject item in comJson)
            {
                if (string.IsNullOrEmpty(strUnitID))
                    strUnitID = item["UnitID"].ToString();
                else
                    strUnitID += "," + item["UnitID"].ToString();
            }
            sbSql.AppendFormat("select * from B01 where UnitID in ({0})", strUnitID);
            DataTable dtUnit = HCQ2_Common.SQL.SqlHelper.ExecuteDataTable(sbSql.ToString());
            List<B01> unitList = HCQ2_Common.Data.DataTableHelper.DataTableToIList<B01>(dtUnit);

            switch (upType)
            {
                case "01":
                    strXmlList = UpLoadGetProjectMess(unitList, ref reComList, ref reProjectList);
                    break;
                case "02":
                    strXmlList = UpLoadGetPersonMess(unitList, ref reComList, ref reProjectList);
                    break;
                case "03":
                    strXmlList = UpLoadGetPersonPhoto(unitList, ref reComList, ref reProjectList);
                    break;
                case "04":
                    strXmlList = UpLoadGetPersonCheck(unitList, ref reComList, ref reProjectList);
                    break;
                case "05":
                    strXmlList = UpLoadGetPersonWage(unitList, ref reComList, ref reProjectList);
                    break;
                case "06":
                    strXmlList = UpLoadGetDeWage(strUnitID, ref reComList, ref reProjectList);
                    break;
                case "07":
                    strXmlList = UpLoadPersonDeWage(unitList, ref reComList, ref reProjectList);
                    break;
                case "08":
                    strXmlList = UpLoadPersonFile(unitList, ref reComList, ref reProjectList);
                    break;
                case "09":
                    strXmlList = UpLoadPayAccount(unitList, ref reComList, ref reProjectList);
                    break;
                default:
                    break;
            }

            return strXmlList;
        }

        #region 企业项目上报XML字符串拼接
        /// <summary>
        /// 企业信息XML字符串拼接
        /// </summary>
        /// <param name="comList"></param>
        /// <param name="reComList"></param>
        /// <param name="reProjectList"></param>
        private List<string> UpLoadGetProjectMess(List<B01> unitlist, ref List<string> reComList, ref List<string> reProjectList)
        {
            List<string> xmlList = new List<string>();
            List<T_CompProInfo> comList = new T_CompProInfoBLL().Select(o => o.QXLB == "01");
            foreach (var item in unitlist)
            {
                B01 unit = item;
                unit = GetRealUnit(item);
                string in_cpmany = unit.in_compay;

                var data = comList.Where(o => o.com_id.ToString() == in_cpmany);
                if (data.Count() > 0)
                {
                    T_CompProInfo com = data.FirstOrDefault();
                    string param = "<?xml version=\"1.0\" encoding=\"GBK\"?><p>";
                    param += GetConPanyData(com);
                    param += "<d k=\"vds\">";
                    param += GetProjectData(unit, com);
                    param += "</d>";
                    param += "</p>";
                    reComList.Add(com.dwmc);
                    reProjectList.Add(item.UnitName);
                    xmlList.Add(param);
                }
            }
            return xmlList;
        }

        /// <summary>
        /// 组装企业信息
        /// </summary>
        /// <param name="com"></param>
        /// <returns></returns>
        public string GetConPanyData(T_CompProInfo com)
        {
            string strXml = "";
            strXml += "<s dwbh=\"" + com.com_id + "\" />&#x000A;";
            strXml += "<s dwmc=\"" + com.dwmc + "\" />&#x000A;";
            strXml += "<s tyshxydm=\"" + com.tyshxydm + "\" />&#x000A;";
            strXml += "<s zzjgdm=\"" + com.zzjgdm + "\" />&#x000A;";
            strXml += "<s gsdjzzhm=\"" + com.gsdjzzhm + "\" />&#x000A;";
            strXml += "<s xxly=\"" + xxly + "\" />&#x000A;";
            strXml += "<s gsdjzzzl=\"" + com.gsdjzzzl + "\" />&#x000A;";
            strXml += "<s gsdjyxqxqs=\"" + com.gsdjyxqxqs + "\" />&#x000A;";
            strXml += "<s qsdjyxqxzz=\"" + com.qsdjyxqxzz + "\" />&#x000A;";
            strXml += "<s shbxdjzbm=\"" + com.Shbxdjzbm + "\" />&#x000A;";
            strXml += "<s fddbrxm=\"" + com.Fddbrxm + "\" />&#x000A;";
            strXml += "<s fddbrsfzhm=\"" + com.Fddbrsfzhm + "\" />&#x000A;";
            strXml += "<s fddbrdh=\"" + com.Fddbrdh + "\" />&#x000A;";
            strXml += "<s dwlx=\"" + com.Dwlx + "\" />&#x000A;";
            strXml += "<s jjlx=\"" + com.Jjlx + "\" />&#x000A;";
            strXml += "<s lsgx=\"" + com.Lsgx + "\" />&#x000A;";
            strXml += "<s jyfs=\"" + com.Jyfs + "\" />&#x000A;";
            strXml += "<s zczb=\"" + com.Zczb + "\" />&#x000A;";
            strXml += "<s zyfw=\"" + com.ZYFW + "\" />&#x000A;";
            strXml += "<s jyfw=\"" + com.JYFW + "\" />&#x000A;";
            strXml += "<s xzqhdm=\"" + com.XZQHDM + "\" />&#x000A;";
            strXml += "<s djzclx=\"" + com.DJZCLX + "\" />&#x000A;";
            strXml += "<s fddbrzw=\"" + com.FDDBRZW + "\" />&#x000A;";
            strXml += "<s dwfzrxm=\"" + com.DWFZRXM + "\" />&#x000A;";
            strXml += "<s dwfzrzw=\"" + com.DWFZRZW + "\" />&#x000A;";
            strXml += "<s dwfzrdh=\"" + com.DWFZRDH + "\" />&#x000A;";
            strXml += "<s zcdz=\"" + com.ZCDZ + "\" />&#x000A;";
            strXml += "<s lzfzr=\"" + com.LZFZR + "\" />&#x000A;";
            strXml += "<s lzfzrsfzhm=\"" + com.LZFZRSFZHM + "\" />&#x000A;";
            strXml += "<s lzfzrzw=\"" + com.LZFZRZW + "\" />&#x000A;";
            strXml += "<s lzfzrdh=\"" + com.LZFZRDH + "\" />&#x000A;";
            strXml += "<s sshy=\"" + com.SSHY + "\" />&#x000A;";
            strXml += "<s dwqtlxfs=\"" + com.DWQTLXFS + "\" />&#x000A;";
            strXml += "<s lxr=\"" + com.LXR + "\" />&#x000A;";
            strXml += "<s lxdh=\"" + com.LXDH + "\" />&#x000A;";
            strXml += "<s bgdz=\"" + com.BGDZ + "\" />&#x000A;";
            strXml += "<s yzbm=\"" + com.YZBM + "\" />&#x000A;";
            strXml += "<s dwjbzhkhyh=\"" + com.DWJBZHKHYH + "\" />&#x000A;";
            strXml += "<s dwjbzhkhmc=\"" + com.DWJBZHKHMC + "\" />&#x000A;";
            strXml += "<s dwjbzhzh=\"" + com.DWJBZHZH + "\" />&#x000A;";
            strXml += "<s czhm=\"" + com.CZHM + "\" />&#x000A;";
            strXml += "<s dzyx=\"" + com.DZYX + "\" />&#x000A;";
            strXml += "<s wz=\"" + com.WZ + "\" />&#x000A;";
            strXml += "<s jgzsbh=\"" + com.JGZSBH + "\" />&#x000A;";
            strXml += "<s lyyjy=\"" + com.LYYJY + "\" />&#x000A;";
            strXml += "<s jglb=\"" + com.JGLB + "\" />&#x000A;";
            if (!string.IsNullOrEmpty(com.SSWG))
            {
                if (com.SSWG.Length == 2)
                    strXml += "<s sswg=\"" + com.SSWG + "000000" + "\" />&#x000A;";
                if (com.SSWG.Length == 4)
                    strXml += "<s sswg=\"" + com.SSWG + "0000" + "\" />&#x000A;";
                if (com.SSWG.Length == 6)
                    strXml += "<s sswg=\"" + com.SSWG + "00" + "\" />&#x000A;";
            }
            else
                strXml += "<s sswg=\"" + com.SSWG + "\" />&#x000A;";
            strXml += "<s dwmcpy=\"" + com.DWMCPY + "\" />&#x000A;";
            strXml += "<s fddbrzjhm=\"" + com.FDDBRZJHM + "\" />&#x000A;";
            strXml += "<s zgbm=\"" + com.ZGBM + "\" />&#x000A;";
            strXml += "<s isylwpqjyxm=\"" + com.tiISYLWPQJYXMtle + "\" />&#x000A;";
            strXml += "<s bz=\"" + com.BZ + "\" />&#x000A;";
            strXml += "<s ssks=\"" + com.SSKS + "\" />&#x000A;";
            strXml += "<s czrxm=\"" + com.CZRXM + "\" />&#x000A;";
            strXml += "<s czrdz=\"" + com.CZRDZ + "\" />&#x000A;";
            strXml += "<s czrlxdh=\"" + com.CZRLXDH + "\" />&#x000A;";
            strXml += "<s zlqx=\"" + com.ZLQX + "\" />&#x000A;";
            strXml += "<s czrfbdr=\"" + com.CZRFBDR + "\" />&#x000A;";
            strXml += "<s isyyzx=\"" + com.ISYYZX + "\" />&#x000A;";
            strXml += "<s yrdwwhsj=\"\" />&#x000A;";//用人单位维护日期
            strXml += "<s sjdw=\"" + com.SJDW + "\" />&#x000A;";
            strXml += "<s lzjbrxm=\"" + com.LZJBRXM + "\" />&#x000A;";
            strXml += "<s lzjbrdh=\"" + com.LZJBRDH + "\" />&#x000A;";
            strXml += "<s ldjcbh=\"" + com.LDJCBH + "\" />&#x000A;";
            strXml += "<s stdjzh=\"" + com.STDJZH + "\" />&#x000A;";
            strXml += "<s sjdwmc=\"" + com.Sjdwmc + "\" />&#x000A;";
            return strXml;
        }

        /// <summary>
        /// 组装项目信息
        /// </summary>
        /// <param name="project"></param>
        /// <returns></returns>
        public string GetProjectData(B01 dtProject, T_CompProInfo com)
        {
            string strXml = "";
            strXml += " <r ";
            strXml += " xmbh=\"" + dtProject.UnitID + "\" ";
            strXml += " xmmc=\"" + dtProject.UnitName + "\" ";
            strXml += " xxly=\"" + xxly + "\" ";
            strXml += " fbr=\"" + dtProject.FBR + "\" ";
            strXml += " cbr=\"" + dtProject.CBR + "\" ";
            strXml += " gcdd=\"" + dtProject.B0112 + "\" ";
            strXml += " gclxpzwh=\"" + dtProject.GCLXPZWH + "\" ";
            strXml += " zjly=\"" + dtProject.ZJLY + "\" ";
            strXml += " htbh=\"" + dtProject.HTBH + "\" ";
            strXml += " zbbh=\"" + dtProject.ZBBH + "\" ";

            if (!string.IsNullOrEmpty(dtProject.B0109.ToString()))
                strXml += " xmjhkgrq=\"" + HCQ2_Common.DateHelper.GetCSTDate(dtProject.B0109.ToString()) + "\" ";
            else
                strXml += " xmjhkgrq=\"\" ";
            if (!string.IsNullOrEmpty(dtProject.B0110.ToString()))
                strXml += " xmjhjgrq=\"" + HCQ2_Common.DateHelper.GetCSTDate(dtProject.B0110.ToString()) + "\" ";
            else
                strXml += " xmjhjgrq=\"\" ";

            strXml += " xmjhzgq=\"\" ";
            if (dtProject.B0114 > 0)
            {
                strXml += " qyhtj=\"" + dtProject.B0114 * 10000 + "\" ";
            }
            else
            {
                strXml += " qyhtj=\"\" ";
            }
            strXml += " cbrxmjlxm=\"" + dtProject.CBRXMJLXM + "\" ";
            strXml += " cbrxmjlzc=\"" + dtProject.CBRXMJLZC + "\" ";
            strXml += " cbrxmjlsfzh=\"" + dtProject.CBRXMJLSFZH + "\" ";
            strXml += " cbrxmjlzcjzszgzsbh=\"" + dtProject.CBRXMJLZCJZSZGZSBH + "\" ";
            strXml += " cbrxmjlzcjzszszcbh=\"" + dtProject.CBRXMJLZCJZSZSZCBH + "\" ";
            strXml += " cbrxmjlzcjzszyyzh=\"" + dtProject.CBRXMJLZCJZSZYYZH + "\" ";

            if (!string.IsNullOrEmpty(dtProject.XMHTQDRQ.ToString()))
                strXml += " xmhtqdrq=\"" + HCQ2_Common.DateHelper.GetCSTDate(dtProject.XMHTQDRQ.ToString()) + "\" ";
            else
                strXml += " xmhtqdrq=\"\" ";

            strXml += " fbrzz=\"" + dtProject.FBRZZ + "\" ";
            strXml += " fbrdh=\"" + dtProject.FBRDH + "\" ";
            strXml += " fbrfddbr=\"" + dtProject.FBRFDDBR + "\" ";
            strXml += " fbrcz=\"" + dtProject.FBRCZ + "\" ";
            strXml += " fbrkhyh=\"" + dtProject.FBRKHYH + "\" ";
            strXml += " fbryhzh=\"" + dtProject.FBRYHZH + "\" ";
            strXml += " fbryzbm=\"" + dtProject.FBRYZBM + "\" ";
            strXml += " fbrdz=\"" + dtProject.FBRDZ + "\" ";
            strXml += " cbrzz=\"" + dtProject.CBRZZ + "\" ";
            strXml += " cbrdh=\"" + dtProject.CBRDH + "\" ";
            strXml += " cbrfddbr=\"" + dtProject.CBRFDDBR + "\" ";
            strXml += " cbrcz=\"" + dtProject.CBRCZ + "\"";
            strXml += " cbrkhyh=\"" + dtProject.CBRKHYH + "\" ";
            strXml += " cbryhzh=\"" + dtProject.CBRYHZH + "\" ";
            strXml += " cbryzbm=\"" + dtProject.CBRYZBM + "\" ";
            strXml += " cbrdz=\"" + dtProject.CBRDZ + "\" ";
            strXml += " ssxzzgbm=\"" + dtProject.SSXZZGBM + "\" ";
            strXml += " basblx=\"" + dtProject.BASBLX + "\" ";
            strXml += " basbbh=\"" + dtProject.BASBBH + "\" ";

            if (!string.IsNullOrEmpty(dtProject.SSWG))
            {
                if (dtProject.SSWG.Length == 2)
                    strXml += " sswg=\"" + dtProject.SSWG + "000000" + "\" ";
                else if (dtProject.SSWG.Length == 4)
                    strXml += " sswg=\"" + dtProject.SSWG + "0000" + "\" ";
                else if (dtProject.SSWG.Length == 6)
                    strXml += " sswg=\"" + dtProject.SSWG + "00" + "\" ";
                else
                    strXml += " sswg=\"\" ";
            }

            strXml += " xmcjr=\"" + dtProject.XMCJR + "\" ";
            strXml += " fxmid=\"" + dtProject.FXMID + "\" ";
            strXml += " ssdwyhid=\"" + dtProject.in_compay + "\" ";
            strXml += " sfcjgsbx=\"" + dtProject.SFCJGSBX + "\" ";
            if (dtProject.B0116 > 0)
            {
                strXml += " xmbzjycje=\"" + (dtProject.B0116 * 10000) + "\" ";
            }
            else
            {
                strXml += " xmbzjycje=\"\" ";
            }
            strXml += " lzzgy=\"" + dtProject.LZZGYYI + "\" ";
            strXml += " fxrq=\"" + dtProject.FXRQ + "\" ";
            strXml += " zzjgdm=\"" + dtProject.ZZJGDM + "\" ";
            strXml += " gsdjzzzl=\"" + dtProject.GSDJZZZL + "\" ";
            strXml += " gsdjzzhm=\"" + dtProject.GSDJZZHM + "\" ";
            strXml += " shxydm=\"" + dtProject.SHXYDM + "\" ";
            string lsjg = "";
            if (!string.IsNullOrEmpty(dtProject.LSJG))
            {
                if (dtProject.LSJG.Length == 2)
                    lsjg = dtProject.LSJG + "000000";
                if (dtProject.LSJG.Length == 4)
                    lsjg = dtProject.LSJG + "0000";
                if (dtProject.LSJG.Length == 6)
                    lsjg = dtProject.LSJG + "00";
            }
            strXml += " lsjg=\"" + lsjg + "\" ";
            strXml += " />";
            return strXml;
        }

        #endregion

        #region 人员基本信息上报XML字符串拼接

        /// <summary>
        /// 人员上报XML字符串组装
        /// </summary>
        /// <param name="comList"></param>
        /// <param name="reComList"></param>
        /// <param name="reProjectList"></param>
        /// <returns></returns>
        private List<string> UpLoadGetPersonMess(List<B01> unitList, ref List<string> reComList, ref List<string> reProjectList)
        {
            List<string> xmlList = new List<string>();

            List<SM_CodeItems> workerList = new SM_CodeItemsBLL().GetCodeItemByCodeID("JA");
            List<T_ItemCodeMenum> menuList = new T_ItemCodeMenumBLL().GetByItemId(32);

            List<B01> projectList = new B01BLL().GetB01Info();
            A01BLL person = new A01BLL();
            foreach (var UnitItem in unitList)
            {
                B01 unit = UnitItem;
                unit = GetRealUnit(UnitItem);
                string in_cpmany = unit.in_compay;

                List<A01> userList = person.Select(o => o.UnitID == UnitItem.UnitID);
                if (userList.Count() > 0)
                {
                    reComList.Add("");
                    reProjectList.Add(UnitItem.UnitName);
                    string param = "<?xml version=\"1.0\" encoding=\"GBK\"?><p>";
                    param += "<d k=\"vds\">";
                    param += UploadProPerInfo(userList, workerList, menuList, unit.UnitID);
                    param += "</d>";
                    param += "</p>";
                    xmlList.Add(param);
                }
            }

            return xmlList;
        }

        private string UploadProPerInfo(List<A01> userList, List<SM_CodeItems> workerList, List<T_ItemCodeMenum> menuList, string realUnitID)
        {
            string strXml = "";

            foreach (var user in userList)
            {
                strXml += " <r ";
                strXml += " ryid=\"" + user.PersonID + "\"";
                strXml += " xm=\"" + user.A0101 + "\"";
                strXml += " sfzhm=\"" + user.A0177 + "\"";
                strXml += " xmbh=\"" + realUnitID + "\"";
                strXml += " xxly=\"" + xxly + "\"";
                strXml += " XB=\"" + user.A0107 + "\"";
                strXml += " NL=\"" + user.C0101 + "\"";
                strXml += " SSDWLB=\"" + user.SSDWLB + "\"";
                strXml += " SSDWMC=\"\"";
                strXml += " SSDWZW=\"" + user.SSDWZW + "\"";
                if (!string.IsNullOrEmpty(user.E0386))
                {
                    var data = workerList.Where(o => o.CodeItemID == user.E0386).FirstOrDefault();
                    var dataWork = menuList.Where(o => o.code_name == data.CodeItemName);
                    if (dataWork.Count() > 0)
                    {
                        strXml += " GZ=\"" + dataWork.FirstOrDefault().code_value + "\"";
                    }
                    else
                    {
                        strXml += " GZ=\"5000\"";//其他工种
                    }
                }
                else
                    strXml += " GZ=\"5000\"";//其他工种

                strXml += " GZGZHDFS=\"" + user.GZGZHDFS + "\"";
                strXml += " GZGZHDBZ=\"" + user.GZGZHDBZ + "\"";
                strXml += " JKZK=\"\"";
                strXml += " SSBZ=\"" + user.SSBZ + "\"";
                strXml += " SFBZFZR=\"" + user.SFBZFZR + "\"";
                strXml += " SFQDJYYGHT=\"" + user.SFQDJYYGHT + "\"";

                //是否在职
                if (!string.IsNullOrEmpty(user.retire_time.ToString()))
                {
                    strXml += " Sfzz=\"0\"";
                }
                else
                {
                    strXml += " Sfzz=\"1\"";
                }
                //入职时间
                if (!string.IsNullOrEmpty(user.E0359.ToString()))
                {
                    strXml += " rzsj=\"" + Convert.ToDateTime(user.E0359).ToString("yyyyMMdd") + "\"";
                }
                else
                {
                    strXml += " rzsj=\"\"";
                }
                //离职时间
                if (!string.IsNullOrEmpty(user.retire_time.ToString()))
                {
                    strXml += " lzsj=\"" + Convert.ToDateTime(user.retire_time).ToString("yyyyMMdd") + "\"";
                }
                else
                {
                    strXml += " lzsj=\"\"";
                }
                strXml += " lzyy=\"" + user.lzyy + "\"";
                strXml += " />";
            }

            return strXml;
        }

        #endregion

        #region 人员照片上报

        private List<string> UpLoadGetPersonPhoto(List<B01> unitList, ref List<string> reComList, ref List<string> reProjectList)
        {
            List<string> xmlList = new List<string>();

            List<B01> projectList = new B01BLL().GetB01Info();
            A01BLL person = new A01BLL();

            foreach (var UnitItem in unitList)
            {
                List<A01> userList = person.Select(o => o.UnitID == UnitItem.UnitID);
                if (userList.Count() > 0)
                {
                    reComList.Add("");
                    reProjectList.Add(UnitItem.UnitName);
                    string param = "<?xml version=\"1.0\" encoding=\"GBK\"?><p>";
                    param += "<d k=\"vds\">";
                    param += UploadPhotoInfo(userList);
                    param += "</d>";
                    param += "</p>";
                    xmlList.Add(param);
                }
            }
            return xmlList;
        }

        private string UploadPhotoInfo(List<A01> userList)
        {
            string strXml = "";

            foreach (var user in userList)
            {
                if (user.PersonPhoto != null)
                {
                    strXml += " <r ";
                    strXml += " ryid=\"" + user.PersonID + "\"";
                    strXml += " xxly=\"" + xxly + "\"";
                    if (!string.IsNullOrEmpty(user.E0359.ToString()))
                    {
                        strXml += " Jbsj=\"" + Convert.ToDateTime(user.E0359).ToString("yyyyMMdd") + "\"";
                    }
                    else
                    {
                        strXml += " Jbsj=\"" + DateTime.Now.ToString("yyyyMMdd") + "\"";
                    }
                    strXml += " zp=\"" + Convert.ToBase64String(user.PersonPhoto) + "\"";
                    strXml += " zpname=\"" + user.A0101 + "\"";
                    strXml += " zptype=\"Base64String\"";
                    strXml += " bz=\"\"";
                    strXml += " />";
                }
            }

            return strXml;
        }

        #endregion

        #region 考勤信息上报

        private List<string> UpLoadGetPersonCheck(List<B01> unitList, ref List<string> reComList, ref List<string> reProjectList)
        {
            List<string> xmlList = new List<string>();

            List<B01> projectList = new B01BLL().GetB01Info();
            A01BLL person = new A01BLL();

            foreach (var UnitItem in unitList)
            {
                B01 unit = GetRealUnit(UnitItem);

                List<A01> userList = person.Select(o => o.UnitID == UnitItem.UnitID);
                if (userList.Count() > 0)
                {
                    reComList.Add("");
                    reProjectList.Add(UnitItem.UnitName);
                    string param = "<?xml version=\"1.0\" encoding=\"GBK\"?><p>";
                    param += "<d k=\"vds\">";
                    param += UploadAttends(userList, unit.UnitID);
                    param += "</d>";
                    param += "</p>";
                    xmlList.Add(param);
                }
            }
            return xmlList;
        }

        private string UploadAttends(List<A01> userList, string realUnitID, string checkDate = "")
        {
            string strXml = "";
            string UnitID = userList[0].UnitID;
            List<View_A02> checkList = new View_A02BLL().Select(o => o.UnitID == UnitID);
            foreach (var user in userList)
            {
                var data = checkList.Where(o => o.PersonID == user.PersonID && (o.A0204 == "1" || o.A0203 == "1"));
                if (data.Count() > 0 && !string.IsNullOrEmpty(checkDate))
                {
                    //日期筛选
                    data = data.Where(o => o.A0201.ToString().Substring(0, 7) == checkDate.Replace("-", "/"));
                }
                if (data.Count() > 0)
                {
                    List<View_A02> cUserList = data.ToList();
                    foreach (var item in cUserList)
                    {
                        strXml += " <r ";
                        strXml += " kqid=\"" + item.RowID + "\"";
                        strXml += " ryid=\"" + item.PersonID + "\"";
                        strXml += " xxly=\"" + xxly + "\"";
                        strXml += " xmbh=\"" + realUnitID + "\"";
                        strXml += " sfzh=\"" + item.A0177 + "\"";
                        strXml += " xm=\"" + item.A0101 + "\"";
                        strXml += " kqsj=\"" + HCQ2_Common.DateHelper.GetCSTDate(item.A0201.ToString()) + "\"";
                        strXml += " sbbs=\"" + (item.A0203 == "1" ? 1 : 2) + "\"";
                        strXml += " kqtz=\"9\"";
                        strXml += " kqsbbm=\"\"";
                        strXml += " />";
                    }
                }
            }

            return strXml;
        }

        #endregion

        #region 工资发放信息上报

        private List<string> UpLoadGetPersonWage(List<B01> unitList, ref List<string> reComList, ref List<string> reProjectList)
        {
            List<string> xmlList = new List<string>();

            List<B01> projectList = new B01BLL().GetB01Info();
            A01BLL person = new A01BLL();

            foreach (var UnitItem in unitList)
            {
                List<A01> userList = person.Select(o => o.UnitID == UnitItem.UnitID);
                if (userList.Count() > 0)
                {
                    reComList.Add("");
                    reProjectList.Add(UnitItem.UnitName);
                    string param = "<?xml version=\"1.0\" encoding=\"GBK\"?><p>";
                    param += "<d k=\"vds\">";
                    param += UploadWage(UnitItem);
                    param += "</d>";
                    param += "</p>";
                    xmlList.Add(param);
                }
            }
            return xmlList;
        }

        private string UploadWage(B01 Project)
        {
            string strXml = "";
            string UnitID = Project.UnitID;
            List<WGJG02> wageList = new WGJG02BLL().Select(o => o.UnitID == UnitID);

            StringBuilder sbSql = new StringBuilder();
            sbSql.AppendFormat(" select GZFFZHSSYH=(select GZFFZHSSYH from B01 where UnitID=a.UnitID),");
            sbSql.AppendFormat(" NMGZHSSYH=(select NMGZHSSYH from A01 where PersonID=a.PersonID),");
            sbSql.AppendFormat(" NMGZHZH=(select A0146 from A01 where PersonID=a.PersonID),");
            sbSql.AppendFormat(" FFZQ=(select GZGZHDFS from A01 where PersonID=a.PersonID),*");
            sbSql.AppendFormat(" from WGJG02 a where UnitID='{0}'", UnitID);
            DataTable dt = HCQ2_Common.SQL.SqlHelper.ExecuteDataTable(sbSql.ToString());

            if (dt.Rows.Count > 0)
            {
                B01 unit = GetRealUnit(Project);

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    DataRow dr = dt.Rows[i];

                    strXml += " <r ";
                    strXml += " gzffid=\"" + dr["RowID"] + "\"";
                    strXml += " ryid=\"" + dr["PersonID"] + "\"";
                    strXml += " xmbh=\"" + unit.UnitID + "\"";
                    strXml += " xxly=\"" + xxly + "\"";
                    strXml += " xm=\"" + dr["A0101"] + "\"";
                    strXml += " sfzh=\"" + dr["A0177"] + "\"";
                    strXml += " sfgz=\"" + dr["WGJG0208"] + "\"";
                    strXml += " yfgz=\"" + dr["WGJG0207"] + "\"";
                    strXml += " sm=\" \"";
                    strXml += " ffzq=\"" + dr["FFZQ"] + "\"";
                    strXml += " ffrq=\"" + HCQ2_Common.DateHelper.GetCSTDate(dr["WGJG0202"].ToString()) + "\"";
                    strXml += " ffxh=\"" + Convert.ToDateTime(dr["WGJG0201"].ToString()).ToString("yyyyMM") + "\"";
                    strXml += " jsl=\"" + dr["WGJG0208"] + "\"";
                    strXml += " gzffzhssyh=\"" + dr["GZFFZHSSYH"] + "\"";
                    strXml += " nmgzhssyh=\"" + dr["NMGZHSSYH"] + "\"";
                    strXml += " nmgzhzh=\"" + dr["NMGZHZH"] + "\"";
                    strXml += " qrbz=\"" + dr["WGJG0211"] + "\"";
                    strXml += " grhdbz=\"" + dr["WGJG0211"] + "\"";
                    strXml += " wgf=\"\"";
                    strXml += " shf=\"\"";
                    strXml += " />";
                }
            }

            return strXml;
        }

        #endregion

        #region 欠薪信息上报

        private List<string> UpLoadGetDeWage(string strCom, ref List<string> reComList, ref List<string> reProjectList)
        {
            List<string> xmlList = new List<string>();

            StringBuilder sbSql = new StringBuilder();
            sbSql.AppendFormat(" select qxid=c.RowID,dwid=a.com_id,xmbh=b.UnitID,DWMC=a.dwmc,");
            sbSql.AppendFormat(" DWLX=a.Dwlx,XMMC=b.UnitName,XMDZ=b.B0112,QXLB=a.QXLB,LDZRS=c.People2,");
            sbSql.AppendFormat(" QYFZRXM=a.Fddbrxm,LXDH=a.Fddbrdh,QXZRS=c.People,QXZJE=c.QXTJ01,");
            sbSql.AppendFormat(" DYSQXRS=c.People,DYSQXJE=c.QXTJ01,JGBMZRR='',ZRLD='',BZ='',");
            sbSql.AppendFormat(" DJRQ='',XJSPYJ='',XJSPSM='',SJSPYJ='',SJSPSM='',qsny='2017-09-01 00:00:00',");
            sbSql.AppendFormat(" zzny='9999-12-31 00:00:00',sbbz='',sbrq='' from T_CompProInfo a inner join B01 b");
            sbSql.AppendFormat(" on a.com_id=b.in_compay inner join View_QXTJ c");
            sbSql.AppendFormat(" on b.UnitID=c.UnitID where c.QXTJ01 > 0 and b.UnitID in ({0})", strCom);
            DataTable dt = HCQ2_Common.SQL.SqlHelper.ExecuteDataTable(sbSql.ToString());

            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    DataRow dr = dt.Rows[i];
                    reComList.Add(dr["DWMC"].ToString());
                    reProjectList.Add(dr["XMMC"].ToString());
                    string param = "<?xml version=\"1.0\" encoding=\"GBK\"?><p>";
                    param += "<d k=\"vds\">";
                    param += UploadProBackPayInfo(dr);
                    param += "</d>";
                    param += "</p>";
                    xmlList.Add(param);
                }
            }

            return xmlList;
        }

        private string UploadProBackPayInfo(DataRow dr)
        {
            string strXml = "";

            strXml += " <r ";
            strXml += " qxid=\"" + dr["qxid"] + "\"";
            strXml += " dwid=\"" + dr["dwid"] + "\"";

            //项目编号处理
            if (!string.IsNullOrEmpty(dr["xmbh"].ToString()))
            {
                string strSql = "select upLoadId from B01 where UnitID='" + dr["xmbh"] + "'";
                string xxbh = dr["xmbh"].ToString();
                B01 unit = new B01BLL().Select(o => o.UnitID == xxbh).FirstOrDefault();
                if (!string.IsNullOrEmpty(unit.upLoadId))
                    strXml += " xmbh=\"" + unit.upLoadId + "\"";
                else
                    strXml += " xmbh=\"" + dr["xmbh"] + "\"";
            }
            else
            {
                strXml += " xmbh=\"" + dr["xmbh"] + "\"";
            }

            strXml += " xxly=\"" + xxly + "\"";
            strXml += " dwmc=\"" + dr["DWMC"] + "\"";
            strXml += " dwlx=\"" + dr["DWLX"] + "\"";
            strXml += " xmmc=\"" + dr["XMMC"] + "\"";
            strXml += " xmdz=\"" + dr["XMDZ"] + "\"";
            strXml += " qxlb=\"1\"";
            strXml += " ldzrs=\"" + dr["LDZRS"] + "\"";
            strXml += " qyfzrxm=\"" + dr["QYFZRXM"] + "\"";
            strXml += " lxdh=\"" + dr["LXDH"] + "\"";
            strXml += " qxzrs=\"" + dr["QXZRS"] + "\"";
            strXml += " qxzje=\"" + dr["QXZJE"] + "\"";
            strXml += " dysqxrs=\"" + dr["DYSQXRS"] + "\"";
            strXml += " dysqxje=\"" + dr["DYSQXJE"] + "\"";
            strXml += " jgbmzrr=\"" + dr["JGBMZRR"] + "\"";
            strXml += " zrld=\"" + dr["ZRLD"] + "\"";
            strXml += " bz=\"" + dr["BZ"] + "\"";
            strXml += " djrq=\"" + dr["DJRQ"] + "\"";
            strXml += " xjspyj=\"" + dr["XJSPYJ"] + "\"";
            strXml += " xjspsm=\"" + dr["XJSPSM"] + "\"";
            strXml += " sjspyj=\"" + dr["SJSPYJ"] + "\"";
            strXml += " sjspsm=\"" + dr["SJSPSM"] + "\"";
            strXml += " qsny=\"" + HCQ2_Common.DateHelper.GetCSTDate(dr["qsny"].ToString()) + "\"";
            strXml += " zzny=\"" + HCQ2_Common.DateHelper.GetCSTDate(dr["zzny"].ToString()) + "\"";
            strXml += " sbbz=\"0\"";
            strXml += " sbrq=\"\"";
            strXml += " xmfrspyj=\"\"";
            strXml += " xmfrspsm=\"\"";
            strXml += " xmfrsprq=\"\"";
            strXml += " />";

            return strXml;
        }

        #endregion

        #region 个人详细欠薪上报

        private List<string> UpLoadPersonDeWage(List<B01> unitList, ref List<string> reComList, ref List<string> reProjectList)
        {
            List<string> xmlList = new List<string>();
            StringBuilder sbSql = new StringBuilder();


            foreach (var UnitItem in unitList)
            {
                sbSql = new StringBuilder();
                sbSql.AppendFormat(" select deMoney=(WGJG0207-WGJG0208),");
                sbSql.AppendFormat(" nation=(select A0107 from A01 where PersonID=a.PersonID),");
                sbSql.AppendFormat(" tellPhone=(select C0104 from A01 where PersonID=a.PersonID),");
                sbSql.AppendFormat(" xxmc=(select RowID from B01 where UnitID=a.UnitID),");
                sbSql.AppendFormat(" unitname=(select unitName from B01 where UnitID=a.UnitID),");
                sbSql.AppendFormat(" * from WGJG02 a where WGJG0208-WGJG0207<0 and UnitID = {0}", UnitItem.UnitID);
                DataTable dt = HCQ2_Common.SQL.SqlHelper.ExecuteDataTable(sbSql.ToString());

                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        DataRow dr = dt.Rows[i];
                        reComList.Add("");
                        reProjectList.Add(dr["unitname"].ToString());
                        string param = "<?xml version=\"1.0\" encoding=\"GBK\"?><p>";
                        param += "<d k=\"vds\">";
                        param += DeWageDetail(dr);
                        param += "</d>";
                        param += "</p>";
                        xmlList.Add(param);
                    }
                }
            }

            return xmlList;
        }

        private string DeWageDetail(DataRow dr)
        {
            string strXml = "";

            strXml += " <r ";
            strXml += " qxid=\"" + dr["RowID"] + "\"";
            strXml += " ryid=\"" + dr["PersonID"] + "\"";
            strXml += " xm=\"" + dr["A0101"] + "\"";
            strXml += " xxly=\"" + xxly + "\"";
            strXml += " xb=\"" + dr["nation"] + "\"";
            strXml += " sfzh=\"" + dr["A0177"] + "\"";
            strXml += " lxdh=\"" + dr["tellPhone"] + "\"";
            strXml += " ssxmid=\"" + dr["xxmc"] + "\"";
            strXml += " qxje=\"" + dr["deMoney"] + "\"";
            strXml += " qxny=\"\"";
            strXml += " />";

            return strXml;
        }

        #endregion

        #region 上报简易劳动合同

        private List<string> UpLoadPersonFile(List<B01> unitList, ref List<string> reComList, ref List<string> reProjectList)
        {
            List<string> xmlList = new List<string>();
            StringBuilder sbSql = new StringBuilder();

            foreach (var UnitItem in unitList)
            {
                sbSql = new StringBuilder();
                sbSql.AppendFormat("select * from A01 where scan_contract<>'' and UnitID='{0}'", UnitItem.UnitID);
                DataTable dt = HCQ2_Common.SQL.SqlHelper.ExecuteDataTable(sbSql.ToString());
                if (dt.Rows.Count > 0)
                {
                    reComList.Add("");
                    reProjectList.Add(UnitItem.UnitName);
                    string param = "<?xml version=\"1.0\" encoding=\"GBK\"?><p>";
                    param += "<d k=\"vds\">";
                    param += UpLoadFile(dt);
                    param += "</d>";
                    param += "</p>";
                    xmlList.Add(param);
                }
            }

            return xmlList;
        }

        private string UpLoadFile(DataTable dt)
        {
            string strXml = "";

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DataRow dr = dt.Rows[i];
                strXml += " <r ";
                strXml += " Lsh=\"" + DateTime.Now.ToString("yyyyMMddHHmmss") + "\"";
                strXml += " ryid=\"" + dr["PersonID"] + "\"";
                strXml += " xxly=\"" + xxly + "\"";
                strXml += " Jbsj=\"" + HCQ2_Common.DateHelper.GetCSTDate(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")) + "\"";
                strXml += " filecontent=\"" + Convert.ToBase64String(HCQ2_Common.ImageHelper.ImageToBytes(HttpContext.Current.Server.MapPath(dr["scan_contract"].ToString()))) + "\"";
                strXml += " filename=\"" + dr["A0101"] + "劳动合同\"";
                strXml += " filetype=\"Base64String\"";
                strXml += " bz=\"\"";
                strXml += " />";
            }

            return strXml;
        }

        #endregion

        #region 上报项目工资专户

        private List<string> UpLoadPayAccount(List<B01> dataUnit, ref List<string> reComList, ref List<string> reProjectList)
        {
            List<string> xmlList = new List<string>();
            StringBuilder sbSql = new StringBuilder();
            List<T_PayAccount> projectList = new T_PayAccountBLL().GetPayAccount();
            foreach (var unit in dataUnit)
            {
                B01 reUnit = GetRealUnit(unit);

                var data = projectList.Where(o => o.UnitID.Equals(unit.UnitID));
                if (data.Count() > 0)
                {
                    reComList.Add("");
                    reProjectList.Add(unit.UnitName);
                    string param = "<?xml version=\"1.0\" encoding=\"GBK\"?><p>";
                    param += "<d k=\"vds\">";
                    foreach (var project in data)
                    {
                        param += GetPayAccountXml(project, reUnit.UnitID);
                    }
                    param += "</d>";
                    param += "</p>";
                    xmlList.Add(param);
                }
            }

            return xmlList;
        }

        private string GetPayAccountXml(T_PayAccount pay, string realUnitID)
        {
            string strXml = "";

            strXml += " <r ";
            strXml += " xmbh=\"" + realUnitID + "\"";
            strXml += " ssyh=\"" + pay.ssyh + "\"";
            strXml += " xxly=\"" + xxly + "\"";
            strXml += " khmc=\"" + pay.khmc + "\"";
            strXml += " zh=\"" + pay.zh + "\"";
            strXml += " khh=\"" + pay.khh + "\"";
            strXml += " pzzl=\"" + pay.pzzl + "\"";
            strXml += " pzhm=\"" + pay.pzhm + "\"";
            strXml += " ye=\"" + pay.ye + "\"";
            strXml += " />";

            return strXml;
        }

        #endregion

        /// <summary>
        /// 根据项目信息获取真实的项目
        /// </summary>
        /// <param name="unit"></param>
        /// <returns></returns>
        private static B01 GetRealUnit(B01 unit)
        {
            B01 rUnit = unit;
            if (!string.IsNullOrEmpty(unit.upLoadId))
            {
                string unitid = unit.upLoadId;
                List<B01> allUnit = new B01BLL().Select(o => o.UnitID.Length == 3);
                rUnit = allUnit.Where(o => o.UnitID == unitid).FirstOrDefault();
            }
            return rUnit;
        }

        /// <summary>
        /// 获取上报真是项目编号
        /// </summary>
        /// <param name="unit_id"></param>
        /// <returns></returns>
        private static string GetRealUnitID(string unit_id)
        {
            string UnitID = unit_id;

            B01 unit = new B01BLL().GetByUnitID(unit_id);
            if (!string.IsNullOrEmpty(unit.upLoadId))
                UnitID = unit.UnitID;

            return UnitID;
        }

        /// <summary>
        /// 人员基本信息、照片、合同上报
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="comList"></param>
        /// <param name="projectList"></param>
        /// <param name="type"></param>
        /// <param name="userList"></param>
        /// <returns></returns>
        public List<string> UpLoadDataFormPerson(object obj, ref List<string> comList, ref List<string> projectList, string type, ref List<A01> userList, string unit_id)
        {
            if (type == "test")
                xxly = "JvHZhv4X3trzG+kzFom8+US5tBs91mq38cv1piRTimR9e/L7j719YhIQ6ttRyO7xt7ljLmpL1Z6+K0vG1V3sZea4/KVyltRQhVRkW9aZb+DW/iMUdjtqQKhkbBIUZgQ2wkqgB7vYd+pGkiwFSPZN7HcE4P96FMpLI6pHAZWsLcA=";
            else
                xxly = "HVvxulonjCwuD8Dogh20VLZvxKlejeRhr3HLXHlP9tT99q6x54eerLKH0qVDd6b5a7H7nJ0Z2ggc1GkXBYPK9LZN378zQpgy11UlQyIxpFfS0LYiHzGI6zI/YQDwhyNq5kgiOXeYvP6fZIwYKDtwvGx5xSgNtLrfNt3X8t7mFs=";

            List<string> strXmlList = new List<string>();
            FormCollection param = (FormCollection)obj;
            JArray comJson = JArray.Parse(param["rows"]);
            string upType = param["upType"];

            StringBuilder sbSql = new StringBuilder();
            //收集上报的项目的ID
            string strPersonID = "";
            foreach (JObject item in comJson)
            {
                A01 u = new A01();
                u.PersonID = item["PersonID"].ToString();
                u.A0101 = item["A0101"].ToString();
                u.A0177 = item["A0177"].ToString();
                u.UnitID = item["UnitID"].ToString();
                userList.Add(u);

                if (string.IsNullOrEmpty(strPersonID))
                    strPersonID = "'" + item["PersonID"].ToString() + "'";
                else
                    strPersonID += ",'" + item["PersonID"].ToString() + "'";
            }
            sbSql.AppendFormat("select * from A01 where PersonID in ({0})", strPersonID);
            DataTable drUser = HCQ2_Common.SQL.SqlHelper.ExecuteDataTable(sbSql.ToString());
            List<A01> user = HCQ2_Common.Data.DataTableHelper.DataTableToIList<A01>(drUser);

            string realUnitID = GetRealUnitID(unit_id);
            List<string> xmlList = new List<string>();

            string strParam = "";
            comList.Add("");
            projectList.Add("");
            strParam += "<?xml version=\"1.0\" encoding=\"GBK\"?><p>";
            strParam += "<d k=\"vds\">";
            switch (upType)
            {
                case "02":
                    List<SM_CodeItems> workerList = new SM_CodeItemsBLL().GetCodeItemByCodeID("JA");
                    List<T_ItemCodeMenum> menuList = new T_ItemCodeMenumBLL().GetByItemId(32);
                    strParam += UploadProPerInfo(user, workerList, menuList, realUnitID);
                    break;
                case "03":
                    strParam += UploadPhotoInfo(user);
                    break;
                case "04":
                    strParam += UploadAttends(user, realUnitID, param["dateSelect"]);
                    break;
                case "08":
                    sbSql = new StringBuilder();
                    sbSql.AppendFormat("select * from A01 where scan_contract<>'' and PersonID in ({0})", strPersonID);
                    DataTable dt = HCQ2_Common.SQL.SqlHelper.ExecuteDataTable(sbSql.ToString());
                    strParam += UpLoadFile(dt);
                    break;
                default:
                    break;
            }
            strParam += "</d>";
            strParam += "</p>";
            xmlList.Add(strParam);

            return xmlList;
        }

        /// <summary>
        /// 获取单人上报字符串
        /// </summary>
        /// <param name="userList"></param>
        /// <param name="workerList"></param>
        /// <param name="menuList"></param>
        /// <param name="realUnitID"></param>
        /// <returns></returns>
        public string GetStrtoUpLoad(List<A01> user, List<SM_CodeItems> workerList, List<T_ItemCodeMenum> menuList, string realUnitID, string upType)
        {
            string strParam = "";
            strParam += "<?xml version=\"1.0\" encoding=\"GBK\"?><p>";
            strParam += "<d k=\"vds\">";
            switch (upType)
            {
                case "02":
                    strParam += UploadProPerInfo(user, workerList, menuList, realUnitID);
                    break;
                case "03":
                    strParam += UploadPhotoInfo(user);
                    break;
                case "08":
                    StringBuilder sbSql = new StringBuilder();
                    sbSql.AppendFormat("select * from A01 where scan_contract<>'' and PersonID = '{0}'", user[0].PersonID);
                    DataTable dt = HCQ2_Common.SQL.SqlHelper.ExecuteDataTable(sbSql.ToString());
                    if (dt != null)
                        strParam += UpLoadFile(dt);
                    break;
                default:
                    break;
            }
            strParam += "</d>";
            strParam += "</p>";
            return strParam;
        }

        /// <summary>
        /// 改写人员相关上报状态
        /// </summary>
        /// <param name="userList"></param>
        /// <param name="upType"></param>
        public void ChangePersonUpLoad(List<A01> userList, string upType)
        {
            string updateColumn = "";
            A01 user = new A01();
            switch (upType)
            {
                case "02":
                    user.if_uparchive = "1";
                    updateColumn = "if_uparchive";
                    break;
                case "03":
                    user.if_upphoto = "1";
                    updateColumn = "if_upphoto";
                    break;
                case "04":
                    return;
                case "08":
                    user.if_upscanfile = "1";
                    updateColumn = "if_upscanfile";
                    break;
                default:
                    break;
            }
            string strUserName = "";
            foreach (var item in userList)
            {
                if (string.IsNullOrEmpty(strUserName))
                    strUserName = item.A0101 + "(" + item.A0177 + ")";
                else
                    strUserName += "," + item.A0101 + "(" + item.A0177 + ")";
                Modify(user, o => o.PersonID == item.PersonID, updateColumn);
            }
            new BB_UpDataLogBLL().InsertDataLog(upType, strUserName, 1, userList[0].UnitID);
        }

        /// <summary>
        /// 人员上报处理
        /// </summary>
        /// <param name="UnitID"></param>
        /// <param name="IdentifyCode"></param>
        public void UpLoadPerson(string UnitID, string IdentifyCode)
        {
            string IndentifyCode = IdentifyCode;
            List<string> strXmlList = new List<string>();
            //GetStrtoUpLoad
            List<A01> userList = Select(o => o.UnitID == UnitID && o.A0177 == IndentifyCode);

            List<SM_CodeItems> workerList = new SM_CodeItemsBLL().GetCodeItemByCodeID("JA");
            List<T_ItemCodeMenum> menuList = new T_ItemCodeMenumBLL().GetByItemId(32);
            B01 Unit = new B01BLL().Select(o => o.UnitID == UnitID).FirstOrDefault();
            string realUnitID = string.IsNullOrEmpty(Unit.upLoadId) ? Unit.UnitID : Unit.UnitID;

            //正式地址
            WebUpData.uddi client2 = new WebUpData.uddi();
            ServicePointManager.ServerCertificateValidationCallback = ValidateServerCertificate;
            client2.Url = "https://222.85.128.67:8088/dwlesbserver/services/uddi?wsdl";
            X509Certificate xs = new X509Certificate("E:\\RSA2008root.cer");
            client2.ClientCertificates.Add(xs);

            //基本信息上报字符串
            string strXml = GetStrtoUpLoad(userList, workerList, menuList, realUnitID, "02");
            string serviceName = "HSMWService";
            string methodName = "UploadProPerInfo";
            string mess = client2.invokeService(serviceName, methodName, strXml);
            if (mess.Contains("服务调用成功！"))
            {
                ChangePersonUpLoad(userList, "02");
            }

            if (userList[0].PersonPhoto != null)
            {
                //有照片需要上报
                strXml = GetStrtoUpLoad(userList, workerList, menuList, realUnitID, "03");
                serviceName = "HSMWService";
                methodName = "UploadProPhotoInfo";
                mess = client2.invokeService(serviceName, methodName, strXml);
                if (mess.Contains("服务调用成功！"))
                {
                    ChangePersonUpLoad(userList, "03");
                }
            }

            if (!string.IsNullOrEmpty(userList[0].scan_contract))
            {
                //有附件（合同）需要上报
                strXml = GetStrtoUpLoad(userList, workerList, menuList, realUnitID, "08");
                serviceName = "HSMWService";
                methodName = "UploadProFileInfo";
                mess = client2.invokeService(serviceName, methodName, strXml);
                if (mess.Contains("服务调用成功！"))
                {
                    ChangePersonUpLoad(userList, "08");
                }
            }
        }

        private bool ValidateServerCertificate(object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors)
        {
            return true;
        }

        #endregion

        #region ——————————处理字典——————

        /// <summary>
        /// 获取一个经过字典表处理过的A01实体类
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public A01 GetBySmCodeItem(A01 user)
        {
            BLLSession bll = new BLLSession();
            List<SM_CodeItems> codeItem = bll.SM_CodeItems.GetCodeItems();
            List<B01> unitInfo = bll.B01.GetB01Info();
            user.PClassID = "在职人员库";
            user.E0386 = GetNewValue(codeItem, "JA", user.E0386);
            user.A0107 = GetNewValue(codeItem, "AX", user.A0107);
            user.A0108 = GetNewValue(codeItem, "JDXL", user.A0108);
            user.A0121 = GetNewValue(codeItem, "AE", user.A0121);
            user.A0114 = GetNewValue(codeItem, "AB", user.A0114);
            user.A0110 = GetNewValue(codeItem, "HP", user.A0110);
            user.A0127 = GetNewValue(codeItem, "BG", user.A0127);
            user.A0128 = GetNewValue(codeItem, "AT", user.A0128);
            user.A0142 = GetNewValue(codeItem, "29", user.A0142);
            user.A0145 = GetNewValue(codeItem, "YGZT", user.A0145);
            user.A0120 = GetNewValue(codeItem, "45", user.A0120);

            user.B0001 = GetNewUnitName(unitInfo, "N", user.B0001);
            user.B0002 = GetNewUnitName(unitInfo, "M", user.B0002);
            user.B000201 = GetNewUnitName(unitInfo, "M", user.B000201);
            user.B000202 = GetNewUnitName(unitInfo, "M", user.B000202);
            user.A0143 = GetNewUnitName(unitInfo, "M", user.A0143);
            return user;
        }

        /// <summary>
        /// 根据CodeItems表删选
        /// </summary>
        /// <param name="list"></param>
        /// <param name="codeID"></param>
        /// <param name="codeItemID"></param>
        /// <returns></returns>
        private string GetNewValue(List<SM_CodeItems> list, string codeID, string codeItemID)
        {
            string value = "";
            if (!string.IsNullOrEmpty(codeItemID))
                value = GetCodeItemName(o => o.CodeID == codeID && o.CodeItemID == codeItemID, list);
            return value;
        }

        /// <summary>
        /// 根据B01单位表筛选
        /// </summary>
        /// <param name="list"></param>
        /// <param name="codeID"></param>
        /// <param name="codeItemID"></param>
        /// <returns></returns>
        private string GetNewUnitName(List<B01> list, string codeID, string codeItemID)
        {
            string value = "";
            if (!string.IsNullOrEmpty(codeItemID))
                value = GetUnitName(o => o.UnitType == codeID && o.UnitID == codeItemID, list);
            return value;
        }

        /// <summary>
        /// 根据条件筛选CodeItemName
        /// </summary>
        /// <param name="func"></param>
        /// <param name="codeItem"></param>
        /// <returns></returns>
        private string GetCodeItemName(Func<SM_CodeItems, bool> func, List<SM_CodeItems> codeItem)
        {
            string CodeItemName = "";
            try
            {
                CodeItemName = codeItem.Where(func).FirstOrDefault().CodeItemName;
            }
            catch (Exception)
            {
            }
            return CodeItemName;
        }

        /// <summary>
        /// 从单位表筛选数据
        /// </summary>
        /// <param name="func"></param>
        /// <param name="unitInfo"></param>
        /// <returns></returns>
        private string GetUnitName(Func<B01, bool> func, List<B01> unitInfo)
        {
            return unitInfo.Where(func).FirstOrDefault().UnitName;
        }

        #endregion

        #region  ————————考勤记录————————

        /// <summary>
        /// 获取所有人当前年月的考勤记录
        /// </summary>
        /// <param name="attYear"></param>
        /// <param name="attMonth"></param>
        /// <returns></returns>
        public DataTable GetAttendance(string attYear, string attMonth)
        {
            StringBuilder sbSql = new StringBuilder();
            sbSql.AppendFormat("select UnitID,PersonID,A0101,A0177,");
            sbSql.AppendFormat(" GZ=(select CodeItemName from SM_CodeItems where CodeID='JA' and CodeItemID=a.e0386), ");
            sbSql.AppendFormat(" XM=(select UnitName from B01 where UnitID=a.B0001), ");
            sbSql.AppendFormat(" DW=(select UnitName from B01 where UnitID=a.B0002),YF='{0}.{1}', ", attYear, attMonth);
            sbSql.AppendFormat(" TS=(select Count(distinct DAY(A0201)) from A02 where YEAR(A0201)=@year  ");
            sbSql.AppendFormat(" and MONTH(A0201)=@month and PersonID=a.PersonID),a.B0001,B0002 ");
            sbSql.AppendFormat("  from A01 a order by TS desc,DispOrder");
            SqlParameter[] param = new SqlParameter[] {
                new SqlParameter("@year",attYear),
                new SqlParameter("@month",attMonth)
            };
            DataTable dt = HCQ2_Common.SQL.SqlHelper.ExecuteDataTable(sbSql.ToString(), CommandType.Text, param);
            return dt;
        }

        /// <summary>
        /// 获取当前单位当前年月的考勤记录
        /// </summary>
        /// <param name="unitID"></param>
        /// <param name="attYear"></param>
        /// <param name="attMonth"></param>
        /// <returns></returns>
        public DataTable GetAttendanceByUnitID(string unitID, string attYear, string attMonth)
        {
            StringBuilder sbSql = new StringBuilder();
            sbSql.AppendFormat("select PersonID,A0101 AS 姓名,A0177 as 身份证号,");
            sbSql.AppendFormat(" 工种=(select CodeItemName from SM_CodeItems where CodeID='JA' and CodeItemID=a.e0386), ");
            sbSql.AppendFormat(" 所属项目=(select UnitName from B01 where UnitID=a.B0001), ");
            sbSql.AppendFormat(" 用工单位=(select UnitName from B01 where UnitID=a.B0002),考勤月份='{0}{1}', ", attYear, attMonth);
            sbSql.AppendFormat(" 考勤天数=(select COUNT(*) from A02 where YEAR(A0201)=@year  ");
            sbSql.AppendFormat(" and MONTH(A0201)=@month and PersonID=a.PersonID) ");
            sbSql.AppendFormat("  from A01 a where B0001=@UnitID order by DispOrder");
            SqlParameter[] param = new SqlParameter[] {
                new SqlParameter("@year",attYear),
                new SqlParameter("@month",attMonth),
                new SqlParameter("@UnitID",unitID)
            };
            DataTable dt = HCQ2_Common.SQL.SqlHelper.ExecuteDataTable(sbSql.ToString(), CommandType.Text, param);
            return dt;
        }

        #endregion

        #region ————————重复数据————————

        /// <summary>
        /// 获取重复数据
        /// </summary>
        /// <returns></returns>
        public DataTable GetReaptPerson()
        {
            StringBuilder sbSql = new StringBuilder();
            sbSql.AppendFormat("SELECT PersonID AS PersonID,B0001,A0101,");
            sbSql.AppendFormat(" C0104,A0178,");
            sbSql.AppendFormat(" (SELECT CodeItemName FROM SM_CodeItems WHERE CodeID='JA' AND CodeItemID=A01.E0386) AS E0386,");
            sbSql.AppendFormat(" (SELECT UnitName FROM B01 WHERE UnitID=A01.B0001) AS UnitName,");
            sbSql.AppendFormat(" (SELECT UnitName FROM B01 WHERE UnitID=A01.B0002) AS UnitGroup,A0177,");
            sbSql.AppendFormat(" (SELECT CodeItemName FROM SM_CodeItems WHERE CodeID='AE' AND CodeItemID=A01.A0121) AS nation,");
            sbSql.AppendFormat(" A0119 AS 入职登记时间 FROM A01 WHERE A0177 IN (select A0177 from A01 group by A0177");
            sbSql.AppendFormat(" having(count(*))>1) and PClassID='00001' ORDER BY A0101");
            DataTable dt = HCQ2_Common.SQL.SqlHelper.ExecuteDataTable(sbSql.ToString());
            string PersonID = string.Empty;
            //for (int i = 1; i < dt.Rows.Count; i++)
            //{
            //    //从第二个人开始比对。如果又重复则删除，删除之后，降i的直，继续比较，一直比较到没有重复的值再进行升值
            //    if (dt.Rows[i]["A0177"].ToString() == dt.Rows[i - 1]["A0177"].ToString())
            //    {
            //        dt.Rows.Remove(dt.Rows[i]);
            //        i--;
            //    }
            //}
            return dt;
        }

        /// <summary>
        /// 获取API需要的重复数据
        /// </summary>
        /// <returns></returns>
        public DataTable GetApiRepeatPerson(string guid)
        {
            StringBuilder sbSql = new StringBuilder();
            sbSql.AppendFormat("SELECT (SELECT CodeItemName FROM SM_CodeItems WHERE CodeID='JA' AND CodeItemID=A01.E0386) AS E0386,");
            sbSql.AppendFormat(" (SELECT UnitName FROM B01 WHERE UnitID=A01.B0001) AS UnitName,");
            sbSql.AppendFormat(" (SELECT UnitName FROM B01 WHERE UnitID=A01.B0002) AS UnitGroup,A0177,");
            sbSql.AppendFormat(" (SELECT CodeItemName FROM SM_CodeItems WHERE CodeID='AE' AND CodeItemID=A01.A0121) AS nation,");
            sbSql.AppendFormat(" (select (select CodeItemName from SM_CodeItems where CodeID='ZXZT' and CodeItemID=WGJG_GRZX06)");
            sbSql.AppendFormat(" from WGJG_GRZX where WGJG_GRZX03=A01.A0177) as zx,");
            sbSql.AppendFormat(" A0119 AS work_start,* FROM A01 WHERE A0177 IN (select A0177 from A01 group by A0177");
            sbSql.AppendFormat(" having(count(*))>1) and PClassID='00001'");
            T_User user = new T_UserBLL().Select(o => o.user_guid == guid).FirstOrDefault();
            List<B01> unitList = new B01BLL().GetPerUnitByUserID(user.user_id);
            sbSql.AppendFormat(" and  UnitID in ({0})", "'" + string.Join("','", unitList.Select(o => o.UnitID)) + "'");
            return HCQ2_Common.SQL.SqlHelper.ExecuteDataTable(sbSql.ToString());
        }

        #endregion

        #region ————APP接口人员信息——————————

        /// <summary>
        /// 根据姓名或身份证号码获取人员列表
        /// </summary>
        /// <param name="person"></param>
        /// <returns></returns>
        public List<HCQ2_Model.AppModel.ReturePerson> GetPersonQueryList(HCQ2_Model.AppModel.Person person)
        {
            List<HCQ2_Model.AppModel.ReturePerson> list = new List<HCQ2_Model.AppModel.ReturePerson>();
            HCQ2_Model.AppModel.ReturePerson rPerson = new HCQ2_Model.AppModel.ReturePerson();
            T_User user = new T_UserBLL().Select(o => o.user_guid == person.userid).FirstOrDefault();

            StringBuilder sbSql = new StringBuilder();
            sbSql.AppendFormat("select A0101,A0177,UnitID from A01 where (A0177 like '%{0}%' or A0101 like '%{1}%')", person.person_name_or_identity, person.person_name_or_identity);

            B01BLL _bList = new B01BLL();
            List<B01> perUnit = _bList.GetPerUnitByUserID(user.user_id);
            var unitList = _bList.GetB01Info();

            sbSql.AppendFormat(" and  UnitID in ({0})", "'" + string.Join("','", perUnit.Select(o => o.UnitID)) + "'");
            DataTable dt = HCQ2_Common.SQL.SqlHelper.ExecuteDataTable(sbSql.ToString());

            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    rPerson = new HCQ2_Model.AppModel.ReturePerson();
                    rPerson.person_name = dt.Rows[i]["A0101"].ToString();
                    rPerson.person_identify_code = dt.Rows[i]["A0177"].ToString();
                    rPerson.unit_code = dt.Rows[i]["UnitID"].ToString();
                    var unitData = unitList.Where(o => o.UnitID == rPerson.unit_code);
                    if (unitData != null && unitData.Count() > 0)
                    {
                        rPerson.unit_name = unitData.FirstOrDefault().UnitName;
                        list.Add(rPerson);
                    }
                }
            }

            return list;
        }

        /// <summary>
        /// 根据姓名和项目名称获取人员基本信息
        /// </summary>
        /// <param name="person"></param>
        /// <returns></returns>
        public HCQ2_Model.AppModel.PersonDetailReturn GetPersonDetail(HCQ2_Model.AppModel.PersonDetail person)
        {
            HCQ2_Model.AppModel.PersonDetailReturn rPerson = new HCQ2_Model.AppModel.PersonDetailReturn();
            string unit_id = person.unit_code;
            if (string.IsNullOrEmpty(unit_id))
                unit_id = new B01BLL().Select(o => o.UnitName == person.unit_name).FirstOrDefault().UnitID;

            StringBuilder sbSql = new StringBuilder();
            sbSql.AppendFormat("select top 1 PersonID,A0101,A0177,PersonPhoto,A0107=(select CodeItemName from");
            sbSql.AppendFormat(" SM_CodeItems where CodeID='AX' and CodeItemID=A0107),A0111,A0115,C0104,A0121, ");
            sbSql.AppendFormat(" E0386=(select CodeItemName from ");
            sbSql.AppendFormat(" SM_CodeItems where CodeID='JA' and CodeItemID=E0386),nation=(select CodeItemName from SM_CodeItems where CodeID='AE' and CodeItemID=A0121) from A01 ");
            if (!string.IsNullOrEmpty(person.person_identify_code))
                sbSql.AppendFormat(" where A0177='{0}' ", person.person_identify_code);
            else
                sbSql.AppendFormat(" where A0101='{0}' ", person.person_name);
            sbSql.AppendFormat(" and UnitID='{0}' ", unit_id);

            DataTable dt = HCQ2_Common.SQL.SqlHelper.ExecuteDataTable(sbSql.ToString());
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    rPerson.person_name = dt.Rows[i]["A0101"].ToString();
                    rPerson.person_sex = dt.Rows[i]["A0107"].ToString();
                    rPerson.person_identify_code = dt.Rows[i]["A0177"].ToString();
                    if (!string.IsNullOrEmpty(dt.Rows[i]["PersonPhoto"].ToString()))
                    {
                        rPerson.person_photo = Convert.ToBase64String(GetByPersonID(dt.Rows[i]["PersonID"].ToString()).PersonPhoto);
                    }
                    rPerson.person_nation = dt.Rows[i]["nation"].ToString();
                    if (!string.IsNullOrEmpty(dt.Rows[i]["A0111"].ToString()))
                        rPerson.person_birth = Convert.ToDateTime(dt.Rows[i]["A0111"]).ToString("yyyy-MM-dd");
                    rPerson.person_address = dt.Rows[i]["A0115"].ToString();
                    rPerson.person_phone = dt.Rows[i]["C0104"].ToString();
                    rPerson.person_jobs = dt.Rows[i]["E0386"].ToString();
                    rPerson.person_status = "在岗";
                }
            }

            return rPerson;
        }

        /// <summary>
        /// 根据姓名和项目名称获取人员当前所在项目
        /// </summary>
        /// <param name="person"></param>
        /// <returns></returns>
        public HCQ2_Model.AppModel.PersonUnit GetPersonUnitDetail(HCQ2_Model.AppModel.PersonDetail person)
        {
            HCQ2_Model.AppModel.PersonUnit unit = new HCQ2_Model.AppModel.PersonUnit();
            string unit_id = person.unit_code;
            if (string.IsNullOrEmpty(unit_id))
                unit_id = new B01BLL().Select(o => o.UnitName == person.unit_name).FirstOrDefault().UnitID;
            string unit_cname = "B0001";
            if (unit_id.Length > 3)
                unit_cname = "B0002";
            StringBuilder sbSql = new StringBuilder();
            sbSql.AppendFormat("select E0386=(select CodeItemName from");
            sbSql.AppendFormat(" SM_CodeItems where CodeID='JA' and CodeItemID=E0386), ");
            sbSql.AppendFormat(" E0359,UnitName,B0180,B0181 from A01 a inner join B01 b on a.{0}=b.UnitID ", unit_cname);
            if (!string.IsNullOrEmpty(person.person_identify_code))
                sbSql.AppendFormat(" where a.A0177='{0}' and b.UnitID='{1}' ", person.person_identify_code, unit_id);
            else
                sbSql.AppendFormat(" where a.A0101='{0}' and b.UnitID='{1}' ", person.person_name, unit_id);
            DataTable dt = HCQ2_Common.SQL.SqlHelper.ExecuteDataTable(sbSql.ToString());
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    unit.unit_name = dt.Rows[i]["UnitName"].ToString();
                    unit.work_start = dt.Rows[i]["E0359"].ToString();
                    unit.work_jobs = dt.Rows[i]["E0386"].ToString();
                    unit.unit_contact = dt.Rows[i]["B0180"].ToString();
                    unit.unit_contact_phone = dt.Rows[i]["B0181"].ToString();
                }
            }
            return unit;
        }

        /// <summary>
        /// 根据姓名和项目名称获取人员出工记录
        /// </summary>
        /// <param name="person"></param>
        /// <returns></returns>
        public List<HCQ2_Model.AppModel.WorkDays> GetCheckDaysRecord(HCQ2_Model.AppModel.PersonDetailCkeck person)
        {
            List<HCQ2_Model.AppModel.WorkDays> list = new List<HCQ2_Model.AppModel.WorkDays>();
            HCQ2_Model.AppModel.WorkDays work = new HCQ2_Model.AppModel.WorkDays();
            string unit_id = person.unit_code;
            if (string.IsNullOrEmpty(unit_id))
                unit_id = new B01BLL().Select(o => o.UnitName == person.unit_name).FirstOrDefault().UnitID;
            StringBuilder sbSql = new StringBuilder();
            if (!string.IsNullOrEmpty(person.person_identify_code))
                sbSql.AppendFormat("select * from A01 where A0177='{0}'", person.person_identify_code);
            else
                sbSql.AppendFormat("select * from A01 where A0101='{0}'", person.person_name);
            if (unit_id.Length > 3)
                sbSql.AppendFormat(" and B0002='{0}' ", unit_id);
            else
                sbSql.AppendFormat(" and B0001='{0}' and ISNULL(B0002,'')='' ", unit_id);
            string person_id = HCQ2_Common.SQL.SqlHelper.ExecuteDataTable(sbSql.ToString()).Rows[0]["PersonID"].ToString();

            //获取所有的打卡年、月
            sbSql = new StringBuilder();
            string year = string.IsNullOrEmpty(person.query_year) ? DateTime.Now.Year.ToString() : person.query_year;
            //sbSql.AppendFormat("select distinct time=CAST(YEAR(A0201) as nvarchar(4))  +'.'+ CAST(MONTH(A0201) as nvarchar(4)),A0201");
            //sbSql.AppendFormat(" from A02 where PersonID='{0}' and year(A0201)={1} order by A0201 ", person_id, year);
            sbSql.AppendFormat("select a.PersonID,a.time,a.dd from (select LEFT(A0201,7) time , (select LEFT(A0201,10)) dd,* from A02");
            sbSql.AppendFormat(" where PersonID='{0}' and year(a0201)={1})  a group by a.PersonID,a.dd,a.time", person_id, year);
            DataTable dt = HCQ2_Common.SQL.SqlHelper.ExecuteDataTable(sbSql.ToString());
            if (dt != null && dt.Rows.Count > 0)
            {
                DataTable dtMonth = dt.DefaultView.ToTable(true, "time");
                List<string> listMonth = new List<string>();
                List<int> listDay = new List<int>();
                for (int i = 0; i < dtMonth.Rows.Count; i++)
                {
                    work = new HCQ2_Model.AppModel.WorkDays();
                    work.check_month = dtMonth.Rows[i]["time"].ToString();
                    work.check_count = dt.AsEnumerable().Where(o => o.Field<string>("time") == dtMonth.Rows[i]["time"].ToString()).Count();
                    list.Add(work);
                }
            }
            return list;
        }

        /// <summary>
        /// 务工人员接口-----------------维权凭证
        /// </summary>
        /// <param name="person"></param>
        /// <returns></returns>
        public HCQ2_Model.AppModel.PersonDetailReturn GetWorkPersonDetail(HCQ2_Model.AppModel.WorkPersonDetail person)
        {
            var data = new T_UserBLL().Select(o => o.user_guid == person.userid);
            StringBuilder sbSql = new StringBuilder();
            HCQ2_Model.AppModel.PersonDetail detail = new HCQ2_Model.AppModel.PersonDetail();
            detail.person_identify_code = data[0].user_identify;
            detail.unit_code = person.unit_code;
            return GetPersonDetail(detail);
        }

        /// <summary>
        /// 务工人员接口-----------------所在项目
        /// </summary>
        /// <param name="person"></param>
        /// <returns></returns>
        public List<HCQ2_Model.AppModel.UnitReturn> GetWorkPersonUnit(HCQ2_Model.AppModel.WorkPerson person)
        {
            List<HCQ2_Model.AppModel.UnitReturn> rList = new List<HCQ2_Model.AppModel.UnitReturn>();
            HCQ2_Model.AppModel.UnitReturn rUnit = new HCQ2_Model.AppModel.UnitReturn();
            var data = new T_UserBLL().Select(o => o.user_guid == person.userid);

            StringBuilder sbSql = new StringBuilder();
            sbSql.AppendFormat("select * from A01 where A0177='{0}'", data[0].user_identify);
            List<A01> userList = HCQ2_Common.Data.DataTableHelper.DataTableToIList<A01>(
                HCQ2_Common.SQL.SqlHelper.ExecuteDataTable(sbSql.ToString()));

            foreach (var item in userList)
            {
                List<B01> unitList = new List<B01>();
                rUnit = new HCQ2_Model.AppModel.UnitReturn();
                sbSql = new StringBuilder();
                sbSql.AppendFormat("select * from B01 where UnitID =");
                if (!string.IsNullOrEmpty(item.B0002))
                {
                    sbSql.AppendFormat("{0}", item.B0002);
                }
                else
                {
                    sbSql.AppendFormat("{0}", item.B0001);
                }
                DataTable dt = HCQ2_Common.SQL.SqlHelper.ExecuteDataTable(sbSql.ToString());
                if (dt != null)
                {
                    unitList = HCQ2_Common.Data.DataTableHelper.DataTableToIList<B01>(dt);
                    rUnit.unit_name = unitList[0].UnitName;
                    rUnit.unit_code = unitList[0].UnitID;
                    rUnit.contract_money = unitList[0].B0114.ToString();
                    rUnit.unit_contact = unitList[0].B0180;
                    rUnit.unit_phone = unitList[0].B0181;
                    rUnit.unit_type = unitList[0].UnitType;

                    sbSql = new StringBuilder();
                    if (unitList[0].UnitID.Length > 3)
                        sbSql.AppendFormat("select count(*) from A01 where B0002='{0}'", unitList[0].UnitID);
                    else
                        sbSql.AppendFormat("select count(*) from A01 where B0001='{0}'", unitList[0].UnitID);
                    rUnit.worker_num = HCQ2_Common.Helper.ToInt(HCQ2_Common.SQL.SqlHelper.ExecuteScalar(sbSql.ToString()));
                    rList.Add(rUnit);
                }

            }

            return rList;
        }

        /// <summary>
        /// 人员同步
        /// </summary>
        /// <param name="match_timestamp"></param>
        /// <param name="unit_id"></param>
        /// <param name="userid"></param>
        /// <returns></returns>
        public List<A01> PersonsSynchronous(string match_timestamp, string unit_id, string userid, string deviceid)
        {
            List<A01> userList = new List<A01>();
            T_User u = DBSession.IT_UserDAL.Select(s => s.user_guid.Equals(userid)).FirstOrDefault();
            string syData = match_timestamp.Substring(0, 4) + "-" + match_timestamp.Substring(4, 2) + "-" + match_timestamp.Substring(6, 2);
            syData += " " + match_timestamp.Substring(8, 2) + ":" + match_timestamp.Substring(10, 2) + ":" + match_timestamp.Substring(12, 2);
            StringBuilder sbSql = new StringBuilder();
            sbSql.AppendFormat("select A0115,A0101,A0107,A0121,A0111,A0112,A0116,A0117,A0177,PersonID,A0118,");
            sbSql.AppendFormat(" big_iris_data,PersonPhoto from A01 where update_time>(select ");
            sbSql.AppendFormat(" top 1 sy_date from T_Synchronous where sy_unit_id='{0}' and deviceid='{2}' order by sy_id desc)and UnitID='{1}'", unit_id, unit_id, deviceid);
            DataTable dt = HCQ2_Common.SQL.SqlHelper.ExecuteDataTable(sbSql.ToString());

            //先删除上一次同步的记录
            new T_SynchronousBLL().Delete(o => o.deviceid == deviceid);
            //再记录本次同步的记录
            T_Synchronous syn = new T_Synchronous();
            syn.sy_unit_id = unit_id;
            syn.sy_user_id = u.user_id;
            syn.sy_date = Convert.ToDateTime(syData);
            syn.deviceid = deviceid;
            new T_SynchronousBLL().Add(syn);

            userList = HCQ2_Common.Data.DataTableHelper.DataTableToIList<A01>(dt);
            return userList;
        }

        #endregion

        #region  ————APP接口出工情况————————

        /// <summary>
        /// 获取所有出工情况列表
        /// </summary>
        /// <param name="checkWork"></param>
        /// <returns></returns>
        public List<HCQ2_Model.AppModel.CheckWorkReturn> GetCheckWorkList(HCQ2_Model.AppModel.CheckWork checkWork)
        {
            List<HCQ2_Model.AppModel.CheckWorkReturn> list = new List<HCQ2_Model.AppModel.CheckWorkReturn>();
            HCQ2_Model.AppModel.CheckWorkReturn rCheck = new HCQ2_Model.AppModel.CheckWorkReturn();

            //判断日期
            string[] checkTime = checkWork.check_date.Split('-');
            if (checkTime.Length != 3)
                return list;
            //获取单位列表

            T_User u = DBSession.IT_UserDAL.Select(s => s.user_guid.Equals(checkWork.userid)).FirstOrDefault();
            List<B01> unitList = new B01BLL().GetPerUnitByUserID(u.user_id);

            if (!string.IsNullOrEmpty(checkWork.unit_name))
                unitList = unitList.Where(o => o.UnitName.Contains(checkWork.unit_name)).ToList();

            //获取人员列表
            List<A01> personList = GetA01Info();

            StringBuilder sbSql = new StringBuilder();
            foreach (var item in unitList)
            {
                List<A01> listTotal = new List<A01>();
                string arrPersonID = string.Empty;
                if (item.UnitID.Length > 3)
                {
                    //该单位总人数
                    listTotal = personList.Where(o => o.B0002 == item.UnitID).ToList();
                }
                else
                {
                    //该单位总人数
                    listTotal = personList.Where(o => o.B0001 == item.UnitID && (o.B0002 == "" || o.B0002 == "null" || o.B0002 == null)).ToList();
                }
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
                sbSql.AppendFormat("select distinct PersonID from A02 where YEAR(A0201)={0}", checkTime[0]);
                sbSql.AppendFormat("and MONTH(A0201)={1} and DAY(A0201)={2} and PersonID in ({0})", string.IsNullOrEmpty(arrPersonID) ? "''" : arrPersonID, checkTime[1], checkTime[2]);
                DataTable dt = HCQ2_Common.SQL.SqlHelper.ExecuteDataTable(sbSql.ToString());

                rCheck = new HCQ2_Model.AppModel.CheckWorkReturn();
                rCheck.unit_name = item.UnitName;
                rCheck.unit_code = item.UnitID;
                rCheck.unit_count = listTotal.Count();
                rCheck.check_count = dt.Rows.Count;
                if (rCheck.check_count > 0)
                    rCheck.check_pepe = Convert.ToDouble((((decimal)rCheck.check_count / rCheck.unit_count) * 100).ToString("f2"));
                else
                    rCheck.check_pepe = 0;
                list.Add(rCheck);
            }
            if (list != null)
                list = list.OrderByDescending(o => o.check_pepe).ToList();
            return list;
        }

        /// <summary>
        /// 分页获取出工情况列表
        /// </summary>
        /// <param name="checkWork"></param>
        /// <returns></returns>
        public List<HCQ2_Model.AppModel.CheckWorkReturn> GetRowPageList(HCQ2_Model.AppModel.CheckWorkPageRow checkWork)
        {
            List<HCQ2_Model.AppModel.CheckWorkReturn> list = new List<HCQ2_Model.AppModel.CheckWorkReturn>();
            HCQ2_Model.AppModel.CheckWorkReturn rCheck = new HCQ2_Model.AppModel.CheckWorkReturn();
            //判断日期
            string[] checkTime = checkWork.check_date.Split('-');
            if (checkTime.Length != 3)
                return list;
            //获取单位列表
            T_User u = DBSession.IT_UserDAL.Select(s => s.user_guid.Equals(checkWork.userid)).FirstOrDefault();
            List<B01> unitList = new B01BLL().GetPerUnitByUserID(u.user_id);

            if (!string.IsNullOrEmpty(checkWork.unit_name))
                unitList = unitList.Where(o => o.UnitName.Contains(checkWork.unit_name)).ToList();

            //获取人员列表
            List<A01> personList = GetA01Info();

            StringBuilder sbSql = new StringBuilder();
            foreach (var item in unitList)
            {
                List<A01> listTotal = new List<A01>();
                string arrPersonID = string.Empty;
                if (item.UnitID.Length > 3)
                {
                    //该单位总人数
                    listTotal = personList.Where(o => o.B0002 == item.UnitID).ToList();
                }
                else
                {
                    //该单位总人数
                    listTotal = personList.Where(o => o.B0001 == item.UnitID && (o.B0002 == "" || o.B0002 == "null" || o.B0002 == null)).ToList();
                }
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
                sbSql.AppendFormat("select distinct PersonID from A02 where YEAR(A0201)={0}", checkTime[0]);
                sbSql.AppendFormat("and MONTH(A0201)={1} and DAY(A0201)={2} and PersonID in ({0})", string.IsNullOrEmpty(arrPersonID) ? "''" : arrPersonID, checkTime[1], checkTime[2]);
                DataTable dt = HCQ2_Common.SQL.SqlHelper.ExecuteDataTable(sbSql.ToString());

                rCheck = new HCQ2_Model.AppModel.CheckWorkReturn();
                rCheck.unit_name = item.UnitName;
                rCheck.unit_code = item.UnitID;
                rCheck.unit_count = listTotal.Count();
                rCheck.check_count = dt.Rows.Count;
                if (rCheck.check_count > 0)
                    rCheck.check_pepe = Convert.ToDouble((((decimal)rCheck.check_count / rCheck.unit_count) * 100).ToString("f2"));
                else
                    rCheck.check_pepe = 0;
                list.Add(rCheck);
            }

            if (list != null)
                list = list.OrderByDescending(o => o.check_pepe).ToList();

            if (list.Count() > 0)
            {
                list = list.Skip((checkWork.page * checkWork.rows) - checkWork.rows).Take(checkWork.rows).ToList();
            }

            return list;
        }

        /// <summary>
        /// 获取具体项目出工情况列表
        /// </summary>
        /// <param name="checkWork"></param>
        /// <returns></returns>
        public List<HCQ2_Model.AppModel.CheckUnitWorkDetail> GetPersonList(HCQ2_Model.AppModel.CheckWork checkWork)
        {
            List<HCQ2_Model.AppModel.CheckUnitWorkDetail> list = new List<HCQ2_Model.AppModel.CheckUnitWorkDetail>();
            HCQ2_Model.AppModel.CheckUnitWorkDetail rWork = new HCQ2_Model.AppModel.CheckUnitWorkDetail();

            string unit_id = new B01BLL().GetB01Info().Where(o => o.UnitName == checkWork.unit_name).FirstOrDefault().UnitID;

            //判断日期
            string[] checkTime = checkWork.check_date.Split('-');
            if (checkTime.Length != 3)
                return list;

            //获取该项目的所有人员
            StringBuilder sbSql = new StringBuilder();
            sbSql.AppendFormat("select PersonID,A0101,C0104,E0386=(select CodeItemName from");
            sbSql.AppendFormat(" SM_CodeItems where CodeID='JA' and CodeItemID=E0386),");
            sbSql.AppendFormat(" if_check=(case when (select COUNT(*) from A02 where PersonID=a.PersonID and YEAR(A0201)={0}  ", checkTime[0]);
            sbSql.AppendFormat(" and MONTH(A0201)={0} and DAY(A0201)={1}) > 0 then 1 else 0 end) ", checkTime[1], checkTime[2]);
            sbSql.AppendFormat(" from A01 a ");
            if (unit_id.Length > 3)
                sbSql.AppendFormat(" where B0002='{0}' ", unit_id);
            else
                sbSql.AppendFormat(" where B0001='{0}' and ISNULL(B0002,'')='' ", unit_id);
            sbSql.AppendFormat(" order by if_check desc ");
            DataTable dt = HCQ2_Common.SQL.SqlHelper.ExecuteDataTable(sbSql.ToString());

            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    rWork = new HCQ2_Model.AppModel.CheckUnitWorkDetail();
                    rWork.person_name = dt.Rows[i]["A0101"].ToString();
                    rWork.person_phone = dt.Rows[i]["C0104"].ToString();
                    rWork.person_jobs = dt.Rows[i]["E0386"].ToString();
                    rWork.if_check = dt.Rows[i]["if_check"].ToString();
                    list.Add(rWork);
                }
            }

            return list;
        }

        /// <summary>
        /// 项目人员出工统计
        /// </summary>
        /// <param name="checkStatis"></param>
        /// <returns></returns>
        public List<HCQ2_Model.AppModel.CheckWorkStaticReturn> GetPersonStatis(HCQ2_Model.AppModel.CheckWorkStatic checkStatis)
        {
            List<HCQ2_Model.AppModel.CheckWorkStaticReturn> list = new List<HCQ2_Model.AppModel.CheckWorkStaticReturn>();
            HCQ2_Model.AppModel.CheckWorkStaticReturn rStatis = new HCQ2_Model.AppModel.CheckWorkStaticReturn();
            string unit_id = new B01BLL().GetB01Info().Where(o => o.UnitName == checkStatis.unit_name).FirstOrDefault().UnitID;
            StringBuilder sbSql = new StringBuilder();

            sbSql.AppendFormat("select A0101,E0386=(select CodeItemName from SM_CodeItems where CodeID='JA' and CodeItemID=E0386),");
            sbSql.AppendFormat(" work_day=(select count(distinct(CAST(YEAR(a0201) as nvarchar(4)) + '-' + CAST(month(a0201) as nvarchar(2)) + '-' + CAST(day(a0201) as nvarchar(2))))");
            sbSql.AppendFormat(" from A02 where PersonID=a.PersonID and A0201>@start and A0201 < @end )");
            sbSql.AppendFormat(" from A01 a");

            if (unit_id.Length > 3)
                sbSql.AppendFormat(" where B0002={0} ", unit_id);
            else
                sbSql.AppendFormat(" where B0001={0} and ISNULL(B0002,'')='' ", unit_id);

            sbSql.AppendFormat(" order by work_day desc");
            SqlParameter[] param = new SqlParameter[] {
                new SqlParameter("@start",checkStatis.start_date),
                new SqlParameter("@end",checkStatis.end_date)
            };

            DataTable dt = HCQ2_Common.SQL.SqlHelper.ExecuteDataTable(sbSql.ToString(), CommandType.Text, param);
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    rStatis = new HCQ2_Model.AppModel.CheckWorkStaticReturn();
                    rStatis.person_name = dt.Rows[i]["A0101"].ToString();
                    rStatis.work_jobs = dt.Rows[i]["E0386"].ToString();
                    if (!string.IsNullOrEmpty(dt.Rows[i]["work_day"].ToString()))
                        rStatis.work_days = Convert.ToInt32(dt.Rows[i]["work_day"].ToString());
                    else
                        rStatis.work_days = 0;
                    list.Add(rStatis);
                }
            }

            return list;
        }

        /// <summary>
        /// 获取所有项目的平均出工率
        /// </summary>
        /// <param name="checkWork"></param>
        /// <returns></returns>
        public Dictionary<string, object> GetAllProjectAvg(HCQ2_Model.AppModel.CheckWork checkWork)
        {
            Dictionary<string, object> dic = new Dictionary<string, object>();
            StringBuilder sbSql = new StringBuilder();
            string[] check_date = checkWork.check_date.Split('-');
            if (check_date.Length != 3)
                return dic;

            string unit_id = "";
            if (!string.IsNullOrEmpty(checkWork.unit_name))
                unit_id = new B01BLL().GetByUnitName(checkWork.unit_name).UnitID;
            //获取出工人数
            sbSql.AppendFormat("select COUNT(distinct(PersonID)) from View_A02 where YEAR(A0201)={0} and MONTH(A0201)={1} and DAY(A0201)={2}", check_date[0], check_date[1], check_date[2]);
            if (!string.IsNullOrEmpty(unit_id))
                sbSql.AppendFormat(" and UnitID='{0}' ", unit_id);
            double check_count = Convert.ToDouble(HCQ2_Common.SQL.SqlHelper.ExecuteScalar(sbSql.ToString()));
            dic.Add("check_count", check_count);

            sbSql = new StringBuilder();
            sbSql.AppendFormat("select COUNT(PersonID) from A01 where YEAR(create_time)<={0} and MONTH(create_time)<={1}", check_date[0], check_date[1]);
            sbSql.AppendFormat(" and DAY(create_time)<{0} and ISNULL(UnitID,'')<>''", check_date[2]);
            if (!string.IsNullOrEmpty(unit_id))
                sbSql.AppendFormat(" and UnitID='{0}' ", unit_id);
            double total_count = Convert.ToDouble(HCQ2_Common.SQL.SqlHelper.ExecuteScalar(sbSql.ToString()));
            dic.Add("total_count", total_count);
            double pepe = ((check_count / total_count));
            dic.Add("total_pepe", decimal.Round(decimal.Parse(pepe.ToString()) * 100, 2) + "%");
            return dic;
        }

        /// <summary>
        /// 月出工率
        /// </summary>
        /// <param name="checkWork"></param>
        /// <returns></returns>
        public List<HCQ2_Model.AppModel.CheckWorkMonth> GetDayWorkByMonth(HCQ2_Model.AppModel.CheckWork checkWork)
        {
            List<HCQ2_Model.AppModel.CheckWorkMonth> rList = new List<HCQ2_Model.AppModel.CheckWorkMonth>();
            HCQ2_Model.AppModel.CheckWorkMonth rCheck = new HCQ2_Model.AppModel.CheckWorkMonth();
            StringBuilder sbSql = new StringBuilder();
            string unit_id = "";
            if (!string.IsNullOrEmpty(checkWork.unit_name))
                unit_id = new B01BLL().GetByUnitName(checkWork.unit_name).UnitID;

            //日期为年-月结构
            string[] checkDate = checkWork.check_date.Split('-');
            if (checkDate.Length != 2)
                return null;

            DateTime beginDate = Convert.ToDateTime(checkWork.check_date + "-1");
            DateTime endData = DateTime.Now;
            if (checkDate[1] == "12")
                endData = Convert.ToDateTime((Convert.ToInt32(checkDate[0]) + 1).ToString() + "-1-1");
            else
                endData = Convert.ToDateTime(checkDate[0] + "-" + (Convert.ToInt32(checkDate[1]) + 1) + "-1");

            //获取该月所有月份
            List<int> dayList = new List<int>();
            for (DateTime dt = beginDate; dt < endData; dt = dt.AddDays(1))
            {
                if (dt.Year > DateTime.Now.Year || (dt.Year == DateTime.Now.Year && dt.Month == DateTime.Now.Month && dt.Day > DateTime.Now.Day))
                {
                    break;
                }

                sbSql = new StringBuilder();
                rCheck = new HCQ2_Model.AppModel.CheckWorkMonth();
                rCheck.check_date = dt.Day + "日";
                sbSql.AppendFormat("select COUNT(distinct(PersonID)) from View_A02 where YEAR(A0201)={0}", dt.Year);
                sbSql.AppendFormat(" and MONTH(A0201)={0} and DAY(A0201)={1} ", dt.Month, dt.Day);
                if (!string.IsNullOrEmpty(unit_id))
                    sbSql.AppendFormat(" and UnitID='{0}' ", unit_id);
                double check_count = Convert.ToDouble(HCQ2_Common.SQL.SqlHelper.ExecuteScalar(sbSql.ToString()));
                rCheck.check_count = Convert.ToInt32(check_count);

                sbSql = new StringBuilder();
                sbSql.AppendFormat(" select COUNT(PersonID) from A01 where YEAR(create_time)<={0} ", dt.Year);
                sbSql.AppendFormat(" and MONTH(create_time)<={0} ", dt.Month);
                sbSql.AppendFormat(" and DAY(create_time)<={0} and ISNULL(UnitID,'')<>'' ", dt.Day);
                if (!string.IsNullOrEmpty(unit_id))
                    sbSql.AppendFormat(" and UnitID='{0}' ", unit_id);
                double total_count = Convert.ToDouble(HCQ2_Common.SQL.SqlHelper.ExecuteScalar(sbSql.ToString()));
                rCheck.total_count = Convert.ToInt32(total_count);

                if (rCheck.total_count > 0)
                {
                    double check_pepe = (double)check_count / total_count;
                    rCheck.check_pepe = decimal.Round(decimal.Parse(check_pepe.ToString()) * 100, 2) + "%";
                }
                else
                {
                    rCheck.check_pepe = "0%";
                }

                rList.Add(rCheck);
            }
            return rList;
        }

        #endregion

        #region ————————滚屏显示内容————————

        /// <summary>
        /// 获取滚屏显示工种工区统计
        /// </summary>
        /// <param name="roll"></param>
        /// <returns></returns>
        public List<object> GetWorkerJobsRollSrcen(HCQ2_Model.RollScreenModel.Roll roll)
        {
            List<object> list = new List<object>();
            Dictionary<string, object> dicRoll = new Dictionary<string, object>();

            #region 获取统计信息
            HCQ2_Model.RollScreenModel.UnitStatis unit_statis = new HCQ2_Model.RollScreenModel.UnitStatis();
            unit_statis.unit_name = roll.unit_name;
            StringBuilder sbSql = new StringBuilder();
            var unit = new B01BLL().GetB01Info().Where(o => o.UnitName == roll.unit_name).FirstOrDefault();
            unit_statis.unit_conact = unit.B0180;
            if (unit.UnitID.Length > 3)
                sbSql.AppendFormat("select count(*) as count from A01 where B0002='" + unit.UnitID + "'");
            else
                sbSql.AppendFormat("select count(*) as count from A01 where B0001='" + unit.UnitID + "' and isnull(B0002,'')=''");
            unit_statis.total_person = Convert.ToInt32(HCQ2_Common.SQL.SqlHelper.ExecuteDataTable(sbSql.ToString()).Rows[0]["count"]);
            #endregion

            //项目详细信息

            string[] ckDate = roll.check_date.Split('-');
            if (ckDate.Length != 3)
                return null;

            List<Dictionary<string, object>> listJobs = new List<Dictionary<string, object>>();
            Dictionary<string, object> dic = new Dictionary<string, object>();
            sbSql = new StringBuilder();
            sbSql.AppendFormat("select E0386=(select CodeItemName from SM_CodeItems where CodeID='JA' and CodeItemID=a.E0386),");
            sbSql.AppendFormat(" A0181 from A01 a inner join A02 b on a.PersonID=b.PersonID and ISNULL(a.A0181,'')<>''");
            sbSql.AppendFormat(" where year(a0201)={0} and MONTH(A0201)={1} and DAY(A0201)={2}", ckDate[0], ckDate[1], ckDate[2]);
            if (unit.UnitID.Length > 3)
                sbSql.AppendFormat(" and a.B0002='" + unit.UnitID + "' ");
            else
                sbSql.AppendFormat(" and a.B0001='" + unit.UnitID + "' and isnull(B0002,'')='' ");
            DataTable dt = HCQ2_Common.SQL.SqlHelper.ExecuteDataTable(sbSql.ToString());
            if (dt.Rows.Count > 0)
            {
                DataTable dtJobs = dt.DefaultView.ToTable(true, "E0386");
                DataTable dtArea = dt.DefaultView.ToTable(true, "A0181");

                for (int i = 0; i < dtArea.Rows.Count; i++)
                {
                    dic = new Dictionary<string, object>();
                    string area_name = dtArea.Rows[i]["A0181"].ToString();
                    //工区
                    dic.Add("工区", area_name);
                    //获取工种
                    for (int j = 0; j < dtJobs.Rows.Count; j++)
                    {
                        string jobs = dtJobs.Rows[j]["E0386"].ToString();
                        if (!string.IsNullOrEmpty(jobs))
                        {
                            dic.Add(jobs, dt.AsEnumerable().Where(o => o.Field<string>("E0386") == jobs &&
                            o.Field<string>("A0181") == area_name).Count());
                        }
                        else
                        {
                            dic.Add("其他", dt.Select(" A0181='" + area_name + "' and isnull(E0386,'')='' ").Count());
                        }
                    }
                    listJobs.Add(dic);
                }
            }

            dicRoll.Add("statisNum", unit_statis);
            dicRoll.Add("jobCount", listJobs);
            list.Add(dicRoll);

            return list;
        }

        #endregion
    }
}
