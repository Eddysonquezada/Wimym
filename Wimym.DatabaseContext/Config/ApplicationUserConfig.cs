using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using Wimym.Model.Domain;

namespace Wimym.DatabaseContext.Config
{
    public class ApplicationUserConfig
    {
        public ApplicationUserConfig(EntityTypeBuilder<ApplicationUser> entityBuilder)
        {
            entityBuilder.HasKey(x => x.Id);
            //entityBuilder.Property(x => x.SeoUrl).IsRequired().HasMaxLength(100);
            //entityBuilder.Property(x => x.AboutUs).HasMaxLength(500);
            //entityBuilder.Property(x => x.Image).HasMaxLength(100);
        }
    }
}
