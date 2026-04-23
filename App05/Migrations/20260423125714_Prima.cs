using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace App05.Migrations
{
    /// <inheritdoc />
    public partial class Prima : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Gruppi",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nome = table.Column<string>(type: "TEXT", nullable: false),
                    Descrizione = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gruppi", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tipi",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nome = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tipi", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Contatti",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nome = table.Column<string>(type: "TEXT", nullable: false),
                    Cognome = table.Column<string>(type: "TEXT", nullable: false),
                    Telefono = table.Column<string>(type: "TEXT", nullable: false),
                    Email = table.Column<string>(type: "TEXT", nullable: false),
                    TipoId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contatti", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Contatti_Tipi_TipoId",
                        column: x => x.TipoId,
                        principalTable: "Tipi",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "ContattoGruppo",
                columns: table => new
                {
                    ContattiId = table.Column<int>(type: "INTEGER", nullable: false),
                    GruppiId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContattoGruppo", x => new { x.ContattiId, x.GruppiId });
                    table.ForeignKey(
                        name: "FK_ContattoGruppo_Contatti_ContattiId",
                        column: x => x.ContattiId,
                        principalTable: "Contatti",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ContattoGruppo_Gruppi_GruppiId",
                        column: x => x.GruppiId,
                        principalTable: "Gruppi",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Contatti_TipoId",
                table: "Contatti",
                column: "TipoId");

            migrationBuilder.CreateIndex(
                name: "IX_ContattoGruppo_GruppiId",
                table: "ContattoGruppo",
                column: "GruppiId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ContattoGruppo");

            migrationBuilder.DropTable(
                name: "Contatti");

            migrationBuilder.DropTable(
                name: "Gruppi");

            migrationBuilder.DropTable(
                name: "Tipi");
        }
    }
}
