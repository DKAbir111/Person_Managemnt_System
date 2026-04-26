namespace person_management_system.Controllers
{

    using Microsoft.AspNetCore.Mvc;
    using person_management_system.DTOs;
    using person_management_system.Models;

    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {

        private readonly AppDbContext _context;
        public PersonController(AppDbContext context)
        {
            _context = context;
        }


        [HttpPost]
        public async Task<IActionResult> AddPerson(PersonCreateDto personData)
        {
            try
            {
                var person = new Person
                {
                    FirstName = personData.FirstName,
                    LastName = personData.LastName,
                    BirthDate = personData.BirthDate
                };

                _context.Persons.Add(person);
                await _context.SaveChangesAsync();
                return Ok(person);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}