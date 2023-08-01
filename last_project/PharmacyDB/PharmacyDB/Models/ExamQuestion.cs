using System;
using System.Collections.Generic;

namespace PharmacyDB.Models
{
    public partial class ExamQuestion
    {
        public ExamQuestion()
        {
            UserQuestions = new HashSet<UserQuestion>();
        }

        public int Id { get; set; }
        public int ExamId { get; set; }
        public int QuestionId { get; set; }

        public virtual Exam Exam { get; set; } = null!;
        public virtual Question Question { get; set; } = null!;
        public virtual ICollection<UserQuestion> UserQuestions { get; set; }
    }
}
