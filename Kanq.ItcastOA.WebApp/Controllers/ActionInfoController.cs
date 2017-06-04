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
using System.IO;

namespace Kanq.ItcastOA.WebApp.Controllers
{
    public class ActionInfoController : Controller
    {

        public IActionInfoService ActionInfoService { get; set; }
        public IRoleInfoService RoleInfoService { get; set; }

        short delFlag = (short)DeleteEnumType.Normal;

        // GET: ActionInfo
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetActionInfoList(int page, int rows, string ActionInfoName, string Url)
        {
            //int totalCount = 0;
            ActionInfoSearch actionInfoSearch = new ActionInfoSearch()
            {
                PageIndex = page,
                PageSize = rows,
                ActionInfoName = ActionInfoName,
                Url = Url,
                //TotalCount = totalCount
            };
            var ActionInfoList = ActionInfoService.LoadSerachEntities(actionInfoSearch, delFlag).Select(
                u =>
                new
                {
                    u.ID,
                    u.ActionInfoName,
                    u.Url,
                    u.HttpMethod,
                    u.Remark,
                    u.MenuIcon,
                    u.IsMenu,
                    u.SubTime,
                    u.ModifiedOn,
                    u.Sort
                });
            //var ActionInfoList = ActionInfoService.LoadPageEntities(page, rows, out totalCount, u => u.DelFlag == delFlag, u => u.ID).Select(u => new { ID = u.ID, UName = u.UName, UPwd = u.UPwd, SubTime = u.SubTime, Remark = u.Remark });
            string data = WebCommon.GetJsonList(actionInfoSearch.TotalCount, ActionInfoList);
            return Content(data);
        }

        public ActionResult DeleteActionInfo(string idList)
        {
            string[] strs = idList.Split(',');
            List<int> list = new List<int>();
            foreach (string item in strs)
            {
                list.Add(Convert.ToInt32(item));
            }
            if (ActionInfoService.DeleteEntitys(list))
            {
                return Content("ok");
            }
            else
            {
                return Content("no");
            }
        }

        public ActionResult AddActionInfo(ActionInfo actionInfo)
        {
            actionInfo.DelFlag = (short)DeleteEnumType.Normal;
            actionInfo.SubTime = DateTime.Now;
            actionInfo.ModifiedOn = DateTime.Now;
            actionInfo.IsMenu = Request["IsMenu"] == null ? false : true;
            ActionInfoService.AddEntity(actionInfo);
            return Content("ok");
        }

        public ActionResult ShowActionInfo(int id)
        {
            ActionInfo actionInfo = ActionInfoService.LoadEntities(u => u.ID == id).FirstOrDefault();
            return Content(WebCommon.GetJson(actionInfo));
        }

        public ActionResult EditActionInfo(ActionInfo actionInfo)
        {
            actionInfo.ModifiedOn = DateTime.Now;
            if (ActionInfoService.EditEntity(actionInfo))
            {
                return Content("ok");
            }
            else
            {
                return Content("no");
            }
        }

        public ActionResult UploadImage()
        {
            var file = Request.Files["fileMenuIcon"];
            string dirPath = "/UploadFiles/UploadImages";
            string fullPath = Path.Combine(dirPath, Guid.NewGuid().ToString() + "-" + Path.GetFileName(file.FileName));
            if (!Directory.Exists(Request.MapPath(dirPath)))
            {
                Directory.CreateDirectory(Request.MapPath(dirPath));
            }
            file.SaveAs(Request.MapPath(fullPath));
            return Content(fullPath);
        }

        public ActionResult SetRole(int id)
        {
            ActionInfo actionInfo = ActionInfoService.LoadEntities(t => t.ID == id).FirstOrDefault();
            ViewBag.allRoleInfos = RoleInfoService.LoadEntities(t => t.DelFlag == delFlag).ToList();
            ViewBag.existsRoleIds = actionInfo.RoleInfo.Select(t => t.ID).ToList();
            return View(actionInfo);
        }

        public ActionResult ProcessSetRole(int actionId)
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
            ActionInfoService.setRole(actionId, roleIds);
            return Content("ok");
        }

    }
}