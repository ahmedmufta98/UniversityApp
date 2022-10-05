using Microsoft.EntityFrameworkCore;
using UniversityApp.Domain.Entities;

namespace UniversityApp.Infrastructure.Persistence
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //FLUENT API -> Create many to many relationship
            modelBuilder.Entity<ExamStudentQuestion>().HasKey(k => new { k.ExamId, k.StudentId, k.QuestionId });
            modelBuilder.Entity<ExamStudentQuestion>().HasOne<Exam>(e => e.Exam).WithMany(e => e.ExamStudentQuestions).HasForeignKey(e => e.ExamId);
            modelBuilder.Entity<ExamStudentQuestion>().HasOne<Student>(s => s.Student).WithMany(s => s.ExamStudentQuestions).HasForeignKey(s => s.StudentId);
            modelBuilder.Entity<ExamStudentQuestion>().HasOne<Question>(q => q.Question).WithMany(q => q.ExamStudentQuestions).HasForeignKey(q => q.QuestionId);

            //Unique constraints on table for users
            modelBuilder.Entity<User>().HasIndex(u => new { u.Email, u.Username }).IsUnique();
        }

        public DbSet<Answer> Answers { get; set; }
        public DbSet<Exam> Exams { get; set; }
        public DbSet<ExamStudentQuestion> ExamStudentQuestions { get; set; }
        public DbSet<Professor> Professors { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<RefreshToken> RefreshTokens { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
