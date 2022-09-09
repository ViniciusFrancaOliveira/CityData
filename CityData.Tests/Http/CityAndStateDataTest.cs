using CityData.Application.Http;
using CityData.Domain.Models;
using System.Threading.Tasks;
using Xunit;

namespace CityData.Tests.Http
{
    public class CityAndStateDataTest
    {
        [Theory]
        [InlineData("BA", "Salvador")]
        [InlineData("RS", "Porto Alegre")]
        public async Task Get_City_Data_Successifuly(string UF, string city)
        {
            var getCityData = new CityAndStateData();
            City cityData = await getCityData.GetCityData(UF, city);

            Assert.True(cityData.Population > 0);
        }

        [Theory]
        [InlineData("BA")]
        [InlineData("RS")]
        public async Task Get_State_Data_Successifuly(string UF)
        {
            var getStateData = new CityAndStateData();
            State stateData = await getStateData.GetStateData(UF);

            Assert.True(stateData.Population > 0);
            Assert.True(stateData.TerritorialArea > 0);
            Assert.True(stateData.HDI > 0);
            Assert.Equal(stateData.UF, UF);
            Assert.NotNull(stateData.Ethnic);
        }
    }
}
