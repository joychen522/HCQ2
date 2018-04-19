using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HCQ2_Model;
using HCQ2_Model.APPModel.ParamModel;
using HCQ2_Model.APPModel.ResultApiModel;
using HCQ2_Model.SelectModel;
using HCQ2_Model.ViewModel;

namespace HCQ2_BLL
{
    public partial class WGJG01BLL: HCQ2_IBLL.IWGJG01BLL
    {
        public List<WGJG01Model> GetWageListDataByUnit(WGJG01ChartModel model)
        {
            if (string.IsNullOrEmpty(model.unitID))
                return null;
            return DBSession.IWGJG01DAL.GetWageListDataByUnit(model);
        }

        public int EditWGJG01(WGJG01 model)
        {
            return Modify(model,s=>s.RowID==model.RowID, "WGJG0101", "WGJG0103", "WGJG0104", "WGJG0107");
        }

        public EchartsVo GetChartData(WGJG01ChartModel model)
        {
            List<WGJG01Model> list = DBSession.IWGJG01DAL.GetWageListDataByUnit(model);
            if (list.Count <= 0)
                return null;
            EchartsVo dChart = new EchartsVo();
            List<Series> seriesList = new List<Series>();
            List<decimal?> aMoney = new List<decimal?>();
            decimal monry = Math.Round(list.Sum(s => s.allMoney)/10000, 2);
            aMoney.Add(monry);//应该总金额
            monry = Math.Round(list.Sum(s => s.sureMoney) / 10000, 2);
            aMoney.Add(monry);//已发总金额
            monry = Math.Round(list.Sum(s => s.payMoney) / 10000, 2);
            aMoney.Add(monry);//欠薪总金额
            seriesList.Add(
                new Series()
                {
                    name = "金额",
                    type = "bar",
                    data = aMoney
                });
            dChart.seriesList = seriesList;
            return dChart;
        }

        public List<DebtWGJG01Model> GetGrantInfoByUnit(DebtSelGrantModel model)
        {
            return DBSession.IWGJG01DAL.GetGrantInfoByUnit(model);
        }
    }
}
