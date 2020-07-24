using CentralDeErros.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace CentralDeErros.Datas.Map
{
    public class EnvironmentMap : IEntityTypeConfiguration<Domain.Entities.Environment>
    {
        public void Configure(EntityTypeBuilder<Domain.Entities.Environment> builder)
        {
            builder.ToTable("Environment");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name)
                .HasColumnType("varchar(100)")
                .IsRequired();

            builder.HasMany<Log>(e => e.Logs)
                .WithOne(ev => ev.Environment)
                .HasForeignKey(ev => ev.EnvironmentId);
        }
    }
}
