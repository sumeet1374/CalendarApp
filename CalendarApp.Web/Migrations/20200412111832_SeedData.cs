using Microsoft.EntityFrameworkCore.Migrations;

namespace CalendarApp.Web.Migrations
{
    public partial class SeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AppRole",
                columns: new[] { "Id", "Deleted", "Name" },
                values: new object[] { 1, false, "Admin" });

            migrationBuilder.InsertData(
                table: "AppRole",
                columns: new[] { "Id", "Deleted", "Name" },
                values: new object[] { 2, false, "Organizer" });

            migrationBuilder.InsertData(
                table: "AppRole",
                columns: new[] { "Id", "Deleted", "Name" },
                values: new object[] { 3, false, "Participant" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AppRole",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "AppRole",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "AppRole",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
