using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace News365.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class Mig6 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "FullName", "Email", "Password", "Role" },
                values: new object[] { "Admin", "admin@admin.com", "Admin123", "Admin" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "FullName",
                keyValue: "Admin");
        }
    }
}
