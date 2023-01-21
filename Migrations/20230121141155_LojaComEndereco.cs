using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace cdfapiintegrador.Migrations
{
    /// <inheritdoc />
    public partial class LojaComEndereco : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "EnderecoId",
                table: "Lojas",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Lojas_EnderecoId",
                table: "Lojas",
                column: "EnderecoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Lojas_Enderecos_EnderecoId",
                table: "Lojas",
                column: "EnderecoId",
                principalTable: "Enderecos",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Lojas_Enderecos_EnderecoId",
                table: "Lojas");

            migrationBuilder.DropIndex(
                name: "IX_Lojas_EnderecoId",
                table: "Lojas");

            migrationBuilder.DropColumn(
                name: "EnderecoId",
                table: "Lojas");
        }
    }
}
