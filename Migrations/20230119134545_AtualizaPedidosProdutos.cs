using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace cdfapiintegrador.Migrations
{
    /// <inheritdoc />
    public partial class AtualizaPedidosProdutos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_PedidoProdutos",
                table: "PedidoProdutos");

            migrationBuilder.RenameTable(
                name: "PedidoProdutos",
                newName: "pedidos-produtos");

            migrationBuilder.AddPrimaryKey(
                name: "PK_pedidos-produtos",
                table: "pedidos-produtos",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_pedidos-produtos",
                table: "pedidos-produtos");

            migrationBuilder.RenameTable(
                name: "pedidos-produtos",
                newName: "PedidoProdutos");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PedidoProdutos",
                table: "PedidoProdutos",
                column: "Id");
        }
    }
}
