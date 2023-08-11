using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LogicaAccesoDatos.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Tipos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre_NombreTipo = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CostoPorHuesped_Costo = table.Column<double>(type: "float", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tipos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Cabanias",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TipoId = table.Column<int>(type: "int", nullable: false),
                    Nombre_Nombre = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Descripcion_Descripcion = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    PoseeJacuzzi = table.Column<bool>(type: "bit", nullable: false),
                    HabilitadoReservas = table.Column<bool>(type: "bit", nullable: false),
                    NumHabitacion = table.Column<int>(type: "int", nullable: false),
                    CapacidadMaximaPersonas = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cabanias", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cabanias_Tipos_TipoId",
                        column: x => x.TipoId,
                        principalTable: "Tipos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Fotos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreFoto = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CabaniaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fotos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Fotos_Cabanias_CabaniaId",
                        column: x => x.CabaniaId,
                        principalTable: "Cabanias",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Mantenimientos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Fecha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Costo = table.Column<double>(type: "float", nullable: false),
                    NombreTrabajador = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CabaniaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mantenimientos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Mantenimientos_Cabanias_CabaniaId",
                        column: x => x.CabaniaId,
                        principalTable: "Cabanias",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cabanias_Descripcion_Descripcion",
                table: "Cabanias",
                column: "Descripcion_Descripcion");

            migrationBuilder.CreateIndex(
                name: "IX_Cabanias_Nombre_Nombre",
                table: "Cabanias",
                column: "Nombre_Nombre");

            migrationBuilder.CreateIndex(
                name: "IX_Cabanias_NumHabitacion",
                table: "Cabanias",
                column: "NumHabitacion",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Cabanias_TipoId",
                table: "Cabanias",
                column: "TipoId");

            migrationBuilder.CreateIndex(
                name: "IX_Fotos_CabaniaId",
                table: "Fotos",
                column: "CabaniaId");

            migrationBuilder.CreateIndex(
                name: "IX_Mantenimientos_CabaniaId",
                table: "Mantenimientos",
                column: "CabaniaId");

            migrationBuilder.CreateIndex(
                name: "IX_Tipos_CostoPorHuesped_Costo",
                table: "Tipos",
                column: "CostoPorHuesped_Costo");

            migrationBuilder.CreateIndex(
                name: "IX_Tipos_Nombre_NombreTipo",
                table: "Tipos",
                column: "Nombre_NombreTipo",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_Email",
                table: "Usuarios",
                column: "Email",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Fotos");

            migrationBuilder.DropTable(
                name: "Mantenimientos");

            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropTable(
                name: "Cabanias");

            migrationBuilder.DropTable(
                name: "Tipos");
        }
    }
}
