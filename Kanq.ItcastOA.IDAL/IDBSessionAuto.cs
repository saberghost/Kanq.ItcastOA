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
        IActionInfoDal ActionInfoDal { get; set; }
        IBooksDal BooksDal { get; set; }
        IDepartmentDal DepartmentDal { get; set; }
        IKeyWordsRankDal KeyWordsRankDal { get; set; }
        IRoleInfoDal RoleInfoDal { get; set; }
        IR_UserInfo_ActionInfoDal R_UserInfo_ActionInfoDal { get; set; }
        ISearchDetailsDal SearchDetailsDal { get; set; }
        IUserInfoDal UserInfoDal { get; set; }
    }
}