using System;
using System.Collections.Generic;

namespace CityData.Domain.Models
{
    public class State : BaseEntity
    {
        public int StateID { get; set; }
        public string StateName { get; set; }
        public string Ethnic { get; set; }
        public string StateCode { get; set; }
        public string UF { get; set; }
        public int Population { get; set; }
        public double TerritorialArea { get; set; }
        public double HDI { get; set; }
        public ICollection<City> Cities { get; set; }
    }
}
