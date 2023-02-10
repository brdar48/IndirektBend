using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(IndirektBend.Startup))]
namespace IndirektBend
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
