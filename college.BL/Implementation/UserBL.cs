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
    }
}
