namespace HallodocMVC.Models
{
    public class ViewDataBusinessRequest
    {
        public string BUP_FirstName { get; set; }
        public string BUP_LastName { get; set; }
        public string BUP_PhoneNumber { get; set; }
        public string BUP_Email { get; set; }
        public string BUP_PropertyName { get; set; }
        public string BUP_CaseNumber { get; set; }
        public string Id { get; set; } = null!;
        public string Symptoms { get; set; }
        public string FirstName { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
        public string RoomSite { get; set; }
        public IFormFile? UploadFile { get; set; }
        public string UploadImage { get; set; }
    }
}
