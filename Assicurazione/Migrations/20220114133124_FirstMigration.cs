using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Assicurazione.Migrations
{
    public partial class FirstMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clienti",
                columns: table => new
                {
                    Codice_Fiscale = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Cognome = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Indirizzo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clienti", x => x.Codice_Fiscale);
                });

            migrationBuilder.CreateTable(
                name: "Polizza",
                columns: table => new
                {
                    NumeroPolizza = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DataStipula = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ImportoAssicurativo = table.Column<decimal>(type: "Decimal(10,2)", precision: 10, scale: 2, nullable: false),
                    RataMensile = table.Column<decimal>(type: "Decimal(10,2)", precision: 10, scale: 2, nullable: false),
                    CF = table.Column<string>(type: "nvarchar(16)", nullable: true),
                    Categoria = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    InsuredYears = table.Column<int>(type: "int", nullable: true),
                    LicensePlate = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: true),
                    Displacement = table.Column<int>(type: "int", nullable: true),
                    CoveredPercentage = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Polizza", x => x.NumeroPolizza);
                    table.ForeignKey(
                        name: "FK_CodiceFiscale",
                        column: x => x.CF,
                        principalTable: "Clienti",
                        principalColumn: "Codice_Fiscale");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Polizza_CF",
                table: "Polizza",
                column: "CF");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Polizza");

            migrationBuilder.DropTable(
                name: "Clienti");
        }
    }
}
