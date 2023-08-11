using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LogicaAccesoDatos.Migrations
{
    /// <inheritdoc />
    public partial class sacandoEliminacionEnCascada : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cabanias_Tipos_TipoId",
                table: "Cabanias");

            migrationBuilder.AddForeignKey(
                name: "FK_Cabanias_Tipos_TipoId",
                table: "Cabanias",
                column: "TipoId",
                principalTable: "Tipos",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cabanias_Tipos_TipoId",
                table: "Cabanias");

            migrationBuilder.AddForeignKey(
                name: "FK_Cabanias_Tipos_TipoId",
                table: "Cabanias",
                column: "TipoId",
                principalTable: "Tipos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
