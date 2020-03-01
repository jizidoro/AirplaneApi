using Microsoft.EntityFrameworkCore.Migrations;

namespace AirplaneProject.Infrastructure.Migrations
{
    public partial class AS004_AlterarSobressalente : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Mrps_RegraEstoques_RegraEstoqueId",
                table: "Mrps");

            migrationBuilder.DropForeignKey(
                name: "FK_RegraEstoques_Mrps_MrpId",
                table: "RegraEstoques");

            migrationBuilder.DropIndex(
                name: "IX_MaterialFornecidos_CodigoConsultaSap",
                table: "MaterialFornecidos");

            migrationBuilder.DropIndex(
                name: "IX_MaterialEstocados_Codigo",
                table: "MaterialEstocados");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RegraEstoques",
                table: "RegraEstoques");

            migrationBuilder.DropColumn(
                name: "Descricao",
                table: "MaterialFornecidos");

            migrationBuilder.DropColumn(
                name: "Nome",
                table: "MaterialFornecidos");

            migrationBuilder.DropColumn(
                name: "ChaveUsuario",
                table: "MaterialEstocados");

            migrationBuilder.DropColumn(
                name: "Codigo",
                table: "MaterialEstocados");

            migrationBuilder.DropColumn(
                name: "Descricao",
                table: "MaterialEstocados");

            migrationBuilder.DropColumn(
                name: "Nome",
                table: "MaterialEstocados");

            migrationBuilder.DropColumn(
                name: "NomeUsuario",
                table: "MaterialEstocados");

            migrationBuilder.RenameTable(
                name: "RegraEstoques",
                newName: "MrpRegraEstoques");

            migrationBuilder.RenameColumn(
                name: "RegraEstoqueId",
                table: "Mrps",
                newName: "MrpRegraEstoqueId");

            migrationBuilder.RenameIndex(
                name: "IX_Mrps_RegraEstoqueId",
                table: "Mrps",
                newName: "IX_Mrps_MrpRegraEstoqueId");

            migrationBuilder.RenameColumn(
                name: "CodigoConsultaSap",
                table: "MaterialFornecidos",
                newName: "NM");

            migrationBuilder.RenameIndex(
                name: "IX_RegraEstoques_MrpId",
                table: "MrpRegraEstoques",
                newName: "IX_MrpRegraEstoques_MrpId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MrpRegraEstoques",
                table: "MrpRegraEstoques",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MrpRegraEstoques_Mrps_MrpId",
                table: "MrpRegraEstoques",
                column: "MrpId",
                principalTable: "Mrps",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Mrps_MrpRegraEstoques_MrpRegraEstoqueId",
                table: "Mrps",
                column: "MrpRegraEstoqueId",
                principalTable: "MrpRegraEstoques",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MrpRegraEstoques_Mrps_MrpId",
                table: "MrpRegraEstoques");

            migrationBuilder.DropForeignKey(
                name: "FK_Mrps_MrpRegraEstoques_MrpRegraEstoqueId",
                table: "Mrps");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MrpRegraEstoques",
                table: "MrpRegraEstoques");

            migrationBuilder.RenameTable(
                name: "MrpRegraEstoques",
                newName: "RegraEstoques");

            migrationBuilder.RenameColumn(
                name: "MrpRegraEstoqueId",
                table: "Mrps",
                newName: "RegraEstoqueId");

            migrationBuilder.RenameIndex(
                name: "IX_Mrps_MrpRegraEstoqueId",
                table: "Mrps",
                newName: "IX_Mrps_RegraEstoqueId");

            migrationBuilder.RenameColumn(
                name: "NM",
                table: "MaterialFornecidos",
                newName: "CodigoConsultaSap");

            migrationBuilder.RenameIndex(
                name: "IX_MrpRegraEstoques_MrpId",
                table: "RegraEstoques",
                newName: "IX_RegraEstoques_MrpId");

            migrationBuilder.AddColumn<string>(
                name: "Descricao",
                table: "MaterialFornecidos",
                maxLength: 255,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Nome",
                table: "MaterialFornecidos",
                maxLength: 120,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ChaveUsuario",
                table: "MaterialEstocados",
                maxLength: 12,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Codigo",
                table: "MaterialEstocados",
                maxLength: 120,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Descricao",
                table: "MaterialEstocados",
                maxLength: 255,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Nome",
                table: "MaterialEstocados",
                maxLength: 120,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "NomeUsuario",
                table: "MaterialEstocados",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RegraEstoques",
                table: "RegraEstoques",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_MaterialFornecidos_CodigoConsultaSap",
                table: "MaterialFornecidos",
                column: "CodigoConsultaSap",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_MaterialEstocados_Codigo",
                table: "MaterialEstocados",
                column: "Codigo",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Mrps_RegraEstoques_RegraEstoqueId",
                table: "Mrps",
                column: "RegraEstoqueId",
                principalTable: "RegraEstoques",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_RegraEstoques_Mrps_MrpId",
                table: "RegraEstoques",
                column: "MrpId",
                principalTable: "Mrps",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
