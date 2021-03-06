﻿using GameLibrary.Data.Extensions;
using GameLibrary.Domain.Entities.Games;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GameLibrary.Data.Mappings
{
    public class DeveloperMapping : EntityTypeConfiguration<Developer>
    {
        public override void Map(EntityTypeBuilder<Developer> builder)
        {
            builder.Property(c => c.Name)
               .HasColumnType("varchar(150)")
               .IsRequired();

            builder.Property(c => c.Founded)
               .HasColumnType("datetime")
               .IsRequired();

            builder.Property(c => c.WebSite)
               .HasColumnType("varchar(150)")
               .IsRequired(false);

            //builder.Ignore(e => e.ValidationResult);

            //builder.Ignore(e => e.CascadeMode);

            builder.Ignore(e => e.Erros);

            builder.ToTable("Desenvolvedoras");
        }
    }
}