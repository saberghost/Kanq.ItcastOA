using Kanq.ItcastOA.Common;
using Kanq.ItcastOA.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Kanq.ItcastOA.WebApp.Controllers
{
    public class BaseController : System.Web.Mvc.Controller
    {
        public UserInfo LoginUser { get; set; }

        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext);
            //if (Session["userInfo"] == null)
            //{
            //    filterContext.HttpContext.Response.Redirect("/Login/Index");
            //}
            bool isScuess = false;
            if (Request.Cookies["sessionID"] != null)
            {
                string sessionID = Request.Cookies["sessionID"].Value;
                object obj = MemcacheHelper.Get(sessionID);
                if (obj != null)
                {
                    UserInfo userInfo = SerializeHelper.DeserializeToObject<UserInfo>(obj.ToString());
                    LoginUser = userInfo;
                    //模拟滑动过期时间
                    MemcacheHelper.Set(sessionID, obj, DateTime.Now.AddMinutes(20));
                    isScuess = true;
                }
            }
            if (!isScuess)
            {
                filterContext.Result = Redirect("/Login/Index");
            }
        }
    }
}