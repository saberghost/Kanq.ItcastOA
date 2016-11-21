using Kanq.ItcastOA.IBLL;
using Kanq.ItcastOA.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kanq.ItcastOA.Model.Search;

namespace Kanq.ItcastOA.BLL
{
    public partial class ActionInfoService : BaseService<ActionInfo>, IActionInfoService
    {
        public override void SetCurrentDal()
        {
            CurrentDal = CurrentDBSession.ActionInfoDal;
        }
    }

    public partial class BooksService : BaseService<Books>, IBooksService
    {
        public override void SetCurrentDal()
        {
            CurrentDal = CurrentDBSession.BooksDal;
        }
    }

    public partial class DepartmentService : BaseService<Department>, IDepartmentService
    {
        public override void SetCurrentDal()
        {
            CurrentDal = CurrentDBSession.DepartmentDal;
        }
    }

    public partial class KeyWordsRankService : BaseService<KeyWordsRank>, IKeyWordsRankService
    {
        public override void SetCurrentDal()
        {
            CurrentDal = CurrentDBSession.KeyWordsRankDal;
        }
    }

    public partial class RoleInfoService : BaseService<RoleInfo>, IRoleInfoService
    {
        public override void SetCurrentDal()
        {
            CurrentDal = CurrentDBSession.RoleInfoDal;
        }
    }

    public partial class R_UserInfo_ActionInfoService : BaseService<R_UserInfo_ActionInfo>, IR_UserInfo_ActionInfoService
    {
        public override void SetCurrentDal()
        {
            CurrentDal = CurrentDBSession.R_UserInfo_ActionInfoDal;
        }
    }

    public partial class SearchDetailsService : BaseService<SearchDetails>, ISearchDetailsService
    {
        public override void SetCurrentDal()
        {
            CurrentDal = CurrentDBSession.SearchDetailsDal;
        }
    }

    public partial class UserInfoService : BaseService<UserInfo>, IUserInfoService
    {
        public override void SetCurrentDal()
        {
            CurrentDal = CurrentDBSession.UserInfoDal;
        }
    }

}