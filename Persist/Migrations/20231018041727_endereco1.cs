using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persist.Migrations
{
    /// <inheritdoc />
    public partial class endereco1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EnderecoCliente_Clientes_ClienteId",
                table: "EnderecoCliente");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EnderecoCliente",
                table: "EnderecoCliente");

            migrationBuilder.RenameTable(
                name: "EnderecoCliente",
                newName: "Endereco");

            migrationBuilder.RenameIndex(
                name: "IX_EnderecoCliente_ClienteId",
                table: "Endereco",
                newName: "IX_Endereco_ClienteId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Endereco",
                table: "Endereco",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Endereco_Clientes_ClienteId",
                table: "Endereco",
                column: "ClienteId",
                principalTable: "Clientes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Endereco_Clientes_ClienteId",
                table: "Endereco");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Endereco",
                table: "Endereco");

            migrationBuilder.RenameTable(
                name: "Endereco",
                newName: "EnderecoCliente");

            migrationBuilder.RenameIndex(
                name: "IX_Endereco_ClienteId",
                table: "EnderecoCliente",
                newName: "IX_EnderecoCliente_ClienteId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EnderecoCliente",
                table: "EnderecoCliente",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_EnderecoCliente_Clientes_ClienteId",
                table: "EnderecoCliente",
                column: "ClienteId",
                principalTable: "Clientes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
