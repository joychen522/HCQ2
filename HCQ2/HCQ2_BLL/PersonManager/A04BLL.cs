using HCQ2_Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace HCQ2_BLL
{
    public partial class A04BLL : HCQ2_IBLL.IA04BLL
    {
        /// <summary>
        /// 获取所有人员学历信息
        /// </summary>
        /// <returns></returns>
        public List<A04> GetA04Info()
        {
            return base.Select(o => o.RowID != "").OrderBy(k => k.DispOrder).ToList();
        }

        /// <summary>
        /// 根据人员编号获取学历信息
        /// </summary>
        /// <param name="PersonID"></param>
        /// <returns></returns>
        public List<A04> GetByPersonID(string PersonID)
        {
            return base.Select(o => o.PersonID == PersonID).OrderBy(k => k.DispOrder).ToList();
        }

        /// <summary>
        /// 将一个学历集合里面的代码行字段全部替换
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public List<A04> GetCodeItemA04(List<A04> list)
        {
            BLLSession bll = new BLLSession();
            List<SM_CodeItems> CodeItemList = bll.SM_CodeItems.GetCodeItems();
            if (list.Count() > 0)
            {
                for (int i = 0; i < list.Count; i++)
                {
                    list[i].A0405 = GetEduName(CodeItemList, "JDXL", list[i].A0405);
                    list[i].C0401 = GetEduName(CodeItemList, "KF", list[i].C0401);
                }
            }
            return list;
        }

        /// <summary>
        /// 将一个学历实体类里面的代码行字段全部替换
        /// </summary>
        /// <param name="A04"></param>
        /// <returns></returns>
        public A04 GetCodeItemEntity(A04 A04)
        {
            BLLSession bll = new BLLSession();
            List<SM_CodeItems> CodeItemList = bll.SM_CodeItems.GetCodeItems();
            A04.A0405 = GetEduName(CodeItemList, "JDXL", A04.A0405);
            A04.C0401 = GetEduName(CodeItemList, "KF", A04.C0401);
            return A04;
        }

        /// <summary>
        /// 从CodeIem字段表筛选数据
        /// </summary>
        /// <param name="list"></param>
        /// <param name="codeID"></param>
        /// <param name="codeItemID"></param>
        /// <returns></returns>
        private string GetEduName(List<SM_CodeItems> list, string codeID, string codeItemID)
        {
            string value = "";
            if (!string.IsNullOrEmpty(codeItemID))
            {
                value = list.Where(o => o.CodeID == codeID && o.CodeItemID == codeItemID).FirstOrDefault().CodeItemName;
            }
            return value;
        }

        /// <summary>
        /// 根据RowID获取一条学历信息
        /// </summary>
        /// <param name="RowID"></param>
        /// <returns></returns>
        public A04 GetByRowID(string RowID)
        {
            return base.Select(o => o.RowID == RowID).FirstOrDefault();
        }

        /// <summary>
        /// 添加学历学位信息
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public bool AddEdu(object obj)
        {
            A01BLL _aBll = new A01BLL();
            SM_CodeItemsBLL item = new SM_CodeItemsBLL();
            FormCollection param = (FormCollection)obj;
            A04 a = new A04();
            a.PersonID = _aBll.GetByRowID(param["EduRowID"]).PersonID;
            a.RowID = HCQ2_Common.RowIDHelp.GetNewRowID();
            if (!string.IsNullOrEmpty(param["A0405"]))
                a.A0405 = item.GetCodeItemByCodeID("JDXL").Where(o => o.CodeItemName == param["A0405"]).FirstOrDefault().CodeItemID;
            if (!string.IsNullOrEmpty(param["C0401"]))
                a.C0401 = item.GetCodeItemByCodeID("KF").Where(o => o.CodeItemName == param["C0401"]).FirstOrDefault().CodeItemID;
            a.IsLastRow = 1;
            if (!string.IsNullOrEmpty(param["A0415"]) && param["A0415"] != "学历学位")
                a.A0415 = Convert.ToDateTime(param["A0415"]);
            if (!string.IsNullOrEmpty(param["A0430"]) && param["A0430"] != "A0430")
                a.A0430 = Convert.ToDateTime(param["A0430"]);
            a.A0435 = param["A0435"];
            a.A0410 = param["A0410"];

            bool isAccess = false;
            if (!string.IsNullOrEmpty(param["EduIsEdit"]))
            {
                //编辑
                string EduRowID = param["EduIsEdit"];
                isAccess = base.Modify(a, o => o.RowID == EduRowID, "A0405", "C0401", "A0415", "A0430", "A0435", "A0410") > 0;
            }
            else {
                var data = GetA04Info();
                if (data.Count() > 0)
                    a.DispOrder = data.Max(o => o.DispOrder) + 1;
                else
                    a.DispOrder = 1;

                //添加
                isAccess = base.Add(a) > 0;
            }

            return isAccess;
        }

        /// <summary>
        /// 修改学历学位信息
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public bool EditEdu(object obj)
        {
            A01BLL _aBll = new A01BLL();
            SM_CodeItemsBLL item = new SM_CodeItemsBLL();
            FormCollection param = (FormCollection)obj;
            A04 a = new A04();
            a.PersonID = _aBll.GetByRowID(param["EduRowID"]).PersonID;
            if (!string.IsNullOrEmpty(param["A0405"]))
                a.A0405 = item.GetCodeItemByCodeID("JDXL").Where(o => o.CodeItemName == param["A0405"]).FirstOrDefault().CodeItemID;
            if (!string.IsNullOrEmpty(param["C0401"]))
                a.C0401 = item.GetCodeItemByCodeID("KF").Where(o => o.CodeItemName == param["C0401"]).FirstOrDefault().CodeItemID;
            a.DispOrder = GetA04Info().Count() + 1;
            a.IsLastRow = 1;
            if (!string.IsNullOrEmpty(param["A0415"]))
                a.A0415 = Convert.ToDateTime(param["A0415"]);
            if (!string.IsNullOrEmpty(param["A0430"]))
                a.A0430 = Convert.ToDateTime(param["A0430"]);
            a.A0435 = param["A0435"];
            a.A0410 = param["A0410"];
            string RowID = param["EduRowID"];
            return base.Modify(a, o => o.RowID == RowID, "A0405", "C0401", "A0415", "A0430", "A0435", "A0410") > 0;
        }
    }
}
