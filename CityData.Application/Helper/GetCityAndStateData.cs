using CityData.Domain.Models;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace CityData.Application.Helper
{
    public class GetCityAndStateData
    {
        public string IBGEUrl = @"https://www.ibge.gov.br/cidades-e-estados/";
        public GetCityAndStateData(string IBGEUrl)
        {
            this.IBGEUrl = IBGEUrl;
        }
        public async Task<State> GetStateData(string UF)
        {
            var httpHandler = new HttpClientHandler();
            httpHandler.AllowAutoRedirect = true;
            httpHandler.CookieContainer = new CookieContainer();
            httpHandler.UseCookies = true;

            var httpClient = new HttpClient(httpHandler);
            httpClient.BaseAddress = new Uri(IBGEUrl);
            var responseMessage = new HttpResponseMessage();

            responseMessage = await httpClient.GetAsync(UF);

            return new State(UF);
        }

        public async Task<City> GetCityData(string UF, string city)
        {
            var httpHandler = new HttpClientHandler();
            httpHandler.AllowAutoRedirect = true;
            httpHandler.CookieContainer = new CookieContainer();
            httpHandler.UseCookies = true;

            var httpClient = new HttpClient(httpHandler);

            string cityNameWithDash = GetCityNameWithDash(city);
            string url = IBGEUrl + $"/{UF}" + $"/{cityNameWithDash}";
            httpClient.BaseAddress = new Uri(url);

            var responseMessage = new HttpResponseMessage();

            responseMessage = await httpClient.GetAsync(UF);

            return new City();
        }

        private string GetCityNameWithDash(string city)
        {
            return city.Trim().Replace(" ", "-");
        }
    }
}
