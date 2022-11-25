using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MoBaEsport.Data.EntityModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoBaEsport.Data.Configuration
{
    public class GamePlayerConfiguration : IEntityTypeConfiguration<GamePlayer>
    {
        public void Configure(EntityTypeBuilder<GamePlayer> builder)
        {
            builder.ToTable("GamePlayers");
            builder.HasKey(m => new {m.playerId, m.gameId });
            builder.HasOne(m => m.player).WithMany(m => m.GamePlay).HasForeignKey(m => m.playerId);
            builder.HasOne(m => m.game).WithMany(m => m.players).HasForeignKey(m => m.gameId);

        }
    }
}
