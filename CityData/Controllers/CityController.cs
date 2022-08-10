using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CityData.Web.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class CityController : ControllerBase
    {
        public CityController()
        { 
        }

        [HttpGet]
        public IActionResult GetCityByName(string name)
        {
            return NotFound();
        }
    }
}
