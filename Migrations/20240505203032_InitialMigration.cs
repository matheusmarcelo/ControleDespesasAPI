using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ControleDespesas.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    DDD = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: true),
                    Celular = table.Column<string>(type: "nvarchar(9)", maxLength: 9, nullable: true),
                    DataNascimento = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CEP = table.Column<string>(type: "nvarchar(6)", maxLength: 6, nullable: true),
                    Cidade = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Estado = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Endereco = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NumeroEndereco = table.Column<int>(type: "int", nullable: true),
                    ComplementoEndereco = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.UserId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Usuarios");
        }
    }
}
