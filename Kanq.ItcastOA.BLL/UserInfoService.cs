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
    public partial class UserInfoService : BaseService<UserInfo>, IUserInfoService
    {
        public bool DeleteEntitys(List<int> list)
        {
            var userInfoList = CurrentDal.LoadEntities(u => list.Contains(u.ID));
            foreach (var userInfo in userInfoList)
            {
                CurrentDal.DeleteEntity(userInfo);
            }
            return CurrentDBSession.SaveChanges();
        }

        public IQueryable<UserInfo> LoadSerachEntities(UserInfoSearch userInfoSearch, short delFlag)
        {
            var temp = CurrentDal.LoadEntities(u => u.DelFlag == delFlag);
            if (!string.IsNullOrEmpty(userInfoSearch.UName))
            {
                temp = temp.Where(u => u.UName.Contains(userInfoSearch.UName));
            }
            if (!string.IsNullOrEmpty(userInfoSearch.Remark))
            {
                temp = temp.Where(u => u.Remark.Contains(userInfoSearch.Remark));
            }
            userInfoSearch.TotalCount = temp.Count();
            return temp.OrderBy(u => u.ID).Skip((userInfoSearch.PageIndex - 1) * userInfoSearch.PageSize).Take(userInfoSearch.PageSize);
        }

        public bool setRole(int userId, List<int> roleIds)
        {
            var userInfo = CurrentDal.LoadEntities(t => t.ID == userId).FirstOrDefault();
            userInfo.RoleInfo.Clear();
            var roleInfos = CurrentDBSession.RoleInfoDal.LoadEntities(t => roleIds.Contains(t.ID));
            foreach (var roleInfo in roleInfos)
            {
                userInfo.RoleInfo.Add(roleInfo);
            }
            return CurrentDBSession.SaveChanges();
        }
    }
}
