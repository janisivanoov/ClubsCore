using ClubsCore.Models.Repository;
using ClubsCore.Paging;
using System.Collections.Generic;
using System.Linq;

namespace ClubsCore.Models.DataManager
{
    public class ClubManager : IDataRepository<Club>
    {
        private ClubsContext _clubsContext;

        public ClubManager(ClubsContext context)
        {
            _clubsContext = context;
        }

        public IEnumerable<Club> GetAll(QueryParameters queryparameters)
        {
            return _clubsContext.Clubs.OrderBy(c => c.Id).Skip((queryparameters.PageNumber - 1) * queryparameters.PageSize).Take(queryparameters.PageSize).ToList();
        }

        public Club Get(long id)
        {
            return _clubsContext.Clubs
                  .FirstOrDefault(c => c.Id == id);
        }

        public void Add(Club entity)
        {
            entity.CreatedDate = System.DateTime.Now;
            entity.UpdatedDate = System.DateTime.Now;
            _clubsContext.Clubs.Add(entity);
            _clubsContext.SaveChanges();
        }

        public void Update(Club club, Club entity)
        {
            club.Name = entity.Name;
            club.Type = entity.Type;

            _clubsContext.SaveChanges();
        }

        public void Delete(Club club)
        {
            _clubsContext.Clubs.Remove(club);
            _clubsContext.SaveChanges();
        }
    }
}