using Microsoft.EntityFrameworkCore.Migrations;

namespace EntityFramework.Migrations
{
    public partial class IsItDueWrongConvention : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Komendas_Region_Miastas_RegionID_regionu",
                table: "Komendas");

            migrationBuilder.RenameColumn(
                name: "RegionID_regionu",
                table: "Komendas",
                newName: "Region_MiastaID_regionu");

            migrationBuilder.RenameIndex(
                name: "IX_Komendas_RegionID_regionu",
                table: "Komendas",
                newName: "IX_Komendas_Region_MiastaID_regionu");

            migrationBuilder.AddForeignKey(
                name: "FK_Komendas_Region_Miastas_Region_MiastaID_regionu",
                table: "Komendas",
                column: "Region_MiastaID_regionu",
                principalTable: "Region_Miastas",
                principalColumn: "ID_regionu",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Komendas_Region_Miastas_Region_MiastaID_regionu",
                table: "Komendas");

            migrationBuilder.RenameColumn(
                name: "Region_MiastaID_regionu",
                table: "Komendas",
                newName: "RegionID_regionu");

            migrationBuilder.RenameIndex(
                name: "IX_Komendas_Region_MiastaID_regionu",
                table: "Komendas",
                newName: "IX_Komendas_RegionID_regionu");

            migrationBuilder.AddForeignKey(
                name: "FK_Komendas_Region_Miastas_RegionID_regionu",
                table: "Komendas",
                column: "RegionID_regionu",
                principalTable: "Region_Miastas",
                principalColumn: "ID_regionu",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
