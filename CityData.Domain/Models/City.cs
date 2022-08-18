using System;

namespace CityData.Domain.Models
{
    public class City : BaseEntity
    {
        public string Name { get; set; }
        public int Population { get; set; }
        public string CityCode { get; set; }
        public State State { get; set; }
    }
}
