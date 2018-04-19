using HCQ2_Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace HCQ2_BLL
{
    public partial class A19BLL : HCQ2_IBLL.IA19BLL
    {
        /// <summary>
        /// 获取所有工作经历信息
        /// </summary>
        /// <returns></returns>
        public List<A19> GetA19Info()
        {
            return base.Select(o => o.PersonID != "").OrderBy(k => k.DispOrder).ToList();
        }

        /// <summary>
        /// 根据PersonID获取工作经历信息
        /// </summary>
        /// <returns></returns>
        public List<A19> GetByPersonID(string PersonID)
        {
            return base.Select(o => o.PersonID == PersonID).OrderBy(k => k.DispOrder).ToList();
        }

        /// <summary>
        /// 保存或者编辑工作经历
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public bool OperWork(object obj)
        {
            FormCollection param = (FormCollection)obj;
            A19 a = new A19();
            a.IsLastRow = 1;

            if (!string.IsNullOrEmpty(param["A1905"]))
                a.A1905 = Convert.ToDateTime(param["A1905"]);
            if (!string.IsNullOrEmpty(param["A1910"]))
                a.A1910 = Convert.ToDateTime(param["A1910"]);
            a.A1915 = param["A1915"];
            a.A1920 = param["A1920"];
            a.A1925 = param["A1925"];
            a.A1926 = param["A1926"];
            a.A1927 = param["A1927"];
            a.A1928 = param["A1928"];
            a.A1929 = param["A1929"];
            a.A1930 = param["A1930"];

            bool returnBool = false;
            if (!string.IsNullOrEmpty(param["workIsEdit"]))
            {
                //编辑
                string workEditRowID = param["workIsEdit"];
                returnBool = base.Modify(a, o => o.RowID == workEditRowID, "A1905", "A1910", "A1915", "A1920", "A1925"
                    , "A1926", "A1927", "A1928", "A1929", "A1930") > 0;
            }
            else
            {
                A01BLL _aBll = new A01BLL();
                a.RowID = HCQ2_Common.RowIDHelp.GetNewRowID();
                a.PersonID = _aBll.GetByRowID(param["workRowID"]).PersonID;
                if (GetA19Info().Count() > 0)
                    a.DispOrder = GetA19Info().Max(o => o.DispOrder) + 1;
                else
                    a.DispOrder = 1;
                returnBool = base.Add(a) > 0;
            }

            return returnBool;
        }
    }
}
