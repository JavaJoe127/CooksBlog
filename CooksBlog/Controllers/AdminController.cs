// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AdminController.cs" company="HotR">
//   2015
// </copyright>
// <summary>
//   The Admin Controller
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace CooksBlog.Controllers
{
    using System.Web.Mvc;

    using Models;
    using Providers;

    [Authorize]
    public class AdminController : Controller
    {
        private readonly IAuthorizeProvider authorizeProvider;

        public AdminController(IAuthorizeProvider authorizeProvider)
        {
            this.authorizeProvider = authorizeProvider;
        }

        private ActionResult RedirectToUrl(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }

            return RedirectToAction("Manage");
        }

        [AllowAnonymous]
        public ActionResult Login(string returnUrl)
        {
            if (authorizeProvider.IsLoggedIn)
            {
                return RedirectToUrl(returnUrl);
            }

            ViewBag.ReturnUrl = returnUrl;

            return View();
        }

        [HttpPost, AllowAnonymous, ValidateAntiForgeryToken]
        public ActionResult Login(LoginModel model, string returnUrl)
        {
            if (ModelState.IsValid && authorizeProvider.Login(model.UserName, model.Password))
            {
                return RedirectToUrl(returnUrl);
            }

            ModelState.AddModelError("", "The user name or password provided is incorrect.");
            return View(model);
        }

        public ActionResult Manager()
        {
            return View();
        }

        public ActionResult Logout()
        {
            authorizeProvider.Logout();

            return RedirectToAction("Login", "Admin");
        }

        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }
    }
}