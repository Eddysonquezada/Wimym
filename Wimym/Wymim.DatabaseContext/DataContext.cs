using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Wymim.Domain;

namespace Wymim.DatabaseContext
{
   public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options)
            : base(options)
        {
        }

        //here are the database structure tables, the object than will be referenced, 
        //and then the name than will have on the database

        public DbSet<Wallet> Wallets { get; set; }
        public DbSet<Account> Accounts { get; set; }
    }
}
