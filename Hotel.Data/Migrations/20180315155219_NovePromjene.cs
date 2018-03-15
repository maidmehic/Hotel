using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Hotel.Data.Migrations
{
    public partial class NovePromjene : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RezervisanSmjestaj_Gost_GostId",
                table: "RezervisanSmjestaj");

            migrationBuilder.DropIndex(
                name: "IX_RezervisanSmjestaj_GostId",
                table: "RezervisanSmjestaj");

            migrationBuilder.DropColumn(
                name: "GostId",
                table: "RezervisanSmjestaj");

            migrationBuilder.DropColumn(
                name: "Datumrezervacije",
                table: "RezervisanaUsluga");

            migrationBuilder.AddColumn<float>(
                name: "Cijena",
                table: "TipUsluge",
                nullable: false,
                defaultValue: 0f);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Cijena",
                table: "TipUsluge");

            migrationBuilder.AddColumn<int>(
                name: "GostId",
                table: "RezervisanSmjestaj",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "Datumrezervacije",
                table: "RezervisanaUsluga",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateIndex(
                name: "IX_RezervisanSmjestaj_GostId",
                table: "RezervisanSmjestaj",
                column: "GostId");

            migrationBuilder.AddForeignKey(
                name: "FK_RezervisanSmjestaj_Gost_GostId",
                table: "RezervisanSmjestaj",
                column: "GostId",
                principalTable: "Gost",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
