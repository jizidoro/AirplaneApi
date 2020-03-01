using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AirplaneProject.Infrastructure.Migrations
{
    public partial class AS004_AddRegrasEstoque : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Operador",
                table: "Mrps");

            migrationBuilder.RenameColumn(
                name: "Campo",
                table: "Mrps",
                newName: "Descricao");

            migrationBuilder.AddColumn<int>(
                name: "RegraEstoqueId",
                table: "Mrps",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "RegraEstoques",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Campo = table.Column<string>(maxLength: 255, nullable: false),
                    Operador = table.Column<int>(nullable: false),
                    MrpId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RegraEstoques", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RegraEstoques_Mrps_MrpId",
                        column: x => x.MrpId,
                        principalTable: "Mrps",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Mrps_RegraEstoqueId",
                table: "Mrps",
                column: "RegraEstoqueId");

            migrationBuilder.CreateIndex(
                name: "IX_RegraEstoques_MrpId",
                table: "RegraEstoques",
                column: "MrpId");

            migrationBuilder.AddForeignKey(
                name: "FK_Mrps_RegraEstoques_RegraEstoqueId",
                table: "Mrps",
                column: "RegraEstoqueId",
                principalTable: "RegraEstoques",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Mrps_RegraEstoques_RegraEstoqueId",
                table: "Mrps");

            migrationBuilder.DropTable(
                name: "RegraEstoques");

            migrationBuilder.DropIndex(
                name: "IX_Mrps_RegraEstoqueId",
                table: "Mrps");

            migrationBuilder.DropColumn(
                name: "RegraEstoqueId",
                table: "Mrps");

            migrationBuilder.RenameColumn(
                name: "Descricao",
                table: "Mrps",
                newName: "Campo");

            migrationBuilder.AddColumn<string>(
                name: "Operador",
                table: "Mrps",
                maxLength: 30,
                nullable: true);
        }
    }
}
