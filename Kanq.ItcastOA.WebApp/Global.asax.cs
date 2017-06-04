using Kanq.ItcastOA.WebApp.Models;
using Spring.Web.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace Kanq.ItcastOA.WebApp
{
    public class MvcApplication : SpringMvcApplication
    {
        protected void Application_Start()
        {
            log4net.Config.XmlConfigurator.Configure();
            //扫描LuceneNet队列中的数据
            IndexMananger.GetInstance().StartThread();
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            ExceptionConfig.CreateExceptionThread();
            GlobalConfiguration.Configure(WebApiConfig.Register);
        }
    }
}
