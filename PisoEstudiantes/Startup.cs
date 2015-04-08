using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PisoEstudiantes.Startup))]
namespace PisoEstudiantes
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
