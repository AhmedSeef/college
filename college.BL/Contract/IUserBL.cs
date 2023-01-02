using college.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace college.BL.Contract
{
    public interface IUserBL
    {
        Task<bool> Register(User User, string Password);       
        Task<User> Login(string name, string password);
    }
}
