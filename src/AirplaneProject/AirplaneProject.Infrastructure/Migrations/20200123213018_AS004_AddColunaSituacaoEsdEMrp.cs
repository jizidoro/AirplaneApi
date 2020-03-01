using System;
using System.IO;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AirplaneProject.Infrastructure.Migrations
{
    public partial class AS004_AddColunaSituacaoEsdEMrp : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Mrp",
                table: "MaterialEstocados");

            migrationBuilder.DropColumn(
                name: "Situacao",
                table: "MaterialEstocados");
            
            migrationBuilder.AddColumn<int>(
                name: "MrpId",
                table: "MaterialEstocados",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SituacaoMaterialId",
                table: "MaterialEstocados",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SituacaoId",
                table: "Esds",
                nullable: false,
                defaultValue: 1);

            migrationBuilder.CreateTable(
                name: "Mrps",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(maxLength: 50, nullable: false),
                    Codigo = table.Column<string>(maxLength: 50, nullable: false),
                    Descricao = table.Column<string>(maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mrps", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SituacaoMateriais",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(maxLength: 50, nullable: false),
                    Codigo = table.Column<string>(maxLength: 50, nullable: false),
                    Descricao = table.Column<string>(maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SituacaoMateriais", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MaterialEstocados_MrpId",
                table: "MaterialEstocados",
                column: "MrpId");

            migrationBuilder.CreateIndex(
                name: "IX_MaterialEstocados_SituacaoMaterialId",
                table: "MaterialEstocados",
                column: "SituacaoMaterialId");

            migrationBuilder.CreateIndex(
                name: "IX_Esds_SituacaoId",
                table: "Esds",
                column: "SituacaoId");

            migrationBuilder.CreateIndex(
                name: "IX_Mrps_Codigo",
                table: "Mrps",
                column: "Codigo");

            migrationBuilder.CreateIndex(
                name: "IX_Situacao_Materiais_Codigo",
                table: "SituacaoMateriais",
                column: "Codigo");

            migrationBuilder.AddForeignKey(
                name: "FK_Esds_Situacoes_SituacaoId",
                table: "Esds",
                column: "SituacaoId",
                principalTable: "Situacoes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_MaterialEstocados_Mrps_MrpId",
                table: "MaterialEstocados",
                column: "MrpId",
                principalTable: "Mrps",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_MaterialEstocados_SituacaoMateriais_SituacaoMaterialId",
                table: "MaterialEstocados",
                column: "SituacaoMaterialId",
                principalTable: "SituacaoMateriais",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Esds_Situacoes_SituacaoId",
                table: "Esds");

            migrationBuilder.DropForeignKey(
                name: "FK_MaterialEstocados_Mrps_MrpId",
                table: "MaterialEstocados");

            migrationBuilder.DropForeignKey(
                name: "FK_MaterialEstocados_SituacaoMateriais_SituacaoMaterialId",
                table: "MaterialEstocados");

            migrationBuilder.DropTable(
                name: "Mrps");

            migrationBuilder.DropTable(
                name: "SituacaoMateriais");

            migrationBuilder.DropIndex(
                name: "IX_MaterialEstocados_MrpId",
                table: "MaterialEstocados");

            migrationBuilder.DropIndex(
                name: "IX_MaterialEstocados_SituacaoMaterialId",
                table: "MaterialEstocados");

            migrationBuilder.DropIndex(
                name: "IX_Esds_SituacaoId",
                table: "Esds");
            
            migrationBuilder.DropColumn(
                name: "MrpId",
                table: "MaterialEstocados");

            migrationBuilder.DropColumn(
                name: "SituacaoMaterialId",
                table: "MaterialEstocados");

            migrationBuilder.DropColumn(
                name: "SituacaoId",
                table: "Esds");

            migrationBuilder.AddColumn<string>(
                name: "Mrp",
                table: "MaterialEstocados",
                maxLength: 20,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Situacao",
                table: "MaterialEstocados",
                maxLength: 20,
                nullable: false,
                defaultValue: "");

        }
    }
}
