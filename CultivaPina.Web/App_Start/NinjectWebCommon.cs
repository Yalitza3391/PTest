using Microsoft.Web.Infrastructure.DynamicModuleHelper;
using Ninject;
using Ninject.Web.Common;
using Ninject.Web.Common.WebHost;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CultivaPina.EntityFramework.Models;
using Ninject.Modules;
using System.Web.Http;
using System.Data.Entity;
using CultivaPina.EntityFramework.Models.Repositories;
using CultivoPina.Core.Cultivo;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Options;
using CultivaPiñaWeb.Util.Extensions;
using System.Web.Http.Dependencies;
using Ninject.Syntax;
using Ninject.Activation;
using Ninject.Parameters;
using CultivoPina.Core.Sector;
using CultivoPina.Core.Pina;

[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(CultivaPiñaWeb.App_Start.NinjectWebCommon), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(CultivaPiñaWeb.App_Start.NinjectWebCommon), "Stop")]

namespace CultivaPiñaWeb.App_Start
{
    public static class NinjectWebCommon
    {
        private static readonly Bootstrapper bootstrapper = new Bootstrapper();

        /// 

        /// Starts the application
        /// 
        public static void Start()
        {
            DynamicModuleUtility.RegisterModule(typeof(OnePerRequestHttpModule));
            DynamicModuleUtility.RegisterModule(typeof(NinjectHttpModule));
            bootstrapper.Initialize(CreateKernel);
        }

        /// 

        /// Stops the application.
        /// 
        public static void Stop()
        {
            bootstrapper.ShutDown();
        }

        /// 

        /// Creates the kernel that will manage your application.
        /// 
        /// The created kernel.
        public static IKernel CreateKernel()
        {



            var kernel = new StandardKernel();
            try
            {
                kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
                kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();
                RegisterServices(kernel);
                GlobalConfiguration.Configuration.DependencyResolver = new NinjectResolver(kernel);
                return kernel;
            }
            catch
            {
                kernel.Dispose();
                throw;
            }

            

        }

        public class NinjectResolver : NinjectScope, IDependencyResolver
        {
            private readonly IKernel _kernel;
            public NinjectResolver(IKernel kernel)
                : base(kernel)
            {
                _kernel = kernel;
            }
            public IDependencyScope BeginScope()
            {
                return new NinjectScope(_kernel.BeginBlock());
            }
        }

        public class NinjectScope : IDependencyScope
        {
            protected IResolutionRoot resolutionRoot;
            public NinjectScope(IResolutionRoot kernel)
            {
                resolutionRoot = kernel;
            }
            public object GetService(Type serviceType)
            {
                IRequest request = resolutionRoot.CreateRequest(serviceType, null, new Parameter[0], true, true);
                return resolutionRoot.Resolve(request).SingleOrDefault();
            }
            public IEnumerable<object> GetServices(Type serviceType)
            {
                IRequest request = resolutionRoot.CreateRequest(serviceType, null, new Parameter[0], true, true);
                return resolutionRoot.Resolve(request).ToList();
            }
            public void Dispose()
            {
                IDisposable disposable = (IDisposable)resolutionRoot;
                if (disposable != null) disposable.Dispose();
                resolutionRoot = null;
            }

        }    /// 

            /// Load your modules or register your services here!
            /// 
            /// The kernel.
            private static void RegisterServices(IKernel kernel)

        {
            kernel.Bind<CultivoPinaDBContext>().ToSelf().InRequestScope().OnActivation((k, d) =>
            {
#pragma warning disable S2201 // Return values should not be ignored when function calls don't have any side effects

#pragma warning restore S2201 // Return values should not be ignored when function calls don't have any side effects
            });
            kernel.Bind<DbContext>().To<CultivoPinaDBContext>().InRequestScope();



            kernel.Load<Bindings>();
            // GlobalConfiguration.Configuration.UseNinjectActivator(this.Kernel);

        }

        public class Bindings : NinjectModule
        {
            public override void Load()
            {

                this.Kernel.Bind<IRepository<Cultivo>>().To<CultivoRepository>().InRequestScope();
                this.Kernel.Bind<ICultivo>().To<CultivoManage>().InRequestScope();
                this.Kernel.Bind<IRepository<Sector>>().To<SectorRepository>().InRequestScope();
                this.Kernel.Bind<ISector>().To<SectorManager>().InRequestScope();
                this.Kernel.Bind<IRepository<Pina>>().To<PinaRepository>().InRequestScope();
                this.Kernel.Bind<IPina>().To<PinaManager>().InRequestScope();
            }
        }


    }
}
