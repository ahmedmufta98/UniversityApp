using System.ComponentModel.DataAnnotations;

namespace UniversityApp.Application.Models
{
    public class Student
    {
        public int Id { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        [StringLength(13)]
        public string UniqueIdentificator { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [Phone]
        public string Phone { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        public DateTime BirthDate { get; set; }

        [Required]
        public string IndexNumber { get; set; }

        [Required]
        public string ParentName { get; set; }
    }
}
