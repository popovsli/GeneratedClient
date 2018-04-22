using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Messaging;
using System.ServiceModel;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Transactions;

namespace StockQuoteClientTcpBinding
{

    [ServiceContract]
    public interface IStockQuoteService
    {
        [OperationContract]
        double GetQuote(string symbol);
    }

    //One-way MSMQ
    [ServiceContract]
    public interface IStockQuoteRequest
    {
        [OperationContract(IsOneWay = true)]
        void SendQuoteRequest(string symbol);
    }

    //One-way MSMQ
    [ServiceContract]
    public interface IStockQuoteResponse
    {
        [OperationContract(IsOneWay = true)]
        void SendQuoteResponse(string symbol, double price);
    }

    public class StockQuoteResponse : IStockQuoteResponse
    {
        private static AutoResetEvent waitForResponse;

        public static void MsMqStarService()
        {
            MyServiceHost.StartService(new StockQuoteResponse());
            try
            {
                waitForResponse = new AutoResetEvent(false);
                using (ChannelFactory<IStockQuoteRequest> cf = new ChannelFactory<IStockQuoteRequest>("NetMsmqRequestClient"))
                {
                    IStockQuoteRequest client = cf.CreateChannel();

                    using (TransactionScope scope = new TransactionScope(TransactionScopeOption.Required))
                    {
                        client.SendQuoteRequest("MSFT");
                        scope.Complete();
                    }
                    cf.Close();
                }
                waitForResponse.WaitOne();
            }
            finally
            {
                MyServiceHost.StopService();
            }
        }


        public void SendQuoteResponse(string symbol, double price)
        {
            Console.WriteLine("MSMQ response : {0} price : {1}", symbol, price);
            waitForResponse.Set();
        }
    }

    internal class MyServiceHost
    {
        internal static string queueName = null;
        internal static ServiceHost myServiceHost = null;

        internal static void StartService<T>(T obj) where T : class
        {
            queueName = ConfigurationManager.AppSettings["queueName"];
            if (!MessageQueue.Exists(queueName))
            {
                MessageQueue.Create(queueName, true);
            }
            myServiceHost = new ServiceHost(obj.GetType());

             myServiceHost.Open();
        }

        internal static void StopService()
        {
            if (myServiceHost.State != CommunicationState.Closed)
            {
                myServiceHost.Close();
            }
        }
    }

    class Program : IStockQuoteDuplexServiceCallBack
    {
        private static AutoResetEvent waitForResponse;

        static void Main(string[] args)
        {
            
            ChannelFactory<IStockQuoteService> tcpChanelFactory = new ChannelFactory<IStockQuoteService>("tcpEndpoint");
            ChannelFactory<IStockQuoteService> pipeChanelFactory = new ChannelFactory<IStockQuoteService>("pipeEndpoint");
            ChannelFactory<IStockQuoteService> httpChanelFactory = new ChannelFactory<IStockQuoteService>("httpEndpoint");
            ChannelFactory<IStockQuoteService> wsHttpChanelFactory = new ChannelFactory<IStockQuoteService>("wsHttpEndpoint");
            ChannelFactory<IStockQuoteService> ws2007HttpChanelFactory = new ChannelFactory<IStockQuoteService>("ws2007HttpEndpoint");
            ChannelFactory<IStockQuoteService> cutomBindingChanelFactory = new ChannelFactory<IStockQuoteService>("customBinding");

            //Consuming Two one-way duplex service
            waitForResponse = new AutoResetEvent(false);
            InstanceContext callBackInstance = new InstanceContext(new Program());

            using (StockQuoteDuplexServiceClient client = new StockQuoteDuplexServiceClient(callBackInstance))
            {
                client.SendQuoteRequest("MSFT");
                waitForResponse.WaitOne();
            }
            //

            IStockQuoteService tcpClient = tcpChanelFactory.CreateChannel();
            IStockQuoteService pipeClient = pipeChanelFactory.CreateChannel();
            IStockQuoteService httpClient = httpChanelFactory.CreateChannel();
            IStockQuoteService wsHttpClient = wsHttpChanelFactory.CreateChannel();
            IStockQuoteService ws2007HttpClient = ws2007HttpChanelFactory.CreateChannel();
            IStockQuoteService customBindingHttpClient = cutomBindingChanelFactory.CreateChannel();
            

            Console.WriteLine("TCP client : {0}", tcpClient.GetQuote("YHOO"));
            Console.WriteLine("Pipe client : {0}", pipeClient.GetQuote("YHOO"));
            Console.WriteLine("HTTP client : {0}", httpClient.GetQuote("YHOO"));
            Console.WriteLine("WS HTTP client : {0}", wsHttpClient.GetQuote("YHOO"));
            Console.WriteLine("WS2007 HTTP client : {0}", ws2007HttpClient.GetQuote("YHOO"));
            Console.WriteLine("Custom Binding TCP client : {0}", customBindingHttpClient.GetQuote("YHOO"));
            StockQuoteResponse.MsMqStarService();


            Console.ReadLine();

        }

        //DuplexCallBackMethod
        public void SendQuoteResponse(string symbol, double price)
        {
            Console.WriteLine("{0} @ ${1}", symbol, price);
            waitForResponse.Set();
        }
    }
}
