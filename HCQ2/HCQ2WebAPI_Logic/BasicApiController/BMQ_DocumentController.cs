using System.Web.Http;
using HCQ2_Common.Constant;
using HCQ2_Model.WebApiModel.ParamModel;
using HCQ2WebAPI_Logic.BaseAPIController;

namespace HCQ2WebAPI_Logic.BasicApiController
{
    public class BMQ_DocumentController : BaseWeiXinApiLogic
    {
        /// <summary>
        /// 获取所有的新闻政策
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public object GetDocument()
        {
            var data = operateContext.bllSession.BMQ_Document.GetDocumentInfo();
            return operateContext.RedirectWebApi(WebResultCode.Ok, GlobalConstant.操作成功.ToString(), data);
        }

        /// <summary>
        /// 根据政策ID获取条相关新闻政策
        /// </summary>
        /// <param name="document_id"></param>
        /// <returns></returns>
        [HttpPost]
        public object GetDocByID(BmqDetail detail)
        {
            var data = operateContext.bllSession.BMQ_Document.GetByDocumentID(detail.document_id);
            return operateContext.RedirectWebApi(WebResultCode.Ok, GlobalConstant.操作成功.ToString(), data);
        }

        /// <summary>
        /// 分页获取新闻政策以及政策新闻关键字搜索
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public object GetPageRowDocument(BmqModle modle)
        {
            if (!ModelState.IsValid)
                return operateContext.RedirectWebApi(WebResultCode.Exception, GlobalConstant.参数异常.ToString(), null);

            var data = operateContext.bllSession.BMQ_Document.GetApiPageRowDoc(modle);
            return operateContext.RedirectWebApi(WebResultCode.Ok, GlobalConstant.操作成功.ToString(), data);
        }
    }
}
