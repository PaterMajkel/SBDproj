using Microsoft.EntityFrameworkCore.Migrations;

namespace EntityFramework.Migrations
{
    public partial class brokeConventions : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PatrolPolicjant_Policjants_PolicjantId",
                table: "PatrolPolicjant");

            migrationBuilder.RenameColumn(
                name: "PolicjantId",
                table: "PatrolPolicjant",
                newName: "PolicjantsPolicjantId");

            migrationBuilder.RenameIndex(
                name: "IX_PatrolPolicjant_PolicjantId",
                table: "PatrolPolicjant",
                newName: "IX_PatrolPolicjant_PolicjantsPolicjantId");

            migrationBuilder.AddForeignKey(
                name: "FK_PatrolPolicjant_Policjants_PolicjantsPolicjantId",
                table: "PatrolPolicjant",
                column: "PolicjantsPolicjantId",
                principalTable: "Policjants",
                principalColumn: "PolicjantId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PatrolPolicjant_Policjants_PolicjantsPolicjantId",
                table: "PatrolPolicjant");

            migrationBuilder.RenameColumn(
                name: "PolicjantsPolicjantId",
                table: "PatrolPolicjant",
                newName: "PolicjantId");

            migrationBuilder.RenameIndex(
                name: "IX_PatrolPolicjant_PolicjantsPolicjantId",
                table: "PatrolPolicjant",
                newName: "IX_PatrolPolicjant_PolicjantId");

            migrationBuilder.AddForeignKey(
                name: "FK_PatrolPolicjant_Policjants_PolicjantId",
                table: "PatrolPolicjant",
                column: "PolicjantId",
                principalTable: "Policjants",
                principalColumn: "PolicjantId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
