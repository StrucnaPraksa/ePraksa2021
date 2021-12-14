using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PracticeManagement.Startup))]
namespace PracticeManagement
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
