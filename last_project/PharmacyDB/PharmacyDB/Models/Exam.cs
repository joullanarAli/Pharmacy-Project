﻿using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace PharmacyDB.Models
{
    public partial class Exam
    {
        public Exam()
        {
            ExamQuestions = new HashSet<ExamQuestion>();
            UserExams = new HashSet<UserExam>();
        }
        [JsonIgnore]
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public DateTime ExamDate { get; set; }
        [JsonIgnore]
        public virtual ICollection<ExamQuestion> ExamQuestions { get; set; }
        [JsonIgnore]
        public virtual ICollection<UserExam> UserExams { get; set; }
    }
}
