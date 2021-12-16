using Microsoft.EntityFrameworkCore.Migrations;

namespace EntityFramework.Migrations
{
    public partial class AddedAdminPolicemanToBugFix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Komendas",
                keyColumn: "KomendaId",
                keyValue: 1,
                columns: new[] { "Adres", "IsActive" },
                values: new object[] { "Panel Admina", false });

            migrationBuilder.InsertData(
                table: "Komendas",
                columns: new[] { "KomendaId", "Adres", "IsActive", "Region_MiastaId" },
                values: new object[] { 10, "Muchomorska 9", true, 1 });

            migrationBuilder.UpdateData(
                table: "Policjants",
                keyColumn: "PolicjantId",
                keyValue: 1,
                columns: new[] { "Imie", "IsActive", "Nazwisko" },
                values: new object[] { "Admin", false, "Admin" });

            migrationBuilder.UpdateData(
                table: "Policjants",
                keyColumn: "PolicjantId",
                keyValue: 2,
                column: "KomendaId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Policjants",
                keyColumn: "PolicjantId",
                keyValue: 3,
                column: "KomendaId",
                value: 3);

            migrationBuilder.UpdateData(
                table: "Policjants",
                keyColumn: "PolicjantId",
                keyValue: 4,
                column: "KomendaId",
                value: 4);

            migrationBuilder.UpdateData(
                table: "Policjants",
                keyColumn: "PolicjantId",
                keyValue: 5,
                column: "KomendaId",
                value: 2);

            migrationBuilder.InsertData(
                table: "Policjants",
                columns: new[] { "PolicjantId", "Imie", "IsActive", "KomendaId", "Nazwisko", "RangaId" },
                values: new object[] { 6, "Adam", true, 2, "Pogorzelski", 1 });

            migrationBuilder.InsertData(
                table: "Rangas",
                columns: new[] { "RangaId", "IsActive", "Nazwa", "Pensja" },
                values: new object[] { 18, false, "Admin", 0.0 });

            migrationBuilder.UpdateData(
                table: "Uzytkowniks",
                keyColumn: "UzytkownikId",
                keyValue: 1,
                column: "PolicjantId",
                value: 1);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Komendas",
                keyColumn: "KomendaId",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Policjants",
                keyColumn: "PolicjantId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Rangas",
                keyColumn: "RangaId",
                keyValue: 18);

            migrationBuilder.UpdateData(
                table: "Komendas",
                keyColumn: "KomendaId",
                keyValue: 1,
                columns: new[] { "Adres", "IsActive" },
                values: new object[] { "Muchomorska 9", true });

            migrationBuilder.UpdateData(
                table: "Policjants",
                keyColumn: "PolicjantId",
                keyValue: 1,
                columns: new[] { "Imie", "IsActive", "Nazwisko" },
                values: new object[] { "Adam", true, "Pogorzelski" });

            migrationBuilder.UpdateData(
                table: "Policjants",
                keyColumn: "PolicjantId",
                keyValue: 2,
                column: "KomendaId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Policjants",
                keyColumn: "PolicjantId",
                keyValue: 3,
                column: "KomendaId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Policjants",
                keyColumn: "PolicjantId",
                keyValue: 4,
                column: "KomendaId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Policjants",
                keyColumn: "PolicjantId",
                keyValue: 5,
                column: "KomendaId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Uzytkowniks",
                keyColumn: "UzytkownikId",
                keyValue: 1,
                column: "PolicjantId",
                value: null);
        }
    }
}
