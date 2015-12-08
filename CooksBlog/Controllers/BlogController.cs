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
    using System.Web.Security;

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

        /// <summary>
        /// The Search method
        /// </summary>
        /// <param name="search"></param>
        /// <param name="page"></param>
        /// <returns>
        /// Returns view of all matching posts
        /// </returns>
        public ViewResult Search(string search, int page = 1)
        {
            ViewBag.Title = string.Format(@"Lists of posts found for search text ""{0}""", search);

            var viewModel = new ListViewModel(this.blogRepository, search, "Search", page);

            return View("List", viewModel);
        }

        /// <summary>
        /// The Post method
        /// </summary>
        /// <param name="year"></param>
        /// <param name="month"></param>
        /// <param name="title"></param>
        /// <returns>
        /// Returns a detailed view of a post
        /// </returns>
        public ViewResult Post(int year, int month, string title)
        {
            var post = this.blogRepository.Post(year, month, title);

            if (post == null)
            {
                throw new HttpException(404, "Post not found");
            }

            if (post.Published == false && User.Identity.IsAuthenticated == false)
            {
                throw new HttpException(401, "The post is not published");
            }

            return View(post);
        }

        /// <summary>
        /// The Login as admin method
        /// </summary>
        /// <param name="model"></param>
        /// <param name="returnUrl"></param>
        /// <returns>
        /// Returns a view depending on success or failure to login
        /// </returns>
        [HttpPost, AllowAnonymous, ValidateAntiForgeryToken]
        public ActionResult Login(LoginModel model, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                if (Membership.ValidateUser(model.UserName, model.Password))
                {
                    FormsAuthentication.SetAuthCookie(model.UserName, false);

                    if (!string.IsNullOrEmpty(returnUrl) && Url.IsLocalUrl(returnUrl))
                    {
                        return Redirect(returnUrl);
                    }

                    return RedirectToAction("Manage");
                }

                ModelState.AddModelError("", "The user name or password provided is incorrect.");
            }

            return View();
        }

        /// <summary>
        /// The Logout as admin method
        /// </summary>
        /// <returns>
        /// Returns a public view after logging out
        /// </returns>
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();

            return RedirectToAction("Login", "Admin");
        }

        /// <summary>
        /// The Sidebars method
        /// </summary>
        /// <returns>
        /// Returns the partial sidebar view
        /// </returns>
        [ChildActionOnly]
        public PartialViewResult Sidebars()
        {
            var widgetViewModel = new WidgetViewModel(this.blogRepository);
            return PartialView("_Sidebars", widgetViewModel);
        }
    }
}