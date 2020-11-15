using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Bidly.Startup))]
namespace Bidly
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
