using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Text;
using System.Threading.Tasks;

namespace StockQuoteClientTcpBinding
{
    [GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [ServiceContractAttribute(ConfigurationName = "IStockQuoteDuplexService",
        CallbackContract = typeof(IStockQuoteDuplexServiceCallBack),
        SessionMode = SessionMode.Required)]
    public interface IStockQuoteDuplexService
    {
        [OperationContractAttribute(IsOneWay = true,
            Action = "http://tempuri.org/IStockQuoteDuplexService/SendQuoteRequest")]
        void SendQuoteRequest(string symbol);
    }

    [GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IStockQuoteDuplexServiceCallBack
    {
        [OperationContractAttribute(IsOneWay = true,
            Action = "http://tempuri.org/IStockQuoteDuplexService/SendQuoteResponse")]
        void SendQuoteResponse(string symbol, double price);
    }

    [GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IStockQuoteDuplexServiceChanel : IStockQuoteDuplexService, IClientChannel
    {

    }

    [DebuggerStepThroughAttribute()]
    [GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class StockQuoteDuplexServiceClient : DuplexClientBase<IStockQuoteDuplexService>,
                                                         IStockQuoteDuplexService
    {

        public StockQuoteDuplexServiceClient(InstanceContext callbackInstance)
            : base(callbackInstance)
        {

        }

        public StockQuoteDuplexServiceClient(InstanceContext callbackInstance, string endpointConfigurationName)
            : base(callbackInstance, endpointConfigurationName)
        {

        }

        public StockQuoteDuplexServiceClient(InstanceContext callbackInstance, string endpointConfigurationName ,string remoteAddress)
            : base(callbackInstance, endpointConfigurationName,remoteAddress)
        {

        }

        public StockQuoteDuplexServiceClient(InstanceContext callbackInstance, string endpointConfigurationName, EndpointAddress remoteAddress)
            : base(callbackInstance, endpointConfigurationName, remoteAddress)
        {

        }

        public StockQuoteDuplexServiceClient(InstanceContext callbackInstance, Binding binding, EndpointAddress remoteAddress)
            : base(callbackInstance, binding, remoteAddress)
        {

        }

        public void SendQuoteRequest(string symbol)
        {
            base.Channel.SendQuoteRequest(symbol);
        }
    }

}
