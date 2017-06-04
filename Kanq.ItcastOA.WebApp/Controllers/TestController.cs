using Kanq.ItcastOA.WebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Kanq.ItcastOA.WebApp.Controllers
{
    public class TestController : Controller
    {
        // GET: Test
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult LuceueTest()
        {
            IndexMananger.GetInstance().AddQueue(9999, "天才", "天朝的人是天才");
            return Content("ok");
        }
    }
}