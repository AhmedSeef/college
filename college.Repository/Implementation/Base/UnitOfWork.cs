using college.BL.Implementation;
using college.Database;
using college.Repository.Contract;
using college.Repository.Contract.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace college.Repository.Implementation.Base
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ColeegeDataContext _context;
        public UnitOfWork(ColeegeDataContext context)
        {
            this._context = context;
        }
        public IUserRepository userRepository { get; }
        public IUserRepository UserRepository => userRepository ?? new UserRepository(_context);

        public ICourseRepository courseRepository { get; }
        public ICourseRepository CourseRepository => courseRepository ?? new CourseRepository(_context);

        public IStudentRepository studentRepository { get; }
        public IStudentRepository StudentRepository => studentRepository ?? new StudentRepository(_context);

        public ITeacherRepository teacherRepository { get; }
        public ITeacherRepository TeacherRepository => teacherRepository ?? new TeacherRepository(_context);

        public ISubjectRepository subjectRepository { get; }
        public ISubjectRepository SubjectRepository => subjectRepository ?? new SubjectRepository(_context);

        public async Task<bool> complete()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
