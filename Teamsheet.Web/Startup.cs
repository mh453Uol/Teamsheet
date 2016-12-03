using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Teamsheet.Web.Startup))]
namespace Teamsheet.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
