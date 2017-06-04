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
        public IActionInfoDal ActionInfoDal { get; set; } = SpringNetHelper.GetObject<IActionInfoDal>("ActionInfoDal");
        public IBooksDal BooksDal { get; set; } = SpringNetHelper.GetObject<IBooksDal>("BooksDal");
        public IDepartmentDal DepartmentDal { get; set; } = SpringNetHelper.GetObject<IDepartmentDal>("DepartmentDal");
        public IKeyWordsRankDal KeyWordsRankDal { get; set; } = SpringNetHelper.GetObject<IKeyWordsRankDal>("KeyWordsRankDal");
        public IRoleInfoDal RoleInfoDal { get; set; } = SpringNetHelper.GetObject<IRoleInfoDal>("RoleInfoDal");
        public IR_UserInfo_ActionInfoDal R_UserInfo_ActionInfoDal { get; set; } = SpringNetHelper.GetObject<IR_UserInfo_ActionInfoDal>("R_UserInfo_ActionInfoDal");
        public ISearchDetailsDal SearchDetailsDal { get; set; } = SpringNetHelper.GetObject<ISearchDetailsDal>("SearchDetailsDal");
        public IUserInfoDal UserInfoDal { get; set; } = SpringNetHelper.GetObject<IUserInfoDal>("UserInfoDal");
    }
}