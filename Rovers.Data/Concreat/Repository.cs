using Microsoft.EntityFrameworkCore;
using Rovers.Data.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Rovers.Data.Concreat
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class, IEntity, new()
    {
        protected readonly DbContext context;
        public Repository(DbContext _context)
        {
            context = _context;
        }

        public bool Add(TEntity entity)
        {
            try
            {
                var added = context.Entry(entity);
                added.State = EntityState.Added;
                int result = context.SaveChanges();
                return result > 0 ? true : false;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Delete(int id)
        {
            try
            {
                var data = context.Find<TEntity>(id);
                var deleted = context.Entry(data);
                deleted.State = EntityState.Deleted;
                int result = context.SaveChanges();
                return result > 0 ? true : false;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<TEntity> Get(Expression<Func<TEntity, bool>> filter)
        {
            return await context.Set<TEntity>().FirstOrDefaultAsync(filter);
        }

        public async Task<ICollection<TEntity>> GetList(Expression<Func<TEntity, bool>> filter = null)
        {
            if (filter == null)
                return await context.Set<TEntity>().ToListAsync();
            else
            {
                var db = context.Set<TEntity>() as IQueryable<TEntity>;
                return await db.Where(filter).ToListAsync();
            }

        }

        public bool Update(TEntity entity)
        {
            try
            {
                var modified = context.Entry<TEntity>(entity);
                modified.State = EntityState.Modified;
                int result = context.SaveChanges();
                return result > 0 ? true : false;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
