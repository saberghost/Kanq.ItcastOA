using Kanq.ItcastOA.Common;
using Kanq.ItcastOA.IBLL;
using Kanq.ItcastOA.Model;
using Kanq.ItcastOA.Model.Search;
using Kanq.ItcastOA.WebApp.Models.EnumType;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Kanq.ItcastOA.WebApp.Controllers
{
    public class RoleInfoController : Controller
    {

        public IRoleInfoService RoleInfoService { get; set; }
        // GET: RoleInfo
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetRoleInfoList(int page, int rows, string RoleName, string Remark)
        {
            //int totalCount = 0;
            short delFlag = (short)DeleteEnumType.Normal;
            RoleInfoSearch roleInfoSearch = new RoleInfoSearch()
            {
                PageIndex = page,
                PageSize = rows,
                RoleName = RoleName,
                Remark = Remark,
                //TotalCount = totalCount
            };
            var RoleInfoList = RoleInfoService.LoadSerachEntities(roleInfoSearch, delFlag).Select(
                u =>
                new
                {
                    u.ID,
                    u.RoleName,
                    u.Remark,
                    u.SubTime,
                    u.ModifiedOn,
                    u.Sort
                });
            //var RoleInfoList = RoleInfoService.LoadPageEntities(page, rows, out totalCount, u => u.DelFlag == delFlag, u => u.ID).Select(u => new { ID = u.ID, UName = u.UName, UPwd = u.UPwd, SubTime = u.SubTime, Remark = u.Remark });
            string data = WebCommon.GetJsonList(roleInfoSearch.TotalCount, RoleInfoList);
            return Content(data);
        }

        public ActionResult DeleteRoleInfo(string idList)
        {
            string[] strs = idList.Split(',');
            List<int> list = new List<int>();
            foreach (string item in strs)
            {
                list.Add(Convert.ToInt32(item));
            }
            if (RoleInfoService.DeleteEntitys(list))
            {
                return Content("ok");
            }
            else
            {
                return Content("no");
            }
        }

        public ActionResult AddRoleInfo(RoleInfo roleInfo)
        {
            roleInfo.DelFlag = (short)DeleteEnumType.Normal;
            roleInfo.SubTime = DateTime.Now;
            roleInfo.ModifiedOn = DateTime.Now;
            RoleInfoService.AddEntity(roleInfo);
            return Content("ok");
        }

        public ActionResult ShowRoleInfo(int id)
        {
            RoleInfo roleInfo = RoleInfoService.LoadEntities(u => u.ID == id).FirstOrDefault();
            return Content(WebCommon.GetJson(roleInfo));
        }

        public ActionResult EditRoleInfo(RoleInfo roleInfo)
        {
            roleInfo.ModifiedOn = DateTime.Now;
            if (RoleInfoService.EditEntity(roleInfo))
            {
                return Content("ok");
            }
            else
            {
                return Content("no");
            }
        }

    }
}