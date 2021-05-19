using GatewayTask.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace GatewayTask.Repo.Configurations
{
    class GatewayEntityConfiguration : IEntityTypeConfiguration<Gateway>
    {
        public void Configure(EntityTypeBuilder<Gateway> builder)
        {
            builder.Property(e => e.Id).IsRequired();
            builder.Property(e => e.SerialNumber).ValueGeneratedOnAdd();

        }
    }
}
