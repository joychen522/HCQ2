using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HCQ2_Model;
using HCQ2_Model.SelectModel;
using HCQ2_Model.ViewModel;
using HCQ2_Model.WebApiModel.ResultApiModel;
using HCQ2_Model.APPModel.ResultApiModel;
using HCQ2_Model.APPModel.ParamModel;

namespace HCQ2_BLL
{
    public partial class WGJG02BLL:HCQ2_IBLL.IWGJG02BLL
    {
        public List<WGJG02Model> GetWageDetailByRowId(HCQ2_Model.SelectModel.WGJG01ChartModel model)
        {
            return DBSession.IWGJG02DAL.GetWageDetailByRowId(model);
        }

        public List<WGJG02Model> GetWageDetailByUnitID(WGJG02ByUnitID model)
        {
            if (model==null)
                return null;
            return DBSession.IWGJG02DAL.GetWageDetailByUnitID(model);
        }

        public int CountPersonsByModel(WGJG02ByUnitID model)
        {
            if (model == null)
                return 0;
            return DBSession.IWGJG02DAL.CountPersonsByModel(model);
        }

        public void ExportToExcel(WGJG02ByUnitID model)
        {
            //1.0获取待导出数据
            System.Data.DataTable dt = DBSession.IWGJG02DAL.GetExportData(model);
            Dictionary<string, string> dict = new Dictionary<string, string>();
            dict.Add("A0101", "姓名");
            dict.Add("B0002", "用工单位");
            dict.Add("UnitID", "用工单位");
            dict.Add("E0386", "工种");
            dict.Add("WGJG0203", "发放方式");
            dict.Add("WGJG0202", "约定发放时间");
            dict.Add("WGJG0201", "确定时间");
            dict.Add("WGJG0207", "应发金额");
            dict.Add("WGJG0208", "实发金额");
            if (dt != null)
            {
                DataRow row = dt.NewRow();
                row["A0101"] = "合计";
                row["WGJG0207"] =
                    dt.Select(" WGJG0207 IS NOT NULL").AsEnumerable().Select(d => d.Field<decimal>("WGJG0207")).Sum();
                row["WGJG0208"] = dt.Select(" WGJG0208 IS NOT NULL").AsEnumerable().Select(d => d.Field<decimal>("WGJG0208")).Sum();
                dt.Rows.Add(row);
            }
            HCQ2_Common.NpoiHelper.DataTableToExeclForNpoi(dt, dict,"发放汇总", "发放汇总", "A0177",true, ",WGJG0207,WGJG0208,");
        }

        public int CountGrantPersons(WGJG01ChartModel model)
        {
            return DBSession.IWGJG02DAL.CountGrantPersons(model);
        }

        public string EditAffirmWageByPerson(HCQ2_Model.WebApiModel.ParamModel.WageRegisterModel model)
        {
            if (null==model)
                return null;
            //1：更新是否发放，签到时间
            bool mark = DBSession.IWGJG02DAL.EditAffirmWageByPerson(model);
            if (!mark)
                return null;
            //2：更新成功 获取修改记录的主键RowID
            WGJG02 uWage =
                Select(s => s.PersonID == model.personid && s.PersonSalaryID == model.personsalaryid).FirstOrDefault();
            string salarysignid = uWage?.RowID;
            //3：更新成功 判断是否确认完毕
            int markCount = DBSession.IWGJG02DAL.GetWagePersonCount(model);
            if (markCount > 0)
                return salarysignid;//还有未确认的
            //4：没有未确认的更新 WGJG01，更新之前获取第一个农民工发放时间，作为整个发放时间
            WGJG02 firstModel = DBSession.IWGJG02DAL.GetFirstCheckInUser(model);
            DBSession.IWGJG01DAL.Modify(new WGJG01() { WGJG0101 = "01", WGJG0102 = DateTime.Now }, s => s.RowID == firstModel.WGJG01RowID, "WGJG0101", "WGJG0102");
            return salarysignid;
        }

        public List<WageSentDownModel> GetWageSentDownByOrgId(string orgid)
        {
            List<WageSentDownModel> list= DBSession.IWGJG02DAL.GetWageSentDownByOrgId(orgid);
            if (null == list)
                return new List<WageSentDownModel>();
            return list;
        }
        /// <summary>
        ///  工资下发
        /// </summary>
        /// <param name="person"></param>
        /// <returns></returns>
        public List<WageDetialResult> GetWageDetialByPerson(WageGrantParamModel person)
        {
            if (null == person)
                return null;
            return DBSession.IWGJG02DAL.GetWageDetialByPerson(person);
        }
        /// <summary>
        ///  根据年份获取指定人员 一年的薪资发放情况
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public List<WorkMoneyResult> GetWageByYear(WorkAllList model)
        {
            if (null == model)
                return null;
            return DBSession.IWGJG02DAL.GetWageByYear(model);
        }
        /// <summary>
        ///  获取个人拖欠薪资
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
       public List<WorkMoneyResult> GetTradyWageByYear(WorkAllList model)
        {
            if (null == model)
                return null;
            return DBSession.IWGJG02DAL.GetTradyWageByYear(model);
        }
        /// <summary>
        ///  获取总的发放金额
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public decimal GetAllGrantMoney(BaseAPI model)
        {
            if (null == model)
                return 0;
            return DBSession.IWGJG02DAL.GetAllGrantMoney(model);
        }
        /// <summary>
        ///  获取总的欠薪金额
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public decimal GetAllPayMoney(BaseAPI model)
        {
            if (null == model)
                return 0;
            return DBSession.IWGJG02DAL.GetAllPayMoney(model);
        }
        /// <summary>
        ///  获取欠薪金额趋势数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public List<DebtMoneyModel> GetPayMoneyByDate(DebtChartByYearModel model)
        {
            if (null == model)
                return null;
            return DBSession.IWGJG02DAL.GetPayMoneyByDate(model);
        }
        /// <summary>
        ///  获取欠薪人数趋势
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public List<DebtPersonsModel> GetPayCountPerson(DebtChartByYearModel model)
        {
            if (null == model)
                return null;
            return DBSession.IWGJG02DAL.GetPayCountPerson(model);
        }
    }
}
