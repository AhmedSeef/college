using college.Database;
using college.Models;
using college.Repository.Contract;
using college.Repository.Implementation.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace college.Repository.Implementation
{
    public class StudentRepository : Repository<Student>, IStudentRepository
    {
        private readonly ColeegeDataContext _context;
        public StudentRepository(ColeegeDataContext context) : base(context)
        {
            this._context = context;
        }
    }
}
