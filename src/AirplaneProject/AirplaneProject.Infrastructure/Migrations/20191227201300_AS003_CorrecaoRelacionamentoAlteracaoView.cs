using System;
using System.IO;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AirplaneProject.Infrastructure.Migrations
{
    public partial class AS003_CorrecaoRelacionamentoAlteracaoView : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var sqlFile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Migrations", "20191227201300_AS003_CorrecaoRelacionamentoAlteracaoView_Up.sql");
            migrationBuilder.Sql(File.ReadAllText(sqlFile));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            var sqlFile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Migrations", "20191227201300_AS003_CorrecaoRelacionamentoAlteracaoView_Down.sql");
            migrationBuilder.Sql(File.ReadAllText(sqlFile));

        }
    }
}
