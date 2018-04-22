using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RefClient.Client;
using System.Security.Cryptography.X509Certificates;
using System.ServiceModel;

namespace RefClient
{
    class Program
    {
        static void Main(string[] args)
        {
            RefServiceClient proxy = new RefServiceClient("WSHttpBinding_IRefService");
            //X509Certificate2 certificate = new X509Certificate2(@"C:\Users\nrpopov\Desktop\Cert\MyClientCert.pfx");
            //proxy.ClientCredentials.ClientCertificate.Certificate = certificate;

            //Console.Write("Username:");
            //proxy.ClientCredentials.UserName.UserName = Console.ReadLine();
            //Console.Write("Password:");
            //proxy.ClientCredentials.UserName.Password = Console.ReadLine();

            var res = proxy.matchByName(new matchByName() { name = "This is just a request!" });
            
            Console.WriteLine("Name is : {0}", res.name);
            try
            {
                var res2 = proxy.matchByName(new matchByName() { name = "Nikolai" });
            }
            catch (FaultException exp)
            {
                Console.WriteLine("Exception code name : {0} , message : {1} , type : {2}",
                     exp.Code.Name, exp.Message.ToString(), exp.GetType().ToString());
            }

            Console.ReadLine();


        }
    }
}
