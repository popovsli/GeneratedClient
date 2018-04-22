using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test.Client;
namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            Client.SyncDataServiceClient proxy = new SyncDataServiceClient("CustomEndPoint");
            var res = proxy.GetAllPersons().ToList();
        }
    }
}
