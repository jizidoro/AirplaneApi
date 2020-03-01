using Microsoft.EntityFrameworkCore.Migrations;

namespace AirplaneProject.Infrastructure.Migrations
{
    public partial class AS004_AddSituacaoHistoricoEsd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {            
            migrationBuilder.AddColumn<int>(
                name: "SituacaoId",
                table: "Historicos",
                nullable: false,
                defaultValue: 1);

            migrationBuilder.CreateIndex(
                name: "IX_Historicos_SituacaoId",
                table: "Historicos",
                column: "SituacaoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Historicos_Situacoes_SituacaoId",
                table: "Historicos",
                column: "SituacaoId",
                principalTable: "Situacoes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Historicos_Situacoes_SituacaoId",
                table: "Historicos");

            migrationBuilder.DropIndex(
                name: "IX_Historicos_SituacaoId",
                table: "Historicos");

            migrationBuilder.DropColumn(
                name: "SituacaoId",
                table: "Historicos");
        }
    }
}
