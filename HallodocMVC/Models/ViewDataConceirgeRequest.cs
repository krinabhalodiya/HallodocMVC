using System.ComponentModel.DataAnnotations;
namespace HallodocMVC.Models
{
    public class ViewDataConceirgeRequest
    {
        [Required(ErrorMessage = "FirstName Is Required!")]
        public required string CON_FirstName { get; set; }
        [Required(ErrorMessage = "LastName Is Required!")]
        public required string CON_LastName { get; set; }
        [Required(ErrorMessage = "PhoneNumber Is Required!")]
        [RegularExpression(@"([0-9]{10})", ErrorMessage = "Please enter 10 digits for a contact number")]
        public required string CON_PhoneNumber { get; set; }
        [Required(ErrorMessage = "Email Is Required!")]
        [EmailAddress(ErrorMessage = "Please Enter Valid Email Address!")]
        public required string CON_Email { get; set; }
        public string? CON_PropertyName { get; set; }
        public string? Id { get; set; } = null!;
        [Required(ErrorMessage = "Symptoms Is Required!")]
        public required string Symptoms { get; set; }
        [Required(ErrorMessage = "FirstName Is Required!")]
        public required string FirstName { get; set; }
        [Required(ErrorMessage = "LastName Is Required!")]
        public required string LastName { get; set; }
        [Required(ErrorMessage = "BirthDate Is Required!")]
        public DateTime BirthDate { get; set; }
        [Required(ErrorMessage = "Email Is Required!")]
        [EmailAddress(ErrorMessage = "Please Enter Valid Email Address!")]
        public required string Email { get; set; }
        [Required(ErrorMessage = "Phone Number Is Required!")]
        [RegularExpression(@"([0-9]{10})", ErrorMessage = "Please enter 10 digits for a contact number")]
        public required string PhoneNumber { get; set; }
        [Required(ErrorMessage = "Street Is Required!")]
        public required string CON_Street { get; set; }
        [Required(ErrorMessage = "City Is Required!")]
        public required string CON_City { get; set; }
        [Required(ErrorMessage = "State Is Required!")]
        public required string CON_State { get; set; }
        [Required(ErrorMessage = "ZipCode Is Required!")]
        public required string CON_ZipCode { get; set; }
        public string? RoomSuite { get; set; }
        public IFormFile? UploadFile { get; set; }
        public string? UploadImage { get; set; }
    }
}