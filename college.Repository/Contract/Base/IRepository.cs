using college.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace college.Repository.Contract.Base
{
    public interface IRepository<T> where T : BaseModel, new()
    {
        Task<T> GetById(int id);
        Task<IEnumerable<T>> GetAll();
        IEnumerable<T> Include(params Expression<Func<T, object>>[] includes);
        Task<IEnumerable<T>> GetWhere(Expression<Func<T, bool>> predicate);
        Task<bool> CheckExit(Expression<Func<T, bool>> predicate);
        void Insert(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
