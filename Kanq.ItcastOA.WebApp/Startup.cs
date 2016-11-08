using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Kanq.ItcastOA.WebApp.Startup))]
namespace Kanq.ItcastOA.WebApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
