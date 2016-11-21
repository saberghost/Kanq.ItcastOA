using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Web.Configuration;

namespace Kanq.ItcastOA.IDAL
{
    public partial interface IDBSession
    {
        DbContext db { get; }
        bool SaveChanges();
    }
}
