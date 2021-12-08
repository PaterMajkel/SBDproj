using Microsoft.EntityFrameworkCore.Migrations;

namespace EntityFramework.Migrations
{
    public partial class DefaultAdmin : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Uzytkowniks",
                columns: new[] { "ID_uzytkownika", "ID_policjanta", "Login", "Password", "PolicjantID_policjanta", "Rola" },
                values: new object[] { 1, null, "Admin", "Admin", null, "admin" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Uzytkowniks",
                keyColumn: "ID_uzytkownika",
                keyValue: 1);
        }
    }
}
