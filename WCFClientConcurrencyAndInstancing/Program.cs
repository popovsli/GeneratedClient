using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WCFClientConcurrencyAndInstancing.StockServiceClientProxy;
using System.Threading.Tasks;
using System.Threading;

namespace WCFClientConcurrencyAndInstancing
{
    class Program
    {
        static int c = 0;
        static void Main(string[] args)
        {
           
            //for (int i = 0; i < 3; i++)
            //{
            //    Console.WriteLine("{0}: Calling GetPrice", System.DateTime.Now);
            //    proxy.BeginGetPrice("MSFT", GetPriceCallBack, proxy);
            //    Thread.Sleep(500);
            //    Interlocked.Increment(ref c);
            //}

            //TaskScheduler scheduler = TaskScheduler.FromCurrentSynchronizationContext();
            StockServiceClient proxy = new StockServiceClient("WSHttpBinding_IStockService");
            while (Console.ReadLine() == "")
            {
                var task = Task.Factory.StartNew(() =>
                {
                    //Invoke Service
                    
                    Console.WriteLine("{0}: Calling GetPrice", System.DateTime.Now);
                    StockPrice res = proxy.GetPrice("test");

                    return res;

                }).ContinueWith(i =>
                {
                    if (i.Exception != null)
                    {
                        //this.Dispatcher.BeginInvoke(new Action(() =>
                        // {

                        // }),null);
                    }
                    else
                    {
                        // this.Dispatcher.BeginInvoke(new Action(() =>
                        // {
                        Console.WriteLine("Result in : {0}, Price:{1},calls : {2}", System.DateTime.Now, i.Result.price, i.Result.calls);
                        Console.ReadLine();
                        // }),null);
                    }
                }/*scheduler*/);
            }
            Console.ReadLine();

            //while (true)
            //{
            //    Console.WriteLine("{0}: Calling GetPrice", System.DateTime.Now);
            //    StockPrice res = proxy.GetPrice("test");
            //    //proxy.BeginGetPrice("MSFT", GetPriceCallBack, proxy);
            //    Console.WriteLine("Result in : {0}, Price:{1},calls : {2}", System.DateTime.Now,res.price,res.calls);
            //    Console.ReadLine();
            //}

            //Console.ReadLine();
        }

        static void GetPriceCallBack(IAsyncResult ar)
        {
            StockPrice price = ((StockServiceClient)ar.AsyncState).EndGetPrice(ar);
            Console.WriteLine("{0}:Price:{1}", System.DateTime.Now, price.price);
            ((StockServiceClient)ar.AsyncState).Close();
            Interlocked.Decrement(ref c);

        }
    }
}
