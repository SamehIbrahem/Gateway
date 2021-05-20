using GatewayTask.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace GatewayTask.Repo.Data
{
    public interface IRepository<T>
    {
        Task<T> Get(int id, params Expression<Func<T, object>>[] includes);
        Task<T> Insert(T entity);
        Task<T> Update(T entity);
        Task<T> Delete(T entity);
        IQueryable<T> AsQueryable();
        Task<List<T>> GetAll(params Expression<Func<T, object>>[] includes);
    }
}
