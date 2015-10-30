// --------------------------------------------------------------------------------------------------------------------
// <copyright file="BlogController.cs" company="HotR">
//   2015
// </copyright>
// <summary>
//   The Blog Controller
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace CooksBlog.Controllers
{
    using System.Web;
    using System.Web.Mvc;

    using Models;
    using Core.Repository;

    /// <summary>
    /// Initialize a new instance of the Blog Controller class
    /// </summary>
    public class BlogController: Controller
    {
        /// <summary>
        /// The blog repository
        /// </summary>
        private readonly IBlogRepository blogRepository;

        /// <summary>
        /// The blog controller constructor
        /// </summary>
        /// <param name="blogRepo"></param>
        public BlogController(IBlogRepository blogRepo)
        {
            this.blogRepository = blogRepo;
        }

        /// <summary>
        /// The Posts
        /// </summary>
        /// <param name="p"></param>
        /// <returns>
        /// Returns all Posts
        /// </returns>
        public ViewResult Posts(int page = 1)
        {
            var listViewModel = new ListViewModel(this.blogRepository, page);

            ViewBag.Title = "Latest Posts";
            return View("List", listViewModel);
        }

        /// <summary>
        /// The Category Method
        /// </summary>
        /// <param name="category"></param>
        /// <param name="page"></param>
        /// <returns>
        /// Returns view of all associated category posts
        /// </returns>
        public ViewResult Category(string category, int page = 1)
        {
            var listViewModel = new ListViewModel(this.blogRepository, category, "category", page);

            if (listViewModel.Category == null)
            {
                throw new HttpException(404, "Category not found");
            }

            ViewBag.Title = string.Format(@"Latest posts on category ""{0}""", listViewModel.Category.Name);
            return View("List", listViewModel);
        }

        /// <summary>
        /// The Tag Method
        /// </summary>
        /// <param name="tag"></param>
        /// <param name="page"></param>
        /// <returns>
        /// Returns view of all associated tag posts
        /// </returns>
        public ViewResult Tag(string tag, int page = 1)
        {
            var listViewModel = new ListViewModel(this.blogRepository, tag, "tag", page);

            if (listViewModel.Tag == null)
            {
                throw new HttpException(404, "Category not found");
            }

            ViewBag.Title = string.Format(@"Latest posts tagged on ""{0}""", listViewModel.Tag.Name);
            return View("List", listViewModel);
        }

        public ViewResult Search(string search, int page = 1)
        {
            ViewBag.Title = string.Format(@"Lists of posts found for search text ""{0}""", search);

            var viewModel = new ListViewModel(this.blogRepository, search, "Search", page);

            return View("List", viewModel);
        }
    }
}