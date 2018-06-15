using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(GEA.AvaliacaoTecnica.Presentation.Startup))]
namespace GEA.AvaliacaoTecnica.Presentation
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
