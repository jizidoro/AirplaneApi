using Microsoft.EntityFrameworkCore.Migrations;

namespace AirplaneProject.Infrastructure.Migrations
{
    public partial class AS003_AddIndiceModuloAlteracao : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Situacoes_Codigo",
                table: "Situacoes",
                column: "Codigo");

            migrationBuilder.CreateIndex(
                name: "IX_Sistemas_Codigo",
                table: "Sistemas",
                column: "Codigo");

            migrationBuilder.CreateIndex(
                name: "IX_Funcoes_Codigo",
                table: "Funcoes",
                column: "Codigo");

            migrationBuilder.CreateIndex(
                name: "IX_Finalidades_Codigo",
                table: "Finalidades",
                column: "Codigo");

            migrationBuilder.CreateIndex(
                name: "IX_Camadas_Codigo",
                table: "Camadas",
                column: "Codigo");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Situacoes_Codigo",
                table: "Situacoes");

            migrationBuilder.DropIndex(
                name: "IX_Sistemas_Codigo",
                table: "Sistemas");

            migrationBuilder.DropIndex(
                name: "IX_Funcoes_Codigo",
                table: "Funcoes");

            migrationBuilder.DropIndex(
                name: "IX_Finalidades_Codigo",
                table: "Finalidades");

            migrationBuilder.DropIndex(
                name: "IX_Camadas_Codigo",
                table: "Camadas");
        }
    }
}
