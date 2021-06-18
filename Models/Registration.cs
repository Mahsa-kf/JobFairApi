using System;

namespace JobFairApi.Models
{
    public class Registration
    {
        public int? RegistrationID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Website { get; set; }
        public string UserTyple { get; set; }
    }
}