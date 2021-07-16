using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WakenBake.Startup))]
namespace WakenBake
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
