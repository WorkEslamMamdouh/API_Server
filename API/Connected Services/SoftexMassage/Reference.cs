﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Inv.API.SoftexMassage {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(Namespace="http://smsws.softexsw.info/ClientServices/", ConfigurationName="SoftexMassage.MiniClientSoap")]
    public interface MiniClientSoap {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://smsws.softexsw.info/ClientServices/GetBalance", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        decimal GetBalance(string SecStr, string Email, string Password);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://smsws.softexsw.info/ClientServices/GetBalance", ReplyAction="*")]
        System.Threading.Tasks.Task<decimal> GetBalanceAsync(string SecStr, string Email, string Password);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://smsws.softexsw.info/ClientServices/SendInstantMsg", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        Inv.API.SoftexMassage.EnumMiniClientStatus SendInstantMsg(string SecStr, string Email, string Password, string Msg, string[] PhoneNumbers, bool IsUniCode);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://smsws.softexsw.info/ClientServices/SendInstantMsg", ReplyAction="*")]
        System.Threading.Tasks.Task<Inv.API.SoftexMassage.EnumMiniClientStatus> SendInstantMsgAsync(string SecStr, string Email, string Password, string Msg, string[] PhoneNumbers, bool IsUniCode);
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://smsws.softexsw.info/ClientServices/")]
    public enum EnumMiniClientStatus {
        
        /// <remarks/>
        Error_,
        
        /// <remarks/>
        Success,
        
        /// <remarks/>
        LoginFail,
        
        /// <remarks/>
        MsgNeedRevision,
        
        /// <remarks/>
        NoCredit,
        
        /// <remarks/>
        NoSuccessPhones,
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface MiniClientSoapChannel : Inv.API.SoftexMassage.MiniClientSoap, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class MiniClientSoapClient : System.ServiceModel.ClientBase<Inv.API.SoftexMassage.MiniClientSoap>, Inv.API.SoftexMassage.MiniClientSoap {
        
        public MiniClientSoapClient() {
        }
        
        public MiniClientSoapClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public MiniClientSoapClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public MiniClientSoapClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public MiniClientSoapClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public decimal GetBalance(string SecStr, string Email, string Password) {
            return base.Channel.GetBalance(SecStr, Email, Password);
        }
        
        public System.Threading.Tasks.Task<decimal> GetBalanceAsync(string SecStr, string Email, string Password) {
            return base.Channel.GetBalanceAsync(SecStr, Email, Password);
        }
        
        public Inv.API.SoftexMassage.EnumMiniClientStatus SendInstantMsg(string SecStr, string Email, string Password, string Msg, string[] PhoneNumbers, bool IsUniCode) {
            return base.Channel.SendInstantMsg(SecStr, Email, Password, Msg, PhoneNumbers, IsUniCode);
        }
        
        public System.Threading.Tasks.Task<Inv.API.SoftexMassage.EnumMiniClientStatus> SendInstantMsgAsync(string SecStr, string Email, string Password, string Msg, string[] PhoneNumbers, bool IsUniCode) {
            return base.Channel.SendInstantMsgAsync(SecStr, Email, Password, Msg, PhoneNumbers, IsUniCode);
        }
    }
}
