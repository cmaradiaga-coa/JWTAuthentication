using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApiDemo.Migrations
{
    /// <inheritdoc />
    public partial class LaSegunda : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "user_account",
                keyColumn: "id",
                keyValue: 1);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "user_account",
                columns: new[] { "id", "full_name", "password", "user_name" },
                values: new object[] { 1, "Administrator", "AQAAAAIAAYagAAAAEF4Ym0bBfc3DPKUWx4mohkUpO0RVM3Iq62skbUVY6J9CYTOJlgWKLMY0etgNVXk0Pw==", "admin" });
        }
    }
}
