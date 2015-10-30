// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ActionLinkExtensions.cs" company="HotR">
//   2015
// </copyright>
// <summary>
//   The Action Link Extensions
//   The ActionLink overload used here has 5 parameters:
//      anchor text, action name, controller name, route parameters, html attributes
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace CooksBlog
{
    using System.Web.Mvc;
    using System.Web.Mvc.Html;

    using Core.Objects;

    /// <summary>
    /// The Action Link Extension class
    /// </summary>
    public static class ActionLinkExtensions
    {
        /// <summary>
        /// The Post link
        /// </summary>
        /// <param name="helper">
        ///     The HTML helper
        /// </param>
        /// <param name="post">
        ///     The post
        /// </param>
        /// <returns>
        ///     The action link for HTML
        /// </returns>
        public static MvcHtmlString PostLink(this HtmlHelper helper, Post post)
        {
            return helper.ActionLink(post.Title, "Post", "Blog",
                new
                {
                    year = post.PostedOn.Year,
                    month = post.PostedOn.Month,
                    title = post.UrlSlug
                },
                new
                {
                    title = post.Title
                });
        }

        /// <summary>
        /// The Category link
        /// </summary>
        /// <param name="helper">
        ///     The HTML helper
        /// </param>
        /// <param name="category">
        ///     The category
        /// </param>
        /// <returns>
        ///     The action link for HTML
        /// </returns>
        public static MvcHtmlString CategoryLink(this HtmlHelper helper, Category category)
        {
            return helper.ActionLink(category.Name, "Category", "Blog",
                new
                {
                    category = category.UrlSlug
                },
                new
                {
                    title = string.Format("See all posts in {0}", category.Name)
                });
        }

        /// <summary>
        /// The Tag link
        /// </summary>
        /// <param name="helper">
        ///     The HTML helper
        /// </param>
        /// <param name="tag">
        ///     The tag
        /// </param>
        /// <returns>
        ///     The action link for HTML
        /// </returns>
        public static MvcHtmlString TagLink(this HtmlHelper helper, Tag tag)
        {
            return helper.ActionLink(tag.Name, "Tag", "Blog",
                new
                {
                    tag = tag.UrlSlug
                },
                new
                {
                    title = string.Format("See all posts in {0}", tag.Name)
                });
        }
    }
}