using CityData.Infrastructure.Context;
using CityData.Infrastructure.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CityData.Infrastructure.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly CityDataContext _context;

        public Repository(CityDataContext context)
        {
            _context = context;
        }

        public async Task<T> GetAsNoTracking(Expression<Func<T, bool>> predicate)
        {
            return await _context.Set<T>().AsNoTracking().SingleOrDefaultAsync(predicate);
        }

        public async void Delete(T entity)
        {
            _context.Set<T>().Remove(entity);

            await _context.SaveChangesAsync();
        }

        public async void Insert(T entity)
        {
            _context.Set<T>().Add(entity);

            await _context.SaveChangesAsync();
        }

        public async void Update(T entity)
        {
            _context.Set<T>().Update(entity);

            await _context.SaveChangesAsync();
        }

        public IQueryable<T> Get(Expression<Func<T, bool>> filter)
        {
            return _context.Set<T>().Where(filter);
        }
    }
}
