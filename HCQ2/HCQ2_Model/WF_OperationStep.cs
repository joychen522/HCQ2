//------------------------------------------------------------------------------
// <auto-generated>
//     此代码已从模板生成。
//
//     手动更改此文件可能导致应用程序出现意外的行为。
//     如果重新生成代码，将覆盖对此文件的手动更改。
// </auto-generated>
//------------------------------------------------------------------------------

namespace HCQ2_Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class WF_OperationStep
    {
        public string OperID { get; set; }
        public string StepID { get; set; }
        public string StepName { get; set; }
        public Nullable<int> DispOrder { get; set; }
        public int IsStartup { get; set; }
        public string Privilege { get; set; }
        public string InterfaceUrl { get; set; }
        public string RedirectAction { get; set; }
        public string Descript { get; set; }
        public string EqualStepPrivilege { get; set; }
        public int IsSharePrivilege { get; set; }
        public int IsSpecialPrivilege { get; set; }
        public int IsNeedAudit { get; set; }
        public string AuditScript { get; set; }
        public string DescriptSubmit { get; set; }
        public string DescriptRemarkData { get; set; }
        public string DescriptRemarkResult { get; set; }
        public string ViewInterfaceUrl { get; set; }
        public string SubmitScript { get; set; }
        public Nullable<int> IsManualEndJob { get; set; }
        public string AuditScriptNotForce { get; set; }
        public int IsNeedAuditNotForce { get; set; }
        public string WidgetModuleID { get; set; }
        public string SubmitArchiveScript { get; set; }
        public string SubmitArchiveScriptSql { get; set; }
        public string SubmitAfterAction { get; set; }
    }
}
