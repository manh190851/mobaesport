using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MoBaEsport.Data.Migrations
{
    public partial class addGameTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "gameId",
                table: "Posts",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Games",
                columns: table => new
                {
                    gameId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    gameName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    createDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    isActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Games", x => x.gameId);
                });

            migrationBuilder.CreateTable(
                name: "GamePlayers",
                columns: table => new
                {
                    playerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    gameId = table.Column<long>(type: "bigint", nullable: false),
                    Id = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GamePlayers", x => new { x.playerId, x.gameId });
                    table.ForeignKey(
                        name: "FK_GamePlayers_AppUsers_playerId",
                        column: x => x.playerId,
                        principalTable: "AppUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GamePlayers_Games_gameId",
                        column: x => x.gameId,
                        principalTable: "Games",
                        principalColumn: "gameId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Posts_gameId",
                table: "Posts",
                column: "gameId");

            migrationBuilder.CreateIndex(
                name: "IX_GamePlayers_gameId",
                table: "GamePlayers",
                column: "gameId");

            migrationBuilder.AddForeignKey(
                name: "FK_Posts_Games_gameId",
                table: "Posts",
                column: "gameId",
                principalTable: "Games",
                principalColumn: "gameId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Posts_Games_gameId",
                table: "Posts");

            migrationBuilder.DropTable(
                name: "GamePlayers");

            migrationBuilder.DropTable(
                name: "Games");

            migrationBuilder.DropIndex(
                name: "IX_Posts_gameId",
                table: "Posts");

            migrationBuilder.DropColumn(
                name: "gameId",
                table: "Posts");
        }
    }
}
