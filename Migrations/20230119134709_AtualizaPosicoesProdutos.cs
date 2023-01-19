using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace cdfapiintegrador.Migrations
{
    /// <inheritdoc />
    public partial class AtualizaPosicoesProdutos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_PosicoesProdutos",
                table: "PosicoesProdutos");

            migrationBuilder.RenameTable(
                name: "PosicoesProdutos",
                newName: "posicoes-produtos");

            migrationBuilder.AddPrimaryKey(
                name: "PK_posicoes-produtos",
                table: "posicoes-produtos",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_posicoes-produtos",
                table: "posicoes-produtos");

            migrationBuilder.RenameTable(
                name: "posicoes-produtos",
                newName: "PosicoesProdutos");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PosicoesProdutos",
                table: "PosicoesProdutos",
                column: "Id");
        }
    }
}
