using System.ComponentModel.DataAnnotations;

namespace UniversityApp.Application.Models
{
    public class Exam
    {
        public int Id { get; set; }

        [Required] 
        public DateTime Date { get; set; }

        [Required]
        public string Location { get; set; }

        [Required]
        public int Duration { get; set; }

        [Required]
        public int SubjectId { get; set; }

        [Required]
        public int UserId { get; set; }
    }
}
