using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AutoCompleteProject.Startup))]
namespace AutoCompleteProject
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
