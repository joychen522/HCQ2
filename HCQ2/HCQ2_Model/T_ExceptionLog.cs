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
    
    public partial class T_ExceptionLog
    {
        public int log_id { get; set; }
        public string log_ip { get; set; }
        public string log_browse { get; set; }
        public string browse_versions { get; set; }
        public string log_sys { get; set; }
        public string log_url { get; set; }
        public string log_title { get; set; }
        public string log_source { get; set; }
        public string log_func { get; set; }
        public string log_stack { get; set; }
        public System.DateTime created_time { get; set; }
    }
}