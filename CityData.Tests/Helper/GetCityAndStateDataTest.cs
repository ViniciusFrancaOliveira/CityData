using CityData.Application.Helper;
using CityData.Domain.Models;
using System.Threading.Tasks;
using Xunit;

namespace CityData.Tests.Helper
{
    public class GetCityAndStateDataTest
    {
        private string IBGEUrl;

        public GetCityAndStateDataTest(string IBGEUrl)
        {
            this.IBGEUrl = IBGEUrl;
        }

        [Theory]
        [InlineData("BA", "Salvador")]
        [InlineData("CE", "Fortaleza")]
        [InlineData("RS", "Porto Alegre")]
        public async Task Get_City_Data_Successifuly(string UF, string city)
        {
            var getCityData = new GetCityAndStateData(IBGEUrl);
            City cityData = await getCityData.GetCityData(UF, city);
        }
    }
}
