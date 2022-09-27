using System.ComponentModel.DataAnnotations;
using UniversityApp.Domain.Enums;

namespace UniversityApp.Application.Models
{
    public class Subject
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public StudyYear StudyYear { get; set; }

        [Required]
        public int ECTS { get; set; }
    }
}
