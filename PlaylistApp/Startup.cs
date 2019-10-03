using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PlaylistApp.Startup))]
namespace PlaylistApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
