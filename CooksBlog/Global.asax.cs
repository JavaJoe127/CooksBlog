﻿namespace CooksBlog
{
    using System.Web.Routing;

    using Ninject;
    using Ninject.Web.Common;

    using Core.Repository;

    /// <summary>
    /// Initialize a new instance of the Cooks Blog Application class
    /// </summary>
    public class MvcApplication : NinjectHttpApplication
    {
        /// <summary>
        /// The Create Kernel method
        /// </summary>
        /// <returns>
        /// Returns Standard Kernel
        /// </returns>
        protected override IKernel CreateKernel()
        {
            var kernel = new StandardKernel();

            kernel.Load(new RepositoryModule());
            kernel.Bind<IBlogRepository>().To<BlogRepository>();

            return kernel;
        }

        /// <summary>
        /// The On Application Started method
        /// </summary>
        protected override void OnApplicationStarted()
        {
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            base.OnApplicationStarted();
        }
    }
}
