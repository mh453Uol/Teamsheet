using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Teamsheet.Startup))]
namespace Teamsheet
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
