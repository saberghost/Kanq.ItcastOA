using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Kanq.ItcastOA.WebApp.Models
{
    public class MyFilterAttribute: ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext);
            if (filterContext.HttpContext.Session["userInfo"] == null)
            {
                //filterContext.HttpContext.Response.Redirect("/Login/Index");
                filterContext.Result = new RedirectResult("/Login/Index");
            }
        }
    }
}