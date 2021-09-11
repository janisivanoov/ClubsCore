using ClubsCore.Models;
using System.Collections.Generic;

namespace Contracts
{
    public interface IClubRepository : IRepositoryBase<Club>
    {
        IEnumerable<Club> AccountsByStudent(int studentId);

        Club GetClubById(int clubId);

        Club GetClubWithDetails(int clubId);

        void CreateClub(Club club);

        void UpdateClub(Club club);

        void DeleteClub(Club club);
    }
}