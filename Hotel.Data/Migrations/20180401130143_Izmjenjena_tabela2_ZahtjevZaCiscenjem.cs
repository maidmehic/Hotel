using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Hotel.Data.Migrations
{
    public partial class Izmjenjena_tabela2_ZahtjevZaCiscenjem : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ZahtjevZaCiscenjem_Zaposlenik_ZaposlenikId",
                table: "ZahtjevZaCiscenjem");

            migrationBuilder.AlterColumn<int>(
                name: "ZaposlenikId",
                table: "ZahtjevZaCiscenjem",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_ZahtjevZaCiscenjem_Zaposlenik_ZaposlenikId",
                table: "ZahtjevZaCiscenjem",
                column: "ZaposlenikId",
                principalTable: "Zaposlenik",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ZahtjevZaCiscenjem_Zaposlenik_ZaposlenikId",
                table: "ZahtjevZaCiscenjem");

            migrationBuilder.AlterColumn<int>(
                name: "ZaposlenikId",
                table: "ZahtjevZaCiscenjem",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ZahtjevZaCiscenjem_Zaposlenik_ZaposlenikId",
                table: "ZahtjevZaCiscenjem",
                column: "ZaposlenikId",
                principalTable: "Zaposlenik",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
