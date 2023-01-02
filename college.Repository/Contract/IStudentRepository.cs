using college.Models;
using college.Repository.Contract.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace college.Repository.Contract
{
    public interface IStudentRepository : IRepository<Student>
    {
    }
}
