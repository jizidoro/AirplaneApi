using Microsoft.EntityFrameworkCore.Migrations;

namespace AirplaneProject.Infrastructure.Migrations
{
    public partial class AS004_AlterarMrpEMaterialFornecido : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Descricao",
                table: "Mrps",
                newName: "Campo");

            migrationBuilder.AddColumn<string>(
                name: "Operador",
                table: "Mrps",
                maxLength: 30,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CodigoConsultaSap",
                table: "MaterialFornecidos",
                maxLength: 255,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Modelo",
                table: "MaterialFornecidos",
                maxLength: 255,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Operador",
                table: "Mrps");

            migrationBuilder.DropColumn(
                name: "CodigoConsultaSap",
                table: "MaterialFornecidos");

            migrationBuilder.DropColumn(
                name: "Modelo",
                table: "MaterialFornecidos");

            migrationBuilder.RenameColumn(
                name: "Campo",
                table: "Mrps",
                newName: "Descricao");
        }
    }
}
