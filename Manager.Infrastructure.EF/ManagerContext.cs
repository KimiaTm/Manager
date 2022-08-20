using Manager.Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace Manager.Infrastructure.EF
{
    public class ManagerContext : DbContext
    {
        public ManagerContext(DbContextOptions<ManagerContext> dbContextOptions) : base(dbContextOptions)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
        public DbSet<Products> Products { get; set; }
        public DbSet<Store> Stores { get; set; }
        public DbSet<Factor> Factors { get; set; }
        public DbSet<Factor_Store> Factor_Store { get; set; }
    }
}
