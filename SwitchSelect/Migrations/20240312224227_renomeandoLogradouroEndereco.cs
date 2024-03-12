using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SwitchSelect.Migrations
{
    /// <inheritdoc />
    public partial class renomeandoLogradouroEndereco : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Logradouros_Clientes_ClienteId",
                table: "Logradouros");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Logradouros",
                table: "Logradouros");

            migrationBuilder.RenameTable(
                name: "Logradouros",
                newName: "Enderecos");

            migrationBuilder.RenameIndex(
                name: "IX_Logradouros_ClienteId",
                table: "Enderecos",
                newName: "IX_Enderecos_ClienteId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Enderecos",
                table: "Enderecos",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Enderecos_Clientes_ClienteId",
                table: "Enderecos",
                column: "ClienteId",
                principalTable: "Clientes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Enderecos_Clientes_ClienteId",
                table: "Enderecos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Enderecos",
                table: "Enderecos");

            migrationBuilder.RenameTable(
                name: "Enderecos",
                newName: "Logradouros");

            migrationBuilder.RenameIndex(
                name: "IX_Enderecos_ClienteId",
                table: "Logradouros",
                newName: "IX_Logradouros_ClienteId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Logradouros",
                table: "Logradouros",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Logradouros_Clientes_ClienteId",
                table: "Logradouros",
                column: "ClienteId",
                principalTable: "Clientes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
