using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(JiraProgressTracker.Startup))]
namespace JiraProgressTracker
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
