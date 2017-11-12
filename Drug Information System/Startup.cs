using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Drug_Information_System.Startup))]
namespace Drug_Information_System
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
