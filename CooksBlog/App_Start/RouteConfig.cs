// --------------------------------------------------------------------------------------------------------------------
// <copyright file="RouteConfig.cs" company="HotR">
//   2015
// </copyright>
// <summary>
//   The Route Configuration
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace CooksBlog
{
    using System.Web.Mvc;
    using System.Web.Routing;

    /// <summary>
    /// The route configuration class
    /// </summary>
    public class RouteConfig
    {
        /// <summary>
        /// The register routes method
        /// </summary>
        /// <param name="routes">
        /// The route collection
        /// </param>
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Blog", action = "Posts", id = UrlParameter.Optional }
            );
        }
    }
}
