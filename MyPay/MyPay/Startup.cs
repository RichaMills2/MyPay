using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MyPay.Startup))]
namespace MyPay
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
