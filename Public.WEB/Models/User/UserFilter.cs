﻿namespace Public.WEB.Models.User
{
    public class UserFilter
    {
        public string? Search { get; set; }

        public string? EmploymentType { get; set; }

        public string? UserType { get; set; }

        public int PageNumber { get; set; } = 1;

        public int PageSize { get; set; } = 10;

        public string? SortBy { get; set; }

        public bool SortDescending { get; set; } = false;
    }
}
