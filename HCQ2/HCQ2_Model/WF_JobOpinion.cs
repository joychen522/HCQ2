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
    
    public partial class WF_JobOpinion
    {
        public string OpinionID { get; set; }
        public string JobID { get; set; }
        public Nullable<int> JobStepID { get; set; }
        public string AuditUserID { get; set; }
        public string AuditUserName { get; set; }
        public string AuditResult { get; set; }
        public string AuditResultName { get; set; }
        public string AuditOpinion { get; set; }
        public string AuditDisagreeProcess { get; set; }
        public Nullable<System.DateTime> AuditTime { get; set; }
    }
}
