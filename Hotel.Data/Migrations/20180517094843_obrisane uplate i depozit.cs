using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Hotel.Data.Migrations
{
    public partial class obrisaneuplateidepozit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Uplata");

            migrationBuilder.DropColumn(
                name: "Depozit",
                table: "CheckIN");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<float>(
                name: "Depozit",
                table: "CheckIN",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.CreateTable(
                name: "Uplata",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CheckINId = table.Column<int>(nullable: false),
                    DatumUplate = table.Column<DateTime>(nullable: false),
                    Iznos = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Uplata", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Uplata_CheckIN_CheckINId",
                        column: x => x.CheckINId,
                        principalTable: "CheckIN",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Uplata_CheckINId",
                table: "Uplata",
                column: "CheckINId");
        }
    }
}
