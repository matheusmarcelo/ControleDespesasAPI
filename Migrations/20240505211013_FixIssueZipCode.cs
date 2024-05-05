using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ControleDespesas.Migrations
{
    /// <inheritdoc />
    public partial class FixIssueZipCode : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "CEP",
                table: "Usuarios",
                type: "nvarchar(8)",
                maxLength: 8,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(6)",
                oldMaxLength: 6,
                oldNullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "CEP",
                table: "Usuarios",
                type: "nvarchar(6)",
                maxLength: 6,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(8)",
                oldMaxLength: 8,
                oldNullable: true);
        }
    }
}
