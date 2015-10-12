// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ListView.cs" company="HotR">
//   2015
// </copyright>
// <summary>
//   The List View
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace CooksBlog.Models
{
    using Objects;
    using System.Collections.Generic;

    /// <summary>
    /// Initialize a new instance of the List View class
    /// </summary>
    public class ListView
    {
        /// <summary>
        /// The Get posts property
        /// </summary>
        public IList<Post> Posts { get; private set; }

        /// <summary>
        /// The Get total posts property
        /// </summary>
        public int TotalPosts { get; private set; }
    }
}