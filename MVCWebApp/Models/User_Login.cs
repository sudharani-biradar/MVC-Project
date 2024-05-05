using System.ComponentModel.DataAnnotations;

namespace MVCWebApp.Models
{
    public class User_Login
    {
        [Required(ErrorMessage = "Enter Username")]
        [Display(Name = "Enter Username")]
        public string Username { get; set; }
        [Required(ErrorMessage = "Enter Password")]
        [Display(Name = "Enter Password")]
        public string Pasword { get; set; }
    }
}
