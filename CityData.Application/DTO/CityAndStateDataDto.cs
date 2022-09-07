using System;
using System.Collections.Generic;
using System.Text;

namespace CityData.Application.DTO
{
    public class CityAndStateDataDto
    {
        public string Ethnic { get; set; }
        public string Code { get; set; }
        public int Population { get; set; }
        public int TerritorialArea { get; set; }
        public double HDI { get; set; }
    }
}
