using CityData.Application.Extensions;
using CityData.Domain.Models;
using HtmlAgilityPack;
using System.Threading.Tasks;
using CityData.Application.Helper;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.Linq;

namespace CityData.Application.Http
{
    public class CityAndStateData : IBGEPageAcess
    {
        public async Task<State> GetStateData(string UF)
        {
            HtmlDocument htmlDocument = await GetHtmlPage(UF);
            var htmlElements = htmlDocument.DocumentNode.Descendants("p");

            bool getNextValue = false;
            bool isValueNumber = false;
            string valueToGetName = "";

            var stateDataToDeserialize = new Dictionary<string, object>();
            stateDataToDeserialize.Add("UF", UF);

            foreach (var htmlElement in htmlElements)
            {
                if (CityAndStateDataDictionary.CityAndStateData.ContainsKey(htmlElement.InnerText))
                {
                    valueToGetName = CityAndStateDataDictionary.CityAndStateData[htmlElement.InnerText];
                    getNextValue = true;
                    continue;
                }
                if (getNextValue)
                {
                    isValueNumber = htmlElement.InnerText.Any(char.IsDigit);
                    if (isValueNumber)
                    {
                        double valueToAdd = htmlElement.InnerText.GetAndCleanNumbers();
                        bool isInt = valueToAdd.IsInteger();

                        if (isInt)
                        {
                            stateDataToDeserialize.Add(valueToGetName, (int)valueToAdd);
                        }
                        else
                        {
                            stateDataToDeserialize.Add(valueToGetName, valueToAdd);
                        }
                    }
                    else
                    {
                        stateDataToDeserialize.Add(valueToGetName, htmlElement.InnerText);
                    }
                    valueToGetName = "";
                }
                getNextValue = false;
            }

            string stateDataInJson = JsonConvert.SerializeObject(stateDataToDeserialize);
            State state = JsonConvert.DeserializeObject<State>(stateDataInJson);

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
                    city.Population = (int)htmlElement.InnerText.GetAndCleanNumbers();
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
