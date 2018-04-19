using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HCQ2_Model.ExtendsionModel;
using HCQ2_Model.ViewModel;

namespace HCQ2_BLL
{
    public partial class A02BLL:HCQ2_IBLL.IA02BLL
    {
        public List<A02Model> SelectA02Data(HCQ2_Model.SelectModel.A02Model model)
        {
            if (model == null || string.IsNullOrEmpty(model.unitID))
                return null;
            return DBSession.IA02DAL.SelectA02CheckByMonthData(model);
        }

        public EchartsVo GetMonthChartData(HCQ2_Model.SelectModel.A02Model model)
        {
            if (model == null || string.IsNullOrEmpty(model.unitID))
                return null;
            List<A02Model> list= DBSession.IA02DAL.SelectA02CheckByMonthData(model);
            if (list==null || list.Count <= 0)
                return null;
            EchartsVo dChart = new EchartsVo();
            List<Series> seriesList = new List<Series>();//数据集合
            List<string> xAxis = new List<string>();//x轴数据
            List<decimal?> aPersons = new List<decimal?>();
            foreach (A02Model item in list)
            {
                xAxis.Add(item.cardDate);
                aPersons.Add(item.countPersons);
            }
            seriesList.Add(
                new Series()
                {
                    name = "打卡人数",
                    type = "bar",
                    data = aPersons
                });
            dChart.xAxis = xAxis;
            dChart.seriesList = seriesList;
            return dChart;
        }

        public List<PunchCardModel> SelectCardPersons(HCQ2_Model.SelectModel.A02Model model)
        {
            return DBSession.IA02DAL.SelectCardPersons(model);
        }
    }
}
