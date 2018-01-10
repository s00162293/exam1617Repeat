using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(examRepeat1617.Startup))]
namespace examRepeat1617
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
