using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ContosoHotel.Startup))]
namespace ContosoHotel
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
