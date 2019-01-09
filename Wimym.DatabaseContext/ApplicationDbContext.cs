using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Wimym.DatabaseContext.Config;
using Wimym.Model.Domain;
using Wimym.Model.Domain.DbHelper;

namespace Wimym.DatabaseContext
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) :
           base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // ...

            var cascadeFKs = modelBuilder.Model.GetEntityTypes()
                .SelectMany(t => t.GetForeignKeys())
                .Where(fk => !fk.IsOwnership && fk.DeleteBehavior == DeleteBehavior.Cascade);

            foreach (var fk in cascadeFKs)
                fk.DeleteBehavior = DeleteBehavior.Restrict;

            base.OnModelCreating(modelBuilder);

            //registering the configurations for all the classes
            new ApplicationUserConfig(modelBuilder.Entity<ApplicationUser>());
            new OriginConfig(modelBuilder.Entity<Origin>());

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

            foreach (var entry in modifiedEntries)
            {
                var entity = entry.Entity as AuditEntity;

                if (entity != null)
                {
                    var date = DateTime.UtcNow;
                    string userId = null;

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
            modelBuilder.Entity<Origin>().HasQueryFilter(x => !x.Deleted);
            //modelBuilder.Entity<LikesPerPhoto>().HasQueryFilter(x => !x.Deleted);
            //modelBuilder.Entity<Photo>().HasQueryFilter(x => !x.Deleted);
            #endregion
        }

    }
}
