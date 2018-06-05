using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Punch.Startup))]
namespace Punch
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
