// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CooksBlogApplication.cs" company="HotR">
//   2015
// </copyright>
// <summary>
//   The Repository Module.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace CooksBlog.Repository
{
    using Objects;

    using FluentNHibernate.Cfg;
    using FluentNHibernate.Cfg.Db;
    using NHibernate;
    using NHibernate.Cache;
    using NHibernate.Tool.hbm2ddl;
    using Ninject;
    using Ninject.Modules;
    using Ninject.Web.Common;

    /// <summary>
    /// The Repository Module class.
    /// </summary>
    public class RepositoryModule : NinjectModule
    {
        /// <summary>
        /// The Load method.
        /// </summary>
        public override void Load()
        {
            // Create instance of ISessionFactory using Fluent API
            Bind<ISessionFactory>()
                .ToMethod
                (
                    e =>
                        Fluently.Configure()
                        .Database(MsSqlConfiguration.MsSql2012.ConnectionString(c =>
                            c.FromConnectionStringWithKey("CooksBlogDbConnString")))
                        .Cache(c => c.UseQueryCache().ProviderClass<HashtableCacheProvider>())
                        .Mappings(m => m.FluentMappings.AddFromAssemblyOf<Post>())
                        .ExposeConfiguration(cfg => new SchemaExport(cfg).Execute(true, true, false))
                        .BuildConfiguration()
                        .BuildSessionFactory()
                )
                .InSingletonScope();

            // Create single instance of ISessionFactory for this app
            Bind<ISession>()
                .ToMethod((ctx) => ctx.Kernel.Get<ISessionFactory>().OpenSession())
                .InRequestScope();
        }
    }
}