using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FreqPratica1.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Contacto",
                columns: table => new
                {
                    Email = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    NickName = table.Column<string>(type: "nvarchar(4)", maxLength: 4, nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Amigo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contacto", x => x.Email);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Contacto_Email",
                table: "Contacto",
                column: "Email",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Contacto");
        }
    }
}
