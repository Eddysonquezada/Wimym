namespace Wimym.DatabaseContext.Config
{
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using Model.Domain._General;

    public class OperationConfig
    {
        public OperationConfig(EntityTypeBuilder<Operation> entityBuilder)
        {
            entityBuilder.HasKey(x => x.OperationId);
            entityBuilder.Property(x => x.Observations).IsRequired().HasMaxLength(500);

            entityBuilder.HasOne(p => p.Periodicity)
                  .WithMany(m => m.Operations)
                  .HasForeignKey(s => s.PeriodicityId)
                  .IsRequired();
            entityBuilder.HasOne(p => p.Account)
                 .WithMany(m => m.Operations)
                 .HasForeignKey(s => s.AccountId)
                 .IsRequired();
            entityBuilder.HasOne(p => p.Tag)
                  .WithMany(m => m.Operations)
                  .HasForeignKey(s => s.TagId)
                  .IsRequired();
            entityBuilder.HasOne(p => p.Origin)
                 .WithMany(m => m.Operations)
                 .HasForeignKey(s => s.OriginId)
                 .IsRequired();
           

        }
    }
}
