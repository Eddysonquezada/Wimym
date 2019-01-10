namespace Wimym.DatabaseContext.Config
{
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using Wimym.Model.Domain._Control;

    public class OriginConfig
    {
        public OriginConfig(EntityTypeBuilder<Origin> entityBuilder)
        {
            entityBuilder.HasKey(x => x.OriginId);
            entityBuilder.Property(x => x.Code).IsRequired().HasMaxLength(2);
            entityBuilder.Property(x => x.Name).IsRequired().HasMaxLength(15);
            entityBuilder.Property(x => x.Description).HasMaxLength(30);
            entityBuilder.Property(x => x.Simbol).IsRequired().HasMaxLength(2);
        }
    }
}
