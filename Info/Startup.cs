using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Info.Startup))]
namespace Info
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
