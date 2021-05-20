using GatewayTask.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace GatewayTask.Repo.Data
{
    public class Repository<T> : IRepository<T> where T : BaseAuditClass
    {
        private readonly GatewayContext context;
        private DbSet<T> entities;

        public Repository(GatewayContext context)
        {
            this.context = context;
            entities = context.Set<T>();
        }
        public Task<List<T>> GetAll(params Expression<Func<T, object>>[] includes)
        {
            IEnumerable<T> query = null;
            foreach (var include in includes)
            {
                query = entities.Include(include);
            }
            if (query != null)
                return Task.FromResult(query.ToList());

            return entities.ToListAsync();
        }

        public IQueryable<T> AsQueryable()
        {
            return entities.AsQueryable();
        }

        public Task<T> Get(int id)
        {
            return entities.SingleOrDefaultAsync(s => s.Id == id);
        }
        public async Task Insert(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            entities.Add(entity);
            await context.SaveChangesAsync();
        }

        public async Task Update(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            await context.SaveChangesAsync();
        }

        public async Task Delete(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            entities.Remove(entity);
            await context.SaveChangesAsync();
        }

    }
}
