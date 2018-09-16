using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(RoadName.Startup))]
namespace RoadName
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
