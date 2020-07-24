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
        public DbSet<Domain.Entities.Environment> Ambiente { get; set; } 

        public Context(DbContextOptions<Context> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new LogMap());
            modelBuilder.ApplyConfiguration(new EnvironmentMap());

            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Domain.Entities.Environment>().HasData(new Domain.Entities.Environment { Id = 1, Name = "Produção" });
            modelBuilder.Entity<Domain.Entities.Environment>().HasData(new Domain.Entities.Environment { Id = 2, Name = "Homologação" });
            modelBuilder.Entity<Domain.Entities.Environment>().HasData(new Domain.Entities.Environment { Id = 3, Name = "Dev" });
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
