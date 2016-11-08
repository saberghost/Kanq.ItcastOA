using Kanq.ItcastOA.BLL;
using Kanq.ItcastOA.IBLL;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Kanq.ItcastOA.WebApp.Controllers
{
    public class DemoController : Controller
    {
        // GET: Demo
        public ActionResult Index()
        {
            IUserInfoService bll = new UserInfoService();
            var list = bll.LoadEntities(u => true);
            foreach (var item in list)
            {
                Response.Write(item.UName);
            }
            return View();
        }
    }
}