using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MoBaEsport.Data.EntityModel;

namespace MoBaEsport.Data.Configuration
{
    public class FollowConfiguration : IEntityTypeConfiguration<Follow>
    {
        public void Configure(EntityTypeBuilder<Follow> builder)
        {
            builder.ToTable("Follows");

            builder.HasKey(m => m.FollowId);

            builder.Property(m => m.Created).IsRequired();

            builder.HasOne(m => m.Follower).WithMany(m => m.Following).HasForeignKey(m => m.FollowerId);
            builder.HasOne(m => m.Following).WithMany(m => m.Followers).HasForeignKey(m => m.FollowingId);
        }
    }
}