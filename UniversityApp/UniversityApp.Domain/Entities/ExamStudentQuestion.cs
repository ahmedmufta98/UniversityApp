﻿namespace UniversityApp.Domain.Entities
{
    public sealed class ExamStudentQuestion
    {
        public int ExamId { get; set; }

        public Exam Exam { get; set; }

        public int StudentId { get; set; }

        public Student Student { get; set; }

        public int QuestionId { get; set; }

        public Question Question { get; set; }
    }
}
