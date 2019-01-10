namespace Wimym.DatabaseContext.Config
{
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using Wimym.Model.Domain._Control;
    using Wimym.Model.Domain._General;

    public class TagConfig
    {
        public TagConfig(EntityTypeBuilder<Tag> entityBuilder)
        {
            entityBuilder.HasKey(x => x.TagId);
            entityBuilder.Property(x => x.Name).IsRequired().HasMaxLength(100);
            entityBuilder.Property(x => x.Description).HasMaxLength(100);

            entityBuilder.HasOne(p => p.Owner)
                  .WithMany(m => m.Tags)
                  .HasForeignKey(s => s.OwnerId)
                  .IsRequired();

        }
    }
}
