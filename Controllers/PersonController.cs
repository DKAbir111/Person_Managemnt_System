namespace person_management_system.Controllers
{

    using Microsoft.AspNetCore.Mvc;
    using person_management_system.DTOs;
    using person_management_system.Models;
    using person_management_system.Services;

    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly PersonService _personService;
        public PersonController(PersonService personService)
        {
            _personService = personService;
        }


        //  create person
        [HttpPost]
        public async Task<IActionResult> AddPerson(PersonCreateDto personData)
        {
            try
            {
                var result = await _personService.AddPersonAsync(personData);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }



    }
}