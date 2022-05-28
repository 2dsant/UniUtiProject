using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UniUti.Migrations
{
    public partial class UpdateModelsAndRelations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "cursos",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    nome = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    deletado = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cursos", x => x.id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "disciplinas",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    nome = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    descricao = table.Column<string>(type: "varchar(300)", maxLength: 300, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    deletado = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_disciplinas", x => x.id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "enderecos",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    cep = table.Column<string>(type: "varchar(8)", maxLength: 8, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    rua = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    numero = table.Column<string>(type: "varchar(8)", maxLength: 8, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    cidade = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    estado = table.Column<string>(type: "varchar(2)", maxLength: 2, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    pais = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_enderecos", x => x.id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "CursoDisciplina",
                columns: table => new
                {
                    CursosId = table.Column<long>(type: "bigint", nullable: false),
                    DisciplinasId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CursoDisciplina", x => new { x.CursosId, x.DisciplinasId });
                    table.ForeignKey(
                        name: "FK_CursoDisciplina_cursos_CursosId",
                        column: x => x.CursosId,
                        principalTable: "cursos",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CursoDisciplina_disciplinas_DisciplinasId",
                        column: x => x.DisciplinasId,
                        principalTable: "disciplinas",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "instituicoes",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    nome = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    EnderecoId = table.Column<long>(type: "bigint", nullable: false),
                    telefone = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    email = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    celular = table.Column<string>(type: "varchar(11)", maxLength: 11, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    deletado = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_instituicoes", x => x.id);
                    table.ForeignKey(
                        name: "FK_instituicoes_enderecos_EnderecoId",
                        column: x => x.EnderecoId,
                        principalTable: "enderecos",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "CursoInstituicao",
                columns: table => new
                {
                    CursosId = table.Column<long>(type: "bigint", nullable: false),
                    InstituicoesId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CursoInstituicao", x => new { x.CursosId, x.InstituicoesId });
                    table.ForeignKey(
                        name: "FK_CursoInstituicao_cursos_CursosId",
                        column: x => x.CursosId,
                        principalTable: "cursos",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CursoInstituicao_instituicoes_InstituicoesId",
                        column: x => x.InstituicoesId,
                        principalTable: "instituicoes",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "usuarios",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    nome = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    email = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    senha_hash = table.Column<byte[]>(type: "longblob", nullable: false),
                    senha_salt = table.Column<byte[]>(type: "longblob", nullable: false),
                    celular = table.Column<string>(type: "varchar(11)", maxLength: 11, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    InstituicaoId = table.Column<long>(type: "bigint", nullable: false),
                    CursoId = table.Column<long>(type: "bigint", nullable: false),
                    deletado = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_usuarios", x => x.id);
                    table.ForeignKey(
                        name: "FK_usuarios_cursos_CursoId",
                        column: x => x.CursoId,
                        principalTable: "cursos",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_usuarios_instituicoes_InstituicaoId",
                        column: x => x.InstituicaoId,
                        principalTable: "instituicoes",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "monitorias",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    SolicitanteId = table.Column<long>(type: "bigint", nullable: false),
                    PrestadorId = table.Column<long>(type: "bigint", nullable: false),
                    descricao = table.Column<string>(type: "varchar(500)", maxLength: 500, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DisciplinaId = table.Column<long>(type: "bigint", nullable: false),
                    data_solicitacao = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    status_solicitacao = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_monitorias", x => x.id);
                    table.ForeignKey(
                        name: "FK_monitorias_disciplinas_DisciplinaId",
                        column: x => x.DisciplinaId,
                        principalTable: "disciplinas",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_monitorias_usuarios_PrestadorId",
                        column: x => x.PrestadorId,
                        principalTable: "usuarios",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_monitorias_usuarios_SolicitanteId",
                        column: x => x.SolicitanteId,
                        principalTable: "usuarios",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_CursoDisciplina_DisciplinasId",
                table: "CursoDisciplina",
                column: "DisciplinasId");

            migrationBuilder.CreateIndex(
                name: "IX_CursoInstituicao_InstituicoesId",
                table: "CursoInstituicao",
                column: "InstituicoesId");

            migrationBuilder.CreateIndex(
                name: "IX_instituicoes_EnderecoId",
                table: "instituicoes",
                column: "EnderecoId");

            migrationBuilder.CreateIndex(
                name: "IX_monitorias_DisciplinaId",
                table: "monitorias",
                column: "DisciplinaId");

            migrationBuilder.CreateIndex(
                name: "IX_monitorias_PrestadorId",
                table: "monitorias",
                column: "PrestadorId");

            migrationBuilder.CreateIndex(
                name: "IX_monitorias_SolicitanteId",
                table: "monitorias",
                column: "SolicitanteId");

            migrationBuilder.CreateIndex(
                name: "IX_usuarios_CursoId",
                table: "usuarios",
                column: "CursoId");

            migrationBuilder.CreateIndex(
                name: "IX_usuarios_InstituicaoId",
                table: "usuarios",
                column: "InstituicaoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CursoDisciplina");

            migrationBuilder.DropTable(
                name: "CursoInstituicao");

            migrationBuilder.DropTable(
                name: "monitorias");

            migrationBuilder.DropTable(
                name: "disciplinas");

            migrationBuilder.DropTable(
                name: "usuarios");

            migrationBuilder.DropTable(
                name: "cursos");

            migrationBuilder.DropTable(
                name: "instituicoes");

            migrationBuilder.DropTable(
                name: "enderecos");
        }
    }
}
