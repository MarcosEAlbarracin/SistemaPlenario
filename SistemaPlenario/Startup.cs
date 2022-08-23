using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SistemaPlenario.Startup))]
namespace SistemaPlenario
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
