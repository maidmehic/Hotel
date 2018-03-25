using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Hotel.Data.Migrations
{
    public partial class dodanUsernamePasswordUZaposlenika : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "password",
                table: "Zaposlenik",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "username",
                table: "Zaposlenik",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "password",
                table: "Zaposlenik");

            migrationBuilder.DropColumn(
                name: "username",
                table: "Zaposlenik");
        }
    }
}
