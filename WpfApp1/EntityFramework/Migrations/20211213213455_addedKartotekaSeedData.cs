using Microsoft.EntityFrameworkCore.Migrations;

namespace EntityFramework.Migrations
{
    public partial class addedKartotekaSeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Kartotekas",
                columns: new[] { "KartotekaId", "Imie", "Nazwisko", "Wiek", "Zdjecie" },
                values: new object[,]
                {
                    { 1, "Zuzanna", "Bagińska", 21, null },
                    { 2, "Lewis", "Hamilto", 37, null },
                    { 3, "Bruno", "Czech", 20, null },
                    { 4, "Stachu", "Jones", 74, null },
                    { 5, "Stanisław", "Wokulski", 30, null },
                    { 6, "Witold", "Gombrowicz", 43, null },
                    { 7, "Piotrek", "Parker", 30, null },
                    { 8, "Sara", "Sudoł", 23, null }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Kartotekas",
                keyColumn: "KartotekaId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Kartotekas",
                keyColumn: "KartotekaId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Kartotekas",
                keyColumn: "KartotekaId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Kartotekas",
                keyColumn: "KartotekaId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Kartotekas",
                keyColumn: "KartotekaId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Kartotekas",
                keyColumn: "KartotekaId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Kartotekas",
                keyColumn: "KartotekaId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Kartotekas",
                keyColumn: "KartotekaId",
                keyValue: 8);
        }
    }
}
