using System;
using System.IO;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AirplaneProject.Infrastructure.Migrations
{
    public partial class AS003_AddConclusaoAlteracaoView : Migration
    {
	    protected override void Up(MigrationBuilder migrationBuilder)
	    {
		    var sqlFile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Migrations", "20200110203939_AS003_AddConclusaoAlteracaoView_Up.sql");
		    migrationBuilder.Sql(File.ReadAllText(sqlFile));
	    }

	    protected override void Down(MigrationBuilder migrationBuilder)
	    {
		    var sqlFile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Migrations", "20200110203939_AS003_AddConclusaoAlteracaoView_Down.sql");
		    migrationBuilder.Sql(File.ReadAllText(sqlFile));

	    }
    }
}
