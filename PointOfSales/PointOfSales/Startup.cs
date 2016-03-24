using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PointOfSales.Startup))]
namespace PointOfSales
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
