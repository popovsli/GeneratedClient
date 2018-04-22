using DuplexClient.WCFDuplex;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace DuplexClient
{

    public class CallBackHandler : IServerStockCallback
    {
        static InstanceContext site = new InstanceContext(new CallBackHandler());
        static ServerStockClient proxy = new ServerStockClient(site);

        public void PriceUpdate(string ticker, double price)
        {
            Console.WriteLine("Received alert at : {0}. {1}:{2}", System.DateTime.Now, ticker, price);
        }

        class Program
        {
            static void Main(string[] args)
            {
                proxy.RegisterForUpdate("MSFT");
         
                Console.ReadLine();
            }
        }
    }
    
}
