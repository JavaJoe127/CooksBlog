// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AuthorizeProvider.cs" company="HotR">
//   2015
// </copyright>
// <summary>
//   The Authorize Provider class
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace CooksBlog.Providers
{
    using System.Web;
    using System.Web.Security;

    public class AuthorizeProvider : IAuthorizeProvider
    {
        public bool IsLoggedIn
        {
            get
            {
                return HttpContext.Current.User.Identity.IsAuthenticated;
            }
        }

        public bool Login(string userName, string password)
        {
            bool result = Membership.ValidateUser(userName, password);

            if (result)
            {
                FormsAuthentication.SetAuthCookie(userName, false);
            }

            return result;
        }

        public void Logout()
        {
            FormsAuthentication.SignOut();
        }
    }
}