using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CrmJovenes.AccesoDatos.Migrations
{
    /// <inheritdoc />
    public partial class AgregarBrigadaMigracion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Brigadas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    NumeroPersonas = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Localidad = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Municipio = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ZonaId = table.Column<int>(type: "int", nullable: false),
                    Fecha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Estado = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Brigadas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Brigadas_Zonas_ZonaId",
                        column: x => x.ZonaId,
                        principalTable: "Zonas",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Brigadas_ZonaId",
                table: "Brigadas",
                column: "ZonaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Brigadas");
        }
    }
}
