using System;

namespace CityData.Domain.Models
{
    public class State : BaseEntity
    {
        public string Name { get; set; }
        public string UF { get; set; }
        public int Population { get; set; }
    }
}
