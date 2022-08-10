using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CityData.Web.Controllers
{
    [Route("[Controller]")]
    [ApiController]
    public class StateController : ControllerBase
    {
        public StateController()
        { 
        }

        [HttpGet]
        public IActionResult GetStateByName()
        {
            return NotFound();
        }

        [HttpGet]
        public IActionResult GetStateByUF()
        {
            return NotFound();
        }
    }
}
