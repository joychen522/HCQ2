using HCQ2_Model.ExtendsionModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HCQ2_BLL
{
    public partial class T_CompProInfoBLL:HCQ2_IBLL.IT_CompProInfoBLL
    {
        public List<ComProModel> GetComProData(string unitID)
        {
            if (string.IsNullOrEmpty(unitID))
                return null;
            return DBSession.IT_CompProInfoDAL.GetComProData(unitID);
        }
        /// <summary>
        ///  获取企业单位信息
        /// </summary>
        /// <returns></returns>
        public List<HCQ2_Model.TreeModel.ProInfoTreeModel> GetUnitData(int use_status)
        {
            List<HCQ2_Model.T_AreaInfo> areaInfo = DBSession.IT_AreaInfoDAL.Select(s => !string.IsNullOrEmpty(s.area_name)).ToList();
            List<HCQ2_Model.T_CompProInfo> proInfo = DBSession.IT_CompProInfoDAL.Select(s => !string.IsNullOrEmpty(s.dwmc)).ToList();
            List<HCQ2_Model.TreeModel.ProInfoTreeModel> list = new List<HCQ2_Model.TreeModel.ProInfoTreeModel>();
            List<HCQ2_Model.T_AreaInfo> tempInfo = areaInfo.Where(s => s.area_pid == 0).ToList();
            //全部招聘信息
            List<HCQ2_Model.T_UseWorker> works = null;
            if (use_status == 0)
                works = DBSession.IT_UseWorkerDAL.Select(s => s.use_status > 1).ToList();
            else
                works = DBSession.IT_UseWorkerDAL.Select(s => s.use_status == 1).ToList();
            if (null != tempInfo && tempInfo.Count > 0)
            {
                #region 区域
                foreach (var item in tempInfo)
                {
                    //1：区域节点
                    list.Add(new HCQ2_Model.TreeModel.ProInfoTreeModel
                    {
                        com_id = 0,
                        text = item.area_name,
                        nodes = GetDataByID(item.area_id, areaInfo, proInfo, works)
                    });
                }
                #endregion
            }
            else
            {
                #region 没有区域 单位
                List<HCQ2_Model.T_CompProInfo> strTemp = proInfo.Where(s => s.SJDW == "0").ToList();
               foreach (var item in strTemp)
               {
                    int tempLen = works.Where(s => s.com_id == item.com_id).Count();
                    list.Add(new HCQ2_Model.TreeModel.ProInfoTreeModel
                    {
                        com_id = item.com_id,
                        text = item.dwmc + (tempLen > 0 ? "(" + tempLen + ")" : ""),
                        nodes = GetUnitDataByID(item.com_id, areaInfo, proInfo, works)
                    });
                }
                #endregion
            }
            return list;
        }
        /// <summary>
        ///  区域递归
        /// </summary>
        /// <returns></returns>
        private List<HCQ2_Model.TreeModel.ProInfoTreeModel> GetDataByID(int pid, List<HCQ2_Model.T_AreaInfo> areaInfo, List<HCQ2_Model.T_CompProInfo> proInfo, List<HCQ2_Model.T_UseWorker> works)
        {

            #region 1.0 区域节点
            List<HCQ2_Model.TreeModel.ProInfoTreeModel> list = null;
            var temp = areaInfo.Where(s => s.area_pid == pid).ToList();
            if (temp.Count > 0)
            {
                #region 区域
                if (list == null)
                    list = new List<HCQ2_Model.TreeModel.ProInfoTreeModel>();
                foreach (var item in temp)
                {
                    //1：区域节点
                    list.Add(new HCQ2_Model.TreeModel.ProInfoTreeModel
                    {
                        com_id = 0,
                        text = item.area_name,
                        nodes = GetDataByID(item.area_id, areaInfo, proInfo,works)
                    });
                    //2：单位节点
                    var tempStr = proInfo.Where(s => s.area_id == pid).ToList();
                    if (null != tempStr && tempStr.Count > 0)
                    {
                        foreach (var str in tempStr)
                        {
                            int tempLen = works.Where(s => s.com_id == str.com_id).Count();
                            list.Add(new HCQ2_Model.TreeModel.ProInfoTreeModel
                            {
                                com_id = str.com_id,
                                text = str.dwmc + (tempLen > 0 ? "(" + tempLen + ")" : ""),
                                nodes = GetUnitDataByID(str.com_id, areaInfo, proInfo, works)
                            });
                        }
                    }
                }
                return list;
                #endregion 
            }
            #endregion

            #region 2.0 最后一层区域 单位
            List<HCQ2_Model.T_CompProInfo> temp2 = null;
            if (null == temp || temp.Count <= 0)
                temp2 = proInfo.Where(s => s.area_id == pid).ToList();
            if (temp2.Count > 0)
            {
                #region 单位
                if (list == null)
                    list = new List<HCQ2_Model.TreeModel.ProInfoTreeModel>();
                foreach (var item in temp2)
                {
                    int tempLen = works.Where(s => s.com_id == item.com_id).Count();
                    list.Add(new HCQ2_Model.TreeModel.ProInfoTreeModel
                    {
                        com_id = item.com_id,
                        text = item.dwmc + (tempLen > 0 ? "(" + tempLen + ")" : ""),
                        nodes = GetUnitDataByID(item.com_id, areaInfo, proInfo,works)
                    });
                }
                return list;
                #endregion
            } 
            #endregion
            return list;
        }
        /// <summary>
        ///  单位递归
        /// </summary>
        /// <param name="pid"></param>
        /// <param name="areaInfo"></param>
        /// <param name="proInfo"></param>
        /// <returns></returns>
        private List<HCQ2_Model.TreeModel.ProInfoTreeModel> GetUnitDataByID(int pid, List<HCQ2_Model.T_AreaInfo> areaInfo, List<HCQ2_Model.T_CompProInfo> proInfo, List<HCQ2_Model.T_UseWorker> works)
        {
            List<HCQ2_Model.TreeModel.ProInfoTreeModel> list = null;
            List<HCQ2_Model.T_CompProInfo> temp = proInfo.Where(s => s.SJDW == pid.ToString()).ToList();
            if (null != temp && temp.Count > 0)
            {
                #region 区域
                if(null==list)
                    list = new List<HCQ2_Model.TreeModel.ProInfoTreeModel>();
                foreach (var item in temp)
                {
                    int tempLen = works.Where(s => s.com_id == item.com_id).Count();
                    list.Add(new HCQ2_Model.TreeModel.ProInfoTreeModel
                    {
                        com_id = item.com_id,
                        text = item.dwmc + (tempLen > 0 ? "(" + tempLen + ")" : ""),
                        nodes = GetUnitDataByID(item.com_id, areaInfo, proInfo,works)
                    });
                }
                #endregion
            }
            return list;
        }
    }
}
