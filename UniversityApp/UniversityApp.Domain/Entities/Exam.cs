namespace UniversityApp.Domain.Entities
{
    public sealed class Exam : BaseEntity<int>
    {
        public DateTime Date { get; set; }

        public string Location { get; set; }

        public int Duration { get; set; }

        //NAVIGATION PROPERTIES
        public int SubjectId { get; set; }

        public Subject Subject { get; set; }

        public int UserId { get; set; } //USER ID WHO ADDS EXAM.

        public User User { get; set; }

        public List<ExamStudentQuestion> ExamStudentQuestions { get; set; }
    }
}
