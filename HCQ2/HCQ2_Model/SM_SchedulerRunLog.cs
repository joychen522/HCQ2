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
    
    public partial class SM_SchedulerRunLog
    {
        public string RowID { get; set; }
        public string SchedulerID { get; set; }
        public string SchedulerName { get; set; }
        public string LogID { get; set; }
        public System.DateTime LogTime { get; set; }
        public System.DateTime StartTime { get; set; }
        public System.DateTime EndTime { get; set; }
        public long ElapsedTime { get; set; }
        public int ExecuteResult { get; set; }
        public string ResultMessage { get; set; }
    }
}
