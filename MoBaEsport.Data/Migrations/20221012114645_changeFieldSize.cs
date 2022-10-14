using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MoBaEsport.Data.Migrations
{
    public partial class changeFieldSize : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PostFile_Posts_PostId",
                table: "PostFile");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PostFile",
                table: "PostFile");

            migrationBuilder.RenameTable(
                name: "PostFile",
                newName: "Files");

            migrationBuilder.RenameIndex(
                name: "IX_PostFile_PostId",
                table: "Files",
                newName: "IX_Files_PostId");

            migrationBuilder.AlterColumn<long>(
                name: "Size",
                table: "Files",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Files",
                table: "Files",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Files_Posts_PostId",
                table: "Files",
                column: "PostId",
                principalTable: "Posts",
                principalColumn: "PostId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Files_Posts_PostId",
                table: "Files");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Files",
                table: "Files");

            migrationBuilder.RenameTable(
                name: "Files",
                newName: "PostFile");

            migrationBuilder.RenameIndex(
                name: "IX_Files_PostId",
                table: "PostFile",
                newName: "IX_PostFile_PostId");

            migrationBuilder.AlterColumn<int>(
                name: "Size",
                table: "PostFile",
                type: "int",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PostFile",
                table: "PostFile",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PostFile_Posts_PostId",
                table: "PostFile",
                column: "PostId",
                principalTable: "Posts",
                principalColumn: "PostId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
