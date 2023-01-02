using college.BL.Contract;
using college.Models;
using college.Repository.Contract.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace college.BL.Implementation
{
    public class UserBL : IUserBL
    {
        private readonly IRepository<User> _repository;
        private readonly IUnitOfWork _unitOfWork;
        public UserBL(IUnitOfWork unitOfWork, IRepository<User> repository) 
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }
        #region Login
        public async Task<User> Login(string name, string password)
        {
            var user = await _unitOfWork.UserRepository.GetWhere(x=>x.UserName == name);
            if (user == null)
                return null;
            var userData = user.FirstOrDefault();
            if (!VerifyPasswordHash(password, userData.PasswordHash, userData.PasswordSalt))
                return null;
            return userData;
        }

        private bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512(passwordSalt))
            {
                var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
                for (int i = 0; i < computedHash.Length; i++)
                {
                    if (computedHash[i] != passwordHash[i]) return false;
                }
                return true;
            }
        }

        #endregion
        #region user regiset
        public async Task<bool> Register(User User, string Password)
        {
            CreatePasswordHash(Password, out var passwordHash, out var passwordSalt);

            User.PasswordHash = passwordHash;
            User.PasswordSalt = passwordSalt;

            _unitOfWork.UserRepository.Insert(User);

            return await _unitOfWork.complete();
        }       

        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
            }

        }

        #endregion
    }
}
