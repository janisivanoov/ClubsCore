using ClubsCore.Models;
using ClubsCore.Repository;
using Contracts;
using System.Collections.Generic;
using System.Linq;

namespace Repository
{
    public class ClubRepository : RepositoryBase<Club>, IClubRepository
    {
        public ClubRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {
        }

        public IEnumerable<Club> AccountsBystudent(int studentId)
        {
            return FindByCondition(a => a.Id.Equals(studentId)).ToList();
        }
    }
}