namespace Wimym.Backend.Models
{
    using Microsoft.EntityFrameworkCore;

    public class LocalDataContext : DbContext
    {
        public LocalDataContext (DbContextOptions<LocalDataContext> options)
            : base(options)
        {
        }

        public DbSet<Currency> Currencies { get; set; }
    }
}
