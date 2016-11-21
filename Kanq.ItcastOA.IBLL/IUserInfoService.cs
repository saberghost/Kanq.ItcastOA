using Kanq.ItcastOA.Model;
using Kanq.ItcastOA.Model.Search;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kanq.ItcastOA.IBLL
{
    public partial interface IUserInfoService:IBaseService<UserInfo>
    {
        bool DeleteEntitys(List<int> list);

        IQueryable<UserInfo> LoadSerachEntities(UserInfoSearch userInfoSearch, short delFlag);
    }
}
