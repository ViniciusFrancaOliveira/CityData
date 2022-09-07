using CityData.Application.Extensions;
using CityData.Domain.Models;
using HtmlAgilityPack;
using System.Threading.Tasks;

namespace CityData.Application.Http
{
    public class GetCityAndStateData : IBGEPageAcess
    {
       

        public async Task<State> GetStateData(string UF)
        {
            HtmlDocument htmlDocument = await GetHtmlPage(UF);
            var htmlElements = htmlDocument.DocumentNode.Descendants("p");

            bool GetNextValue = false;
            State state = new State();
            foreach (var htmlElement in htmlElements)
            {
                if (GetNextValue)
                {
                    state.Population = htmlElement.InnerText.GetAndCleanNumbers();
                }
                if (htmlElement.InnerText == "População estimada")
                {
                    GetNextValue = true;
                    continue;
                }

                GetNextValue = false;
            }

            return state;
        }

        public async Task<City> GetCityData(string UF, string cityName)
        {
            HtmlDocument htmlDocument = await GetHtmlPage(UF, cityName);
            var htmlElements = htmlDocument.DocumentNode.Descendants("p");

            bool GetNextValue = false;
            City city = new City();

            foreach (var htmlElement in htmlElements)
            {
                if (GetNextValue)
                {
                    city.Population = htmlElement.InnerText.GetAndCleanNumbers();
                }
                if (htmlElement.InnerText == "População estimada")
                {
                    GetNextValue = true;
                    continue;
                }

                GetNextValue = false;
            }

            return city;
        }


    }
}
