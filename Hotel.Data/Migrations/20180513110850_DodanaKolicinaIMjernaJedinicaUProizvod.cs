using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Hotel.Data.Migrations
{
    public partial class DodanaKolicinaIMjernaJedinicaUProizvod : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<float>(
                name: "Kolicina",
                table: "Proizvod",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<string>(
                name: "MjernaJedinica",
                table: "Proizvod",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Kolicina",
                table: "Proizvod");

            migrationBuilder.DropColumn(
                name: "MjernaJedinica",
                table: "Proizvod");
        }
    }
}
