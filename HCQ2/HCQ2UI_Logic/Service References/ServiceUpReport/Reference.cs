﻿//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由工具生成。
//     运行时版本:4.0.30319.42000
//
//     对此文件的更改可能会导致不正确的行为，并且如果
//     重新生成代码，这些更改将会丢失。
// </auto-generated>
//------------------------------------------------------------------------------

namespace HCQ2UI_Logic.ServiceUpReport {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(Namespace="http://uddi_1_0.uddi.dwlesbserver.apps.dareway.com", ConfigurationName="ServiceUpReport.uddiPortType")]
    public interface uddiPortType {
        
        // CODEGEN: 消息 invokeServiceRequest 的包装命名空间(http://uddi.dareway.com)以后生成的消息协定与默认值(http://uddi_1_0.uddi.dwlesbserver.apps.dareway.com)不匹配
        [System.ServiceModel.OperationContractAttribute(Action="urn:invokeService", ReplyAction="urn:invokeServiceResponse")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        HCQ2UI_Logic.ServiceUpReport.invokeServiceResponse invokeService(HCQ2UI_Logic.ServiceUpReport.invokeServiceRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="urn:invokeService", ReplyAction="urn:invokeServiceResponse")]
        System.Threading.Tasks.Task<HCQ2UI_Logic.ServiceUpReport.invokeServiceResponse> invokeServiceAsync(HCQ2UI_Logic.ServiceUpReport.invokeServiceRequest request);
        
        // CODEGEN: 消息 serviceProxyRequest 的包装命名空间(http://uddi.dareway.com)以后生成的消息协定与默认值(http://uddi_1_0.uddi.dwlesbserver.apps.dareway.com)不匹配
        [System.ServiceModel.OperationContractAttribute(Action="urn:serviceProxy", ReplyAction="urn:serviceProxyResponse")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        HCQ2UI_Logic.ServiceUpReport.serviceProxyResponse serviceProxy(HCQ2UI_Logic.ServiceUpReport.serviceProxyRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="urn:serviceProxy", ReplyAction="urn:serviceProxyResponse")]
        System.Threading.Tasks.Task<HCQ2UI_Logic.ServiceUpReport.serviceProxyResponse> serviceProxyAsync(HCQ2UI_Logic.ServiceUpReport.serviceProxyRequest request);
        
        // CODEGEN: 消息 getTargetAppsByTypeRequest 的包装命名空间(http://uddi.dareway.com)以后生成的消息协定与默认值(http://uddi_1_0.uddi.dwlesbserver.apps.dareway.com)不匹配
        [System.ServiceModel.OperationContractAttribute(Action="urn:getTargetAppsByType", ReplyAction="urn:getTargetAppsByTypeResponse")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        HCQ2UI_Logic.ServiceUpReport.getTargetAppsByTypeResponse getTargetAppsByType(HCQ2UI_Logic.ServiceUpReport.getTargetAppsByTypeRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="urn:getTargetAppsByType", ReplyAction="urn:getTargetAppsByTypeResponse")]
        System.Threading.Tasks.Task<HCQ2UI_Logic.ServiceUpReport.getTargetAppsByTypeResponse> getTargetAppsByTypeAsync(HCQ2UI_Logic.ServiceUpReport.getTargetAppsByTypeRequest request);
        
        // CODEGEN: 消息 getServiceUrlRequest 的包装命名空间(http://uddi.dareway.com)以后生成的消息协定与默认值(http://uddi_1_0.uddi.dwlesbserver.apps.dareway.com)不匹配
        [System.ServiceModel.OperationContractAttribute(Action="urn:getServiceUrl", ReplyAction="urn:getServiceUrlResponse")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        HCQ2UI_Logic.ServiceUpReport.getServiceUrlResponse getServiceUrl(HCQ2UI_Logic.ServiceUpReport.getServiceUrlRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="urn:getServiceUrl", ReplyAction="urn:getServiceUrlResponse")]
        System.Threading.Tasks.Task<HCQ2UI_Logic.ServiceUpReport.getServiceUrlResponse> getServiceUrlAsync(HCQ2UI_Logic.ServiceUpReport.getServiceUrlRequest request);
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
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface uddiPortTypeChannel : HCQ2UI_Logic.ServiceUpReport.uddiPortType, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class uddiPortTypeClient : System.ServiceModel.ClientBase<HCQ2UI_Logic.ServiceUpReport.uddiPortType>, HCQ2UI_Logic.ServiceUpReport.uddiPortType {
        
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
        HCQ2UI_Logic.ServiceUpReport.invokeServiceResponse HCQ2UI_Logic.ServiceUpReport.uddiPortType.invokeService(HCQ2UI_Logic.ServiceUpReport.invokeServiceRequest request) {
            return base.Channel.invokeService(request);
        }
        
        public string invokeService(string args0, string args1, string args2) {
            HCQ2UI_Logic.ServiceUpReport.invokeServiceRequest inValue = new HCQ2UI_Logic.ServiceUpReport.invokeServiceRequest();
            inValue.args0 = args0;
            inValue.args1 = args1;
            inValue.args2 = args2;
            HCQ2UI_Logic.ServiceUpReport.invokeServiceResponse retVal = ((HCQ2UI_Logic.ServiceUpReport.uddiPortType)(this)).invokeService(inValue);
            return retVal.@return;
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<HCQ2UI_Logic.ServiceUpReport.invokeServiceResponse> HCQ2UI_Logic.ServiceUpReport.uddiPortType.invokeServiceAsync(HCQ2UI_Logic.ServiceUpReport.invokeServiceRequest request) {
            return base.Channel.invokeServiceAsync(request);
        }
        
        public System.Threading.Tasks.Task<HCQ2UI_Logic.ServiceUpReport.invokeServiceResponse> invokeServiceAsync(string args0, string args1, string args2) {
            HCQ2UI_Logic.ServiceUpReport.invokeServiceRequest inValue = new HCQ2UI_Logic.ServiceUpReport.invokeServiceRequest();
            inValue.args0 = args0;
            inValue.args1 = args1;
            inValue.args2 = args2;
            return ((HCQ2UI_Logic.ServiceUpReport.uddiPortType)(this)).invokeServiceAsync(inValue);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        HCQ2UI_Logic.ServiceUpReport.serviceProxyResponse HCQ2UI_Logic.ServiceUpReport.uddiPortType.serviceProxy(HCQ2UI_Logic.ServiceUpReport.serviceProxyRequest request) {
            return base.Channel.serviceProxy(request);
        }
        
        public string serviceProxy(string args0, string args1, string args2, string args3, string args4) {
            HCQ2UI_Logic.ServiceUpReport.serviceProxyRequest inValue = new HCQ2UI_Logic.ServiceUpReport.serviceProxyRequest();
            inValue.args0 = args0;
            inValue.args1 = args1;
            inValue.args2 = args2;
            inValue.args3 = args3;
            inValue.args4 = args4;
            HCQ2UI_Logic.ServiceUpReport.serviceProxyResponse retVal = ((HCQ2UI_Logic.ServiceUpReport.uddiPortType)(this)).serviceProxy(inValue);
            return retVal.@return;
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<HCQ2UI_Logic.ServiceUpReport.serviceProxyResponse> HCQ2UI_Logic.ServiceUpReport.uddiPortType.serviceProxyAsync(HCQ2UI_Logic.ServiceUpReport.serviceProxyRequest request) {
            return base.Channel.serviceProxyAsync(request);
        }
        
        public System.Threading.Tasks.Task<HCQ2UI_Logic.ServiceUpReport.serviceProxyResponse> serviceProxyAsync(string args0, string args1, string args2, string args3, string args4) {
            HCQ2UI_Logic.ServiceUpReport.serviceProxyRequest inValue = new HCQ2UI_Logic.ServiceUpReport.serviceProxyRequest();
            inValue.args0 = args0;
            inValue.args1 = args1;
            inValue.args2 = args2;
            inValue.args3 = args3;
            inValue.args4 = args4;
            return ((HCQ2UI_Logic.ServiceUpReport.uddiPortType)(this)).serviceProxyAsync(inValue);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        HCQ2UI_Logic.ServiceUpReport.getTargetAppsByTypeResponse HCQ2UI_Logic.ServiceUpReport.uddiPortType.getTargetAppsByType(HCQ2UI_Logic.ServiceUpReport.getTargetAppsByTypeRequest request) {
            return base.Channel.getTargetAppsByType(request);
        }
        
        public string getTargetAppsByType(string args0) {
            HCQ2UI_Logic.ServiceUpReport.getTargetAppsByTypeRequest inValue = new HCQ2UI_Logic.ServiceUpReport.getTargetAppsByTypeRequest();
            inValue.args0 = args0;
            HCQ2UI_Logic.ServiceUpReport.getTargetAppsByTypeResponse retVal = ((HCQ2UI_Logic.ServiceUpReport.uddiPortType)(this)).getTargetAppsByType(inValue);
            return retVal.@return;
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<HCQ2UI_Logic.ServiceUpReport.getTargetAppsByTypeResponse> HCQ2UI_Logic.ServiceUpReport.uddiPortType.getTargetAppsByTypeAsync(HCQ2UI_Logic.ServiceUpReport.getTargetAppsByTypeRequest request) {
            return base.Channel.getTargetAppsByTypeAsync(request);
        }
        
        public System.Threading.Tasks.Task<HCQ2UI_Logic.ServiceUpReport.getTargetAppsByTypeResponse> getTargetAppsByTypeAsync(string args0) {
            HCQ2UI_Logic.ServiceUpReport.getTargetAppsByTypeRequest inValue = new HCQ2UI_Logic.ServiceUpReport.getTargetAppsByTypeRequest();
            inValue.args0 = args0;
            return ((HCQ2UI_Logic.ServiceUpReport.uddiPortType)(this)).getTargetAppsByTypeAsync(inValue);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        HCQ2UI_Logic.ServiceUpReport.getServiceUrlResponse HCQ2UI_Logic.ServiceUpReport.uddiPortType.getServiceUrl(HCQ2UI_Logic.ServiceUpReport.getServiceUrlRequest request) {
            return base.Channel.getServiceUrl(request);
        }
        
        public string getServiceUrl(string args0) {
            HCQ2UI_Logic.ServiceUpReport.getServiceUrlRequest inValue = new HCQ2UI_Logic.ServiceUpReport.getServiceUrlRequest();
            inValue.args0 = args0;
            HCQ2UI_Logic.ServiceUpReport.getServiceUrlResponse retVal = ((HCQ2UI_Logic.ServiceUpReport.uddiPortType)(this)).getServiceUrl(inValue);
            return retVal.@return;
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<HCQ2UI_Logic.ServiceUpReport.getServiceUrlResponse> HCQ2UI_Logic.ServiceUpReport.uddiPortType.getServiceUrlAsync(HCQ2UI_Logic.ServiceUpReport.getServiceUrlRequest request) {
            return base.Channel.getServiceUrlAsync(request);
        }
        
        public System.Threading.Tasks.Task<HCQ2UI_Logic.ServiceUpReport.getServiceUrlResponse> getServiceUrlAsync(string args0) {
            HCQ2UI_Logic.ServiceUpReport.getServiceUrlRequest inValue = new HCQ2UI_Logic.ServiceUpReport.getServiceUrlRequest();
            inValue.args0 = args0;
            return ((HCQ2UI_Logic.ServiceUpReport.uddiPortType)(this)).getServiceUrlAsync(inValue);
        }
    }
}
