using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TestingShoppingCart.Startup))]
namespace TestingShoppingCart
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
