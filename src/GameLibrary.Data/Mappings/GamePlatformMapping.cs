﻿using GameLibrary.Data.Extensions;
using GameLibrary.Domain.Entities.Games;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GameLibrary.Data.Mappings
{
    public class GamePlatformMapping : EntityTypeConfiguration<GamePlatform>
    {
        public override void Map(EntityTypeBuilder<GamePlatform> builder)
        {
            builder.HasKey(pg => new { pg.GameId, pg.PlatformId });

            builder.HasOne(g => g.Game)
                .WithMany(pg => pg.GamePlatform)
                .HasForeignKey(g => g.GameId);

            builder.HasOne(p => p.Platform)
                .WithMany(pg => pg.GamePlatform)
                .HasForeignKey(p => p.PlatformId);

            builder.Ignore(e => e.Platform);

            builder.ToTable("JogosPlataformas");
        }
    }
}