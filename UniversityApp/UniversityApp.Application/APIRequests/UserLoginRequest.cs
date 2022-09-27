using System.ComponentModel.DataAnnotations;

namespace UniversityApp.Application.APIRequests
{
    public class UserLoginRequest
    {
        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
