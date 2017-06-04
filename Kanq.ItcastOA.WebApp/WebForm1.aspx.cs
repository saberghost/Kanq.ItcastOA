using Kanq.ItcastOA.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Kanq.ItcastOA.BLL;
using Kanq.ItcastOA.IBLL;
using Kanq.ItcastOA.Model;

namespace Kanq.ItcastOA.WebApp
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //MemcacheHelper.Set("name", "Tom");
            //Response.Write(MemcacheHelper.Get("name").ToString());
            //OAEntities db = new OAEntities();
            //db.Database.Create();
            Response.Write("ok");
        }
    }
}