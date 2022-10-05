namespace UniversityApp.Domain.Entities
{
    public sealed class RefreshToken : BaseEntity<int>
    {
        public string Token { get; set; } = string.Empty;

        public DateTime TokenCreated { get; set; }

        public DateTime TokenExpires { get; set; }

        public int UserId { get; set; }

        public User User { get; set; }
    }
}
