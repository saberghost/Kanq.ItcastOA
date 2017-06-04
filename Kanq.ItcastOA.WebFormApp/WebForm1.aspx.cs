using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Kanq.ItcastOA.WebFormApp
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ServiceReference1.WebServiceDemoSoapClient client = new ServiceReference1.WebServiceDemoSoapClient();
            Response.Write(client.Add(4, 6));
            MapServer.MapServerPortClient ci = new MapServer.MapServerPortClient();
        }
    }
}