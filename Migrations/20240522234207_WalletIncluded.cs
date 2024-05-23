using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ControleDespesas.Migrations
{
    /// <inheritdoc />
    public partial class WalletIncluded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Financeiro_Usuarios_UserId",
                table: "Financeiro");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Usuarios",
                newName: "UsuarioId");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Financeiro",
                newName: "UsuarioId");

            migrationBuilder.RenameColumn(
                name: "FinanceId",
                table: "Financeiro",
                newName: "FinanceiroId");

            migrationBuilder.RenameIndex(
                name: "IX_Financeiro_UserId",
                table: "Financeiro",
                newName: "IX_Financeiro_UsuarioId");

            migrationBuilder.AlterColumn<decimal>(
                name: "Valor",
                table: "Financeiro",
                type: "decimal(10,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.CreateTable(
                name: "Carteira",
                columns: table => new
                {
                    CarteiraId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UsuarioId = table.Column<int>(type: "int", nullable: false),
                    Total = table.Column<decimal>(type: "decimal(10,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Carteira", x => x.CarteiraId);
                    table.ForeignKey(
                        name: "FK_Carteira_Usuarios_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuarios",
                        principalColumn: "UsuarioId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Carteira_UsuarioId",
                table: "Carteira",
                column: "UsuarioId");

            migrationBuilder.AddForeignKey(
                name: "FK_Financeiro_Usuarios_UsuarioId",
                table: "Financeiro",
                column: "UsuarioId",
                principalTable: "Usuarios",
                principalColumn: "UsuarioId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Financeiro_Usuarios_UsuarioId",
                table: "Financeiro");

            migrationBuilder.DropTable(
                name: "Carteira");

            migrationBuilder.RenameColumn(
                name: "UsuarioId",
                table: "Usuarios",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "UsuarioId",
                table: "Financeiro",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "FinanceiroId",
                table: "Financeiro",
                newName: "FinanceId");

            migrationBuilder.RenameIndex(
                name: "IX_Financeiro_UsuarioId",
                table: "Financeiro",
                newName: "IX_Financeiro_UserId");

            migrationBuilder.AlterColumn<decimal>(
                name: "Valor",
                table: "Financeiro",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(10,2)");

            migrationBuilder.AddForeignKey(
                name: "FK_Financeiro_Usuarios_UserId",
                table: "Financeiro",
                column: "UserId",
                principalTable: "Usuarios",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
