using Microsoft.EntityFrameworkCore.Migrations;

namespace AirplaneProject.Infrastructure.Migrations
{
    public partial class AS003_AddOrigemAgenteConfiguration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrigemAgentes_Agentes_AgenteId",
                table: "OrigemAgentes");

            migrationBuilder.DropForeignKey(
                name: "FK_OrigemAgentes_Origens_OrigemId",
                table: "OrigemAgentes");

            migrationBuilder.AddForeignKey(
                name: "FK_OrigemAgentes_Agentes_AgenteId",
                table: "OrigemAgentes",
                column: "AgenteId",
                principalTable: "Agentes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_OrigemAgentes_Origens_OrigemId",
                table: "OrigemAgentes",
                column: "OrigemId",
                principalTable: "Origens",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrigemAgentes_Agentes_AgenteId",
                table: "OrigemAgentes");

            migrationBuilder.DropForeignKey(
                name: "FK_OrigemAgentes_Origens_OrigemId",
                table: "OrigemAgentes");

            migrationBuilder.AddForeignKey(
                name: "FK_OrigemAgentes_Agentes_AgenteId",
                table: "OrigemAgentes",
                column: "AgenteId",
                principalTable: "Agentes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrigemAgentes_Origens_OrigemId",
                table: "OrigemAgentes",
                column: "OrigemId",
                principalTable: "Origens",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
