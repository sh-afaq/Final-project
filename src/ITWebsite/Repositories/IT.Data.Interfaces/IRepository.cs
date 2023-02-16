using IT.Data.Models;
using System.Linq.Expressions;

namespace IT.Data.Interfaces
{
    public interface IRepository<TEntity> where TEntity : BaseEntity
    {
        IList<TEntity> GetAll();
        IQueryable<TEntity> Get(Expression<Func<TEntity,bool>> predicate);

        void Save(TEntity entity);
        void Delete(TEntity entity);
    }
}