using Microsoft.EntityFrameworkCore.Migrations;

namespace EntityFramework.Migrations
{
    public partial class MoreSeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Komendas",
                columns: new[] { "ID_komendy", "Adres", "ID_regionu", "RegionID_regionu" },
                values: new object[,]
                {
                    { 1, "Muchomorska 9", 1, null },
                    { 2, "Zawadiaków 14", 2, null },
                    { 3, "Mirosławska 15", 4, null },
                    { 4, "Piątków 21/7", 5, null },
                    { 5, "Miłosierdzia Pańskiego 2137", 6, null },
                    { 6, "Obi-Wana Kenobiego 3", 7, null },
                    { 7, "Plackowa 98", 8, null },
                    { 8, "Iglasta 41", 3, null },
                    { 9, "Chrobrego 21", 9, null }
                });

            migrationBuilder.InsertData(
                table: "Miastos",
                columns: new[] { "ID_miasta", "Nazwa" },
                values: new object[,]
                {
                    { 9, "Poznań" },
                    { 8, "Wrocław" },
                    { 7, "Katowice" },
                    { 6, "Gdańsk" },
                    { 5, "Łódź" },
                    { 4, "Rzeszów" },
                    { 3, "Warszawa" },
                    { 2, "Kraków" },
                    { 1, "Białystok" }
                });

            migrationBuilder.InsertData(
                table: "Region_Miastas",
                columns: new[] { "ID_regionu", "ID_miasta", "MiastoID_miasta", "Nazwa", "Stopien_zagrozenia" },
                values: new object[,]
                {
                    { 1, 1, null, "Piasta", "Niski" },
                    { 2, 1, null, "Skorupy", "Wysoki" },
                    { 3, 5, null, "Bałuty", "Śmiertelny" },
                    { 4, 9, null, "Paciorków", "Średni" },
                    { 5, 4, null, "Puchatkowo", "Niski" },
                    { 6, 3, null, "Niski Stok", "Wysoki" },
                    { 7, 3, null, "Średnia Górka", "Niski" },
                    { 8, 8, null, "Swoja", "Średni" },
                    { 9, 7, null, "Chmurzyńska Wieś", "Śmiertelny" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Komendas",
                keyColumn: "ID_komendy",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Komendas",
                keyColumn: "ID_komendy",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Komendas",
                keyColumn: "ID_komendy",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Komendas",
                keyColumn: "ID_komendy",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Komendas",
                keyColumn: "ID_komendy",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Komendas",
                keyColumn: "ID_komendy",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Komendas",
                keyColumn: "ID_komendy",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Komendas",
                keyColumn: "ID_komendy",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Komendas",
                keyColumn: "ID_komendy",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Miastos",
                keyColumn: "ID_miasta",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Miastos",
                keyColumn: "ID_miasta",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Miastos",
                keyColumn: "ID_miasta",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Miastos",
                keyColumn: "ID_miasta",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Miastos",
                keyColumn: "ID_miasta",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Miastos",
                keyColumn: "ID_miasta",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Miastos",
                keyColumn: "ID_miasta",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Miastos",
                keyColumn: "ID_miasta",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Miastos",
                keyColumn: "ID_miasta",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Region_Miastas",
                keyColumn: "ID_regionu",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Region_Miastas",
                keyColumn: "ID_regionu",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Region_Miastas",
                keyColumn: "ID_regionu",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Region_Miastas",
                keyColumn: "ID_regionu",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Region_Miastas",
                keyColumn: "ID_regionu",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Region_Miastas",
                keyColumn: "ID_regionu",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Region_Miastas",
                keyColumn: "ID_regionu",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Region_Miastas",
                keyColumn: "ID_regionu",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Region_Miastas",
                keyColumn: "ID_regionu",
                keyValue: 9);
        }
    }
}
