using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Final_Lakshya.Startup))]
namespace Final_Lakshya
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
