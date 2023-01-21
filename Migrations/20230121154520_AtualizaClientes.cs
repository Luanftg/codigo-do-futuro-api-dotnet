using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace cdfapiintegrador.Migrations
{
    /// <inheritdoc />
    public partial class AtualizaClientes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cliente_Enderecos_EnderecoId",
                table: "Cliente");

            migrationBuilder.DropForeignKey(
                name: "FK_Pedidos_Cliente_ClienteId",
                table: "Pedidos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Cliente",
                table: "Cliente");

            migrationBuilder.RenameTable(
                name: "Cliente",
                newName: "clientes");

            migrationBuilder.RenameIndex(
                name: "IX_Cliente_EnderecoId",
                table: "clientes",
                newName: "IX_clientes_EnderecoId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_clientes",
                table: "clientes",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_clientes_Enderecos_EnderecoId",
                table: "clientes",
                column: "EnderecoId",
                principalTable: "Enderecos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Pedidos_clientes_ClienteId",
                table: "Pedidos",
                column: "ClienteId",
                principalTable: "clientes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_clientes_Enderecos_EnderecoId",
                table: "clientes");

            migrationBuilder.DropForeignKey(
                name: "FK_Pedidos_clientes_ClienteId",
                table: "Pedidos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_clientes",
                table: "clientes");

            migrationBuilder.RenameTable(
                name: "clientes",
                newName: "Cliente");

            migrationBuilder.RenameIndex(
                name: "IX_clientes_EnderecoId",
                table: "Cliente",
                newName: "IX_Cliente_EnderecoId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Cliente",
                table: "Cliente",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Cliente_Enderecos_EnderecoId",
                table: "Cliente",
                column: "EnderecoId",
                principalTable: "Enderecos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Pedidos_Cliente_ClienteId",
                table: "Pedidos",
                column: "ClienteId",
                principalTable: "Cliente",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
