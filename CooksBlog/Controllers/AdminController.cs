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
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;

    [Authorize]
    public class AdminController : Controller
    {
        [AllowAnonymous]
        public ActionResult Login(string returnUrl)
        {
            if (User.Identity.IsAuthenticated)
            {
                if (!string.IsNullOrEmpty(returnUrl) && Url.IsLocalUrl(returnUrl))
                {
                    return Redirect(returnUrl);
                }

                return RedirectToAction("Manage");
            }

            ViewBag.ReturnUrl = returnUrl;

            return View();
        }

        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }
    }
}