using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace college.Repository.Contract.Base
{
    public interface IUnitOfWork : IDisposable
    {
        IUserRepository UserRepository { get; }       
        ICourseRepository CourseRepository { get; }       
        Task<bool> complete();
    }
}
