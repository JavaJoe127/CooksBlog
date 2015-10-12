// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Post.cs" company="HotR">
//   2015
// </copyright>
// <summary>
//   The Post for blog database
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace CooksBlog.Objects
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    ///   Initialize a new instance of the Post class for blog database
    /// </summary>
    public class Post
    {
        /// <summary>
        /// Gets or sets Id
        /// </summary>
        public virtual int Id { get; set; }

        /// <summary>
        /// Gets or sets title
        /// </summary>
        public virtual string Title { get; set; }

        /// <summary>
        /// Gets or sets short description
        /// </summary>
        public virtual string ShortDescription { get; set; }

        /// <summary>
        /// Gets or sets description
        /// </summary>
        public virtual string Description { get; set; }

        /// <summary>
        /// Gets or sets metadata
        /// metadata is used for SEO
        /// </summary>
        public virtual string Meta { get; set; }

        /// <summary>
        /// Gets or sets url slug
        /// alternate for Title property to use in address in case of special chars like '#'
        /// </summary>
        public virtual string UrlSlug { get; set; }

        /// <summary>
        /// Gets or sets is published?
        /// </summary>
        public virtual bool Published { get; set; }

        /// <summary>
        /// Gets or sets date posted on
        /// </summary>
        public virtual DateTime PostedOn { get; set; }

        /// <summary>
        /// Gets or sets date last modified
        /// </summary>
        public virtual DateTime? Modified { get; set; }

        /// <summary>
        /// Gets or sets category
        /// </summary>
        public virtual Category Category { get; set; }

        /// <summary>
        /// Gets or sets list of tags
        /// </summary>
        public virtual IList<Tag> Tags { get; set; }
    }
}
