using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace cdfapiintegrador.Migrations
{
    /// <inheritdoc />
    public partial class AtualizaTabelas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_PosicoesProduto",
                table: "PosicoesProduto");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PedidoProduto",
                table: "PedidoProduto");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Pedido",
                table: "Pedido");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Loja",
                table: "Loja");

            migrationBuilder.RenameTable(
                name: "PosicoesProduto",
                newName: "PosicoesProdutos");

            migrationBuilder.RenameTable(
                name: "PedidoProduto",
                newName: "PedidoProdutos");

            migrationBuilder.RenameTable(
                name: "Pedido",
                newName: "Pedidos");

            migrationBuilder.RenameTable(
                name: "Loja",
                newName: "Lojas");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PosicoesProdutos",
                table: "PosicoesProdutos",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PedidoProdutos",
                table: "PedidoProdutos",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Pedidos",
                table: "Pedidos",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Lojas",
                table: "Lojas",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_PosicoesProdutos",
                table: "PosicoesProdutos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Pedidos",
                table: "Pedidos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PedidoProdutos",
                table: "PedidoProdutos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Lojas",
                table: "Lojas");

            migrationBuilder.RenameTable(
                name: "PosicoesProdutos",
                newName: "PosicoesProduto");

            migrationBuilder.RenameTable(
                name: "Pedidos",
                newName: "Pedido");

            migrationBuilder.RenameTable(
                name: "PedidoProdutos",
                newName: "PedidoProduto");

            migrationBuilder.RenameTable(
                name: "Lojas",
                newName: "Loja");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PosicoesProduto",
                table: "PosicoesProduto",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Pedido",
                table: "Pedido",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PedidoProduto",
                table: "PedidoProduto",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Loja",
                table: "Loja",
                column: "Id");
        }
    }
}
