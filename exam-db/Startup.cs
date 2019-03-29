using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(exam_db.Startup))]
namespace exam_db
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);

        }
    }
}
