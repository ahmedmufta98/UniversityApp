using System.ComponentModel.DataAnnotations;

namespace UniversityApp.Application.Models
{
    public class Answer
    {
        public int Id { get; set; }

        [Required]
        public string Text { get; set; }

        [Required]
        public bool Correct { get; set; }

        [Required]
        public int QuestionId { get; set; }
    }
}
