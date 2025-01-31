using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Estudo_Exemplo1.Migrations
{
    /// <inheritdoc />
    public partial class vendas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Vendas",
                table: "Pessoa",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Vendas",
                table: "Pessoa");
        }
    }
}
