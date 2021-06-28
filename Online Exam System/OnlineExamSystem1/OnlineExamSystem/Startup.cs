using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(OnlineExamSystem.Startup))]
namespace OnlineExamSystem
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
