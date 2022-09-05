using CityData.Infrastructure.Context;
using CityData.Infrastructure.Repository.Interfaces;
using System;
using System.Collections.Generic;
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

        public async Task<T> GetById(int id)
        {
            return await _context.Set<T>().FindAsync(id);
        }
    }
}
