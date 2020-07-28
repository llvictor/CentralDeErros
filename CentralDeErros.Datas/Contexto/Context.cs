using CentralDeErros.Datas.Map;
using CentralDeErros.Domain.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CentralDeErros.Datas.Contexto
{
    public class Context : IdentityDbContext
    {
        public DbSet<Log> Log { get; set; }
        public DbSet<Level> Level { get; set; } 

        public Context(DbContextOptions<Context> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new LogMap());
            modelBuilder.ApplyConfiguration(new LevelMap());

            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Level>().HasData(new Level { Id = 1, Name = "Error", CreatedAt = DateTime.Now });
            modelBuilder.Entity<Level>().HasData(new Level { Id = 2, Name = "Info", CreatedAt = DateTime.Now });
            modelBuilder.Entity<Level>().HasData(new Level { Id = 3, Name = "Warning", CreatedAt = DateTime.Now });
        }

        public override int SaveChanges()
        {
            foreach (var entry in ChangeTracker.Entries().Where(entry => entry.Entity.GetType().GetProperty("CreatedAt") != null))
            {
                if (entry.State == EntityState.Added)
                {
                    entry.Property("CreatedAt").CurrentValue = DateTime.Now;
                }

                if (entry.State == EntityState.Modified)
                {
                    entry.Property("CreatedAt").IsModified = false;
                }
            }

            foreach (var entry in ChangeTracker.Entries().Where(entry => entry.Entity.GetType().GetProperty("UpdatedAt") != null))
            {
                if (entry.State == EntityState.Added || entry.State == EntityState.Modified)
                {
                    entry.Property("UpdatedAt").CurrentValue = DateTime.Now;
                }
            }

            return base.SaveChanges();
        }

    }
}
