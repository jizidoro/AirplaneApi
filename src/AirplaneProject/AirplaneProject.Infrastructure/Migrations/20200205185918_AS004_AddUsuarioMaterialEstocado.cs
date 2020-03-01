using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AirplaneProject.Infrastructure.Migrations
{
    public partial class AS004_AddUsuarioMaterialEstocado : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "MrpId",
                table: "MaterialEstocados",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<string>(
                name: "ChaveUsuario",
                table: "MaterialEstocados",
                maxLength: 12,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "DataRegistro",
                table: "MaterialEstocados",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "NomeUsuario",
                table: "MaterialEstocados",
                maxLength: 100,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ChaveUsuario",
                table: "MaterialEstocados");

            migrationBuilder.DropColumn(
                name: "DataRegistro",
                table: "MaterialEstocados");

            migrationBuilder.DropColumn(
                name: "NomeUsuario",
                table: "MaterialEstocados");

            migrationBuilder.AlterColumn<int>(
                name: "MrpId",
                table: "MaterialEstocados",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);
        }
    }
}
