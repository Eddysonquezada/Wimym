namespace Wimym.DatabaseContext.Config
{
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using Wimym.Model.Domain._Control;

    public class OwnerConfig
    {
        public OwnerConfig(EntityTypeBuilder<Owner> entityBuilder)
        {
            entityBuilder.HasKey(x => x.OwnerId);
            entityBuilder.Property(x => x.Code).IsRequired().HasMaxLength(15);
            entityBuilder.Property(x => x.Name).IsRequired().HasMaxLength(100);
            entityBuilder.Property(x => x.LastName).IsRequired().HasMaxLength(100);
            entityBuilder.Property(x => x.Email).IsRequired().HasMaxLength(50);

            entityBuilder.Property(x => x.PrefixFact).HasMaxLength(15);
            entityBuilder.Property(x => x.PrefixOrder).HasMaxLength(10);
            entityBuilder.Property(x => x.PrefixNcf).HasMaxLength(15);
            entityBuilder.Property(x => x.PrefixFinalFact).HasMaxLength(15);
            entityBuilder.Property(x => x.NcfEnds).HasMaxLength(25);

        }
    }
}
