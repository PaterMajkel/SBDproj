using Microsoft.EntityFrameworkCore.Migrations;

namespace EntityFramework.Migrations
{
    public partial class IsItDueWrongConvention2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Komendas_Region_Miastas_Region_MiastaID_regionu",
                table: "Komendas");

            migrationBuilder.DropForeignKey(
                name: "FK_Region_Miastas_Miastos_MiastoID_miasta",
                table: "Region_Miastas");

            migrationBuilder.DropIndex(
                name: "IX_Region_Miastas_MiastoID_miasta",
                table: "Region_Miastas");

            migrationBuilder.DropIndex(
                name: "IX_Komendas_Region_MiastaID_regionu",
                table: "Komendas");

            migrationBuilder.DropColumn(
                name: "MiastoID_miasta",
                table: "Region_Miastas");

            migrationBuilder.DropColumn(
                name: "Region_MiastaID_regionu",
                table: "Komendas");

            migrationBuilder.RenameColumn(
                name: "ID_miasta",
                table: "Region_Miastas",
                newName: "MiastoId");

            migrationBuilder.RenameColumn(
                name: "ID_regionu",
                table: "Komendas",
                newName: "Region_MiastaId");

            migrationBuilder.CreateIndex(
                name: "IX_Region_Miastas_MiastoId",
                table: "Region_Miastas",
                column: "MiastoId");

            migrationBuilder.CreateIndex(
                name: "IX_Komendas_Region_MiastaId",
                table: "Komendas",
                column: "Region_MiastaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Komendas_Region_Miastas_Region_MiastaId",
                table: "Komendas",
                column: "Region_MiastaId",
                principalTable: "Region_Miastas",
                principalColumn: "ID_regionu",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Region_Miastas_Miastos_MiastoId",
                table: "Region_Miastas",
                column: "MiastoId",
                principalTable: "Miastos",
                principalColumn: "ID_miasta",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Komendas_Region_Miastas_Region_MiastaId",
                table: "Komendas");

            migrationBuilder.DropForeignKey(
                name: "FK_Region_Miastas_Miastos_MiastoId",
                table: "Region_Miastas");

            migrationBuilder.DropIndex(
                name: "IX_Region_Miastas_MiastoId",
                table: "Region_Miastas");

            migrationBuilder.DropIndex(
                name: "IX_Komendas_Region_MiastaId",
                table: "Komendas");

            migrationBuilder.RenameColumn(
                name: "MiastoId",
                table: "Region_Miastas",
                newName: "ID_miasta");

            migrationBuilder.RenameColumn(
                name: "Region_MiastaId",
                table: "Komendas",
                newName: "ID_regionu");

            migrationBuilder.AddColumn<int>(
                name: "MiastoID_miasta",
                table: "Region_Miastas",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Region_MiastaID_regionu",
                table: "Komendas",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Region_Miastas_MiastoID_miasta",
                table: "Region_Miastas",
                column: "MiastoID_miasta");

            migrationBuilder.CreateIndex(
                name: "IX_Komendas_Region_MiastaID_regionu",
                table: "Komendas",
                column: "Region_MiastaID_regionu");

            migrationBuilder.AddForeignKey(
                name: "FK_Komendas_Region_Miastas_Region_MiastaID_regionu",
                table: "Komendas",
                column: "Region_MiastaID_regionu",
                principalTable: "Region_Miastas",
                principalColumn: "ID_regionu",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Region_Miastas_Miastos_MiastoID_miasta",
                table: "Region_Miastas",
                column: "MiastoID_miasta",
                principalTable: "Miastos",
                principalColumn: "ID_miasta",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
