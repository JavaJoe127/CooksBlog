// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Category.cs" company="HotR">
//   2015
// </copyright>
// <summary>
//   The Category for blog database.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace CooksBlog.Objects
{
    using System.Collections.Generic;

    // <summary>
    //   The Category for blog database.
    // </summary>
    public class Category
    {
        /// <summary>
        /// Gets or sets Id.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets url slug.
        /// alternate for Title property to use in address in case of special chars like '#'.
        /// </summary>
        public virtual string UrlSlug { get; set; }

        /// <summary>
        /// Gets or sets description.
        /// </summary>
        public virtual string Description { get; set; }

        /// <summary>
        /// Gets or sets list of posts.
        /// </summary>
        public virtual IList<Post> Posts { get; set; }
    }
}
