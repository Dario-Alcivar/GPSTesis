using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(GPSTesis.Startup))]
namespace GPSTesis
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
