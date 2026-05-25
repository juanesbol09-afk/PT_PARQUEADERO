using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Parqueadero.Infrastructura.Migrations
{
    /// <inheritdoc />
    public partial class AgregarCamposPago : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TotalMinutos",
                table: "Vehiculos",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "ValorPagado",
                table: "Vehiculos",
                type: "decimal(65,30)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TotalMinutos",
                table: "Vehiculos");

            migrationBuilder.DropColumn(
                name: "ValorPagado",
                table: "Vehiculos");
        }
    }
}
