using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(RegistrationQuestionnare.Startup))]
namespace RegistrationQuestionnare
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
