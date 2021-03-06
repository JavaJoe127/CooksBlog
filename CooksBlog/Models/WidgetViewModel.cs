﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="WidgetViewModel.cs" company="HotR">
//   2015
// </copyright>
// <summary>
//   The Widget View Model
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace CooksBlog.Models
{
    using System.Collections.Generic;

    using Core.Objects;
    using Core.Repository;

    /// <summary>
    /// The Widget View Model class
    /// </summary>
    public class WidgetViewModel
    {
        /// <summary>
        /// The Get or Set Categories
        /// </summary>
        public IList<Category> Categories { get; private set; }

        /// <summary>
        /// The Get or Set Tags
        /// </summary>
        public IList<Tag> Tags { get; private set; }

        /// <summary>
        /// The Get or Set Posts
        /// </summary>
        public IList<Post> LatestPosts { get; private set; }

        /// <summary>
        /// The Widget View Model class constructor
        /// </summary>
        /// <param name="blogRepository"></param>
        public WidgetViewModel(IBlogRepository blogRepository)
        {
            Categories = blogRepository.Categories();
            Tags = blogRepository.Tags();
            LatestPosts = blogRepository.Posts(0, 10);
        }
    }
}