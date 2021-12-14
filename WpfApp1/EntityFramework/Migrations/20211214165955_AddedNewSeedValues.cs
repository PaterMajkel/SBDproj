using Microsoft.EntityFrameworkCore.Migrations;

namespace EntityFramework.Migrations
{
    public partial class AddedNewSeedValues : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Radiowozs",
                columns: new[] { "RadiowozId", "Marka", "Model", "Rok_produkcji" },
                values: new object[,]
                {
                    { 1, "BMW", "M3", 2016 },
                    { 2, "BMW", "M3", 2016 },
                    { 3, "BMW", "M3", 2016 },
                    { 4, "BMW", "M3", 2016 },
                    { 5, "BMW", "M3", 2016 },
                    { 6, "BMW", "M3", 2016 }
                });

            migrationBuilder.InsertData(
                table: "Rangas",
                columns: new[] { "RangaId", "Nazwa", "Pensja" },
                values: new object[,]
                {
                    { 15, "Inspektor", 4200.0 },
                    { 14, "Młodszy Inspektor", 4100.0 },
                    { 13, "Podinspektor", 4000.0 },
                    { 12, "Nadkomisarz", 3900.0 },
                    { 11, "Komisarz", 3800.0 },
                    { 10, "Podkomisarz", 3700.0 },
                    { 9, "Aspirant Sztabowy", 3600.0 },
                    { 6, "Młodszy Aspirant", 3300.0 },
                    { 7, "Aspirant", 3400.0 },
                    { 16, "Nadinspektor", 4300.0 },
                    { 5, "Sierżant Sztabowy", 3200.0 },
                    { 4, "Starszy Sierżant", 3100.0 },
                    { 3, "Sierżant", 3000.0 },
                    { 2, "Starszy Posterunkowy", 2900.0 },
                    { 1, "Posterunkowy", 2800.0 },
                    { 8, "Starszy Aspirant", 3500.0 },
                    { 17, "Generalny Inspektor", 4400.0 }
                });

            migrationBuilder.InsertData(
                table: "Policjants",
                columns: new[] { "PolicjantId", "Imie", "KomendaId", "Nazwisko", "RangaId" },
                values: new object[,]
                {
                    { 1, "Adam", 1, "Pogorzelski", 1 },
                    { 2, "Krzysztof", 1, "Gonciarz", 2 },
                    { 3, "Tomasz", 1, "Działowy", 3 },
                    { 4, "Antoni", 1, "Macierewicz", 4 },
                    { 5, "Darth", 1, "Vader", 5 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Policjants",
                keyColumn: "PolicjantId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Policjants",
                keyColumn: "PolicjantId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Policjants",
                keyColumn: "PolicjantId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Policjants",
                keyColumn: "PolicjantId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Policjants",
                keyColumn: "PolicjantId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Radiowozs",
                keyColumn: "RadiowozId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Radiowozs",
                keyColumn: "RadiowozId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Radiowozs",
                keyColumn: "RadiowozId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Radiowozs",
                keyColumn: "RadiowozId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Radiowozs",
                keyColumn: "RadiowozId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Radiowozs",
                keyColumn: "RadiowozId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Rangas",
                keyColumn: "RangaId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Rangas",
                keyColumn: "RangaId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Rangas",
                keyColumn: "RangaId",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Rangas",
                keyColumn: "RangaId",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Rangas",
                keyColumn: "RangaId",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Rangas",
                keyColumn: "RangaId",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Rangas",
                keyColumn: "RangaId",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Rangas",
                keyColumn: "RangaId",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Rangas",
                keyColumn: "RangaId",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Rangas",
                keyColumn: "RangaId",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Rangas",
                keyColumn: "RangaId",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Rangas",
                keyColumn: "RangaId",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Rangas",
                keyColumn: "RangaId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Rangas",
                keyColumn: "RangaId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Rangas",
                keyColumn: "RangaId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Rangas",
                keyColumn: "RangaId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Rangas",
                keyColumn: "RangaId",
                keyValue: 5);
        }
    }
}
