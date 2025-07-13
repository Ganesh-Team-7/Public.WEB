﻿using System.ComponentModel.DataAnnotations;

namespace Public.WEB.Models.Authentication
{
    public class RegisterRequest
    {
        [Required]
        public string Username { get; set; }

        [Required, EmailAddress]
        public string Email { get; set; }

        [Required, DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
