using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WebAutomationApplication.Startup))]
namespace WebAutomationApplication
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
