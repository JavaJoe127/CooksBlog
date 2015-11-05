// --------------------------------------------------------------------------------------------------------------------
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
        /// The Widget View Model class constructor
        /// </summary>
        /// <param name="blogRepository"></param>
        public WidgetViewModel(IBlogRepository blogRepository)
        {
            Categories = blogRepository.Categories();
        }
    }
}