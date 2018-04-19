using HCQ2_Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace HCQ2_BLL
{
    public partial class A03BLL
    {
        /// <summary>
        /// 获取所有的工资发放登记
        /// </summary>
        /// <returns></returns>
        public List<A03> GetA03Info()
        {
            return base.Select(o => o.PersonID != "").OrderBy(k => k.DispOrder).ToList();
        }

        /// <summary>
        /// 根据PersonID获取员工工资发放登记
        /// </summary>
        /// <param name="PersonID"></param>
        /// <returns></returns>
        public List<A03> GetByPersonID(string PersonID)
        {
            return base.Select(o => o.PersonID == PersonID).OrderBy(k => k.DispOrder).ToList();
        }

        /// <summary>
        /// 添加、编辑员工工资发放登记
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public bool OperWage(object obj)
        {
            FormCollection param = (FormCollection)obj;
            A01BLL aBll = new A01BLL();

            A03 a = new A03();
            a.A0301 = Convert.ToDateTime(param["A0301"]);
            a.A0302 = param["A0302"];

            bool returnBool = false;
            if (!string.IsNullOrEmpty(param["WageIsEdit"]))
            {
                string RowID = param["WageIsEdit"];
                returnBool = base.Modify(a, o => o.RowID == RowID, "A0301", "A0302") > 0;
            }
            else
            {
                a.RowID = HCQ2_Common.RowIDHelp.GetNewRowID();
                a.IsLastRow = 0;
                string RowID = param["WageRowID"];
                a.PersonID = aBll.GetByRowID(RowID).PersonID;
                var data = GetA03Info();
                if (data.Count() > 0)
                    a.DispOrder = data.Count() + 1;
                else
                    a.DispOrder = 1;
                returnBool = base.Add(a) > 0;
            }
            return returnBool;
        }
    }
}
