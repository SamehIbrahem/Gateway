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
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(GatewayEntityConfiguration).Assembly);
            base.OnModelCreating(modelBuilder);
        }



        public DbSet<Gateway> Gateways { get; set; }
    }
}
