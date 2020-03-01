using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AirplaneProject.Infrastructure.Migrations
{
    public partial class AS004_AddModuloSobressalente : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.CreateTable(
                name: "Almoxarifados",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(maxLength: 20, nullable: false),
                    Codigo = table.Column<string>(maxLength: 20, nullable: false),
                    CodigoSAP = table.Column<string>(maxLength: 50, nullable: false),
                    Descricao = table.Column<string>(maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Almoxarifados", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CategoriaMateriais",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(maxLength: 20, nullable: false),
                    Codigo = table.Column<string>(maxLength: 20, nullable: false),
                    Descricao = table.Column<string>(maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoriaMateriais", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Fabricantes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(maxLength: 20, nullable: false),
                    Codigo = table.Column<string>(maxLength: 20, nullable: false),
                    CodigoSAP = table.Column<string>(maxLength: 50, nullable: false),
                    Descricao = table.Column<string>(maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fabricantes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UepAlmoxarifado",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UepId = table.Column<int>(nullable: false),
                    AlmoxarifadoId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UepAlmoxarifado", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UepAlmoxarifado_Almoxarifados_AlmoxarifadoId",
                        column: x => x.AlmoxarifadoId,
                        principalTable: "Almoxarifados",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UepAlmoxarifado_Ueps_UepId",
                        column: x => x.UepId,
                        principalTable: "Ueps",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ClasseMateriais",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CategoriaMaterialId = table.Column<int>(nullable: false),
                    Nome = table.Column<string>(maxLength: 20, nullable: false),
                    Codigo = table.Column<string>(maxLength: 20, nullable: false),
                    Descricao = table.Column<string>(maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClasseMateriais", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ClasseMateriais_CategoriaMateriais_CategoriaMaterialId",
                        column: x => x.CategoriaMaterialId,
                        principalTable: "CategoriaMateriais",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MaterialFornecidos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ClasseMaterialId = table.Column<int>(nullable: false),
                    FabricanteId = table.Column<int>(nullable: false),
                    Nome = table.Column<string>(maxLength: 20, nullable: false),
                    Codigo = table.Column<string>(maxLength: 20, nullable: false),
                    Descricao = table.Column<string>(maxLength: 255, nullable: false),
                    PartNumber = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MaterialFornecidos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MaterialFornecidos_ClasseMateriais_ClasseMaterialId",
                        column: x => x.ClasseMaterialId,
                        principalTable: "ClasseMateriais",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MaterialFornecidos_Fabricantes_FabricanteId",
                        column: x => x.FabricanteId,
                        principalTable: "Fabricantes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MaterialEstocados",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AlmoxarifadoId = table.Column<int>(nullable: false),
                    MaterialFornecidoId = table.Column<int>(nullable: false),
                    Nome = table.Column<string>(maxLength: 20, nullable: false),
                    Codigo = table.Column<string>(maxLength: 20, nullable: false),
                    Descricao = table.Column<string>(maxLength: 255, nullable: false),
                    Mrp = table.Column<string>(maxLength: 20, nullable: false),
                    Reabastecimento = table.Column<string>(maxLength: 20, nullable: false),
                    Maximo = table.Column<double>(nullable: false),
                    Estoque = table.Column<double>(nullable: false),
                    Situacao = table.Column<string>(maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MaterialEstocados", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MaterialEstocados_Almoxarifados_AlmoxarifadoId",
                        column: x => x.AlmoxarifadoId,
                        principalTable: "Almoxarifados",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MaterialEstocados_MaterialFornecidos_MaterialFornecidoId",
                        column: x => x.MaterialFornecidoId,
                        principalTable: "MaterialFornecidos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Almoxarifados_Codigo",
                table: "Almoxarifados",
                column: "Codigo",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CategoriaMaterials_Codigo",
                table: "CategoriaMateriais",
                column: "Codigo",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ClasseMateriais_CategoriaMaterialId",
                table: "ClasseMateriais",
                column: "CategoriaMaterialId");

            migrationBuilder.CreateIndex(
                name: "IX_ClasseMaterials_Codigo",
                table: "ClasseMateriais",
                column: "Codigo",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Fabricantes_Codigo",
                table: "Fabricantes",
                column: "Codigo",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_MaterialEstocados_AlmoxarifadoId",
                table: "MaterialEstocados",
                column: "AlmoxarifadoId");

            migrationBuilder.CreateIndex(
                name: "IX_MaterialEstocados_Codigo",
                table: "MaterialEstocados",
                column: "Codigo",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_MaterialEstocados_MaterialFornecidoId",
                table: "MaterialEstocados",
                column: "MaterialFornecidoId");

            migrationBuilder.CreateIndex(
                name: "IX_MaterialFornecidos_ClasseMaterialId",
                table: "MaterialFornecidos",
                column: "ClasseMaterialId");

            migrationBuilder.CreateIndex(
                name: "IX_MaterialFornecidos_Codigo",
                table: "MaterialFornecidos",
                column: "Codigo",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_MaterialFornecidos_FabricanteId",
                table: "MaterialFornecidos",
                column: "FabricanteId");

            migrationBuilder.CreateIndex(
                name: "IX_UepAlmoxarifado_AlmoxarifadoId",
                table: "UepAlmoxarifado",
                column: "AlmoxarifadoId");

            migrationBuilder.CreateIndex(
                name: "IX_UepAlmoxarifado_UepId",
                table: "UepAlmoxarifado",
                column: "UepId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MaterialEstocados");

            migrationBuilder.DropTable(
                name: "UepAlmoxarifado");

            migrationBuilder.DropTable(
                name: "MaterialFornecidos");

            migrationBuilder.DropTable(
                name: "Almoxarifados");

            migrationBuilder.DropTable(
                name: "ClasseMateriais");

            migrationBuilder.DropTable(
                name: "Fabricantes");

            migrationBuilder.DropTable(
                name: "CategoriaMateriais");
        }
    }
}
