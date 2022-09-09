using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace CityData.Infrastructure.Repository.Interfaces
{
    public interface IRepository<T>
    {
        Task<T> GetAsNoTracking(Expression<Func<T, bool>> predicate);
        void Insert(T entity);
        void Update(T entity);
        void Delete(T entity);
        IQueryable<T> Get(Expression<Func<T, bool>> filter);
    }
}
