using CityData.Application.Http;
using CityData.Domain.Models;
using System.Threading.Tasks;
using Xunit;

namespace CityData.Tests.Http
{
    public class GetCityAndStateDataTest
    {
        [Theory]
        [InlineData("BA", "Salvador")]
        [InlineData("RS", "Porto Alegre")]
        public async Task Get_City_Data_Successifuly(string UF, string city)
        {
            var getCityData = new GetCityAndStateData();
            City cityData = await getCityData.GetCityData(UF, city);

            Assert.True(cityData.Population > 0);
        }

        [Theory]
        [InlineData("BA")]
        [InlineData("RS")]
        public async Task Get_State_Data_Successifuly(string UF)
        {
            var getStateData = new GetCityAndStateData();
            State stateData = await getStateData.GetStateData(UF);

            Assert.True(stateData.Population > 0);
        }
    }
}
