using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApiDemo.Migrations
{
    /// <inheritdoc />
    public partial class UserSeeding : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "user_account",
                columns: new[] { "id", "full_name", "password", "user_name" },
                values: new object[] { 1, "Administrator", "AQAAAAIAAYagAAAAEJvVuMABrS4m/P9IVSl6JWd1sBXSAZp//WCFQhiDUSlUvHgeM1uST9f1ufCsn4w9tw==", "admin" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "user_account",
                keyColumn: "id",
                keyValue: 1);
        }
    }
}
