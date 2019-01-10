namespace Wimym.DatabaseContext.Config
{
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using Wimym.Model.Domain._Control;

    public class AccountTypeConfig
    {
        public AccountTypeConfig(EntityTypeBuilder<AccountType> entityBuilder)
        {
            entityBuilder.HasKey(x => x.AccountTypeId);
            entityBuilder.Property(x => x.Code).IsRequired().HasMaxLength(10);
            entityBuilder.Property(x => x.Name).IsRequired().HasMaxLength(100);
            entityBuilder.Property(x => x.Description).HasMaxLength(100);
            entityBuilder.HasOne(p => p.Origin)
                  .WithMany(m => m.AccountTypes)
                  .HasForeignKey(s => s.OriginId)
                  .IsRequired();

        }
    }
}
