using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(RKPP.Startup))]
namespace RKPP
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
