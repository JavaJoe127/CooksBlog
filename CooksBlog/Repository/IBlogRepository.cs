// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IBlogRepository.cs" company="HotR">
//   2015
// </copyright>
// <summary>
//   The Blog Repository interface.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace CooksBlog.Repository
{
    using System.Collections.Generic;

    using Objects;

    /// <summary>
    /// The Blog Repository interface.
    /// </summary>
    interface IBlogRepository
    {
        /// <summary>
        /// The Posts.
        /// </summary>
        /// <param name="pageNo">
        /// The type.
        /// </param>
        /// <param name="pageSize">
        /// The type.
        /// </param>
        /// <returns>
        /// The <see cref="Post"/>.
        /// </returns>
        IList<Post> Posts(int pageNo, int pageSize);

        /// <summary>
        /// The TotalPosts.
        /// </summary>
        /// <returns>
        /// The <see cref="int"/>
        /// </returns>
        int TotalPosts();
    }
}
