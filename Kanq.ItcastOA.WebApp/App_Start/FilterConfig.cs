using Kanq.ItcastOA.WebApp.Models;
using System.Web;
using System.Web.Mvc;

namespace Kanq.ItcastOA.WebApp
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            //filters.Add(new HandleErrorAttribute());
            filters.Add(new MyExceptionAtttribute());
        }
    }
}
