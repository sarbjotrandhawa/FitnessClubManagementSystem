using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(FitnessClubManagementSystem.Startup))]
namespace FitnessClubManagementSystem
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
