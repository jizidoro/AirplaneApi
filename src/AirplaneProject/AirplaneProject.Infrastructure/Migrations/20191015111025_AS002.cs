using System;
using System.IO;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AirplaneProject.Infrastructure.Migrations
{
	public partial class AS002 : Migration
	{
		protected override void Up(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.DropForeignKey(
				name: "FK_EquipamentoIniciadorUeps_IniciadorUeps_IniciadorUepId",
				table: "EquipamentoIniciadorUeps");

			migrationBuilder.DropForeignKey(
				name: "FK_EquipamentoIniciadorUeps_Equipamentos_EquipamentoId",
				table: "EquipamentoIniciadorUeps");

			migrationBuilder.DropForeignKey(
				name: "FK_IniciadorUeps_Iniciadores_IniciadorId",
				table: "IniciadorUeps");

			migrationBuilder.DropForeignKey(
				name: "FK_Agentes_Origens_OrigemId",
				table: "Agentes");

			migrationBuilder.DropForeignKey(
				name: "FK_Esds_Agentes_AgenteId",
				table: "Esds");

			migrationBuilder.DropForeignKey(
				name: "FK_Esds_EquipamentoIniciadorUeps_EquipamentoIniciadorUepId",
				table: "Esds");

			migrationBuilder.DropForeignKey(
				name: "FK_Esds_NivelUeps_NivelUepId",
				table: "Esds");

			migrationBuilder.DropIndex(
				name: "IX_EquipamentoIniciadorUeps_IniciadorUepId",
				table: "EquipamentoIniciadorUeps");

			migrationBuilder.DropIndex(
				name: "IX_IniciadorUeps_UepId",
				table: "IniciadorUeps");

			migrationBuilder.DropIndex(
				name: "IX_Iniciadores_Codigo",
				table: "Iniciadores");

			migrationBuilder.AddColumn<int>(
				name: "EventoIniciadorId",
				table: "Esds",
				nullable: false,
				defaultValue: 0);

			migrationBuilder.AddColumn<int>(
				name: "NivelOperacaoId",
				table: "Esds",
				nullable: false,
				defaultValue: 0);

			migrationBuilder.AddColumn<int>(
				name: "OrigemAgenteId",
				table: "Esds",
				nullable: false,
				defaultValue: 0);

			migrationBuilder.AddColumn<int>(
				name: "OperacaoId",
				table: "Ueps",
				nullable: false,
				defaultValue: 0);

			migrationBuilder.AddColumn<string>(
				name: "ChaveUsuario",
				table: "Historicos",
				maxLength: 12,
				nullable: false,
				defaultValue: "");

			migrationBuilder.AddColumn<DateTime>(
				name: "DataAlteracao",
				table: "Historicos",
				nullable: false,
				defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

			migrationBuilder.AddColumn<DateTime>(
				name: "DataEvento",
				table: "Historicos",
				nullable: false,
				defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

			migrationBuilder.AddColumn<string>(
				name: "DescricaoCodigo",
				table: "Historicos",
				maxLength: 512,
				nullable: true);

			migrationBuilder.AddColumn<int>(
				name: "EventoIniciadorId",
				table: "Historicos",
				nullable: false,
				defaultValue: 0);

			migrationBuilder.AddColumn<int>(
				name: "MotivoCausaId",
				table: "Historicos",
				nullable: false,
				defaultValue: 0);

			migrationBuilder.AddColumn<int>(
				name: "NivelOperacaoId",
				table: "Historicos",
				nullable: false,
				defaultValue: 0);

			migrationBuilder.AddColumn<int>(
				name: "OrigemAgenteId",
				table: "Historicos",
				nullable: false,
				defaultValue: 0);

			migrationBuilder.AddColumn<int>(
				name: "UepId",
				table: "Historicos",
				nullable: false,
				defaultValue: 0);

			migrationBuilder.AddColumn<string>(
				name: "ChaveUsuario",
				table: "Esds",
				maxLength: 12,
				nullable: false,
				defaultValue: "");

			migrationBuilder.AddColumn<DateTime>(
				name: "DataRegistro",
				table: "Esds",
				nullable: false,
				defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

			migrationBuilder.AddColumn<string>(
				name: "Codigo",
				table: "Agentes",
				maxLength: 50,
				nullable: false,
				defaultValue: "");

			migrationBuilder.AddColumn<string>(
				name: "Descricao",
				table: "Agentes",
				maxLength: 255,
				nullable: true);

			migrationBuilder.AddColumn<string>(
				name: "Nome",
				table: "Agentes",
				maxLength: 50,
				nullable: false,
				defaultValue: "");

			migrationBuilder.CreateTable(
				name: "Eventos",
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
					table.PrimaryKey("PK_Eventos", x => x.Id);
				});

			var sqlFile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Migrations", "20191015111025_AS002_Eventos_Up.sql");
			migrationBuilder.Sql(File.ReadAllText(sqlFile));

			migrationBuilder.CreateTable(
				name: "Operacoes",
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
					table.PrimaryKey("PK_Operacoes", x => x.Id);
				});

			migrationBuilder.CreateTable(
				name: "OrigemAgentes",
				columns: table => new
				{
					Id = table.Column<int>(nullable: false)
						.Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
					OrigemId = table.Column<int>(nullable: false),
					AgenteId = table.Column<int>(nullable: false)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_OrigemAgentes", x => x.Id);
					table.ForeignKey(
						name: "FK_OrigemAgentes_Agentes_AgenteId",
						column: x => x.AgenteId,
						principalTable: "Agentes",
						principalColumn: "Id",
						onDelete: ReferentialAction.Cascade);
					table.ForeignKey(
						name: "FK_OrigemAgentes_Origens_OrigemId",
						column: x => x.OrigemId,
						principalTable: "Origens",
						principalColumn: "Id",
						onDelete: ReferentialAction.Cascade);
				});

			migrationBuilder.CreateTable(
				name: "EventoIniciadores",
				columns: table => new
				{
					Id = table.Column<int>(nullable: false)
						.Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
					EventoId = table.Column<int>(nullable: false),
					IniciadorId = table.Column<int>(nullable: false)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_EventoIniciadores", x => x.Id);
					table.ForeignKey(
						name: "FK_EventoIniciadores_Eventos_EventoId",
						column: x => x.EventoId,
						principalTable: "Eventos",
						principalColumn: "Id",
						onDelete: ReferentialAction.Restrict);
					table.ForeignKey(
						name: "FK_EventoIniciadores_Iniciadores_IniciadorId",
						column: x => x.IniciadorId,
						principalTable: "Iniciadores",
						principalColumn: "Id",
						onDelete: ReferentialAction.Restrict);
				});

			migrationBuilder.CreateTable(
				name: "NivelOperacoes",
				columns: table => new
				{
					Id = table.Column<int>(nullable: false)
						.Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
					OperacaoId = table.Column<int>(nullable: false),
					NivelId = table.Column<int>(nullable: false)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_NivelOperacoes", x => x.Id);
					table.ForeignKey(
						name: "FK_NivelOperacoes_Niveis_NivelId",
						column: x => x.NivelId,
						principalTable: "Niveis",
						principalColumn: "Id",
						onDelete: ReferentialAction.Restrict);
					table.ForeignKey(
						name: "FK_NivelOperacoes_Operacoes_OperacaoId",
						column: x => x.OperacaoId,
						principalTable: "Operacoes",
						principalColumn: "Id",
						onDelete: ReferentialAction.Restrict);
				});

			sqlFile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Migrations", "20191015111025_AS002_Up.sql");
			migrationBuilder.Sql(File.ReadAllText(sqlFile));

			migrationBuilder.CreateIndex(
				name: "IX_Esds_EventoIniciadorId",
				table: "Esds",
				column: "EventoIniciadorId");

			migrationBuilder.CreateIndex(
				name: "IX_Esds_NivelOperacaoId",
				table: "Esds",
				column: "NivelOperacaoId");

			migrationBuilder.CreateIndex(
				name: "IX_Esds_OrigemAgenteId",
				table: "Esds",
				column: "OrigemAgenteId");

			migrationBuilder.CreateIndex(
				name: "IX_Ueps_OperacaoId",
				table: "Ueps",
				column: "OperacaoId");

			migrationBuilder.CreateIndex(
				name: "IX_Historicos_DescricaoCodigo",
				table: "Historicos",
				column: "DescricaoCodigo");

			migrationBuilder.CreateIndex(
				name: "IX_Historicos_EventoIniciadorId",
				table: "Historicos",
				column: "EventoIniciadorId");

			migrationBuilder.CreateIndex(
				name: "IX_Historicos_MotivoCausaId",
				table: "Historicos",
				column: "MotivoCausaId");

			migrationBuilder.CreateIndex(
				name: "IX_Historicos_NivelOperacaoId",
				table: "Historicos",
				column: "NivelOperacaoId");

			migrationBuilder.CreateIndex(
				name: "IX_Historicos_OrigemAgenteId",
				table: "Historicos",
				column: "OrigemAgenteId");

			migrationBuilder.CreateIndex(
				name: "IX_Historicos_UepId",
				table: "Historicos",
				column: "UepId");

			migrationBuilder.CreateIndex(
				name: "IX_EventoIniciadores_EventoId",
				table: "EventoIniciadores",
				column: "EventoId");

			migrationBuilder.CreateIndex(
				name: "IX_EventoIniciadores_IniciadorId",
				table: "EventoIniciadores",
				column: "IniciadorId");

			migrationBuilder.CreateIndex(
				name: "IX_Eventos_Codigo",
				table: "Eventos",
				column: "Codigo");

			migrationBuilder.CreateIndex(
				name: "IX_Iniciadores_Codigo",
				table: "Iniciadores",
				column: "Codigo");

			migrationBuilder.CreateIndex(
				name: "IX_NivelOperacoes_NivelId",
				table: "NivelOperacoes",
				column: "NivelId");

			migrationBuilder.CreateIndex(
				name: "IX_NivelOperacoes_OperacaoId",
				table: "NivelOperacoes",
				column: "OperacaoId");

			migrationBuilder.CreateIndex(
				name: "IX_OrigemAgentes_AgenteId",
				table: "OrigemAgentes",
				column: "AgenteId");

			migrationBuilder.CreateIndex(
				name: "IX_OrigemAgentes_OrigemId",
				table: "OrigemAgentes",
				column: "OrigemId");

			migrationBuilder.AddForeignKey(
				name: "FK_Esds_EventoIniciadores_EventoIniciadorId",
				table: "Esds",
				column: "EventoIniciadorId",
				principalTable: "EventoIniciadores",
				principalColumn: "Id",
				onDelete: ReferentialAction.Restrict);

			migrationBuilder.AddForeignKey(
				name: "FK_Esds_NivelOperacoes_NivelOperacaoId",
				table: "Esds",
				column: "NivelOperacaoId",
				principalTable: "NivelOperacoes",
				principalColumn: "Id",
				onDelete: ReferentialAction.Restrict);

			migrationBuilder.AddForeignKey(
				name: "FK_Esds_OrigemAgentes_OrigemAgenteId",
				table: "Esds",
				column: "OrigemAgenteId",
				principalTable: "OrigemAgentes",
				principalColumn: "Id",
				onDelete: ReferentialAction.Restrict);

			migrationBuilder.AddForeignKey(
				name: "FK_Historicos_EventoIniciadores_EventoIniciadorId",
				table: "Historicos",
				column: "EventoIniciadorId",
				principalTable: "EventoIniciadores",
				principalColumn: "Id",
				onDelete: ReferentialAction.Restrict);

			migrationBuilder.AddForeignKey(
				name: "FK_Historicos_MotivoCausas_MotivoCausaId",
				table: "Historicos",
				column: "MotivoCausaId",
				principalTable: "MotivoCausas",
				principalColumn: "Id",
				onDelete: ReferentialAction.Restrict);

			migrationBuilder.AddForeignKey(
				name: "FK_Historicos_NivelOperacoes_NivelOperacaoId",
				table: "Historicos",
				column: "NivelOperacaoId",
				principalTable: "NivelOperacoes",
				principalColumn: "Id",
				onDelete: ReferentialAction.Restrict);

			migrationBuilder.AddForeignKey(
				name: "FK_Historicos_OrigemAgentes_OrigemAgenteId",
				table: "Historicos",
				column: "OrigemAgenteId",
				principalTable: "OrigemAgentes",
				principalColumn: "Id",
				onDelete: ReferentialAction.Restrict);

			migrationBuilder.AddForeignKey(
				name: "FK_Historicos_Ueps_UepId",
				table: "Historicos",
				column: "UepId",
				principalTable: "Ueps",
				principalColumn: "Id",
				onDelete: ReferentialAction.Restrict);

			migrationBuilder.AddForeignKey(
				name: "FK_Ueps_Operacoes_OperacaoId",
				table: "Ueps",
				column: "OperacaoId",
				principalTable: "Operacoes",
				principalColumn: "Id",
				onDelete: ReferentialAction.Cascade);

			migrationBuilder.DropTable(
				name: "Ambientais");

			migrationBuilder.DropTable(
				name: "EquipamentoIniciadorUeps");

			migrationBuilder.DropTable(
				name: "Humanas");

			migrationBuilder.DropTable(
				name: "NivelUeps");

			migrationBuilder.DropTable(
				name: "Processos");

			migrationBuilder.DropTable(
				name: "Equipamentos");

			migrationBuilder.DropTable(
				name: "IniciadorUeps");

			migrationBuilder.DropIndex(
				name: "IX_Agentes_OrigemId",
				table: "Agentes");

			migrationBuilder.DropIndex(
				name: "IX_Esds_NivelUepId",
				table: "Esds");

			migrationBuilder.DropIndex(
				name: "IX_Esds_EquipamentoIniciadorUepId",
				table: "Esds");

			migrationBuilder.DropIndex(
				name: "IX_Esds_AgenteId",
				table: "Esds");

			migrationBuilder.DropColumn(
				name: "OrigemId",
				table: "Agentes");

			migrationBuilder.DropColumn(
				name: "NivelUepId",
				table: "Esds");

			migrationBuilder.DropColumn(
				name: "EquipamentoIniciadorUepId",
				table: "Esds");

			migrationBuilder.DropColumn(
				name: "AgenteId",
				table: "Esds");
		}

		protected override void Down(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.DropForeignKey(
				name: "FK_Esds_EventoIniciadores_EventoIniciadorId",
				table: "Esds");

			migrationBuilder.DropForeignKey(
				name: "FK_Esds_NivelOperacoes_NivelOperacaoId",
				table: "Esds");

			migrationBuilder.DropForeignKey(
				name: "FK_Esds_OrigemAgentes_OrigemAgenteId",
				table: "Esds");

			migrationBuilder.DropForeignKey(
				name: "FK_Historicos_EventoIniciadores_EventoIniciadorId",
				table: "Historicos");

			migrationBuilder.DropForeignKey(
				name: "FK_Historicos_MotivoCausas_MotivoCausaId",
				table: "Historicos");

			migrationBuilder.DropForeignKey(
				name: "FK_Historicos_NivelOperacoes_NivelOperacaoId",
				table: "Historicos");

			migrationBuilder.DropForeignKey(
				name: "FK_Historicos_OrigemAgentes_OrigemAgenteId",
				table: "Historicos");

			migrationBuilder.DropForeignKey(
				name: "FK_Historicos_Ueps_UepId",
				table: "Historicos");

			migrationBuilder.DropForeignKey(
				name: "FK_Ueps_Operacoes_OperacaoId",
				table: "Ueps");

			migrationBuilder.DropTable(
				name: "EventoIniciadores");

			migrationBuilder.DropTable(
				name: "NivelOperacoes");

			migrationBuilder.DropTable(
				name: "OrigemAgentes");

			migrationBuilder.DropTable(
				name: "Eventos");

			migrationBuilder.DropTable(
				name: "Operacoes");

			migrationBuilder.DropIndex(
				name: "IX_Ueps_OperacaoId",
				table: "Ueps");

			migrationBuilder.DropIndex(
				name: "IX_Historicos_Codigo",
				table: "Historicos");

			migrationBuilder.DropIndex(
				name: "IX_Historicos_EventoIniciadorId",
				table: "Historicos");

			migrationBuilder.DropIndex(
				name: "IX_Historicos_MotivoCausaId",
				table: "Historicos");

			migrationBuilder.DropIndex(
				name: "IX_Historicos_NivelOperacaoId",
				table: "Historicos");

			migrationBuilder.DropIndex(
				name: "IX_Historicos_OrigemAgenteId",
				table: "Historicos");

			migrationBuilder.DropIndex(
				name: "IX_Historicos_UepId",
				table: "Historicos");

			migrationBuilder.DropColumn(
				name: "OperacaoId",
				table: "Ueps");

			migrationBuilder.DropColumn(
				name: "ChaveUsuario",
				table: "Historicos");

			migrationBuilder.DropColumn(
				name: "DataAlteracao",
				table: "Historicos");

			migrationBuilder.DropColumn(
				name: "DataEvento",
				table: "Historicos");

			migrationBuilder.DropColumn(
				name: "DescricaoCodigo",
				table: "Historicos");

			migrationBuilder.DropColumn(
				name: "EventoIniciadorId",
				table: "Historicos");

			migrationBuilder.DropColumn(
				name: "MotivoCausaId",
				table: "Historicos");

			migrationBuilder.DropColumn(
				name: "NivelOperacaoId",
				table: "Historicos");

			migrationBuilder.DropColumn(
				name: "OrigemAgenteId",
				table: "Historicos");

			migrationBuilder.DropColumn(
				name: "UepId",
				table: "Historicos");

			migrationBuilder.DropColumn(
				name: "ChaveUsuario",
				table: "Esds");

			migrationBuilder.DropColumn(
				name: "DataRegistro",
				table: "Esds");

			migrationBuilder.DropColumn(
				name: "Codigo",
				table: "Agentes");

			migrationBuilder.DropColumn(
				name: "Descricao",
				table: "Agentes");

			migrationBuilder.DropColumn(
				name: "Nome",
				table: "Agentes");

			migrationBuilder.RenameColumn(
				name: "OrigemAgenteId",
				table: "Esds",
				newName: "NivelUepId");

			migrationBuilder.RenameColumn(
				name: "NivelOperacaoId",
				table: "Esds",
				newName: "EquipamentoIniciadorUepId");

			migrationBuilder.RenameColumn(
				name: "EventoIniciadorId",
				table: "Esds",
				newName: "AgenteId");

			migrationBuilder.RenameIndex(
				name: "IX_Esds_OrigemAgenteId",
				table: "Esds",
				newName: "IX_Esds_NivelUepId");

			migrationBuilder.RenameIndex(
				name: "IX_Esds_NivelOperacaoId",
				table: "Esds",
				newName: "IX_Esds_EquipamentoIniciadorUepId");

			migrationBuilder.RenameIndex(
				name: "IX_Esds_EventoIniciadorId",
				table: "Esds",
				newName: "IX_Esds_AgenteId");

			migrationBuilder.AddColumn<int>(
				name: "OrigemId",
				table: "Agentes",
				nullable: false,
				defaultValue: 0);

			migrationBuilder.CreateTable(
				name: "Ambientais",
				columns: table => new
				{
					Id = table.Column<int>(nullable: false)
						.Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
					AgenteId = table.Column<int>(nullable: false),
					Codigo = table.Column<string>(maxLength: 50, nullable: false),
					Descricao = table.Column<string>(maxLength: 255, nullable: true),
					Nome = table.Column<string>(maxLength: 50, nullable: false)
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
					AgenteId = table.Column<int>(nullable: true),
					Codigo = table.Column<string>(maxLength: 50, nullable: false),
					Descricao = table.Column<string>(maxLength: 255, nullable: true),
					Nome = table.Column<string>(maxLength: 50, nullable: false)
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
					AgenteId = table.Column<int>(nullable: false),
					Codigo = table.Column<string>(maxLength: 50, nullable: false),
					Descricao = table.Column<string>(maxLength: 255, nullable: true),
					Nome = table.Column<string>(maxLength: 50, nullable: false)
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
				name: "IniciadorUeps",
				columns: table => new
				{
					Id = table.Column<int>(nullable: false)
						.Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
					IniciadorId = table.Column<int>(nullable: false),
					UepId = table.Column<int>(nullable: false)
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
					NivelId = table.Column<int>(nullable: false),
					UepId = table.Column<int>(nullable: false)
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
				name: "Processos",
				columns: table => new
				{
					Id = table.Column<int>(nullable: false)
						.Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
					AgenteId = table.Column<int>(nullable: false),
					Codigo = table.Column<string>(maxLength: 50, nullable: false),
					Descricao = table.Column<string>(maxLength: 255, nullable: true),
					Nome = table.Column<string>(maxLength: 50, nullable: false)
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
				name: "vwAgenteEspecifico",
				columns: table => new
				{
					Id = table.Column<int>(nullable: false)
						.Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
					AgenteGenericoId = table.Column<int>(nullable: false),
					Codigo = table.Column<string>(maxLength: 50, nullable: false),
					Nome = table.Column<string>(maxLength: 50, nullable: false),
					OrigemId = table.Column<int>(nullable: false)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_vwAgenteEspecifico", x => x.Id);
				});

			migrationBuilder.CreateTable(
				name: "vwAgenteGenerico",
				columns: table => new
				{
					Id = table.Column<int>(nullable: false)
						.Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
					AgenteId = table.Column<int>(nullable: false),
					Codigo = table.Column<string>(maxLength: 50, nullable: false),
					Nome = table.Column<string>(maxLength: 50, nullable: false)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_vwAgenteGenerico", x => x.Id);
				});

			migrationBuilder.CreateTable(
				name: "vwAgenteOrigem",
				columns: table => new
				{
					Id = table.Column<int>(nullable: false)
						.Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
					Codigo = table.Column<string>(maxLength: 50, nullable: false),
					Nome = table.Column<string>(maxLength: 50, nullable: false),
					OrigemId = table.Column<int>(nullable: false),
					OrigemNome = table.Column<string>(maxLength: 50, nullable: false)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_vwAgenteOrigem", x => x.Id);
				});

			migrationBuilder.CreateTable(
				name: "vwEquipamentoIniciadorUep",
				columns: table => new
				{
					Id = table.Column<int>(nullable: false)
						.Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
					EquipamentoId = table.Column<int>(nullable: false),
					EquipamentoNome = table.Column<string>(maxLength: 50, nullable: false),
					IniciadorId = table.Column<int>(nullable: false),
					IniciadorNome = table.Column<string>(maxLength: 50, nullable: false),
					UepId = table.Column<int>(nullable: false),
					UepNome = table.Column<string>(maxLength: 50, nullable: false)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_vwEquipamentoIniciadorUep", x => x.Id);
				});

			migrationBuilder.CreateTable(
				name: "vwIniciadorUep",
				columns: table => new
				{
					Id = table.Column<int>(nullable: false)
						.Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
					IniciadorId = table.Column<int>(nullable: false),
					IniciadorNome = table.Column<string>(maxLength: 50, nullable: false),
					UepId = table.Column<int>(nullable: false),
					UepNome = table.Column<string>(maxLength: 50, nullable: false)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_vwIniciadorUep", x => x.Id);
				});

			migrationBuilder.CreateTable(
				name: "vwNivelUep",
				columns: table => new
				{
					Id = table.Column<int>(nullable: false)
						.Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
					NivelId = table.Column<int>(nullable: false),
					NivelNome = table.Column<string>(maxLength: 50, nullable: false),
					UepId = table.Column<int>(nullable: false),
					UepNome = table.Column<string>(maxLength: 50, nullable: false)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_vwNivelUep", x => x.Id);
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
				name: "IX_Humanas_AgenteId",
				table: "Humanas",
				column: "AgenteId");

			migrationBuilder.CreateIndex(
				name: "IX_Humanas_Codigo",
				table: "Humanas",
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
				name: "IX_NivelUeps_NivelId",
				table: "NivelUeps",
				column: "NivelId");

			migrationBuilder.CreateIndex(
				name: "IX_NivelUeps_UepId",
				table: "NivelUeps",
				column: "UepId");

			migrationBuilder.CreateIndex(
				name: "IX_Processos_AgenteId",
				table: "Processos",
				column: "AgenteId");

			migrationBuilder.CreateIndex(
				name: "IX_Processos_Codigo",
				table: "Processos",
				column: "Codigo");

			migrationBuilder.AddForeignKey(
				name: "FK_Agentes_Origens_OrigemId",
				table: "Agentes",
				column: "OrigemId",
				principalTable: "Origens",
				principalColumn: "Id",
				onDelete: ReferentialAction.Restrict);

			migrationBuilder.AddForeignKey(
				name: "FK_Esds_Agentes_AgenteId",
				table: "Esds",
				column: "AgenteId",
				principalTable: "Agentes",
				principalColumn: "Id",
				onDelete: ReferentialAction.Restrict);

			migrationBuilder.AddForeignKey(
				name: "FK_Esds_EquipamentoIniciadorUeps_EquipamentoIniciadorUepId",
				table: "Esds",
				column: "EquipamentoIniciadorUepId",
				principalTable: "EquipamentoIniciadorUeps",
				principalColumn: "Id",
				onDelete: ReferentialAction.Restrict);

			migrationBuilder.AddForeignKey(
				name: "FK_Esds_NivelUeps_NivelUepId",
				table: "Esds",
				column: "NivelUepId",
				principalTable: "NivelUeps",
				principalColumn: "Id",
				onDelete: ReferentialAction.Restrict);
		}
	}
}
