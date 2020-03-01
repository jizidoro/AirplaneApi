using System;
using System.IO;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AirplaneProject.Infrastructure.Migrations
{
    public partial class AS004_AddSituacaoVwEsd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
	        var sqlFile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Migrations", "20200123223822_AS004_AddSituacaoVwEsd_Up.sql");
	        migrationBuilder.Sql(File.ReadAllText(sqlFile));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
	        var sqlFile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Migrations", "20200123223822_AS004_AddSituacaoVwEsd_Down.sql");
	        migrationBuilder.Sql(File.ReadAllText(sqlFile));
        }
    }
}
