using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HCQ2_Model.ViewModel;
using HCQ2_Model;
using System.Data;
using HCQ2_Common;
using HCQ2_Model.JsonData;
using HCQ2_Model.WeiXinApiModel.ParamModel;
using HCQ2_Model.WeiXinApiModel.ResultApiModel;
using HCQ2_Model.APPModel.ParamModel;
using HCQ2_Model.APPModel.ResultApiModel;

namespace HCQ2_BLL
{
    public partial class View_QXTJBLL : HCQ2_IBLL.IView_QXTJBLL
    {
        /// <summary>
        ///  获取欠薪ViewModel数据
        /// </summary>
        /// <returns></returns>
        public EchartsVo GetDebtData()
        {
            //根据权限获取分配的单位信息
            List<View_QXTJ> list = GetDebtUnitDataByPermissTopSeven();
            if (list.Count <= 0)
                return null;
            return GetEchartsData(list);
        }
        /// <summary>
        ///  根据选中单位统计欠薪金额
        /// </summary>
        /// <param name="unit"></param>
        /// <returns></returns>
        public EchartsVo GetDebtMoneyData(string unit)
        {
            if (string.IsNullOrEmpty(unit))
                return null;
            List<HCQ2_Model.JsonData.UnitJsonModel> json = new List<UnitJsonModel>();
            json = JsonHelper.JsonStrToList(unit, json);
            List<string> jsonList = json.ConvertAll(s => s.UnitID);
            List<View_QXTJ> list = Select(s => jsonList.Contains(s.UnitID));
            return GetEchartsData(list);
        }

        private EchartsVo GetEchartsData(List<View_QXTJ> list)
        {
            EchartsVo dMoney = new EchartsVo();
            dMoney.legend =
                new List<string>("保障金额,欠薪金额".Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries));
            //X轴
            List<string> xAxis = new List<string>();
            List<Series> seriesList = new List<Series>();
            List<decimal?> detMoney = new List<decimal?>();//欠薪金额
            List<decimal?> bzMoney = new List<decimal?>();//保证金额
            foreach (View_QXTJ vq in list)
            {
                xAxis.Add(vq.B0001Name);
                detMoney.Add(vq.QXTJ01);
                bzMoney.Add(vq.B0116);
            }
            seriesList.Add(
                new Series()
                {
                    name = "保证金额",
                    type = "bar",
                    data = bzMoney
                });
            seriesList.Add(
                new Series()
                {
                    name = "欠薪金额",
                    type = "bar",
                    data = detMoney
                });
            dMoney.xAxis = xAxis;
            dMoney.seriesList = seriesList;
            return dMoney;
        }

        /// <summary>
        ///  获取欠薪时间数据
        /// </summary>
        /// <returns></returns>
        public EchartsVo GetDebtTimeData(string unitCode, int keyChild)
        {
            List<P_QianXin_ShiJian_Result> list = base.DBSession.IView_QXTJDAL.GetViewTimeData(unitCode, keyChild);
            if (list.Count <= 0)
                return null;
            EchartsVo dTime = new EchartsVo();
            List<Series> seriesList = new List<Series>();
            List<decimal?> detTime = new List<decimal?>();//欠薪人数
            foreach (P_QianXin_ShiJian_Result vq in list)
            {
                detTime.Add(vq.renshu);
            }
            seriesList.Add(
                new Series()
                {
                    name = "欠薪人数",
                    type = "bar",
                    data = detTime
                });
            dTime.seriesList = seriesList;
            return dTime;
        }
        /// <summary>
        ///  获取欠薪人数
        /// </summary>
        /// <returns></returns>
        public EchartsVo GetDebtPerson()
        {
            List<View_QXTJ> list = GetDebtPersonByPermissTopSeren();
            if (list.Count <= 0)
                return null;
            EchartsVo dPerson = new EchartsVo();
            dPerson.legend =
                new List<string>("总人数,欠薪人数".Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries));
            //X轴
            List<string> xAxis = new List<string>();
            List<Series> seriesList = new List<Series>();
            List<decimal?> detAllCount = new List<decimal?>();//总人数
            List<decimal?> detPerson = new List<decimal?>();//欠薪人数
            foreach (View_QXTJ vq in list)
            {
                xAxis.Add(vq.B0001Name);
                detAllCount.Add(vq.People2);
                detPerson.Add(vq.People);
            }
            seriesList.Add(
                new Series()
                {
                    name = "总人数",
                    type = "bar",
                    data = detAllCount
                });
            seriesList.Add(
                new Series()
                {
                    name = "欠薪人数",
                    type = "bar",
                    data = detPerson
                });
            dPerson.xAxis = xAxis;
            dPerson.seriesList = seriesList;
            return dPerson;
        }
        /// <summary>
        ///  获取单位代码
        /// </summary>
        /// <param name="unitName">代码名称</param>
        /// <returns></returns>
        public string GetUnitCodeByUnitName(string unitName)
        {
            if (string.IsNullOrEmpty(unitName))
                return string.Empty;
            return DBSession.IView_QXTJDAL.GetUnitCodeByName(unitName);
        }

        /// <summary>
        /// 获取欠薪金额、欠薪人数
        /// </summary>
        /// <returns></returns>
        public DataTable GetStaticWagePerson(int user_id)
        {
            List<B01> unitList = HCQ2UI_Helper.OperateContext.Current.bllSession.B01.GetUnitDataByPermiss(user_id);
            string strUnitID = "'" + string.Join("','", unitList.Select(o => o.UnitID)) + "'";
            StringBuilder sbSql = new StringBuilder();
            sbSql.AppendFormat("select SUM(QXTJ01) as wage,SUM(People) as [count] from View_QXTJ where UnitID in ({0})", strUnitID);
            return HCQ2_Common.SQL.SqlHelper.ExecuteDataTable(sbSql.ToString());
        }
        /// <summary>
        /// 获取详细的欠薪金额和欠薪人数
        /// </summary>
        /// <returns></returns>
        public List<View_QXTJ> GetMainWagePerson(int user_id)
        {
            List<B01> unitList = HCQ2UI_Helper.OperateContext.Current.bllSession.B01.GetUnitDataByPermiss(user_id);
            string strUnitID = "'" + string.Join("','", unitList.Select(o => o.UnitID)) + "'";
            StringBuilder sbSql = new StringBuilder();
            sbSql.Append("select * from View_QXTJ where QXTJ01>0");
            sbSql.AppendFormat(" and UnitID in ({0}) ", strUnitID);
            return HCQ2_Common.Data.DataTableHelper.DataTableToIList<View_QXTJ>
                (HCQ2_Common.SQL.SqlHelper.ExecuteDataTable(sbSql.ToString()));
        }
        //***************************************************************
        /// <summary>
        ///  根据权限获取前7条欠薪金额数据
        /// </summary>
        /// <param name="task">获取前几条数据 默认top 7</param>
        /// <returns></returns>
        public List<View_QXTJ> GetDebtUnitDataByPermissTopSeven(int task = 7)
        {
            List<View_QXTJ> list = null;
            List<B01> unitList = HCQ2UI_Helper.Session.SysPermissSession.PerminssUnitData;
            if (unitList == null || unitList.Count <= 0)
                return null;
            List<string> strList = unitList.ConvertAll(s => s.UnitID).ToList();
            if (strList.Count > task)
                list = Select<decimal?>(s => strList.Contains(s.UnitID), s => s.QXTJ01, 1, task, false);
            else
                list = Select(s => strList.Contains(s.UnitID));
            return list;
        }
        /// <summary>
        ///  根据权限获取前7条欠薪人数数据
        /// </summary>
        /// <param name="task">获取前几条数据 默认top 7</param>
        /// <returns></returns>
        public List<View_QXTJ> GetDebtPersonByPermissTopSeren(int task = 7)
        {
            List<View_QXTJ> list = null;
            List<B01> unitList = HCQ2UI_Helper.Session.SysPermissSession.PerminssUnitData;
            if (unitList == null || unitList.Count <= 0)
                return null;
            List<string> strList = unitList.ConvertAll(s => s.UnitID).ToList();
            if (strList.Count > task)
                list = DBSession.IView_QXTJDAL.Select<int?>(s => strList.Contains(s.UnitID), s => s.People, 1, task, false);
            else
                list = DBSession.IView_QXTJDAL.Select(s => strList.Contains(s.UnitID));
            return list;
        }

        //*********************************WebChat Service*************************************
        public List<DebtQXTJResultModel> GetViewDataByName(DebtQXTJModel model)
        {
            List<View_QXTJ> list = new List<View_QXTJ>();
            if (string.IsNullOrEmpty(model.project_name))
                list = Select<int>(o => (!string.IsNullOrEmpty(o.UnitID)), s => s.DispOrder, model.page, model.size);
            else
                list = Select<int>(o => o.B0001Name.Contains(model.project_name), s => s.DispOrder, model.page, model.size);
            if (null == list)
                return null;
            List<DebtQXTJResultModel> listModel = new List<DebtQXTJResultModel>();
            foreach (View_QXTJ item in list)
            {
                listModel.Add(new DebtQXTJResultModel()
                {
                    B0001Name = item.B0001Name,
                    B0116 = item.B0116,
                    DispOrder = item.DispOrder,
                    People = item.People,
                    People2 = item.People2,
                    QXTJ01 = item.QXTJ01,
                    UnitID = item.UnitID
                });
            }
            return listModel;
        }

        public List<DebtMoneyResultModel> GetDebtMoneyDetail(DebtMoneyPeopleModel model)
        {
            if (null == model)
                return null;
            return DBSession.IView_QXTJDAL.GetDebtMoneyDetail(model);
        }

        public List<DebtPeopleResultModel> GetDebtPeopleDetail(DebtMoneyPeopleModel model)
        {
            if (null == model)
                return null;
            return DBSession.IView_QXTJDAL.GetDebtPeopleDetail(model);
        }

        /// <summary>
        ///  获取欠薪时间
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public List<DebtSelResultModel> GetDebtTime(DebtSelModel model)
        {
            T_User user = DBSession.IT_UserDAL.Select(s => s.user_guid.Equals(model.userid)).FirstOrDefault();
            if (null == user)
                return null;
            List<B01> list = DBSession.IB01DAL.GetB01Info(user.user_id);
            return DBSession.IView_QXTJDAL.GetDebtTime(model,user.user_id,list?.Select(s=>s.UnitID).ToList());
        }
        /// <summary>
        ///  APP根据单位，时间条件查询欠薪数据汇总
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public List<DebtDataModel> GetDebtCountDataByOrg(DebtSelGrantModel model)
        {
            return DBSession.IView_QXTJDAL.GetDebtCountDataByOrg(model);
        }
        /// <summary>
        ///  APP根据单位，查询时间获取欠薪图表月数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public List<DebtMoneyModel> GetDebtChartMonthDataByOrg(DebtSelGrantModel model)
        {
            return DBSession.IView_QXTJDAL.GetDebtChartMonthDataByOrg(model);
        }
        /// <summary>
        ///  APP根据单位，查询时间获取欠薪图表截止月数据汇总
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public List<DebtMoneyModel> GetDebtChartEndMonthDataByOrg(DebtSelGrantModel model)
        {
            return DBSession.IView_QXTJDAL.GetDebtChartEndMonthDataByOrg(model);
        }
    }
}
