using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using person_management_system.DTOs;
using person_management_system.Models;

namespace person_management_system.Services
{

    public class PersonService
    {
        private readonly AppDbContext _context;

        public PersonService(AppDbContext context)
        {
            _context = context;
        }

        // create a new person
        public async Task<Person> AddPersonAsync(PersonCreateDto personData)
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


        // get all persons
        public async Task<List<PersonGetDto>> GetAllPersonsAsync()
        {
            return await _context.Persons
                .Select(p => new PersonGetDto
                {
                    Id = p.Id,
                    FirstName = p.FirstName,
                    LastName = p.LastName,
                    BirthDate = p.BirthDate,
                    CreatedAt = p.CreatedAt
                })
                .ToListAsync();
        }


        //Find by id
        public async Task<PersonGetDto?> GetPersonByIdAsync(Guid id)
        {
            var person = await _context.Persons.FindAsync(id);
            if (person == null) return null;

            return new PersonGetDto
            {
                Id = person.Id,
                FirstName = person.FirstName,
                LastName = person.LastName,
                BirthDate = person.BirthDate,
                CreatedAt = person.CreatedAt
            };

        }


        //delete person
        public async Task<bool> DeletePersonAsync(Guid id)
        {
            var person = await _context.Persons.FindAsync(id);
            if (person == null) return false;

            _context.Persons.Remove(person);
            await _context.SaveChangesAsync();
            return true;
        }


        //update person
        public async Task<PersonGetDto?> UpdatePersonAsync(Guid id, PersonCreateDto updatedData)
        {
            var person = await _context.Persons.FindAsync(id);
            if (person == null) return null;

            person.FirstName = updatedData.FirstName;
            person.LastName = updatedData.LastName;
            person.BirthDate = updatedData.BirthDate;

            await _context.SaveChangesAsync();

            return new PersonGetDto
            {
                Id = person.Id,
                FirstName = person.FirstName,
                LastName = person.LastName,
                BirthDate = person.BirthDate,
                CreatedAt = person.CreatedAt
            };
        }
    }
}