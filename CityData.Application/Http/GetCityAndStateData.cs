using CityData.Application.Extensions;
using CityData.Domain.Models;
using HtmlAgilityPack;
using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CityData.Application.Http
{
    public class GetCityAndStateData
    {
        public string IBGEUrl = @"https://www.ibge.gov.br/cidades-e-estados/";

        public async Task<State> GetStateData(string UF)
        {
            HttpClient httpClient = GetHttpClientInstance(UF);

            string response = await httpClient.GetStringAsync(httpClient.BaseAddress);

            HtmlDocument htmlDocument = new HtmlDocument();
            htmlDocument.LoadHtml(response);

            State state = new State();

            var htmlElements = htmlDocument.DocumentNode.Descendants("p");
            bool GetNextValue = false;

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

            City city = new City();

            var htmlElements = htmlDocument.DocumentNode.Descendants("p");
            bool GetNextValue = false;

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

        private async Task<HtmlDocument> GetHtmlPage(string UF, string cityName)
        {
            HttpClient httpClient = GetHttpClientInstance(UF, cityName);
            string response = await httpClient.GetStringAsync(httpClient.BaseAddress);

            HtmlDocument htmlDocument = new HtmlDocument();
            htmlDocument.LoadHtml(response);

            return htmlDocument;
        }

        private HttpClient GetHttpClientInstance(string UF, string city = "")
        {
            var httpHandler = new HttpClientHandler();
            httpHandler.AllowAutoRedirect = true;
            httpHandler.CookieContainer = new CookieContainer();
            httpHandler.UseCookies = true;

            var httpClient = new HttpClient(httpHandler);
            string cityNameWithDash = city.ChangeSpaceForDash();

            string url = IBGEUrl + $"{UF}/{cityNameWithDash}";
            httpClient.BaseAddress = new Uri(url);

            return httpClient;
        }
    }
}
