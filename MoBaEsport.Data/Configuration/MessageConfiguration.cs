using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MoBaEsport.Data.EntityModel;

namespace MoBaEsport.Data.Configuration
{
    public class MessageConfiguration : IEntityTypeConfiguration<Message>
    {
        public void Configure(EntityTypeBuilder<Message> builder)
        {
            builder.ToTable("Messages");

            builder.HasKey(m => m.MessageId);

            builder.HasOne(m => m.Sender).WithMany(m => m.SendMessage).HasForeignKey(m => m.SenderId);

            builder.HasOne(m => m.ChatBox).WithMany(m => m.Messages).HasForeignKey(m => m.ChatBoxId);

            builder.Property(m => m.Content).IsRequired();
            builder.Property(m => m.Created).IsRequired();
        }
    }
}