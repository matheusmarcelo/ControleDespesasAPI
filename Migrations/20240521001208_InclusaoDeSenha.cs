﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ControleDespesas.Migrations
{
    /// <inheritdoc />
    public partial class InclusaoDeSenha : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Senha",
                table: "Usuarios",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Senha",
                table: "Usuarios");
        }
    }
}
