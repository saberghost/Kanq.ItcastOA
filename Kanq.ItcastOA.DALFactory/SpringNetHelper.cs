using Spring.Context;
using Spring.Context.Support;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kanq.ItcastOA.DALFactory
{
    public class SpringNetHelper
    {
        public static T GetObject<T>(string name)
        {
            IApplicationContext ctx = ContextRegistry.GetContext();
            return ctx.GetObject<T>(name);
        }
    }
}
