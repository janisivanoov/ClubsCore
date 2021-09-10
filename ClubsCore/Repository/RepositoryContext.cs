using ClubsCore.Models;
using Microsoft.EntityFrameworkCore;

namespace ClubsCore.Repository
{
    public class RepositoryContext : DbContext
    {
        public RepositoryContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Student> students { get; set; }
        public DbSet<Club> clubs { get; set; }
    }
}