using System.ComponentModel.DataAnnotations;
using System.Text.Json;
using UniversityApp.Domain.Enums;

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
