using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.IO;

namespace AirplaneProject.Infrastructure.Migrations
{
    public partial class AS004_AlterarMrpMaterialEstocado : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "MrpId",
                table: "MaterialEstocados",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            var sqlFile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Migrations", "20200228183907_AS004_AlterarMrpMaterialEstocado_Up.sql");
            migrationBuilder.Sql(File.ReadAllText(sqlFile));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "MrpId",
                table: "MaterialEstocados",
                nullable: true,
                oldClrType: typeof(int));
        }
    }
}
