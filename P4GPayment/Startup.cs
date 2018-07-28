using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(P4GPayment.Startup))]
namespace P4GPayment
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
