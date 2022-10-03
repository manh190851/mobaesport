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
    public class PostFileConfiguration : IEntityTypeConfiguration<PostFile>
    {
        public void Configure(EntityTypeBuilder<PostFile> builder)
        {
            builder.ToTable("Files");

            builder.HasKey(m => m.Id);

            builder.Property(m => m.FilePath).IsRequired(true);
            builder.Property(m => m.IsDefault);
            builder.Property(m => m.DateCreate);

            builder.HasOne(m => m.Post).WithMany(m => m.PostFiles).HasForeignKey(m => m.PostId);
            
        }
    }
}
