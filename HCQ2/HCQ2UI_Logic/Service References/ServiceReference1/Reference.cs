﻿//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由工具生成。
//     运行时版本:4.0.30319.42000
//
//     对此文件的更改可能会导致不正确的行为，并且如果
//     重新生成代码，这些更改将会丢失。
// </auto-generated>
//------------------------------------------------------------------------------

namespace HCQ2UI_Logic.ServiceReference1 {
    
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1586.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true, Namespace="http://uddi.dareway.com")]
    public partial class AppException : object, System.ComponentModel.INotifyPropertyChanged {
        
        private AppException1 appException1Field;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("AppException", IsNullable=true, Order=0)]
        public AppException1 AppException1 {
            get {
                return this.appException1Field;
            }
            set {
                this.appException1Field = value;
                this.RaisePropertyChanged("AppException1");
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1586.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(TypeName="AppException", Namespace="http://exception.framework.dareway.com/xsd")]
    public partial class AppException1 : Exception {
        
        private string clientDescField;
        
        private int errorCodeField;
        
        private bool errorCodeFieldSpecified;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true, Order=0)]
        public string clientDesc {
            get {
                return this.clientDescField;
            }
            set {
                this.clientDescField = value;
                this.RaisePropertyChanged("clientDesc");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=1)]
        public int errorCode {
            get {
                return this.errorCodeField;
            }
            set {
                this.errorCodeField = value;
                this.RaisePropertyChanged("errorCode");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool errorCodeSpecified {
            get {
                return this.errorCodeFieldSpecified;
            }
            set {
                this.errorCodeFieldSpecified = value;
                this.RaisePropertyChanged("errorCodeSpecified");
            }
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(AppException1))]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1586.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://uddi.dareway.com")]
    public partial class Exception : object, System.ComponentModel.INotifyPropertyChanged {
        
        private object exception1Field;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("Exception", IsNullable=true, Order=0)]
        public object Exception1 {
            get {
                return this.exception1Field;
            }
            set {
                this.exception1Field = value;
                this.RaisePropertyChanged("Exception1");
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(Namespace="http://uddi_1_0.uddi.dwlesbserver.apps.dareway.com", ConfigurationName="ServiceReference1.uddiPortType")]
    public interface uddiPortType {
        
        // CODEGEN: 消息 invokeServiceRequest 的包装命名空间(http://uddi.dareway.com)以后生成的消息协定与默认值(http://uddi_1_0.uddi.dwlesbserver.apps.dareway.com)不匹配
        [System.ServiceModel.OperationContractAttribute(Action="urn:invokeService", ReplyAction="urn:invokeServiceResponse")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(Exception))]
        HCQ2UI_Logic.ServiceReference1.invokeServiceResponse invokeService(HCQ2UI_Logic.ServiceReference1.invokeServiceRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="urn:invokeService", ReplyAction="urn:invokeServiceResponse")]
        System.Threading.Tasks.Task<HCQ2UI_Logic.ServiceReference1.invokeServiceResponse> invokeServiceAsync(HCQ2UI_Logic.ServiceReference1.invokeServiceRequest request);
        
        // CODEGEN: 消息 serviceProxyRequest 的包装命名空间(http://uddi.dareway.com)以后生成的消息协定与默认值(http://uddi_1_0.uddi.dwlesbserver.apps.dareway.com)不匹配
        [System.ServiceModel.OperationContractAttribute(Action="urn:serviceProxy", ReplyAction="urn:serviceProxyResponse")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(Exception))]
        HCQ2UI_Logic.ServiceReference1.serviceProxyResponse serviceProxy(HCQ2UI_Logic.ServiceReference1.serviceProxyRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="urn:serviceProxy", ReplyAction="urn:serviceProxyResponse")]
        System.Threading.Tasks.Task<HCQ2UI_Logic.ServiceReference1.serviceProxyResponse> serviceProxyAsync(HCQ2UI_Logic.ServiceReference1.serviceProxyRequest request);
        
        // CODEGEN: 消息 getTargetAppsByTypeRequest 的包装命名空间(http://uddi.dareway.com)以后生成的消息协定与默认值(http://uddi_1_0.uddi.dwlesbserver.apps.dareway.com)不匹配
        [System.ServiceModel.OperationContractAttribute(Action="urn:getTargetAppsByType", ReplyAction="urn:getTargetAppsByTypeResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(HCQ2UI_Logic.ServiceReference1.AppException), Action="urn:getTargetAppsByTypeAppException", Name="AppException", Namespace="http://uddi.dareway.com")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(Exception))]
        HCQ2UI_Logic.ServiceReference1.getTargetAppsByTypeResponse getTargetAppsByType(HCQ2UI_Logic.ServiceReference1.getTargetAppsByTypeRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="urn:getTargetAppsByType", ReplyAction="urn:getTargetAppsByTypeResponse")]
        System.Threading.Tasks.Task<HCQ2UI_Logic.ServiceReference1.getTargetAppsByTypeResponse> getTargetAppsByTypeAsync(HCQ2UI_Logic.ServiceReference1.getTargetAppsByTypeRequest request);
        
        // CODEGEN: 消息 getServiceUrlRequest 的包装命名空间(http://uddi.dareway.com)以后生成的消息协定与默认值(http://uddi_1_0.uddi.dwlesbserver.apps.dareway.com)不匹配
        [System.ServiceModel.OperationContractAttribute(Action="urn:getServiceUrl", ReplyAction="urn:getServiceUrlResponse")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(Exception))]
        HCQ2UI_Logic.ServiceReference1.getServiceUrlResponse getServiceUrl(HCQ2UI_Logic.ServiceReference1.getServiceUrlRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="urn:getServiceUrl", ReplyAction="urn:getServiceUrlResponse")]
        System.Threading.Tasks.Task<HCQ2UI_Logic.ServiceReference1.getServiceUrlResponse> getServiceUrlAsync(HCQ2UI_Logic.ServiceReference1.getServiceUrlRequest request);
        
        // CODEGEN: 消息 TransResultRequest 的包装命名空间(http://uddi.dareway.com)以后生成的消息协定与默认值(http://uddi_1_0.uddi.dwlesbserver.apps.dareway.com)不匹配
        [System.ServiceModel.OperationContractAttribute(Action="urn:TransResult", ReplyAction="urn:TransResultResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(HCQ2UI_Logic.ServiceReference1.AppException), Action="urn:TransResultAppException", Name="AppException", Namespace="http://uddi.dareway.com")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(Exception))]
        HCQ2UI_Logic.ServiceReference1.TransResultResponse TransResult(HCQ2UI_Logic.ServiceReference1.TransResultRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="urn:TransResult", ReplyAction="urn:TransResultResponse")]
        System.Threading.Tasks.Task<HCQ2UI_Logic.ServiceReference1.TransResultResponse> TransResultAsync(HCQ2UI_Logic.ServiceReference1.TransResultRequest request);
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="invokeService", WrapperNamespace="http://uddi.dareway.com", IsWrapped=true)]
    public partial class invokeServiceRequest {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://uddi.dareway.com", Order=0)]
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public string args0;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://uddi.dareway.com", Order=1)]
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public string args1;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://uddi.dareway.com", Order=2)]
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public string args2;
        
        public invokeServiceRequest() {
        }
        
        public invokeServiceRequest(string args0, string args1, string args2) {
            this.args0 = args0;
            this.args1 = args1;
            this.args2 = args2;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="invokeServiceResponse", WrapperNamespace="http://uddi.dareway.com", IsWrapped=true)]
    public partial class invokeServiceResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://uddi.dareway.com", Order=0)]
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public string @return;
        
        public invokeServiceResponse() {
        }
        
        public invokeServiceResponse(string @return) {
            this.@return = @return;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="serviceProxy", WrapperNamespace="http://uddi.dareway.com", IsWrapped=true)]
    public partial class serviceProxyRequest {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://uddi.dareway.com", Order=0)]
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public string args0;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://uddi.dareway.com", Order=1)]
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public string args1;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://uddi.dareway.com", Order=2)]
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public string args2;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://uddi.dareway.com", Order=3)]
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public string args3;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://uddi.dareway.com", Order=4)]
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public string args4;
        
        public serviceProxyRequest() {
        }
        
        public serviceProxyRequest(string args0, string args1, string args2, string args3, string args4) {
            this.args0 = args0;
            this.args1 = args1;
            this.args2 = args2;
            this.args3 = args3;
            this.args4 = args4;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="serviceProxyResponse", WrapperNamespace="http://uddi.dareway.com", IsWrapped=true)]
    public partial class serviceProxyResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://uddi.dareway.com", Order=0)]
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public string @return;
        
        public serviceProxyResponse() {
        }
        
        public serviceProxyResponse(string @return) {
            this.@return = @return;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="getTargetAppsByType", WrapperNamespace="http://uddi.dareway.com", IsWrapped=true)]
    public partial class getTargetAppsByTypeRequest {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://uddi.dareway.com", Order=0)]
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public string args0;
        
        public getTargetAppsByTypeRequest() {
        }
        
        public getTargetAppsByTypeRequest(string args0) {
            this.args0 = args0;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="getTargetAppsByTypeResponse", WrapperNamespace="http://uddi.dareway.com", IsWrapped=true)]
    public partial class getTargetAppsByTypeResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://uddi.dareway.com", Order=0)]
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public string @return;
        
        public getTargetAppsByTypeResponse() {
        }
        
        public getTargetAppsByTypeResponse(string @return) {
            this.@return = @return;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="getServiceUrl", WrapperNamespace="http://uddi.dareway.com", IsWrapped=true)]
    public partial class getServiceUrlRequest {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://uddi.dareway.com", Order=0)]
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public string args0;
        
        public getServiceUrlRequest() {
        }
        
        public getServiceUrlRequest(string args0) {
            this.args0 = args0;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="getServiceUrlResponse", WrapperNamespace="http://uddi.dareway.com", IsWrapped=true)]
    public partial class getServiceUrlResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://uddi.dareway.com", Order=0)]
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public string @return;
        
        public getServiceUrlResponse() {
        }
        
        public getServiceUrlResponse(string @return) {
            this.@return = @return;
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1586.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://util.framework.dareway.com/xsd")]
    public partial class DataObject : object, System.ComponentModel.INotifyPropertyChanged {
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="TransResult", WrapperNamespace="http://uddi.dareway.com", IsWrapped=true)]
    public partial class TransResultRequest {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://uddi.dareway.com", Order=0)]
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public HCQ2UI_Logic.ServiceReference1.DataObject args0;
        
        public TransResultRequest() {
        }
        
        public TransResultRequest(HCQ2UI_Logic.ServiceReference1.DataObject args0) {
            this.args0 = args0;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="TransResultResponse", WrapperNamespace="http://uddi.dareway.com", IsWrapped=true)]
    public partial class TransResultResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://uddi.dareway.com", Order=0)]
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public string @return;
        
        public TransResultResponse() {
        }
        
        public TransResultResponse(string @return) {
            this.@return = @return;
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface uddiPortTypeChannel : HCQ2UI_Logic.ServiceReference1.uddiPortType, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class uddiPortTypeClient : System.ServiceModel.ClientBase<HCQ2UI_Logic.ServiceReference1.uddiPortType>, HCQ2UI_Logic.ServiceReference1.uddiPortType {
        
        public uddiPortTypeClient() {
        }
        
        public uddiPortTypeClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public uddiPortTypeClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public uddiPortTypeClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public uddiPortTypeClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        HCQ2UI_Logic.ServiceReference1.invokeServiceResponse HCQ2UI_Logic.ServiceReference1.uddiPortType.invokeService(HCQ2UI_Logic.ServiceReference1.invokeServiceRequest request) {
            return base.Channel.invokeService(request);
        }
        
        public string invokeService(string args0, string args1, string args2) {
            HCQ2UI_Logic.ServiceReference1.invokeServiceRequest inValue = new HCQ2UI_Logic.ServiceReference1.invokeServiceRequest();
            inValue.args0 = args0;
            inValue.args1 = args1;
            inValue.args2 = args2;
            HCQ2UI_Logic.ServiceReference1.invokeServiceResponse retVal = ((HCQ2UI_Logic.ServiceReference1.uddiPortType)(this)).invokeService(inValue);
            return retVal.@return;
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<HCQ2UI_Logic.ServiceReference1.invokeServiceResponse> HCQ2UI_Logic.ServiceReference1.uddiPortType.invokeServiceAsync(HCQ2UI_Logic.ServiceReference1.invokeServiceRequest request) {
            return base.Channel.invokeServiceAsync(request);
        }
        
        public System.Threading.Tasks.Task<HCQ2UI_Logic.ServiceReference1.invokeServiceResponse> invokeServiceAsync(string args0, string args1, string args2) {
            HCQ2UI_Logic.ServiceReference1.invokeServiceRequest inValue = new HCQ2UI_Logic.ServiceReference1.invokeServiceRequest();
            inValue.args0 = args0;
            inValue.args1 = args1;
            inValue.args2 = args2;
            return ((HCQ2UI_Logic.ServiceReference1.uddiPortType)(this)).invokeServiceAsync(inValue);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        HCQ2UI_Logic.ServiceReference1.serviceProxyResponse HCQ2UI_Logic.ServiceReference1.uddiPortType.serviceProxy(HCQ2UI_Logic.ServiceReference1.serviceProxyRequest request) {
            return base.Channel.serviceProxy(request);
        }
        
        public string serviceProxy(string args0, string args1, string args2, string args3, string args4) {
            HCQ2UI_Logic.ServiceReference1.serviceProxyRequest inValue = new HCQ2UI_Logic.ServiceReference1.serviceProxyRequest();
            inValue.args0 = args0;
            inValue.args1 = args1;
            inValue.args2 = args2;
            inValue.args3 = args3;
            inValue.args4 = args4;
            HCQ2UI_Logic.ServiceReference1.serviceProxyResponse retVal = ((HCQ2UI_Logic.ServiceReference1.uddiPortType)(this)).serviceProxy(inValue);
            return retVal.@return;
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<HCQ2UI_Logic.ServiceReference1.serviceProxyResponse> HCQ2UI_Logic.ServiceReference1.uddiPortType.serviceProxyAsync(HCQ2UI_Logic.ServiceReference1.serviceProxyRequest request) {
            return base.Channel.serviceProxyAsync(request);
        }
        
        public System.Threading.Tasks.Task<HCQ2UI_Logic.ServiceReference1.serviceProxyResponse> serviceProxyAsync(string args0, string args1, string args2, string args3, string args4) {
            HCQ2UI_Logic.ServiceReference1.serviceProxyRequest inValue = new HCQ2UI_Logic.ServiceReference1.serviceProxyRequest();
            inValue.args0 = args0;
            inValue.args1 = args1;
            inValue.args2 = args2;
            inValue.args3 = args3;
            inValue.args4 = args4;
            return ((HCQ2UI_Logic.ServiceReference1.uddiPortType)(this)).serviceProxyAsync(inValue);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        HCQ2UI_Logic.ServiceReference1.getTargetAppsByTypeResponse HCQ2UI_Logic.ServiceReference1.uddiPortType.getTargetAppsByType(HCQ2UI_Logic.ServiceReference1.getTargetAppsByTypeRequest request) {
            return base.Channel.getTargetAppsByType(request);
        }
        
        public string getTargetAppsByType(string args0) {
            HCQ2UI_Logic.ServiceReference1.getTargetAppsByTypeRequest inValue = new HCQ2UI_Logic.ServiceReference1.getTargetAppsByTypeRequest();
            inValue.args0 = args0;
            HCQ2UI_Logic.ServiceReference1.getTargetAppsByTypeResponse retVal = ((HCQ2UI_Logic.ServiceReference1.uddiPortType)(this)).getTargetAppsByType(inValue);
            return retVal.@return;
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<HCQ2UI_Logic.ServiceReference1.getTargetAppsByTypeResponse> HCQ2UI_Logic.ServiceReference1.uddiPortType.getTargetAppsByTypeAsync(HCQ2UI_Logic.ServiceReference1.getTargetAppsByTypeRequest request) {
            return base.Channel.getTargetAppsByTypeAsync(request);
        }
        
        public System.Threading.Tasks.Task<HCQ2UI_Logic.ServiceReference1.getTargetAppsByTypeResponse> getTargetAppsByTypeAsync(string args0) {
            HCQ2UI_Logic.ServiceReference1.getTargetAppsByTypeRequest inValue = new HCQ2UI_Logic.ServiceReference1.getTargetAppsByTypeRequest();
            inValue.args0 = args0;
            return ((HCQ2UI_Logic.ServiceReference1.uddiPortType)(this)).getTargetAppsByTypeAsync(inValue);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        HCQ2UI_Logic.ServiceReference1.getServiceUrlResponse HCQ2UI_Logic.ServiceReference1.uddiPortType.getServiceUrl(HCQ2UI_Logic.ServiceReference1.getServiceUrlRequest request) {
            return base.Channel.getServiceUrl(request);
        }
        
        public string getServiceUrl(string args0) {
            HCQ2UI_Logic.ServiceReference1.getServiceUrlRequest inValue = new HCQ2UI_Logic.ServiceReference1.getServiceUrlRequest();
            inValue.args0 = args0;
            HCQ2UI_Logic.ServiceReference1.getServiceUrlResponse retVal = ((HCQ2UI_Logic.ServiceReference1.uddiPortType)(this)).getServiceUrl(inValue);
            return retVal.@return;
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<HCQ2UI_Logic.ServiceReference1.getServiceUrlResponse> HCQ2UI_Logic.ServiceReference1.uddiPortType.getServiceUrlAsync(HCQ2UI_Logic.ServiceReference1.getServiceUrlRequest request) {
            return base.Channel.getServiceUrlAsync(request);
        }
        
        public System.Threading.Tasks.Task<HCQ2UI_Logic.ServiceReference1.getServiceUrlResponse> getServiceUrlAsync(string args0) {
            HCQ2UI_Logic.ServiceReference1.getServiceUrlRequest inValue = new HCQ2UI_Logic.ServiceReference1.getServiceUrlRequest();
            inValue.args0 = args0;
            return ((HCQ2UI_Logic.ServiceReference1.uddiPortType)(this)).getServiceUrlAsync(inValue);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        HCQ2UI_Logic.ServiceReference1.TransResultResponse HCQ2UI_Logic.ServiceReference1.uddiPortType.TransResult(HCQ2UI_Logic.ServiceReference1.TransResultRequest request) {
            return base.Channel.TransResult(request);
        }
        
        public string TransResult(HCQ2UI_Logic.ServiceReference1.DataObject args0) {
            HCQ2UI_Logic.ServiceReference1.TransResultRequest inValue = new HCQ2UI_Logic.ServiceReference1.TransResultRequest();
            inValue.args0 = args0;
            HCQ2UI_Logic.ServiceReference1.TransResultResponse retVal = ((HCQ2UI_Logic.ServiceReference1.uddiPortType)(this)).TransResult(inValue);
            return retVal.@return;
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<HCQ2UI_Logic.ServiceReference1.TransResultResponse> HCQ2UI_Logic.ServiceReference1.uddiPortType.TransResultAsync(HCQ2UI_Logic.ServiceReference1.TransResultRequest request) {
            return base.Channel.TransResultAsync(request);
        }
        
        public System.Threading.Tasks.Task<HCQ2UI_Logic.ServiceReference1.TransResultResponse> TransResultAsync(HCQ2UI_Logic.ServiceReference1.DataObject args0) {
            HCQ2UI_Logic.ServiceReference1.TransResultRequest inValue = new HCQ2UI_Logic.ServiceReference1.TransResultRequest();
            inValue.args0 = args0;
            return ((HCQ2UI_Logic.ServiceReference1.uddiPortType)(this)).TransResultAsync(inValue);
        }
    }
}