using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TesteBenner.Migrations
{
    /// <inheritdoc />
    public partial class AdiconandoOHorarioDeSaida : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Saida",
                table: "Veiculo");

            migrationBuilder.RenameColumn(
                name: "Entrada",
                table: "Veiculo",
                newName: "HoraEntra");

            migrationBuilder.CreateTable(
                name: "Saida",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    HoraSaida = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Placa = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Saida", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Saida");

            migrationBuilder.RenameColumn(
                name: "HoraEntra",
                table: "Veiculo",
                newName: "Entrada");

            migrationBuilder.AddColumn<DateTime>(
                name: "Saida",
                table: "Veiculo",
                type: "datetime(6)",
                nullable: true);
        }
    }
}
