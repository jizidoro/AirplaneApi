using Microsoft.EntityFrameworkCore.Migrations;

namespace AirplaneProject.Infrastructure.Migrations
{
    public partial class AS004_AlterarMaterialEstocado : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Reabastecimento",
                table: "MaterialEstocados");

            migrationBuilder.RenameIndex(
                name: "IX_Situacao_Materiais_Codigo",
                table: "SituacaoMateriais",
                newName: "IX_SituacaoMateriais_Codigo");

            migrationBuilder.RenameColumn(
                name: "Estoque",
                table: "MaterialEstocados",
                newName: "QuantidadeEstoque");

            migrationBuilder.AddColumn<double>(
                name: "Minimo",
                table: "MaterialEstocados",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AlterColumn<string>(
                name: "Url",
                table: "EsdArquivos",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Profissionais_Chave",
                table: "Profissionais",
                column: "Chave");

            migrationBuilder.CreateIndex(
                name: "IX_MaterialFornecidos_CodigoConsultaSap",
                table: "MaterialFornecidos",
                column: "CodigoConsultaSap",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_EsdArquivos_Url",
                table: "EsdArquivos",
                column: "Url");

            migrationBuilder.CreateIndex(
                name: "IX_Almoxarifados_CodigoSAP",
                table: "Almoxarifados",
                column: "CodigoSAP",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Profissionais_Chave",
                table: "Profissionais");

            migrationBuilder.DropIndex(
                name: "IX_MaterialFornecidos_CodigoConsultaSap",
                table: "MaterialFornecidos");

            migrationBuilder.DropIndex(
                name: "IX_EsdArquivos_Url",
                table: "EsdArquivos");

            migrationBuilder.DropIndex(
                name: "IX_Almoxarifados_CodigoSAP",
                table: "Almoxarifados");

            migrationBuilder.DropColumn(
                name: "Minimo",
                table: "MaterialEstocados");

            migrationBuilder.RenameIndex(
                name: "IX_SituacaoMateriais_Codigo",
                table: "SituacaoMateriais",
                newName: "IX_Situacao_Materiais_Codigo");

            migrationBuilder.RenameColumn(
                name: "QuantidadeEstoque",
                table: "MaterialEstocados",
                newName: "Estoque");

            migrationBuilder.AddColumn<string>(
                name: "Reabastecimento",
                table: "MaterialEstocados",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "Url",
                table: "EsdArquivos",
                nullable: true,
                oldClrType: typeof(string));
        }
    }
}
