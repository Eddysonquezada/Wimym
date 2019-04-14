namespace Wimym.DatabaseContext.Config
{
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using Model.Domain._Control;

    public class CurrencyConfig
    {
        public CurrencyConfig(EntityTypeBuilder<Currency> entityBuilder)
        {
            entityBuilder.HasKey(x => x.CurrencyId);
            entityBuilder.Property(x => x.Code).IsRequired().HasMaxLength(10);
            entityBuilder.Property(x => x.Name).IsRequired().HasMaxLength(100);         
        }
    }
}
