using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Wimym.Backend.Models;
using Wymim.Domain;

namespace Wimym.Backend.Contracts
{
    //and now implement it
    interface IWallet : IGenericRepository<Wallet>
    {
        //we will receive and wallet item and will return a wallet item
        //Task<Wallet> AddAsync(Wallet entity);
        ////will receive an entity wallet and will return a boolean as result
        //Task<bool> DeleteAsync(Wallet entity);
        //Task<bool> UpdateAsync(Wallet entity);
        //bool Exists(int key);
        //Task<Wallet> FindByIdAsync(int key);//will find by id and return the entity
        ////will find by a field, and will return a list of the results
        //Task<List<Wallet>> FindByClause(Func<Wallet, bool> selector = null);
        //Task<Wallet> GetByClause(Func<Wallet, bool> selector = null);
        ////the same than the last one, but will return a single element

    }
}
