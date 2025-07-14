using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebAtencionClientes.Migrations
{
    /// <inheritdoc />
    public partial class AtencionClientes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "InfoCliente",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NOMBRE = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    APELLIDOS = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CELULAR = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EMAIL = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SEXO = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MOTIVO = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FECHA_ALTA = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InfoCliente", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "InfoCliente");
        }
    }
}
