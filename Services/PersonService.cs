using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using person_management_system.DTOs;

namespace person_management_system.Services
{

    public class PersonService
    {
        private readonly AppDbContext _context;

        public PersonService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Models.Person> AddPersonAsync(PersonCreateDto personData)
        {
            var person = new Models.Person
            {
                FirstName = personData.FirstName,
                LastName = personData.LastName,
                BirthDate = personData.BirthDate
            };

            _context.Persons.Add(person);
            await _context.SaveChangesAsync();

            return person;
        }
    }
}