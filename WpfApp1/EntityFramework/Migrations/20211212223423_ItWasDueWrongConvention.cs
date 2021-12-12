using Microsoft.EntityFrameworkCore.Migrations;

namespace EntityFramework.Migrations
{
    public partial class ItWasDueWrongConvention : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_KartotekaPrzestepstwo_Kartotekas_KartotekasID_osoby",
                table: "KartotekaPrzestepstwo");

            migrationBuilder.DropForeignKey(
                name: "FK_KartotekaPrzestepstwo_Przestepstwos_PrzestepstwosID_przestepstwa",
                table: "KartotekaPrzestepstwo");

            migrationBuilder.DropForeignKey(
                name: "FK_KartotekaWykroczenia_Kartotekas_KartotekasID_osoby",
                table: "KartotekaWykroczenia");

            migrationBuilder.DropForeignKey(
                name: "FK_KartotekaWykroczenia_Wykroczenias_WykroczeniasID_wykroczenia",
                table: "KartotekaWykroczenia");

            migrationBuilder.DropForeignKey(
                name: "FK_Patrols_Policjants_PolicjantID_policjanta",
                table: "Patrols");

            migrationBuilder.DropForeignKey(
                name: "FK_Patrols_Radiowozs_RadiowozID_radiowozu",
                table: "Patrols");

            migrationBuilder.DropForeignKey(
                name: "FK_PolicjantPrzestepstwo_Policjants_PolicjantsID_policjanta",
                table: "PolicjantPrzestepstwo");

            migrationBuilder.DropForeignKey(
                name: "FK_PolicjantPrzestepstwo_Przestepstwos_PrzestepstwosID_przestepstwa",
                table: "PolicjantPrzestepstwo");

            migrationBuilder.DropForeignKey(
                name: "FK_Policjants_Komendas_KomendaID_komendy",
                table: "Policjants");

            migrationBuilder.DropForeignKey(
                name: "FK_Policjants_Rangas_RangaID_rangi",
                table: "Policjants");

            migrationBuilder.DropForeignKey(
                name: "FK_PolicjantWykroczenia_Policjants_PolicjantsID_policjanta",
                table: "PolicjantWykroczenia");

            migrationBuilder.DropForeignKey(
                name: "FK_PolicjantWykroczenia_Wykroczenias_WykroczeniasID_wykroczenia",
                table: "PolicjantWykroczenia");

            migrationBuilder.DropForeignKey(
                name: "FK_Uzytkowniks_Policjants_PolicjantID_policjanta",
                table: "Uzytkowniks");

            migrationBuilder.DropIndex(
                name: "IX_Policjants_KomendaID_komendy",
                table: "Policjants");

            migrationBuilder.DropIndex(
                name: "IX_Policjants_RangaID_rangi",
                table: "Policjants");

            migrationBuilder.DropIndex(
                name: "IX_Patrols_PolicjantID_policjanta",
                table: "Patrols");

            migrationBuilder.DropIndex(
                name: "IX_Patrols_RadiowozID_radiowozu",
                table: "Patrols");

            migrationBuilder.DropColumn(
                name: "ID_policjanta",
                table: "Uzytkowniks");

            migrationBuilder.DropColumn(
                name: "KomendaID_komendy",
                table: "Policjants");

            migrationBuilder.DropColumn(
                name: "RangaID_rangi",
                table: "Policjants");

            migrationBuilder.DropColumn(
                name: "PolicjantID_policjanta",
                table: "Patrols");

            migrationBuilder.DropColumn(
                name: "RadiowozID_radiowozu",
                table: "Patrols");

            migrationBuilder.RenameColumn(
                name: "ID_wykroczenia",
                table: "Wykroczenias",
                newName: "WykroczenieId");

            migrationBuilder.RenameColumn(
                name: "PolicjantID_policjanta",
                table: "Uzytkowniks",
                newName: "PolicjantId");

            migrationBuilder.RenameColumn(
                name: "ID_uzytkownika",
                table: "Uzytkowniks",
                newName: "UzytkownikId");

            migrationBuilder.RenameIndex(
                name: "IX_Uzytkowniks_PolicjantID_policjanta",
                table: "Uzytkowniks",
                newName: "IX_Uzytkowniks_PolicjantId");

            migrationBuilder.RenameColumn(
                name: "ID_regionu",
                table: "Region_Miastas",
                newName: "Region_MiastaId");

            migrationBuilder.RenameColumn(
                name: "ID_rangi",
                table: "Rangas",
                newName: "RangaId");

            migrationBuilder.RenameColumn(
                name: "ID_radiowozu",
                table: "Radiowozs",
                newName: "RadiowozId");

            migrationBuilder.RenameColumn(
                name: "ID_przestepstwa",
                table: "Przestepstwos",
                newName: "PrzestepstwoId");

            migrationBuilder.RenameColumn(
                name: "WykroczeniasID_wykroczenia",
                table: "PolicjantWykroczenia",
                newName: "WykroczeniasWykroczenieId");

            migrationBuilder.RenameColumn(
                name: "PolicjantsID_policjanta",
                table: "PolicjantWykroczenia",
                newName: "PolicjantsPolicjantId");

            migrationBuilder.RenameIndex(
                name: "IX_PolicjantWykroczenia_WykroczeniasID_wykroczenia",
                table: "PolicjantWykroczenia",
                newName: "IX_PolicjantWykroczenia_WykroczeniasWykroczenieId");

            migrationBuilder.RenameColumn(
                name: "ID_rangi",
                table: "Policjants",
                newName: "RangaId");

            migrationBuilder.RenameColumn(
                name: "ID_komendy",
                table: "Policjants",
                newName: "KomendaId");

            migrationBuilder.RenameColumn(
                name: "ID_policjanta",
                table: "Policjants",
                newName: "PolicjantId");

            migrationBuilder.RenameColumn(
                name: "PrzestepstwosID_przestepstwa",
                table: "PolicjantPrzestepstwo",
                newName: "PrzestepstwosPrzestepstwoId");

            migrationBuilder.RenameColumn(
                name: "PolicjantsID_policjanta",
                table: "PolicjantPrzestepstwo",
                newName: "PolicjantsPolicjantId");

            migrationBuilder.RenameIndex(
                name: "IX_PolicjantPrzestepstwo_PrzestepstwosID_przestepstwa",
                table: "PolicjantPrzestepstwo",
                newName: "IX_PolicjantPrzestepstwo_PrzestepstwosPrzestepstwoId");

            migrationBuilder.RenameColumn(
                name: "ID_radiowozu",
                table: "Patrols",
                newName: "RadiowozId");

            migrationBuilder.RenameColumn(
                name: "ID_policjanta",
                table: "Patrols",
                newName: "PolicjantId");

            migrationBuilder.RenameColumn(
                name: "ID_patrolu",
                table: "Patrols",
                newName: "PatrolId");

            migrationBuilder.RenameColumn(
                name: "ID_miasta",
                table: "Miastos",
                newName: "MiastoId");

            migrationBuilder.RenameColumn(
                name: "ID_komendy",
                table: "Komendas",
                newName: "KomendaId");

            migrationBuilder.RenameColumn(
                name: "WykroczeniasID_wykroczenia",
                table: "KartotekaWykroczenia",
                newName: "WykroczeniasWykroczenieId");

            migrationBuilder.RenameColumn(
                name: "KartotekasID_osoby",
                table: "KartotekaWykroczenia",
                newName: "KartotekasKartotekaId");

            migrationBuilder.RenameIndex(
                name: "IX_KartotekaWykroczenia_WykroczeniasID_wykroczenia",
                table: "KartotekaWykroczenia",
                newName: "IX_KartotekaWykroczenia_WykroczeniasWykroczenieId");

            migrationBuilder.RenameColumn(
                name: "ID_osoby",
                table: "Kartotekas",
                newName: "KartotekaId");

            migrationBuilder.RenameColumn(
                name: "PrzestepstwosID_przestepstwa",
                table: "KartotekaPrzestepstwo",
                newName: "PrzestepstwosPrzestepstwoId");

            migrationBuilder.RenameColumn(
                name: "KartotekasID_osoby",
                table: "KartotekaPrzestepstwo",
                newName: "KartotekasKartotekaId");

            migrationBuilder.RenameIndex(
                name: "IX_KartotekaPrzestepstwo_PrzestepstwosID_przestepstwa",
                table: "KartotekaPrzestepstwo",
                newName: "IX_KartotekaPrzestepstwo_PrzestepstwosPrzestepstwoId");

            migrationBuilder.CreateIndex(
                name: "IX_Policjants_KomendaId",
                table: "Policjants",
                column: "KomendaId");

            migrationBuilder.CreateIndex(
                name: "IX_Policjants_RangaId",
                table: "Policjants",
                column: "RangaId");

            migrationBuilder.CreateIndex(
                name: "IX_Patrols_PolicjantId",
                table: "Patrols",
                column: "PolicjantId");

            migrationBuilder.CreateIndex(
                name: "IX_Patrols_RadiowozId",
                table: "Patrols",
                column: "RadiowozId");

            migrationBuilder.AddForeignKey(
                name: "FK_KartotekaPrzestepstwo_Kartotekas_KartotekasKartotekaId",
                table: "KartotekaPrzestepstwo",
                column: "KartotekasKartotekaId",
                principalTable: "Kartotekas",
                principalColumn: "KartotekaId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_KartotekaPrzestepstwo_Przestepstwos_PrzestepstwosPrzestepstwoId",
                table: "KartotekaPrzestepstwo",
                column: "PrzestepstwosPrzestepstwoId",
                principalTable: "Przestepstwos",
                principalColumn: "PrzestepstwoId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_KartotekaWykroczenia_Kartotekas_KartotekasKartotekaId",
                table: "KartotekaWykroczenia",
                column: "KartotekasKartotekaId",
                principalTable: "Kartotekas",
                principalColumn: "KartotekaId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_KartotekaWykroczenia_Wykroczenias_WykroczeniasWykroczenieId",
                table: "KartotekaWykroczenia",
                column: "WykroczeniasWykroczenieId",
                principalTable: "Wykroczenias",
                principalColumn: "WykroczenieId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Patrols_Policjants_PolicjantId",
                table: "Patrols",
                column: "PolicjantId",
                principalTable: "Policjants",
                principalColumn: "PolicjantId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Patrols_Radiowozs_RadiowozId",
                table: "Patrols",
                column: "RadiowozId",
                principalTable: "Radiowozs",
                principalColumn: "RadiowozId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PolicjantPrzestepstwo_Policjants_PolicjantsPolicjantId",
                table: "PolicjantPrzestepstwo",
                column: "PolicjantsPolicjantId",
                principalTable: "Policjants",
                principalColumn: "PolicjantId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PolicjantPrzestepstwo_Przestepstwos_PrzestepstwosPrzestepstwoId",
                table: "PolicjantPrzestepstwo",
                column: "PrzestepstwosPrzestepstwoId",
                principalTable: "Przestepstwos",
                principalColumn: "PrzestepstwoId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Policjants_Komendas_KomendaId",
                table: "Policjants",
                column: "KomendaId",
                principalTable: "Komendas",
                principalColumn: "KomendaId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Policjants_Rangas_RangaId",
                table: "Policjants",
                column: "RangaId",
                principalTable: "Rangas",
                principalColumn: "RangaId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PolicjantWykroczenia_Policjants_PolicjantsPolicjantId",
                table: "PolicjantWykroczenia",
                column: "PolicjantsPolicjantId",
                principalTable: "Policjants",
                principalColumn: "PolicjantId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PolicjantWykroczenia_Wykroczenias_WykroczeniasWykroczenieId",
                table: "PolicjantWykroczenia",
                column: "WykroczeniasWykroczenieId",
                principalTable: "Wykroczenias",
                principalColumn: "WykroczenieId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Uzytkowniks_Policjants_PolicjantId",
                table: "Uzytkowniks",
                column: "PolicjantId",
                principalTable: "Policjants",
                principalColumn: "PolicjantId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_KartotekaPrzestepstwo_Kartotekas_KartotekasKartotekaId",
                table: "KartotekaPrzestepstwo");

            migrationBuilder.DropForeignKey(
                name: "FK_KartotekaPrzestepstwo_Przestepstwos_PrzestepstwosPrzestepstwoId",
                table: "KartotekaPrzestepstwo");

            migrationBuilder.DropForeignKey(
                name: "FK_KartotekaWykroczenia_Kartotekas_KartotekasKartotekaId",
                table: "KartotekaWykroczenia");

            migrationBuilder.DropForeignKey(
                name: "FK_KartotekaWykroczenia_Wykroczenias_WykroczeniasWykroczenieId",
                table: "KartotekaWykroczenia");

            migrationBuilder.DropForeignKey(
                name: "FK_Patrols_Policjants_PolicjantId",
                table: "Patrols");

            migrationBuilder.DropForeignKey(
                name: "FK_Patrols_Radiowozs_RadiowozId",
                table: "Patrols");

            migrationBuilder.DropForeignKey(
                name: "FK_PolicjantPrzestepstwo_Policjants_PolicjantsPolicjantId",
                table: "PolicjantPrzestepstwo");

            migrationBuilder.DropForeignKey(
                name: "FK_PolicjantPrzestepstwo_Przestepstwos_PrzestepstwosPrzestepstwoId",
                table: "PolicjantPrzestepstwo");

            migrationBuilder.DropForeignKey(
                name: "FK_Policjants_Komendas_KomendaId",
                table: "Policjants");

            migrationBuilder.DropForeignKey(
                name: "FK_Policjants_Rangas_RangaId",
                table: "Policjants");

            migrationBuilder.DropForeignKey(
                name: "FK_PolicjantWykroczenia_Policjants_PolicjantsPolicjantId",
                table: "PolicjantWykroczenia");

            migrationBuilder.DropForeignKey(
                name: "FK_PolicjantWykroczenia_Wykroczenias_WykroczeniasWykroczenieId",
                table: "PolicjantWykroczenia");

            migrationBuilder.DropForeignKey(
                name: "FK_Uzytkowniks_Policjants_PolicjantId",
                table: "Uzytkowniks");

            migrationBuilder.DropIndex(
                name: "IX_Policjants_KomendaId",
                table: "Policjants");

            migrationBuilder.DropIndex(
                name: "IX_Policjants_RangaId",
                table: "Policjants");

            migrationBuilder.DropIndex(
                name: "IX_Patrols_PolicjantId",
                table: "Patrols");

            migrationBuilder.DropIndex(
                name: "IX_Patrols_RadiowozId",
                table: "Patrols");

            migrationBuilder.RenameColumn(
                name: "WykroczenieId",
                table: "Wykroczenias",
                newName: "ID_wykroczenia");

            migrationBuilder.RenameColumn(
                name: "PolicjantId",
                table: "Uzytkowniks",
                newName: "PolicjantID_policjanta");

            migrationBuilder.RenameColumn(
                name: "UzytkownikId",
                table: "Uzytkowniks",
                newName: "ID_uzytkownika");

            migrationBuilder.RenameIndex(
                name: "IX_Uzytkowniks_PolicjantId",
                table: "Uzytkowniks",
                newName: "IX_Uzytkowniks_PolicjantID_policjanta");

            migrationBuilder.RenameColumn(
                name: "Region_MiastaId",
                table: "Region_Miastas",
                newName: "ID_regionu");

            migrationBuilder.RenameColumn(
                name: "RangaId",
                table: "Rangas",
                newName: "ID_rangi");

            migrationBuilder.RenameColumn(
                name: "RadiowozId",
                table: "Radiowozs",
                newName: "ID_radiowozu");

            migrationBuilder.RenameColumn(
                name: "PrzestepstwoId",
                table: "Przestepstwos",
                newName: "ID_przestepstwa");

            migrationBuilder.RenameColumn(
                name: "WykroczeniasWykroczenieId",
                table: "PolicjantWykroczenia",
                newName: "WykroczeniasID_wykroczenia");

            migrationBuilder.RenameColumn(
                name: "PolicjantsPolicjantId",
                table: "PolicjantWykroczenia",
                newName: "PolicjantsID_policjanta");

            migrationBuilder.RenameIndex(
                name: "IX_PolicjantWykroczenia_WykroczeniasWykroczenieId",
                table: "PolicjantWykroczenia",
                newName: "IX_PolicjantWykroczenia_WykroczeniasID_wykroczenia");

            migrationBuilder.RenameColumn(
                name: "RangaId",
                table: "Policjants",
                newName: "ID_rangi");

            migrationBuilder.RenameColumn(
                name: "KomendaId",
                table: "Policjants",
                newName: "ID_komendy");

            migrationBuilder.RenameColumn(
                name: "PolicjantId",
                table: "Policjants",
                newName: "ID_policjanta");

            migrationBuilder.RenameColumn(
                name: "PrzestepstwosPrzestepstwoId",
                table: "PolicjantPrzestepstwo",
                newName: "PrzestepstwosID_przestepstwa");

            migrationBuilder.RenameColumn(
                name: "PolicjantsPolicjantId",
                table: "PolicjantPrzestepstwo",
                newName: "PolicjantsID_policjanta");

            migrationBuilder.RenameIndex(
                name: "IX_PolicjantPrzestepstwo_PrzestepstwosPrzestepstwoId",
                table: "PolicjantPrzestepstwo",
                newName: "IX_PolicjantPrzestepstwo_PrzestepstwosID_przestepstwa");

            migrationBuilder.RenameColumn(
                name: "RadiowozId",
                table: "Patrols",
                newName: "ID_radiowozu");

            migrationBuilder.RenameColumn(
                name: "PolicjantId",
                table: "Patrols",
                newName: "ID_policjanta");

            migrationBuilder.RenameColumn(
                name: "PatrolId",
                table: "Patrols",
                newName: "ID_patrolu");

            migrationBuilder.RenameColumn(
                name: "MiastoId",
                table: "Miastos",
                newName: "ID_miasta");

            migrationBuilder.RenameColumn(
                name: "KomendaId",
                table: "Komendas",
                newName: "ID_komendy");

            migrationBuilder.RenameColumn(
                name: "WykroczeniasWykroczenieId",
                table: "KartotekaWykroczenia",
                newName: "WykroczeniasID_wykroczenia");

            migrationBuilder.RenameColumn(
                name: "KartotekasKartotekaId",
                table: "KartotekaWykroczenia",
                newName: "KartotekasID_osoby");

            migrationBuilder.RenameIndex(
                name: "IX_KartotekaWykroczenia_WykroczeniasWykroczenieId",
                table: "KartotekaWykroczenia",
                newName: "IX_KartotekaWykroczenia_WykroczeniasID_wykroczenia");

            migrationBuilder.RenameColumn(
                name: "KartotekaId",
                table: "Kartotekas",
                newName: "ID_osoby");

            migrationBuilder.RenameColumn(
                name: "PrzestepstwosPrzestepstwoId",
                table: "KartotekaPrzestepstwo",
                newName: "PrzestepstwosID_przestepstwa");

            migrationBuilder.RenameColumn(
                name: "KartotekasKartotekaId",
                table: "KartotekaPrzestepstwo",
                newName: "KartotekasID_osoby");

            migrationBuilder.RenameIndex(
                name: "IX_KartotekaPrzestepstwo_PrzestepstwosPrzestepstwoId",
                table: "KartotekaPrzestepstwo",
                newName: "IX_KartotekaPrzestepstwo_PrzestepstwosID_przestepstwa");

            migrationBuilder.AddColumn<int>(
                name: "ID_policjanta",
                table: "Uzytkowniks",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "KomendaID_komendy",
                table: "Policjants",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RangaID_rangi",
                table: "Policjants",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PolicjantID_policjanta",
                table: "Patrols",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RadiowozID_radiowozu",
                table: "Patrols",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Policjants_KomendaID_komendy",
                table: "Policjants",
                column: "KomendaID_komendy");

            migrationBuilder.CreateIndex(
                name: "IX_Policjants_RangaID_rangi",
                table: "Policjants",
                column: "RangaID_rangi");

            migrationBuilder.CreateIndex(
                name: "IX_Patrols_PolicjantID_policjanta",
                table: "Patrols",
                column: "PolicjantID_policjanta");

            migrationBuilder.CreateIndex(
                name: "IX_Patrols_RadiowozID_radiowozu",
                table: "Patrols",
                column: "RadiowozID_radiowozu");

            migrationBuilder.AddForeignKey(
                name: "FK_KartotekaPrzestepstwo_Kartotekas_KartotekasID_osoby",
                table: "KartotekaPrzestepstwo",
                column: "KartotekasID_osoby",
                principalTable: "Kartotekas",
                principalColumn: "ID_osoby",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_KartotekaPrzestepstwo_Przestepstwos_PrzestepstwosID_przestepstwa",
                table: "KartotekaPrzestepstwo",
                column: "PrzestepstwosID_przestepstwa",
                principalTable: "Przestepstwos",
                principalColumn: "ID_przestepstwa",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_KartotekaWykroczenia_Kartotekas_KartotekasID_osoby",
                table: "KartotekaWykroczenia",
                column: "KartotekasID_osoby",
                principalTable: "Kartotekas",
                principalColumn: "ID_osoby",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_KartotekaWykroczenia_Wykroczenias_WykroczeniasID_wykroczenia",
                table: "KartotekaWykroczenia",
                column: "WykroczeniasID_wykroczenia",
                principalTable: "Wykroczenias",
                principalColumn: "ID_wykroczenia",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Patrols_Policjants_PolicjantID_policjanta",
                table: "Patrols",
                column: "PolicjantID_policjanta",
                principalTable: "Policjants",
                principalColumn: "ID_policjanta",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Patrols_Radiowozs_RadiowozID_radiowozu",
                table: "Patrols",
                column: "RadiowozID_radiowozu",
                principalTable: "Radiowozs",
                principalColumn: "ID_radiowozu",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PolicjantPrzestepstwo_Policjants_PolicjantsID_policjanta",
                table: "PolicjantPrzestepstwo",
                column: "PolicjantsID_policjanta",
                principalTable: "Policjants",
                principalColumn: "ID_policjanta",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PolicjantPrzestepstwo_Przestepstwos_PrzestepstwosID_przestepstwa",
                table: "PolicjantPrzestepstwo",
                column: "PrzestepstwosID_przestepstwa",
                principalTable: "Przestepstwos",
                principalColumn: "ID_przestepstwa",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Policjants_Komendas_KomendaID_komendy",
                table: "Policjants",
                column: "KomendaID_komendy",
                principalTable: "Komendas",
                principalColumn: "ID_komendy",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Policjants_Rangas_RangaID_rangi",
                table: "Policjants",
                column: "RangaID_rangi",
                principalTable: "Rangas",
                principalColumn: "ID_rangi",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PolicjantWykroczenia_Policjants_PolicjantsID_policjanta",
                table: "PolicjantWykroczenia",
                column: "PolicjantsID_policjanta",
                principalTable: "Policjants",
                principalColumn: "ID_policjanta",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PolicjantWykroczenia_Wykroczenias_WykroczeniasID_wykroczenia",
                table: "PolicjantWykroczenia",
                column: "WykroczeniasID_wykroczenia",
                principalTable: "Wykroczenias",
                principalColumn: "ID_wykroczenia",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Uzytkowniks_Policjants_PolicjantID_policjanta",
                table: "Uzytkowniks",
                column: "PolicjantID_policjanta",
                principalTable: "Policjants",
                principalColumn: "ID_policjanta",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
