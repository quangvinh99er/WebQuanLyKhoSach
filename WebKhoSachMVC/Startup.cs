using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WebKhoSachMVC.Startup))]
namespace WebKhoSachMVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
