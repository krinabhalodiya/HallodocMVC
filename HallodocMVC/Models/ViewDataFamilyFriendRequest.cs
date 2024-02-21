using System.ComponentModel.DataAnnotations;

namespace HallodocMVC.Models
{
    public class ViewDataFamilyFriendRequest
    {
        [Required(ErrorMessage = "FirstName Is Required!")]
        public string FF_FirstName { get; set; }

        [Required(ErrorMessage = "LastName Is Required!")]
        public string FF_LastName { get; set; }

        [Required(ErrorMessage = "PhoneNumber Is Required!")]
        [RegularExpression(@"([0-9]{10})", ErrorMessage = "Please enter 10 digits for a contact number")]
        public string FF_PhoneNumber { get; set; }

        [Required(ErrorMessage = "Email Is Required!")]
        [EmailAddress(ErrorMessage = "Please Enter Valid Email Address!")]
        public string FF_Email { get; set; }

        [Required(ErrorMessage = "Relation With Patient Is Required!")]
        public string FF_RelationWithPatient { get; set; }

        public string Id { get; set; } = null!;

        [Required(ErrorMessage = "Symptoms Is Required!")]
        public string Symptoms { get; set; }

        [Required(ErrorMessage = "FirstName Is Required!")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "LastName Is Required!")]
        public string LastName { get; set; }

        public DateTime BirthDate { get; set; }

        [Required(ErrorMessage = "Email Is Required!")]
        [EmailAddress(ErrorMessage = "Please Enter Valid Email Address!")]
        public string Email { get; set; }

        [Required(ErrorMessage = "PhoneNumber Is Required!")]
        [RegularExpression(@"([0-9]{10})", ErrorMessage = "Please enter 10 digits for a contact number")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Street Is Required!")]
        public string Street { get; set; }

        [Required(ErrorMessage = "City Is Required!")]
        public string City { get; set; }

        [Required(ErrorMessage = "State Is Required!")]
        public string State { get; set; }

        [Required(ErrorMessage = "ZipCode Is Required!")]
        public string ZipCode { get; set; }

        public string RoomSuite { get; set; }

        public IFormFile? UploadFile { get; set; }

        public string UploadImage { get; set; }
    }
}