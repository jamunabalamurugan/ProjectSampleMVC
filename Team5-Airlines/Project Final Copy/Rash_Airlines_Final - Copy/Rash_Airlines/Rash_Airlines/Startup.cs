using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Rash_Airlines.Startup))]
namespace Rash_Airlines
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
