using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace REC_24.Data.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RegistoNota",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NumAluno = table.Column<int>(type: "int", nullable: false),
                    Nota = table.Column<int>(type: "int", nullable: false),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RegistoNota", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RegistoNota_Id",
                table: "RegistoNota",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_RegistoNota_NumAluno",
                table: "RegistoNota",
                column: "NumAluno",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RegistoNota");
        }
    }
}
