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

        public Club GetClubWithDetails(int clubId)
        {
            return FindByCondition(club => club.Id.Equals(clubId))
                .FirstOrDefault();
        }

        public void CreateClub(Club club)
        {
            Create(club);
        }

        public void UpdateClub(Club club)
        {
            Update(club);
        }

        public void DeleteClub(Club club)
        {
            Delete(club);
        }

        public IEnumerable<Club> AccountsByStudent(int studentId)
        {
            return FindByCondition(a => a.Id.Equals(studentId)).ToList();
        }

        Club IClubRepository.GetClubById(int clubId)
        {
            return FindByCondition(club => club.Id.Equals(clubId))
                                    .FirstOrDefault();
        }
    }
}