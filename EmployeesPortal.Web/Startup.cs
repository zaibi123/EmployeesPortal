using Microsoft.Owin;
using Owin;
using System.Reflection;

[assembly: OwinStartup(typeof(EmployeesPortal.Web.Startup))]
namespace EmployeesPortal.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
