﻿//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由工具生成。
//     运行时版本:4.0.30319.42000
//
//     对此文件的更改可能会导致不正确的行为，并且如果
//     重新生成代码，这些更改将会丢失。
// </auto-generated>
//------------------------------------------------------------------------------

// 
// 此源代码是由 Microsoft.VSDesigner 4.0.30319.42000 版自动生成。
// 
#pragma warning disable 1591

namespace HCQ2_BLL.WebUpData {
    using System;
    using System.Web.Services;
    using System.Diagnostics;
    using System.Web.Services.Protocols;
    using System.Xml.Serialization;
    using System.ComponentModel;
    
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.1586.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Web.Services.WebServiceBindingAttribute(Name="uddiSoap11Binding", Namespace="http://uddi_1_0.uddi.dwlesbserver.apps.dareway.com")]
    public partial class uddi : System.Web.Services.Protocols.SoapHttpClientProtocol {
        
        private System.Threading.SendOrPostCallback invokeServiceOperationCompleted;
        
        private System.Threading.SendOrPostCallback serviceProxyOperationCompleted;
        
        private System.Threading.SendOrPostCallback getTargetAppsByTypeOperationCompleted;
        
        private System.Threading.SendOrPostCallback getServiceUrlOperationCompleted;
        
        private bool useDefaultCredentialsSetExplicitly;
        
        /// <remarks/>
        public uddi() {
            this.Url = global::HCQ2_BLL.Properties.Settings.Default.HCQ2_BLL_WebUpData_uddi;
            if ((this.IsLocalFileSystemWebService(this.Url) == true)) {
                this.UseDefaultCredentials = true;
                this.useDefaultCredentialsSetExplicitly = false;
            }
            else {
                this.useDefaultCredentialsSetExplicitly = true;
            }
        }
        
        public new string Url {
            get {
                return base.Url;
            }
            set {
                if ((((this.IsLocalFileSystemWebService(base.Url) == true) 
                            && (this.useDefaultCredentialsSetExplicitly == false)) 
                            && (this.IsLocalFileSystemWebService(value) == false))) {
                    base.UseDefaultCredentials = false;
                }
                base.Url = value;
            }
        }
        
        public new bool UseDefaultCredentials {
            get {
                return base.UseDefaultCredentials;
            }
            set {
                base.UseDefaultCredentials = value;
                this.useDefaultCredentialsSetExplicitly = true;
            }
        }
        
        /// <remarks/>
        public event invokeServiceCompletedEventHandler invokeServiceCompleted;
        
        /// <remarks/>
        public event serviceProxyCompletedEventHandler serviceProxyCompleted;
        
        /// <remarks/>
        public event getTargetAppsByTypeCompletedEventHandler getTargetAppsByTypeCompleted;
        
        /// <remarks/>
        public event getServiceUrlCompletedEventHandler getServiceUrlCompleted;
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("urn:invokeService", RequestNamespace="http://uddi.dareway.com", ResponseNamespace="http://uddi.dareway.com", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        [return: System.Xml.Serialization.XmlElementAttribute("return", IsNullable=true)]
        public string invokeService([System.Xml.Serialization.XmlElementAttribute(IsNullable=true)] string args0, [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)] string args1, [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)] string args2) {
            object[] results = this.Invoke("invokeService", new object[] {
                        args0,
                        args1,
                        args2});
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        public void invokeServiceAsync(string args0, string args1, string args2) {
            this.invokeServiceAsync(args0, args1, args2, null);
        }
        
        /// <remarks/>
        public void invokeServiceAsync(string args0, string args1, string args2, object userState) {
            if ((this.invokeServiceOperationCompleted == null)) {
                this.invokeServiceOperationCompleted = new System.Threading.SendOrPostCallback(this.OninvokeServiceOperationCompleted);
            }
            this.InvokeAsync("invokeService", new object[] {
                        args0,
                        args1,
                        args2}, this.invokeServiceOperationCompleted, userState);
        }
        
        private void OninvokeServiceOperationCompleted(object arg) {
            if ((this.invokeServiceCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.invokeServiceCompleted(this, new invokeServiceCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("urn:serviceProxy", RequestNamespace="http://uddi.dareway.com", ResponseNamespace="http://uddi.dareway.com", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        [return: System.Xml.Serialization.XmlElementAttribute("return", IsNullable=true)]
        public string serviceProxy([System.Xml.Serialization.XmlElementAttribute(IsNullable=true)] string args0, [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)] string args1, [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)] string args2, [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)] string args3, [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)] string args4) {
            object[] results = this.Invoke("serviceProxy", new object[] {
                        args0,
                        args1,
                        args2,
                        args3,
                        args4});
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        public void serviceProxyAsync(string args0, string args1, string args2, string args3, string args4) {
            this.serviceProxyAsync(args0, args1, args2, args3, args4, null);
        }
        
        /// <remarks/>
        public void serviceProxyAsync(string args0, string args1, string args2, string args3, string args4, object userState) {
            if ((this.serviceProxyOperationCompleted == null)) {
                this.serviceProxyOperationCompleted = new System.Threading.SendOrPostCallback(this.OnserviceProxyOperationCompleted);
            }
            this.InvokeAsync("serviceProxy", new object[] {
                        args0,
                        args1,
                        args2,
                        args3,
                        args4}, this.serviceProxyOperationCompleted, userState);
        }
        
        private void OnserviceProxyOperationCompleted(object arg) {
            if ((this.serviceProxyCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.serviceProxyCompleted(this, new serviceProxyCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("urn:getTargetAppsByType", RequestNamespace="http://uddi.dareway.com", ResponseNamespace="http://uddi.dareway.com", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        [return: System.Xml.Serialization.XmlElementAttribute("return", IsNullable=true)]
        public string getTargetAppsByType([System.Xml.Serialization.XmlElementAttribute(IsNullable=true)] string args0) {
            object[] results = this.Invoke("getTargetAppsByType", new object[] {
                        args0});
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        public void getTargetAppsByTypeAsync(string args0) {
            this.getTargetAppsByTypeAsync(args0, null);
        }
        
        /// <remarks/>
        public void getTargetAppsByTypeAsync(string args0, object userState) {
            if ((this.getTargetAppsByTypeOperationCompleted == null)) {
                this.getTargetAppsByTypeOperationCompleted = new System.Threading.SendOrPostCallback(this.OngetTargetAppsByTypeOperationCompleted);
            }
            this.InvokeAsync("getTargetAppsByType", new object[] {
                        args0}, this.getTargetAppsByTypeOperationCompleted, userState);
        }
        
        private void OngetTargetAppsByTypeOperationCompleted(object arg) {
            if ((this.getTargetAppsByTypeCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.getTargetAppsByTypeCompleted(this, new getTargetAppsByTypeCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("urn:getServiceUrl", RequestNamespace="http://uddi.dareway.com", ResponseNamespace="http://uddi.dareway.com", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        [return: System.Xml.Serialization.XmlElementAttribute("return", IsNullable=true)]
        public string getServiceUrl([System.Xml.Serialization.XmlElementAttribute(IsNullable=true)] string args0) {
            object[] results = this.Invoke("getServiceUrl", new object[] {
                        args0});
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        public void getServiceUrlAsync(string args0) {
            this.getServiceUrlAsync(args0, null);
        }
        
        /// <remarks/>
        public void getServiceUrlAsync(string args0, object userState) {
            if ((this.getServiceUrlOperationCompleted == null)) {
                this.getServiceUrlOperationCompleted = new System.Threading.SendOrPostCallback(this.OngetServiceUrlOperationCompleted);
            }
            this.InvokeAsync("getServiceUrl", new object[] {
                        args0}, this.getServiceUrlOperationCompleted, userState);
        }
        
        private void OngetServiceUrlOperationCompleted(object arg) {
            if ((this.getServiceUrlCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.getServiceUrlCompleted(this, new getServiceUrlCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        public new void CancelAsync(object userState) {
            base.CancelAsync(userState);
        }
        
        private bool IsLocalFileSystemWebService(string url) {
            if (((url == null) 
                        || (url == string.Empty))) {
                return false;
            }
            System.Uri wsUri = new System.Uri(url);
            if (((wsUri.Port >= 1024) 
                        && (string.Compare(wsUri.Host, "localHost", System.StringComparison.OrdinalIgnoreCase) == 0))) {
                return true;
            }
            return false;
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.1586.0")]
    public delegate void invokeServiceCompletedEventHandler(object sender, invokeServiceCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.1586.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class invokeServiceCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal invokeServiceCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public string Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((string)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.1586.0")]
    public delegate void serviceProxyCompletedEventHandler(object sender, serviceProxyCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.1586.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class serviceProxyCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal serviceProxyCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public string Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((string)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.1586.0")]
    public delegate void getTargetAppsByTypeCompletedEventHandler(object sender, getTargetAppsByTypeCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.1586.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class getTargetAppsByTypeCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal getTargetAppsByTypeCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public string Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((string)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.1586.0")]
    public delegate void getServiceUrlCompletedEventHandler(object sender, getServiceUrlCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.1586.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class getServiceUrlCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal getServiceUrlCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public string Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((string)(this.results[0]));
            }
        }
    }
}

#pragma warning restore 1591