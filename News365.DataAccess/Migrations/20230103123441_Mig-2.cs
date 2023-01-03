using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace News365.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class Mig2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DateTime",
                table: "News",
                newName: "CreateTime");

            migrationBuilder.AddColumn<Guid>(
                name: "CategoryId1",
                table: "News",
                type: "char(36)",
                nullable: true,
                collation: "ascii_general_ci");

            migrationBuilder.CreateIndex(
                name: "IX_News_CategoryId1",
                table: "News",
                column: "CategoryId1");

            migrationBuilder.AddForeignKey(
                name: "FK_News_Categories_CategoryId1",
                table: "News",
                column: "CategoryId1",
                principalTable: "Categories",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_News_Categories_CategoryId1",
                table: "News");

            migrationBuilder.DropIndex(
                name: "IX_News_CategoryId1",
                table: "News");

            migrationBuilder.DropColumn(
                name: "CategoryId1",
                table: "News");

            migrationBuilder.RenameColumn(
                name: "CreateTime",
                table: "News",
                newName: "DateTime");
        }
    }
}
