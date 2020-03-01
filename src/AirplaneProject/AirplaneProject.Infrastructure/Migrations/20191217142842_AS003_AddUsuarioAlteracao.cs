using System;
using System.IO;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AirplaneProject.Infrastructure.Migrations
{
    public partial class AS003_AddUsuarioAlteracao : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ChaveUsuario",
                table: "Alteracoes",
                maxLength: 12,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "NomeUsuario",
                table: "Alteracoes",
                maxLength: 100,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ChaveUsuario",
                table: "Alteracoes");

            migrationBuilder.DropColumn(
                name: "NomeUsuario",
                table: "Alteracoes");

        }
    }
}
