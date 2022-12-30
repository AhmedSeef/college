using college.Database;
using college.Models;
using college.Repository.Contract;
using college.Repository.Implementation.Base;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace college.Repository.Implementation
{
    public class UserRepository : Repository<User>,IUserRepository
    { 
        private readonly ColeegeDataContext _context;
        public UserRepository(ColeegeDataContext context):base(context)
        {
            this._context = context;
        }

        public async Task<bool> UserExist(string Name)
        {
            return await _context.Users.AnyAsync(x=>x.UserName == Name);
        }
    }
}
