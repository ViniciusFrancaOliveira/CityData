using CityData.Infrastructure.Context;
using CityData.Infrastructure.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace CityData.Infrastructure.Repository
{
    public class Repository : IRepository
    {
        private readonly CityDataContext Context;

        public Repository(CityDataContext context)
        {
            Context = context;
        }

        public
    }
}
