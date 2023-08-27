using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Escuela_Sor_Maria.Migrations
{
    /// <inheritdoc />
    public partial class agregarestadoaalumno : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Estado",
                table: "tbAlumnos",
                type: "int",
                nullable: false,
                defaultValue: 1);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Estado",
                table: "tbAlumnos");
        }
    }
}
