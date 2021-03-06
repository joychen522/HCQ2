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
    
    public partial class BPM_Run_WorkTask
    {
        public string RowID { get; set; }
        public string SchemeID { get; set; }
        public string ProcessID { get; set; }
        public int ProcessVersion { get; set; }
        public string InstanceID { get; set; }
        public string TrackingID { get; set; }
        public string TaskID { get; set; }
        public string TaskName { get; set; }
        public int TaskType { get; set; }
        public int TaskShortDesc { get; set; }
        public string BizID { get; set; }
        public string ActivityID { get; set; }
        public string ActivityName { get; set; }
        public string Summary { get; set; }
        public string FormID { get; set; }
        public string ProcessInitiatorID { get; set; }
        public string ProcessInitiatorName { get; set; }
        public string OwnerID { get; set; }
        public string OwnerName { get; set; }
        public string OwnerOrgID { get; set; }
        public string OwnerPostID { get; set; }
        public string OwnerRoleID { get; set; }
        public string OwnerTeamID { get; set; }
        public string ExecutorID { get; set; }
        public string ExecutorName { get; set; }
        public string FinisherID { get; set; }
        public string FinisherName { get; set; }
        public string AgentID { get; set; }
        public string AgentName { get; set; }
        public Nullable<System.DateTime> CreateTime { get; set; }
        public Nullable<System.DateTime> ReceiveTime { get; set; }
        public Nullable<System.DateTime> EndTime { get; set; }
        public Nullable<System.DateTime> UrgedTime { get; set; }
        public Nullable<System.DateTime> PlanFinishTime { get; set; }
        public Nullable<int> ElapsedTime { get; set; }
        public Nullable<int> Approval { get; set; }
        public string Comment { get; set; }
        public string StateDesc { get; set; }
        public string State { get; set; }
        public string ReturnToTaskID { get; set; }
        public string ParentTaskID { get; set; }
        public Nullable<int> AllowBatchHandle { get; set; }
        public Nullable<int> IsMaster { get; set; }
        public Nullable<int> IsStart { get; set; }
        public Nullable<int> IsDraft { get; set; }
        public Nullable<int> IsShare { get; set; }
        public int IsDeleted { get; set; }
        public int DispOrder { get; set; }
        public Nullable<int> PlanDuration { get; set; }
        public string ActionID { get; set; }
        public string ActionName { get; set; }
    }
}
