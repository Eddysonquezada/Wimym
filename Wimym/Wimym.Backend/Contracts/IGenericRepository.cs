using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Wimym.Backend.Contracts
{
    public interface IGenericRepository<TEntity>
 where TEntity : class
    {
        Task<TEntity> AddAsync(TEntity entity);
        Task<bool> DeleteAsync(TEntity entity);
        Task<bool> UpdateAsync(TEntity entity);
        bool Exists(int key);
        Task<TEntity> FindByIdAsync(int key);//will find by id and return the entity
        Task<List<TEntity>> FindByClause(Func<TEntity, bool> selector = null);
        Task<TEntity> GetByClause(Func<TEntity, bool> selector = null);
        //IQueryable<TEntity> GetAll();
        //Task<TEntity> GetById(int id);
        //Task Create(TEntity entity);
        //Task Update(int id, TEntity entity);
        //Task Delete(int id);
    }
}
