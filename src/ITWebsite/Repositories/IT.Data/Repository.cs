using IT.Data.Interfaces;
using IT.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace IT.Data
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : BaseEntity
    {
        private readonly ITWebsiteDbContext _context;
        protected readonly DbSet<TEntity> _dbset;
        public Repository(ITWebsiteDbContext context, DbSet<TEntity> dbset)
        {
            _context = context;
            _dbset = dbset;


        }
        IList<TEntity> IRepository<TEntity>.GetAll()
        {
            return _dbset.ToList();
        }
        

        IQueryable<TEntity> IRepository<TEntity>.Get(System.Linq.Expressions.Expression<Func<TEntity, bool>> predicate)
        {
            return _dbset.Where(predicate);
        }

        void IRepository<TEntity>.Delete(TEntity entity)
        {
            if (entity == null)
                return;
            var dbEntity = _context.Entry(entity);
            if (dbEntity.State != EntityState.Deleted)
            {
                dbEntity.State = EntityState.Deleted;
            }
            else 
            {
                _dbset.Attach(entity);
                _dbset.Remove(entity);
                _context.SaveChanges();
            }
        }

        void IRepository<TEntity>.Save(TEntity entity)
        {
            if(entity.Id>0)
            {
                _dbset.Attach(entity);
                _context.Entry(entity).State= EntityState.Modified;
                _context.SaveChanges();
            }
            else
            {
                _dbset.Add(entity);
                _context.SaveChanges();
            }
        }
    }
}
