using CityData.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace CityData.Infrastructure.Repository.Interfaces
{
    public interface IStateRepository : IRepository<State>
    {
        IEnumerable<State> GetStateWithCities(Expression<Func<State, bool>> expression);
    }
}
