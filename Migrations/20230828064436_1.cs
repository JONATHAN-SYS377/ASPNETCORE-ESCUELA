using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Escuela_Sor_Maria.Migrations
{
    /// <inheritdoc />
    public partial class _1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Alumno_Ubicacion",
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
                    table.PrimaryKey("PK_Alumno_Ubicacion", x => x.Cedula);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

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
                    IdCurso = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreCursoo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nivel = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Duracion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Estado = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbCursos", x => x.IdCurso);
                });

            migrationBuilder.CreateTable(
                name: "tbPersona",
                columns: table => new
                {
                    Cedula = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Apellido1 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Apellido2 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FechaNacimiento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Sexo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Telefono = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProvinciaID = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CantonID = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DistritoID = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BarrioID = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Direccion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Estado = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbPersona", x => x.Cedula);
                });

            migrationBuilder.CreateTable(
                name: "tbProvincia",
                columns: table => new
                {
                    Cod = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbProvincia", x => x.Cod);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tbMatriculas",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false),
                    CedulaID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CursoID = table.Column<int>(type: "int", nullable: false),
                    Alumno_UbicacionCedula = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbMatriculas", x => x.id);
                    table.ForeignKey(
                        name: "FK_tbMatriculas_Alumno_Ubicacion_Alumno_UbicacionCedula",
                        column: x => x.Alumno_UbicacionCedula,
                        principalTable: "Alumno_Ubicacion",
                        principalColumn: "Cedula");
                    table.ForeignKey(
                        name: "FK_tbMatriculas_tbAlumnos_CedulaID",
                        column: x => x.CedulaID,
                        principalTable: "tbAlumnos",
                        principalColumn: "Cedula",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tbMatriculas_tbCursos_CursoID",
                        column: x => x.CursoID,
                        principalTable: "tbCursos",
                        principalColumn: "IdCurso",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tbMaterias",
                columns: table => new
                {
                    IdMateria = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CursoID = table.Column<int>(type: "int", nullable: false),
                    NombreMateria = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProfesorAsignado = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Estado = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbMaterias", x => x.IdMateria);
                    table.ForeignKey(
                        name: "FK_tbMaterias_tbCursos_CursoID",
                        column: x => x.CursoID,
                        principalTable: "tbCursos",
                        principalColumn: "IdCurso",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tbMaterias_tbPersona_ProfesorAsignado",
                        column: x => x.ProfesorAsignado,
                        principalTable: "tbPersona",
                        principalColumn: "Cedula",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tbCanton",
                columns: table => new
                {
                    ProvinciaID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Canton = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    tbProvinciaCod = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbCanton", x => new { x.ProvinciaID, x.Canton });
                    table.ForeignKey(
                        name: "FK_tbCanton_tbProvincia_tbProvinciaCod",
                        column: x => x.tbProvinciaCod,
                        principalTable: "tbProvincia",
                        principalColumn: "Cod");
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
                        principalColumn: "IdMateria",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tbDistrito",
                columns: table => new
                {
                    ProvinciaID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CantonID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Distrito = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbDistrito", x => new { x.ProvinciaID, x.CantonID, x.Distrito });
                    table.ForeignKey(
                        name: "FK_tbDistrito_tbCanton_ProvinciaID_CantonID",
                        columns: x => new { x.ProvinciaID, x.CantonID },
                        principalTable: "tbCanton",
                        principalColumns: new[] { "ProvinciaID", "Canton" },
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tbBarrios",
                columns: table => new
                {
                    ProvinciaID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CantonID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    DistritoID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Barrio = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbBarrios", x => new { x.ProvinciaID, x.CantonID, x.DistritoID, x.Barrio });
                    table.ForeignKey(
                        name: "FK_tbBarrios_tbDistrito_ProvinciaID_CantonID_DistritoID",
                        columns: x => new { x.ProvinciaID, x.CantonID, x.DistritoID },
                        principalTable: "tbDistrito",
                        principalColumns: new[] { "ProvinciaID", "CantonID", "Distrito" },
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_tbCalificaciones_CedulaEstudianteID",
                table: "tbCalificaciones",
                column: "CedulaEstudianteID");

            migrationBuilder.CreateIndex(
                name: "IX_tbCalificaciones_MateriaID",
                table: "tbCalificaciones",
                column: "MateriaID");

            migrationBuilder.CreateIndex(
                name: "IX_tbCanton_tbProvinciaCod",
                table: "tbCanton",
                column: "tbProvinciaCod");

            migrationBuilder.CreateIndex(
                name: "IX_tbMaterias_CursoID",
                table: "tbMaterias",
                column: "CursoID");

            migrationBuilder.CreateIndex(
                name: "IX_tbMaterias_ProfesorAsignado",
                table: "tbMaterias",
                column: "ProfesorAsignado");

            migrationBuilder.CreateIndex(
                name: "IX_tbMatriculas_Alumno_UbicacionCedula",
                table: "tbMatriculas",
                column: "Alumno_UbicacionCedula");

            migrationBuilder.CreateIndex(
                name: "IX_tbMatriculas_CedulaID",
                table: "tbMatriculas",
                column: "CedulaID");

            migrationBuilder.CreateIndex(
                name: "IX_tbMatriculas_CursoID",
                table: "tbMatriculas",
                column: "CursoID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "tbBarrios");

            migrationBuilder.DropTable(
                name: "tbCalificaciones");

            migrationBuilder.DropTable(
                name: "tbMatriculas");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "tbDistrito");

            migrationBuilder.DropTable(
                name: "tbMaterias");

            migrationBuilder.DropTable(
                name: "Alumno_Ubicacion");

            migrationBuilder.DropTable(
                name: "tbAlumnos");

            migrationBuilder.DropTable(
                name: "tbCanton");

            migrationBuilder.DropTable(
                name: "tbCursos");

            migrationBuilder.DropTable(
                name: "tbPersona");

            migrationBuilder.DropTable(
                name: "tbProvincia");
        }
    }
}
