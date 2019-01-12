namespace Wimym.Domain
{
    using Microsoft.EntityFrameworkCore;
    using Wimym.Domain.DataEntities;
    using Wimym.Domain.DataEntities.Configuration;

    public class DataContext:DbContext
    {
        public DataContext()
        {

        }

        public DataContext (DbContextOptions<DataContext> options) : base(options)
        {

        }

        public virtual DbSet<Currency> Currencies { get; set; }


    }
}
