using HCQ2_Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HCQ2_Model.TreeModel;
using HCQ2_Model.WebApiModel.ResultApiModel;

namespace HCQ2_IBLL
{
    public partial interface IB01BLL
    {
        #region 基本获取数据操作

        /// <summary>
        /// 获取所有B01表数据
        /// </summary>
        /// <returns></returns>
        List<B01> GetB01Info();
        /// <summary>
        /// 根据list生成一个可供读取的js字符串
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        string GetTreeString(List<B01> obj);

        /// <summary>
        /// 根据UnitID查找数据
        /// </summary>
        /// <param name="unitID"></param>
        /// <returns></returns>
        B01 GetByUnitID(string unitID);

        /// <summary>
        /// 根据UnitName查找数据
        /// </summary>
        /// <param name="unitName"></param>
        /// <returns></returns>
        B01 GetByUnitName(string unitName); 

        /// <summary>
        /// 根据UnitID删除单位以及子单位
        /// </summary>
        /// <param name="unitID"></param>
        /// <returns></returns>
        bool DeleteByUnitIDInfo(string UnitID);

        /// <summary>
        /// 获取工地数量
        /// </summary>
        /// <returns></returns>
        int GetProjectCount();

        /// <summary>
        /// 获取工地数量根据用户ID
        /// </summary>
        /// <returns></returns>
        int GetProjectCount(string user_id);

        /// <summary>
        /// 根据用户ID获取该用户权限下的项目集合
        /// </summary>
        /// <param name="user_id"></param>
        /// <returns></returns>
        List<B01> GetPerUnitByUserID(int user_id);

        #endregion

        #region 企业项目增删操作

        /// <summary>
        /// 完善项目信息
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        bool EditPorject(object obj);
        /// <summary>
        /// 新增项目
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        bool AddUnit(object obj);
        /// <summary>
        /// 编辑项目
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        bool EditUnit(object obj);

        #endregion

        #region 项目上报

        void UpDataProject(string UnitID);

        void ChangeUnitUpLoad(string UnitName, string upType);

        #endregion

        #region APP接口 
        /// <summary>
        /// 获取企业项目
        /// </summary>
        /// <param name="compay"></param>
        /// <returns></returns>
        List<HCQ2_Model.AppModel.UnitReturn> GetEnterList(HCQ2_Model.AppModel.Compay compay);

        /// <summary>
        /// 分页获取企业项目
        /// </summary>
        /// <param name="compay"></param>
        /// <returns></returns>
        List<HCQ2_Model.AppModel.UnitReturn> GetEnterRowPageList(HCQ2_Model.AppModel.CompayList compay);

        /// <summary>
        /// 获取详细企业项目
        /// </summary>
        /// <param name="compay"></param>
        /// <returns></returns>
        List<object> GetEnterProjectDetail(HCQ2_Model.AppModel.Compay compay);

        /// <summary>
        /// 获取项目人员明细
        /// </summary>
        /// <param name="compay"></param>
        /// <returns></returns>
        List<HCQ2_Model.AppModel.UnitPerson> GetEnterPersonList(HCQ2_Model.AppModel.CompayPersonDetail compay);

        /// <summary>
        /// 首页统计
        /// </summary>
        /// <returns></returns>
        HCQ2_Model.AppModel.MainCount GetStatisNum(HCQ2_Model.AppModel.WorkPerson orgid);

        /// <summary>
        /// 大数据展示屏企业数量、务工人员、打卡人员统计
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        HCQ2_Model.RollScreenModel.MainData GetMainEnteriseStatis();

        /// <summary>
        /// 大数据展示项目详情统计
        /// </summary>
        /// <returns></returns>
        List<HCQ2_Model.RollScreenModel.Project> GetProjectDetailList();

        /// <summary>
        /// 大数据展示项目详情统计>具体打卡人员信息
        /// </summary>
        /// <param name="unit"></param>
        /// <returns></returns>
        List<Dictionary<string, object>> GetProjectCheckDetail(HCQ2_Model.RollScreenModel.ProjectCheckUnit unit);

        /// <summary>
        /// 大数据展示欠薪预警
        /// </summary>
        /// <returns></returns>
        List<HCQ2_Model.RollScreenModel.DeWage> GetDeWageList();

        /// <summary>
        /// 大数据展示欠薪预警>>>项目详细信息
        /// </summary>
        /// <param name="unit"></param>
        /// <returns></returns>
        HCQ2_Model.RollScreenModel.DeWageProjectDetail GetDeWageProjectDetail(HCQ2_Model.RollScreenModel.ProjectCheckUnit unit);

        /// <summary>
        /// 大数据展示务工人员统计>根据年龄
        /// </summary>
        /// <returns></returns>
        List<object> GetStatisAge();

        /// <summary>
        /// 大数据展示务工人员统计>根据工种
        /// </summary>
        /// <returns></returns>
        List<object> GetStatisJobs(HCQ2_Model.RollScreenModel.DataViewJosb job);

        /// <summary>
        /// 获取地图项目信息
        /// </summary>
        /// <returns></returns>
        List<HCQ2_Model.RollScreenModel.StatisMiddle> GetMiddleMapStatis();

        /// <summary>
        /// 采集趋势图
        /// </summary>
        /// <returns></returns>
        List<Dictionary<string,object>> GetCollectTrend();

        #endregion

        #region 区域项目树

        /// <summary>
        /// 根据用户ID获取区域项目树集合
        /// </summary>
        /// <param name="user_id"></param>
        /// <returns></returns>
        List<AreaUnitModel> GetPerUserAreaUnit(int user_id);

        /// <summary>
        /// 根据用户ID获取区域项目树集合
        /// </summary>
        /// <param name="user_id"></param>
        /// <returns></returns>
        List<AreaUnitModel> GetPerUserAreaUnitInfo(int user_id);

        #endregion

        //*******************************Joychen********************************
        List<B01PerTreeModel> GetB01PerData(int user_id);
        /// <summary>
        ///  查询所有单位信息，并封装至B01TreeModel，
        ///  如果为空或者. 则查询一级单位
        ///  创建人：Joychen
        ///  创建时间：2016-12-15
        /// </summary>
        /// <returns></returns>
        List<B01TreeModel> GetB01Data(int user_id);
        /// <summary>
        ///  获取权限下的单位 并排除QXTJ不存在的记录
        /// </summary>
        /// <returns></returns>
        List<B01TreeModel> GetB01InfoByQXTJ(int user_id);
        /// <summary>
        ///  根据用户ID获取配置代管单位
        /// </summary>
        /// <param name="user_id">用户id</param>
        /// <returns></returns>
        List<B01> GetUnitDataByPermiss(int user_id);
        //*******************************Joychen Service********************************
        /// <summary>
        ///  根据user_guid获取组织结构数据
        /// </summary>
        /// <param name="userGuid"></param>
        /// <returns></returns>
        List<OrgModel> GetOrgDataById(string userGuid);
        /// <summary>
        ///  获取项目月增长
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        List<HCQ2_Model.APPModel.ResultApiModel.ChartProject> GetProjectMonthGrow(HCQ2_Model.APPModel.ParamModel.DebtAllGrantModel model);
        /// <summary>
        ///  获取项目总增长
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        List<HCQ2_Model.APPModel.ResultApiModel.ChartProject> GetProjectAllGrow(HCQ2_Model.APPModel.ParamModel.DebtAllGrantModel model);
    }
}
