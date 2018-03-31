using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Hotel.Data.Migrations
{
    public partial class DodanGostIDURezervisanSmjestaj : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "GostId",
                table: "RezervisanSmjestaj",
                nullable: false,
                defaultValue: 0);

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

        protected override void Down(MigrationBuilder migrationBuilder)
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
        }
    }
}
