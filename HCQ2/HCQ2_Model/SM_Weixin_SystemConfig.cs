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
    
    public partial class SM_Weixin_SystemConfig
    {
        public int WxAccountType { get; set; }
        public string WxAccountName { get; set; }
        public string WxToken { get; set; }
        public string WxAppId { get; set; }
        public string WxAppSecret { get; set; }
        public string WxMenu { get; set; }
        public Nullable<int> IsAccountSignature { get; set; }
        public string TextHandler { get; set; }
        public string VoiceHandler { get; set; }
        public string LocationHandler { get; set; }
        public string LinkHandler { get; set; }
        public string VideoHandler { get; set; }
        public string ImageHandler { get; set; }
        public string EventSubscribeHandler { get; set; }
        public string EventUnSubscribeHandler { get; set; }
        public string EventScanHandler { get; set; }
        public string EventLocationHandler { get; set; }
    }
}