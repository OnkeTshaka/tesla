using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(tesla.Startup))]
namespace tesla
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
