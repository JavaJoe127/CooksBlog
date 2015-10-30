// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ListViewModel.cs" company="HotR">
//   2015
// </copyright>
// <summary>
//   The List View Model
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace CooksBlog.Models
{
    using System.Collections.Generic;
    using System.Web;

    using Core.Objects;
    using Core.Repository;

    /// <summary>
    /// Initialize a new instance of List View Model class
    /// </summary>
    public class ListViewModel
    {
        /// <summary>
        /// The Get Posts property
        /// </summary>
        public IList<Post> Posts { get; private set; }

        /// <summary>
        /// The Get Total Posts property
        /// </summary>
        public int TotalPosts { get; private set; }

        /// <summary>
        /// The Get Category property
        /// </summary>
        public Category Category { get; private set; }

        /// <summary>
        /// The Get Tag property
        /// </summary>
        public Tag Tag { get; private set; }

        /// <summary>
        /// The Get Search property
        /// </summary>
        public string Search { get; private set; }

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
            this.Posts = blogRepository.Posts(page - 1, 10);
            this.TotalPosts = blogRepository.TotalPosts();
        }

        /// <summary>
        /// The List View Model constructor for categories and tags
        /// </summary>
        /// <param name="blogRepository"></param>
        /// <param name="text"></param>
        /// <param name="postType"></param>
        /// <param name="page"></param>
        public ListViewModel(IBlogRepository blogRepository, string text, string postType, int page)
        {
            // improvement: make postType a type and overload this method depending on type passed in
            switch (postType.ToLower())
            {
                case "category":
                    this.Posts = blogRepository.PostsForCategory(text, page - 1, 10);
                    this.TotalPosts = blogRepository.TotalPostsForCategory(text);
                    this.Category = blogRepository.Category(text);
                    break;
                case "tag":
                    this.Posts = blogRepository.PostsForTag(text, page - 1, 10);
                    this.TotalPosts = blogRepository.TotalPostsForTag(text);
                    this.Tag = blogRepository.Tag(text);
                    break;
                default:
                    this.Posts = blogRepository.PostsForSearch(text, page - 1, 10);
                    this.TotalPosts = blogRepository.TotalPostsForSearch(text);
                    this.Search = text;
                    break;
            }
        }
    }
}