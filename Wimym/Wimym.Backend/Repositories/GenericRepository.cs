using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Wimym.Backend.Contracts;
using Wimym.Backend.Models;
using Wymim.DatabaseContext;

namespace Wimym.Backend.Repositories
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity>
    where TEntity : class
    {
        private readonly DataContext _context;
        public GenericRepository(DataContext context)
        {
            _context = context;
        }
        public async Task<TEntity> AddAsync(TEntity entity)
        {
            _context.Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<bool> DeleteAsync(TEntity entity)
        {
            _context.Set<TEntity>().Remove(entity);
            int result = await _context.SaveChangesAsync();

            return result > 0;
        }

        public bool Exists(int key)
        {
            //return _context.Set<TEntity>().Any(p=>p.Set<);
            throw new NotImplementedException();
        }

        public Task<List<TEntity>> FindByClause(Func<TEntity, bool> selector = null)
        {
            var models = _context.Set<TEntity>()
                .Where(selector ?? (s => true));

            return Task.Run(() => models.ToList());
        }

        public async Task<TEntity> FindByIdAsync(int key)
        {
            var entity = await _context.Set<TEntity>().FindAsync(key);
            return entity;
        }

        public Task<TEntity> GetByClause(Func<TEntity, bool> selector = null)
        {
            var models = _context.Set<TEntity>()
                  .Where(selector ?? (s => true));

            return Task.Run(() => models.FirstOrDefault());
        }

        public async Task<bool> UpdateAsync(TEntity entity)
        {
            _context.Update(entity);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }
    }
}
