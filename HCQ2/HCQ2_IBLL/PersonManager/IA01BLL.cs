using HCQ2_Model;
using System.Collections.Generic;
using System.Data;
using HCQ2_Model.ViewModel;
using NPOI.HSSF.UserModel;

namespace HCQ2_IBLL
{
    public partial interface IA01BLL
    {
        #region 获取数据

        /// <summary>
        /// 获取所有的人员数据
        /// </summary>
        /// <returns></returns>
        List<A01> GetA01Info();

        /// <summary>
        /// 获取一个包含字典表的人员信息集合根据RowID
        /// </summary>
        /// <returns></returns>
        DataTable GetA01ItemByRowID(string RowID);

        /// <summary>
        /// 获取所有人员数据的JSON字符串
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        string GetA01Json(List<A01> list);

        /// <summary>
        /// 根据PersonID获取一个人员信息的实体类
        /// </summary>
        /// <param name="PersonID"></param>
        /// <returns></returns>
        A01 GetByPersonID(string PersonID);

        /// <summary>
        /// 获取一个经过字典表处理过的A01实体类
        /// </summary>
        /// <param name="A01"></param>
        /// <returns></returns>
        A01 GetBySmCodeItem(A01 A01);

        /// <summary>
        /// 根据UnitID获取人员信息
        /// </summary>
        /// <param name="unitID"></param>
        /// <returns></returns>
        List<A01> GetByUnitID(string unitID);

        /// <summary>
        /// 根据RowID获取人员信息
        /// </summary>
        /// <param name="RowID"></param>
        /// <returns></returns>
        A01 GetByRowID(string RowID);

        /// <summary>
        /// 获取所有人当前年月的考勤记录
        /// </summary>
        /// <param name="attYear"></param>
        /// <param name="attMonth"></param>
        /// <returns></returns>
        DataTable GetAttendance(string attYear, string attMonth);

        /// <summary>
        /// 获取当前单位当前年月的考勤记录
        /// </summary>
        /// <param name="unitID"></param>
        /// <param name="attYear"></param>
        /// <param name="attMonth"></param>
        /// <returns></returns>
        DataTable GetAttendanceByUnitID(string unitID, string attYear, string attMonth);

        /// <summary>
        /// 获取重复数据
        /// </summary>
        /// <returns></returns>
        DataTable GetReaptPerson();

        /// <summary>
        /// 获取API需要的重复数据
        /// </summary>
        /// <returns></returns>
        DataTable GetApiRepeatPerson(string guid);

        /// <summary>
        /// 获取总人数
        /// </summary>
        /// <returns></returns>
        int GetPeopleSum();

        /// <summary>
        /// 获取总人数，根据用户ID
        /// </summary>
        /// <param name="user_id"></param>
        /// <returns></returns>
        int GetPeopleSum(int user_id);

        /// <summary>
        /// 工种和人数统计
        /// </summary>
        /// <param name="user_id"></param>
        void StaticJobsCoumt(int user_id, ref List<string> listJobs, ref List<int> listCount);

        /// <summary>
        /// 新增人员信息
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        string AddPerson(object obj);

        /// <summary>
        /// 获取一个新的编号
        /// </summary>
        /// <returns></returns>
        string GetNewRowID();

        /// <summary>
        /// 获取页面需要显示的数据源
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        DataTable GetPageTableModle(object obj);

        /// <summary>
        /// 获取首页出工详情
        /// </summary>
        /// <returns></returns>
        List<HCQ2_Model.ViewModel.MainCheckUnit> GetMainCheckUnit(string check_date);

        /// <summary>
        /// 获取首页出工详细人员
        /// </summary>
        /// <param name="unitid"></param>
        /// <returns></returns>
        List<View_A02> GetMainCheckPerson(string unitid, string check_date);

        /// <summary>
        /// 创建一个hssfworkbook
        /// </summary>
        /// <param name="userList"></param>
        /// <returns></returns>
        System.IO.MemoryStream GetWorkBook(string UnitID);

        /// <summary>
        /// 获取人员信息表所用到的全部工种
        /// </summary>
        /// <returns></returns>
        List<Dictionary<string, object>> GetWorkerType();

        #endregion

        #region 人员数据操作

        /// <summary>
        /// 判断项目里面是否存在某个身份证的人
        /// </summary>
        /// <param name="identifyCode"></param>
        /// <param name="unit_id"></param>
        /// <returns></returns>
        bool ValidatePerson(string identifyCode, string unit_id);

        /// <summary>
        /// 人员移动
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        bool MovePerson(object obj, ref string strMsg);

        /// <summary>
        /// 人员复制
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="strMsg"></param>
        /// <returns></returns>
        bool CpoyPerson(object obj, ref string strMsg);

        /// <summary>
        /// 办离职
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="strMsg"></param>
        /// <returns></returns>
        bool HandleRetire(object obj, ref string strMsg);

        /// <summary>
        /// API接口新增用户
        /// </summary>
        /// <param name="person"></param>
        /// <param name="RowID"></param>
        /// <returns></returns>
        bool ApiAddPerson(HCQ2_Model.WebApiModel.ParamModel.PersonModel person, ref string PersonID);

        /// <summary>
        /// API编辑工人信息获取数据
        /// </summary>
        /// <param name="person"></param>
        /// <returns></returns>
        Dictionary<string, object> GetEditPersonDetail(HCQ2_Model.AppModel.EditPerson person);

        /// <summary>
        /// 删除人员信息
        /// </summary>
        /// <param name="person"></param>
        /// <returns></returns>
        bool DeletePerson(HCQ2_Model.AppModel.EditPerson person);

        /// <summary>
        /// 编辑人员信息
        /// </summary>
        /// <param name="person"></param>
        /// <returns></returns>
        bool ApiEditPerson(HCQ2_Model.AppModel.EditPersonToSave person);

        #endregion

        #region 数据上报 基于企业

        /// <summary>
        /// 数据上报组装上报字符串
        /// </summary>
        /// <param name="obj">FormCollection 类型参数</param>
        /// <returns></returns>
        List<string> UpLoadData(object obj,ref List<string> comList,ref List<string> projectList,string type);

        /// <summary>
        /// 人员基本信息、照片、合同上报
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="comList"></param>
        /// <param name="projectList"></param>
        /// <param name="type"></param>
        /// <param name="userList"></param>
        /// <returns></returns>
        List<string> UpLoadDataFormPerson(object obj, ref List<string> comList, ref List<string> projectList, string type, ref List<A01> userList,string unit_id);

        /// <summary>
        /// 获取单人上报字符串
        /// </summary>
        /// <param name="userList"></param>
        /// <param name="workerList"></param>
        /// <param name="menuList"></param>
        /// <param name="realUnitID"></param>
        /// <returns></returns>
        string GetStrtoUpLoad(List<A01> userList, List<SM_CodeItems> workerList, List<T_ItemCodeMenum> menuList, string realUnitID,string upType);

        /// <summary>
        /// 改写人员相关上报状态
        /// </summary>
        /// <param name="userList"></param>
        /// <param name="upType"></param>
        void ChangePersonUpLoad(List<A01> userList, string upType);

        /// <summary>
        /// 人员上报处理
        /// </summary>
        /// <param name="UnitID"></param>
        /// <param name="IdentifyCode"></param>
        void UpLoadPerson(string UnitID, string IdentifyCode);

        #endregion

        #region APP接口业务 人员信息

        /// <summary>
        /// 根据姓名或身份证号码获取人员列表
        /// </summary>
        /// <param name="person"></param>
        /// <returns></returns>
        List<HCQ2_Model.AppModel.ReturePerson> GetPersonQueryList(HCQ2_Model.AppModel.Person person);

        /// <summary>
        /// 根据姓名和项目名称获取人员基本信息
        /// </summary>
        /// <param name="person"></param>
        /// <returns></returns>
        HCQ2_Model.AppModel.PersonDetailReturn GetPersonDetail(HCQ2_Model.AppModel.PersonDetail person);

        /// <summary>
        /// 根据姓名和项目名称获取人员当前所在项目
        /// </summary>
        /// <param name="person"></param>
        /// <returns></returns>
        HCQ2_Model.AppModel.PersonUnit GetPersonUnitDetail(HCQ2_Model.AppModel.PersonDetail person);

        /// <summary>
        /// 根据姓名和项目名称获取人员出工记录
        /// </summary>
        /// <param name="person"></param>
        /// <returns></returns>
        List<HCQ2_Model.AppModel.WorkDays> GetCheckDaysRecord(HCQ2_Model.AppModel.PersonDetailCkeck person);

        /// <summary>
        /// 务工人员接口-----------------维权凭证
        /// </summary>
        /// <param name="person"></param>
        /// <returns></returns>
        HCQ2_Model.AppModel.PersonDetailReturn GetWorkPersonDetail(HCQ2_Model.AppModel.WorkPersonDetail person);

        /// <summary>
        /// 务工人员接口-----------------所在项目
        /// </summary>
        /// <param name="person"></param>
        /// <returns></returns>
        List<HCQ2_Model.AppModel.UnitReturn> GetWorkPersonUnit(HCQ2_Model.AppModel.WorkPerson person);

        /// <summary>
        /// 人员同步
        /// </summary>
        /// <param name="match_timestamp"></param>
        /// <param name="unit_id"></param>
        /// <param name="userid"></param>
        /// <returns></returns>
        List<A01> PersonsSynchronous(string match_timestamp, string unit_id, string userid,string deviceid);

        #endregion

        #region  APP接口业务 出工情况

        /// <summary>
        /// 获取所有出工情况列表
        /// </summary>
        /// <param name="checkWork"></param>
        /// <returns></returns>
        List<HCQ2_Model.AppModel.CheckWorkReturn> GetCheckWorkList(HCQ2_Model.AppModel.CheckWork checkWork);

        /// <summary>
        /// 分页获取出工情况列表
        /// </summary>
        /// <param name="checkWork"></param>
        /// <returns></returns>
        List<HCQ2_Model.AppModel.CheckWorkReturn> GetRowPageList(HCQ2_Model.AppModel.CheckWorkPageRow checkWork);

        /// <summary>
        /// 获取具体项目出工情况列表
        /// </summary>
        /// <param name="checkWork"></param>
        /// <returns></returns>
        List<HCQ2_Model.AppModel.CheckUnitWorkDetail> GetPersonList(HCQ2_Model.AppModel.CheckWork checkWork);

        /// <summary>
        /// 项目人员出工统计
        /// </summary>
        /// <param name="checkStatis"></param>
        /// <returns></returns>
        List<HCQ2_Model.AppModel.CheckWorkStaticReturn> GetPersonStatis(HCQ2_Model.AppModel.CheckWorkStatic checkStatis);

        /// <summary>
        /// 获取所有项目的平均出工率
        /// </summary>
        /// <param name="checkWork"></param>
        /// <returns></returns>
        Dictionary<string, object> GetAllProjectAvg(HCQ2_Model.AppModel.CheckWork checkWork);

        /// <summary>
        /// 月出工率
        /// </summary>
        /// <param name="checkWork"></param>
        /// <returns></returns>
        List<HCQ2_Model.AppModel.CheckWorkMonth> GetDayWorkByMonth(HCQ2_Model.AppModel.CheckWork checkWork);

        #endregion

        #region 滚屏显示内容

        /// <summary>
        /// 获取滚屏显示工种工区统计
        /// </summary>
        /// <param name="roll"></param>
        /// <returns></returns>
        List<object> GetWorkerJobsRollSrcen(HCQ2_Model.RollScreenModel.Roll roll);

        #endregion
    }
}
