using Kanq.ItcastOA.IBLL;
using Kanq.ItcastOA.Model;
using Kanq.ItcastOA.Model.Search;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kanq.ItcastOA.BLL
{
    public partial class RoleInfoService : BaseService<RoleInfo>, IRoleInfoService
    {
        public bool DeleteEntitys(List<int> list)
        {
            var roleInfoList = CurrentDal.LoadEntities(u => list.Contains(u.ID));
            foreach (var roleInfo in roleInfoList)
            {
                CurrentDal.DeleteEntity(roleInfo);
            }
            return CurrentDBSession.SaveChanges();
        }

        public IQueryable<RoleInfo> LoadSerachEntities(RoleInfoSearch roleInfoSearch, short delFlag)
        {
            var temp = CurrentDal.LoadEntities(u => u.DelFlag == delFlag);
            if (!string.IsNullOrEmpty(roleInfoSearch.RoleName))
            {
                temp = temp.Where(u => u.RoleName.Contains(roleInfoSearch.RoleName));
            }
            if (!string.IsNullOrEmpty(roleInfoSearch.Remark))
            {
                temp = temp.Where(u => u.Remark.Contains(roleInfoSearch.Remark));
            }
            roleInfoSearch.TotalCount = temp.Count();
            return temp.OrderBy(u => u.ID).Skip((roleInfoSearch.PageIndex - 1) * roleInfoSearch.PageSize).Take(roleInfoSearch.PageSize);
        }
    }
}
