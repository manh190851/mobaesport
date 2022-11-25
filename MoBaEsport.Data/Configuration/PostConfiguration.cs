using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MoBaEsport.Data.EntityModel;

namespace MoBaEsport.Data.Configuration
{
    public class PostConfiguration : IEntityTypeConfiguration<Post>
    {
        public void Configure(EntityTypeBuilder<Post> builder)
        {
            builder.ToTable("Posts");

            builder.HasKey(m => m.PostId);

            builder.Property(m => m.Created).IsRequired();
            builder.Property(m => m.Status).IsRequired().HasConversion<string>();
            builder.Property(m => m.PostContent).IsRequired(false);
            builder.Property(m => m.IsHidden).HasDefaultValue(false);
            builder.Property(m => m.ShareCount);
            builder.Property(m => m.SharePostId).IsRequired(false);

            builder.HasOne(m => m.User).WithMany(m => m.Posts).HasForeignKey(m => m.UserId);
            builder.HasOne(m => m.game).WithMany(m => m.postGame).HasForeignKey(m => m.gameId);
        }
    }
}