using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HCQ2_IBLL;
using HCQ2_Model;
using HCQ2_Model.TreeModel;
using HCQ2_Model.WebApiModel.ResultApiModel;
using System.Data;
using HCQ2_Common;
using HCQ2_Model.SelectModel;
using System.Web.Mvc;
using System.Net;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;

namespace HCQ2_BLL
{
    public partial class B01BLL : IB01BLL
    {
        #region 获取数据信息

        /// <summary>
        /// 目录树字符串
        /// </summary>
        private StringBuilder sbTree = new StringBuilder();

        /// <summary>
        /// 获取所有单位信息
        /// </summary>
        /// <returns></returns>
        public List<B01> GetB01Info()
        {
            return Select(o => !string.IsNullOrEmpty(o.UnitID));
        }

        /// <summary>
        /// 生成目录树字符串
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public string GetTreeString(List<B01> obj)
        {
            sbTree.Append("[");
            B01 b = new B01();
            for (int i = 0; i < obj.Count; i++)
            {
                b = obj[i];
                if (i != 0)
                    sbTree.Append(" , ");
                sbTree.Append(AddModleItem(b));
                var data = GetB01Info().Where(o => o.KeyParent == b.UnitID && o.KeyParent != ".");
                if (data.Count() > 0)
                {
                    sbTree.Append(" ,nodes:  ");
                    GetTreeString(data.ToList());
                    sbTree.Append(" } ");
                }
                else
                {
                    sbTree.Append("}");
                }
            }
            sbTree.Append(" ]");
            return sbTree.ToString();
        }

        /// <summary>
        /// 根据UnitID获取信息
        /// </summary>
        /// <param name="unitID"></param>
        /// <returns></returns>
        public B01 GetByUnitID(string unitID)
        {
            return GetB01Info().Where(o => o.UnitID == unitID).FirstOrDefault();
        }

        /// <summary>
        /// 根据UnitName查找数据
        /// </summary>
        /// <param name="unitName"></param>
        /// <returns></returns>
        public B01 GetByUnitName(string unitName)
        {
            if (!string.IsNullOrEmpty(unitName))
                return Select(o => o.UnitName == unitName).FirstOrDefault();
            else
                return null;
        }

        /// <summary>
        /// 根据UnitID删除单位以及子单位
        /// </summary>
        /// <param name="unitID"></param>
        /// <returns></returns>
        public bool DeleteByUnitIDInfo(string UnitID)
        {
            return true;
        }

        /// <summary>
        /// 添加属性
        /// </summary>
        /// <param name="b"></param>
        /// <returns></returns>
        private string AddModleItem(B01 b)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("{ \"UnitID\" :\"" + b.UnitID + "\" ");
            sb.Append(", \"KeyParent\" :\"" + b.KeyParent + "\" ");
            sb.Append(", \"UnitName\" :\"" + b.UnitName + "\" ");
            sb.Append(", \"text\" :\"" + b.UnitName + "\" ");
            sb.Append(", \"UnitType\" :\"" + b.UnitType + "\" ");
            sb.Append(", \"B0107\" :\"" + b.B0107 + "\" ");
            sb.Append(", \"B0108\" :\"" + b.B0108 + "\" ");
            sb.Append(", \"B0120\" :\"" + b.B0120 + "\" ");
            sb.Append(", \"D010H\" :\"" + b.D010H + "\" ");
            sb.Append(", \"B0175\" :\"" + b.B0175 + "\" ");
            sb.Append(", \"UnitStartDate\" :\"" + b.UnitStartDate + "\" ");
            sb.Append(", \"UnitEndDate\" :\"" + b.UnitEndDate + "\" ");
            sb.Append(", \"B0111\" :\"" + b.B0111 + "\" ");
            sb.Append(", \"B0112\" :\"" + b.B0112 + "\" ");
            sb.Append(", \"B0130\" :\"" + b.B0130 + "\" ");
            sb.Append(", \"B0113\" :\"" + b.B0113 + "\" ");
            sb.Append(", \"B0114\" :\"" + b.B0114 + "\" ");
            sb.Append(", \"B0115\" :\"" + b.B0115 + "\" ");
            sb.Append(", \"B0116\" :\"" + b.B0116 + "\" ");
            sb.Append(", \"B0118\" :\"" + b.B0118 + "\" ");
            sb.Append(", \"id\" :\"" + b.UnitID + "\" ");
            return sb.ToString();
        }

        /// <summary>
        /// 获取工地数量
        /// </summary>
        /// <returns></returns>
        public int GetProjectCount()
        {
            return GetB01Info().Where(o => o.UnitType == "N").Count();
        }

        /// <summary>
        /// 获取工地数量根据用户ID
        /// </summary>
        /// <returns></returns>
        public int GetProjectCount(string user_id)
        {
            List<B01> unitList = HCQ2UI_Helper.OperateContext.Current.bllSession.B01.GetUnitDataByPermiss(Convert.ToInt32(user_id));
            unitList = unitList.Where(o => o.UnitType.Equals("N")).ToList();
            return unitList.Count();
        }

        /// <summary>
        /// 获取用户代码单位
        /// </summary>
        /// <param name="user_id"></param>
        /// <returns></returns>
        public List<B01> GetPerUnitByUserID(int user_id)
        {
            List<B01> unitList = HCQ2UI_Helper.OperateContext.Current.bllSession.B01.GetUnitDataByPermiss(user_id);
            if (unitList == null)
                return null;
            unitList = unitList.Where(o => o.UnitType.Equals("N")).OrderByDescending(o => o.DispOrder).ToList();
            return unitList;
        }

        #endregion

        #region 企业项目增删操作

        /// <summary>
        /// 完善项目信息
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public bool EditPorject(object obj)
        {
            FormCollection form = (FormCollection)obj;
            SM_CodeItemsBLL sm = new SM_CodeItemsBLL();
            B01 b = new B01();
            b.UnitStartDate = !string.IsNullOrEmpty(form["UnitStartDate"]) ? Convert.ToDateTime(form["UnitStartDate"]) : Convert.ToDateTime("9999-12-31");
            b.UnitEndDate = !string.IsNullOrEmpty(form["UnitEndDate"]) ? Convert.ToDateTime(form["UnitEndDate"]) : Convert.ToDateTime("9999-12-31");
            b.B0107 = form["B0107"];
            b.B0108 = form["B0108"];
            b.B0120 = form["B0120"];
            b.D010H = form["D010H"];
            b.B0111 = form["B0111"];
            b.B0112 = form["B0112"];
            b.B0180 = form["B0180"];
            b.B0181 = form["B0181"];

            #region 上报需要的数据

            b.FBR = form["FBR"];
            b.CBR = form["CBR"];
            b.GCLXPZWH = form["GCLXPZWH"];
            b.ZJLY = form["ZJLY"];
            b.HTBH = form["HTBH"];
            b.ZBBH = form["ZBBH"];
            b.XMJHZGQ = form["XMJHZGQ"];
            b.QYHTJ = form["QYHTJ"];
            b.CBRXMJLXM = form["CBRXMJLXM"];
            b.CBRXMJLZC = form["CBRXMJLZC"];
            b.CBRXMJLSFZH = form["CBRXMJLSFZH"];
            b.CBRXMJLZCJZSZGZSBH = form["CBRXMJLZCJZSZGZSBH"];
            b.CBRXMJLZCJZSZSZCBH = form["CBRXMJLZCJZSZSZCBH"];
            b.CBRXMJLZCJZSZYYZH = form["CBRXMJLZCJZSZYYZH"];
            if (!string.IsNullOrEmpty(form["XMHTQDRQ"]))
                b.XMHTQDRQ = Convert.ToDateTime(form["XMHTQDRQ"]);
            b.FBRZZ = form["FBRZZ"];
            b.FBRDH = form["FBRDH"];
            b.FBRFDDBR = form["FBRFDDBR"];
            b.FBRCZ = form["FBRCZ"];
            b.FBRKHYH = form["FBRKHYH"];
            b.FBRYHZH = form["FBRYHZH"];
            b.FBRYZBM = form["FBRYZBM"];
            b.FBRDZ = form["FBRDZ"];
            b.CBRZZ = form["CBRZZ"];
            b.CBRDH = form["CBRDH"];
            b.CBRFDDBR = form["CBRFDDBR"];
            b.CBRCZ = form["CBRCZ"];
            b.CBRKHYH = form["CBRKHYH"];
            b.CBRYHZH = form["CBRYHZH"];
            b.CBRYZBM = form["CBRYZBM"];
            b.CBRDZ = form["CBRDZ"];
            b.SSXZZGBM = form["SSXZZGBM"];
            b.BASBLX = form["BASBLX"];
            b.BASBBH = form["BASBBH"];
            b.SSWG = form["SSWG"];
            b.XMCJR = form["XMCJR"];
            b.FXMID = form["FXMID"];
            b.SSDWYHID = form["SSDWYHID"];
            b.SFCJGSBX = form["SFCJGSBX"];
            b.XMBZJYCJE = form["XMBZJYCJE"];
            b.LZZGY = form["LZZGY"];
            b.FXRQ = form["FXRQ"];
            b.ZZJGDM = form["ZZJGDM"];
            b.GSDJZZZL = form["GSDJZZZL"];
            b.GSDJZZHM = form["GSDJZZHM"];
            b.SHXYDM = form["SHXYDM"];
            b.LSJG = form["LSJG1"];
            b.GZFFZHSSYH = form["GZFFZHSSYH"];
            #endregion

            b.project_status = form["project_status"];
            b.B0114 = !string.IsNullOrEmpty(form["B0114"]) ? decimal.Parse(form["B0114"]) : 0;
            b.B0116 = !string.IsNullOrEmpty(form["B0116"]) ? decimal.Parse(form["B0116"]) : 0;
            b.B0118 = form["B0118"];
            b.B0185 = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss"));
            b.B0186 = HCQ2UI_Helper.OperateContext.Current.Usr.user_id.ToString();
            if (!string.IsNullOrEmpty(form["B0175"]))
            {
                b.B0175 = sm.GetCodeItemByCodeID("CP").Last(o => o.CodeItemName == form["B0175"]).CodeItemID;
            }
            string RowID = form["EditJianDie"];
            return Modify(b, o => o.RowID == RowID,
                "UnitStartDate", "UnitEndDate", "B0107", "B0108", "B0120", "D010H", "B0111", "B0112", "B0114"
                 , "B0116", "B0118", "B0175", "B0117", "B0185", "B0180", "B0181", "project_status",
                "FBR", "CBR", "GCLXPZWH", "ZJLY", "HTBH", "ZBBH", "XMJHZGQ", "QYHTJ",
                 "CBRXMJLXM", "CBRXMJLZC", "CBRXMJLSFZH", "CBRXMJLZCJZSZGZSBH", "CBRXMJLZCJZSZSZCBH", "CBRXMJLZCJZSZYYZH", "XMHTQDRQ", "FBRZZ",
                 "FBRDH", "FBRFDDBR", "FBRCZ", "FBRKHYH", "FBRYHZH", "FBRYZBM", "FBRDZ", "CBRZZ",
                 "CBRDH", "CBRFDDBR", "CBRCZ", "CBRKHYH", "CBRYHZH", "CBRYZBM", "CBRDZ", "SSXZZGBM",
                 "BASBLX", "BASBBH", "SSWG", "XMCJR", "FXMID", "SSDWYHID", "SFCJGSBX", "XMBZJYCJE",
                 "LZZGY", "FXRQ", "ZZJGDM", "GSDJZZZL", "GSDJZZHM", "SHXYDM", "LSJG", "GZFFZHSSYH") > 0;
        }
        /// <summary>
        /// 新增项目
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public bool AddUnit(object obj)
        {
            FormCollection form = (FormCollection)obj;
            B01 b = new B01();
            List<B01> list = GetB01Info();
            if (string.IsNullOrEmpty(form["JianDie"]))
            {
                //添加的第一层节点
                string newUnitID = "";
                string unit_id = list.Last(o => o.KeyParent == ".").UnitID;
                newUnitID = (int.Parse(unit_id) + 1).ToString();
                if (newUnitID.Length == 1)
                    newUnitID = "00" + newUnitID;
                if (newUnitID.Length == 2)
                    newUnitID = "0" + newUnitID;

                b.UnitID = newUnitID;
                b.KeyParent = ".";
            }
            else
            {
                //添加某一项的子节点
                var iChild = list.Where(o => o.KeyParent == form["JianDie"]);
                if (iChild != null && iChild.Count() > 0)
                {
                    //有其他子节点
                    var child = iChild.Last();
                    //前面的节点路劲
                    string beforeStr = child.UnitID.Substring(0, child.UnitID.Length - 3);
                    //后面三位节点路径
                    string afterStr = child.UnitID.Substring(beforeStr.Length, 3);
                    string newUnitID = "";
                    afterStr = Convert.ToInt32(afterStr).ToString();
                    if (afterStr.Length == 1)
                        newUnitID = beforeStr + "00" + (int.Parse(afterStr) + 1).ToString();
                    if (afterStr.Length == 2)
                        newUnitID = beforeStr = "0" + (int.Parse(afterStr) + 1).ToString();
                    if (afterStr.Length == 3)
                        newUnitID = beforeStr + (int.Parse(afterStr) + 1).ToString();

                    b.UnitID = newUnitID;
                    b.KeyParent = form["JianDie"];
                }
                else
                {
                    //没有其他子节点
                    b.UnitID = form["JianDie"] + "001";
                    b.KeyParent = form["JianDie"];

                    B01 fatherB01 = new B01();
                    fatherB01.KeyChild = 1;
                    string JianDie = form["JianDie"];
                    Modify(fatherB01, o => o.UnitID == JianDie);
                }
            }

            b.DispOrder = list.Max(o => o.DispOrder) + 1;
            b.KeyChild = 0;
            b.UnitType = "N";
            b.UnitStartDate = Convert.ToDateTime(DateTime.Now.Year + "-" + DateTime.Now.Month + "-" + DateTime.Now.Day);
            b.UnitEndDate = Convert.ToDateTime("9999-12-31");
            if (!string.IsNullOrEmpty(form["B0109"]))
                b.B0109 = Convert.ToDateTime(form["B0109"]);
            if (!string.IsNullOrEmpty(form["B0110"]))
                b.B0110 = Convert.ToDateTime(form["B0110"]);
            b.UnitName = form["UnitName"];
            b.B0107 = form["B0107"];
            b.B0108 = form["B0108"];
            b.B0120 = form["B0120"];
            b.D010H = form["D010H"];
            b.B0111 = form["B0111"];
            b.B0112 = form["B0112"];
            b.B0180 = form["B0180"];
            b.B0181 = form["B0181"];
            b.in_compay = form["in_compay"];
            b.project_status = form["project_status"];
            b.GCLB = form["GCLB"];
            b.FBDW = form["FBDW"];

            b.JSDWLXR = form["JSDWLXR"];
            b.JSDWLXRDH = form["JSDWLXRDH"];
            b.SGDWLXR = form["SGDWLXR"];
            b.SGDWLXRDH = form["SGDWLXRDH"];
            b.LZZGYYI = form["LZZGYYI"];
            b.LZZGYYILXFS = form["LZZGYYILXFS"];
            b.LZZGYER = form["LZZGYER"];
            b.LZZGYERLXFS = form["LZZGYERLXFS"];
            b.LZZGYSAN = form["LZZGYSAN"];
            b.LZZGYSANLXFS = form["LZZGYSANLXFS"];
            b.GZFFZHSSYH = form["GZFFZHSSYH"];

            b.B0114 = !string.IsNullOrEmpty(form["B0114"]) ? decimal.Parse(form["B0114"]) : 0;
            b.B0116 = !string.IsNullOrEmpty(form["B0116"]) ? decimal.Parse(form["B0116"]) : 0;
            b.B0118 = form["B0118"];
            b.B0183 = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss"));
            b.B0184 = HCQ2UI_Helper.OperateContext.Current.Usr.user_id.ToString();
            if (!string.IsNullOrEmpty(form["upLoadId"]))
            {
                b.upLoadId = form["upLoadId"];
                b.upLoadName = GetByUnitID(form["upLoadId"]).UnitName;
            }

            #region 上报需要的数据

            b.FBR = form["FBR"];
            b.CBR = form["CBR"];
            b.GCLXPZWH = form["GCLXPZWH"];
            b.ZJLY = form["ZJLY"];
            b.HTBH = form["HTBH"];
            b.ZBBH = form["ZBBH"];
            b.XMJHZGQ = form["XMJHZGQ"];
            b.QYHTJ = form["QYHTJ"];
            b.CBRXMJLXM = form["CBRXMJLXM"];
            b.CBRXMJLZC = form["CBRXMJLZC"];
            b.CBRXMJLSFZH = form["CBRXMJLSFZH"];
            b.CBRXMJLZCJZSZGZSBH = form["CBRXMJLZCJZSZGZSBH"];
            b.CBRXMJLZCJZSZSZCBH = form["CBRXMJLZCJZSZSZCBH"];
            b.CBRXMJLZCJZSZYYZH = form["CBRXMJLZCJZSZYYZH"];
            if (!string.IsNullOrEmpty(form["XMHTQDRQ"]))
                b.XMHTQDRQ = Convert.ToDateTime(form["XMHTQDRQ"]);
            b.FBRZZ = form["FBRZZ"];
            b.FBRDH = form["FBRDH"];
            b.FBRFDDBR = form["FBRFDDBR"];
            b.FBRCZ = form["FBRCZ"];
            b.FBRKHYH = form["FBRKHYH"];
            b.FBRYHZH = form["FBRYHZH"];
            b.FBRYZBM = form["FBRYZBM"];
            b.FBRDZ = form["FBRDZ"];
            b.CBRZZ = form["CBRZZ"];
            b.CBRDH = form["CBRDH"];
            b.CBRFDDBR = form["CBRFDDBR"];
            b.CBRCZ = form["CBRCZ"];
            b.CBRKHYH = form["CBRKHYH"];
            b.CBRYHZH = form["CBRYHZH"];
            b.CBRYZBM = form["CBRYZBM"];
            b.CBRDZ = form["CBRDZ"];
            b.SSXZZGBM = form["SSXZZGBM"];
            b.BASBLX = form["BASBLX"];
            b.BASBBH = form["BASBBH"];
            b.SSWG = form["SSWG1"];
            b.XMCJR = form["XMCJR"];
            b.FXMID = form["FXMID"];
            b.SSDWYHID = form["SSDWYHID"];
            b.SFCJGSBX = form["SFCJGSBX"];
            b.XMBZJYCJE = form["XMBZJYCJE"];
            b.LZZGY = form["LZZGY"];
            b.FXRQ = form["FXRQ"];
            b.ZZJGDM = form["ZZJGDM"];
            b.GSDJZZZL = form["GSDJZZZL"];
            b.GSDJZZHM = form["GSDJZZHM"];
            b.SHXYDM = form["SHXYDM"];
            b.LSJG = form["LSJG1"];

            #endregion

            if (!string.IsNullOrEmpty(form["B0175"]))
            {
                SM_CodeItemsBLL codeItem = new SM_CodeItemsBLL();
                b.B0175 = codeItem.GetCodeItemByCodeID("CP").Last(o => o.CodeItemName == form["B0175"]).CodeItemID; //CP
            }
            b.RowID = HCQ2_Common.SQL.SqlHelper.ExecuteScalar("select NEWID()").ToString().Replace("-", "").ToUpper();
            return Add(b) > 0;
        }
        /// <summary>
        /// 编辑项目
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public bool EditUnit(object obj)
        {
            FormCollection form = (FormCollection)obj;
            B01 b = new B01();
            b.UnitType = "N";
            b.UnitStartDate = Convert.ToDateTime(DateTime.Now.Year + "-" + DateTime.Now.Month + "-" + DateTime.Now.Day);
            b.UnitEndDate = Convert.ToDateTime("9999-12-31");
            b.UnitName = form["UnitName"];
            b.B0107 = form["B0107"];
            b.B0108 = form["B0108"];
            b.B0120 = form["B0120"];
            b.D010H = form["D010H"];
            b.B0111 = form["B0111"];
            b.B0112 = form["B0112"];
            b.B0130 = form["B0130"];
            b.B0113 = form["B0113"];
            b.B0180 = form["B0180"];
            b.B0181 = form["B0181"];
            b.in_compay = form["in_compay"];
            b.project_status = form["project_status"];
            b.GCLB = form["GCLB"];
            b.FBDW = form["FBDW"];

            if (!string.IsNullOrEmpty(form["B0109"]))
                b.B0109 = Convert.ToDateTime(form["B0109"]);
            if (!string.IsNullOrEmpty(form["B0110"]))
                b.B0110 = Convert.ToDateTime(form["B0110"]);

            b.JSDWLXR = form["JSDWLXR"];
            b.JSDWLXRDH = form["JSDWLXRDH"];
            b.SGDWLXR = form["SGDWLXR"];
            b.SGDWLXRDH = form["SGDWLXRDH"];
            b.LZZGYYI = form["LZZGYYI"];
            b.LZZGYYILXFS = form["LZZGYYILXFS"];
            b.LZZGYER = form["LZZGYER"];
            b.LZZGYERLXFS = form["LZZGYERLXFS"];
            b.LZZGYSAN = form["LZZGYSAN"];
            b.LZZGYSANLXFS = form["LZZGYSANLXFS"];
            b.GZFFZHSSYH = form["GZFFZHSSYH"];

            b.B0114 = !string.IsNullOrEmpty(form["B0114"]) ? decimal.Parse(form["B0114"]) : 0;
            b.B0115 = !string.IsNullOrEmpty(form["B0115"]) ? decimal.Parse(form["B0115"]) : 0;
            b.B0116 = !string.IsNullOrEmpty(form["B0116"]) ? decimal.Parse(form["B0116"]) : 0;
            b.B0118 = form["B0118"];
            b.B0185 = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss"));
            b.B0186 = HCQ2UI_Helper.OperateContext.Current.Usr.user_id.ToString();
            if (!string.IsNullOrEmpty(form["upLoadId"]))
            {
                b.upLoadId = form["upLoadId"];
                b.upLoadName = GetByUnitID(form["upLoadId"]).UnitName;
            }

            SM_CodeItemsBLL code = new SM_CodeItemsBLL();
            if (!string.IsNullOrEmpty(form["B0175"]))
            {
                b.B0175 = code.GetCodeItemByCodeID("CP").Last(o => o.CodeItemName == form["B0175"]).CodeItemID;
            }
            if (!string.IsNullOrEmpty(form["B0117"]))
            {
                b.B0117 = code.GetCodeItemByCodeID("45").Last(o => o.CodeItemName == form["B0117"]).CodeItemID;
            }

            #region 编辑上报数据

            b.FBR = form["FBR"];
            b.CBR = form["CBR"];
            b.GCLXPZWH = form["GCLXPZWH"];
            b.ZJLY = form["ZJLY"];
            b.HTBH = form["HTBH"];
            b.ZBBH = form["ZBBH"];
            b.XMJHZGQ = form["XMJHZGQ"];
            b.QYHTJ = form["QYHTJ"];
            b.CBRXMJLXM = form["CBRXMJLXM"];
            b.CBRXMJLZC = form["CBRXMJLZC"];
            b.CBRXMJLSFZH = form["CBRXMJLSFZH"];
            b.CBRXMJLZCJZSZGZSBH = form["CBRXMJLZCJZSZGZSBH"];
            b.CBRXMJLZCJZSZSZCBH = form["CBRXMJLZCJZSZSZCBH"];
            b.CBRXMJLZCJZSZYYZH = form["CBRXMJLZCJZSZYYZH"];
            if (!string.IsNullOrEmpty(form["XMHTQDRQ"]))
                b.XMHTQDRQ = Convert.ToDateTime(form["XMHTQDRQ"]);
            b.FBRZZ = form["FBRZZ"];
            b.FBRDH = form["FBRDH"];
            b.FBRFDDBR = form["FBRFDDBR"];
            b.FBRCZ = form["FBRCZ"];
            b.FBRKHYH = form["FBRKHYH"];
            b.FBRYHZH = form["FBRYHZH"];
            b.FBRYZBM = form["FBRYZBM"];
            b.FBRDZ = form["FBRDZ"];
            b.CBRZZ = form["CBRZZ"];
            b.CBRDH = form["CBRDH"];
            b.CBRFDDBR = form["CBRFDDBR"];
            b.CBRCZ = form["CBRCZ"];
            b.CBRKHYH = form["CBRKHYH"];
            b.CBRYHZH = form["CBRYHZH"];
            b.CBRYZBM = form["CBRYZBM"];
            b.CBRDZ = form["CBRDZ"];
            b.SSXZZGBM = form["SSXZZGBM"];
            b.BASBLX = form["BASBLX"];
            b.BASBBH = form["BASBBH"];
            b.SSWG = form["SSWG1"];
            b.XMCJR = form["XMCJR"];
            b.FXMID = form["FXMID"];
            b.SSDWYHID = form["SSDWYHID"];
            b.SFCJGSBX = form["SFCJGSBX"];
            b.XMBZJYCJE = form["XMBZJYCJE"];
            b.LZZGY = form["LZZGY"];
            b.FXRQ = form["FXRQ"];
            b.ZZJGDM = form["ZZJGDM"];
            b.GSDJZZZL = form["GSDJZZZL"];
            b.GSDJZZHM = form["GSDJZZHM"];
            b.SHXYDM = form["SHXYDM"];
            b.LSJG = form["LSJG1"];

            #endregion

            string RowID = form["EditJianDie"];

            return Modify(b, o => o.RowID == RowID,
                 "UnitType", "UnitStartDate", "UnitEndDate", "UnitName", "B0107", "B0108"
                 , "B0120", "D010H", "B0111", "B0112", "B0130", "B0113", "B0114", "B0115"
                 , "B0109", "B0110", "JSDWLXR", "JSDWLXRDH", "SGDWLXR", "SGDWLXRDH", "LZZGYYI", "LZZGYYILXFS"
                 , "LZZGYER", "LZZGYERLXFS", "LZZGYSAN", "LZZGYSANLXFS", "upLoadId", "upLoadName"
                 , "B0116", "B0118", "B0175", "B0117", "B0185", "B0186",
                 "B0180", "B0181", "project_status", "in_compay", "GCLB", "FBDW",
                 "FBR", "CBR", "GCLXPZWH", "ZJLY", "HTBH", "ZBBH", "XMJHZGQ", "QYHTJ",
                 "CBRXMJLXM", "CBRXMJLZC", "CBRXMJLSFZH", "CBRXMJLZCJZSZGZSBH", "CBRXMJLZCJZSZSZCBH", "CBRXMJLZCJZSZYYZH", "XMHTQDRQ", "FBRZZ",
                 "FBRDH", "FBRFDDBR", "FBRCZ", "FBRKHYH", "FBRYHZH", "FBRYZBM", "FBRDZ", "CBRZZ",
                 "CBRDH", "CBRFDDBR", "CBRCZ", "CBRKHYH", "CBRYHZH", "CBRYZBM", "CBRDZ", "SSXZZGBM",
                 "BASBLX", "BASBBH", "SSWG", "XMCJR", "FXMID", "SSDWYHID", "SFCJGSBX", "XMBZJYCJE",
                 "LZZGY", "FXRQ", "ZZJGDM", "GSDJZZZL", "GSDJZZHM", "SHXYDM", "LSJG", "GZFFZHSSYH") > 0;
        }

        #endregion

        #region 项目上报

        private static string xxly = "HVvxulonjCwuD8Dogh20VLZvxKlejeRhr3HLXHlP9tT99q6x54eerLKH0qVDd6b5a7H7nJ0Z2ggc1GkXBYPK9LZN378zQpgy11UlQyIxpFfS0LYiHzGI6zI/YQDwhyNq5kgiOXeYvP6fZIwYKDtwvGx5xSgNtLrfNt3X8t7mFs=";

        public void UpDataProject(string UnitID)
        {
            B01 Unit = GetByUnitID(UnitID);
            if (!string.IsNullOrEmpty(Unit.in_compay)) {
                string serviceName = "HSMWService";
                string methodName = "UploadCompProInfo";

                T_CompProInfo com = new T_CompProInfoBLL().GetByComID(Convert.ToInt32(Unit.in_compay));

                string param = "<?xml version=\"1.0\" encoding=\"GBK\"?><p>";
                param += GetConPanyData(com);
                param += "<d k=\"vds\">";
                param += GetProjectData(Unit, com);
                param += "</d>";
                param += "</p>";

                //正式地址
                WebUpData.uddi client2 = new WebUpData.uddi();
                ServicePointManager.ServerCertificateValidationCallback = ValidateServerCertificate;
                client2.Url = "https://222.85.128.67:8088/dwlesbserver/services/uddi?wsdl";
                X509Certificate xs = new X509Certificate("E:\\RSA2008root.cer");
                client2.ClientCertificates.Add(xs);

                string mess = client2.invokeService(serviceName, methodName, param);
                if (mess.Contains("服务调用成功！"))
                {
                    ChangeUnitUpLoad(Unit.UnitName, "01");
                }
            }
        }

        private bool ValidateServerCertificate(object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors)
        {
            return true;
        }

        /// <summary>
        /// 组装企业信息
        /// </summary>
        /// <param name="com"></param>
        /// <returns></returns>
        private string GetConPanyData(T_CompProInfo com)
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
        private string GetProjectData(B01 dtProject, T_CompProInfo com)
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

        /// <summary>
        /// 项目改写上报状态
        /// </summary>
        /// <param name="UnitName"></param>
        public void ChangeUnitUpLoad(string UnitName, string upType)
        {
            string upContent = "";
            switch (upType)
            {
                case "01":
                    B01 unit = new B01();
                    unit.if_upload = "1";
                    Modify(unit, o => o.UnitName == UnitName, "if_upload");
                    upContent = UnitName;
                    break;
                case "02":
                    upContent = "上报项目名称为：<" + UnitName + ">所有人员基本信息";
                    break;
                case "03":
                    upContent = "上报项目名称为：<" + UnitName + ">所有人员照片不为空的照片信息";
                    break;
                case "04":
                    upContent = "上报项目名称为：<" + UnitName + ">所有人员考勤信息";
                    break;
                case "05":
                    upContent = "上报<" + UnitName + ">所有工资发放信息";
                    break;
                case "06":
                    upContent = "上报<" + UnitName + ">所有欠薪信息";
                    break;
                case "07":
                    upContent = "上报项目名称为：<" + UnitName + ">个人欠薪信息";
                    break;
                case "08":
                    upContent = "上报项目名称为：<" + UnitName + ">所有人员附件信息(含合同信息)";
                    break;
                case "09":
                    upContent = "<" + UnitName + ">项目工资专户信息";
                    break;
                default:
                    break;
            }
            string unit_id = GetByUnitName(UnitName).UnitID;
            new BB_UpDataLogBLL().InsertDataLog(upType, upContent, 1, unit_id);
        }

        #endregion

        #region APP接口 

        /// <summary>
        /// 获取企业项目
        /// </summary>
        /// <param name="compay"></param>
        /// <returns></returns>
        public List<HCQ2_Model.AppModel.UnitReturn> GetEnterList(HCQ2_Model.AppModel.Compay compay)
        {
            List<HCQ2_Model.AppModel.UnitReturn> list = new List<HCQ2_Model.AppModel.UnitReturn>();
            HCQ2_Model.AppModel.UnitReturn rUnit = new HCQ2_Model.AppModel.UnitReturn();
            //获取企业项目信息
            List<B01> unitlist = new List<B01>();//GetB01Info();
            //获取当前调用接口人员类型
            T_User u = DBSession.IT_UserDAL.Select(s => s.user_guid.Equals(compay.userid)).FirstOrDefault();
            unitlist = GetPerUnitByUserID(u.user_id);
            if (!string.IsNullOrEmpty(compay.unit_name))
                unitlist = unitlist?.Where(s => s.UnitName.Contains(compay.unit_name)).OrderBy(o => o.DispOrder).ToList();

            foreach (var item in unitlist)
            {
                rUnit = new HCQ2_Model.AppModel.UnitReturn();
                rUnit.unit_name = item.UnitName;
                rUnit.unit_code = item.UnitID;
                rUnit.contract_money = item.B0114.ToString();
                rUnit.unit_contact = string.IsNullOrEmpty(item.SGDWLXR) ? "" : item.SGDWLXR;
                rUnit.unit_phone = string.IsNullOrEmpty(item.SGDWLXRDH) ? "" : item.SGDWLXRDH;
                rUnit.unit_type = item.UnitType;
                rUnit.project_type = item.GCLB;
                rUnit.unit_security = item.B0116;
                rUnit.worker_num = DBSession.IA01DAL.GetTotalPersonCountByUser("'" + item.UnitID + "'");
                list.Add(rUnit);
            }
            return list;
        }

        /// <summary>
        /// 分页获取企业项目
        /// </summary>
        /// <param name="compay"></param>
        /// <returns></returns>
        public List<HCQ2_Model.AppModel.UnitReturn> GetEnterRowPageList(HCQ2_Model.AppModel.CompayList compay)
        {
            List<HCQ2_Model.AppModel.UnitReturn> list = new List<HCQ2_Model.AppModel.UnitReturn>();
            HCQ2_Model.AppModel.UnitReturn rUnit = new HCQ2_Model.AppModel.UnitReturn();
            //获取企业项目信息
            List<B01> unitlist = new List<B01>();//GetB01Info();
            //获取当前调用接口人员类型
            T_User u = DBSession.IT_UserDAL.Select(s => s.user_guid.Equals(compay.userid)).FirstOrDefault();
            unitlist = GetPerUnitByUserID(u.user_id);

            if (!string.IsNullOrEmpty(compay.unit_name))
                unitlist = unitlist?.Where(s => s.UnitName.Contains(compay.unit_name)).OrderByDescending(s => s.DispOrder).Skip((compay.page - 1) * compay.rows).Take(compay.rows).ToList();
            else
                unitlist = unitlist?.OrderByDescending(s => s.DispOrder).Skip((compay.page - 1) * compay.rows).Take(compay.rows).ToList();

            foreach (var item in unitlist)
            {
                rUnit = new HCQ2_Model.AppModel.UnitReturn();
                rUnit.unit_name = item.UnitName;
                rUnit.unit_code = item.UnitID;
                rUnit.contract_money = item.B0114.ToString();
                rUnit.unit_contact = string.IsNullOrEmpty(item.SGDWLXR) ? "" : item.SGDWLXR;
                rUnit.unit_phone = string.IsNullOrEmpty(item.SGDWLXRDH) ? "" : item.SGDWLXRDH;
                rUnit.unit_type = item.UnitType;
                rUnit.project_type = item.GCLB;
                rUnit.unit_security = item.B0116;
                rUnit.worker_num = DBSession.IA01DAL.GetTotalPersonCountByUser("'" + item.UnitID + "'");
                list.Add(rUnit);
            }
            return list;
        }

        /// <summary>
        /// 获取详细企业项目
        /// </summary>
        /// <param name="compay"></param>
        /// <returns></returns>
        public List<object> GetEnterProjectDetail(HCQ2_Model.AppModel.Compay compay)
        {
            List<object> list = new List<object>();
            HCQ2_Model.AppModel.ProjectDetail rProject = new HCQ2_Model.AppModel.ProjectDetail();
            HCQ2_Model.AppModel.CompayDetail rCompay = new HCQ2_Model.AppModel.CompayDetail();
            List<B01> unitList = GetB01Info();
            var data = unitList.Where(o => o.UnitName == compay.unit_name).FirstOrDefault();

            if (data != null)
            {
                //项目信息
                rProject.unit_name = data.UnitName;
                rProject.start_date = data.UnitStartDate.ToString();
                rProject.contract_money = data.B0114.ToString();

                rProject.worker_num = DBSession.IA01DAL.GetTotalPersonCountByUser("'" + data.UnitID + "'");
                rProject.unit_contact = data.SGDWLXR;
                rProject.contact_phone = data.SGDWLXRDH;
                rProject.unit_security = data.B0116.ToString();
                rProject.project_type = data.GCLB;
                list.Add(rProject);

                //企业信息
                if (!string.IsNullOrEmpty(data.in_compay))
                {
                    var dataCom = new T_CompProInfoBLL().Select(o => o.com_id.ToString() == data.in_compay).FirstOrDefault();
                    rCompay.compay_code = dataCom.tyshxydm;
                    rCompay.compay_name = dataCom.dwmc;
                }
                rCompay.XXFZR = data.SGDWLXR;
                rCompay.XXFZRDH = data.SGDWLXRDH;
                rCompay.LZZGYYI = data.LZZGYYI;
                rCompay.LZZGYYIDH = data.LZZGYYILXFS;
                rCompay.LZZGYER = data.LZZGYER;
                rCompay.LZZGYERDH = data.LZZGYERLXFS;
                rCompay.LZZGYSAN = data.LZZGYSAN;
                rCompay.LZZGYSANDH = data.LZZGYSANLXFS;

                list.Add(rCompay);
            }

            return list;
        }

        /// <summary>
        /// 获取项目人员明细
        /// </summary>
        /// <param name="compay"></param>
        /// <returns></returns>
        public List<HCQ2_Model.AppModel.UnitPerson> GetEnterPersonList(HCQ2_Model.AppModel.CompayPersonDetail compay)
        {
            List<HCQ2_Model.AppModel.UnitPerson> list = new List<HCQ2_Model.AppModel.UnitPerson>();
            HCQ2_Model.AppModel.UnitPerson rPerson = new HCQ2_Model.AppModel.UnitPerson();
            string unit_id = "";
            var data = GetB01Info().Where(o => o.UnitName == compay.unit_name);
            if (data.Count() <= 0)
                return list;
            unit_id = GetB01Info().Where(o => o.UnitName == compay.unit_name).FirstOrDefault().UnitID;

            DataTable dt = DBSession.IA01DAL.GetPersonByUnitID(unit_id);
            if (!string.IsNullOrEmpty(compay.person_name))
            {
                dt = dt.Select(" A0101 like '%" + compay.person_name + "%' ").CopyToDataTable();
            }

            if (dt != null)
            {
                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        rPerson = new HCQ2_Model.AppModel.UnitPerson();
                        rPerson.person_name = dt.Rows[i]["A0101"].ToString();
                        rPerson.person_phone = dt.Rows[i]["C0104"].ToString();
                        rPerson.person_jobs = dt.Rows[i]["E0386"].ToString();
                        list.Add(rPerson);
                    }
                }
            }

            return list;
        }

        /// <summary>
        /// 首页统计
        /// </summary>
        /// <returns></returns>
        public HCQ2_Model.AppModel.MainCount GetStatisNum(HCQ2_Model.AppModel.WorkPerson orgid)
        {
            T_UserBLL user = new T_UserBLL();
            int user_id = user.Select(o => o.user_guid == orgid.userid).FirstOrDefault().user_id;
            HCQ2_Model.AppModel.MainCount main = new HCQ2_Model.AppModel.MainCount();
            main.compay_unit_count = GetProjectCount(user_id.ToString());
            main.total_person_count = new A01BLL().GetPeopleSum(user_id);
            main.check_day_count = new View_A02BLL().GetAttendanceTrue(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, user_id.ToString());
            main.back_pay_money = Convert.ToDouble(new View_QXTJBLL().GetStaticWagePerson(user_id).Rows[0]["wage"]);

            return main;
        }

        /// <summary>
        /// 大数据展示屏企业数量、务工人员、打卡人员统计
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public HCQ2_Model.RollScreenModel.MainData GetMainEnteriseStatis()
        {
            HCQ2_Model.RollScreenModel.MainData main = new HCQ2_Model.RollScreenModel.MainData();
            main.enterise_num = GetProjectCount();
            main.worker_num = new A01BLL().GetPeopleSum();
            View_A02BLL view = new View_A02BLL();
            main.today_check_workers = view.GetAttendanceTrue(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
            return main;
        }

        /// <summary>
        /// 大数据展示项目详情统计
        /// </summary>
        /// <returns></returns>
        public List<HCQ2_Model.RollScreenModel.Project> GetProjectDetailList()
        {
            List<HCQ2_Model.RollScreenModel.Project> list = new List<HCQ2_Model.RollScreenModel.Project>();
            HCQ2_Model.RollScreenModel.Project project = new HCQ2_Model.RollScreenModel.Project();

            List<B01> unitList = new B01BLL().Select(o => o.UnitType == "N");
            HCQ2_Model.AppModel.WorkCount wk = new HCQ2_Model.AppModel.WorkCount();

            foreach (var item in unitList)
            {
                project = new HCQ2_Model.RollScreenModel.Project();
                project.unit_id = item.UnitID;
                project.unit_name = item.UnitName;
                project.total_worker = DBSession.IA01DAL.GetTotalPersonCountByUser("'" + item.UnitID + "'");

                //今日打卡人数
                wk = new HCQ2_Model.AppModel.WorkCount();
                wk.orgid = item.UnitID;
                wk.work_date = DateTime.Now.ToString("yyyy-MM-dd");
                project.check_worker = DBSession.IView_A02DAL.GetWorkCountByUnitID(item.UnitID, DateTime.Now.Year.ToString(), DateTime.Now.Month.ToString(), DateTime.Now.Day.ToString());
                list.Add(project);
            }

            return list;
        }

        /// <summary>
        /// 大数据展示项目详情统计>具体打卡人员信息
        /// </summary>
        /// <param name="unit"></param>
        /// <returns></returns>
        public List<Dictionary<string, object>> GetProjectCheckDetail(HCQ2_Model.RollScreenModel.ProjectCheckUnit unit)
        {
            List<Dictionary<string, object>> objList = new List<Dictionary<string, object>>();
            Dictionary<string, object> dic = new Dictionary<string, object>();
            List<HCQ2_Model.RollScreenModel.ProjectCheck> list = new List<HCQ2_Model.RollScreenModel.ProjectCheck>();
            HCQ2_Model.RollScreenModel.ProjectCheck rCheck = new HCQ2_Model.RollScreenModel.ProjectCheck();

            StringBuilder sbSql = new StringBuilder();

            //已打卡人员
            DataTable dtCheck = DBSession.IView_A02DAL.GetWorkByUnitData(unit.unit_id, DateTime.Now.Year.ToString(), DateTime.Now.Month.ToString(), DateTime.Now.Day.ToString());

            string mPerson = string.Empty;
            //已经打卡人员的person_id
            if (dtCheck != null)
            {
                for (int i = 0; i < dtCheck.Rows.Count; i++)
                {
                    string person_name = dtCheck.Rows[i]["A0101"].ToString();
                    var data = list.Where(o => o.person_name == person_name);
                    if (data.Count() > 0)
                    {
                        continue;
                    }
                    rCheck = new HCQ2_Model.RollScreenModel.ProjectCheck();
                    rCheck.person_name = person_name;
                    rCheck.worker_name = dtCheck.Rows[i]["E0386"].ToString();
                    rCheck.person_phone = dtCheck.Rows[i]["C0104"].ToString();
                    rCheck.check_time = Convert.ToDateTime(dtCheck.Rows[i]["A0201"]).ToString("HH:mm");
                    list.Add(rCheck);

                    if (string.IsNullOrEmpty(mPerson))
                        mPerson = "'" + dtCheck.Rows[i]["PersonID"].ToString() + "'";
                    else
                        mPerson += ",'" + dtCheck.Rows[i]["PersonID"].ToString() + "'";
                }
            }
            dic.Add("ok", list);

            //没有打卡的人员
            DataTable dtNoCheck = DBSession.IA01DAL.GetPersonByStrPersonID(unit.unit_id, mPerson);

            list = new List<HCQ2_Model.RollScreenModel.ProjectCheck>();
            if (dtNoCheck != null)
            {
                for (int i = 0; i < dtNoCheck.Rows.Count; i++)
                {
                    rCheck = new HCQ2_Model.RollScreenModel.ProjectCheck();
                    rCheck.person_name = dtNoCheck.Rows[i]["A0101"].ToString();
                    rCheck.worker_name = dtNoCheck.Rows[i]["E0386"].ToString();
                    rCheck.person_phone = dtNoCheck.Rows[i]["C0104"].ToString();
                    rCheck.check_time = "";
                    list.Add(rCheck);
                }
            }
            dic.Add("fin", list);
            objList.Add(dic);
            return objList;
        }

        /// <summary>
        /// 大数据展示欠薪预警
        /// </summary>
        /// <returns></returns>
        public List<HCQ2_Model.RollScreenModel.DeWage> GetDeWageList()
        {
            List<HCQ2_Model.RollScreenModel.DeWage> list = new List<HCQ2_Model.RollScreenModel.DeWage>();
            HCQ2_Model.RollScreenModel.DeWage rWage = new HCQ2_Model.RollScreenModel.DeWage();

            List<View_QXTJ> qxList = new View_QXTJBLL().Select(o => o.QXTJ01 > 0);
            foreach (var item in qxList)
            {
                rWage = new HCQ2_Model.RollScreenModel.DeWage();
                rWage.unit_id = item.UnitID;
                rWage.unit_name = item.B0001Name;
                rWage.de_wage = item.QXTJ01;
                rWage.de_personcount = item.People;
                rWage.security_money = item.B0116;
                list.Add(rWage);
            }
            return list;
        }

        /// <summary>
        /// 大数据展示欠薪预警>>>项目详细信息
        /// </summary>
        /// <param name="unit"></param>
        /// <returns></returns>
        public HCQ2_Model.RollScreenModel.DeWageProjectDetail GetDeWageProjectDetail(HCQ2_Model.RollScreenModel.ProjectCheckUnit unit)
        {
            HCQ2_Model.RollScreenModel.DeWageProjectDetail detail = new HCQ2_Model.RollScreenModel.DeWageProjectDetail();
            DataTable dt = DBSession.IView_QXTJDAL.GetProjectQxtjByUnitID(unit.unit_id);
            detail.de_personcount = dt.Rows[0]["People"].ToString();
            detail.de_wage = dt.Rows[0]["QXTJ01"].ToString();
            if (!string.IsNullOrEmpty(dt.Rows[0]["B0109"].ToString()))
                detail.project_start = Convert.ToDateTime(dt.Rows[0]["B0109"]).ToString("yyyy-MM-dd");
            else
                detail.project_start = dt.Rows[0]["B0109"].ToString();
            detail.bargain_money = dt.Rows[0]["B0114"].ToString();
            detail.security_money = dt.Rows[0]["B0116"].ToString();
            detail.project_contact = dt.Rows[0]["SGDWLXR"].ToString();
            detail.contact_phone = dt.Rows[0]["SGDWLXRDH"].ToString();
            detail.project_address = dt.Rows[0]["B0112"].ToString();
            detail.SGDWLXR = dt.Rows[0]["SGDWLXR"].ToString();
            detail.SGDWLXRDH = dt.Rows[0]["SGDWLXRDH"].ToString();
            detail.workers_count = DBSession.IA01DAL.GetTotalPersonCountByUser("'" + unit.unit_id + "'").ToString();

            return detail;
        }

        /// <summary>
        /// 大数据展示务工人员统计>根据年龄
        /// </summary>
        /// <returns></returns>
        public List<object> GetStatisAge()
        {
            List<object> list = new List<object>();
            List<string> listName = new List<string>();
            listName.Add("18岁以下");
            listName.Add("19-25");
            listName.Add("26-35");
            listName.Add("36-45");
            listName.Add("46-60");
            listName.Add("60岁以上");
            List<string> listItem = new List<string>();
            listItem.Add("0,18");
            listItem.Add("19,25");
            listItem.Add("26,35");
            listItem.Add("36,45");
            listItem.Add("46,60");
            listItem.Add("61,100");
            List<object> listCount = new List<object>();

            foreach (var item in listItem)
            {
                string[] str = item.Split(',');
                listCount.Add(DBSession.IA01DAL.GetPersonCountByAge(Convert.ToInt32(str[0]), Convert.ToInt32(str[1])));
            }

            list.Add(listName);
            list.Add(listCount);
            return list;
        }

        /// <summary>
        /// 大数据展示务工人员统计>根据工种
        /// </summary>
        /// <returns></returns>
        public List<object> GetStatisJobs(HCQ2_Model.RollScreenModel.DataViewJosb workRows)
        {
            List<object> rList = new List<object>();
            List<string> listJobs = new List<string>();
            List<int> listCount = new List<int>();
            List<B01> list = GetB01Info();
            if (list != null)
            {
                string unitCodeWhere = "'" + string.Join("','", list.Select(o => o.UnitID)) + "'";
                DataTable dtJobs = DBSession.IA01DAL.GetUserWork(unitCodeWhere);
                DataTable dtTotal = DBSession.IA01DAL.GetPersonWorkByUnit(unitCodeWhere);

                SM_CodeItemsBLL codeItem = new SM_CodeItemsBLL();
                var data = codeItem.GetCodeItemByCodeID("JA");

                JobsModel job = new JobsModel();
                List<JobsModel> jobList = new List<JobsModel>();

                for (int i = 0; i < dtJobs.Rows.Count; i++)
                {
                    if (string.IsNullOrEmpty(dtJobs.Rows[i]["E0386"].ToString()))
                    {
                        job = new JobsModel();
                        job.jobsName = "其他";
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
                    if (i > (workRows.rows - 1))
                        break;
                    listJobs.Add(jobList[i].jobsName);
                    listCount.Add(jobList[i].jobsCount);
                }
                rList.Add(listJobs);
                rList.Add(listCount);
            }
            return rList;
        }

        /// <summary>
        /// 获取地图项目信息
        /// </summary>
        /// <returns></returns>
        public List<HCQ2_Model.RollScreenModel.StatisMiddle> GetMiddleMapStatis()
        {
            DataTable dt = DBSession.IA01DAL.GetRollViewModel();
            return HCQ2_Common.Data.DataTableHelper.DataTableToIList<HCQ2_Model.RollScreenModel.StatisMiddle>(dt);
        }

        /// <summary>
        /// 采集趋势图
        /// </summary>
        /// <returns></returns>
        public List<Dictionary<string, object>> GetCollectTrend()
        {
            List<Dictionary<string, object>> list = new List<Dictionary<string, object>>();
            Dictionary<string, object> dic = new Dictionary<string, object>();
            StringBuilder sbSql = new StringBuilder();
            List<int> pCount = new List<int>();
            List<int> bCount = new List<int>();
            List<string> listTime = new List<string>();

            int year = DateTime.Now.Year;
            int month = DateTime.Now.Month;

            for (int i = 1; i <= month; i++)
            {
                pCount.Add(DBSession.IA01DAL.GetSaveByYearMonth(year, i));
                bCount.Add(DBSession.IB01DAL.GetSaveByYearMonth(year, i));
                listTime.Add(year + "-" + i);
            }
            dic.Add("person_count", pCount);
            dic.Add("project_count", bCount);
            dic.Add("date_time", listTime);
            list.Add(dic);
            return list;
        }

        #endregion

        #region 区域项目树

        /// <summary>
        /// 根据用户ID获取区域项目树集合
        /// </summary>
        /// <param name="user_id"></param>
        /// <returns></returns>
        public List<AreaUnitModel> GetPerUserAreaUnit(int user_id)
        {
            List<AreaUnitModel> rList = new List<AreaUnitModel>();
            List<B01> unitList = new List<B01>();
            if (user_id == 0)
                unitList = Select(o => o.UnitID.Length == 3);//0表示所有项目
            else
                unitList = GetUnitDataByPermiss(user_id).Where(o => o.UnitID.Length == 3).ToList();
            string areaCode = string.Join("','", unitList.Where(o => !string.IsNullOrEmpty(o.LSJG)).Select(o => o.LSJG));

            StringBuilder sbSql = new StringBuilder();
            sbSql.AppendFormat("select * from SM_CodeItems where CodeID='AB'");
            sbSql.AppendFormat(" and CodeItemID in ('{0}') ", areaCode);

            StringBuilder _allCode = new StringBuilder();
            List<SM_CodeItems> areaList = HCQ2_Common.Data.DataTableHelper.DataTableToIList<SM_CodeItems>(HCQ2_Common.SQL.SqlHelper.ExecuteDataTable(sbSql.ToString()));
            foreach (var item in areaList)
            {
                if (item.CodeItemID.Length == 4)
                {
                    _allCode.AppendFormat(",'" + item.CodeItemID.Substring(0, 2) + "'");
                    _allCode.AppendFormat(",'" + item.CodeItemID + "'");
                }
                else if (item.CodeItemID.Length == 6)
                {
                    _allCode.AppendFormat(",'" + item.CodeItemID.Substring(0, 2) + "'");
                    _allCode.AppendFormat(",'" + item.CodeItemID.Substring(0, 4) + "'");
                    _allCode.AppendFormat(",'" + item.CodeItemID + "'");
                }
            }
            //获取需要显示的省市县行政区域
            sbSql = new StringBuilder();
            sbSql.AppendFormat("select * from SM_CodeItems where CodeID='AB'");
            sbSql.AppendFormat(" and CodeItemID in ({0}) ", _allCode.ToString().Substring(1, _allCode.Length - 1));
            areaList = HCQ2_Common.Data.DataTableHelper.DataTableToIList<SM_CodeItems>(HCQ2_Common.SQL.SqlHelper.ExecuteDataTable(sbSql.ToString()));

            List<SM_CodeItems> areaParentList = areaList.Where(o => o.Parent == ".").ToList();
            foreach (var item in areaParentList)
            {
                AreaUnitModel areaUnit = new AreaUnitModel();
                areaUnit.area_code = item.CodeItemID;
                areaUnit.area_name = item.CodeItemName;
                areaUnit.text = item.CodeItemName;
                areaUnit.type = "1";
                var data = areaList.Where(o => o.Parent == item.CodeItemID).ToList();
                areaUnit.children = GetSonNodes(item.CodeItemID, data, areaList, unitList);
                rList.Add(areaUnit);
            }

            var areaNull = unitList.Where(o => string.IsNullOrEmpty(o.SSWG));
            //剩余的项目（所属网格为空的项目）
            if (areaNull.Count() > 0)
            {
                foreach (var item in areaNull)
                {
                    AreaUnitModel areaUnit = new AreaUnitModel();
                    areaUnit.unit_id = item.UnitID;
                    areaUnit.text = item.UnitName;
                    areaUnit.unit_pid = item.KeyParent;
                    areaUnit.type = "2";
                    rList.Add(areaUnit);
                }
            }

            return rList;
        }

        private List<AreaUnitModel> GetSonNodes(string area_code, List<SM_CodeItems> nodesList, List<SM_CodeItems> allAreaList, List<B01> unitList)
        {
            List<AreaUnitModel> rList = new List<AreaUnitModel>();

            //先判断该区域的所属项目
            var perUnit = unitList.Where(o => o.SSWG == area_code);
            if (perUnit.Count() > 0)
            {
                foreach (var unit in perUnit)
                {
                    AreaUnitModel areaUnit = new AreaUnitModel();
                    areaUnit = new AreaUnitModel();
                    areaUnit.unit_id = unit.UnitID;
                    areaUnit.text = unit.UnitName;
                    areaUnit.unit_pid = unit.KeyParent;
                    areaUnit.type = "2";
                    rList.Add(areaUnit);
                }
            }

            foreach (var item in nodesList)
            {
                AreaUnitModel areaUnit = new AreaUnitModel();
                areaUnit.area_code = item.CodeItemID;
                areaUnit.area_name = item.CodeItemName;

                //添加所属项目数量
                var count = unitList.Where(o => o.SSWG == item.CodeItemID).Count();
                if (count > 0)
                    areaUnit.area_name += "(" + count + ")";

                areaUnit.text = item.CodeItemName;
                areaUnit.type = "1";
                var data = allAreaList.Where(o => o.Parent == item.CodeItemID);
                if (data.Count() > 0)
                {
                    areaUnit.children = GetSonNodes(item.CodeItemID, data.ToList(), allAreaList, unitList);
                }
                else
                {
                    //最后一层，判断是否有所属项目
                    var unitData = unitList.Where(o => o.SSWG == item.CodeItemID);
                    if (unitData.Count() > 0)
                    {
                        areaUnit.text = item.CodeItemName + "(" + unitData.Count() + ")";
                        areaUnit.children = GetLastUnit(unitData);
                    }
                }

                rList.Add(areaUnit);
            }

            return rList;
        }

        private List<AreaUnitModel> GetLastUnit(IEnumerable<B01> perUnit)
        {
            List<AreaUnitModel> rList = new List<AreaUnitModel>();
            //先判断该区域的所属项目
            foreach (var unit in perUnit)
            {
                AreaUnitModel areaUnit = new AreaUnitModel();
                areaUnit = new AreaUnitModel();
                areaUnit.unit_id = unit.UnitID;
                areaUnit.text = unit.UnitName;
                areaUnit.unit_pid = unit.KeyParent;
                areaUnit.type = "2";
                rList.Add(areaUnit);
            }
            return rList;
        }

        /// <summary>
        /// 根据用户ID获取区域项目树集合--没有树结构的
        /// </summary>
        /// <param name="user_id"></param>
        /// <returns></returns>
        public List<AreaUnitModel> GetPerUserAreaUnitInfo(int user_id)
        {
            List<AreaUnitModel> rList = new List<AreaUnitModel>();
            AreaUnitModel area = new AreaUnitModel();

            List<B01> unitList = new List<B01>();
            if (user_id == 0)
                unitList = Select(o => o.UnitID.Length == 3);//0表示所有项目
            else
                unitList = GetUnitDataByPermiss(user_id).Where(o => o.UnitID.Length == 3).ToList();
            string areaCode = string.Join("','", unitList.Where(o => !string.IsNullOrEmpty(o.LSJG)).Select(o => o.LSJG));
            foreach (var item in unitList)
            {
                area = new AreaUnitModel();
                area = new AreaUnitModel();
                area.area_code = item.LSJG;
                area.unit_id = item.UnitID;
                area.text = item.UnitName;
                area.unit_pid = item.KeyParent;
                area.type = "2";
                rList.Add(area);
            }


            StringBuilder sbSql = new StringBuilder();
            sbSql.AppendFormat("select * from SM_CodeItems where CodeID='AB'");
            sbSql.AppendFormat(" and CodeItemID in ('{0}') ", areaCode);

            StringBuilder _allCode = new StringBuilder();
            List<SM_CodeItems> areaList = HCQ2_Common.Data.DataTableHelper.DataTableToIList<SM_CodeItems>(HCQ2_Common.SQL.SqlHelper.ExecuteDataTable(sbSql.ToString()));
            foreach (var item in areaList)
            {
                if (item.CodeItemID.Length == 4)
                {
                    _allCode.AppendFormat(",'" + item.CodeItemID.Substring(0, 2) + "'");
                    _allCode.AppendFormat(",'" + item.CodeItemID + "'");
                }
                else if (item.CodeItemID.Length == 6)
                {
                    _allCode.AppendFormat(",'" + item.CodeItemID.Substring(0, 2) + "'");
                    _allCode.AppendFormat(",'" + item.CodeItemID.Substring(0, 4) + "'");
                    _allCode.AppendFormat(",'" + item.CodeItemID + "'");
                }
            }
            //获取需要显示的省市县行政区域
            sbSql = new StringBuilder();
            sbSql.AppendFormat("select * from SM_CodeItems where CodeID='AB'");
            sbSql.AppendFormat(" and CodeItemID in ({0}) ", _allCode.ToString().Substring(1, _allCode.Length - 1));
            areaList = HCQ2_Common.Data.DataTableHelper.DataTableToIList<SM_CodeItems>(HCQ2_Common.SQL.SqlHelper.ExecuteDataTable(sbSql.ToString()));

            foreach (var item in areaList)
            {
                area = new AreaUnitModel();
                area.area_code = item.CodeItemID;
                area.area_name = item.CodeItemName;

                int count = 0;
                if (item.CodeItemID.Length == 2)
                {
                    count = unitList.Where(o => !string.IsNullOrEmpty(o.LSJG)).Where(o => o.LSJG.Substring(0, 2) == item.CodeItemID).Count();
                }
                if (item.CodeItemID.Length == 4)
                {
                    count = unitList.Where(o => !string.IsNullOrEmpty(o.LSJG)).Where(o => o.LSJG.Length >= 4).Where(o => o.LSJG.Substring(0, 4) == item.CodeItemID).Count();
                }
                if (item.CodeItemID.Length == 6)
                {
                    count = unitList.Where(o => !string.IsNullOrEmpty(o.LSJG)).Where(o => o.LSJG.Length == 6).Where(o => o.LSJG.Substring(0, 6) == item.CodeItemID).Count();
                }
                if (count > 0)
                    area.area_name = item.CodeItemName + "(" + count + ")";

                area.text = item.CodeItemName;
                if (count > 0)
                    area.text = item.CodeItemName + "(" + count + ")";
                area.unit_pid = item.Parent;
                area.type = "1";
                rList.Add(area);
            }

            return rList;
        }

        #endregion

        //***************************分割线*******************************
        /// <summary>
        ///  获取权限下的单位信息
        ///  创建人：Joychen
        ///  创建时间：2016-12-15
        /// </summary>
        /// <returns></returns>
        public List<B01TreeModel> GetB01Data(int user_id)
        {
            List<B01TreeModel> listModel = new List<B01TreeModel>();
            //1：获取当前用户对应的所有单位数据
            List<B01> list = DBSession.IB01DAL.GetB01Info(user_id);
            if (list.Count <= 0)
                return null;
            return GetListData(list);
        }
        public List<B01TreeModel> GetB01InfoByQXTJ(int user_id)
        {
            List<B01TreeModel> listModel = new List<B01TreeModel>();
            //1：获取当前用户对应的所有单位数据
            List<B01> list = DBSession.IB01DAL.GetB01Info(user_id);
            if (list.Count <= 0)
                return null;
            //2：获取View_QXTJ所有单位信息
            List<string> unitList =
                DBSession.IView_QXTJDAL.Select(s => !string.IsNullOrEmpty(s.B0001Name))
                    .ConvertAll(s => s.UnitID)
                    .ToList();
            //3：筛选出在View_QXTJ表存在的记录
            list = list.Where(s => unitList.Contains(s.UnitID)).ToList();
            return GetListData(list);
        }
        private List<B01TreeModel> GetListData(List<B01> list)
        {
            List<B01TreeModel> listModel = new List<B01TreeModel>();
            //查找一级目录
            List<B01> first = list.FindAll(s => s.KeyParent == ".");
            if (first.Count > 0)
            {
                for (int i = 0; i < first.Count; i++)
                {
                    listModel.Add(new B01TreeModel()
                    {
                        text = first[i].UnitName,
                        unitID = first[i].UnitID,
                        keyChild = first[i].KeyChild,
                        nodes = GetModelById(list, first[i].UnitID)
                    });
                }
            }
            return listModel;
        }

        public List<B01> GetUnitDataByPermiss(int user_id)
        {
            if (user_id <= 0)
                return null;
            return DBSession.IB01DAL.GetB01Info(user_id);
        }
        /// <summary>
        ///  递归查询单位信息
        ///  创建人：Joychen
        ///  创建时间：2016-12-15
        /// </summary>
        /// <param name="list"></param>
        /// <param name="unitID"></param>
        /// <returns></returns>
        private List<B01TreeModel> GetModelById(List<B01> list, string unitID)
        {
            List<B01TreeModel> listModel = null;
            List<B01> listKey = list.FindAll(s => s.KeyParent == unitID);
            if (listKey.Count > 0)
            {
                listModel = new List<B01TreeModel>();
                B01TreeModel temp = null;
                for (int i = 0; i < listKey.Count; i++)
                {
                    temp = new B01TreeModel();
                    temp.text = listKey[i].UnitName;
                    temp.unitID = listKey[i].UnitID;
                    temp.keyChild = listKey[i].KeyChild;
                    if (temp.keyChild > 0)
                        temp.nodes = GetModelById(list, listKey[i].UnitID);
                    listModel.Add(temp);
                }
            }
            return listModel;
        }

        public List<B01PerTreeModel> GetB01PerData(int user_id)
        {
            List<B01PerTreeModel> listModel = new List<B01PerTreeModel>();
            List<B01> list = DBSession.IB01DAL.GetB01Info(user_id);
            if (list.Count <= 0)
                return null;
            //查找一级目录
            List<B01> first = list.FindAll(s => s.KeyParent == ".");
            string nodeIcon = "";
            if (first.Count > 0)
            {
                foreach (B01 item in first)
                {
                    switch (item.project_status)
                    {
                        case "已完工":
                            nodeIcon = "<i class='glyphicon glyphicon-ok'></i>";
                            break;
                        case "已开工，未安装设备工地":
                            nodeIcon = "<i class='glyphicon glyphicon-remove'></i>";
                            break;
                        case "已安装设备，设备在线":
                            nodeIcon = "<i class='glyphicon glyphicon-home'></i>";
                            break;
                        case "已安装设备，设备离线":
                            nodeIcon = "<i class='glyphicon glyphicon-home' style='color:red;'></i>";
                            break;
                        default:
                            break;
                    }
                    listModel.Add(new B01PerTreeModel()
                    {
                        UnitID = item.UnitID,
                        KeyParent = item.KeyParent,
                        UnitName = item.UnitName,
                        text = nodeIcon + " " + item.UnitName,
                        UnitType = item.UnitType,
                        B0107 = item.B0107,
                        B0108 = item.B0108,
                        B0120 = item.B0120,
                        D010H = item.D010H,
                        B0175 = item.B0175,
                        UnitStartDate = item.UnitStartDate.ToString(),
                        UnitEndDate = item.UnitEndDate.ToString(),
                        B0111 = item.B0111,
                        B0112 = item.B0112,
                        B0130 = item.B0113,
                        B0113 = item.B0113,
                        B0114 = item.B0114,
                        B0115 = item.B0115,
                        B0116 = item.B0116,
                        B0118 = item.B0118,
                        project_status = item.project_status,
                        nodes = GetPerModelById(list, item.UnitID)
                    });
                }
            }
            return listModel;
        }
        private List<B01PerTreeModel> GetPerModelById(List<B01> list, string unitID)
        {
            List<B01PerTreeModel> listModel = new List<B01PerTreeModel>();
            List<B01> listKey = list.FindAll(s => s.KeyParent == unitID);
            if (listKey.Count > 0)
            {
                B01PerTreeModel temp = null;
                foreach (B01 item in listKey)
                {
                    temp = new B01PerTreeModel();
                    temp.UnitID = item.UnitID;
                    temp.KeyParent = item.KeyParent;
                    temp.UnitName = item.UnitName;
                    temp.text = item.UnitName;
                    temp.UnitType = item.UnitType;
                    temp.B0107 = item.B0107;
                    temp.B0108 = item.B0108;
                    temp.B0120 = item.B0120;
                    temp.D010H = item.D010H;
                    temp.B0175 = item.B0175;
                    temp.UnitStartDate = item.UnitStartDate.ToString();
                    temp.UnitEndDate = item.UnitEndDate.ToString();
                    temp.B0111 = item.B0111;
                    temp.B0112 = item.B0112;
                    temp.B0130 = item.B0113;
                    temp.B0113 = item.B0113;
                    temp.B0114 = item.B0114;
                    temp.B0115 = item.B0115;
                    temp.B0116 = item.B0116;
                    temp.B0118 = item.B0118;
                    if (item.KeyChild > 0)
                        temp.nodes = GetPerModelById(list, item.UnitID);
                    listModel.Add(temp);
                }
            }
            return listModel;
        }
        public List<OrgModel> GetOrgDataById(string userGuid)
        {
            T_User user = HCQ2UI_Helper.OperateContext.Current.bllSession.T_User.Select(s => s.user_guid == userGuid).FirstOrDefault();
            if (null == user)
                return null;
            List<B01> list = DBSession.IB01DAL.GetB01Info(user.user_id);
            if (null == list)
                return null;
            List<OrgModel> listModel = new List<OrgModel>();
            //查找一级目录
            List<B01> first = list.FindAll(s => s.KeyParent == ".");
            if (first.Count > 0)
            {
                foreach (B01 item in first)
                {
                    listModel.Add(new OrgModel()
                    {
                        UnitID = item.UnitID,
                        UnitName = item.UnitName,
                        UnitParentID = item.KeyParent,
                        UnitType = item.UnitType,
                        Nodes = GetOrgModelByParentId(list, item.UnitID)
                    });
                }
            }
            return listModel;
        }

        private List<OrgModel> GetOrgModelByParentId(List<B01> list, string unitID)
        {
            List<OrgModel> listModel = null;
            List<B01> listKey = list.FindAll(s => s.KeyParent == unitID);
            if (listKey.Count > 0)
            {
                listModel = new List<OrgModel>();
                OrgModel temp = null;
                foreach (B01 item in listKey)
                {
                    temp = new OrgModel();
                    temp.UnitID = item.UnitID;
                    temp.UnitName = item.UnitName;
                    temp.UnitParentID = item.KeyParent;
                    temp.UnitType = item.UnitType;
                    if (item.KeyChild > 0)
                        temp.Nodes = GetOrgModelByParentId(list, item.UnitID);
                    listModel.Add(temp);
                }
            }
            return listModel;
        }
        /// <summary>
        ///  获取项目月增长
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public List<HCQ2_Model.APPModel.ResultApiModel.ChartProject> GetProjectMonthGrow(HCQ2_Model.APPModel.ParamModel.DebtAllGrantModel model)
        {
            if (model == null)
                return null;
            return DBSession.IB01DAL.GetProjectMonthGrow(model);
        }
        /// <summary>
        ///  获取项目总增长
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public List<HCQ2_Model.APPModel.ResultApiModel.ChartProject> GetProjectAllGrow(HCQ2_Model.APPModel.ParamModel.DebtAllGrantModel model)
        {
            if (model == null)
                return null;
            return DBSession.IB01DAL.GetProjectAllGrow(model);
        }
    }
}
