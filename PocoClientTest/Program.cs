using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PocoClientTest.PocoClient;
using System.ServiceModel;

namespace PocoClientTest
{
    class Program
    {
        static void Main(string[] args)
        {
            CalculatorServiceClient proxy = new CalculatorServiceClient(new BasicHttpBinding(), new EndpointAddress("http://localhost:8000/PocoServiceHost/CalculatorService"));
            int res = proxy.Divide(10, 5);
            Console.WriteLine(res);
            Console.ReadLine();
        }
    }
}
