namespace Wimym.DatabaseContext
{
    using Common;
    using DatabaseContext.Config;
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;
    using Model.Domain;
    using Model.Domain._Control;
    using Model.Domain._General;
    using Model.Domain.DbHelper;
    using System;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        private readonly ICurrentUserFactory _currentUser;

        public ApplicationDbContext(
            DbContextOptions<ApplicationDbContext> options,
            ICurrentUserFactory currentUser = null
        ) : base(options)
        {
            _currentUser = currentUser;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           

            //registering the configurations for all the classes
            new ApplicationUserConfig(modelBuilder.Entity<ApplicationUser>());
            new AccountTypeConfig(modelBuilder.Entity<AccountType>());
            new CurrencyConfig(modelBuilder.Entity<Currency>());
            new OriginConfig(modelBuilder.Entity<Origin>());
            new OwnerConfig(modelBuilder.Entity<Owner>());
            new PeriodicityConfig(modelBuilder.Entity<Periodicity>());
            new UserTypeConfig(modelBuilder.Entity<UserType>());
            new AccountingAccountConfig(modelBuilder.Entity<AccountingAccount>());
            new OperationConfig(modelBuilder.Entity<Operation>());
            new ShopConfig(modelBuilder.Entity<Shop>());
            new TagConfig(modelBuilder.Entity<Tag>());
            new WalletConfig(modelBuilder.Entity<Wallet>());
           
            ////if I want to remove the AspNet prefix from the identity tables
            //foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            //{
            //    var table = entityType.Relational().TableName;
            //    if (table.StartsWith("AspNet"))
            //    {
            //        entityType.Relational().TableName = table.Substring(6);
            //    }
            //};
        }

        public DbSet<Origin> Origins { get; set; }
        public DbSet<AccountType> AccountTypes { get; set; }
        public DbSet<Currency> Currencies { get; set; }
   
        public DbSet<Tag> Tags { get; set; }
        public DbSet<Wallet> Wallets { get; set; }        

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

        private void AddMyFilters(ref ModelBuilder modelBuilder)
        {
            #region SoftDeleted
            modelBuilder.Entity<ApplicationUser>().HasQueryFilter(x => !x.Deleted);
            modelBuilder.Entity<Owner>().HasQueryFilter(x => !x.Deleted);
            modelBuilder.Entity<AccountingAccount>().HasQueryFilter(x => !x.Deleted);
             modelBuilder.Entity<Operation>().HasQueryFilter(x => !x.Deleted);
            modelBuilder.Entity<Shop>().HasQueryFilter(x => !x.Deleted);
            modelBuilder.Entity<Tag>().HasQueryFilter(x => !x.Deleted);
            modelBuilder.Entity<Wallet>().HasQueryFilter(x => !x.Deleted);            
            #endregion
        }

    }
}
