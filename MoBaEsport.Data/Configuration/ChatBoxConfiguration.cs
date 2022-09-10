using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MoBaEsport.Data.EntityModel;

namespace MoBaEsport.Data.Configuration
{
    public class ChatBoxConfiguration : IEntityTypeConfiguration<ChatBox>
    {
        public void Configure(EntityTypeBuilder<ChatBox> builder)
        {
            builder.ToTable("ChatBoxs");

            builder.HasKey(m => m.ChatBoxId);

            builder.Property(m => m.ChatBoxColor);
        }
    }
}