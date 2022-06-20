using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(GoGaming.Startup))]
namespace GoGaming
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
