namespace person_management_system.Controllers
{

    using Microsoft.AspNetCore.Mvc;
    using person_management_system.DTOs;
    using person_management_system.Models;
    using person_management_system.Services;

    [Route("api/persons")]
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


        //get all persons
        [HttpGet]
        public async Task<IActionResult> GetAllPersons()
        {
            try
            {
                var result = await _personService.GetAllPersonsAsync();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }


        }

        // get person by id
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPersonById(Guid id)
        {
            try
            {
                var result = await _personService.GetPersonByIdAsync(id);
                if (result == null)
                    return NotFound();

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        //delete person by id
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePersonById(Guid id)
        {
            try
            {
                var result = await _personService.DeletePersonAsync(id);

                if (!result)
                    return NotFound();

                return NoContent(); // best practice for DELETE
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        //update person by id
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePersonById(Guid id, PersonCreateDto personData)
        {
            try
            {
                var result = await _personService.UpdatePersonAsync(id, personData);
                if (result == null)
                    return NotFound();

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }


        }
    }
}