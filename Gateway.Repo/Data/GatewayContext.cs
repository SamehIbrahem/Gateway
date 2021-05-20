using GatewayTask.Data.Entities;
using GatewayTask.Repo.Configurations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace GatewayTask.Repo.Data
{
    public class GatewayContext : DbContext
    {
        public GatewayContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            #region Gateway builder

            
            var gatewayBuilder = modelBuilder.Entity<Gateway>();
            gatewayBuilder.Property(e => e.Id).IsRequired();
            gatewayBuilder.HasMany(e => e.Devices).WithOne();
            List<Gateway> gateways = new List<Gateway>
            {
                new Gateway
                {
                  Created = DateTime.Now,
                  Id = 1,
                  Name = "First Gateway",
                  SerialNumber = "123456789-77-1",
                  IPv4Address = "http",
                }, new Gateway
                {
                  Created = DateTime.Now,
                  Id = 2,
                  Name = "Second Gateway",
                  SerialNumber = "123456789-33-2",
                  IPv4Address = "http",
                }
       
            };
            gatewayBuilder.HasData(gateways);

            #endregion

            #region Device builder

           
            var deviceBuilder = modelBuilder.Entity<Device>();
            deviceBuilder.Property(e => e.Id).IsRequired();
            List<Device> devices = new List<Device>
            {
                new Device
                {
                    Id =1,
                    Created=DateTime.Now,
                    Status =true,
                    Vendor="Device 1 Vendor",
                    UID =11122,
                    GatewayId =1

                },
                new Device
                {
                    Id =2,
                    Created=DateTime.Now,
                    Status =true,
                    Vendor="Device 2 Vendor",
                    UID =12347,
                    GatewayId = 1

                },
                new Device
                {
                    Id =3,
                    Created=DateTime.Now,
                    Status =true,
                    Vendor="Device 3 Vendor",
                    UID =331117,
                    GatewayId =2

                }
            };
            deviceBuilder.HasData(devices);

            #endregion

            //modelBuilder.ApplyConfigurationsFromAssembly(typeof(GatewayEntityConfiguration).Assembly);
            base.OnModelCreating(modelBuilder);
        }



        public DbSet<Gateway> Gateways { get; set; }
    }
}
