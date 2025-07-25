﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NOR_24.Migrations
{
    /// <inheritdoc />
    public partial class init2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_RegistoUtilizador_RegistoId",
                table: "RegistoUtilizador",
                column: "RegistoId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_RegistoUtilizador_RegistoId",
                table: "RegistoUtilizador");
        }
    }
}
