using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EntityFramework.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Kartotekas",
                columns: table => new
                {
                    ID_osoby = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Imie = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Nazwisko = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Wiek = table.Column<int>(type: "int", nullable: false),
                    Zdjecie = table.Column<byte[]>(type: "varbinary(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kartotekas", x => x.ID_osoby);
                });

            migrationBuilder.CreateTable(
                name: "Miastos",
                columns: table => new
                {
                    ID_miasta = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nazwa = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Miastos", x => x.ID_miasta);
                });

            migrationBuilder.CreateTable(
                name: "Przestepstwos",
                columns: table => new
                {
                    ID_przestepstwa = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nazwa = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Data = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Godzina = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Przestepstwos", x => x.ID_przestepstwa);
                });

            migrationBuilder.CreateTable(
                name: "Radiowozs",
                columns: table => new
                {
                    ID_radiowozu = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Model = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Marka = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Rok_produkcji = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Radiowozs", x => x.ID_radiowozu);
                });

            migrationBuilder.CreateTable(
                name: "Rangas",
                columns: table => new
                {
                    ID_rangi = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nazwa = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Pensja = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rangas", x => x.ID_rangi);
                });

            migrationBuilder.CreateTable(
                name: "Region_Miastas",
                columns: table => new
                {
                    ID_regionu = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ID_miasta = table.Column<int>(type: "int", nullable: false),
                    MiastoID_miasta = table.Column<int>(type: "int", nullable: true),
                    Nazwa = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Stopien_zagrozenia = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Region_Miastas", x => x.ID_regionu);
                    table.ForeignKey(
                        name: "FK_Region_Miastas_Miastos_MiastoID_miasta",
                        column: x => x.MiastoID_miasta,
                        principalTable: "Miastos",
                        principalColumn: "ID_miasta",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "KartotekaPrzestepstwo",
                columns: table => new
                {
                    KartotekasID_osoby = table.Column<int>(type: "int", nullable: false),
                    PrzestepstwosID_przestepstwa = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KartotekaPrzestepstwo", x => new { x.KartotekasID_osoby, x.PrzestepstwosID_przestepstwa });
                    table.ForeignKey(
                        name: "FK_KartotekaPrzestepstwo_Kartotekas_KartotekasID_osoby",
                        column: x => x.KartotekasID_osoby,
                        principalTable: "Kartotekas",
                        principalColumn: "ID_osoby",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_KartotekaPrzestepstwo_Przestepstwos_PrzestepstwosID_przestepstwa",
                        column: x => x.PrzestepstwosID_przestepstwa,
                        principalTable: "Przestepstwos",
                        principalColumn: "ID_przestepstwa",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Komendas",
                columns: table => new
                {
                    ID_komendy = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Adres = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ID_regionu = table.Column<int>(type: "int", nullable: false),
                    RegionID_regionu = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Komendas", x => x.ID_komendy);
                    table.ForeignKey(
                        name: "FK_Komendas_Region_Miastas_RegionID_regionu",
                        column: x => x.RegionID_regionu,
                        principalTable: "Region_Miastas",
                        principalColumn: "ID_regionu",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Policjants",
                columns: table => new
                {
                    ID_policjanta = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Imie = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Nazwisko = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ID_rangi = table.Column<int>(type: "int", nullable: false),
                    RangaID_rangi = table.Column<int>(type: "int", nullable: true),
                    ID_komendy = table.Column<int>(type: "int", nullable: false),
                    KomendaID_komendy = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Policjants", x => x.ID_policjanta);
                    table.ForeignKey(
                        name: "FK_Policjants_Komendas_KomendaID_komendy",
                        column: x => x.KomendaID_komendy,
                        principalTable: "Komendas",
                        principalColumn: "ID_komendy",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Policjants_Rangas_RangaID_rangi",
                        column: x => x.RangaID_rangi,
                        principalTable: "Rangas",
                        principalColumn: "ID_rangi",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Patrols",
                columns: table => new
                {
                    ID_patrolu = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ID_radiowozu = table.Column<int>(type: "int", nullable: false),
                    RadiowozID_radiowozu = table.Column<int>(type: "int", nullable: true),
                    ID_policjanta = table.Column<int>(type: "int", nullable: false),
                    PolicjantID_policjanta = table.Column<int>(type: "int", nullable: true),
                    Data_rozpoczecia = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Data_zakonczenia = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Godzina_rozpoczecia = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Godzina_zakonczenia = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Patrols", x => x.ID_patrolu);
                    table.ForeignKey(
                        name: "FK_Patrols_Policjants_PolicjantID_policjanta",
                        column: x => x.PolicjantID_policjanta,
                        principalTable: "Policjants",
                        principalColumn: "ID_policjanta",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Patrols_Radiowozs_RadiowozID_radiowozu",
                        column: x => x.RadiowozID_radiowozu,
                        principalTable: "Radiowozs",
                        principalColumn: "ID_radiowozu",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PolicjantPrzestepstwo",
                columns: table => new
                {
                    PolicjantsID_policjanta = table.Column<int>(type: "int", nullable: false),
                    PrzestepstwosID_przestepstwa = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PolicjantPrzestepstwo", x => new { x.PolicjantsID_policjanta, x.PrzestepstwosID_przestepstwa });
                    table.ForeignKey(
                        name: "FK_PolicjantPrzestepstwo_Policjants_PolicjantsID_policjanta",
                        column: x => x.PolicjantsID_policjanta,
                        principalTable: "Policjants",
                        principalColumn: "ID_policjanta",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PolicjantPrzestepstwo_Przestepstwos_PrzestepstwosID_przestepstwa",
                        column: x => x.PrzestepstwosID_przestepstwa,
                        principalTable: "Przestepstwos",
                        principalColumn: "ID_przestepstwa",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Uzytkowniks",
                columns: table => new
                {
                    ID_uzytkownika = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Rola = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Loign = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ID_policjanta = table.Column<int>(type: "int", nullable: true),
                    PolicjantID_policjanta = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Uzytkowniks", x => x.ID_uzytkownika);
                    table.ForeignKey(
                        name: "FK_Uzytkowniks_Policjants_PolicjantID_policjanta",
                        column: x => x.PolicjantID_policjanta,
                        principalTable: "Policjants",
                        principalColumn: "ID_policjanta",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Wykroczenias",
                columns: table => new
                {
                    ID_wykroczenia = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nazwa = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Data = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Godzina = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PolicjantID_policjanta = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Wykroczenias", x => x.ID_wykroczenia);
                    table.ForeignKey(
                        name: "FK_Wykroczenias_Policjants_PolicjantID_policjanta",
                        column: x => x.PolicjantID_policjanta,
                        principalTable: "Policjants",
                        principalColumn: "ID_policjanta",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "KartotekaWykroczenia",
                columns: table => new
                {
                    KartotekasID_osoby = table.Column<int>(type: "int", nullable: false),
                    WykroczeniasID_wykroczenia = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KartotekaWykroczenia", x => new { x.KartotekasID_osoby, x.WykroczeniasID_wykroczenia });
                    table.ForeignKey(
                        name: "FK_KartotekaWykroczenia_Kartotekas_KartotekasID_osoby",
                        column: x => x.KartotekasID_osoby,
                        principalTable: "Kartotekas",
                        principalColumn: "ID_osoby",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_KartotekaWykroczenia_Wykroczenias_WykroczeniasID_wykroczenia",
                        column: x => x.WykroczeniasID_wykroczenia,
                        principalTable: "Wykroczenias",
                        principalColumn: "ID_wykroczenia",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_KartotekaPrzestepstwo_PrzestepstwosID_przestepstwa",
                table: "KartotekaPrzestepstwo",
                column: "PrzestepstwosID_przestepstwa");

            migrationBuilder.CreateIndex(
                name: "IX_KartotekaWykroczenia_WykroczeniasID_wykroczenia",
                table: "KartotekaWykroczenia",
                column: "WykroczeniasID_wykroczenia");

            migrationBuilder.CreateIndex(
                name: "IX_Komendas_RegionID_regionu",
                table: "Komendas",
                column: "RegionID_regionu");

            migrationBuilder.CreateIndex(
                name: "IX_Patrols_PolicjantID_policjanta",
                table: "Patrols",
                column: "PolicjantID_policjanta");

            migrationBuilder.CreateIndex(
                name: "IX_Patrols_RadiowozID_radiowozu",
                table: "Patrols",
                column: "RadiowozID_radiowozu");

            migrationBuilder.CreateIndex(
                name: "IX_PolicjantPrzestepstwo_PrzestepstwosID_przestepstwa",
                table: "PolicjantPrzestepstwo",
                column: "PrzestepstwosID_przestepstwa");

            migrationBuilder.CreateIndex(
                name: "IX_Policjants_KomendaID_komendy",
                table: "Policjants",
                column: "KomendaID_komendy");

            migrationBuilder.CreateIndex(
                name: "IX_Policjants_RangaID_rangi",
                table: "Policjants",
                column: "RangaID_rangi");

            migrationBuilder.CreateIndex(
                name: "IX_Region_Miastas_MiastoID_miasta",
                table: "Region_Miastas",
                column: "MiastoID_miasta");

            migrationBuilder.CreateIndex(
                name: "IX_Uzytkowniks_PolicjantID_policjanta",
                table: "Uzytkowniks",
                column: "PolicjantID_policjanta");

            migrationBuilder.CreateIndex(
                name: "IX_Wykroczenias_PolicjantID_policjanta",
                table: "Wykroczenias",
                column: "PolicjantID_policjanta");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "KartotekaPrzestepstwo");

            migrationBuilder.DropTable(
                name: "KartotekaWykroczenia");

            migrationBuilder.DropTable(
                name: "Patrols");

            migrationBuilder.DropTable(
                name: "PolicjantPrzestepstwo");

            migrationBuilder.DropTable(
                name: "Uzytkowniks");

            migrationBuilder.DropTable(
                name: "Kartotekas");

            migrationBuilder.DropTable(
                name: "Wykroczenias");

            migrationBuilder.DropTable(
                name: "Radiowozs");

            migrationBuilder.DropTable(
                name: "Przestepstwos");

            migrationBuilder.DropTable(
                name: "Policjants");

            migrationBuilder.DropTable(
                name: "Komendas");

            migrationBuilder.DropTable(
                name: "Rangas");

            migrationBuilder.DropTable(
                name: "Region_Miastas");

            migrationBuilder.DropTable(
                name: "Miastos");
        }
    }
}
