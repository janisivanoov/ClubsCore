using System;
using System.Collections.Generic;

namespace ClubsCore.Models
{
    public class Student : BaseEntity
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime BirthDate { get; set; }

        public string Password { get; set; }

        public ICollection<Club> Club { get; set; }
    }
}