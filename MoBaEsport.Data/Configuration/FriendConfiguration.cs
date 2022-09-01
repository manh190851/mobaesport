﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MoBaEsport.Data.EntityModel;

namespace MoBaEsport.Data.Configuration
{
    internal class FriendConfiguration : IEntityTypeConfiguration<Friend>
    {
        public void Configure(EntityTypeBuilder<Friend> builder)
        {
            builder.ToTable("Friends");

            builder.HasKey(m => m.FriendId);

            builder.Property(m => m.Status).IsRequired().HasMaxLength(20);
            builder.Property(m => m.Created).IsRequired();

            builder.HasOne(m => m.AcceptUser).WithMany(m => m.AcceptFriends).HasForeignKey(m => m.AcceptId);
            builder.HasOne(m => m.RequestUser).WithMany(m => m.RequestFriends).HasForeignKey(m => m.RequestId);
        }
    }
}