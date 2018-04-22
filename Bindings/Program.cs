using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Text;
using System.Threading.Tasks;

namespace Bindings
{
    class Program
    {
        static void Main(string[] args)
        {

            OutputBindingElements(new WSHttpBinding());
            OutputBindingElements(new NetTcpBinding());
            OutputBindingElements(new NetNamedPipeBinding());
            OutputBindingElements(new BasicHttpBinding());
            Console.ReadLine();
        }

        private static void OutputBindingElements(Binding binding)
        {
            Console.WriteLine("Binding : {0}", binding.GetType().Name);

            BindingElementCollection elements = binding.CreateBindingElements();
            foreach (BindingElement element in elements)
            {
                Console.WriteLine(" {0},", element.GetType().FullName);
            }
            Console.WriteLine();
        }


    }
}
