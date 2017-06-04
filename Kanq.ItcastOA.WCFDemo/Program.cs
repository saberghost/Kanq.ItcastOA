using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Kanq.ItcastOA.WCFDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            using(ServiceHost host=new ServiceHost(typeof(CalculateService)))
            {
                host.Open();
                Console.ReadKey();
            }
        }
    }
}
