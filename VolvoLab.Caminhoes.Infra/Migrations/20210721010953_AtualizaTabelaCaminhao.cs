using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace VolvoLab.Caminhoes.Infra.Data.Migrations
{
    public partial class AtualizaTabelaCaminhao : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Caminhao_Modelos",
                keyColumn: "Id",
                keyValue: new Guid("4aab4f9b-8e0a-4de4-8477-5bc1a55e4358"));

            migrationBuilder.DeleteData(
                table: "Caminhao_Modelos",
                keyColumn: "Id",
                keyValue: new Guid("c61a3917-b3ee-4c03-b568-a6027f1a4569"));

            migrationBuilder.DeleteData(
                table: "Caminhoes",
                keyColumn: "Id",
                keyValue: new Guid("6eff1a20-4529-49f3-a1b4-73221c564df0"));

            migrationBuilder.DeleteData(
                table: "Caminhoes",
                keyColumn: "Id",
                keyValue: new Guid("bf40485e-28a5-4ae2-974e-4cc909a38273"));

            migrationBuilder.AddColumn<string>(
                name: "NumSerie",
                table: "Caminhoes",
                type: "nvarchar(18)",
                maxLength: 18,
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "Caminhao_Modelos",
                columns: new[] { "Id", "Nome" },
                values: new object[,]
                {
                    { new Guid("ac2128d3-0d91-4b37-9be0-acd4ee6015dd"), "FH" },
                    { new Guid("2a197bb0-2c33-4611-88e6-68fae13f0d8e"), "FM" }
                });

            migrationBuilder.InsertData(
                table: "Caminhoes",
                columns: new[] { "Id", "AnoFab", "AnoMod", "Modelo", "NumSerie" },
                values: new object[,]
                {
                    { new Guid("a4013194-39ce-48f5-8197-684ad2d9ce01"), 2021, 2022, "FH", "123ABC" },
                    { new Guid("0895c460-2bba-473e-a9f0-4fde069115c4"), 2021, 2021, "FM", "3452XXY" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Caminhao_Modelos",
                keyColumn: "Id",
                keyValue: new Guid("2a197bb0-2c33-4611-88e6-68fae13f0d8e"));

            migrationBuilder.DeleteData(
                table: "Caminhao_Modelos",
                keyColumn: "Id",
                keyValue: new Guid("ac2128d3-0d91-4b37-9be0-acd4ee6015dd"));

            migrationBuilder.DeleteData(
                table: "Caminhoes",
                keyColumn: "Id",
                keyValue: new Guid("0895c460-2bba-473e-a9f0-4fde069115c4"));

            migrationBuilder.DeleteData(
                table: "Caminhoes",
                keyColumn: "Id",
                keyValue: new Guid("a4013194-39ce-48f5-8197-684ad2d9ce01"));

            migrationBuilder.DropColumn(
                name: "NumSerie",
                table: "Caminhoes");

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
    }
}
