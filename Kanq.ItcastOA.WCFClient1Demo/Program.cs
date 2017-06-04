using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kanq.ItcastOA.WCFClient1Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            CalculateServiceClient client = new CalculateServiceClient();
            int sum = client.Add(3, 4);
            Console.WriteLine(sum);
            client.Close();
            Console.ReadKey();
        }
    }
}
