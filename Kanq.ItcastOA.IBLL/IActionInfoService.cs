using Kanq.ItcastOA.Model;
using Kanq.ItcastOA.Model.Search;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kanq.ItcastOA.IBLL
{
    public partial interface IActionInfoService : IBaseService<ActionInfo>
    {
        bool DeleteEntitys(List<int> list);

        IQueryable<ActionInfo> LoadSerachEntities(ActionInfoSearch actionInfoSearch, short delFlag);

        bool setRole(int actionId, List<int> roleIds);
    }
}
