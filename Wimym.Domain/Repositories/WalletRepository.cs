using System;
using System.Collections.Generic;
using System.Text;

namespace Wimym.Domain.Repositories
{
    using Wymim.DatabaseContext;
    using Wymim.Domain;

    public class WalletRepository : Repository<Wallet>
    {
        public WalletRepository(DataContext context) : base(context)
        {
        }
        //private readonly ApplicationContext _context;
        //private GenericRepository<Wallet> _repository;

        //public WalletRepository(ApplicationContext context)
        //{
        //    _repository = new GenericRepository<Wallet>(context);

        //}
        //public async Task<Wallet> AddAsync(Wallet entity)
        //{
        //    _context.Add(entity);
        //    await _context.SaveChangesAsync();
        //    return entity;
        //}

        //public async Task<bool> DeleteAsync(Wallet entity)
        //{
        //    _context.Wallets.Remove(entity);
        //    int result = await _context.SaveChangesAsync();

        //    return result > 0;
        //}

        //public bool Exists(int key)
        //{
        //    return _context.Wallets.Any(e => e.WalletId == key);
        //}

        //public Task<List<Wallet>> FindByClause(Func<Wallet, bool> selector = null)
        //{
        //    var models = _context.Wallets               
        //        .Where(selector ?? (s => true));

        //    return Task.Run(() => models.ToList());
        //}

        //public async Task<Wallet> FindByIdAsync(int key)
        //{
        //    var entity = await _context.Wallets.FindAsync( key);
        //    return entity;
        //}

        //public Task<Wallet> GetByClause(Func<Wallet, bool> selector = null)
        //{
        //    var models = _context.Wallets
        //         .Where(selector ?? (s => true));

        //    return Task.Run(() => models.FirstOrDefault());
        //}

        //public async Task<bool> UpdateAsync(Wallet entity)
        //{
        //    //_context.Entry(entity).State = EntityState.Modified;
        //    //var result = await _context.SaveChangesAsync();

        //    //return result > 0;
        //    _context.Update(entity);
        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (Exception)
        //    {
        //        return false;
        //    }

        //    return true;
        //}

    }
}
