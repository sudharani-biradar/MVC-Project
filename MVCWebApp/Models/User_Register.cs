using System.ComponentModel.DataAnnotations;
using System.Transactions;

namespace MVCWebApp.Models
{
    public class User_Register
    {
        [Required(ErrorMessage ="Enter Username")]
        [Display(Name="Enter Username")]
        public string Username { get; set; }
        [Required(ErrorMessage = "Enter Password")]
        [Display(Name = "Enter Password")]
        public string Pasword { get; set; }
        [Required(ErrorMessage = "Enter Repassword")]
        [Display(Name = "Enter Repassword")]
        [Compare("Pasword")]
        public string Repassword { get; set; }
        [Required(ErrorMessage = "Enter EmailId")]
        [Display(Name = "Enter EmailId")]
        public string EmailId { get; set; }
        public string Gender { get; set; }

        
    }
}
