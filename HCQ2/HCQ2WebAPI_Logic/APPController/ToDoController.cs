using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HCQ2WebAPI_Logic.BaseAPIController;
using System.Web.Http;
using HCQ2_Common.Constant;
using HCQ2_Model.AppModel;

namespace HCQ2WebAPI_Logic.APPController
{
    public class ToDoController : BaseWeiXinApiLogic
    {

        /// <summary>
        /// 分页获取待办事宜
        /// </summary>
        /// <param name="todo"></param>
        /// <returns></returns>
        [HttpPost]
        public object GetTodoPageRowList(ToDoRecred todo)
        {
            if (!ModelState.IsValid)
                return operateContext.RedirectWebApi(WebResultCode.Exception, GlobalConstant.参数异常.ToString(), null);

            var data = operateContext.bllSession.T_TodoList.GetTodoPageRowList(todo);
            return operateContext.RedirectWebApi(WebResultCode.Ok, GlobalConstant.操作成功.ToString(), data);
        }
    }
}
