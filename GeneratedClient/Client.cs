
using System;
using System.Collections.Generic;
using System.Linq;

using System.Text;
using System.Threading.Tasks;

namespace GeneratedClient
{
    class Client
    {
        static void Main(string[] args)
        {
            StockServiceClient.StockServiceClient proxy = new StockServiceClient.StockServiceClient();
         

            
            double dds = proxy.GetDDS(100);
            double priceWithDDS = proxy.GetPriceWithDDS(100);
            Console.WriteLine("DDS is:{0} , and Price with DDS is :{1}", dds, priceWithDDS);
            var res = proxy.GetStockPrice("MSFT");

            StockServiceSOAP.StockServiceClient proxySOAP = new StockServiceSOAP.StockServiceClient();
            var result = proxySOAP.GetStockPriceSOAP(new StockServiceSOAP.StockPriceReq() { Ticker = "ASD" });
            Console.ReadLine();
            proxy.Close();

        }
    }
}
