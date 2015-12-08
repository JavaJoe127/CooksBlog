namespace CooksBlog.Tests
{
    using System.Web;
    using System.Web.Mvc;
    using System.Web.Routing;

    using Rhino.Mocks;
    using NUnit.Framework;

    using Controllers;
    using Models;
    using Providers;

    [TestFixture]
    public class AdminControllerTests
    {
        private AdminController adminController;
        private IAuthorizeProvider authorizeProvider;

        [SetUp]
        public void SetUp()
        {
            authorizeProvider = MockRepository.GenerateMock<IAuthorizeProvider>();
            adminController = new AdminController(authorizeProvider);

            var httpContextMock = MockRepository.GenerateMock<HttpContextBase>();
            adminController.Url = new UrlHelper(new RequestContext(httpContextMock, new RouteData()));
        }

        [Test]
        public void LoginIsLoggedIn_True_Test()
        {
            // arrange test
            authorizeProvider.Stub(s => s.IsLoggedIn).Return(true);

            // perform a test on a method
            var actual = adminController.Login("/admin/manage");

            // assert if success or fail
            Assert.IsInstanceOf<RedirectResult>(actual);
            Assert.AreEqual("/admin/manage", ((RedirectResult)actual).Url);
        }

        [Test]
        public void LoginIsLoggedIn_False_Test()
        {
            authorizeProvider.Stub(s => s.IsLoggedIn).Return(false);

            var actual = adminController.Login("/");

            Assert.IsInstanceOf<ViewResult>(actual);
            Assert.AreEqual("/", ((ViewResult)actual).ViewBag.ReturnUrl);
        }

        [Test]
        public void LoginPostModel_Invalid_Test()
        {
            var model = new LoginModel();
            adminController.ModelState.AddModelError("Username", "UserName is required");

            var actual = adminController.Login(model, "/");

            Assert.IsInstanceOf<ViewResult>(actual);
        }

        [Test]
        public void LoginPostUser_Invalid_Test()
        {
            var model = new LoginModel
            {
                UserName = "invaliduser",
                Password = "password"
            };
            authorizeProvider.Stub(s => s.Login(model.UserName, model.Password)).Return(false);

            var actual = adminController.Login(model, "/");

            Assert.IsInstanceOf<ViewResult>(actual);
            var modelStateErrors = adminController.ModelState[""].Errors;
            Assert.IsTrue(modelStateErrors.Count > 0);
            Assert.AreEqual("The user name or password provided is incorrect.", modelStateErrors[0].ErrorMessage);
        }

        [Test]
        public void LoginPostUser_Valid_Test()
        {
            var model = new LoginModel
            {
                UserName = "validuser",
                Password = "password"
            };
            authorizeProvider.Stub(s => s.Login(model.UserName, model.Password)).Return(true);

            var actual = adminController.Login(model, "/");

            Assert.IsInstanceOf<RedirectResult>(actual);
            Assert.AreEqual("/", ((RedirectResult)actual).Url);
        }
    }
}
