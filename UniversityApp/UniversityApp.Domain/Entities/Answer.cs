namespace UniversityApp.Domain.Entities
{
    public sealed class Answer : BaseEntity<int>
    { 
        public string Text { get; set; }

        public bool Correct { get; set; }

        //NAVIGATION PROPERTIES
        public int QuestionId { get; set; }

        public Question Question { get; set; }
    }
}
