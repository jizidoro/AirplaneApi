using System;
using System.IO;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AirplaneProject.Infrastructure.Migrations
{
    public partial class Inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AnpNiveis",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(maxLength: 50, nullable: false),
                    Codigo = table.Column<string>(maxLength: 50, nullable: false),
                    Descricao = table.Column<string>(maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnpNiveis", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Causas",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(maxLength: 50, nullable: false),
                    Codigo = table.Column<string>(maxLength: 50, nullable: false),
                    Descricao = table.Column<string>(maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Causas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Iniciadores",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(maxLength: 50, nullable: false),
                    Codigo = table.Column<string>(maxLength: 50, nullable: false),
                    Descricao = table.Column<string>(maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Iniciadores", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Motivos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(maxLength: 50, nullable: false),
                    Codigo = table.Column<string>(maxLength: 50, nullable: false),
                    Descricao = table.Column<string>(maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Motivos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Origens",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(maxLength: 50, nullable: false),
                    Codigo = table.Column<string>(maxLength: 50, nullable: false),
                    Descricao = table.Column<string>(maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Origens", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UepTipos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(maxLength: 50, nullable: false),
                    Codigo = table.Column<string>(maxLength: 50, nullable: false),
                    Descricao = table.Column<string>(maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UepTipos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UnidadesOperativas",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(maxLength: 20, nullable: false),
                    Codigo = table.Column<string>(maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UnidadesOperativas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Niveis",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(maxLength: 20, nullable: false),
                    Codigo = table.Column<string>(maxLength: 20, nullable: false),
                    Descricao = table.Column<string>(maxLength: 255, nullable: true),
                    AnpNivelId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Niveis", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Niveis_AnpNiveis_AnpNivelId",
                        column: x => x.AnpNivelId,
                        principalTable: "AnpNiveis",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MotivoCausas",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    MotivoId = table.Column<int>(nullable: false),
                    CausaId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MotivoCausas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MotivoCausas_Causas_CausaId",
                        column: x => x.CausaId,
                        principalTable: "Causas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MotivoCausas_Motivos_MotivoId",
                        column: x => x.MotivoId,
                        principalTable: "Motivos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Agentes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    OrigemId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Agentes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Agentes_Origens_OrigemId",
                        column: x => x.OrigemId,
                        principalTable: "Origens",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Ativos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UnidadeOperativaId = table.Column<int>(nullable: false),
                    Nome = table.Column<string>(maxLength: 20, nullable: false),
                    Codigo = table.Column<string>(maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ativos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ativos_UnidadesOperativas_UnidadeOperativaId",
                        column: x => x.UnidadeOperativaId,
                        principalTable: "UnidadesOperativas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Ambientais",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(maxLength: 50, nullable: false),
                    Codigo = table.Column<string>(maxLength: 50, nullable: false),
                    Descricao = table.Column<string>(maxLength: 255, nullable: true),
                    AgenteId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ambientais", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ambientais_Agentes_AgenteId",
                        column: x => x.AgenteId,
                        principalTable: "Agentes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Equipamentos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(maxLength: 50, nullable: false),
                    Codigo = table.Column<string>(maxLength: 50, nullable: false),
                    Descricao = table.Column<string>(maxLength: 255, nullable: true),
                    AgenteId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Equipamentos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Equipamentos_Agentes_AgenteId",
                        column: x => x.AgenteId,
                        principalTable: "Agentes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Humanas",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(maxLength: 50, nullable: false),
                    Codigo = table.Column<string>(maxLength: 50, nullable: false),
                    Descricao = table.Column<string>(maxLength: 255, nullable: true),
                    AgenteId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Humanas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Humanas_Agentes_AgenteId",
                        column: x => x.AgenteId,
                        principalTable: "Agentes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Processos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(maxLength: 50, nullable: false),
                    Codigo = table.Column<string>(maxLength: 50, nullable: false),
                    Descricao = table.Column<string>(maxLength: 255, nullable: true),
                    AgenteId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Processos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Processos_Agentes_AgenteId",
                        column: x => x.AgenteId,
                        principalTable: "Agentes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Ueps",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(maxLength: 50, nullable: false),
                    Codigo = table.Column<string>(maxLength: 50, nullable: false),
                    Descricao = table.Column<string>(maxLength: 255, nullable: false),
                    AtivoId = table.Column<int>(nullable: false),
                    UepTipoId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ueps", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ueps_Ativos_AtivoId",
                        column: x => x.AtivoId,
                        principalTable: "Ativos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Ueps_UepTipos_UepTipoId",
                        column: x => x.UepTipoId,
                        principalTable: "UepTipos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "IniciadorUeps",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UepId = table.Column<int>(nullable: false),
                    IniciadorId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IniciadorUeps", x => x.Id);
                    table.ForeignKey(
                        name: "FK_IniciadorUeps_Iniciadores_IniciadorId",
                        column: x => x.IniciadorId,
                        principalTable: "Iniciadores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_IniciadorUeps_Ueps_UepId",
                        column: x => x.UepId,
                        principalTable: "Ueps",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "NivelUeps",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UepId = table.Column<int>(nullable: false),
                    NivelId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NivelUeps", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NivelUeps_Niveis_NivelId",
                        column: x => x.NivelId,
                        principalTable: "Niveis",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_NivelUeps_Ueps_UepId",
                        column: x => x.UepId,
                        principalTable: "Ueps",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "EquipamentoIniciadorUeps",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    EquipamentoId = table.Column<int>(nullable: false),
                    IniciadorUepId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EquipamentoIniciadorUeps", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EquipamentoIniciadorUeps_Equipamentos_EquipamentoId",
                        column: x => x.EquipamentoId,
                        principalTable: "Equipamentos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EquipamentoIniciadorUeps_IniciadorUeps_IniciadorUepId",
                        column: x => x.IniciadorUepId,
                        principalTable: "IniciadorUeps",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Esds",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DataEvento = table.Column<DateTime>(nullable: false),
                    UepId = table.Column<int>(nullable: false),
                    NivelUepId = table.Column<int>(nullable: false),
                    EquipamentoIniciadorUepId = table.Column<int>(nullable: false),
                    MotivoCausaId = table.Column<int>(nullable: false),
                    AgenteId = table.Column<int>(nullable: false),
                    Descricao = table.Column<string>(maxLength: 255, nullable: true),
                    DescricaoCodigo = table.Column<string>(maxLength: 512, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Esds", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Esds_Agentes_AgenteId",
                        column: x => x.AgenteId,
                        principalTable: "Agentes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Esds_EquipamentoIniciadorUeps_EquipamentoIniciadorUepId",
                        column: x => x.EquipamentoIniciadorUepId,
                        principalTable: "EquipamentoIniciadorUeps",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Esds_MotivoCausas_MotivoCausaId",
                        column: x => x.MotivoCausaId,
                        principalTable: "MotivoCausas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Esds_NivelUeps_NivelUepId",
                        column: x => x.NivelUepId,
                        principalTable: "NivelUeps",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Esds_Ueps_UepId",
                        column: x => x.UepId,
                        principalTable: "Ueps",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Historicos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Descricao = table.Column<string>(maxLength: 255, nullable: true),
                    DataRegistro = table.Column<DateTime>(nullable: false),
                    EsdId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Historicos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Historicos_Esds_EsdId",
                        column: x => x.EsdId,
                        principalTable: "Esds",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Agentes_OrigemId",
                table: "Agentes",
                column: "OrigemId");

            migrationBuilder.CreateIndex(
                name: "IX_Ambientais_AgenteId",
                table: "Ambientais",
                column: "AgenteId");

            migrationBuilder.CreateIndex(
                name: "IX_Ambientais_Codigo",
                table: "Ambientais",
                column: "Codigo");

            migrationBuilder.CreateIndex(
                name: "IX_Ativos_Codigo",
                table: "Ativos",
                column: "Codigo",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Ativos_UnidadeOperativaId",
                table: "Ativos",
                column: "UnidadeOperativaId");

            migrationBuilder.CreateIndex(
                name: "IX_Causas_Codigo",
                table: "Causas",
                column: "Codigo");

            migrationBuilder.CreateIndex(
                name: "IX_EquipamentoIniciadorUeps_EquipamentoId",
                table: "EquipamentoIniciadorUeps",
                column: "EquipamentoId");

            migrationBuilder.CreateIndex(
                name: "IX_EquipamentoIniciadorUeps_IniciadorUepId",
                table: "EquipamentoIniciadorUeps",
                column: "IniciadorUepId");

            migrationBuilder.CreateIndex(
                name: "IX_Equipamentos_AgenteId",
                table: "Equipamentos",
                column: "AgenteId");

            migrationBuilder.CreateIndex(
                name: "IX_Equipamentos_Codigo",
                table: "Equipamentos",
                column: "Codigo");

            migrationBuilder.CreateIndex(
                name: "IX_Esds_AgenteId",
                table: "Esds",
                column: "AgenteId");

            migrationBuilder.CreateIndex(
                name: "IX_Esds_Codigo",
                table: "Esds",
                column: "DescricaoCodigo");

            migrationBuilder.CreateIndex(
                name: "IX_Esds_EquipamentoIniciadorUepId",
                table: "Esds",
                column: "EquipamentoIniciadorUepId");

            migrationBuilder.CreateIndex(
                name: "IX_Esds_MotivoCausaId",
                table: "Esds",
                column: "MotivoCausaId");

            migrationBuilder.CreateIndex(
                name: "IX_Esds_NivelUepId",
                table: "Esds",
                column: "NivelUepId");

            migrationBuilder.CreateIndex(
                name: "IX_Esds_UepId",
                table: "Esds",
                column: "UepId");

            migrationBuilder.CreateIndex(
                name: "IX_Historicos_EsdId",
                table: "Historicos",
                column: "EsdId");

            migrationBuilder.CreateIndex(
                name: "IX_Humanas_AgenteId",
                table: "Humanas",
                column: "AgenteId");

            migrationBuilder.CreateIndex(
                name: "IX_Humanas_Codigo",
                table: "Humanas",
                column: "Codigo");

            migrationBuilder.CreateIndex(
                name: "IX_Iniciadores_Codigo",
                table: "Iniciadores",
                column: "Codigo");

            migrationBuilder.CreateIndex(
                name: "IX_IniciadorUeps_IniciadorId",
                table: "IniciadorUeps",
                column: "IniciadorId");

            migrationBuilder.CreateIndex(
                name: "IX_IniciadorUeps_UepId",
                table: "IniciadorUeps",
                column: "UepId");

            migrationBuilder.CreateIndex(
                name: "IX_MotivoCausas_CausaId",
                table: "MotivoCausas",
                column: "CausaId");

            migrationBuilder.CreateIndex(
                name: "IX_MotivoCausas_MotivoId",
                table: "MotivoCausas",
                column: "MotivoId");

            migrationBuilder.CreateIndex(
                name: "IX_Motivos_Codigo",
                table: "Motivos",
                column: "Codigo");

            migrationBuilder.CreateIndex(
                name: "IX_Niveis_AnpNivelId",
                table: "Niveis",
                column: "AnpNivelId");

            migrationBuilder.CreateIndex(
                name: "IX_Niveis_Codigo",
                table: "Niveis",
                column: "Codigo");

            migrationBuilder.CreateIndex(
                name: "IX_NivelUeps_NivelId",
                table: "NivelUeps",
                column: "NivelId");

            migrationBuilder.CreateIndex(
                name: "IX_NivelUeps_UepId",
                table: "NivelUeps",
                column: "UepId");

            migrationBuilder.CreateIndex(
                name: "IX_Origens_Codigo",
                table: "Origens",
                column: "Codigo");

            migrationBuilder.CreateIndex(
                name: "IX_Processos_AgenteId",
                table: "Processos",
                column: "AgenteId");

            migrationBuilder.CreateIndex(
                name: "IX_Processos_Codigo",
                table: "Processos",
                column: "Codigo");

            migrationBuilder.CreateIndex(
                name: "IX_Ueps_AtivoId",
                table: "Ueps",
                column: "AtivoId");

            migrationBuilder.CreateIndex(
                name: "IX_Ueps_Codigo",
                table: "Ueps",
                column: "Codigo",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Ueps_UepTipoId",
                table: "Ueps",
                column: "UepTipoId");

            migrationBuilder.CreateIndex(
                name: "IX_UepTipos_Codigo",
                table: "UepTipos",
                column: "Codigo");

            migrationBuilder.CreateIndex(
                name: "IX_UnidadesOperativas_Codigo",
                table: "UnidadesOperativas",
                column: "Codigo",
                unique: true);

			var sqlFile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Migrations", "20190906053211_Inicial_Up.sql");
			migrationBuilder.Sql(File.ReadAllText(sqlFile));
		}

		protected override void Down(MigrationBuilder migrationBuilder)
		{
			var sqlFile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Migrations", "20190906053211_Inicial_Down.sql");
			migrationBuilder.Sql(File.ReadAllText(sqlFile));

			migrationBuilder.DropTable(
                name: "Ambientais");

            migrationBuilder.DropTable(
                name: "Historicos");

            migrationBuilder.DropTable(
                name: "Humanas");

            migrationBuilder.DropTable(
                name: "Processos");

            migrationBuilder.DropTable(
                name: "Esds");

            migrationBuilder.DropTable(
                name: "EquipamentoIniciadorUeps");

            migrationBuilder.DropTable(
                name: "MotivoCausas");

            migrationBuilder.DropTable(
                name: "NivelUeps");

            migrationBuilder.DropTable(
                name: "Equipamentos");

            migrationBuilder.DropTable(
                name: "IniciadorUeps");

            migrationBuilder.DropTable(
                name: "Causas");

            migrationBuilder.DropTable(
                name: "Motivos");

            migrationBuilder.DropTable(
                name: "Niveis");

            migrationBuilder.DropTable(
                name: "Agentes");

            migrationBuilder.DropTable(
                name: "Iniciadores");

            migrationBuilder.DropTable(
                name: "Ueps");

            migrationBuilder.DropTable(
                name: "AnpNiveis");

            migrationBuilder.DropTable(
                name: "Origens");

            migrationBuilder.DropTable(
                name: "Ativos");

            migrationBuilder.DropTable(
                name: "UepTipos");

            migrationBuilder.DropTable(
                name: "UnidadesOperativas");
        }
    }
}
