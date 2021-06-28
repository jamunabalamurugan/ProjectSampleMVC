using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(projectOnlineShopping.Startup))]
namespace projectOnlineShopping
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
