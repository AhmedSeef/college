using college.BL.Contract.Base;
using college.Models.Base;
using college.Repository.Contract.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace college.BL.Implementation.Base
{
    public class BL<T> : IBL<T> where T : BaseModel, new()
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<T> _repository;
        public BL(IUnitOfWork unitOfWork,IRepository<T> repository)
        {
            _unitOfWork= unitOfWork;
            _repository= repository;
        }
        public void Delete(T entity)
        {
           _repository.Delete(entity);
            _unitOfWork.complete();
        }

        public async Task<IEnumerable<T>> GetAll()
        {
           return await _repository.GetAll();
        }

        public async Task<T> GetById(int id)
        {
           return await _repository.GetById(id);
        }

        public async Task<IEnumerable<T>> GetWhere(Expression<Func<T, bool>> predicate)
        {
           return  await _repository.GetWhere(predicate);
        }

        public async Task<bool> CheckExit(Expression<Func<T, bool>> predicate)
        {
            return  await _repository.CheckExit(predicate);
        }

        public void Insert(T entity)
        {
            _repository.Insert(entity);
            _unitOfWork.complete();
        }

        public void Update(T entity)
        {
            _repository.Update(entity);
            _unitOfWork.complete();
        }
    }
}
