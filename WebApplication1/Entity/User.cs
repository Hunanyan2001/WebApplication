﻿using System.Data;

namespace WebApplication1.Entity
{
    public class User
    {
        public int Id { get; set; }

        public string? UserName { get; set; }

        public string? Email { get; set; }

        public string? Password { get; set; }

        public string? PhoneNumber { get; set; }
    }
}