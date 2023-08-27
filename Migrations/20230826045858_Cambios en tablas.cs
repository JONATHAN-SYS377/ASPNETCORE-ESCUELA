using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Escuela_Sor_Maria.Migrations
{
    /// <inheritdoc />
    public partial class Cambiosentablas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Apellidos",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Cedula",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Nombre",
                table: "AspNetUsers");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "tbMaterias",
                newName: "IdMateria");

            migrationBuilder.RenameColumn(
                name: "NombreGrado",
                table: "tbCursos",
                newName: "NombreCursoo");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "tbCursos",
                newName: "IdCurso");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IdMateria",
                table: "tbMaterias",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "NombreCursoo",
                table: "tbCursos",
                newName: "NombreGrado");

            migrationBuilder.RenameColumn(
                name: "IdCurso",
                table: "tbCursos",
                newName: "Id");

            migrationBuilder.AddColumn<string>(
                name: "Apellidos",
                table: "AspNetUsers",
                type: "nvarchar(100)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Cedula",
                table: "AspNetUsers",
                type: "nvarchar(20)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Nombre",
                table: "AspNetUsers",
                type: "nvarchar(100)",
                nullable: false,
                defaultValue: "");
        }
    }
}
