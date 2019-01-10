namespace Wimym.DatabaseContext.Config
{
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using Model.Domain._General;

    public class AccountingAccountConfig
    {
        public AccountingAccountConfig(EntityTypeBuilder<AccountingAccount> entityBuilder)
        {
            entityBuilder.HasKey(x => x.AccountingAccountId);
            entityBuilder.Property(x => x.Code).IsRequired().HasMaxLength(10);
            entityBuilder.Property(x => x.Description).HasMaxLength(100);

            entityBuilder.HasOne(p => p.Currency)
                  .WithMany(m => m.AccountingAccounts)
                  .HasForeignKey(s => s.CurrencyId)
                  .IsRequired();
            entityBuilder.HasOne(p => p.Wallet)
                .WithMany(m => m.AccountingAccounts)
                .HasForeignKey(s => s.WalletId)
                .IsRequired();
            entityBuilder.HasOne(p => p.AccountType)
                .WithMany(m => m.AccountingAccounts)
                .HasForeignKey(s => s.AccountTypeId)
                .IsRequired();

        }
    }
}
