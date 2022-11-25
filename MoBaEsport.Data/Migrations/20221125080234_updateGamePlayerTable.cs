using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MoBaEsport.Data.Migrations
{
    public partial class updateGamePlayerTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Id",
                table: "GamePlayers");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "Id",
                table: "GamePlayers",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);
        }
    }
}
