using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Hotel.Data.Migrations
{
    public partial class dodanadostavastavke : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Cijena",
                table: "Dostava");

            migrationBuilder.DropColumn(
                name: "Kolicina",
                table: "Dostava");

            migrationBuilder.DropColumn(
                name: "Naziv",
                table: "Dostava");

            migrationBuilder.AddColumn<DateTime>(
                name: "Datum",
                table: "Dostava",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "Zavrsena",
                table: "Dostava",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Datum",
                table: "Dostava");

            migrationBuilder.DropColumn(
                name: "Zavrsena",
                table: "Dostava");

            migrationBuilder.AddColumn<float>(
                name: "Cijena",
                table: "Dostava",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<int>(
                name: "Kolicina",
                table: "Dostava",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Naziv",
                table: "Dostava",
                nullable: true);
        }
    }
}
