namespace UniversityApp.Domain.Entities
{
    public sealed class Role : BaseEntity<string>
    { 
        public string Description { get; set; }

        //NAVIGATION PROPERTIES
        public List<User> Users { get; set; }
    }
}
