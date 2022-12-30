using college.BL.Contract;
using college.BL.Implementation.Base;
using college.Models;
using college.Repository.Contract.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace college.BL.Implementation
{
    public class UserBL : BL<User>, IUserBL
    {
        private readonly IRepository<User> _repository;
        private readonly IUnitOfWork _unitOfWork;
        public UserBL(IUnitOfWork unitOfWork, IRepository<User> repository) : base(unitOfWork, repository)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        #region user regiset
        public async Task<bool> Register(User User, string Password)
        {
            CreatePasswordHash(Password, out var passwordHash, out var passwordSalt);

            User.PasswordHash = passwordHash;
            User.PasswordSalt = passwordSalt;

            _unitOfWork.UserRepository.Insert(User);

            return await _unitOfWork.complete();
        }

        public async Task<bool> UserExist(string email)
        {
            return await _unitOfWork.UserRepository.UserExist(email);
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
