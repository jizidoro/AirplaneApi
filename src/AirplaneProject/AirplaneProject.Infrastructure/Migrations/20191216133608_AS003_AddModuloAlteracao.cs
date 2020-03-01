using System;
using System.IO;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AirplaneProject.Infrastructure.Migrations
{
    public partial class AS003_AddModuloAlteracao : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Camadas",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Codigo = table.Column<string>(maxLength: 50, nullable: false),
                    Nome = table.Column<string>(maxLength: 50, nullable: false),
                    Descricao = table.Column<string>(maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Camadas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Finalidades",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Codigo = table.Column<string>(maxLength: 50, nullable: false),
                    Nome = table.Column<string>(maxLength: 50, nullable: false),
                    Descricao = table.Column<string>(maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Finalidades", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Funcoes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Codigo = table.Column<string>(maxLength: 50, nullable: false),
                    Nome = table.Column<string>(maxLength: 50, nullable: false),
                    Descricao = table.Column<string>(maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Funcoes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Profissionais",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Chave = table.Column<string>(maxLength: 12, nullable: false),
                    Nome = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Profissionais", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Sistemas",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Codigo = table.Column<string>(maxLength: 50, nullable: false),
                    Nome = table.Column<string>(maxLength: 50, nullable: false),
                    Descricao = table.Column<string>(maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sistemas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Situacoes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Codigo = table.Column<string>(maxLength: 50, nullable: false),
                    Nome = table.Column<string>(maxLength: 50, nullable: false),
                    Descricao = table.Column<string>(maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Situacoes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Alteracoes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UepId = table.Column<int>(nullable: false),
                    FinalidadeId = table.Column<int>(nullable: false),
                    CamadaId = table.Column<int>(nullable: false),
                    FuncaoId = table.Column<int>(nullable: false),
                    SistemaId = table.Column<int>(nullable: false),
                    SituacaoId = table.Column<int>(nullable: false),
                    SolicitanteId = table.Column<int>(nullable: false),
                    ExecutorId = table.Column<int>(nullable: true),
                    AprovadorId = table.Column<int>(nullable: true),
                    AutorizadorId = table.Column<int>(nullable: true),
                    VerificadorId = table.Column<int>(nullable: true),
                    Checksum = table.Column<string>(maxLength: 255, nullable: true),
                    DataEvento = table.Column<DateTime>(nullable: false),
                    DataRegistro = table.Column<DateTime>(nullable: false),
                    Descricao = table.Column<string>(maxLength: 255, nullable: true),
                    DescricaoCodigo = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Alteracoes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Alteracoes_Profissionais_AprovadorId",
                        column: x => x.AprovadorId,
                        principalTable: "Profissionais",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Alteracoes_Profissionais_AutorizadorId",
                        column: x => x.AutorizadorId,
                        principalTable: "Profissionais",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Alteracoes_Camadas_CamadaId",
                        column: x => x.CamadaId,
                        principalTable: "Camadas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Alteracoes_Profissionais_ExecutorId",
                        column: x => x.ExecutorId,
                        principalTable: "Profissionais",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Alteracoes_Finalidades_FinalidadeId",
                        column: x => x.FinalidadeId,
                        principalTable: "Finalidades",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Alteracoes_Funcoes_FuncaoId",
                        column: x => x.FuncaoId,
                        principalTable: "Funcoes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Alteracoes_Sistemas_SistemaId",
                        column: x => x.SistemaId,
                        principalTable: "Sistemas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Alteracoes_Situacoes_SituacaoId",
                        column: x => x.SituacaoId,
                        principalTable: "Situacoes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Alteracoes_Profissionais_SolicitanteId",
                        column: x => x.SolicitanteId,
                        principalTable: "Profissionais",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Alteracoes_Ueps_UepId",
                        column: x => x.UepId,
                        principalTable: "Ueps",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Alteracoes_Profissionais_VerificadorId",
                        column: x => x.VerificadorId,
                        principalTable: "Profissionais",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "HistoricoAlteracoes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AlteracaoId = table.Column<int>(nullable: false),
                    Descricao = table.Column<string>(maxLength: 255, nullable: true),
                    Checksum = table.Column<string>(maxLength: 255, nullable: true),
                    DataEvento = table.Column<DateTime>(nullable: false),
                    UepId = table.Column<int>(nullable: false),
                    FinalidadeId = table.Column<int>(nullable: false),
                    CamadaId = table.Column<int>(nullable: false),
                    FuncaoId = table.Column<int>(nullable: false),
                    SistemaId = table.Column<int>(nullable: false),
                    SituacaoId = table.Column<int>(nullable: false),
                    SolicitanteId = table.Column<int>(nullable: false),
                    ExecutorId = table.Column<int>(nullable: true),
                    AprovadorId = table.Column<int>(nullable: true),
                    AutorizadorId = table.Column<int>(nullable: true),
                    VerificadorId = table.Column<int>(nullable: true),
                    ChaveUsuario = table.Column<string>(maxLength: 12, nullable: false),
                    NomeUsuario = table.Column<string>(maxLength: 100, nullable: false),
                    DataRegistro = table.Column<DateTime>(nullable: false),
                    DataAlteracao = table.Column<DateTime>(nullable: false),
                    AlteracaoId1 = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HistoricoAlteracoes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HistoricoAlteracoes_Alteracoes_AlteracaoId",
                        column: x => x.AlteracaoId,
                        principalTable: "Alteracoes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HistoricoAlteracoes_Alteracoes_AlteracaoId1",
                        column: x => x.AlteracaoId1,
                        principalTable: "Alteracoes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HistoricoAlteracoes_Profissionais_AprovadorId",
                        column: x => x.AprovadorId,
                        principalTable: "Profissionais",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HistoricoAlteracoes_Profissionais_AutorizadorId",
                        column: x => x.AutorizadorId,
                        principalTable: "Profissionais",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HistoricoAlteracoes_Camadas_CamadaId",
                        column: x => x.CamadaId,
                        principalTable: "Camadas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HistoricoAlteracoes_Profissionais_ExecutorId",
                        column: x => x.ExecutorId,
                        principalTable: "Profissionais",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HistoricoAlteracoes_Finalidades_FinalidadeId",
                        column: x => x.FinalidadeId,
                        principalTable: "Finalidades",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HistoricoAlteracoes_Funcoes_FuncaoId",
                        column: x => x.FuncaoId,
                        principalTable: "Funcoes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HistoricoAlteracoes_Sistemas_SistemaId",
                        column: x => x.SistemaId,
                        principalTable: "Sistemas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HistoricoAlteracoes_Situacoes_SituacaoId",
                        column: x => x.SituacaoId,
                        principalTable: "Situacoes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HistoricoAlteracoes_Profissionais_SolicitanteId",
                        column: x => x.SolicitanteId,
                        principalTable: "Profissionais",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HistoricoAlteracoes_Ueps_UepId",
                        column: x => x.UepId,
                        principalTable: "Ueps",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HistoricoAlteracoes_Profissionais_VerificadorId",
                        column: x => x.VerificadorId,
                        principalTable: "Profissionais",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Alteracoes_AprovadorId",
                table: "Alteracoes",
                column: "AprovadorId");

            migrationBuilder.CreateIndex(
                name: "IX_Alteracoes_AutorizadorId",
                table: "Alteracoes",
                column: "AutorizadorId");

            migrationBuilder.CreateIndex(
                name: "IX_Alteracoes_CamadaId",
                table: "Alteracoes",
                column: "CamadaId");

            migrationBuilder.CreateIndex(
                name: "IX_Alteracoes_ExecutorId",
                table: "Alteracoes",
                column: "ExecutorId");

            migrationBuilder.CreateIndex(
                name: "IX_Alteracoes_FinalidadeId",
                table: "Alteracoes",
                column: "FinalidadeId");

            migrationBuilder.CreateIndex(
                name: "IX_Alteracoes_FuncaoId",
                table: "Alteracoes",
                column: "FuncaoId");

            migrationBuilder.CreateIndex(
                name: "IX_Alteracoes_SistemaId",
                table: "Alteracoes",
                column: "SistemaId");

            migrationBuilder.CreateIndex(
                name: "IX_Alteracoes_SituacaoId",
                table: "Alteracoes",
                column: "SituacaoId");

            migrationBuilder.CreateIndex(
                name: "IX_Alteracoes_SolicitanteId",
                table: "Alteracoes",
                column: "SolicitanteId");

            migrationBuilder.CreateIndex(
                name: "IX_Alteracoes_UepId",
                table: "Alteracoes",
                column: "UepId");

            migrationBuilder.CreateIndex(
                name: "IX_Alteracoes_VerificadorId",
                table: "Alteracoes",
                column: "VerificadorId");

            migrationBuilder.CreateIndex(
                name: "IX_HistoricoAlteracoes_AlteracaoId",
                table: "HistoricoAlteracoes",
                column: "AlteracaoId");

            migrationBuilder.CreateIndex(
                name: "IX_HistoricoAlteracoes_AlteracaoId1",
                table: "HistoricoAlteracoes",
                column: "AlteracaoId1");

            migrationBuilder.CreateIndex(
                name: "IX_HistoricoAlteracoes_AprovadorId",
                table: "HistoricoAlteracoes",
                column: "AprovadorId");

            migrationBuilder.CreateIndex(
                name: "IX_HistoricoAlteracoes_AutorizadorId",
                table: "HistoricoAlteracoes",
                column: "AutorizadorId");

            migrationBuilder.CreateIndex(
                name: "IX_HistoricoAlteracoes_CamadaId",
                table: "HistoricoAlteracoes",
                column: "CamadaId");

            migrationBuilder.CreateIndex(
                name: "IX_HistoricoAlteracoes_ExecutorId",
                table: "HistoricoAlteracoes",
                column: "ExecutorId");

            migrationBuilder.CreateIndex(
                name: "IX_HistoricoAlteracoes_FinalidadeId",
                table: "HistoricoAlteracoes",
                column: "FinalidadeId");

            migrationBuilder.CreateIndex(
                name: "IX_HistoricoAlteracoes_FuncaoId",
                table: "HistoricoAlteracoes",
                column: "FuncaoId");

            migrationBuilder.CreateIndex(
                name: "IX_HistoricoAlteracoes_SistemaId",
                table: "HistoricoAlteracoes",
                column: "SistemaId");

            migrationBuilder.CreateIndex(
                name: "IX_HistoricoAlteracoes_SituacaoId",
                table: "HistoricoAlteracoes",
                column: "SituacaoId");

            migrationBuilder.CreateIndex(
                name: "IX_HistoricoAlteracoes_SolicitanteId",
                table: "HistoricoAlteracoes",
                column: "SolicitanteId");

            migrationBuilder.CreateIndex(
                name: "IX_HistoricoAlteracoes_UepId",
                table: "HistoricoAlteracoes",
                column: "UepId");

            migrationBuilder.CreateIndex(
                name: "IX_HistoricoAlteracoes_VerificadorId",
                table: "HistoricoAlteracoes",
                column: "VerificadorId");

            var sqlFile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Migrations", "20191216133608_AS003_AddModuloAlteracao_Up.sql");
            migrationBuilder.Sql(File.ReadAllText(sqlFile));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HistoricoAlteracoes");

            migrationBuilder.DropTable(
                name: "Alteracoes");

            migrationBuilder.DropTable(
                name: "Profissionais");

            migrationBuilder.DropTable(
                name: "Camadas");

            migrationBuilder.DropTable(
                name: "Finalidades");

            migrationBuilder.DropTable(
                name: "Funcoes");

            migrationBuilder.DropTable(
                name: "Sistemas");

            migrationBuilder.DropTable(
                name: "Situacoes");
        }
    }
}
