using Microsoft.EntityFrameworkCore.Migrations;

namespace AirplaneProject.Infrastructure.Migrations
{
    public partial class AS004_AddRelacionamentoMaterialEstocado : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MaterialEstocados_Almoxarifados_AlmoxarifadoId",
                table: "MaterialEstocados");

            migrationBuilder.DropForeignKey(
                name: "FK_MaterialEstocados_MaterialFornecidos_MaterialFornecidoId",
                table: "MaterialEstocados");

            migrationBuilder.AddForeignKey(
                name: "FK_MaterialEstocados_Almoxarifados_AlmoxarifadoId",
                table: "MaterialEstocados",
                column: "AlmoxarifadoId",
                principalTable: "Almoxarifados",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_MaterialEstocados_MaterialFornecidos_MaterialFornecidoId",
                table: "MaterialEstocados",
                column: "MaterialFornecidoId",
                principalTable: "MaterialFornecidos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MaterialEstocados_Almoxarifados_AlmoxarifadoId",
                table: "MaterialEstocados");

            migrationBuilder.DropForeignKey(
                name: "FK_MaterialEstocados_MaterialFornecidos_MaterialFornecidoId",
                table: "MaterialEstocados");

            migrationBuilder.AddForeignKey(
                name: "FK_MaterialEstocados_Almoxarifados_AlmoxarifadoId",
                table: "MaterialEstocados",
                column: "AlmoxarifadoId",
                principalTable: "Almoxarifados",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MaterialEstocados_MaterialFornecidos_MaterialFornecidoId",
                table: "MaterialEstocados",
                column: "MaterialFornecidoId",
                principalTable: "MaterialFornecidos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
