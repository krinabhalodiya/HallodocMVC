using System.ComponentModel.DataAnnotations;

namespace HallodocMVC.Models
{
    public class ViewDataBusinessRequest
    {
        [Required(ErrorMessage = "FirstName Is Required!")]
        public required string BUP_FirstName { get; set; }
        [Required(ErrorMessage = "LastName Is Required!")]
        public required string BUP_LastName { get; set; }
        [Required(ErrorMessage = "PhoneNumber Is Required!")]
        [RegularExpression(@"([0-9]{10})", ErrorMessage = "Please enter 10 digits for a contact number")]
        public required string BUP_PhoneNumber { get; set; }
        [Required(ErrorMessage = "Email Is Required!")]
        [EmailAddress(ErrorMessage = "Please Enter Valid Email Address!")]
        public required string BUP_Email { get; set; }
        public string? BUP_PropertyName { get; set; }
        public string? BUP_CaseNumber { get; set; }
        public string Id { get; set; } = null!;
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
        [Required(ErrorMessage = "PhoneNumber Is Required!")]
        [RegularExpression(@"([0-9]{10})", ErrorMessage = "Please enter 10 digits for a contact number")]
        public required string PhoneNumber { get; set; }
        [Required(ErrorMessage = "Street Is Required!")]
        public string? Street { get; set; }
        [Required(ErrorMessage = "City Is Required!")]
        public string? City { get; set; }
        [Required(ErrorMessage = "State Is Required!")]
        public string? State { get; set; }
        [Required(ErrorMessage = "ZipCode Is Required!")]
        public string? ZipCode { get; set; }
        public string? RoomSite { get; set; }
        public IFormFile? UploadFile { get; set; }
        public string? UploadImage { get; set; }
    }
}