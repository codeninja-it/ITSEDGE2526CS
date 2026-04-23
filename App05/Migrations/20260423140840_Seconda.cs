using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace App05.Migrations
{
    /// <inheritdoc />
    public partial class Seconda : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "UltimaModifica",
                table: "Tipi",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "UltimaModifica",
                table: "Gruppi",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "UltimaModifica",
                table: "Contatti",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UltimaModifica",
                table: "Tipi");

            migrationBuilder.DropColumn(
                name: "UltimaModifica",
                table: "Gruppi");

            migrationBuilder.DropColumn(
                name: "UltimaModifica",
                table: "Contatti");
        }
    }
}
