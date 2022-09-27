namespace UniversityApp.Domain.Entities
{
    public sealed class Student : BaseEntity<int>
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string UniqueIdentificator { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        public string Address { get; set; }

        public DateTime BirthDate { get; set; }

        public string IndexNumber { get; set; }

        public string ParentName { get; set; }

        public List<ExamStudentQuestion> ExamStudentQuestions { get; set; }
    }
}
