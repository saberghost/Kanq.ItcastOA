using Kanq.ItcastOA.DAL;
using Kanq.ItcastOA.IDAL;
using Kanq.ItcastOA.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kanq.ItcastOA.DALFactory
{
    public partial class DBSession : IDBSession
    {

        //private IUserInfoDal _userInfoDAl;

        //public IUserInfoDal UserInfoDal
        //{
        //    get
        //    {
        //        if (_userInfoDAl == null)
        //        {
        //            _userInfoDAl = AbstractFactory.CreateUserInfoDal();
        //        }
        //        return _userInfoDAl;
        //    }
        //    set
        //    {
        //        _userInfoDAl = value;
        //    }
        //}

        public DbContext db
        {
            get
            {
                return DbContextFactory.CreateDbContext();
            }
        }

        public bool SaveChanges()
        {
            return db.SaveChanges() > 0;
        }
    }
}
