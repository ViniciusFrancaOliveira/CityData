using System.Threading.Tasks;

namespace CityData.Infrastructure.Repository.Interfaces
{
    public interface IRepository<T>
    {
        public Task<T> GetById(int id);
    }
}
