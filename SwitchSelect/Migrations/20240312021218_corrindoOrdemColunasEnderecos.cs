using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SwitchSelect.Migrations
{
    /// <inheritdoc />
    public partial class corrindoOrdemColunasEnderecos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
    name: "Enderecos",
    columns: table => new
    {
        Id = table.Column<int>(nullable: false)
            .Annotation("SqlServer:Identity", "1, 1"),
        Logradouro = table.Column<string>(maxLength: 200, nullable: false),
        Numero = table.Column<string>(maxLength: 50, nullable: false),
        Cep = table.Column<string>(maxLength: 8, nullable: false),
        Bairro = table.Column<string>(maxLength: 100, nullable: false),
        Cidade = table.Column<string>(maxLength: 100, nullable: false),
        Estado = table.Column<string>(maxLength: 100, nullable: false),
        Complemento = table.Column<string>(maxLength: 100, nullable: true),
        ClienteId = table.Column<int>(nullable: false),
    },
    constraints: table =>
    {
        table.PrimaryKey("PK_Enderecos", x => x.Id);
        table.ForeignKey(
            name: "FK_Enderecos_Clientes_ClienteId",
            column: x => x.ClienteId,
            principalTable: "Clientes",
            principalColumn: "Id",
            onDelete: ReferentialAction.Cascade);
    });

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
