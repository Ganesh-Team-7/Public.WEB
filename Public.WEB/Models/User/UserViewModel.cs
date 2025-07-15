namespace Public.WEB.Models.User
{
    public class UserViewModel
    {
        public int UserId { get; set; }

        public string FirstName { get; set; } = string.Empty;

        public string LastName { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        public string PhoneNumber { get; set; } = string.Empty;

        public string EmploymentType { get; set; } = string.Empty;

        public string UserType { get; set; } = string.Empty;

        public DateTime CreatedAt { get; set; }

        public string CreatedAtFormatted => CreatedAt.ToString("yyyy-MM-dd HH:mm");
    }
}
