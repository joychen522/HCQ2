using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HCQ2_Model;
using HCQ2_Model.ViewModel;
using System.Web.Mvc;
using System.Data;
using HCQ2_Model.ExtendsionModel;

namespace HCQ2_BLL
{
    public partial class T_CompProInfoBLL : HCQ2_IBLL.IT_CompProInfoBLL
    {
        /// <summary>
        /// 获取所有的企业信息
        /// </summary>
        /// <returns></returns>
        public List<T_CompProInfo> GetComPro()
        {
            return Select(o => o.com_id > 0);
        }

        /// <summary>
        /// 根据企业ID获取企业信息
        /// </summary>
        /// <param name="com_id"></param>
        /// <returns></returns>
        public T_CompProInfo GetByComID(int com_id)
        {
            return Select(o => o.com_id == com_id).FirstOrDefault();
        }

        /// <summary>
        /// 根据UnitID获取所属队伍
        /// </summary>
        /// <param name="RowID"></param>
        /// <returns></returns>
        public List<T_CompProInfo> GetInTeamByUnitID(string UnitID)
        {
            List<T_CompProInfo> comList = new List<T_CompProInfo>();
            StringBuilder sbSql = new StringBuilder();
            //sbSql.AppendFormat(" select * from T_CompProInfo where QXLB='02' and compath like ( ");
            //sbSql.AppendFormat(" select dwmc from T_CompProInfo where com_id = ( ");
            //sbSql.AppendFormat(" select in_compay from B01 where UnitID='{0}')) + '%' ", UnitID);
            sbSql.AppendFormat("select FBDW from B01 where UnitID='{0}'", UnitID);
            string fbdw = HCQ2_Common.SQL.SqlHelper.ExecuteScalar(sbSql.ToString()).ToString();
            if (string.IsNullOrEmpty(fbdw))
                return comList;

            string[] strFB = fbdw.Split(';');
            string dwmc = string.Empty;
            for (int i = 0; i < strFB.Length; i++)
            {
                if (string.IsNullOrEmpty(dwmc))
                    dwmc = "'" + strFB[i] + "'";
                else
                    dwmc += ",'" + strFB[i] + "'";
            }
            sbSql = new StringBuilder();
            sbSql.AppendFormat("select * from T_CompProInfo where dwmc in ({0})", dwmc);
            comList = HCQ2_Common.Data.DataTableHelper.DataTableToIList<T_CompProInfo>(
                HCQ2_Common.SQL.SqlHelper.ExecuteDataTable(sbSql.ToString()));
            return comList;
        }

        /// <summary>
        /// 新增或者编辑企业信息
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public bool OperionCom(object obj)
        {
            FormCollection param = (FormCollection)obj;
            T_CompProInfo com = new T_CompProInfo();

            com.QXLB = param["QXLB"];
            com.dwmc = param["dwmc"];
            com.tyshxydm = param["tyshxydm"];
            com.zzjgdm = param["zzjgdm"];
            com.gsdjzzhm = param["gsdjzzhm"];
            com.xxly = param["xxly"];
            com.gsdjzzzl = param["gsdjzzzl"];

            com.gsdjyxqxqs = param["gsdjyxqxqs"];
            com.qsdjyxqxzz = param["qsdjyxqxzz"];

            com.Shbxdjzbm = param["Shbxdjzbm"];
            com.Fddbrxm = param["Fddbrxm"];
            com.Fddbrsfzhm = param["Fddbrsfzhm"];
            com.Fddbrdh = param["Fddbrdh"];
            com.Dwlx = param["Dwlx"];
            com.Jjlx = param["Jjlx"];
            com.Lsgx = param["Lsgx"];
            com.Jyfs = param["Jyfs"];
            com.Zczb = param["Zczb"];
            com.ZYFW = param["ZYFW"];
            com.JYFW = param["JYFW"];
            com.XZQHDM = param["XZQHDM"];
            com.DJZCLX = param["DJZCLX"];
            com.FDDBRZW = param["FDDBRZW"];
            com.DWFZRXM = param["DWFZRXM"];
            com.DWFZRZW = param["DWFZRZW"];
            com.DWFZRDH = param["DWFZRDH"];
            com.ZCDZ = param["ZCDZ"];
            com.LZFZR = param["LZFZR"];
            com.LZFZRSFZHM = param["LZFZRSFZHM"];
            com.LZFZRZW = param["LZFZRZW"];
            com.LZFZRDH = param["LZFZRDH"];
            com.SSHY = param["SSHY"];
            com.DWQTLXFS = param["DWQTLXFS"];
            com.LXR = param["LXR"];
            com.LXDH = param["LXDH"];
            com.BGDZ = param["BGDZ"];
            com.YZBM = param["YZBM"];
            com.DWJBZHKHYH = param["DWJBZHKHYH"];
            com.DWJBZHKHMC = param["DWJBZHKHMC"];
            com.DWJBZHZH = param["DWJBZHZH"];
            com.CZHM = param["CZHM"];
            com.DZYX = param["DZYX"];
            com.WZ = param["WZ"];
            com.JGZSBH = param["JGZSBH"];
            com.LYYJY = param["LYYJY"];
            com.JGLB = param["JGLB"];
            com.SSWG = param["SSWG1"];

            //单位首字母拼音
            com.DWMCPY = param["DWMCPY"];

            com.FDDBRZJHM = param["FDDBRZJHM"];
            com.ZGBM = param["ZGBM"];
            com.tiISYLWPQJYXMtle = param["tiISYLWPQJYXMtle"];
            com.BZ = param["BZ"];
            com.SSKS = param["SSKS"];
            com.CZRXM = param["CZRXM"];
            com.CZRDZ = param["CZRDZ"];
            com.CZRLXDH = param["CZRLXDH"];
            com.ZLQX = param["ZLQX"];
            com.CZRFBDR = param["CZRFBDR"];
            com.ISYYZX = param["ISYYZX"];

            if (!string.IsNullOrEmpty(param["YRDWWHSJ"]))
                com.YRDWWHSJ = Convert.ToDateTime(param["YRDWWHSJ"]);

            com.LZJBRXM = param["LZJBRXM"];
            com.LZJBRDH = param["LZJBRDH"];
            com.LDJCBH = param["LDJCBH"];
            com.STDJZH = param["STDJZH"];

            string ckNodeStr = param["JianDieUnitID"];
            string edNodeStr = param["EditComID"];
            if (string.IsNullOrEmpty(edNodeStr))
            {
                //添加
                if (!string.IsNullOrEmpty(ckNodeStr))
                {
                    //子节点
                    int com_id = Convert.ToInt32(ckNodeStr);
                    var data = GetComPro().Where(o => o.com_id == com_id).FirstOrDefault();
                    com.SJDW = data.com_id.ToString();
                    com.Sjdwmc = data.dwmc;
                }
                else
                {
                    //第一层节点
                    com.SJDW = "0";
                    com.Sjdwmc = "";
                }
                return Add(com) > 0;
            }
            else
            {
                string[] par = { "QXLB","dwmc","tyshxydm","zzjgdm","gsdjzzhm","gsdjzzzl","gsdjyxqxqs","qsdjyxqxzz",
                "Shbxdjzbm","Fddbrxm","Fddbrsfzhm","Fddbrdh","Dwlx","Jjlx","Lsgx",
                "Jyfs","Zczb","ZYFW","JYFW","XZQHDM","DJZCLX","FDDBRZW",
                "DWFZRXM","DWFZRZW","DWFZRDH","ZCDZ","LZFZR","LZFZRSFZHM","LZFZRZW",
                "LZFZRDH","SSHY","DWQTLXFS","LXR","LXDH","BGDZ","YZBM",
                "DWJBZHKHYH","DWJBZHKHMC","DWJBZHZH","CZHM","DZYX","WZ","JGZSBH",
                "LYYJY","JGLB","SSWG","DWMCPY","FDDBRZJHM","ZGBM","tiISYLWPQJYXMtle",
                "BZ","SSKS","CZRXM","CZRDZ","CZRLXDH","ZLQX","CZRFBDR",
                "ISYYZX","YRDWWHSJ","LZJBRXM","LZJBRDH","LDJCBH","STDJZH"};
                int com_id = Convert.ToInt32(edNodeStr);
                return base.Modify(com, o => o.com_id == com_id, par) > 0;
            }
        }

        /// <summary>
        /// 删除企业信息
        /// </summary>
        /// <param name="com_id"></param>
        /// <returns></returns>
        public bool DeleteCom(int com_id)
        {
            if (com_id > 0)
                return Delete(o => o.com_id == com_id) > 0;
            else
                return false;
        }

        /// <summary>
        /// 获取一个可以直接显示的企业目录实体集合
        /// </summary>
        /// <param name="comList"></param>
        /// <returns></returns>
        public List<Dictionary<string, object>> GetComTreeModle(List<T_CompProInfo> comList)
        {
            List<Dictionary<string, object>> dicList = new List<Dictionary<string, object>>();
            Dictionary<string, object> dic = new Dictionary<string, object>();
            if (comList == null)
                return dicList;

            var firstNode = comList.Where(o => o.SJDW == "0");
            if (firstNode == null)
                return dicList;

            foreach (var item in firstNode)
            {
                dic = new Dictionary<string, object>();
                dic.Add("text", item.dwmc);
                dic.Add("com_id", item.com_id);
                dic.Add("com_pid", item.SJDW);
                var data = comList.Where(o => o.SJDW == item.com_id.ToString());
                if (data.Count() > 0)
                    dic.Add("nodes", GetComNode(data.ToList(), comList));
                dicList.Add(dic);
            }

            return dicList;
        }

        /// <summary>
        /// 子节点以及其他节点信息
        /// </summary>
        /// <param name="nodeList"></param>
        /// <param name="comList"></param>
        /// <returns></returns>
        public List<Dictionary<string, object>> GetComNode(List<T_CompProInfo> nodeList, List<T_CompProInfo> comList)
        {
            List<Dictionary<string, object>> dicList = new List<Dictionary<string, object>>();
            Dictionary<string, object> dic = new Dictionary<string, object>();
            foreach (var item in nodeList)
            {
                dic = new Dictionary<string, object>();
                dic.Add("text", item.dwmc);
                dic.Add("com_id", item.com_id);
                dic.Add("com_pid", item.SJDW);
                var data = comList.Where(o => o.SJDW == item.com_id.ToString());
                if (data.Count() > 0)
                    dic.Add("nodes", GetComNode(data.ToList(), comList));
                dicList.Add(dic);
            }
            return dicList;
        }

        /// <summary>
        /// 获取页面显示数据源
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public TableModel GetPageModle(object obj)
        {
            FormCollection param = (FormCollection)obj;
            TableModel model = new TableModel();
            var comList = GetComPro();
            int page = int.Parse(param["page"]);
            int rows = int.Parse(param["rows"]);
            if (!string.IsNullOrEmpty(param["comType"]))
            {
                if (param["comType"] == "1")
                    comList = comList.Where(o => o.QXLB == "01" || o.QXLB == "02").ToList();
                else
                    comList = comList.Where(o => o.QXLB != "01" && o.QXLB != "02").ToList();
            }
            if (!string.IsNullOrEmpty(param["txtSearchName"]))
            {
                page = 1;
                string txtName = param["txtSearchName"];
                comList = comList.Where(o => o.dwmc.Contains(txtName)).ToList();
            }

            if (!string.IsNullOrEmpty(param["JianDieUnitID"]))
            {
                string JianDieUnitID = param["JianDieUnitID"];
                comList = comList.Where(o => o.com_id == Convert.ToInt32(JianDieUnitID)).ToList();
            }

            model.total = comList.Count;
            model.rows = comList.Skip((rows * page) - rows).Take(rows).OrderBy(o => o.SJDW);

            return model;
        }
        /// <summary>
        /// 获取已经被绑定的数据源
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public TableModel GetBindPageModel(object obj)
        {
            FormCollection param = (FormCollection)obj;
            TableModel model = new TableModel();
            var comList = DBSession.IT_CompProInfoDAL.GetBindProjectCom();
            int page = int.Parse(param["page"]);
            int rows = int.Parse(param["rows"]);
            if (!string.IsNullOrEmpty(param["txtSearchName"]))
            {
                page = 1;
                string txtName = param["txtSearchName"];
                comList = comList.Where(o => o.dwmc.Contains(txtName)).ToList();
            }

            if (!string.IsNullOrEmpty(param["JianDieUnitID"]))
            {
                string JianDieUnitID = param["JianDieUnitID"];
                comList = comList.Where(o => o.com_id == Convert.ToInt32(JianDieUnitID)).ToList();
            }

            model.total = comList.Count;
            model.rows = comList.Skip((rows * page) - rows).Take(rows).OrderBy(o => o.SJDW);

            return model;
        }

        /// <summary>
        /// 获取页面显示数据源
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public List<ComProInfoDalModel> GetPageComInfoModle(object obj)
        {
            FormCollection param = (FormCollection)obj;
            int page = int.Parse(param["page"]);
            int rows = int.Parse(param["rows"]);
            string txtSearchName = param["txtSearchName"],
                JianDieUnitID = param["JianDieUnitID"];
            return DBSession.IT_CompProInfoDAL.GetPageComInfoModle(new HCQ2_Model.ExtendsionModel.ComProInfoModel { page = page, rows = rows, txtSearchName = txtSearchName, JianDieUnitID = JianDieUnitID });
        }
        public int GetPageComInfoCount(object obj)
        {
            FormCollection param = (FormCollection)obj;
            string txtSearchName = param["txtSearchName"],
                JianDieUnitID = param["JianDieUnitID"];
            if (!string.IsNullOrEmpty(txtSearchName) && !string.IsNullOrEmpty(JianDieUnitID))
                return Select(s => s.dwmc.Contains(txtSearchName) && s.SJDW == JianDieUnitID).ToList().Count;
            if (!string.IsNullOrEmpty(txtSearchName) && string.IsNullOrEmpty(JianDieUnitID))
                return Select(s => s.dwmc.Contains(txtSearchName)).ToList().Count;
            if (string.IsNullOrEmpty(txtSearchName) && !string.IsNullOrEmpty(JianDieUnitID))
                return Select(s => s.SJDW == JianDieUnitID).ToList().Count;
            return Select(s => !string.IsNullOrEmpty(s.dwmc)).ToList().Count;
        }
        /// <summary>
        /// 获取企业项目显示数据源
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public TableModel GetComProjectSoure(object obj)
        {
            FormCollection param = (FormCollection)obj;
            B01BLL unit = new B01BLL();
            TableModel model = new TableModel();
            int rows = int.Parse(param["rows"]);
            int page = int.Parse(param["page"]);
            string com_id = param["com_id"];
            if (string.IsNullOrEmpty(com_id))
            {
                int user_id = HCQ2UI_Helper.OperateContext.Current.Usr.user_id;
                List<B01> unitList = new B01BLL().GetPerUnitByUserID(user_id);
                com_id = unitList[0].in_compay;
            }
            if (string.IsNullOrEmpty(com_id))
                return model;

            var data = unit.GetB01Info().Where(o => o.in_compay == com_id);

            if (!string.IsNullOrEmpty(param["txtSearchName"]))
            {
                string txtSearchName = param["txtSearchName"];
                data = data.Where(o => o.UnitName.Contains(txtSearchName));
            }

            model.total = data.Count();
            model.rows = data.Skip((rows * page) - rows).Take(rows);

            return model;
        }

        /// <summary>
        /// 获取完善企业信息显示数据源
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public TableModel GetComPerfectSoure(object obj)
        {
            FormCollection param = (FormCollection)obj;
            B01BLL unit = new B01BLL();
            TableModel model = new TableModel();
            int rows = int.Parse(param["rows"]);
            int page = int.Parse(param["page"]);
            string com_id = param["com_id"];
            if (string.IsNullOrEmpty(com_id))
            {
                int user_id = HCQ2UI_Helper.OperateContext.Current.Usr.user_id;
                List<B01> unitList = new B01BLL().GetPerUnitByUserID(user_id);
                com_id = unitList[0].in_compay;
            }
            if (string.IsNullOrEmpty(com_id))
                return model;

            var data = GetComPro().Where(o => o.com_id == Convert.ToInt32(com_id));

            if (!string.IsNullOrEmpty(param["txtSearchName"]))
            {
                string txtSearchName = param["txtSearchName"];
                data = data.Where(o => o.dwmc.Contains(txtSearchName));
            }

            model.total = data.Count();
            model.rows = data.Skip((rows * page) - rows).Take(rows);

            return model;
        }

        /// <summary>
        /// 根据用户ID获取该用户权限下的项目信息以及企业信息
        /// </summary>
        /// <param name="user_id"></param>
        /// <returns></returns>
        public List<T_CompProInfo> GetPerCompanyByUserID(int user_id)
        {
            List<T_CompProInfo> list = new List<T_CompProInfo>();
            List<T_CompProInfo> comList = new List<T_CompProInfo>();
            B01BLL unit = new B01BLL();
            List<B01> unitList = unit.GetPerUnitByUserID(user_id);
            string strPerUnitjoin = "'" + string.Join("','", unitList.Select(o => o.UnitID)) + "'";
            StringBuilder sbSql = new StringBuilder();
            sbSql.AppendFormat("select * from B01 where UnitID in ({0})", strPerUnitjoin);
            DataTable unitDt = HCQ2_Common.SQL.SqlHelper.ExecuteDataTable(sbSql.ToString());
            if (unitDt == null)
                return comList;

            for (int i = 0; i < unitDt.Rows.Count; i++)
            {
                string in_compay = unitDt.Rows[i]["in_compay"].ToString();
                if (!string.IsNullOrEmpty(in_compay))
                {
                    list = new List<T_CompProInfo>();
                    sbSql = new StringBuilder();
                    sbSql.AppendFormat(" select * from T_CompProInfo where compath like ( ");
                    sbSql.AppendFormat(" select dwmc from T_CompProInfo where com_id ='{0}' ) + '%' order by com_id ", in_compay);
                    list = HCQ2_Common.Data.DataTableHelper.DataTableToIList<T_CompProInfo>(
                        HCQ2_Common.SQL.SqlHelper.ExecuteDataTable(sbSql.ToString()));
                    if (comList != null)
                    {
                        if (list == null)
                            continue;
                        foreach (var item in list)
                        {
                            if (comList.Where(o => o.com_id == item.com_id).Count() > 0)
                                continue;
                            comList.Add(item);
                        }
                    }
                    else
                    {
                        comList = list;
                    }
                }
            }
            return comList;
        }

        #region api数据

        /// <summary>
        /// 根据用户GUID获取所属项目下的劳务公司
        /// </summary>
        /// <param name="person"></param>
        /// <returns></returns>
        public List<Dictionary<string, object>> GetComByGuID(HCQ2_Model.AppModel.EditPerson person)
        {
            List<Dictionary<string, object>> rList = new List<Dictionary<string, object>>();
            Dictionary<string, object> rDic = new Dictionary<string, object>();
            StringBuilder sbSql = new StringBuilder();
            sbSql.AppendFormat("select * from T_CompProInfo where COMPATH like (");
            sbSql.AppendFormat(" select dwmc from T_CompProInfo where com_id=( ");
            sbSql.AppendFormat(" select in_compay from B01 where UnitID='{0}')) + '%' ", person.unit_code);
            sbSql.AppendFormat(" and SJDW<>0 ");
            DataTable dt = HCQ2_Common.SQL.SqlHelper.ExecuteDataTable(sbSql.ToString());

            if (dt == null)
                return rList;

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                rDic = new Dictionary<string, object>();
                rDic.Add("com_name", dt.Rows[i]["dwmc"]);
                rDic.Add("com_id", dt.Rows[i]["com_id"]);
                rList.Add(rDic);
            }

            return rList;
        }

        /// <summary>
        /// 根据企业类别统计人数
        /// </summary>
        /// <returns></returns>
        public List<Dictionary<string, object>> GetCompayQXLB()
        {
            List<Dictionary<string, object>> rList = new List<Dictionary<string, object>>();
            Dictionary<string, object> rDic = new Dictionary<string, object>();

            StringBuilder sbSql = new StringBuilder();
            sbSql.AppendFormat("select a.QXLB,PersonCount=(select COUNT(*) from A01 where UnitID=b.UnitID) from B01 b");
            sbSql.AppendFormat(" inner join T_CompProInfo a on b.in_compay=a.com_id");
            sbSql.AppendFormat(" where in_compay>0 order by in_compay");
            DataTable dt = HCQ2_Common.SQL.SqlHelper.ExecuteDataTable(sbSql.ToString());

            double totlePerson = Convert.ToDouble(dt.Compute("sum(PersonCount)", "true"));
            T_ItemCode itemCode = new T_ItemCodeBLL().GetByItemCode("QYLSZBFB");
            List<T_ItemCodeMenum> menuList = new T_ItemCodeMenumBLL().GetByItemId(itemCode.item_id);

            double percent01 = 0;
            double percent02 = 0;
            foreach (var item in menuList)
            {
                rDic = new Dictionary<string, object>();

                rDic.Add("name", item.code_name);
                var data = dt.Select("QXLB='" + item.code_value + "'");
                if (data.Count() > 0)
                {
                    double count = Convert.ToDouble(data.CopyToDataTable().Compute("sum(PersonCount)", "true"));
                    rDic.Add("value", count / totlePerson);

                    if (item.code_value == "01")
                        percent01 = count / totlePerson;
                    if (item.code_value == "02")
                        percent02 = count / totlePerson;
                }
                else
                {
                    rDic.Add("value", 0);

                    if (item.code_value == "01")
                        percent01 = 0;
                    if (item.code_value == "02")
                        percent02 = 0;
                }

                if (item.code_value != "01" && item.code_value != "02")
                    rList.Add(rDic);
            }

            //合并工程类总包和工程类分包
            rDic = new Dictionary<string, object>();
            rDic.Add("name", "建筑");
            rDic.Add("value", (percent01 + percent02));
            rList.Add(rDic);

            return rList;
        }

        #endregion
    }
}
