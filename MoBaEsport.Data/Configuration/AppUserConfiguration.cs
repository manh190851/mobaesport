using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MoBaEsport.Data.EntityModel;

namespace MoBaEsport.Data.Configuration
{
    public class AppUserConfiguration : IEntityTypeConfiguration<AppUser>
    {
        public void Configure(EntityTypeBuilder<AppUser> builder)
        {
            builder.ToTable("AppUsers");

            builder.Property(m => m.Fullname).IsRequired().HasMaxLength(100);

            builder.Property(m => m.Gender).IsRequired().HasConversion<string>();

            builder.Property(m => m.Phone).IsRequired();

            builder.Property(m => m.DOB).IsRequired();

            builder.Property(m => m.Nation).IsRequired().HasMaxLength(50);

            builder.Property(m => m.City).IsRequired().HasMaxLength(50);

            builder.Property(m => m.ImageUrl).HasDefaultValue("https://icon-library.com/images/icon-user/icon-user-15.jpg");
            builder.Property(m => m.LastLogin).IsRequired();

            builder.Property(m => m.LoginStatus).HasConversion<string>();
            builder.Property(m => m.UserStatus).HasConversion<string>();
        }
    }
}