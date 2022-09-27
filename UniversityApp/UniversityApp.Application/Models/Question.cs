using System.ComponentModel.DataAnnotations;

namespace UniversityApp.Application.Models
{
    public class Question
    {
        public int Id { get; set; }

        [Required]
        public string Text { get; set; }

        [Required]
        public int Points { get; set; }

        [Required]
        public int SubjectId { get; set; }
    }
}
