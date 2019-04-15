namespace Wimym.Web.Data
{
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using Wimym.Web.Data.DbHelper;
    using Wimym.Web.Data.Entities;
    using Wimym.Web.Helpers;

    public class DataContext : IdentityDbContext<ApplicationUser>
    {
        private readonly ICurrentUserFactory _currentUser;

        public DataContext(
            DbContextOptions<DataContext> options,
            ICurrentUserFactory currentUser = null
        ) : base(options)
        {
            _currentUser = currentUser;
        }

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            //this dont exist on core
            // builder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            //foreach (var entityType in builder.Model.GetEntityTypes())
            //{
            //    // equivalent of modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            //    entityType.Relational().TableName = entityType.DisplayName();

            //    // equivalent of modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            //    // and modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();
            //    entityType.GetForeignKeys()
            //        .Where(fk => !fk.IsOwnership && fk.DeleteBehavior == DeleteBehavior.Cascade)
            //        .ToList()
            //        .ForEach(fk => fk.DeleteBehavior = DeleteBehavior.Restrict);
            //}
            foreach (var relationship in builder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }

            base.OnModelCreating(builder);

            // My custom filters
            AddMyFilters(ref builder);

            // My fluent api contraints
            //new ApplicationUserConfig(modelBuilder.Entity<ApplicationUser>());
            //new CommentsPerPhotoConfig(modelBuilder.Entity<CommentsPerPhoto>());
            //new LikesPerPhotoConfig(modelBuilder.Entity<LikesPerPhoto>());
            //new PhotoConfig(modelBuilder.Entity<Photo>());

            //base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);

        }

        //[NotMapped]
        //public virtual DbSet<ApplicationUser> ApplicationUsers { get; set; }

        public DbSet<Owner> Owners { get; set; }
        public DbSet<Currency> Currencies { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<AccountType> AccountTypes { get; set; }
        public DbSet<Origin> Origins { get; set; }
        public DbSet<Status> Status { get; set; }
        public DbSet<Wallet> Wallets { get; set; }
        public DbSet<Reaction> Reactions { get; set; }

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
            //modelBuilder.Entity<CommentsPerPhoto>().HasQueryFilter(x => !x.Deleted);
            //modelBuilder.Entity<LikesPerPhoto>().HasQueryFilter(x => !x.Deleted);
            //modelBuilder.Entity<Photo>().HasQueryFilter(x => !x.Deleted);
            #endregion
        }

    }
}
