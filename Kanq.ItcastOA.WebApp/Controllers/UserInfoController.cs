using Kanq.ItcastOA.Common;
using Kanq.ItcastOA.IBLL;
using Kanq.ItcastOA.Model;
using Kanq.ItcastOA.Model.Search;
using Kanq.ItcastOA.WebApp.Models;
using Kanq.ItcastOA.WebApp.Models.EnumType;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Kanq.ItcastOA.WebApp.Controllers
{
    public class UserInfoController :Controller
    {
        public IUserInfoService userInfoService { get; set; }
        public IRoleInfoService RoleInfoService { get; set; }

        short delFlag = (short)DeleteEnumType.Normal;
        // GET: UserInfo
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetUserInfoList(int page, int rows, string UName, string Remark)
        {
            //int totalCount = 0;
            UserInfoSearch userInfoSearch = new UserInfoSearch()
            {
                PageIndex = page,
                PageSize = rows,
                UName = UName,
                Remark = Remark,
                //TotalCount = totalCount
            };
            var userInfoList = userInfoService.LoadSerachEntities(userInfoSearch, delFlag).Select(u => new { ID = u.ID, UName = u.UName, UPwd = u.UPwd, SubTime = u.SubTime, Remark = u.Remark });
            //var userInfoList = userInfoService.LoadPageEntities(page, rows, out totalCount, u => u.DelFlag == delFlag, u => u.ID).Select(u => new { ID = u.ID, UName = u.UName, UPwd = u.UPwd, SubTime = u.SubTime, Remark = u.Remark });
            string data = WebCommon.GetJsonList(userInfoSearch.TotalCount, userInfoList);
            return Content(data);
        }

        public ActionResult DeleteUserInfo(string idList)
        {
            string[] strs = idList.Split(',');
            List<int> list = new List<int>();
            foreach (string item in strs)
            {
                list.Add(Convert.ToInt32(item));
            }
            if (userInfoService.DeleteEntitys(list))
            {
                return Content("ok");
            }
            else
            {
                return Content("no");
            }
        }

        public ActionResult AddUserInfo(UserInfo userInfo)
        {
            userInfo.DelFlag = (short)DeleteEnumType.Normal;
            userInfo.SubTime = DateTime.Now;
            userInfo.ModifiedOn = DateTime.Now;
            userInfoService.AddEntity(userInfo);
            return Content("ok");
        }

        public ActionResult ShowUserInfo(int id)
        {
            UserInfo userInfo = userInfoService.LoadEntities(u => u.ID == id).FirstOrDefault();
            return Content(WebCommon.GetJson(userInfo));
        }

        public ActionResult EditUserInfo(UserInfo userInfo)
        {
            userInfo.ModifiedOn = DateTime.Now;
            if (userInfoService.EditEntity(userInfo))
            {
                return Content("ok");
            }
            else
            {
                return Content("no");
            }
        }

        public ActionResult SetRole(int id)
        {
            UserInfo userInfo = userInfoService.LoadEntities(t => t.ID == id).FirstOrDefault();
            ViewBag.allRoleInfos = RoleInfoService.LoadEntities(t => t.DelFlag == delFlag).ToList();
            ViewBag.existsRoleIds = userInfo.RoleInfo.Select(t => t.ID).ToList();
            return View(userInfo);
        }

        public ActionResult ProcessSetRole(int userId)
        {
            List<int> roleIds = new List<int>();
            foreach (var key in Request.Form.AllKeys)
            {
                if (key.StartsWith("ckb_"))
                {
                    int roleId = int.Parse(key.Replace("ckb_", ""));
                    roleIds.Add(roleId);
                }
            }
            userInfoService.setRole(userId, roleIds);
            return Content("ok");
        }

        public ActionResult SetAction(int id)
        {
            UserInfo userInfo = userInfoService.LoadEntities(t => t.ID == id).FirstOrDefault();
            //ViewBag.allRoleInfos = RoleInfoService.LoadEntities(t => t.DelFlag == delFlag).ToList();
            //ViewBag.existsRoleIds = userInfo.RoleInfo.Select(t => t.ID).ToList();
            return View(userInfo);
        }
    }
}