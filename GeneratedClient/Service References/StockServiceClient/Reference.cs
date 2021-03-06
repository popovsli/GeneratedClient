﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.34014
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace GeneratedClient.StockServiceClient {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Price", Namespace="http://EssentialWCF")]
    [System.SerializableAttribute()]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(GeneratedClient.StockServiceClient.StockPrice))]
    public partial class Price : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
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
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="StockPrice", Namespace="http://EssentialWCF")]
    [System.SerializableAttribute()]
    public partial class StockPrice : GeneratedClient.StockServiceClient.Price {
        
        private double CurrentPriceField;
        
        private System.DateTime CurrentTimeField;
        
        private string TickerField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private long DailyVolumeField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private double DaylyChangeField;
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true)]
        public double CurrentPrice {
            get {
                return this.CurrentPriceField;
            }
            set {
                if ((this.CurrentPriceField.Equals(value) != true)) {
                    this.CurrentPriceField = value;
                    this.RaisePropertyChanged("CurrentPrice");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true)]
        public System.DateTime CurrentTime {
            get {
                return this.CurrentTimeField;
            }
            set {
                if ((this.CurrentTimeField.Equals(value) != true)) {
                    this.CurrentTimeField = value;
                    this.RaisePropertyChanged("CurrentTime");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true)]
        public string Ticker {
            get {
                return this.TickerField;
            }
            set {
                if ((object.ReferenceEquals(this.TickerField, value) != true)) {
                    this.TickerField = value;
                    this.RaisePropertyChanged("Ticker");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=3)]
        public long DailyVolume {
            get {
                return this.DailyVolumeField;
            }
            set {
                if ((this.DailyVolumeField.Equals(value) != true)) {
                    this.DailyVolumeField = value;
                    this.RaisePropertyChanged("DailyVolume");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=4)]
        public double DaylyChange {
            get {
                return this.DaylyChangeField;
            }
            set {
                if ((this.DaylyChangeField.Equals(value) != true)) {
                    this.DaylyChangeField = value;
                    this.RaisePropertyChanged("DaylyChange");
                }
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="StockServiceClient.IStockService")]
    public interface IStockService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IStockService/GetDDS", ReplyAction="http://tempuri.org/IStockService/GetDDSResponse")]
        double GetDDS(double price);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IStockService/GetDDS", ReplyAction="http://tempuri.org/IStockService/GetDDSResponse")]
        System.Threading.Tasks.Task<double> GetDDSAsync(double price);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IStockService/GetPriceWithDDS", ReplyAction="http://tempuri.org/IStockService/GetPriceWithDDSResponse")]
        double GetPriceWithDDS(double price);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IStockService/GetPriceWithDDS", ReplyAction="http://tempuri.org/IStockService/GetPriceWithDDSResponse")]
        System.Threading.Tasks.Task<double> GetPriceWithDDSAsync(double price);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IStockService/OneWay")]
        void OneWay();
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IStockService/OneWay")]
        System.Threading.Tasks.Task OneWayAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IStockService/NotOneWay", ReplyAction="http://tempuri.org/IStockService/NotOneWayResponse")]
        void NotOneWay();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IStockService/NotOneWay", ReplyAction="http://tempuri.org/IStockService/NotOneWayResponse")]
        System.Threading.Tasks.Task NotOneWayAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IStockService/GetStockPrice", ReplyAction="http://tempuri.org/IStockService/GetStockPriceResponse")]
        GeneratedClient.StockServiceClient.Price GetStockPrice(string ticker);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IStockService/GetStockPrice", ReplyAction="http://tempuri.org/IStockService/GetStockPriceResponse")]
        System.Threading.Tasks.Task<GeneratedClient.StockServiceClient.Price> GetStockPriceAsync(string ticker);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IStockServiceChannel : GeneratedClient.StockServiceClient.IStockService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class StockServiceClient : System.ServiceModel.ClientBase<GeneratedClient.StockServiceClient.IStockService>, GeneratedClient.StockServiceClient.IStockService {
        
        public StockServiceClient() {
        }
        
        public StockServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public StockServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public StockServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public StockServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public double GetDDS(double price) {
            return base.Channel.GetDDS(price);
        }
        
        public System.Threading.Tasks.Task<double> GetDDSAsync(double price) {
            return base.Channel.GetDDSAsync(price);
        }
        
        public double GetPriceWithDDS(double price) {
            return base.Channel.GetPriceWithDDS(price);
        }
        
        public System.Threading.Tasks.Task<double> GetPriceWithDDSAsync(double price) {
            return base.Channel.GetPriceWithDDSAsync(price);
        }
        
        public void OneWay() {
            base.Channel.OneWay();
        }
        
        public System.Threading.Tasks.Task OneWayAsync() {
            return base.Channel.OneWayAsync();
        }
        
        public void NotOneWay() {
            base.Channel.NotOneWay();
        }
        
        public System.Threading.Tasks.Task NotOneWayAsync() {
            return base.Channel.NotOneWayAsync();
        }
        
        public GeneratedClient.StockServiceClient.Price GetStockPrice(string ticker) {
            return base.Channel.GetStockPrice(ticker);
        }
        
        public System.Threading.Tasks.Task<GeneratedClient.StockServiceClient.Price> GetStockPriceAsync(string ticker) {
            return base.Channel.GetStockPriceAsync(ticker);
        }
    }
}
