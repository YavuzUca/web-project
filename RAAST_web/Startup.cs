using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(RAAST_web.Startup))]
namespace RAAST_web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
