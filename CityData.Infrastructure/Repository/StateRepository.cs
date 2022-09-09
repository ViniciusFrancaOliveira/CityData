using CityData.Domain.Models;
using CityData.Infrastructure.Context;
using CityData.Infrastructure.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace CityData.Infrastructure.Repository
{
    public class StateRepository : Repository<State>, IStateRepository
    {
        public StateRepository(CityDataContext context) : base(context)
        {
        }

        public IEnumerable<State> GetStateWithCities(Expression<Func<State, bool>> expression)
        {
            return Get(expression).Include(state => state.Cities);
        }
    }
}
