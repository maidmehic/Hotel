using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Hotel.Data.Migrations
{
    public partial class Izmjenjena_tabela_ZahtjevZaCiscenjem : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Obavljen",
                table: "ZahtjevZaCiscenjem",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Obavljen",
                table: "ZahtjevZaCiscenjem");
        }
    }
}
