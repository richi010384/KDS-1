using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(KDS.Web.Startup))]
namespace KDS.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
