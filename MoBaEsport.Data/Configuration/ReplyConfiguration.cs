using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MoBaEsport.Data.EntityModel;

namespace MoBaEsport.Data.Configuration
{
    public class ReplyConfiguration : IEntityTypeConfiguration<Reply>
    {
        public void Configure(EntityTypeBuilder<Reply> builder)
        {
            builder.ToTable("Replys");

            builder.HasKey(m => m.ReplyId);

            builder.Property(m => m.ReplyContent).IsRequired();
            builder.Property(m => m.Created).IsRequired();

            builder.HasOne(m => m.Comment).WithMany(m => m.Replys).HasForeignKey(m => m.ComId);
            builder.HasOne(m => m.User).WithMany(m => m.Replys).HasForeignKey(m => m.UserId);
        }
    }
}