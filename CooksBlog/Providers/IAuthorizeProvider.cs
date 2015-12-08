// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IAuthorizeProvider.cs" company="HotR">
//   2015
// </copyright>
// <summary>
//   The Authorize Provider Interface
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace CooksBlog.Providers
{
    public interface IAuthorizeProvider
    {
        bool IsLoggedIn { get; }

        bool Login(string userName, string password);

        void Logout();
    }
}