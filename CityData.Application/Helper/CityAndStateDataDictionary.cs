using System;
using System.Collections.Generic;
using System.Text;

namespace CityData.Application.Helper
{
    public static class CityAndStateDataDictionary
    {
        public static Dictionary<string, string> CityAndStateData = new Dictionary<string, string>()
        {
            { "Área Territorial", "TerritorialArea"},
            { "População estimada", "Population"},
            { "IDHM", "HDI"},
            { "IDH Índice de desenvolvimento humano", "HDI"},
            { "Gent&iacute;lico", "Ethnic"}
        };
    }
}
