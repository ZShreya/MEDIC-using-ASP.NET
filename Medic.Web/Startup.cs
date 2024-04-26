using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Medic.Web.Startup))]
namespace Medic.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
