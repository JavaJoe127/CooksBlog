// --------------------------------------------------------------------------------------------------------------------
// <copyright file="LoginModel.cs" company="HotR">
//   2015
// </copyright>
// <summary>
//   The Login Model
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace CooksBlog.Models
{
    using System.ComponentModel.DataAnnotations;

    public class LoginModel
    {
        [Required(ErrorMessage = "User name is required")]
        [Display(Name = "User name (*)")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [Display(Name = "Password (*)")]
        public string Password { get; set; }
    }
}