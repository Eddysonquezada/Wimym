using System;
using System.Collections.Generic;
using System.Text;

namespace Wimym.Domain.Repositories
{
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Wymim.DatabaseContext;
    using Wymim.Domain;


    public class AccountRepository : Repository<Account>
    {
        private DataContext _context;
        public AccountRepository(DataContext context) : base(context)
        {
            _context = context;
        }
        public new Task<List<Account>> FindByClause(Func<Account, bool> selector = null)
        {
            var models = _context.Accounts.
                Include(prop => prop.Wallet)
                .Where(selector ?? (s => true));

            return Task.Run(() => models.ToList());
        }

        public new Task<Account> GetByClause(Func<Account, bool> selector = null)
        {
            var models = _context.Accounts
                .Include(p => p.Wallet)
                .Where(selector ?? (s => true));

            return Task.Run(() => models.FirstOrDefault());
        }

    }
}
