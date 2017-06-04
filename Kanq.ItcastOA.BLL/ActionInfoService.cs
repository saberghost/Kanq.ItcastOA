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
    public partial class ActionInfoService : BaseService<ActionInfo>, IActionInfoService
    {
        public bool DeleteEntitys(List<int> list)
        {
            var actionInfoList = CurrentDal.LoadEntities(u => list.Contains(u.ID));
            foreach (var actionInfo in actionInfoList)
            {
                CurrentDal.DeleteEntity(actionInfo);
            }
            return CurrentDBSession.SaveChanges();
        }

        public IQueryable<ActionInfo> LoadSerachEntities(ActionInfoSearch actionInfoSearch, short delFlag)
        {
            var temp = CurrentDal.LoadEntities(u => u.DelFlag == delFlag);
            if (!string.IsNullOrEmpty(actionInfoSearch.ActionInfoName))
            {
                temp = temp.Where(u => u.ActionInfoName.Contains(actionInfoSearch.ActionInfoName));
            }
            if (!string.IsNullOrEmpty(actionInfoSearch.Url))
            {
                temp = temp.Where(u => u.Remark.Contains(actionInfoSearch.Url));
            }
            actionInfoSearch.TotalCount = temp.Count();
            return temp.OrderBy(u => u.ID).Skip((actionInfoSearch.PageIndex - 1) * actionInfoSearch.PageSize).Take(actionInfoSearch.PageSize);
        }

        public bool setRole(int actionId, List<int> roleIds)
        {
            var actionInfo = CurrentDal.LoadEntities(t => t.ID == actionId).FirstOrDefault();
            actionInfo.RoleInfo.Clear();
            var roleInfos = CurrentDBSession.RoleInfoDal.LoadEntities(t => roleIds.Contains(t.ID));
            foreach (var roleInfo in roleInfos)
            {
                actionInfo.RoleInfo.Add(roleInfo);
            }
            return CurrentDBSession.SaveChanges();
        }
    }
}
