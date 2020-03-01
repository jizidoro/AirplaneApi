using Microsoft.EntityFrameworkCore.Migrations;

namespace AirplaneProject.Infrastructure.Migrations
{
    public partial class AS003_CorrecaoHistoricoAlteracao : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HistoricoAlteracoes_Alteracoes_AlteracaoId1",
                table: "HistoricoAlteracoes");

            migrationBuilder.DropIndex(
                name: "IX_HistoricoAlteracoes_AlteracaoId1",
                table: "HistoricoAlteracoes");

            migrationBuilder.DropColumn(
                name: "AlteracaoId1",
                table: "HistoricoAlteracoes");

            migrationBuilder.AlterColumn<int>(
                name: "ExecutorId",
                table: "HistoricoAlteracoes",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ExecutorId",
                table: "Alteracoes",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "ExecutorId",
                table: "HistoricoAlteracoes",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "AlteracaoId1",
                table: "HistoricoAlteracoes",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ExecutorId",
                table: "Alteracoes",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.CreateIndex(
                name: "IX_HistoricoAlteracoes_AlteracaoId1",
                table: "HistoricoAlteracoes",
                column: "AlteracaoId1");

            migrationBuilder.AddForeignKey(
                name: "FK_HistoricoAlteracoes_Alteracoes_AlteracaoId1",
                table: "HistoricoAlteracoes",
                column: "AlteracaoId1",
                principalTable: "Alteracoes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
