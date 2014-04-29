using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(source_asp.Startup))]
namespace source_asp
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
