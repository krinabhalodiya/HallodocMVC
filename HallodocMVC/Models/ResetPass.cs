using System.ComponentModel.DataAnnotations;

namespace HallodocMVC.Models
{
    public class ResetPass
    {
        public required string email { get; set; }
        public required string Password { get; set; }
        [Compare("Password", ErrorMessage = "Password and confirm password must match")]
        public required string confirmpassword { get; set; }
    }
}
