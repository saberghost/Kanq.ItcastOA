using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            string nameStr = "";
            string basePath = Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory).Parent.Parent.Parent.FullName;
            string fullPath = Path.Combine(basePath, @"Kanq.ItcastOA.Model\bin\Debug\Kanq.ItcastOA.Model.dll");
            foreach (Type t in Assembly.LoadFile(fullPath).GetTypes())
            {
                if (t.Namespace != "Kanq.ItcastOA.Model" || t.BaseType.Name == "DbContext")
                {
                    continue;
                }
                nameStr += t.Name + ",";
            }
        }
    }
}
