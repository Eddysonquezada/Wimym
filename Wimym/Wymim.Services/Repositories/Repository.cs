using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wymim.DatabaseContext;
using Wymim.Services.Interfaces;

namespace Wymim.Services.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity>
   where TEntity : class
    {
        private readonly DataContext _context;
        public Repository(DataContext context)
        {
            _context = context;
        }
        public async Task<TEntity> AddAsync(TEntity entity)
        {
            //Mapper.Initialize(cfg => cfg.CreateMap<TEntity, TEntity>());
            ////or
            //var config = new MapperConfiguration(cfg => cfg.CreateMap<TEntity, TEntity>());
            //var mapper = config.CreateMapper();
            // or
          

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
