using PharmacyDB.Models;
using PharmacyDB.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmacyInfrastructure.Repositories
{
    public class ExamQuestionRepository : GenericRepository<ExamQuestion> , IExamQuestionRepository
    {
        public ExamQuestionRepository(PharmacyDbContext context) : base(context)
        {

        }
    }
}
