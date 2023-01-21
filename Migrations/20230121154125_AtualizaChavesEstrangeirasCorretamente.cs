using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace cdfapiintegrador.Migrations
{
    /// <inheritdoc />
    public partial class AtualizaChavesEstrangeirasCorretamente : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_posicoes-produtos_Produtos_ProdutoId1",
                table: "posicoes-produtos");

            migrationBuilder.DropIndex(
                name: "IX_posicoes-produtos_ProdutoId1",
                table: "posicoes-produtos");

            migrationBuilder.DropColumn(
                name: "ProdutoId1",
                table: "posicoes-produtos");

            migrationBuilder.AlterColumn<int>(
                name: "ProdutoId",
                table: "posicoes-produtos",
                type: "int",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(65,30)");

            migrationBuilder.CreateIndex(
                name: "IX_posicoes-produtos_ProdutoId",
                table: "posicoes-produtos",
                column: "ProdutoId");

            migrationBuilder.AddForeignKey(
                name: "FK_posicoes-produtos_Produtos_ProdutoId",
                table: "posicoes-produtos",
                column: "ProdutoId",
                principalTable: "Produtos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_posicoes-produtos_Produtos_ProdutoId",
                table: "posicoes-produtos");

            migrationBuilder.DropIndex(
                name: "IX_posicoes-produtos_ProdutoId",
                table: "posicoes-produtos");

            migrationBuilder.AlterColumn<decimal>(
                name: "ProdutoId",
                table: "posicoes-produtos",
                type: "decimal(65,30)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "ProdutoId1",
                table: "posicoes-produtos",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_posicoes-produtos_ProdutoId1",
                table: "posicoes-produtos",
                column: "ProdutoId1");

            migrationBuilder.AddForeignKey(
                name: "FK_posicoes-produtos_Produtos_ProdutoId1",
                table: "posicoes-produtos",
                column: "ProdutoId1",
                principalTable: "Produtos",
                principalColumn: "Id");
        }
    }
}
