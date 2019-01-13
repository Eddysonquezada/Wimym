using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Wimym.Backend.Contracts
{
    //but, Here comes a question, on the account i have to update the Wallet?
    //no, so, we need to use generic object
    public interface IRepository<TEntity, in TKey> where TEntity : class
    {
        Task<TEntity> AddAsync(TEntity entity);
         Task<bool> DeleteAsync(TEntity entity);
        Task<bool> UpdateAsync(TEntity entity);
        bool Exists(int key);
        Task<TEntity> FindByIdAsync(int key);//will find by id and return the entity
         Task<List<TEntity>> FindByClause(Func<TEntity, bool> selector = null);
        Task<TEntity> GetByClause(Func<TEntity, bool> selector = null);
      
    }
}
