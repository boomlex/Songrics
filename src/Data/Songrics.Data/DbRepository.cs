using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Songrics.Data.Common;

namespace Songrics.Data
{
    public class DbRepository<TEntity> : IRepository<TEntity>, IDisposable where TEntity : class
    {
        private readonly SongricsContext context;
        private DbSet<TEntity> dbSet;

        public DbRepository(SongricsContext context)
        {
            this.context = context;
            this.dbSet = this.context.Set<TEntity>();
        }

        public Task AddAsync(TEntity entity)
        {
            return this.dbSet.AddAsync(entity);
        }

        public IQueryable<TEntity> All()
        {
            return this.dbSet;
        }

        public void Delete(TEntity entity)
        {
            this.dbSet.Remove(entity);
        }

        public Task<int> SaveChangesAsync()
        {
            return this.context.SaveChangesAsync();
        }

        public void Dispose()
        {
            context?.Dispose();
        }
    }
}
