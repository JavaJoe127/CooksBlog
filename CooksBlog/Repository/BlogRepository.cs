// --------------------------------------------------------------------------------------------------------------------
// <copyright file="BlogRepository.cs" company="HotR">
//   2015
// </copyright>
// <summary>
//   The Blog Repository.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace CooksBlog.Repository
{
    using System.Collections.Generic;
    using System.Linq;

    using Objects;
    using NHibernate;
    using NHibernate.Linq;

    /// <summary>
    /// The Blog Repository
    /// </summary>
    public class BlogRepository: IBlogRepository
    {
        /// <summary>
        /// The session.
        /// </summary>
        private readonly ISession session;

        /// <summary>
        /// The Blog Repository constructor.
        /// </summary>
        /// <param name="session">
        /// The session.
        /// </param>
        public BlogRepository(ISession session)
        {
            this.session = session;
        }

        /// <summary>
        /// The Posts.
        /// </summary>
        /// <param name="pageNo">
        /// The page number.
        /// </param>
        /// <param name="pageSize">
        /// The page size.
        /// </param>
        /// <returns>
        /// The list of Posts
        /// </returns>
        public IList<Post> Posts(int pageNo, int pageSize)
        {
            var posts = this.session.Query<Post>()
                .Where(p => p.Published)
                .OrderByDescending(p => p.PostedOn)
                .Skip(pageNo * pageSize)
                .Take(pageSize)
                .Fetch(p => p.Category)
                .ToList();

            var postIds = posts.Select(p => p.Id).ToList();

            return this.session.Query<Post>()
                .Where(p => postIds.Contains(p.Id))
                .OrderByDescending(p => p.PostedOn)
                .FetchMany(p => p.Tags)
                .ToList();
        }

        /// <summary>
        /// The Total Posts.
        /// </summary>
        /// <returns>
        /// The number of posts.
        /// </returns>
        public int TotalPosts()
        {
            return this.session.Query<Post>()
                .Where(p => p.Published)
                .Count();
        }
    }
}