using WebApplication1.Models;
using System.Data;

namespace WebApplication1.Models
{
    public class User
    {
        public string? Id { get; set; }

        public string? UserName { get; set; }

        public string? Email { get; set; }

        public string? Password { get; set; }

        public string? PhoneNumber { get; set; }
    }
}
