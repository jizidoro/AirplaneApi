using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.IO;

namespace AirplaneProject.Infrastructure.Migrations
{
    public partial class AS002_NovosCamposEsd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Alarme",
                table: "Historicos",
                maxLength: 20,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LinkCadinc",
                table: "Historicos",
                maxLength: 255,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LinkGip",
                table: "Historicos",
                maxLength: 255,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LinkRta",
                table: "Historicos",
                maxLength: 255,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LinkSitop",
                table: "Historicos",
                maxLength: 255,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Alarme",
                table: "Esds",
                maxLength: 20,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LinkCadinc",
                table: "Esds",
                maxLength: 255,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LinkGip",
                table: "Esds",
                maxLength: 255,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LinkRta",
                table: "Esds",
                maxLength: 255,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LinkSitop",
                table: "Esds",
                maxLength: 255,
                nullable: true);

            migrationBuilder.CreateTable(
                name: "EsdArquivos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    EsdId = table.Column<int>(nullable: false),
                    NomeArquivo = table.Column<string>(nullable: true),
                    Url = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EsdArquivos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EsdArquivos_Esds_EsdId",
                        column: x => x.EsdId,
                        principalTable: "Esds",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EsdArquivos_EsdId",
                table: "EsdArquivos",
                column: "EsdId");

			var sqlFile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Migrations", "20191129103839_AS002_NovosCamposEsd_Up.sql");
			migrationBuilder.Sql(File.ReadAllText(sqlFile));
		}

        protected override void Down(MigrationBuilder migrationBuilder)
        {
			var sqlFile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Migrations", "20191129103839_AS002_NovosCamposEsd_Down.sql");
			migrationBuilder.Sql(File.ReadAllText(sqlFile));

			migrationBuilder.DropTable(
                name: "EsdArquivos");

            migrationBuilder.DropColumn(
                name: "Alarme",
                table: "Historicos");

            migrationBuilder.DropColumn(
                name: "LinkCadinc",
                table: "Historicos");

            migrationBuilder.DropColumn(
                name: "LinkGip",
                table: "Historicos");

            migrationBuilder.DropColumn(
                name: "LinkRta",
                table: "Historicos");

            migrationBuilder.DropColumn(
                name: "LinkSitop",
                table: "Historicos");

            migrationBuilder.DropColumn(
                name: "Alarme",
                table: "Esds");

            migrationBuilder.DropColumn(
                name: "LinkCadinc",
                table: "Esds");

            migrationBuilder.DropColumn(
                name: "LinkGip",
                table: "Esds");

            migrationBuilder.DropColumn(
                name: "LinkRta",
                table: "Esds");

            migrationBuilder.DropColumn(
                name: "LinkSitop",
                table: "Esds");
        }
    }
}
