using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Escuela_Sor_Maria.Migrations
{
    /// <inheritdoc />
    public partial class Creaciontbalumnostncursostbmateiastbcalificaciones : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tbAlumnos",
                columns: table => new
                {
                    Cedula = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Aoellido1 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Apellido2 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Sexo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FechaNacimiento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Edad = table.Column<int>(type: "int", nullable: false),
                    ProvinciaID = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CantonID = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DistritoID = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BarrioID = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Direccion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CedulaEncargado = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EncargadoLegal = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ContactoEmergencia = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Estado = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbAlumnos", x => x.Cedula);
                });

            migrationBuilder.CreateTable(
                name: "tbCursos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreGrado = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nivel = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Duracion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Estado = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbCursos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tbMaterias",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CursoID = table.Column<int>(type: "int", nullable: false),
                    NombreMateria = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProfesorAsignado = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Estado = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbMaterias", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tbMaterias_tbCursos_CursoID",
                        column: x => x.CursoID,
                        principalTable: "tbCursos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tbMaterias_tbPersona_ProfesorAsignado",
                        column: x => x.ProfesorAsignado,
                        principalTable: "tbPersona",
                        principalColumn: "Cedula",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tbCalificaciones",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CedulaEstudianteID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    MateriaID = table.Column<int>(type: "int", nullable: false),
                    FechaCalificacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NotaObtenida = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbCalificaciones", x => x.id);
                    table.ForeignKey(
                        name: "FK_tbCalificaciones_tbAlumnos_CedulaEstudianteID",
                        column: x => x.CedulaEstudianteID,
                        principalTable: "tbAlumnos",
                        principalColumn: "Cedula",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tbCalificaciones_tbMaterias_MateriaID",
                        column: x => x.MateriaID,
                        principalTable: "tbMaterias",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tbCalificaciones_CedulaEstudianteID",
                table: "tbCalificaciones",
                column: "CedulaEstudianteID");

            migrationBuilder.CreateIndex(
                name: "IX_tbCalificaciones_MateriaID",
                table: "tbCalificaciones",
                column: "MateriaID");

            migrationBuilder.CreateIndex(
                name: "IX_tbMaterias_CursoID",
                table: "tbMaterias",
                column: "CursoID");

            migrationBuilder.CreateIndex(
                name: "IX_tbMaterias_ProfesorAsignado",
                table: "tbMaterias",
                column: "ProfesorAsignado");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tbCalificaciones");

            migrationBuilder.DropTable(
                name: "tbAlumnos");

            migrationBuilder.DropTable(
                name: "tbMaterias");

            migrationBuilder.DropTable(
                name: "tbCursos");
        }
    }
}
