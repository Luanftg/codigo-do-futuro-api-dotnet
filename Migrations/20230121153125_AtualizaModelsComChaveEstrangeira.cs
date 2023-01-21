using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace cdfapiintegrador.Migrations
{
    /// <inheritdoc />
    public partial class AtualizaModelsComChaveEstrangeira : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Produto_Id",
                table: "posicoes-produtos",
                newName: "ProdutoId");

            migrationBuilder.RenameColumn(
                name: "Campanha_Id",
                table: "posicoes-produtos",
                newName: "CampanhaId");

            migrationBuilder.RenameColumn(
                name: "Produto_Id",
                table: "pedidos-produtos",
                newName: "ProdutoId");

            migrationBuilder.RenameColumn(
                name: "Pedido_Id",
                table: "pedidos-produtos",
                newName: "PedidoId");

            migrationBuilder.RenameColumn(
                name: "Cliente_Id",
                table: "Pedidos",
                newName: "ClienteId");

            migrationBuilder.RenameColumn(
                name: "Photo_Url",
                table: "Campanhas",
                newName: "PhotoUrl");

            migrationBuilder.RenameColumn(
                name: "Loja_Id",
                table: "Campanhas",
                newName: "LojaId");

            migrationBuilder.RenameColumn(
                name: "Dt_Criacao",
                table: "Campanhas",
                newName: "DtCriacao");

            migrationBuilder.AddColumn<int>(
                name: "ProdutoId1",
                table: "posicoes-produtos",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_posicoes-produtos_CampanhaId",
                table: "posicoes-produtos",
                column: "CampanhaId");

            migrationBuilder.CreateIndex(
                name: "IX_posicoes-produtos_ProdutoId1",
                table: "posicoes-produtos",
                column: "ProdutoId1");

            migrationBuilder.CreateIndex(
                name: "IX_pedidos-produtos_PedidoId",
                table: "pedidos-produtos",
                column: "PedidoId");

            migrationBuilder.CreateIndex(
                name: "IX_pedidos-produtos_ProdutoId",
                table: "pedidos-produtos",
                column: "ProdutoId");

            migrationBuilder.CreateIndex(
                name: "IX_Pedidos_ClienteId",
                table: "Pedidos",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_Campanhas_LojaId",
                table: "Campanhas",
                column: "LojaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Campanhas_Lojas_LojaId",
                table: "Campanhas",
                column: "LojaId",
                principalTable: "Lojas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Pedidos_Cliente_ClienteId",
                table: "Pedidos",
                column: "ClienteId",
                principalTable: "Cliente",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_pedidos-produtos_Pedidos_PedidoId",
                table: "pedidos-produtos",
                column: "PedidoId",
                principalTable: "Pedidos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_pedidos-produtos_Produtos_ProdutoId",
                table: "pedidos-produtos",
                column: "ProdutoId",
                principalTable: "Produtos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_posicoes-produtos_Campanhas_CampanhaId",
                table: "posicoes-produtos",
                column: "CampanhaId",
                principalTable: "Campanhas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_posicoes-produtos_Produtos_ProdutoId1",
                table: "posicoes-produtos",
                column: "ProdutoId1",
                principalTable: "Produtos",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Campanhas_Lojas_LojaId",
                table: "Campanhas");

            migrationBuilder.DropForeignKey(
                name: "FK_Pedidos_Cliente_ClienteId",
                table: "Pedidos");

            migrationBuilder.DropForeignKey(
                name: "FK_pedidos-produtos_Pedidos_PedidoId",
                table: "pedidos-produtos");

            migrationBuilder.DropForeignKey(
                name: "FK_pedidos-produtos_Produtos_ProdutoId",
                table: "pedidos-produtos");

            migrationBuilder.DropForeignKey(
                name: "FK_posicoes-produtos_Campanhas_CampanhaId",
                table: "posicoes-produtos");

            migrationBuilder.DropForeignKey(
                name: "FK_posicoes-produtos_Produtos_ProdutoId1",
                table: "posicoes-produtos");

            migrationBuilder.DropIndex(
                name: "IX_posicoes-produtos_CampanhaId",
                table: "posicoes-produtos");

            migrationBuilder.DropIndex(
                name: "IX_posicoes-produtos_ProdutoId1",
                table: "posicoes-produtos");

            migrationBuilder.DropIndex(
                name: "IX_pedidos-produtos_PedidoId",
                table: "pedidos-produtos");

            migrationBuilder.DropIndex(
                name: "IX_pedidos-produtos_ProdutoId",
                table: "pedidos-produtos");

            migrationBuilder.DropIndex(
                name: "IX_Pedidos_ClienteId",
                table: "Pedidos");

            migrationBuilder.DropIndex(
                name: "IX_Campanhas_LojaId",
                table: "Campanhas");

            migrationBuilder.DropColumn(
                name: "ProdutoId1",
                table: "posicoes-produtos");

            migrationBuilder.RenameColumn(
                name: "ProdutoId",
                table: "posicoes-produtos",
                newName: "Produto_Id");

            migrationBuilder.RenameColumn(
                name: "CampanhaId",
                table: "posicoes-produtos",
                newName: "Campanha_Id");

            migrationBuilder.RenameColumn(
                name: "ProdutoId",
                table: "pedidos-produtos",
                newName: "Produto_Id");

            migrationBuilder.RenameColumn(
                name: "PedidoId",
                table: "pedidos-produtos",
                newName: "Pedido_Id");

            migrationBuilder.RenameColumn(
                name: "ClienteId",
                table: "Pedidos",
                newName: "Cliente_Id");

            migrationBuilder.RenameColumn(
                name: "PhotoUrl",
                table: "Campanhas",
                newName: "Photo_Url");

            migrationBuilder.RenameColumn(
                name: "LojaId",
                table: "Campanhas",
                newName: "Loja_Id");

            migrationBuilder.RenameColumn(
                name: "DtCriacao",
                table: "Campanhas",
                newName: "Dt_Criacao");
        }
    }
}
