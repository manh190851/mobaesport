﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MoBaEsport.Data.DBContextModel;

#nullable disable

namespace MoBaEsport.Data.Migrations
{
    [DbContext(typeof(ESportDbContext))]
    [Migration("20220901135422_initial")]
    partial class initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<System.Guid>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.ToTable("AppRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<System.Guid>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.ToTable("AppUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<System.Guid>", b =>
                {
                    b.Property<Guid>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId");

                    b.ToTable("AppUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<System.Guid>", b =>
                {
                    b.Property<Guid>("RoleId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("RoleId", "UserId");

                    b.ToTable("AppUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<System.Guid>", b =>
                {
                    b.Property<Guid>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId");

                    b.ToTable("AppUserToken", (string)null);
                });

            modelBuilder.Entity("MoBaEsport.Data.EntityModel.AppRole", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ConcurrencyStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NormalizedName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("AppRoles", (string)null);
                });

            modelBuilder.Entity("MoBaEsport.Data.EntityModel.AppUser", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("ConcurrencyStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DOB")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("Fullname")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("Gender")
                        .HasColumnType("int");

                    b.Property<string>("ImageUrl")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(max)")
                        .HasDefaultValue("https://icon-library.com/images/icon-user/icon-user-15.jpg");

                    b.Property<DateTime>("LastLogin")
                        .HasColumnType("datetime2");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<int>("LoginStatus")
                        .HasMaxLength(50)
                        .HasColumnType("int");

                    b.Property<string>("Nation")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("NormalizedEmail")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NormalizedUserName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserStatus")
                        .HasMaxLength(50)
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("AppUsers", (string)null);
                });

            modelBuilder.Entity("MoBaEsport.Data.EntityModel.ChatBox", b =>
                {
                    b.Property<long>("ChatBoxId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("ChatBoxId"), 1L, 1);

                    b.Property<Guid>("ChatWithId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("OwnerId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("ChatBoxId");

                    b.HasIndex("ChatWithId");

                    b.HasIndex("OwnerId");

                    b.ToTable("ChatBoxs", (string)null);
                });

            modelBuilder.Entity("MoBaEsport.Data.EntityModel.Comment", b =>
                {
                    b.Property<long>("ComId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("ComId"), 1L, 1);

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<long>("PostId")
                        .HasColumnType("bigint");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("ComId");

                    b.HasIndex("PostId");

                    b.HasIndex("UserId");

                    b.ToTable("Comments", (string)null);
                });

            modelBuilder.Entity("MoBaEsport.Data.EntityModel.Follow", b =>
                {
                    b.Property<long>("FollowId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("FollowId"), 1L, 1);

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("FollowerId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("FollowingId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("FollowId");

                    b.HasIndex("FollowerId");

                    b.HasIndex("FollowingId");

                    b.ToTable("Follows", (string)null);
                });

            modelBuilder.Entity("MoBaEsport.Data.EntityModel.Friend", b =>
                {
                    b.Property<long>("FriendId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("FriendId"), 1L, 1);

                    b.Property<Guid>("AcceptId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("RequestId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Status")
                        .HasMaxLength(20)
                        .HasColumnType("int");

                    b.HasKey("FriendId");

                    b.HasIndex("AcceptId");

                    b.HasIndex("RequestId");

                    b.ToTable("Friends", (string)null);
                });

            modelBuilder.Entity("MoBaEsport.Data.EntityModel.Message", b =>
                {
                    b.Property<long>("MessageId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("MessageId"), 1L, 1);

                    b.Property<long>("ChatBoxId")
                        .HasColumnType("bigint");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("SenderId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("MessageId");

                    b.HasIndex("ChatBoxId");

                    b.HasIndex("SenderId");

                    b.ToTable("Messages", (string)null);
                });

            modelBuilder.Entity("MoBaEsport.Data.EntityModel.Post", b =>
                {
                    b.Property<long>("PostId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("PostId"), 1L, 1);

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsHidden")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false);

                    b.Property<string>("PostContent")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("ShareCount")
                        .HasColumnType("bigint");

                    b.Property<long?>("SharePostId")
                        .HasColumnType("bigint");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("PostId");

                    b.HasIndex("SharePostId");

                    b.HasIndex("UserId");

                    b.ToTable("Posts", (string)null);
                });

            modelBuilder.Entity("MoBaEsport.Data.EntityModel.Reaction", b =>
                {
                    b.Property<long>("ReacId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("ReacId"), 1L, 1);

                    b.Property<long?>("ComId")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<long?>("PostId")
                        .HasColumnType("bigint");

                    b.Property<int>("ReacName")
                        .HasMaxLength(20)
                        .HasColumnType("int");

                    b.Property<long?>("ReplyId")
                        .HasColumnType("bigint");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("ReacId");

                    b.HasIndex("ComId");

                    b.HasIndex("PostId");

                    b.HasIndex("ReplyId");

                    b.HasIndex("UserId");

                    b.ToTable("Reactions", (string)null);
                });

            modelBuilder.Entity("MoBaEsport.Data.EntityModel.Reply", b =>
                {
                    b.Property<long>("ReplyId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("ReplyId"), 1L, 1);

                    b.Property<long>("ComId")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<string>("ReplyContent")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("ReplyId");

                    b.HasIndex("ComId");

                    b.HasIndex("UserId");

                    b.ToTable("Replys", (string)null);
                });

            modelBuilder.Entity("MoBaEsport.Data.EntityModel.ChatBox", b =>
                {
                    b.HasOne("MoBaEsport.Data.EntityModel.AppUser", "ChatWithUser")
                        .WithMany("ChatBoxes")
                        .HasForeignKey("ChatWithId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MoBaEsport.Data.EntityModel.AppUser", "BoxOwner")
                        .WithMany("OwnerChatBoxes")
                        .HasForeignKey("OwnerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("BoxOwner");

                    b.Navigation("ChatWithUser");
                });

            modelBuilder.Entity("MoBaEsport.Data.EntityModel.Comment", b =>
                {
                    b.HasOne("MoBaEsport.Data.EntityModel.Post", "Post")
                        .WithMany("Comments")
                        .HasForeignKey("PostId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MoBaEsport.Data.EntityModel.AppUser", "User")
                        .WithMany("Comments")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Post");

                    b.Navigation("User");
                });

            modelBuilder.Entity("MoBaEsport.Data.EntityModel.Follow", b =>
                {
                    b.HasOne("MoBaEsport.Data.EntityModel.AppUser", "Follower")
                        .WithMany("Following")
                        .HasForeignKey("FollowerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MoBaEsport.Data.EntityModel.AppUser", "Following")
                        .WithMany("Followers")
                        .HasForeignKey("FollowingId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Follower");

                    b.Navigation("Following");
                });

            modelBuilder.Entity("MoBaEsport.Data.EntityModel.Friend", b =>
                {
                    b.HasOne("MoBaEsport.Data.EntityModel.AppUser", "AcceptUser")
                        .WithMany("AcceptFriends")
                        .HasForeignKey("AcceptId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MoBaEsport.Data.EntityModel.AppUser", "RequestUser")
                        .WithMany("RequestFriends")
                        .HasForeignKey("RequestId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AcceptUser");

                    b.Navigation("RequestUser");
                });

            modelBuilder.Entity("MoBaEsport.Data.EntityModel.Message", b =>
                {
                    b.HasOne("MoBaEsport.Data.EntityModel.ChatBox", "ChatBox")
                        .WithMany("Messages")
                        .HasForeignKey("ChatBoxId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MoBaEsport.Data.EntityModel.AppUser", "Sender")
                        .WithMany("SendMessage")
                        .HasForeignKey("SenderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ChatBox");

                    b.Navigation("Sender");
                });

            modelBuilder.Entity("MoBaEsport.Data.EntityModel.Post", b =>
                {
                    b.HasOne("MoBaEsport.Data.EntityModel.Post", "SharePost")
                        .WithMany()
                        .HasForeignKey("SharePostId");

                    b.HasOne("MoBaEsport.Data.EntityModel.AppUser", "User")
                        .WithMany("Posts")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("SharePost");

                    b.Navigation("User");
                });

            modelBuilder.Entity("MoBaEsport.Data.EntityModel.Reaction", b =>
                {
                    b.HasOne("MoBaEsport.Data.EntityModel.Comment", "Comment")
                        .WithMany("Reactions")
                        .HasForeignKey("ComId");

                    b.HasOne("MoBaEsport.Data.EntityModel.Post", "Post")
                        .WithMany("Reactions")
                        .HasForeignKey("PostId");

                    b.HasOne("MoBaEsport.Data.EntityModel.Reply", "Reply")
                        .WithMany("Reactions")
                        .HasForeignKey("ReplyId");

                    b.HasOne("MoBaEsport.Data.EntityModel.AppUser", "User")
                        .WithMany("Reactions")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Comment");

                    b.Navigation("Post");

                    b.Navigation("Reply");

                    b.Navigation("User");
                });

            modelBuilder.Entity("MoBaEsport.Data.EntityModel.Reply", b =>
                {
                    b.HasOne("MoBaEsport.Data.EntityModel.Comment", "Comment")
                        .WithMany("Replys")
                        .HasForeignKey("ComId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MoBaEsport.Data.EntityModel.AppUser", "User")
                        .WithMany("Replys")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Comment");

                    b.Navigation("User");
                });

            modelBuilder.Entity("MoBaEsport.Data.EntityModel.AppUser", b =>
                {
                    b.Navigation("AcceptFriends");

                    b.Navigation("ChatBoxes");

                    b.Navigation("Comments");

                    b.Navigation("Followers");

                    b.Navigation("Following");

                    b.Navigation("OwnerChatBoxes");

                    b.Navigation("Posts");

                    b.Navigation("Reactions");

                    b.Navigation("Replys");

                    b.Navigation("RequestFriends");

                    b.Navigation("SendMessage");
                });

            modelBuilder.Entity("MoBaEsport.Data.EntityModel.ChatBox", b =>
                {
                    b.Navigation("Messages");
                });

            modelBuilder.Entity("MoBaEsport.Data.EntityModel.Comment", b =>
                {
                    b.Navigation("Reactions");

                    b.Navigation("Replys");
                });

            modelBuilder.Entity("MoBaEsport.Data.EntityModel.Post", b =>
                {
                    b.Navigation("Comments");

                    b.Navigation("Reactions");
                });

            modelBuilder.Entity("MoBaEsport.Data.EntityModel.Reply", b =>
                {
                    b.Navigation("Reactions");
                });
#pragma warning restore 612, 618
        }
    }
}
