using college.Database;
using college.Models;
using college.Repository.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace college.Repository.Implementation
{
    public class UserRepository : IUserRepository
    {
        private ColeegeDataContext db = new ColeegeDataContext();
        public List<User> Users()
        {
            return db.Users.ToList();
        }
    }
}
