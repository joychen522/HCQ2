using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HCQ2_Model.WebApiModel.ParamModel;

namespace HCQ2_BLL
{
    public partial class Project_LogApiBLL:HCQ2_IBLL.IProject_LogApiBLL
    {
        public int Add(AppLogModel model)
        {
           return Add(new HCQ2_Model.Project_LogApi()
            {
                Message = model.log_message,
                Content = model.log_content
            });
        }
    }
}
