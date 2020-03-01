using Microsoft.EntityFrameworkCore.Migrations;

namespace AirplaneProject.Infrastructure.Migrations
{
    public partial class AS004_AddConfiguracaoRelacionamentoAlmoxarifado : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UepAlmoxarifado_Almoxarifados_AlmoxarifadoId",
                table: "UepAlmoxarifado");

            migrationBuilder.DropForeignKey(
                name: "FK_UepAlmoxarifado_Ueps_UepId",
                table: "UepAlmoxarifado");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UepAlmoxarifado",
                table: "UepAlmoxarifado");

            migrationBuilder.RenameTable(
                name: "UepAlmoxarifado",
                newName: "UepAlmoxarifados");

            migrationBuilder.RenameIndex(
                name: "IX_UepAlmoxarifado_UepId",
                table: "UepAlmoxarifados",
                newName: "IX_UepAlmoxarifados_UepId");

            migrationBuilder.RenameIndex(
                name: "IX_UepAlmoxarifado_AlmoxarifadoId",
                table: "UepAlmoxarifados",
                newName: "IX_UepAlmoxarifados_AlmoxarifadoId");

            migrationBuilder.AddColumn<int>(
                name: "UepAlmoxarifadoId",
                table: "Historicos",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UepAlmoxarifadoId",
                table: "Esds",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_UepAlmoxarifados",
                table: "UepAlmoxarifados",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Historicos_UepAlmoxarifadoId",
                table: "Historicos",
                column: "UepAlmoxarifadoId");

            migrationBuilder.CreateIndex(
                name: "IX_Esds_UepAlmoxarifadoId",
                table: "Esds",
                column: "UepAlmoxarifadoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Esds_UepAlmoxarifados_UepAlmoxarifadoId",
                table: "Esds",
                column: "UepAlmoxarifadoId",
                principalTable: "UepAlmoxarifados",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Historicos_UepAlmoxarifados_UepAlmoxarifadoId",
                table: "Historicos",
                column: "UepAlmoxarifadoId",
                principalTable: "UepAlmoxarifados",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UepAlmoxarifados_Almoxarifados_AlmoxarifadoId",
                table: "UepAlmoxarifados",
                column: "AlmoxarifadoId",
                principalTable: "Almoxarifados",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UepAlmoxarifados_Ueps_UepId",
                table: "UepAlmoxarifados",
                column: "UepId",
                principalTable: "Ueps",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Esds_UepAlmoxarifados_UepAlmoxarifadoId",
                table: "Esds");

            migrationBuilder.DropForeignKey(
                name: "FK_Historicos_UepAlmoxarifados_UepAlmoxarifadoId",
                table: "Historicos");

            migrationBuilder.DropForeignKey(
                name: "FK_UepAlmoxarifados_Almoxarifados_AlmoxarifadoId",
                table: "UepAlmoxarifados");

            migrationBuilder.DropForeignKey(
                name: "FK_UepAlmoxarifados_Ueps_UepId",
                table: "UepAlmoxarifados");

            migrationBuilder.DropIndex(
                name: "IX_Historicos_UepAlmoxarifadoId",
                table: "Historicos");

            migrationBuilder.DropIndex(
                name: "IX_Esds_UepAlmoxarifadoId",
                table: "Esds");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UepAlmoxarifados",
                table: "UepAlmoxarifados");

            migrationBuilder.DropColumn(
                name: "UepAlmoxarifadoId",
                table: "Historicos");

            migrationBuilder.DropColumn(
                name: "UepAlmoxarifadoId",
                table: "Esds");

            migrationBuilder.RenameTable(
                name: "UepAlmoxarifados",
                newName: "UepAlmoxarifado");

            migrationBuilder.RenameIndex(
                name: "IX_UepAlmoxarifados_UepId",
                table: "UepAlmoxarifado",
                newName: "IX_UepAlmoxarifado_UepId");

            migrationBuilder.RenameIndex(
                name: "IX_UepAlmoxarifados_AlmoxarifadoId",
                table: "UepAlmoxarifado",
                newName: "IX_UepAlmoxarifado_AlmoxarifadoId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UepAlmoxarifado",
                table: "UepAlmoxarifado",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UepAlmoxarifado_Almoxarifados_AlmoxarifadoId",
                table: "UepAlmoxarifado",
                column: "AlmoxarifadoId",
                principalTable: "Almoxarifados",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UepAlmoxarifado_Ueps_UepId",
                table: "UepAlmoxarifado",
                column: "UepId",
                principalTable: "Ueps",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
