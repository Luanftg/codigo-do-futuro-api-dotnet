using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace cdfapiintegrador.Migrations
{
    /// <inheritdoc />
    public partial class LojaAtualizaEnderecoId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Lojas_Enderecos_EnderecoId",
                table: "Lojas");

            migrationBuilder.DropColumn(
                name: "Endereco_id",
                table: "Lojas");

            migrationBuilder.AlterColumn<int>(
                name: "EnderecoId",
                table: "Lojas",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Lojas_Enderecos_EnderecoId",
                table: "Lojas",
                column: "EnderecoId",
                principalTable: "Enderecos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Lojas_Enderecos_EnderecoId",
                table: "Lojas");

            migrationBuilder.AlterColumn<int>(
                name: "EnderecoId",
                table: "Lojas",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "Endereco_id",
                table: "Lojas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_Lojas_Enderecos_EnderecoId",
                table: "Lojas",
                column: "EnderecoId",
                principalTable: "Enderecos",
                principalColumn: "Id");
        }
    }
}
