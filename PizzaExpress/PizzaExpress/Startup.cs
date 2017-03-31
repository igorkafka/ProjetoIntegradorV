using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PizzaExpress.Startup))]
namespace PizzaExpress
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
