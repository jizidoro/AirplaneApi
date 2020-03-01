using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.IO;

namespace AirplaneProject.Infrastructure.Migrations
{
    public partial class AS004_AlterarSobressalenteView : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var sqlFile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Migrations", "20200226193534_AS004_AlterarSobressalenteView_Up.sql");
            migrationBuilder.Sql(File.ReadAllText(sqlFile));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            var sqlFile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Migrations", "20200226193534_AS004_AlterarSobressalenteView_Down.sql");
            migrationBuilder.Sql(File.ReadAllText(sqlFile));
        }
    }
}
