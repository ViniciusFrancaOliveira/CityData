using CityData.Application.Extensions;
using HtmlAgilityPack;
using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace CityData.Application.Http
{
    public class IBGEPageAcess
    {
        private readonly string IBGEUrl = @"https://www.ibge.gov.br/cidades-e-estados/";

        protected async Task<HtmlDocument> GetHtmlPage(string UF, string cityName = "")
        {
            HttpClient httpClient = GetHttpClientInstance(UF, cityName);
            string response = await httpClient.GetStringAsync(httpClient.BaseAddress);

            HtmlDocument htmlDocument = new HtmlDocument();
            htmlDocument.LoadHtml(response);

            return htmlDocument;
        }

        protected HttpClient GetHttpClientInstance(string UF, string cityName = "")
        {
            var httpHandler = new HttpClientHandler();
            httpHandler.AllowAutoRedirect = true;
            httpHandler.CookieContainer = new CookieContainer();
            httpHandler.UseCookies = true;

            var httpClient = new HttpClient(httpHandler);
            string cityNameWithDash = cityName.ChangeSpaceForDash();

            string url = IBGEUrl + $"{UF}/{cityNameWithDash}";
            httpClient.BaseAddress = new Uri(url);

            return httpClient;
        }
    }
}
