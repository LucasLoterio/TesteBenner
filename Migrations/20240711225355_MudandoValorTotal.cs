using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TesteBenner.Migrations
{
    /// <inheritdoc />
    public partial class MudandoValorTotal : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "valorTotal",
                table: "Veiculo",
                type: "int",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "valorTotal",
                table: "Veiculo");
        }
    }
}
