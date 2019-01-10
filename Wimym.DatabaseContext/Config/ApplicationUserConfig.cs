using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using Wimym.Model.Domain;
using Wimym.Model.Domain._Control;

namespace Wimym.DatabaseContext.Config
{
    public class ApplicationUserConfig
    {
        public ApplicationUserConfig(EntityTypeBuilder<ApplicationUser> entityBuilder)
        {
            entityBuilder.HasKey(x => x.Id);
            entityBuilder.Property(x => x.SeoUrl).IsRequired().HasMaxLength(100);
            entityBuilder.Property(x => x.AboutMe).HasMaxLength(500);
            entityBuilder.Property(x => x.Image).HasMaxLength(100);
            entityBuilder.Property(x => x.Name).HasMaxLength(50);
            entityBuilder.Property(x => x.Lastname).HasMaxLength(50);

            entityBuilder.HasOne(e => e.Shop)
                   .WithMany(s => s.ApplicationUsers)
                   .HasForeignKey(s => s.ShopId)
                   .IsRequired();

            entityBuilder.HasOne(e => e.UserType)
                 .WithMany(s => s.ApplicationUsers)
                 .HasForeignKey(s => s.UserTypeId)
                 .IsRequired();


        }
    }
}
