using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MoBaEsport.Data.EntityModel;

namespace MoBaEsport.Data.Configuration
{
    public class CommentConfiguration : IEntityTypeConfiguration<Comment>
    {
        public void Configure(EntityTypeBuilder<Comment> builder)
        {
            builder.ToTable("Comments");

            builder.HasKey(m => m.ComId);

            builder.Property(m => m.Content).IsRequired();
            builder.Property(m => m.Created).IsRequired();

            builder.HasOne(m => m.Post).WithMany(m => m.Comments).HasForeignKey(m => m.PostId);
            builder.HasOne(m => m.User).WithMany(m => m.Comments).HasForeignKey(m => m.UserId);
        }
    }
}