using Microsoft.EntityFrameworkCore.Migrations;

namespace EntityFramework.Migrations
{
    public partial class AddedNeededAttribute : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Wykroczenias_Policjants_PolicjantID_policjanta",
                table: "Wykroczenias");

            migrationBuilder.DropIndex(
                name: "IX_Wykroczenias_PolicjantID_policjanta",
                table: "Wykroczenias");

            migrationBuilder.DropColumn(
                name: "PolicjantID_policjanta",
                table: "Wykroczenias");

            migrationBuilder.CreateTable(
                name: "PolicjantWykroczenia",
                columns: table => new
                {
                    PolicjantsID_policjanta = table.Column<int>(type: "int", nullable: false),
                    WykroczeniasID_wykroczenia = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PolicjantWykroczenia", x => new { x.PolicjantsID_policjanta, x.WykroczeniasID_wykroczenia });
                    table.ForeignKey(
                        name: "FK_PolicjantWykroczenia_Policjants_PolicjantsID_policjanta",
                        column: x => x.PolicjantsID_policjanta,
                        principalTable: "Policjants",
                        principalColumn: "ID_policjanta",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PolicjantWykroczenia_Wykroczenias_WykroczeniasID_wykroczenia",
                        column: x => x.WykroczeniasID_wykroczenia,
                        principalTable: "Wykroczenias",
                        principalColumn: "ID_wykroczenia",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PolicjantWykroczenia_WykroczeniasID_wykroczenia",
                table: "PolicjantWykroczenia",
                column: "WykroczeniasID_wykroczenia");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PolicjantWykroczenia");

            migrationBuilder.AddColumn<int>(
                name: "PolicjantID_policjanta",
                table: "Wykroczenias",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Wykroczenias_PolicjantID_policjanta",
                table: "Wykroczenias",
                column: "PolicjantID_policjanta");

            migrationBuilder.AddForeignKey(
                name: "FK_Wykroczenias_Policjants_PolicjantID_policjanta",
                table: "Wykroczenias",
                column: "PolicjantID_policjanta",
                principalTable: "Policjants",
                principalColumn: "ID_policjanta",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
