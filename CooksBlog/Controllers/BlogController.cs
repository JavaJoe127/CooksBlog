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
    using System.Web.Mvc;

    using Repository;

    /// <summary>
    /// Initialize a new instance of the Blog Controller class
    /// </summary>
    public class BlogController: Controller
    {
        private readonly IBlogRepository blogRepository;

        /// <summary>
        /// The Blog Controller constructor
        /// </summary>
        /// <param name="blogRepository">
        /// The blog repository
        /// </param>
        public BlogController(IBlogRepository blogRepository)
        {
            this.blogRepository = blogRepository;
        }

        /// <summary>
        /// The Posts
        /// </summary>
        /// <param name="p">
        /// The page
        /// </param>
        /// <returns>
        /// The result view
        /// </returns>
        public ViewResult Posts(int page = 1)
        {
            var posts = this.blogRepository.Posts(page - 1, 10);
            var totalPosts = blogRepository.TotalPosts();

            var listViewModel = new ListViewModel(this.blogRepository, page);

            ViewBag.Title = "Latest Posts";
            return View("List", listViewModel);
        }
    }
}