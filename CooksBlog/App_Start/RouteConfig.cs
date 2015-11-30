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
            // reminder - the maproutes go in order from first to last, Posts needs to be on the bottom
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                "Post",
                "Archive/{year}/{month}/{title}",
                new { controller = "Blog", action = "Post"}
                );

            routes.MapRoute(
                "Tag",
                "Tag/{tag}",
                new { controller = "Blog", action = "Tag" }
                );

            routes.MapRoute(
                "Category",
                "Category/{category}",
                new { controller = "Blog", action = "Category" }
                );

            routes.MapRoute(
                "Login",
                "Login",
                new { controller = "Admin", action = "Login" }
                );

            // default route
            routes.MapRoute(
                "Action",
                "{action}",
                new { controller = "Blog", action = "Posts" }
            );
        }
    }
}
