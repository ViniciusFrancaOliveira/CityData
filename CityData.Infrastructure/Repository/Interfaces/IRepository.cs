using System;
using System.Collections.Generic;
using System.Text;

namespace CityData.Infrastructure.Repository.Interfaces
{
    public interface IRepository<T>
    {
        public T GetById(int id);


    }
}
