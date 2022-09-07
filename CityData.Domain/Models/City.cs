using System;
using System.ComponentModel.DataAnnotations;

namespace CityData.Domain.Models
{
    public class City : BaseEntity
    {
        public int CityID { get; set; }
        public string CityName { get; set; }
        public string Ethnic { get; set; }
        public string CityCode { get; set; }
        public int Population { get; set; }
        public int TerritorialArea { get; set; }
        public double HDI { get; set; }
        
        public State State { get; set; }
        public string UF { get => State.UF; }
    }
}
