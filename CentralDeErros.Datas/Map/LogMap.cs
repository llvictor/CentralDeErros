using CentralDeErros.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace CentralDeErros.Datas.Map
{
    public class LogMap : IEntityTypeConfiguration<Log>
    {
        public void Configure(EntityTypeBuilder<Log> builder)
        {
            builder.ToTable("Log");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Description)
                .HasColumnType("varchar(100)")
                .IsRequired();

            builder.Property(x => x.Details)
                .HasColumnType("varchar(500)")
                .IsRequired();

            builder.Property(x => x.Origin)
                .HasColumnType("varchar(100)")
                .IsRequired();

            builder.Property(x => x.CreatedAt)
                .HasColumnType("smalldatetime")
                .IsRequired();
        }
    }
}
