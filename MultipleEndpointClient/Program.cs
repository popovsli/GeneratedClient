using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MultipleEndpointClient.MultipleEndpointClientWCF;

namespace MultipleEndpointClient
{
    class Program
    {
        static void Main(string[] args)
        {

            using (GreatStockServiceClient proxy = new GreatStockServiceClient("BetterStockService"))
            {
                Console.WriteLine(proxy.GetStockPriceFast("MSFT"));
            }

            using (GreatStockServiceClient proxy = new GreatStockServiceClient("BestStockService"))
            {
                 Console.WriteLine(proxy.GetStockPriceFast("MSFT"));
            }
        }
    }
}
