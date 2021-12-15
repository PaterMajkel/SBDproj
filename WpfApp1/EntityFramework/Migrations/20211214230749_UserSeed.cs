using Microsoft.EntityFrameworkCore.Migrations;

namespace EntityFramework.Migrations
{
    public partial class UserSeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Uzytkowniks",
                keyColumn: "UzytkownikId",
                keyValue: 1,
                columns: new[] { "Login", "Password" },
                values: new object[] { "admin", "admin" });

            migrationBuilder.InsertData(
                table: "Uzytkowniks",
                columns: new[] { "UzytkownikId", "IsActive", "Login", "Password", "PolicjantId", "Rola" },
                values: new object[] { 3, true, "xxx", "xxx", 3, "" });

            migrationBuilder.InsertData(
                table: "Uzytkowniks",
                columns: new[] { "UzytkownikId", "IsActive", "Login", "Password", "PolicjantId", "Rola" },
                values: new object[] { 2, true, "bruh", "bruh", 5, "" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Uzytkowniks",
                keyColumn: "UzytkownikId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Uzytkowniks",
                keyColumn: "UzytkownikId",
                keyValue: 3);

            migrationBuilder.UpdateData(
                table: "Uzytkowniks",
                keyColumn: "UzytkownikId",
                keyValue: 1,
                columns: new[] { "Login", "Password" },
                values: new object[] { "Admin", "Admin" });
        }
    }
}
