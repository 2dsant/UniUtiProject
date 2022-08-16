using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UniUti.Infra.Data.Migrations
{
    public partial class UpdateInstituicao : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_instituicoes_cursos_CursoId",
                table: "instituicoes");

            migrationBuilder.DropIndex(
                name: "IX_instituicoes_CursoId",
                table: "instituicoes");

            migrationBuilder.DropColumn(
                name: "CursoId",
                table: "instituicoes");

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

            migrationBuilder.CreateIndex(
                name: "IX_CursoInstituicao_InstituicoesId",
                table: "CursoInstituicao",
                column: "InstituicoesId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CursoInstituicao");

            migrationBuilder.AddColumn<long>(
                name: "CursoId",
                table: "instituicoes",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_instituicoes_CursoId",
                table: "instituicoes",
                column: "CursoId");

            migrationBuilder.AddForeignKey(
                name: "FK_instituicoes_cursos_CursoId",
                table: "instituicoes",
                column: "CursoId",
                principalTable: "cursos",
                principalColumn: "id");
        }
    }
}
