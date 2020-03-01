using Microsoft.EntityFrameworkCore.Migrations;

namespace AirplaneProject.Infrastructure.Migrations
{
    public partial class AS004_AddColunaSituacaoMaterial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Cor",
                table: "SituacaoMateriais",
                maxLength: 50,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Cor",
                table: "SituacaoMateriais");

        }
    }
}
