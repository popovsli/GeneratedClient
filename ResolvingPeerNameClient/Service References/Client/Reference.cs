﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.34014
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ResolvingPeerNameClient.Client {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="Client.IPeerNetwork")]
    public interface IPeerNetwork {
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IPeerNetwork/GetName")]
        void GetName();
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IPeerNetwork/GetName")]
        System.Threading.Tasks.Task GetNameAsync();
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IPeerNetworkChannel : ResolvingPeerNameClient.Client.IPeerNetwork, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class PeerNetworkClient : System.ServiceModel.ClientBase<ResolvingPeerNameClient.Client.IPeerNetwork>, ResolvingPeerNameClient.Client.IPeerNetwork {
        
        public PeerNetworkClient() {
        }
        
        public PeerNetworkClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public PeerNetworkClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public PeerNetworkClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public PeerNetworkClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public void GetName() {
            base.Channel.GetName();
        }
        
        public System.Threading.Tasks.Task GetNameAsync() {
            return base.Channel.GetNameAsync();
        }
    }
}
