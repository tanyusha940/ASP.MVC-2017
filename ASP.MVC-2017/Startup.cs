using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ASP.MVC_2017.Startup))]
namespace ASP.MVC_2017
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
