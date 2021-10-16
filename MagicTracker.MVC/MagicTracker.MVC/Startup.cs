using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MagicTracker.MVC.Startup))]
namespace MagicTracker.MVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
