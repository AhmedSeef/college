using college.Database;
using college.Models;
using college.Repository.Contract;
using college.Repository.Implementation.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace college.BL.Implementation
{
    public class CourseRepository : Repository<Course>, ICourseRepository
    {
        private readonly ColeegeDataContext _context;
        public CourseRepository(ColeegeDataContext context) : base(context)
        {
            this._context = context;
        }
    }
}
