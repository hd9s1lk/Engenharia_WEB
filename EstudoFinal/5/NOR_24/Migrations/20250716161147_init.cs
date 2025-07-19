using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NOR_24.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RegistoUtilizador",
                columns: table => new
                {
                    RegistoID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Regime = table.Column<int>(type: "int", nullable: false),
                    Valido = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RegistoUtilizador", x => x.RegistoID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RegistoUtilizador_RegistoID",
                table: "RegistoUtilizador",
                column: "RegistoID",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RegistoUtilizador");
        }
    }
}
