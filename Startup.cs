using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BootFlixBC7.Startup))]
namespace BootFlixBC7
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
