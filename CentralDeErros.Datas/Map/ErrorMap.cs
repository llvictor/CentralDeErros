using CentralDeErros.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace CentralDeErros.Datas.Map
{
    public class ErrorMap : IEntityTypeConfiguration<Error>
    {
        public void Configure(EntityTypeBuilder<Error> builder)
        {
            builder.ToTable("Error");

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

            builder.Property(x => x.Level)
                .HasColumnType("varchar(5)")
                .IsRequired();

            builder.Property(x => x.CreatedAt)
                .HasColumnType("smalldatetime")
                .IsRequired();
        }
    }
}
