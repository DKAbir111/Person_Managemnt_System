namespace person_management_system.Controllers
{

    using Microsoft.AspNetCore.Mvc;

    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> Get()
        {

            return Ok();
        }
    }
}