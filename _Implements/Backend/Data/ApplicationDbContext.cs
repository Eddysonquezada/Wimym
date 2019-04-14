using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.Models;
using Microsoft.EntityFrameworkCore;
using Domain;

namespace Backend.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Core Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Core Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }

        public DbSet<Domain.Contact> Contact { get; set; }

       // public DbSet<Backend.Models.Contact> Contact { get; set; }
    }
}
