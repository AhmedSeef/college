using college.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace college.Repository.Contract
{
    public interface IUserRepository
    {
        List<User> Users();
    }
}
