using Microsoft.EntityFrameworkCore.Migrations;

namespace EntityFramework.Migrations
{
    public partial class ManytoManyPatrolsPolice : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Patrols_Policjants_PolicjantId",
                table: "Patrols");

            migrationBuilder.DropIndex(
                name: "IX_Patrols_PolicjantId",
                table: "Patrols");

            migrationBuilder.DropColumn(
                name: "PolicjantId",
                table: "Patrols");

            migrationBuilder.CreateTable(
                name: "PatrolPolicjant",
                columns: table => new
                {
                    PatrolsPatrolId = table.Column<int>(type: "int", nullable: false),
                    PolicjantId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PatrolPolicjant", x => new { x.PatrolsPatrolId, x.PolicjantId });
                    table.ForeignKey(
                        name: "FK_PatrolPolicjant_Patrols_PatrolsPatrolId",
                        column: x => x.PatrolsPatrolId,
                        principalTable: "Patrols",
                        principalColumn: "PatrolId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PatrolPolicjant_Policjants_PolicjantId",
                        column: x => x.PolicjantId,
                        principalTable: "Policjants",
                        principalColumn: "PolicjantId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "Policjants",
                keyColumn: "PolicjantId",
                keyValue: 1,
                column: "RangaId",
                value: 18);

            migrationBuilder.CreateIndex(
                name: "IX_PatrolPolicjant_PolicjantId",
                table: "PatrolPolicjant",
                column: "PolicjantId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PatrolPolicjant");

            migrationBuilder.AddColumn<int>(
                name: "PolicjantId",
                table: "Patrols",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Policjants",
                keyColumn: "PolicjantId",
                keyValue: 1,
                column: "RangaId",
                value: 1);

            migrationBuilder.CreateIndex(
                name: "IX_Patrols_PolicjantId",
                table: "Patrols",
                column: "PolicjantId");

            migrationBuilder.AddForeignKey(
                name: "FK_Patrols_Policjants_PolicjantId",
                table: "Patrols",
                column: "PolicjantId",
                principalTable: "Policjants",
                principalColumn: "PolicjantId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
