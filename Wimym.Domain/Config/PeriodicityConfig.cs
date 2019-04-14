namespace Wimym.DatabaseContext.Config
{
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using Model.Domain._Control;

    public class PeriodicityConfig
    {
        public PeriodicityConfig(EntityTypeBuilder<Periodicity> entityBuilder)
        {
            entityBuilder.HasKey(x => x.PeriodicityId);
            entityBuilder.Property(x => x.Code).IsRequired().HasMaxLength(15);
            entityBuilder.Property(x => x.Name).IsRequired().HasMaxLength(100);
        }
    }
}
