// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ListViewModel.cs" company="HotR">
//   2015
// </copyright>
// <summary>
//   The List View Model
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace CooksBlog.Controllers
{
    using System.Collections.Generic;

    using Objects;
    using Repository;

    /// <summary>
    /// Initialize a new instance of List View Model class
    /// </summary>
    public class ListViewModel
    {
        /// <summary>
        /// The Get or Set Posts property
        /// </summary>
        public IList<Post> Posts { get; private set; }

        /// <summary>
        /// The Get or Set Total Posts property
        /// </summary>
        public int TotalPosts { get; private set; }

        /// <summary>
        /// The List View Model constructor
        /// </summary>
        /// <param name="blogRepository">
        /// The blog repository
        /// </param>
        /// <param name="page">
        /// The page
        /// </param>
        public ListViewModel(IBlogRepository blogRepository, int page)
        {
            Posts = blogRepository.Posts(page - 1, 10);
            TotalPosts = blogRepository.TotalPosts();
        }
    }
}