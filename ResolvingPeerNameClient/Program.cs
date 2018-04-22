using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.PeerToPeer;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using ResolvingPeerNameClient.Client;

namespace ResolvingPeerNameClient
{

    class Program
    {
        static void Main(string[] args)
        {
            PeerNameResolver resolver = new PeerNameResolver();
            PeerName peerName = new PeerName("0.peerchat");

            PeerNameRecordCollection result = resolver.Resolve(peerName);

            PeerNameRecord record;

            for (int i = 0; i < result.Count; i++)
            {
                record = result[i];
                Console.WriteLine("record #{0}", i);
                if (!string.IsNullOrEmpty(record.PeerName.PeerHostName))
                    Console.WriteLine("Peer name is :{0}", record.PeerName.PeerHostName);

                if (record.Comment != null)
                    Console.WriteLine(record.Comment);

                Console.Write("Data: ");
                if (record.Data != null)
                    Console.WriteLine(Encoding.ASCII.GetString(record.Data));
                else
                    Console.WriteLine();
                Console.WriteLine("Endpoints:");
                foreach (IPEndPoint endPoint in record.EndPointCollection)
                {
                    Console.WriteLine("Endpoint:{0}", endPoint);
                }

               // Uri uri = new Uri(string.Format("net.peer://{0}/GetName/", record.PeerName));

               // ChannelFactory<IPeerNetwork> myChanelFactory = new ChannelFactory<IPeerNetwork>(
               //new NetPeerTcpBinding(), new EndpointAddress("net.peer://peerchat/GetName"));

               // IPeerNetwork peer = myChanelFactory.CreateChannel();

               // peer.GetName();

               

                //Console.WriteLine();
            }

            //ChannelFactory<IPeerNetwork> myChanelFactory = new ChannelFactory<IPeerNetwork>("peerToPeer");


            PeerNetworkClient proxy = new PeerNetworkClient();
            proxy.GetName();



            Console.ReadLine();
            Console.WriteLine("Hit [Enter] to exit.");

        }
    }
}
