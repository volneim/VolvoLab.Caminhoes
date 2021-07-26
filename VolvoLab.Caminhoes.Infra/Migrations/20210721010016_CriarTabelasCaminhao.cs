using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace VolvoLab.Caminhoes.Infra.Data.Migrations
{
    public partial class CriarTabelasCaminhao : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Caminhao_Modelos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PrimaryKey_Caminhao_Modelos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Caminhoes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Modelo = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    AnoFab = table.Column<int>(type: "int", nullable: false),
                    AnoMod = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PrimaryKey_Caminhao", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Caminhao_Modelos",
                columns: new[] { "Id", "Nome" },
                values: new object[,]
                {
                    { new Guid("c61a3917-b3ee-4c03-b568-a6027f1a4569"), "FH" },
                    { new Guid("4aab4f9b-8e0a-4de4-8477-5bc1a55e4358"), "FM" }
                });

            migrationBuilder.InsertData(
                table: "Caminhoes",
                columns: new[] { "Id", "AnoFab", "AnoMod", "Modelo" },
                values: new object[,]
                {
                    { new Guid("bf40485e-28a5-4ae2-974e-4cc909a38273"), 2021, 2022, "FH" },
                    { new Guid("6eff1a20-4529-49f3-a1b4-73221c564df0"), 2021, 2021, "FM" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Caminhao_Modelos");

            migrationBuilder.DropTable(
                name: "Caminhoes");
        }
    }
}
