namespace Wimym.Domain
{
    using Microsoft.EntityFrameworkCore;
    using Wimym.Domain.DataEntities;
    using Wimym.Domain.DataEntities.Configuration;

   
    public class DataContext : IdentityDbContext<ApplicationUser>
    {
        private readonly ICurrentUserFactory _currentUser;
        public DataContext(DbContextOptions<DataContext> options,
             ICurrentUserFactory currentUser = null)
            : base(options)
        {
            _currentUser = currentUser;
        }

        //here are the database structure tables, the object than will be referenced, 
        //and then the name than will have on the database

        public DbSet<Wallet> Wallets { get; set; }
        public DbSet<Account> Accounts { get; set; }

        private void MakeAudit()
        {
            var modifiedEntries = ChangeTracker.Entries().Where(
                x => x.Entity is AuditEntity
                    && (
                    x.State == EntityState.Added
                    || x.State == EntityState.Modified
                )
            );

            var user = new CurrentUser();

            if (_currentUser != null)
            {
                user = _currentUser.Get;
            }

            foreach (var entry in modifiedEntries)
            {
                var entity = entry.Entity as AuditEntity;

                if (entity != null)
                {
                    var date = DateTime.Now;
                    string userId = user.UserId;

                    if (entry.State == EntityState.Added)
                    {
                        entity.CreatedAt = date;
                        entity.CreatedBy = userId;
                    }
                    else if (entity is ISoftDeleted && ((ISoftDeleted)entity).Deleted)
                    {
                        entity.DeletedAt = date;
                        entity.DeletedBy = userId;
                    }

                    Entry(entity).Property(x => x.CreatedAt).IsModified = false;
                    Entry(entity).Property(x => x.CreatedBy).IsModified = false;

                    entity.UpdatedAt = date;
                    entity.UpdatedBy = userId;
                }
            }
        }
        public override int SaveChanges()
        {
            MakeAudit();
            return base.SaveChanges();
        }
        public override async Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default(CancellationToken))
        {
            MakeAudit();
            return await base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            MakeAudit();
            return await base.SaveChangesAsync(cancellationToken);
        }

    }
}
