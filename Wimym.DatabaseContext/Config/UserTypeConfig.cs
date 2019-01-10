namespace Wimym.DatabaseContext.Config
{
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using Wimym.Model.Domain._Control;

    public class UserTypeConfig
    {
        public UserTypeConfig(EntityTypeBuilder<UserType> entityBuilder)
        {
            entityBuilder.HasKey(x => x.UserTypeId);
            entityBuilder.Property(x => x.Name).IsRequired().HasMaxLength(100);
        }
    }
}
