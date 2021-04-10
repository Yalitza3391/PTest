using System;
using System.Threading.Tasks;
using System.Web.Http;
using Microsoft.Owin;
using Owin;
using static CultivaPiñaWeb.App_Start.NinjectWebCommon;

[assembly: OwinStartup(typeof(CultivaPiñaWeb.App_Start.Startup))]

namespace CultivaPiñaWeb.App_Start
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=316888
            var config = new HttpConfiguration();
            config.DependencyResolver = new NinjectResolver(NinjectWebCommon.CreateKernel());


            app.Use(config);
        }
    }
}
