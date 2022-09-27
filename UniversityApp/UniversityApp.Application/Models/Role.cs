using System.ComponentModel.DataAnnotations;

namespace UniversityApp.Application.Models
{
    public class Role
    {
        public string Id { get; set; }

        [Required]
        public string Description { get; set; }
    }
}
