namespace Wimym.DatabaseContext.Config
{
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using Wimym.Model.Domain;
    using Wimym.Model.Domain._Control;

    public class ShopConfig
    {
        public ShopConfig(EntityTypeBuilder<Shop> entityBuilder)
        {
            entityBuilder.HasKey(x => x.ShopId);
            entityBuilder.Property(x => x.Name).IsRequired().HasMaxLength(100);
            entityBuilder.Property(x => x.Address).HasMaxLength(200);
            entityBuilder.Property(x => x.Email).HasMaxLength(50);
            entityBuilder.Property(x => x.WebAddress).HasMaxLength(50);
            entityBuilder.Property(x => x.Tel).HasMaxLength(15);

            entityBuilder.HasOne(p => p.Owner)
                  .WithMany(m => m.Shops)
                  .HasForeignKey(s => s.OwnerId)
                  .IsRequired();

        }
    }
}
