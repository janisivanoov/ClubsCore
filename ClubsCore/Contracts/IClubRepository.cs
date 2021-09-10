using ClubsCore.Models;
using System.Collections.Generic;

namespace Contracts
{
    public interface IClubRepository : IRepositoryBase<Club>
    {
        IEnumerable<Club> AccountsBystudent(int studentId);
    }
}