using Kanq.ItcastOA.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Kanq.ItcastOA.WebApp
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //MemcacheHelper.Set("name", "Tom");
            Response.Write(MemcacheHelper.Get("name").ToString());
        }
    }
}