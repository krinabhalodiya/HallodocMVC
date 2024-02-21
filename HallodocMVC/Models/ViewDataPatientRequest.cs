using System.ComponentModel.DataAnnotations;

namespace HallodocMVC.Models
{
    public class ViewDataPatientRequest
    {
        public string Id { get; set; }
        public string Symptoms { get; set; }
        [Required(ErrorMessage = "FirstName Is Required!")]
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        [Required(ErrorMessage = "Email Is Required!")]
        [EmailAddress(ErrorMessage = "Please Enter Valid Email Address!")]
        public string Email { get; set; }
        [Compare("PassWord", ErrorMessage = "Password and confirm password must match")]
        public string RePassWord { get; set; }
        public string PassWord { get; set; }
        public DateTime BirthDate { get; set; }
        [Required(ErrorMessage = "PhoneNumber Is Required!")]
        [RegularExpression(@"([0-9]{10})", ErrorMessage = "Please enter 10 digits for a contact number")]
        public string PhoneNumber { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
        public string RoomSite { get; set; }
        public string? UploadImage { get; set; }
        public IFormFile? UploadFile { get; set; }
        public string FF_RelationWithPatient { get; set; }

    }
}
