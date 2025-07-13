using System.ComponentModel.DataAnnotations;

namespace Public.WEB.Models.Authentication
{
    public class LoginRequest
    {
        [Required]
        public string EmailOrUsername { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
