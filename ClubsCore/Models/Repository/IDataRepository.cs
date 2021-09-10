using ClubsCore.Paging;
using System.Collections.Generic;

namespace ClubsCore.Models.Repository
{
    public interface IDataRepository<TEntity>
    {
        IEnumerable<TEntity> GetAll(QueryParameters queryParameters);

        TEntity Get(long id);

        void Add(TEntity entity);

        void Update(TEntity dbEntity, TEntity entity);

        void Delete(TEntity entity);
    }
}