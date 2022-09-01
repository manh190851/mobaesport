using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MoBaEsport.Data.EntityModel;

namespace MoBaEsport.Data.Configuration
{
    public class ReactionConfiguration : IEntityTypeConfiguration<Reaction>
    {
        public void Configure(EntityTypeBuilder<Reaction> builder)
        {
            builder.ToTable("Reactions");

            builder.HasKey(m => m.ReacId);

            builder.Property(m => m.ReacName).IsRequired().HasMaxLength(20);
            builder.Property(m => m.Created).IsRequired();

            builder.HasOne(m => m.Post).WithMany(m => m.Reactions).HasForeignKey(m => m.PostId);
            builder.HasOne(m => m.Comment).WithMany(m => m.Reactions).HasForeignKey(m => m.ComId);
            builder.HasOne(m => m.User).WithMany(m => m.Reactions).HasForeignKey(m => m.UserId);
            builder.HasOne(m => m.Reply).WithMany(m => m.Reactions).HasForeignKey(m => m.ReplyId);
        }
    }
}