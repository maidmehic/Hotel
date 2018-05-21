using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Hotel.Data.Migrations
{
    public partial class m : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_DostavaStavke_DostavaId",
                table: "DostavaStavke",
                column: "DostavaId");

            migrationBuilder.CreateIndex(
                name: "IX_DostavaStavke_ProizvodId",
                table: "DostavaStavke",
                column: "ProizvodId");

            migrationBuilder.AddForeignKey(
                name: "FK_DostavaStavke_Dostava_DostavaId",
                table: "DostavaStavke",
                column: "DostavaId",
                principalTable: "Dostava",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DostavaStavke_Proizvod_ProizvodId",
                table: "DostavaStavke",
                column: "ProizvodId",
                principalTable: "Proizvod",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DostavaStavke_Dostava_DostavaId",
                table: "DostavaStavke");

            migrationBuilder.DropForeignKey(
                name: "FK_DostavaStavke_Proizvod_ProizvodId",
                table: "DostavaStavke");

            migrationBuilder.DropIndex(
                name: "IX_DostavaStavke_DostavaId",
                table: "DostavaStavke");

            migrationBuilder.DropIndex(
                name: "IX_DostavaStavke_ProizvodId",
                table: "DostavaStavke");
        }
    }
}
