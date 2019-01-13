using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Wimym.Backend.Models;

namespace Wimym.Backend.Models
{
    public class ApplicationContext : DbContext
    {
        //here im going to resived the database credentials, and location
        public ApplicationContext (DbContextOptions<ApplicationContext> options)
            : base(options)
        {
        }

        //here are the database structure tables, the object than will be referenced, 
        //and then the name than will have on the database

        public DbSet<Wallet> Wallets { get; set; }              
        public DbSet<Account> Accounts { get; set; }
    }
}
