using Microsoft.EntityFrameworkCore;
using System;

namespace ClubsCore.Models
{
    public class ClubsContext : DbContext
    {
        public ClubsContext(DbContextOptions options)
          : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Club>().HasData(
                new Club() { Id = 1, Name = "International", Type = "Other" },
                new Club() { Id = 2, Name = "Math", Type = "Academic" },
                new Club() { Id = 3, Name = "Diving", Type = "Sport" },
                new Club() { Id = 4, Name = "Strollers", Type = "Leisure" });

            modelBuilder.Entity<Student>().HasData(
                new Student() { Id = 1, FirstName = "Ali", LastName = "Tayari", BirthDate = new DateTime(1999, 8, 1) },
                new Student() { Id = 2, FirstName = "Dmitry", LastName = "Apraksin", BirthDate = new DateTime(1963, 8, 9) },
                new Student() { Id = 3, FirstName = "Ivan", LastName = "Ivanou", BirthDate = new DateTime(2004, 8, 12) },
                new Student() { Id = 4, FirstName = "Petr", LastName = "Petrov", BirthDate = new DateTime(2000, 1, 1) },
                new Student() { Id = 5, FirstName = "Sidor", LastName = "Sidorov", BirthDate = new DateTime(1989, 2, 3) },
                new Student() { Id = 6, FirstName = "Pambos", LastName = "Boss", BirthDate = new DateTime(2000, 5, 10) },
                new Student() { Id = 7, FirstName = "Christos", LastName = "Christou", BirthDate = new DateTime(1998, 4, 5) },
                new Student() { Id = 8, FirstName = "Savvas", LastName = "Savvou", BirthDate = new DateTime(1999, 12, 21) }
                );

            modelBuilder.Entity<StudentClub>().HasData(
                 new StudentClub() { Id = 1, ClubId = 1, StudentId = 1 },
                new StudentClub() { Id = 2, ClubId = 2, StudentId = 1 },
                new StudentClub() { Id = 3, ClubId = 3, StudentId = 2 },
                new StudentClub() { Id = 4, ClubId = 4, StudentId = 3 },
                new StudentClub() { Id = 5, ClubId = 3, StudentId = 4 },
                new StudentClub() { Id = 6, ClubId = 2, StudentId = 5 },
                new StudentClub() { Id = 7, ClubId = 1, StudentId = 6 },
                new StudentClub() { Id = 8, ClubId = 2, StudentId = 7 },
                new StudentClub() { Id = 9, ClubId = 3, StudentId = 8 },
                new StudentClub() { Id = 10, ClubId = 4, StudentId = 3 },
                new StudentClub() { Id = 11, ClubId = 2, StudentId = 5 },
                new StudentClub() { Id = 12, ClubId = 2, StudentId = 6 },
                new StudentClub() { Id = 13, ClubId = 1, StudentId = 7 }
                );
        }

        public DbSet<Club> Clubs { get; set; }
        public DbSet<Student> Students { get; set; }

        public DbSet<StudentClub> StudentClubs { get; set; }
    }
}