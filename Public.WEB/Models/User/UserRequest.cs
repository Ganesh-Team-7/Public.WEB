using System.ComponentModel.DataAnnotations;

namespace Public.WEB.Models.User
{
    public class UserRequest
    {
        [Required]
        public string FirstName { get; set; } = string.Empty;

        [Required]
        public string LastName { get; set; } = string.Empty;

        [Required]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;

        [Required]
        [Phone]
        public string PhoneNumber { get; set; } = string.Empty;

        [Required]
        public string EmploymentType { get; set; } = string.Empty;

        [Required]
        public string UserType { get; set; } = "user"; // admin, staff, user
    }
}
