using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.IO;

namespace AirplaneProject.Infrastructure.Migrations
{
    public partial class AS004_AlterarAlmoxarifado : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Almoxarifados_CodigoSAP",
                table: "Almoxarifados");

            migrationBuilder.RenameColumn(
                name: "CodigoSAP",
                table: "Almoxarifados",
                newName: "CodigoCentroMrp");

            migrationBuilder.AddColumn<string>(
                name: "CodigoAreaMrp",
                table: "Almoxarifados",
                maxLength: 50,
                nullable: false,
                defaultValue: "");



        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CodigoAreaMrp",
                table: "Almoxarifados");

            migrationBuilder.RenameColumn(
                name: "CodigoCentroMrp",
                table: "Almoxarifados",
                newName: "CodigoSAP");

            migrationBuilder.CreateIndex(
                name: "IX_Almoxarifados_CodigoSAP",
                table: "Almoxarifados",
                column: "CodigoSAP",
                unique: true);


        }
    }
}
