using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HCQ2_Model;
using HCQ2_Model.ViewModel;
using System.Web.Mvc;

namespace HCQ2_BLL
{
    public partial class BB_UpDataLogBLL
    {
        /// <summary>
        /// 获取所有的上记录日志
        /// </summary>
        /// <returns></returns>
        public List<BB_UpDataLog> GetLogInfo()
        {
            return Select(o => o.up_id > 0);
        }

        /// <summary>
        /// 根据用户ID获取上报记录
        /// </summary>
        /// <param name="user_id"></param>
        /// <returns></returns>
        public List<BB_UpDataLog> GetByUserID(int user_id)
        {
            return Select(o => o.up_user_id == user_id);
        }

        /// <summary>
        /// 写入上报信息
        /// </summary>
        /// <param name="log_type"></param>
        /// <param name="log_content"></param>
        /// <returns></returns>
        public bool InsertDataLog(string log_type, string log_content,int result,string unit_id)
        {
            BB_UpDataLog log = new BB_UpDataLog();
            log.up_name = GetLogType(log_type);
            log.up_context = log_content;
            log.up_unit_id = unit_id;
            log.up_date = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss"));
            log.up_user_id = HCQ2UI_Helper.OperateContext.Current.Usr.user_id;
            log.up_user_name = HCQ2UI_Helper.OperateContext.Current.Usr.login_name;
            log.up_result = result;
            return AddLog(log) > 0;
        }

        /// <summary>
        /// 根据上报类别获取title
        /// </summary>
        /// <param name="log_type"></param>
        /// <returns></returns>
        private string GetLogType(string log_type)
        {
            string value = "";
            switch (log_type)
            {
                case "01":
                    value = "项目企业信息上报";
                    break;
                case "02":
                    value = "人员信息上报";
                    break;
                case "03":
                    value = "人员照片上报";
                    break;
                case "04":
                    value = "考勤信息上报";
                    break;
                case "05":
                    value = "工资发放信息上报";
                    break;
                case "06":
                    value = "欠薪信息上报";
                    break;
                case "07":
                    value = "上报欠薪个人明细";
                    break;
                case "08":
                    value = "人员附件上报";
                    break;
                case "09":
                    value = "工资专户信息上报";
                    break;
                default:
                    break;
            }
            return value;
        }

        /// <summary>
        /// 获取页面显示所需要的数据源
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public TableModel GetPageModel(object obj)
        {
            TableModel model = new TableModel();
            FormCollection param = (FormCollection)obj;
            int rows = int.Parse(param["rows"]);
            int page = int.Parse(param["page"]);

            string UnitID = param["UnitID"];
            if(string.IsNullOrEmpty(UnitID))
                UnitID = HCQ2UI_Helper.OperateContext.Current.bllSession.B01.
                    GetB01PerData(HCQ2UI_Helper.OperateContext.Current.Usr.user_id)[0].UnitID;

            List<BB_UpDataLog> upList = Select(o => o.up_unit_id == UnitID);

            if (!string.IsNullOrEmpty(param["txtSearchName"])) {
                string searchName = param["txtSearchName"];
                upList = upList.Where(o => o.up_name.Contains(searchName) || o.up_context.Contains(searchName)).ToList();
            }
            upList = upList.OrderByDescending(o => o.up_date).ToList();
            model.total = upList.Count();
            model.rows = upList.Skip((rows * page) - rows).Take(rows);

            return model;
        }

        /// <summary>
        /// 新增上报日志
        /// </summary>
        /// <param name="log"></param>
        /// <returns></returns>
        public int AddLog(BB_UpDataLog log)
        {
            return Add(log);
        }

        /// <summary>
        /// 删除上报日志
        /// </summary>
        /// <param name="up_id"></param>
        /// <returns></returns>
        public int Delete(int up_id)
        {
            return Delete(o => o.up_id == up_id);
        }
    }
}
