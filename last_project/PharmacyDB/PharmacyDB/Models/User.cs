using System;
using System.Collections.Generic;

namespace PharmacyDB.Models
{
    public partial class User
    {
        public User()
        {
            UserExams = new HashSet<UserExam>();
        }

        public int Id { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string MobileNumber { get; set; } = null!;
        public string City { get; set; } = null!;
        public string StreetNumber { get; set; } = null!;

        public virtual ICollection<UserExam> UserExams { get; set; }
    }
}
