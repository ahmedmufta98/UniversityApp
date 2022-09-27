namespace UniversityApp.Domain.Entities
{
    public sealed class Question : BaseEntity<int>
    {
        public string Text { get; set; }

        public int Points { get; set; }

        //NAVIGATION PROPERTIES
        public int SubjectId { get; set; }

        public Subject Subject { get; set; }

        public List<Answer> Answers { get; set; }

        public List<ExamStudentQuestion> ExamStudentQuestions { get; set; }
    }
}
