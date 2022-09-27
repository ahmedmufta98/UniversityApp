using UniversityApp.Domain.Enums;

namespace UniversityApp.Domain.Entities
{
    public sealed class Subject : BaseEntity<int>
    {
        public string Name { get; set; }

        public StudyYear StudyYear { get; set; }

        public int ECTS { get; set; }

        //NAVIGATION PROPERTIES
        public int ProfessorId { get; set; }

        public Professor Professor { get; set; }

        public List<Exam> Exams { get; set; }
    }
}
