using Kanq.ItcastOA.Model;
using Kanq.ItcastOA.Model.Search;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kanq.ItcastOA.IBLL
{
    public partial interface IRoleInfoService : IBaseService<RoleInfo>
    {
        bool DeleteEntitys(List<int> list);

        IQueryable<RoleInfo> LoadSerachEntities(RoleInfoSearch roleInfoSearch, short delFlag);
    }
}
