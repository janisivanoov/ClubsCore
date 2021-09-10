using System;
using System.Collections.Generic;

namespace ClubsCore.Models.ExtendedModels
{
    public class StudentExtented
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public string Password { get; set; }
        public IEnumerable<Club> Clubs { get; set; }

        public StudentExtented()
        {
        }

        public StudentExtented(Student student)
        {
            Id = student.Id;
            FirstName = student.FirstName;
            LastName = student.LastName;
            BirthDate = student.BirthDate;
            Password = student.Password;
        }
    }
}