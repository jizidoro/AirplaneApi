using System;
using System.IO;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AirplaneProject.Infrastructure.Migrations
{
    public partial class AS003_AddColunasAlteracaoView : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
	        var sqlFile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Migrations", "20200122172605_AS003_AddColunasAlteracaoView_Up.sql");
	        migrationBuilder.Sql(File.ReadAllText(sqlFile));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
	        var sqlFile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Migrations", "20200122172605_AS003_AddColunasAlteracaoView_Down.sql");
	        migrationBuilder.Sql(File.ReadAllText(sqlFile));
        }
    }
}
