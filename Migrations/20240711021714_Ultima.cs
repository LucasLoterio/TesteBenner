using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TesteBenner.Migrations
{
    /// <inheritdoc />
    public partial class Ultima : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "tempo",
                table: "Saida");

            migrationBuilder.AddColumn<DateTime>(
                name: "HoraSaida",
                table: "Veiculo",
                type: "datetime(6)",
                nullable: true);

            migrationBuilder.AddColumn<TimeSpan>(
                name: "tempo",
                table: "Veiculo",
                type: "time(6)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HoraSaida",
                table: "Veiculo");

            migrationBuilder.DropColumn(
                name: "tempo",
                table: "Veiculo");

            migrationBuilder.AddColumn<TimeSpan>(
                name: "tempo",
                table: "Saida",
                type: "time(6)",
                nullable: false,
                defaultValue: new TimeSpan(0, 0, 0, 0, 0));
        }
    }
}
