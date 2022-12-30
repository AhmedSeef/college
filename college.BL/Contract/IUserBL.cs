﻿using college.BL.Contract.Base;
using college.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace college.BL.Contract
{
    public interface IUserBL : IBL<User>
    {
        Task<bool> Register(User User, string Password);
        Task<bool> UserExist(string Name);
        Task<User> Login(string name, string password);
    }
}
