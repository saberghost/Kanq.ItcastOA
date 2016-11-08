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
    public interface IDBSession
    {
        DbContext db { get; }
        IUserInfoDal UserInfoDal { get; set; }
        bool SaveChanges();
    }
}
