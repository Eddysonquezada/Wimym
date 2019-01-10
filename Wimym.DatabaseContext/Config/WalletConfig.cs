namespace Wimym.DatabaseContext.Config
{
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using Wimym.Model.Domain._General;

    public class WalletConfig
    {
        public WalletConfig(EntityTypeBuilder<Wallet> entityBuilder)
        {
            entityBuilder.HasKey(x => x.WalletId);
            entityBuilder.Property(x => x.Code).IsRequired().HasMaxLength(10);
            entityBuilder.Property(x => x.Name).IsRequired().HasMaxLength(100);
            entityBuilder.Property(x => x.Description).HasMaxLength(100);

            entityBuilder.HasOne(p => p.Owner)
                  .WithMany(m => m.Wallets)
                  .HasForeignKey(s => s.OwnerId)
                  .IsRequired();

        }
    }
}
