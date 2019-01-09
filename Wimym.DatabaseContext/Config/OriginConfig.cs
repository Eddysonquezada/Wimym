using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using Wimym.Model.Domain;

namespace Wimym.DatabaseContext.Config
{
    //the config classes are make it to remove the use of the dataanotations
    public class OriginConfig
    {
        public OriginConfig(EntityTypeBuilder<Origin> entityBuilder)
        {
            entityBuilder.HasKey(x => x.OriginId);

        }
    }
}
