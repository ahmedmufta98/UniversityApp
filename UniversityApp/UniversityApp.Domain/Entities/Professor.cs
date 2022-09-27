namespace UniversityApp.Domain.Entities
{
    public sealed class Professor : BaseEntity<int>
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        public string Address { get; set; }

        public DateTime BirthDate { get; set; }

        public DateTime EmploymentDate { get; set; }

        //NAVIGATION PROPERTIES
        public List<Subject> Subjects { get; set; }
    }
}
