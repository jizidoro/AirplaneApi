using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.IO;

namespace AirplaneProject.Infrastructure.Migrations
{
    public partial class AS002_AddAlarmeCodigoEsd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AlarmeCodigo",
                table: "Esds",
                maxLength: 20,
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Esds_AlarmeCodigo",
                table: "Esds",
                column: "AlarmeCodigo");

			var sqlFile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Migrations", "20191208162138_AS002_AddAlarmeCodigoEsd_Up.sql");
			migrationBuilder.Sql(File.ReadAllText(sqlFile));
		}

        protected override void Down(MigrationBuilder migrationBuilder)
		{
			var sqlFile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Migrations", "20191208162138_AS002_AddAlarmeCodigoEsd_Down.sql");
			migrationBuilder.Sql(File.ReadAllText(sqlFile));

			migrationBuilder.DropIndex(
                name: "IX_Esds_AlarmeCodigo",
                table: "Esds");

            migrationBuilder.DropColumn(
                name: "AlarmeCodigo",
                table: "Esds");
        }
    }
}
