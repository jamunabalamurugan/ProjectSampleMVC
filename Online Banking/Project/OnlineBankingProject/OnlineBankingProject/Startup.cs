using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(OnlineBankingProject.Startup))]
namespace OnlineBankingProject
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
