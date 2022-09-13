using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MoBaEsport.Data.Migrations
{
    public partial class Fixchatboxfriend : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ChatBoxs_AppUsers_ChatWithId",
                table: "ChatBoxs");

            migrationBuilder.DropForeignKey(
                name: "FK_ChatBoxs_AppUsers_OwnerId",
                table: "ChatBoxs");

            migrationBuilder.DropIndex(
                name: "IX_ChatBoxs_ChatWithId",
                table: "ChatBoxs");

            migrationBuilder.DropIndex(
                name: "IX_ChatBoxs_OwnerId",
                table: "ChatBoxs");

            migrationBuilder.DropColumn(
                name: "ChatWithId",
                table: "ChatBoxs");

            migrationBuilder.DropColumn(
                name: "OwnerId",
                table: "ChatBoxs");

            migrationBuilder.AddColumn<string>(
                name: "ChatBoxColor",
                table: "ChatBoxs",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<long>(
                name: "FriendId",
                table: "ChatBoxs",
                type: "biglong",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateIndex(
                name: "IX_ChatBoxs_FriendId",
                table: "ChatBoxs",
                column: "FriendId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ChatBoxs_Friends_FriendId",
                table: "ChatBoxs",
                column: "FriendId",
                principalTable: "Friends",
                principalColumn: "FriendId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ChatBoxs_Friends_FriendId",
                table: "ChatBoxs");

            migrationBuilder.DropIndex(
                name: "IX_ChatBoxs_FriendId",
                table: "ChatBoxs");

            migrationBuilder.DropColumn(
                name: "ChatBoxColor",
                table: "ChatBoxs");

            migrationBuilder.DropColumn(
                name: "FriendId",
                table: "ChatBoxs");

            migrationBuilder.AddColumn<Guid>(
                name: "ChatWithId",
                table: "ChatBoxs",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "OwnerId",
                table: "ChatBoxs",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_ChatBoxs_ChatWithId",
                table: "ChatBoxs",
                column: "ChatWithId");

            migrationBuilder.CreateIndex(
                name: "IX_ChatBoxs_OwnerId",
                table: "ChatBoxs",
                column: "OwnerId");

            migrationBuilder.AddForeignKey(
                name: "FK_ChatBoxs_AppUsers_ChatWithId",
                table: "ChatBoxs",
                column: "ChatWithId",
                principalTable: "AppUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ChatBoxs_AppUsers_OwnerId",
                table: "ChatBoxs",
                column: "OwnerId",
                principalTable: "AppUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
