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
            builder.HasMany(e => e.Devices).WithOne();
            SeedData(builder);


        }

        private void SeedData(EntityTypeBuilder<Gateway> builder)
        {
            builder.HasData(
          new Gateway
          {
              Created = DateTime.Now,
              Id = 1,
              Name = "First Gateway",
              SerialNumber = "123456789-77-1",
              IPv4Address = "http",
              Devices = new List<Device> {
                        new Device {
                            Id =1,
                            Created=DateTime.Now,
                            Status =true,
                            Vendor="Device 1 Vendor",
                            UID =11122
                           }
              }
          }, new Gateway
          {
              Created = DateTime.Now,
              Id = 2,
              Name = "Second Gateway",
              SerialNumber = "123456789-33-2",
              IPv4Address = "http",
              Devices = new List<Device> {
                        new Device {
                            Id =2,
                            Created=DateTime.Now,
                            Status =true,
                            Vendor="Device 1 Vendor",
                            UID =1112211
                           },
                        new Device {
                            Id =3,
                            Created=DateTime.Now,
                            Status =true,
                            Vendor="Device 3 Vendor",
                            UID =77710
                           }
              }
          });
        }
    }
}
