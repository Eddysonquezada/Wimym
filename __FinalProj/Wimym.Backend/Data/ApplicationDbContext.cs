using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Wimym.Backend.Models;

namespace Wimym.Backend.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
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
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
           
        }

        [NotMapped]
        public virtual DbSet<ApplicationUser> ApplicationUsers { get; set; }

        public DbSet<Currency> Currencies { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<AccountType> AccountTypes { get; set; }
        public DbSet<Origin> Origins { get; set; }
        public DbSet<Status> Status { get; set; }
        public DbSet<Wallet> Wallets { get; set; }


    }
}
