using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kanq.ItcastOA.WCFClient2Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            ServiceReference1.CalculateServiceClient client = new ServiceReference1.CalculateServiceClient();
            int sum = client.Add(3, 4);
            Console.WriteLine(sum);
            client.Close();
            Console.ReadKey();
        }
    }
}
