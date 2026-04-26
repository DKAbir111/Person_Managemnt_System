using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace person_management_system.DTOs
{
    public class PersonGetDto
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public DateTime BirthDate { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}